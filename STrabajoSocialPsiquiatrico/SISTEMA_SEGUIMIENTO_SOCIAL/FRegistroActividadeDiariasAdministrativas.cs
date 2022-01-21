using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_SocialTableAdapters;
using SISTEMA_SEGUIMIENTO_SOCIAL.Reportes;

namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    public partial class FRegistroActividadeDiariasAdministrativas : Form
    {
        ActividadesTableAdapter TAActividadesPacientes;
        ActividadesTipoTableAdapter TAActividaddesTipo;
        UsuariosTableAdapter TAUsuarios;
        PacientesTableAdapter TAPacientes;
        QTAFuncionesSistema TAFuncionesSistema;

        DSTrabajo_Social.ActividadesDataTable DTActividadesPacientes;
        DSTrabajo_Social.ActividadesTipoDataTable DTActividadesTipos;
        DSTrabajo_Social.UsuariosDataTable DTUsuarios;
        DSTrabajo_Social.PacientesDataTable DTPacientes;

        private string TipoOperacion = "";
        public int NumeroPacientes { get; set; }
        public int CodigoActividad { get; set; }
        private ErrorProvider eProviderActividades;

        public FRegistroActividadeDiariasAdministrativas()
        {
            InitializeComponent();

            TAActividaddesTipo = new ActividadesTipoTableAdapter();
            TAActividadesPacientes = new ActividadesTableAdapter();
            TAUsuarios = new UsuariosTableAdapter();
            TAPacientes = new PacientesTableAdapter();
            eProviderActividades = new ErrorProvider();
            TAFuncionesSistema = new QTAFuncionesSistema();

            DTActividadesTipos = TAActividaddesTipo.GetDataByClase("G");
            cBoxActividadRealizada.DataSource = DTActividadesTipos;
            cBoxActividadRealizada.ValueMember = "CodigoActividadTipo";
            cBoxActividadRealizada.DisplayMember = "NombreActividad";

           

            DTUsuarios = TAUsuarios.GetDataByTrabajadorSocial();
            //foreach (DataRow DRUsuarios in DTUsuarios.Select("TipoUsuario = 'A'"))
            //{
            //    DTUsuarios.Rows.Remove(DRUsuarios);
            //}
            //DTUsuarios.Columns.Add("NombreCompleto");
            //DTUsuarios.Columns["NombreCompleto"].Expression = String.Format("{0} +' ' + {1} + ' ' + {2}", DTUsuarios.NombreColumn.ColumnName, DTUsuarios.ApellidoPaternoColumn.ColumnName, DTUsuarios.ApellidoPaternoColumn.ColumnName);
            cBoxTrabajadorSocial.DataSource = DTUsuarios;
            cBoxTrabajadorSocial.DisplayMember = "NombreCompleto";
            cBoxTrabajadorSocial.ValueMember = "CodigoUsuario";
            cBoxTrabajadorSocial.SelectedIndex = -1;

            cBoxTrabajadoraSocialFiltro.DataSource = DTUsuarios.Copy();
            cBoxTrabajadoraSocialFiltro.DisplayMember = "NombreCompleto";
            cBoxTrabajadoraSocialFiltro.ValueMember = "CodigoUsuario";
            cBoxTrabajadoraSocialFiltro.SelectedIndex = -1;

            DGCNombreActividad.DataSource = DTActividadesTipos;
            DGCNombreActividad.DisplayMember = "NombreActividad";
            DGCNombreActividad.ValueMember = "CodigoActividadTipo";
            DGCNombreActividad.DataPropertyName = "CodigoActividadTipo";

            DGCTrabajadorSocial.DataSource = DTUsuarios;
            DGCTrabajadorSocial.DisplayMember = "NombreCompleto";
            DGCTrabajadorSocial.ValueMember = "CodigoUsuario";
            DGCTrabajadorSocial.DataPropertyName = "CodigoUsuario";

            DTActividadesPacientes = TAActividadesPacientes.GetData("G");            
            bdSourceActividadesDiarias.DataSource = DTActividadesPacientes;
            DGCNumeroPaciente.Visible = false;
            DGCHClinico.Visible = false;
            cargarDatosActividadDiaria( -1, DateTime.Now);
            btnLimpiar.Click += new EventHandler(btnLimpiar_Click);
            cBoxTrabajadoraSocialFiltro.KeyDown += new KeyEventHandler(cBoxTrabajadoraSocialFiltro_KeyDown);
            cBoxTrabajadoraSocialFiltro.SelectedIndexChanged += new EventHandler(this.dateFechaDesde_ValueChanged);
            
            dateFechaDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime fechaFin = DateTime.Now.AddDays(1);
            dateFechaHasta.Value = new DateTime(fechaFin.Year, fechaFin.Month, fechaFin.Day).AddMilliseconds(-1);
            dtGVListadoActividades.AutoGenerateColumns = false;
        }

        void cBoxTrabajadoraSocialFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                cBoxTrabajadoraSocialFiltro.SelectedIndex = -1;
            }
        }


        void btnLimpiar_Click(object sender, EventArgs e)
        {
            DTActividadesPacientes.Clear();
            limpiarControles();
        }

        public void limpiarControles()
        {
            TxtNombreApellidosPaciente.Text = String.Empty;
            TxtNumeroActividad.Text = String.Empty;
            txtSeccion.Text = String.Empty;
            TxtUnidad.Text = String.Empty;
            txtDenominacion.Text = String.Empty;
            txtObservaciones.Clear();
            cBoxActividadRealizada.SelectedIndex = -1;
            cBoxTrabajadorSocial.SelectedIndex = -1;
            dateFechaRegistroDiarioActividades.Value = DateTime.Now;

        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            cBoxActividadRealizada.Enabled = estadoHabilitacion;
            cBoxTrabajadorSocial.Enabled = estadoHabilitacion;
            //dateFechaRegistroDiarioActividades.Enabled = estadoHabilitacion;
            btnAnadirActividadTipo.Enabled = estadoHabilitacion;
            txtObservaciones.Enabled = estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool eliminar, bool modificar)
        {
            this.btnAnadirActividad.Enabled = nuevo;
            this.btnGuardarActividad.Enabled = aceptar;
            this.btnCancelar.Enabled = cancelar;
            this.btnEliminarActividad.Enabled = eliminar;
            this.btnEditarActividad.Enabled = modificar;
        }

        public void cargarDatosActividadDiaria(int CodigoActividadAux, DateTime FechaActividad)
        {
            limpiarControles();
            habilitarControles(false);
            DSTrabajo_Social.ActividadesRow DRActividadesPaciente = DTActividadesPacientes.FindByCodigoActividadFechaActividad(CodigoActividadAux, FechaActividad);
            if (DRActividadesPaciente == null)
            {
                DSTrabajo_Social.ActividadesDataTable DTActividadesPacienteAux = TAActividadesPacientes.GetDataBy1(CodigoActividadAux, FechaActividad);
                if (DTActividadesPacienteAux.Count > 0)
                    DRActividadesPaciente = DTActividadesPacienteAux[0];
                else
                {
                    habilitarBotones(true, false, false, false, false);
                    return;
                }
            }

            this.NumeroPacientes = DRActividadesPaciente.IsNumeroPacienteNull() ? -1 : DRActividadesPaciente.NumeroPaciente;
            this.CodigoActividad = CodigoActividadAux;
            DTPacientes = TAPacientes.GetDataBy11(NumeroPacientes);
            if (DTPacientes.Count > 0)
            {
                TxtNombreApellidosPaciente.Text = String.Format("{0} {1} {2}", DTPacientes[0].Nombre, DTPacientes[0].ApellidoPaterno, DTPacientes[0].ApellidoMaterno);
                txtSeccion.Text = DTPacientes[0].IsSeccionNull() ? String.Empty : DTPacientes[0].Seccion;
                TxtUnidad.Text = DTPacientes[0].IsUnidadNull() ? String.Empty : DTPacientes[0].Unidad.ToString();
                txtDenominacion.Text = DTPacientes[0].IsDenominacionNull() ? String.Empty : DTPacientes[0].Denominacion;
            }
            else
            {
                TxtNombreApellidosPaciente.Text = String.Empty;
                txtSeccion.Text =String.Empty;
                TxtUnidad.Text = String.Empty;
                txtDenominacion.Text = String.Empty;
            }

            dateFechaRegistroDiarioActividades.Value = DRActividadesPaciente.FechaActividad;
            TxtNumeroActividad.Text = DRActividadesPaciente.CodigoActividad.ToString();
            txtObservaciones.Text = DRActividadesPaciente.IsObservacionesNull() ? String.Empty : DRActividadesPaciente.Observaciones;

            if (DRActividadesPaciente.IsCodigoActividadTipoNull())
                cBoxActividadRealizada.SelectedIndex = -1;
            else
                cBoxActividadRealizada.SelectedValue = DRActividadesPaciente.CodigoActividadTipo;
            cBoxTrabajadorSocial.SelectedValue = DRActividadesPaciente.CodigoUsuario;

            habilitarBotones(true, false, false, true, true);
        }

        public bool validarControleS()
        {
            //if (string.IsNullOrEmpty(TxtNombreApellidosPaciente.Text))
            //{
            //    eProviderActividades.SetError(TxtNombreApellidosPaciente, "Aún no ha seleccionado ningun paciente");
            //    return false;
            //}
            if (cBoxActividadRealizada.SelectedIndex < 0)
            {
                eProviderActividades.SetError(cBoxActividadRealizada, "Aún no ha Seleccionado ninguna Actividad");
                cBoxActividadRealizada.Focus();
                return false;
            }
            if (cBoxTrabajadorSocial.SelectedIndex < 0)
            {
                eProviderActividades.SetError(cBoxTrabajadorSocial, "Aún no ha Seleccionado el Responsable del Registro");
                cBoxTrabajadorSocial.Focus();
                return false;
            }
            return true;

            

        }

        private void btnAnadirActividad_Click(object sender, EventArgs e)
        {
            //FBusquedaPacientes formBuscarPacientes = new FBusquedaPacientes();
            //if (MessageBox.Show(this, "¿Desea Registrar una Actividad para un Paciente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    formBuscarPacientes.ShowDialog();
            //    if (formBuscarPacientes.NumeroPaciente > 0)
            //    {
            //        limpiarControles();

            //        TxtNombreApellidosPaciente.Text = String.Format("{0} {1} {2}", formBuscarPacientes.DRPacienteSeleccionado.Nombre, formBuscarPacientes.DRPacienteSeleccionado.ApellidoPaterno, formBuscarPacientes.DRPacienteSeleccionado.ApellidoMaterno);
            //        TxtUnidad.Text = formBuscarPacientes.DRPacienteSeleccionado.IsUnidadNull() ? String.Empty : formBuscarPacientes.DRPacienteSeleccionado.Unidad.ToString();
            //        txtSeccion.Text = formBuscarPacientes.DRPacienteSeleccionado.IsSeccionNull() ? String.Empty : formBuscarPacientes.DRPacienteSeleccionado.Seccion;
            //        txtDenominacion.Text = formBuscarPacientes.DRPacienteSeleccionado.IsDenominacionNull() ? string.Empty : formBuscarPacientes.DRPacienteSeleccionado.Denominacion;

            //        int? CodigoAux = -1;
            //        CodigoAux = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(formBuscarPacientes.NumeroPaciente, "A").Value;
            //        TxtNumeroActividad.Text = CodigoAux == null ? String.Empty : (CodigoAux).ToString();

            //        this.NumeroPacientes = formBuscarPacientes.NumeroPaciente;

            //        habilitarControles(true);
            //        habilitarBotones(false, true, true, false, false);
            //        TipoOperacion = "I";
            //    }
            //    else
            //    {
            //        MessageBox.Show(this, "Aún no ha Seleccionado ningún Paciente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    }
            //}
            //else
            //{
                limpiarControles();
                TxtNombreApellidosPaciente.Text = "";
                TxtUnidad.Text = "";
                txtSeccion.Text = "";
                txtDenominacion.Text = String.Empty;

                int? CodigoAux = -1;
                CodigoAux = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(-1, "A").Value;
                TxtNumeroActividad.Text = CodigoAux == null ? String.Empty : (CodigoAux).ToString();

                this.NumeroPacientes = -1;

                habilitarControles(true);
                habilitarBotones(false, true, true, false, false);
                TipoOperacion = "I";
                
            //}
            
        }

        private void btnGuardarActividad_Click(object sender, EventArgs e)
        {
            if (validarControleS())
            {
                try
                {
                    int CodigoAux = int.Parse(TxtNumeroActividad.Text);
                    if (TipoOperacion == "I")
                    {
                        TAActividadesPacientes.Insert(NumeroPacientes > 0 ? NumeroPacientes : (int?) null, dateFechaRegistroDiarioActividades.Value, int.Parse(cBoxActividadRealizada.SelectedValue.ToString()),
                            int.Parse(cBoxTrabajadorSocial.SelectedValue.ToString()), "G", txtObservaciones.Text);
                        
                        //DTActividadesPacientes.AddActividadesRow(NumeroPacientes, dateFechaRegistroDiarioActividades.Value, int.Parse(cBoxActividadRealizada.SelectedValue.ToString()),
                            //int.Parse(cBoxTrabajadorSocial.SelectedValue.ToString()));
                        DTActividadesPacientes.AddActividadesRow(int.Parse(cBoxActividadRealizada.SelectedValue.ToString()), int.Parse(cBoxTrabajadorSocial.SelectedValue.ToString()),
                            NumeroPacientes, -1, DateTime.Now, "G", txtObservaciones.Text, -1);
                        DTActividadesPacientes[DTActividadesPacientes.Count - 1].CodigoActividad = CodigoAux;
                        if (NumeroPacientes > 0)
                        {
                            int? numero = TAFuncionesSistema.ObtenerNumeroHistorialClinicoPaciente(NumeroPacientes);
                            if(numero != null) 
                                DTActividadesPacientes[DTActividadesPacientes.Count - 1]["HClinico"] = numero;
                        }
                        DTActividadesPacientes.AcceptChanges();

                        CodigoActividad = CodigoAux;
                    }
                    else
                    {
                        TAActividadesPacientes.ActualizarActividad(NumeroPacientes > 0 ? NumeroPacientes : (int?)null, CodigoAux, dateFechaRegistroDiarioActividades.Value, int.Parse(cBoxActividadRealizada.SelectedValue.ToString()),
                            int.Parse(cBoxTrabajadorSocial.SelectedValue.ToString()), "G", txtObservaciones.Text);
                        DSTrabajo_Social.ActividadesRow DRActvidadesEdicion = DTActividadesPacientes.FindByCodigoActividadFechaActividad(CodigoAux, dateFechaRegistroDiarioActividades.Value);
                        DRActvidadesEdicion.CodigoActividadTipo =  int.Parse(cBoxActividadRealizada.SelectedValue.ToString());
                        DRActvidadesEdicion.CodigoUsuario = int.Parse(cBoxTrabajadorSocial.SelectedValue.ToString());
                        DRActvidadesEdicion.FechaActividad = dateFechaRegistroDiarioActividades.Value;
                        DRActvidadesEdicion.Observaciones = txtObservaciones.Text;
                        DRActvidadesEdicion.AcceptChanges();
                    }

                    MessageBox.Show(this, "Operación realizada Correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitarBotones(true, false, false, true, true);
                    habilitarControles(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se pudo Registrar el registro, debido a las siguientes dificultades " + ex.Message,
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this,"Existen algunos campos que son considerados obligatorios, por favor proceda a corregirlos", 
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditarActividad_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false);
        }

        private void btnEliminarActividad_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se Encuentra seguro de Eliminar el Registro Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                TAActividadesPacientes.Delete(int.Parse(TxtNumeroActividad.Text), dateFechaRegistroDiarioActividades.Value);
                DTActividadesPacientes.Rows.Remove(DTActividadesPacientes.FindByCodigoActividadFechaActividad(int.Parse(TxtNumeroActividad.Text), dateFechaRegistroDiarioActividades.Value));
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false);
        }

        private void btnCerrarActividad_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bdSourceActividadesDiarias_CurrentChanged(object sender, EventArgs e)
        {
            //if (bdSourceActividadesDiarias.Position >= 0)
            //{
            //    cargarDatosActividadDiaria(
            //        DTActividadesPacientes[bdSourceActividadesDiarias.Position].CodigoActividad, DTActividadesPacientes[bdSourceActividadesDiarias.Position].FechaActividad);
            //}
        }

        private void btnAñadirActividad_Click(object sender, EventArgs e)
        {
            //FAñadirActividadesTipo formActividades = new FAñadirActividadesTipo();
            FAñadirActividadesTipo formActividades = new FAñadirActividadesTipo();

            formActividades.configurarFormularioIA(null);
            formActividades.Visible = false;
            if (formActividades.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                DTActividadesTipos.FindByCodigoActividadTipo(formActividades.CodigoActividadTipo) == null)
            {
                DTActividadesTipos.Rows.Add(TAActividaddesTipo.GetDataBy1(formActividades.CodigoActividadTipo)[0].ItemArray);
                DTActividadesTipos.DefaultView.Sort = "NombreActividad ASC";
                //cBoxActividadRealizada.DataSource = DTParentescoFamiliar;
                cBoxActividadRealizada.SelectedValue = formActividades.CodigoActividadTipo;

            }
            formActividades.Dispose();
        }

        private void dateFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            DTActividadesPacientes = TAActividadesPacientes.GetDataByPaciente("G", null, dateFechaDesde.Value, dateFechaHasta.Value);
            if (cBoxTrabajadoraSocialFiltro.SelectedIndex >= 0)
            {
                DTActividadesPacientes.DefaultView.RowFilter = "CodigoUsuario = " + int.Parse(cBoxTrabajadoraSocialFiltro.SelectedValue.ToString());
            }
            bdSourceActividadesDiarias.DataSource = DTActividadesPacientes;
            dtGVListadoActividades.DataSource = bdSourceActividadesDiarias;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ListarActividadesReporteTableAdapter TAListarActividadesReporte = new ListarActividadesReporteTableAdapter();
            int? CodigoUsuario = cBoxTrabajadoraSocialFiltro.SelectedIndex >= 0 ? int.Parse(cBoxTrabajadoraSocialFiltro.SelectedValue.ToString()) : (int?)null;
            DataTable DTActividades = TAListarActividadesReporte.GetData(CodigoUsuario, "A", dateFechaDesde.Value, dateFechaHasta.Value);            


            FReporteFormulariosIndividuales formReporte = new FReporteFormulariosIndividuales();
            formReporte.ListarActividadesReporte(DTActividades, null, null, "A", string.Empty,
                dateFechaDesde.Value, dateFechaHasta.Value);
            formReporte.ShowDialog();
            formReporte.Dispose();
        }

        private void dtGVListadoActividades_SelectionChanged(object sender, EventArgs e)
        {
            if (dtGVListadoActividades.CurrentRow != null && dtGVListadoActividades.Rows.Count > 0)
            {
                cargarDatosActividadDiaria(int.Parse(dtGVListadoActividades.CurrentRow.Cells["DGCCodigoActividad"].Value.ToString()),
                    DateTime.Parse(dtGVListadoActividades.CurrentRow.Cells["DGCFechaActividad"].Value.ToString()));

                if (String.IsNullOrEmpty(DTActividadesPacientes.DefaultView.RowFilter))
                {
                    cargarDatosActividadDiaria(
                    DTActividadesPacientes[bdSourceActividadesDiarias.Position].CodigoActividad, DTActividadesPacientes[bdSourceActividadesDiarias.Position].FechaActividad);
                }
                else
                {
                    int indice = dtGVListadoActividades.CurrentRow.Index;
                    DataTable DTActividades = (dtGVListadoActividades.DataSource as BindingSource).DataSource as DataTable;
                    DSTrabajo_Social.ActividadesRow DRActividadesAux = DTActividadesPacientes.NewActividadesRow();
                    DataTable DTDefaultViewAux = DTActividades.DefaultView.ToTable();

                    DRActividadesAux["CodigoActividad"] = DTDefaultViewAux.Rows[indice]["CodigoActividad"];
                    DRActividadesAux["FechaActividad"] = DTDefaultViewAux.Rows[indice]["FechaActividad"];
 
                    //(DSTrabajo_Social.ActividadesRow)DTActividades.DefaultView.ToTable().Rows[indice];
                    cargarDatosActividadDiaria(DRActividadesAux.CodigoActividad, DRActividadesAux.FechaActividad);
                    DTActividades.RejectChanges();
                }

                //cargarDatosActividadDiaria(
                //    DTActividadesPacientes[bdSourceActividadesDiarias.Position].CodigoActividad, DTActividadesPacientes[bdSourceActividadesDiarias.Position].FechaActividad);
            }
        }


    }
}
