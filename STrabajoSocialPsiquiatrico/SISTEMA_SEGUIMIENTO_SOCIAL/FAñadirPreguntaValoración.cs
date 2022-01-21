using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_SocialTableAdapters;
using System.Text.RegularExpressions;
namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    public partial class FAñadirPreguntaValoración : Form
    {

        PreguntasValoracionTableAdapter TAPreguntasValoracion;
        RespuestasValoracionTableAdapter TARespuestasValoracion;

        DSTrabajo_Social.PreguntasValoracionDataTable DTPreguntasValoracion;
        DSTrabajo_Social.RespuestasValoracionDataTable DTRespuestasValoracion;
        DSTrabajo_Social.RespuestasValoracionDataTable DTRespuestasValoracionTemporal;
        QTAFuncionesSistema TAFuncionesSistema;

        ErrorProvider eProviderPreguntasValoracion;
        DataSet DSPreguntasRespuestasValoracion;
        DataSet DSPreguntasRespuestasXML;
        string TipoOperacion = "";
        private bool soloInsertarEditar = false;
        public int CodigoPreguntaValoracion { get; set; }
        public FAñadirPreguntaValoración()
        {
            InitializeComponent();

            try
            {
                DTPreguntasValoracion = new DSTrabajo_Social.PreguntasValoracionDataTable();
                TAPreguntasValoracion = new PreguntasValoracionTableAdapter();
                TAFuncionesSistema = new QTAFuncionesSistema();
                TARespuestasValoracion = new RespuestasValoracionTableAdapter();
                DTPreguntasValoracion = TAPreguntasValoracion.GetData();
                DTRespuestasValoracion = TARespuestasValoracion.GetData();
                DTRespuestasValoracionTemporal = new DSTrabajo_Social.RespuestasValoracionDataTable();
                DTRespuestasValoracionTemporal.CodigoRespuestaValoracionColumn.AutoIncrement = true;
                DTRespuestasValoracionTemporal.CodigoRespuestaValoracionColumn.AutoIncrementSeed = 1;
                DTRespuestasValoracionTemporal.CodigoRespuestaValoracionColumn.AutoIncrementStep = +1;
                DTRespuestasValoracionTemporal.CodigoPreguntaValoracionColumn.DefaultValue = 1;

                crearMaestroDetalle();

                eProviderPreguntasValoracion = new ErrorProvider();

                //dtGVPreguntas.Columns["DGCCodigoPreguntaValoracion"].SortMode = DataGridViewColumnSortMode.Programmatic;
                //bdSourcePreguntasValoracion.Sort = "CodigoPreguntaValoracion ASC";
                                
                //dtGVRespuestas.Columns["DGCPuntaje"].SortMode = DataGridViewColumnSortMode.Programmatic;
                //bdSourceRespuestas.Sort = "Puntaje DESC";

                dtGVRespuestas.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridView1_CellValidating);
                dtGVRespuestas.RowValidating += new DataGridViewCellCancelEventHandler(dataGridView1_RowValidating);
                dtGVRespuestas.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dtGVRespuestas_EditingControlShowing);
                dtGVRespuestas.CellEndEdit += new DataGridViewCellEventHandler(dtGVRespuestas_CellEndEdit);

                //DTRespuestasValoracionTemporal.RowChanging += new DataRowChangeEventHandler(DTRespuestasValoracionTemporal_RowChanged);
                DSPreguntasRespuestasXML = new DataSet("PreguntasValoracion");
                DSPreguntasRespuestasXML.Tables.Add(DTRespuestasValoracionTemporal);

                CargarDatosConcepto(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió la siguiente excepción al momento de cargar el Formulario " + ex.Message);
                throw;
            }
            Visible = true;
        }

        void dtGVRespuestas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!String.IsNullOrEmpty(TipoOperacion))
            {
                dtGVRespuestas.Rows[e.RowIndex].ErrorText = String.Empty;
            }
        }

        void dtGVRespuestas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!String.IsNullOrEmpty(TipoOperacion))
            {
                TextBox textBoxCell = e.Control as TextBox;
                //if (textBoxCell != null)
                //{
                //    textBoxCell.KeyPress += new KeyPressEventHandler(textBoxCell_KeyPress);
                //}

                if (this.dtGVRespuestas.CurrentCell.ColumnIndex == DGCNombreRespuestaValoracion.Index)
                {
                    TextBox tx = e.Control as TextBox;
                    //if (this.dtGVRespuestas.CurrentCell.RowIndex == 1)
                    //{
                    tx.KeyPress += new KeyPressEventHandler(textBoxCell_KeyPress);
                    //tx.KeyPress += Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress;
                    //}
                    //else
                    //{
                    //    tx.KeyPress -= Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress;
                    //    //We do not restrict the input in other cells in this column
                    //    //tx.KeyPress -= new KeyPressEventHandler(textBoxCell_KeyPress);
                    //}
                }
            }
        }
        void textBoxCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string expresion = "[a-z]?[ñáéíóú]?[\\s]?";
            string TextoValidar =(sender as TextBox).Text;
            //if (Regex.IsMatch(TextoValidar, expresion))
            //{
            //    if (Regex.Replace(TextoValidar, expresion, String.Empty).Length == 0)
            //    {
            //        dtGVRespuestas.CurrentRow.ErrorText = "No puede ingresar ese caracter";
            //    }
            //    //else
            //    //{
            //    //    dtGVRespuestas.CurrentRow.ErrorText = "No puede ingresar ese caracter";                    
            //    //}
            //}
            //else
            //{
            //    dtGVRespuestas.CurrentRow.ErrorText = "No puede ingresar ese caracter";                    
            //}

            Regex reg = new Regex("[^a-zA-Z0-9 ]");
            string TextoValidado = reg.Replace(TextoValidar.Normalize(NormalizationForm.FormD), "");
            if (TextoValidar.CompareTo(TextoValidado) != 0 || e.KeyChar == '\b')
            {
                System.Media.SystemSounds.Beep.Play();
                dtGVRespuestas.CurrentRow.ErrorText = "No puede ingresar acentos ni la letra 'ñ'";                    
                e.Handled = true;
            }
            //string CodigoProductoAux = Productos.GenerarCodigoProducto(int.Parse(cBTipoProducto.SelectedValue.ToString()), reg.Replace(tBNombreProducto.Text.Normalize(NormalizationForm.FormD), ""));
            //tBCodigoProducto.Text = CodigoProductoAux;

        } 

        public void crearMaestroDetalle()
        {

            if (DSPreguntasRespuestasValoracion != null)
            {
                DSPreguntasRespuestasValoracion.Relations.Clear();
                DSPreguntasRespuestasValoracion.AcceptChanges();
                DTRespuestasValoracion.Constraints.Remove("FK_Preguntas_Respuestas");
                DSPreguntasRespuestasValoracion.Tables.Clear();                
                DSPreguntasRespuestasValoracion.Dispose();
                
            }
            DSPreguntasRespuestasValoracion = new DataSet("PreguntasRepuestasValoracion");
            
            DSPreguntasRespuestasValoracion.Tables.AddRange(new DataTable[] { DTPreguntasValoracion, DTRespuestasValoracion });

            DataRelation DRFK_Preguntas_Respuestas = new DataRelation("FK_Preguntas_Respuestas", DTPreguntasValoracion.CodigoPreguntaValoracionColumn, DTRespuestasValoracion.CodigoPreguntaValoracionColumn);
            DSPreguntasRespuestasValoracion.Relations.Add(DRFK_Preguntas_Respuestas);

            bdSourcePreguntasValoracion.DataSource = DSPreguntasRespuestasValoracion;
            bdSourcePreguntasValoracion.DataMember = DTPreguntasValoracion.TableName;

            bdSourceRespuestas.DataSource = bdSourcePreguntasValoracion;
            bdSourceRespuestas.DataMember = "FK_Preguntas_Respuestas";
        }

        void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(TipoOperacion))
            {
                int PuntajeNuevo = -1;
                
                if (dtGVRespuestas.Rows[e.RowIndex].Cells["DGCPuntaje"].ToString().Trim().Length < 1)
                {
                    this.dtGVRespuestas.Rows[e.RowIndex].ErrorText = "El Puntaje de la respuesta es necesario y no puede estar vacio.";
                    e.Cancel = true;
                }
                else if (dtGVRespuestas.Rows[e.RowIndex].Cells["DGCPuntaje"].Value != null &&
                    !int.TryParse(dtGVRespuestas.Rows[e.RowIndex].Cells["DGCPuntaje"].Value.ToString(), out PuntajeNuevo) || PuntajeNuevo <= 0)
                {
                    this.dtGVRespuestas.Rows[e.RowIndex].ErrorText = "El Puntaje de la respuesta debe ser un entero positivo.";
                    e.Cancel = true;
                }
                
                if (dtGVRespuestas.Rows[e.RowIndex].Cells["DGCNombreRespuestaValoracion"].Value != null &&
                    dtGVRespuestas.Rows[e.RowIndex].Cells["DGCNombreRespuestaValoracion"].Value.ToString().Trim().Length < 1)
                {
                    this.dtGVRespuestas.Rows[e.RowIndex].ErrorText = "El Nombre de la respuesta es necesario y no puede estar vacio.";
                    e.Cancel = true;
                }
                else if (dtGVRespuestas.Rows[e.RowIndex].Cells["DGCPuntaje"].Value != null
                    && DTRespuestasValoracionTemporal.Select(string.Format("NombreRespuestaValoracion = '{0}'", dtGVRespuestas.Rows[e.RowIndex].Cells["DGCPuntaje"].Value.ToString())).Length > 0)
                {
                    this.dtGVRespuestas.Rows[e.RowIndex].ErrorText = "El Nombre de la respuesta no puede ser repetido, ya se encuentra dentro de la lista";
                    e.Cancel = true;
                }
                
            }
        }

        void DTRespuestasValoracionTemporal_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            //e.Action == DataRowAction.Add && 
            if (String.IsNullOrEmpty(e.Row["NombreRespuestaValoracion"].ToString()))
            {
                MessageBox.Show(this, "Aún no ha Ingresado el Nombre de la Respuesta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }
        }

        void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int PuntajeNuevo;

            this.dtGVRespuestas.Rows[e.RowIndex].ErrorText = "";

            // No cell validation for new rows. New rows are validated on Row Validation.
            if (this.dtGVRespuestas.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dtGVRespuestas.IsCurrentCellDirty)
            {
                switch (this.dtGVRespuestas.Columns[e.ColumnIndex].Name)
                {

                    case "DGCPuntaje":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVRespuestas.Rows[e.RowIndex].ErrorText = "El Puntaje de la Respuesta es necesario y no puede estar vacía.";
                            e.Cancel = true;
                        }
                        else if (!int.TryParse(e.FormattedValue.ToString(), out PuntajeNuevo) || PuntajeNuevo <= 0)
                        {
                            this.dtGVRespuestas.Rows[e.RowIndex].ErrorText = "El Puntaje de la Respuesta debe ser un entero positivo.";
                            e.Cancel = true;
                        }
                        break;
                    case "DGCNombreRespuestaValoracion":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVRespuestas.Rows[e.RowIndex].ErrorText = "El Nombre de la Respuesta es necesario y no puede estar vacío.";
                            e.Cancel = true;
                        }
                        else if (DTRespuestasValoracionTemporal.Select(string.Format("NombreRespuestaValoracion = '{0}'", e.FormattedValue)).Length > 0)
                        {
                            this.dtGVRespuestas.Rows[e.RowIndex].ErrorText = "El Nombre de la Respuesta no puede ser repetido, ya se encuentra dentro de la lista";
                            e.Cancel = true;
                        }
                        break;

                }

            }
        }

        public void CargarDatosConcepto(int CodigoPreguntaValoracion)
        {

            DSTrabajo_Social.PreguntasValoracionRow DRConcepto = DTPreguntasValoracion.FindByCodigoPreguntaValoracion(CodigoPreguntaValoracion);
            if (DRConcepto == null)
            {
                DSTrabajo_Social.PreguntasValoracionDataTable DTPreguntasValoracionAux = TAPreguntasValoracion.GetDataBy11(CodigoPreguntaValoracion);
                if (DTPreguntasValoracionAux.Count > 0)
                    DRConcepto = DTPreguntasValoracionAux[0];
                else
                {
                    limpiarControles();
                    habilitarControles(false);
                    habilitarBotones(true, false, false, false, false);
                    return;
                }
            }
            else
            {
                TxtCodigoPregunta.Text = DRConcepto.CodigoPreguntaValoracion.ToString();
                TxtNombrePregunta.Text = DRConcepto.NombrePreguntaValoracion;
                rTextBoxDescripcionPregunta.Text = DRConcepto.IsDescripcionNull() ? String.Empty : DRConcepto.Descripcion;


                habilitarBotones(true, false, false, true, true);
                habilitarControles(false);
            }
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            TxtNombrePregunta.ReadOnly = !estadoHabilitacion;
            rTextBoxDescripcionPregunta.Enabled = estadoHabilitacion;
            dtGVRespuestas.ReadOnly = !estadoHabilitacion;
            bindingNavigatorAddNewItem.Visible = bindingNavigatorDeleteItem.Visible = estadoHabilitacion;
            dtGVRespuestas.RowHeadersVisible = estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool editar, bool eliminar)
        {
            this.btnAñadirPregunta.Enabled = nuevo;
            this.btnGuardarPregunta.Enabled = aceptar;
            this.btnCancelar.Enabled = cancelar;
            this.btnEditarPregunta.Enabled = editar;
            this.btnEliminarPregunta.Enabled = eliminar;
        }

        public void limpiarControles()
        {
            TxtNombrePregunta.Text = string.Empty;
            rTextBoxDescripcionPregunta.Text = string.Empty;
        }

        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(TxtNombrePregunta.Text.Trim()))
            {
                eProviderPreguntasValoracion.SetError(TxtNombrePregunta, "Aún no ha Ingresado el Nombre de Tipo de Pregunta");
                TxtNombrePregunta.Focus();
                TxtNombrePregunta.SelectAll();
                return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int? NumeroPreguntasValoracioniguiente = 0;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("PreguntasValoracion", ref NumeroPreguntasValoracioniguiente);
            NumeroPreguntasValoracioniguiente = NumeroPreguntasValoracioniguiente == -1
                 ? 1 : NumeroPreguntasValoracioniguiente.Value + 1;
            TxtCodigoPregunta.Text = NumeroPreguntasValoracioniguiente.ToString();

            TipoOperacion = "I";
            habilitarControles(true);
            limpiarControles();
            habilitarBotones(false, true, true, false, false);
            dtGVPreguntas.Enabled = false;
            DTRespuestasValoracionTemporal.CodigoRespuestaValoracionColumn.AutoIncrement = true;
            DTRespuestasValoracionTemporal.CodigoRespuestaValoracionColumn.AutoIncrementSeed = 1;
            DTRespuestasValoracionTemporal.CodigoRespuestaValoracionColumn.AutoIncrementStep = +1;
            
            DTRespuestasValoracionTemporal.Clear();
            bdSourceRespuestas.DataSource = DTRespuestasValoracionTemporal;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            dtGVPreguntas.Enabled = false;
            TipoOperacion = "E";
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false);

            int? NumeroRespuestaValoracioniguiente = 0;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("RespuestasValoracion", ref NumeroRespuestaValoracioniguiente);
            NumeroRespuestaValoracioniguiente = NumeroRespuestaValoracioniguiente == -1
                 ? 1 : NumeroRespuestaValoracioniguiente.Value + 1;

            CodigoPreguntaValoracion = int.Parse(TxtCodigoPregunta.Text);
            DTRespuestasValoracionTemporal.Clear();
            foreach (DSTrabajo_Social.RespuestasValoracionRow DRRespuesta in DTRespuestasValoracion.Select(" CodigoPreguntaValoracion = " + CodigoPreguntaValoracion.ToString()))
            {
                DTRespuestasValoracionTemporal.Rows.Add(DRRespuesta.ItemArray);
            }

            DTRespuestasValoracionTemporal.CodigoRespuestaValoracionColumn.AutoIncrementSeed = NumeroRespuestaValoracioniguiente.Value;
            DTRespuestasValoracionTemporal.CodigoRespuestaValoracionColumn.AutoIncrementStep = +1;
            dtGVPreguntas.Enabled = false;
            bdSourceRespuestas.DataSource = DTRespuestasValoracionTemporal;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                eProviderPreguntasValoracion.Clear();
                if (validarDatos())
                {
                    int CodigoNumeroAuxiliar = int.Parse(TxtCodigoPregunta.Text);

                    if (DTRespuestasValoracionTemporal.Count == 0)
                    {
                        MessageBox.Show(this, "Aun no ha Ingresado ninguna respuesta para la pregunta que desea formular", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //DTRespuestasValoracionTemporal.GroupBy(DSTrabajo_Social.RespuestasValoracionRow fila);
                    //DataSetHelper dsh = new DataSetHelper(ref dts);
                    //DataTable t = //
                    
                    //var groups = DTRespuestasValoracionTemporal.AsEnumerable().GroupBy(r => r.Field<int>("Puntaje"));

                    var RespuestasAgrupadas = DTRespuestasValoracionTemporal.AsEnumerable().GroupBy(r => r.Field<int>("Puntaje"))
                          .Select(g => new { Puntaje = g.Key, Cantidad = g.Count() }).Where(tupla => tupla.Cantidad > 1 );

                    if (RespuestasAgrupadas.Count() > 0)
                    {
                        MessageBox.Show(this,"Existen Puntajes repetidos dentro de las respuestas ingresadas" , this.Text,
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }


                    if (TipoOperacion == "I")
                    {
                        
                        TAPreguntasValoracion.Insert(TxtNombrePregunta.Text.Trim(), rTextBoxDescripcionPregunta.Text);
                        DSTrabajo_Social.PreguntasValoracionRow DRPreguntaNuevo = DTPreguntasValoracion.AddPreguntasValoracionRow(TxtNombrePregunta.Text.Trim(), rTextBoxDescripcionPregunta.Text);
                        DRPreguntaNuevo.CodigoPreguntaValoracion = CodigoNumeroAuxiliar;
                        DRPreguntaNuevo.AcceptChanges();
                        DTPreguntasValoracion.AcceptChanges();

                        int? CodigoRespuestaAux = -1;
                        TAFuncionesSistema.ObtenerUltimoIndiceTabla("RespuestasValoracion", ref CodigoRespuestaAux);
                        DTRespuestasValoracionTemporal.CodigoRespuestaValoracionColumn.AutoIncrement = false;
                        foreach( DSTrabajo_Social.RespuestasValoracionRow DRRespuesta in DTRespuestasValoracionTemporal.Rows )
                        {
                            TARespuestasValoracion.Insert(CodigoNumeroAuxiliar, DRRespuesta.NombreRespuestaValoracion, DRRespuesta.Puntaje, DRRespuesta.IsDescripcionNull() ? null : DRRespuesta.Descripcion);
                            DTRespuestasValoracion.AddRespuestasValoracionRow(CodigoNumeroAuxiliar, DRRespuesta.NombreRespuestaValoracion, DRRespuesta.Puntaje, 
                                DRRespuesta.IsDescripcionNull() ? string.Empty : DRRespuesta.Descripcion);
                            CodigoRespuestaAux = ++CodigoRespuestaAux;
                            DTRespuestasValoracion[DTRespuestasValoracion.Count - 1].CodigoRespuestaValoracion = CodigoRespuestaAux.Value;
                        }
                        DTRespuestasValoracion.AcceptChanges();
                        //bdSourceRespuestas.ResetBindings(false);
                        //bdSourceRespuestas.DataSource = null;
                        //crearMaestroDetalle();
                        TipoOperacion = String.Empty;
                        dtGVPreguntas.Enabled = true;
                        DTRespuestasValoracionTemporal.CodigoRespuestaValoracionColumn.AutoIncrement = false;

                        //bdSourcePreguntasValoracion.ResetBindings(false);
                        bdSourceRespuestas.DataSource = bdSourcePreguntasValoracion;
                        bdSourceRespuestas.DataMember = "FK_Preguntas_Respuestas";
                    }

                    else
                    {                        
                        DataTable DTEdicionPreguntas = DTRespuestasValoracionTemporal.Copy();
                        Regex reg = new Regex("[^a-zA-Z0-9 ]");                        
                        foreach (DataRow DRPregunta in DTEdicionPreguntas.Rows)
                        {
                            DRPregunta["NombreRespuestaValoracion"] = reg.Replace(DRPregunta["NombreRespuestaValoracion"].ToString().Normalize(NormalizationForm.FormD), "");
                        }                        
                        DTEdicionPreguntas.TableName = "RespuestasValoracion";
                        //DTEdicionPreguntas.Columns[""];
                        DataSet DSEdicionPreguntas = new DataSet("PreguntasValoracion");
                        DSEdicionPreguntas.Tables.Add(DTEdicionPreguntas);
                        DTEdicionPreguntas.AcceptChanges();
                        string RespuestasXMl = DSEdicionPreguntas.GetXml();
                        



                        //TAPreguntasValoracion.ActualizarPreguntaValoracion(int.Parse(TxtCodigoPregunta.Text), TxtNombrePregunta.Text, rTextBoxDescripcionPregunta.Text);
                        TAPreguntasValoracion.ActualizarPreguntaRespuestaValoracionXML(CodigoPreguntaValoracion, TxtNombrePregunta.Text, rTextBoxDescripcionPregunta.Text, RespuestasXMl);
                        int indiceEdicion = DTPreguntasValoracion.Rows.IndexOf(DTPreguntasValoracion.FindByCodigoPreguntaValoracion(int.Parse(TxtCodigoPregunta.Text)));
                        DTPreguntasValoracion[indiceEdicion].NombrePreguntaValoracion = TxtNombrePregunta.Text;
                        DTPreguntasValoracion[indiceEdicion].Descripcion = rTextBoxDescripcionPregunta.Text;
                        DTPreguntasValoracion.AcceptChanges();



                    }
                    habilitarBotones(true, false, false, true, true);
                    habilitarControles(false);
                    TipoOperacion = "";
                    MessageBox.Show(this, "Operación realizada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CodigoPreguntaValoracion = CodigoNumeroAuxiliar;
                    dtGVPreguntas.Enabled = true;
                    if (soloInsertarEditar)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        bdSourcePreguntasValoracion.MoveLast();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Falta completar el llenado de algunos campos que son necesarios, revise su datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudo culminar satisfactoriamente la operación actual, debido a que ocurrió la siguiente excepción" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtGVPreguntas.Enabled = true;
            eProviderPreguntasValoracion.Clear();
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false);
            bdSourcePreguntasValoracion_CurrentChanged(bdSourcePreguntasValoracion, e);
            if (soloInsertarEditar)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            bdSourceRespuestas.DataSource = bdSourcePreguntasValoracion;
            bdSourceRespuestas.DataMember = "FK_Preguntas_Respuestas";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de Eliminar el Registro Actual??", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {                    
                    habilitarBotones(true, false, false, false, false);
                    TAPreguntasValoracion.Delete(int.Parse(TxtCodigoPregunta.Text));
                    DTPreguntasValoracion.Rows.Remove(DTPreguntasValoracion.FindByCodigoPreguntaValoracion(int.Parse(TxtCodigoPregunta.Text)));
                    DTPreguntasValoracion.AcceptChanges();
                    limpiarControles();
                }
                catch (Exception )
                {
                    MessageBox.Show(this, "No se pudo culminar la operación actual, seguramente el registro se encuentra en uso en otras operaciones del sistema", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }



        private void bdSourcePreguntasValoracion_CurrentChanged(object sender, EventArgs e)
        {

            if (dtGVPreguntas.CurrentRow != null && bdSourcePreguntasValoracion.Position >= 0)
            {
                //CargarDatosConcepto(DTPreguntasValoracion[bdSourcePreguntasValoracion.Position].CodigoPreguntaValoracion);
                //CargarDatosConcepto(int.Parse(dtGVPreguntas.CurrentRow.Cells["DGCCodigoPreguntaValoracion"].Value.ToString()));

                if (soloInsertarEditar && (DialogResult == System.Windows.Forms.DialogResult.OK || DialogResult == System.Windows.Forms.DialogResult.Cancel))
                {
                    CodigoPreguntaValoracion = DTPreguntasValoracion[bdSourcePreguntasValoracion.Position].CodigoPreguntaValoracion;
                    this.Close();
                }
            }

        }

        public void configurarFormularioIA(int? CodigoPreguntaValoracion)
        {
            CargarDatosConcepto(CodigoPreguntaValoracion != null ? CodigoPreguntaValoracion.Value : -1);
            if (CodigoPreguntaValoracion == null)
            {
                int? NumeroPreguntasValoracioniguiente = 0;
                TAFuncionesSistema.ObtenerUltimoIndiceTabla("PreguntasValoracion", ref NumeroPreguntasValoracioniguiente);
                NumeroPreguntasValoracioniguiente = NumeroPreguntasValoracioniguiente == -1
                     ? 1 : NumeroPreguntasValoracioniguiente.Value + 1;
                TxtCodigoPregunta.Text = NumeroPreguntasValoracioniguiente.ToString();
            }
            TipoOperacion = CodigoPreguntaValoracion == null ? "I" : "E";
            soloInsertarEditar = true;
            dtGVPreguntas.Visible = false;
            //290
            btnEditarPregunta.Visible = btnAñadirPregunta.Visible = btnEliminarPregunta.Visible = false;
            this.Size = new Size(290, this.Size.Height);
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false);
        }

        private void btnCerrarAñadirPregunta_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
            if (e.ColumnIndex == DGCNombreRespuestaValoracion.Index)
            {
                dtGVRespuestas.CurrentCell = dtGVRespuestas[DGCNombreRespuestaValoracion.Index, e.RowIndex];
                dtGVRespuestas.CurrentCell.ErrorText = "Aún no ha Ingresado el Nombre de la Pregunta";
                e.Cancel = false;
            }
            if (e.ColumnIndex == DGCPuntaje.Index)
            {
                dtGVRespuestas.CurrentCell = dtGVRespuestas[DGCPuntaje.Index, e.RowIndex];
                dtGVRespuestas.CurrentCell.ErrorText = "Aún no ha Ingresado el puntaje de la Pregunta";
                e.Cancel = false;
            }
        }

        private void btnCerrarPregunta_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtGVPreguntas_SelectionChanged(object sender, EventArgs e)
        {
            if (dtGVPreguntas.CurrentRow != null)
            {
                int CodigoPregunta = int.Parse(dtGVPreguntas.CurrentRow.Cells["DGCCodigoPreguntaValoracion"].Value.ToString());
                CargarDatosConcepto(CodigoPregunta);
                CodigoPreguntaValoracion = CodigoPregunta;
            }
        }
    }
}
