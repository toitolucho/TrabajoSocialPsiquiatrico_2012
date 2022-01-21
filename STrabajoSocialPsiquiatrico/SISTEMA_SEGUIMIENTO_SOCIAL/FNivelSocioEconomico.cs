using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_SocialTableAdapters;

namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    public partial class FNivelSocioEconomico : Form
    {
        QTAFuncionesSistema TAFuncionesSistema;
        PreguntasValoracionTableAdapter TAPreguntasValoracion;
        RespuestasValoracionTableAdapter TARespuestasValoracion;
        CategoriasTableAdapter TACategorias;
        ValoracionSocioeconomicaTableAdapter TAValoracionSocioeconomica;
        


        DSTrabajo_Social.PreguntasValoracionDataTable DTPreguntasValoracion;
        public DSTrabajo_Social.RespuestasValoracionDataTable DTRespuestasValoracion;
        DSTrabajo_Social.CategoriasDataTable DTCategorias;
        DSTrabajo_Social.ValoracionSocioeconomicaDataTable DTValoracionSocioeconomica;
        DSTrabajo_Social.ValoracionSocioeconomicaDataTable DTValoracionSocioeconomicaTemporal;
        //TAValoracionSocioEocnomica.GetDataByNombreRespuesta(NumeroPaciente);
        DateTime? FechaHoraValoracionSocioEconomica = null;


        DataSet DSValoracionSocioEconomica;

        private string TipoOperacion;
        public int CodigoCategoria;
        public string NombreCategoria;
        private int? NumeroPaciente;
        public FNivelSocioEconomico(string NombreCompleto, string TipoOperacion, int? NumeroPaciente)
        {
            InitializeComponent();
            TxtNombreApellidoPaciente.Text = NombreCompleto;
            this.NumeroPaciente = NumeroPaciente;
            this.TipoOperacion = TipoOperacion;

            DSValoracionSocioEconomica = new DataSet("ValoracionSocioEconomica");
            TAPreguntasValoracion = new PreguntasValoracionTableAdapter();
            TARespuestasValoracion = new RespuestasValoracionTableAdapter();
            TAFuncionesSistema = new QTAFuncionesSistema();
            TACategorias = new CategoriasTableAdapter();
            TAValoracionSocioeconomica = new ValoracionSocioeconomicaTableAdapter();


            //para cargar las columnas axuiliares
            DTValoracionSocioeconomicaTemporal = TAValoracionSocioeconomica.GetDataByNombreRespuesta(NumeroPaciente, null );
            if (DTValoracionSocioeconomicaTemporal.Rows.Count > 0)
            {
                DTValoracionSocioeconomicaTemporal.Rows.RemoveAt(0);
                DTValoracionSocioeconomicaTemporal.AcceptChanges();
            }
            dtGVRespuestasSeleccionadas.AutoGenerateColumns = false;
            dtGVRespuestasSeleccionadas.DataSource = DTValoracionSocioeconomicaTemporal;

            DTCategorias = TACategorias.GetData();

            DTPreguntasValoracion = TAPreguntasValoracion.GetData();
            
            DTRespuestasValoracion = TARespuestasValoracion.GetData();
            
            DataColumn DCSeleccionar = new DataColumn("Seleccionar", Type.GetType("System.Boolean"));
            DCSeleccionar.DefaultValue = false;
            DTRespuestasValoracion.Columns.Add(DCSeleccionar);

            DTRespuestasValoracion.RowChanged += new DataRowChangeEventHandler(DTRespuestasValoracion_RowChanged);

            int CodigoResidenciaUrbana = 1, CodigoResidenciaRural = 2;
            bool esRedisenciaUrbana = true;

            if (TAFuncionesSistema.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPaciente, true) == null)
            {   
                if (MessageBox.Show(this, "¿El Tipo de Residencia del Paciente es URBANA?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    esRedisenciaUrbana = false;
               
            }

            else
            {
                DTValoracionSocioeconomica = TAValoracionSocioeconomica.GetDataByNombreRespuesta(NumeroPaciente, null);
                DTValoracionSocioeconomica.Rows.RemoveAt(0);
                DTValoracionSocioeconomica.AcceptChanges();


                foreach (DSTrabajo_Social.ValoracionSocioeconomicaRow DRValoracionSocioEconomica
                    in DTValoracionSocioeconomica.Rows)
                {
                    DTRespuestasValoracion.FindByCodigoRespuestaValoracionCodigoPreguntaValoracion(DRValoracionSocioEconomica.CodigoRespuestaValoracion, DRValoracionSocioEconomica.CodigoPreguntaValoracion)["Seleccionar"] = true;
                }

                esRedisenciaUrbana = DTValoracionSocioeconomica.Select("CodigoPreguntaValoracion = " + CodigoResidenciaUrbana).Length > 0;
            }


            if (esRedisenciaUrbana)
            {
                DTPreguntasValoracion.RemovePreguntasValoracionRow(DTPreguntasValoracion.FindByCodigoPreguntaValoracion(CodigoResidenciaRural));
                foreach (DataRow DRRespuesta in DTRespuestasValoracion.Select(String.Format("CodigoPreguntaValoracion = {0}", CodigoResidenciaRural)))
                {
                    DTRespuestasValoracion.Rows.Remove(DRRespuesta);
                }

            }
            else
            {
                DTPreguntasValoracion.RemovePreguntasValoracionRow(DTPreguntasValoracion.FindByCodigoPreguntaValoracion(CodigoResidenciaUrbana));
                foreach (DataRow DRRespuesta in DTRespuestasValoracion.Select(String.Format("CodigoPreguntaValoracion = {0}", CodigoResidenciaUrbana)))
                {
                    DTRespuestasValoracion.Rows.Remove(DRRespuesta);
                }
            }

            DSValoracionSocioEconomica.Tables.AddRange (new DataTable[]{ DTPreguntasValoracion, DTRespuestasValoracion});
            DataRelation DRConstraintFK_Respuestas_Preguntas = new DataRelation("DRConstraintFK_Respuestas_Preguntas", DTPreguntasValoracion.CodigoPreguntaValoracionColumn, DTRespuestasValoracion.CodigoPreguntaValoracionColumn);

            //DataColumn[] DRConstraintFK_Respuestas_Preguntas = new DataColumn[] { DTPreguntasValoracion.CodigoPreguntaValoracionColumn, DTRespuestasValoracion.CodigoRespuestaValoracionColumn };
            DSValoracionSocioEconomica.Relations.Add(DRConstraintFK_Respuestas_Preguntas);

            bdSourcePreguntas.DataSource = DSValoracionSocioEconomica;
            bdSourcePreguntas.DataMember = DTPreguntasValoracion.TableName;

            bdSourceRespuestas.DataSource = bdSourcePreguntas;
            bdSourceRespuestas.DataMember = "DRConstraintFK_Respuestas_Preguntas";

            bdSourcePreguntas.MoveFirst();
            dtGVRespuestas.CurrentCellDirtyStateChanged += new EventHandler(dtGVRespuestas_CurrentCellDirtyStateChanged);
            dtGVRespuestas.CellValueChanged += new DataGridViewCellEventHandler(dtGVRespuestas_CellValueChanged);

            //DTPreguntasValoracion.DefaultView.Sort = "CodigoPreguntaValoracion ASC";
            dtGVPreguntas.Columns["DGCCodigoPreguntaValoracion"].SortMode = DataGridViewColumnSortMode.Programmatic;
            //bdSourcePreguntas.Sort = "CodigoPreguntaValoracion ASC";
            
            //DTRespuestasValoracion.DefaultView.Sort = "Puntaje ASC";
            dtGVRespuestas.Columns["DGCPuntaje"].SortMode = DataGridViewColumnSortMode.Programmatic;
            //bdSourceRespuestas.Sort = "Puntaje DESC";

            FechaHoraValoracionSocioEconomica = TAFuncionesSistema.ObtenerFechaHoraServidor().Value;
            //this.dtGVPreguntas.DataSource = bdSourcePreguntas;
            //this.dtGVPreguntas.Sort(this.dtGVPreguntas.Columns["DGCCodigoPreguntaValoracion"], ListSortDirection.Ascending);
            //this.dtGVPreguntas.
            //this.dtGVRespuestas.DataSource = bdSourceRespuestas;
            //this.dtGVRespuestas.Sort(this.dtGVRespuestas.Columns["DGCPuntaje"], ListSortDirection.Descending);
            
        }

        void dtGVRespuestas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVRespuestas.RowCount > 0
                && dtGVRespuestas.CurrentRow != null && e.RowIndex >= 0 && dtGVRespuestas.Columns[dtGVRespuestas.CurrentCell.ColumnIndex].Name == DGCSeleccionar.Name)
            {
                if (dtGVRespuestas.CurrentCell.Value.Equals(true))
                {
                    int CodigoRespuesta = int.Parse(dtGVRespuestas.Rows[dtGVRespuestas.CurrentCell.RowIndex].Cells["DGCCodigoRespuestaValoracion"].Value.ToString());
                    int CodigoPregunta = DTPreguntasValoracion[bdSourcePreguntas.Position].CodigoPreguntaValoracion;
                    foreach (DSTrabajo_Social.RespuestasValoracionRow DRRespuesta in DTRespuestasValoracion.Select("CodigoPreguntaValoracion = " + CodigoPregunta))
                    {
                        DRRespuesta["Seleccionar"] = false;

                        foreach (DataRow DRRespuestaTemp in DTValoracionSocioeconomicaTemporal.Select("CodigoPreguntaValoracion = " + CodigoPregunta))
                        {
                            DTValoracionSocioeconomicaTemporal.Rows.Remove(DRRespuestaTemp);
                        }

                    }
                    if (DTRespuestasValoracion.FindByCodigoRespuestaValoracionCodigoPreguntaValoracion(CodigoRespuesta, CodigoPregunta) != null)
                    {
                        DTRespuestasValoracion.FindByCodigoRespuestaValoracionCodigoPreguntaValoracion(CodigoRespuesta, CodigoPregunta)["Seleccionar"] = true;

                        DataRow FilaNueva = DTValoracionSocioeconomicaTemporal.NewRow();
                        FilaNueva["CodigoRespuestaValoracion"] = CodigoRespuesta;
                        FilaNueva["CodigoPreguntaValoracion"] = CodigoPregunta;
                        FilaNueva["PuntajeActual"] = int.Parse(dtGVRespuestas.Rows[dtGVRespuestas.CurrentCell.RowIndex].Cells["DGCPuntaje"].Value.ToString()); ;
                        FilaNueva["NombreRespuestaValoracion"] = dtGVRespuestas.Rows[dtGVRespuestas.CurrentCell.RowIndex].Cells["DGCNombreRespuestaValoracion"].Value.ToString();
                        FilaNueva["NombrePreguntaValoracion"] = dtGVPreguntas.Rows[dtGVPreguntas.CurrentCell.RowIndex].Cells["DGCNombrePreguntaValoracion"].Value.ToString();
                        FilaNueva["NumeroPaciente"] = NumeroPaciente;
                        FilaNueva["FechaHoraValoracionSocioEcon"] = FechaHoraValoracionSocioEconomica;

                        DTValoracionSocioeconomicaTemporal.Rows.Add(FilaNueva);
                    }
                    

                    DTValoracionSocioeconomicaTemporal.AcceptChanges();
                }
                else
                {
                }
                DTRespuestasValoracion.AcceptChanges();
            }
        }

        void dtGVRespuestas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if(dtGVRespuestas.IsCurrentCellDirty && dtGVRespuestas.Columns[dtGVRespuestas.CurrentCell.ColumnIndex].Name == DGCSeleccionar.Name)
                dtGVRespuestas.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        void DTRespuestasValoracion_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            object suma = DTRespuestasValoracion.Compute("Sum(Puntaje)", "Seleccionar = True");
            decimal montoAcumulado = -1;
            if (suma != null && Decimal.TryParse(suma.ToString(), out montoAcumulado))
            {
                TxtPuntajeTotal.Text = montoAcumulado.ToString();
                DataRow[] DRCategorias = DTCategorias.Select(String.Format("PuntajeMinimo >= {0}  OR PuntajeMaximo >= {1}", montoAcumulado, montoAcumulado), "PuntajeMinimo ASC");

                if (DRCategorias.Length > 0)
                {
                    CodigoCategoria = int.Parse(DRCategorias[0]["CodigoCategoria"].ToString());
                    NombreCategoria = DRCategorias[0]["NombreCategoria"].ToString();

                    TxtRangoPuntaje.Text = String.Format("Entre {0} y {1}", DRCategorias[0]["PuntajeMinimo"], DRCategorias[0]["PuntajeMaximo"]);
                    TxtCategoria.Text = NombreCategoria;
                }
            }
            else
            {
                TxtPuntajeTotal.Text = "0";
                TxtRangoPuntaje.Text = TxtCategoria.Text = "";
                CodigoCategoria = -1;
                NombreCategoria = String.Empty;
            }
        }

        private void btnGuardarNivelSocioeconomico_Click(object sender, EventArgs e)
        {
            int cantidadSeleccionados = DTRespuestasValoracion.Select("Seleccionar = True").Length;
            if(cantidadSeleccionados <= 0)
            {
                MessageBox.Show(this,"Aún no ha seleccionado Ninguna Respuesta para las Preguntas");
                return;
            }
            if (DTPreguntasValoracion.Count != cantidadSeleccionados)
            {
                MessageBox.Show(this,"Existen Respuestas que no han sido seleccionadas para cada una de las Preguntas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //GuardarDatos();
            this.Close();
        }


        public void GuardarDatos()
        {
            if (DTRespuestasValoracion.Count > 0)
            {
                DataSet DSValoracionSocioEconomica = new DataSet("ValoracionSocioEconomica");
                DataTable DTAux = DTRespuestasValoracion.Clone();                
                foreach (DSTrabajo_Social.RespuestasValoracionRow DRRespuestas in DTRespuestasValoracion.Select("Seleccionar = True"))
                {
                    DTAux.ImportRow(DRRespuestas);
                }


                DTAux.Columns.Remove(DTAux.Columns["NombreRespuestaValoracion"]);
                DTAux.Columns.Remove(DTAux.Columns["Descripcion"]);
                DTAux.TableName = "RespuestasValoracion";
                DSValoracionSocioEconomica.Tables.Add(DTAux);


                TAValoracionSocioeconomica.InsertarActualizarValoracionSocioEconomicaXML(NumeroPaciente, FechaHoraValoracionSocioEconomica, DTAux.DataSet.GetXml());
            }
        }

    }
}
