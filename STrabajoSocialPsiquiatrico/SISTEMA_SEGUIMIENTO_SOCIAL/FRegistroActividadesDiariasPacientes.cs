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
    public partial class FRegistroActividadesDiariasPacientes : Form
    {

        ActividadesTableAdapter TAActividadesPacientes;
        ActividadesTipoTableAdapter TAActividaddesTipo;
        UsuariosTableAdapter TAUsuarios;
        PacientesTableAdapter TAPacientes;
        QTAFuncionesSistema TAFuncionesSistema;
        ResponsablesTableAdapter TAResponsablesPaciente;
        DocumentosTableAdapter TAPacientesDocumentos;
        

        DSTrabajo_Social.ActividadesDataTable DTActividadesPacientes;        
        DSTrabajo_Social.ActividadesTipoDataTable DTActividadesTipos;
        DSTrabajo_Social.UsuariosDataTable DTUsuarios;
        DSTrabajo_Social.PacientesDataTable DTPacientes;
        DSTrabajo_Social.ResponsablesDataTable DTResponsablesPaciente;
        DSTrabajo_Social.DocumentosDataTable DTPacientesDocumentos;
        DateTime FechaHoraServidor;

        private string TipoOperacion = "";
        public int? NumeroPacienteActual { get; set; }
        public int CodigoActividad { get; set; }
        private ErrorProvider eProviderActividades;

        

        public FRegistroActividadesDiariasPacientes()
        {
            InitializeComponent();

            TAActividaddesTipo = new ActividadesTipoTableAdapter();
            TAActividadesPacientes = new ActividadesTableAdapter();
            TAUsuarios = new UsuariosTableAdapter();
            TAPacientes = new PacientesTableAdapter();
            eProviderActividades = new ErrorProvider();
            TAFuncionesSistema = new QTAFuncionesSistema();
            TAPacientesDocumentos = new DocumentosTableAdapter();
            TAResponsablesPaciente = new ResponsablesTableAdapter();

            DTResponsablesPaciente = new DSTrabajo_Social.ResponsablesDataTable();            
            DTPacientesDocumentos = new DSTrabajo_Social.DocumentosDataTable();            
            //DTActividadesPacientesTemp.Columns.Add("Observaciones");

            DTActividadesTipos = TAActividaddesTipo.GetDataByClase("P");
            cBoxActividadRealizada.DataSource = DTActividadesTipos;
            cBoxActividadRealizada.ValueMember = "CodigoActividadTipo";
            cBoxActividadRealizada.DisplayMember = "NombreActividad";

            //DTActividadesPacientes = TAActividadesPacientes.GetData("P");                        
            DTActividadesPacientes = new DSTrabajo_Social.ActividadesDataTable();

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

            //DGCNombreActividad.DataSource = DTActividadesTipos;
            //DGCNombreActividad.DisplayMember = "NombreActividad";
            //DGCNombreActividad.ValueMember = "CodigoActividadTipo";
            //DGCNombreActividad.DataPropertyName = "CodigoActividadTipo";
            dtGVResponsables.ReadOnly = true;
            dtGVResponsables.AutoGenerateColumns = false;
            dtGVActividades.AutoGenerateColumns = false;
            //dtGVActividades.ReadOnly = true;
            dateFechaDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime fechaFin = DateTime.Now.AddDays(1);
            dateFechaHasta.Value = new DateTime(fechaFin.Year, fechaFin.Month, fechaFin.Day).AddMilliseconds(-1);

            cargarDatosActividadDiaria(-1, DateTime.Now);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.cBoxTrabajadoraSocialFiltro.SelectedIndexChanged += new System.EventHandler(this.cBoxTrabajadoraSocialFiltro_SelectedIndexChanged);
            this.cBoxTrabajadoraSocialFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cBoxTrabajadoraSocialFiltro_KeyDown);            
            DTActividadesPacientes.Clear();
        }


        public void limpiarControles()
        {
            
            TxtNumeroActividad.Text = String.Empty;            
            cBoxActividadRealizada.SelectedIndex = -1;
            cBoxTrabajadorSocial.SelectedIndex = -1;
            dateFechaRegistroDiarioActividades.Value = DateTime.Now;
            txtObservaciones.Text = string.Empty;

            if (NumeroPacienteActual == null)
            {
                txtSeccion.Text = String.Empty;
                TxtUnidad.Text = String.Empty;
                txtDenominacion.Text = String.Empty;
                TxtNombreApellidosPaciente.Text = String.Empty;
                txtHClinico.Text = string.Empty;
                DTResponsablesPaciente.Clear();
            }

        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            cBoxActividadRealizada.Enabled = estadoHabilitacion;
            cBoxTrabajadorSocial.Enabled = estadoHabilitacion;
            //dateFechaRegistroDiarioActividades.Enabled = estadoHabilitacion;
            btnAnadirActividadTipo.Enabled = estadoHabilitacion;
            txtObservaciones.Enabled = estadoHabilitacion;
            btnModificarResponsable.Enabled = estadoHabilitacion;
            DGCObservaciones.ReadOnly = !estadoHabilitacion;
            bindingNavigatorDeleteItem.Visible = estadoHabilitacion && TipoOperacion == "I";            
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool eliminar, bool modificar, bool buscar, bool verReportes)
        {
            this.btnNuevo.Enabled = nuevo;
            this.btnGuardarActividad.Enabled = aceptar;
            this.btnCancelar.Enabled = cancelar;
            this.btnEliminarActividad.Enabled = eliminar;
            this.btnEditarActividad.Enabled = modificar;
            this.btnBuscar.Enabled = buscar;
            this.btnImprimir.Enabled = verReportes;
            
        }

        public void cargarDatosPaciente(int NuemroPaciente)
        {
            this.NumeroPacienteActual = NuemroPaciente;            
            DTPacientes = TAPacientes.GetDataBy11(NumeroPacienteActual);
            if (DTPacientes.Count > 0)
            {
                TxtNombreApellidosPaciente.Text = String.Format("{0} {1} {2}", DTPacientes[0].Nombre, DTPacientes[0].ApellidoPaterno, DTPacientes[0].ApellidoMaterno);
                txtSeccion.Text = DTPacientes[0].IsSeccionNull() ? String.Empty : DTPacientes[0].Seccion;
                TxtUnidad.Text = DTPacientes[0].IsUnidadNull() ? String.Empty : DTPacientes[0].Unidad.ToString();
                txtDenominacion.Text = DTPacientes[0].IsDenominacionNull() ? String.Empty : DTPacientes[0].Denominacion;
                txtHClinico.Text = DTPacientes[0].IsHClinicoNull() ? string.Empty : DTPacientes[0].HClinico.ToString();
                DTResponsablesPaciente = TAResponsablesPaciente.GetDataByPaciente(NumeroPacienteActual, "V");
                dtGVResponsables.DataSource = DTResponsablesPaciente;

                DTPacientesDocumentos = TAPacientesDocumentos.GetDataByPaciente(NumeroPacienteActual);
            }
            else
            {
                TxtNombreApellidosPaciente.Text = String.Empty;
                txtSeccion.Text = String.Empty;
                TxtUnidad.Text = String.Empty;
                txtDenominacion.Text = String.Empty;
            }
        }

        public void cargarDatosActividadDiaria(int CodigoActividadAux, DateTime FechaActividad)
        {
            limpiarControles();
            habilitarControles(false);
            DSTrabajo_Social.ActividadesRow DRActividadesPaciente = DTActividadesPacientes.FindByCodigoActividadFechaActividad(CodigoActividadAux, FechaActividad);
            if (DRActividadesPaciente == null)
            {
                //DSTrabajo_Social.ActividadesDataTable DTActividadesPacienteAux = TAActividadesPacientes.GetDataBy1(CodigoActividadAux, FechaActividad);
                //DRActividadesPaciente = DTActividadesPacientes.Select(String.Format("NumeroPaciente = {0} and CodigoActividad ={1}", NumeroPacienteActual.Value, CodigoActividadAux), "")[0] as DSTrabajo_Social.ActividadesRow;
                DSTrabajo_Social.ActividadesDataTable DTActividadesPacienteAux = new DSTrabajo_Social.ActividadesDataTable();
                if (DTActividadesPacientes.Select(String.Format("NumeroPaciente = {0} and CodigoActividad ={1}", NumeroPacienteActual ?? -1, CodigoActividadAux), "").Length > 0)
                {
                    DataTable DTAux = DTActividadesPacientes.Copy();
                    if (DTAux.Columns.Contains("NombreActividad"))
                        DTAux.Columns.Remove(DTAux.Columns["NombreActividad"]);
                    DTActividadesPacienteAux.Rows.Add(DTAux.Select(String.Format("NumeroPaciente = {0} and CodigoActividad ={1}", NumeroPacienteActual.Value, CodigoActividadAux), "")[0].ItemArray);
                }
                if (DTActividadesPacienteAux.Count > 0)
                    DRActividadesPaciente = DTActividadesPacienteAux[0];
                else
                {
                    habilitarBotones(false, false, false, false, false, true, false);
                    return;
                }
            }
            dateFechaRegistroDiarioActividades.Value = DRActividadesPaciente.FechaActividad;
            FechaHoraServidor = DRActividadesPaciente.FechaActividad;
            TxtNumeroActividad.Text = DRActividadesPaciente.CodigoActividad.ToString();
            txtObservaciones.Text = DRActividadesPaciente.IsObservacionesNull() ? String.Empty : DRActividadesPaciente.Observaciones;
            if (DRActividadesPaciente.IsCodigoActividadTipoNull())
                cBoxActividadRealizada.SelectedIndex = -1;
            else
                cBoxActividadRealizada.SelectedValue = DRActividadesPaciente.CodigoActividadTipo;
            if (DRActividadesPaciente.IsCodigoUsuarioNull())
                cBoxTrabajadorSocial.SelectedIndex = -1;
            else
                cBoxTrabajadorSocial.SelectedValue = DRActividadesPaciente.CodigoUsuario;

            habilitarBotones(true, false, false, true, true, true, true);
        }

        public bool validarControleS()
        {
            if (string.IsNullOrEmpty(TxtNombreApellidosPaciente.Text))
            {
                eProviderActividades.SetError(TxtNombreApellidosPaciente, "Aún no ha seleccionado ningun paciente");
                return false;
            }
            eProviderActividades.Clear();
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //FBusquedaPacientes formBuscarPacientes = new FBusquedaPacientes();            
            //formBuscarPacientes.ShowDialog(); 
            //if (formBuscarPacientes.NumeroPaciente > 0)
            //{
            //    limpiarControles();
            //    FechaHoraServidor = TAFuncionesSistema.ObtenerFechaHoraServidor().Value;
            //    dateFechaRegistroDiarioActividades.Value = FechaHoraServidor;
            //    TxtNombreApellidosPaciente.Text = String.Format("{0} {1} {2}", formBuscarPacientes.DRPacienteSeleccionado.Nombre, formBuscarPacientes.DRPacienteSeleccionado.ApellidoPaterno, formBuscarPacientes.DRPacienteSeleccionado.ApellidoMaterno);
            //    TxtUnidad.Text = formBuscarPacientes.DRPacienteSeleccionado.IsUnidadNull() ? String.Empty : formBuscarPacientes.DRPacienteSeleccionado.Unidad.ToString();
            //    txtSeccion.Text = formBuscarPacientes.DRPacienteSeleccionado.IsSeccionNull() ? String.Empty : formBuscarPacientes.DRPacienteSeleccionado.Seccion;
            //    txtDenominacion.Text = formBuscarPacientes.DRPacienteSeleccionado.IsDenominacionNull() ? string.Empty : formBuscarPacientes.DRPacienteSeleccionado.Denominacion;
            //    txtHClinico.Text = formBuscarPacientes.DRPacienteSeleccionado.IsHClinicoNull() ? string.Empty : formBuscarPacientes.DRPacienteSeleccionado.HClinico.ToString();

            //    int? CodigoAux = -1;
            //    CodigoAux = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(formBuscarPacientes.NumeroPaciente, "A").Value;
            //    TxtNumeroActividad.Text = CodigoAux == null ? String.Empty : (CodigoAux).ToString();
            //    CodigoActividad = CodigoAux.Value;

            //    this.NumeroPacienteActual = formBuscarPacientes.NumeroPaciente;

            //    DTResponsablesPaciente = TAResponsablesPaciente.GetDataByPaciente(NumeroPacienteActual, "V");
            //    dtGVResponsables.DataSource = DTResponsablesPaciente;

            //    TipoOperacion = "I";
            //    habilitarControles(true);
            //    habilitarBotones(false, true, true, false, false, false, false);                
            //    bdSourceActividades.DataSource = DTActividadesPacientesTemp;
            //    dtGVActividades.DataSource = bdSourceActividades;
            //}
            //else
            //{
            //    MessageBox.Show(this, "Aún no ha Seleccionado ningún Paciente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}

            if (!String.IsNullOrEmpty(TxtNombreApellidosPaciente.Text))
            {
                TipoOperacion = "I";
                limpiarControles();
                habilitarControles(true);
                habilitarBotones(false, true, true, false, false, false, false);
                int? CodigoAux = -1;
                CodigoAux = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(NumeroPacienteActual, "A").Value;
                TxtNumeroActividad.Text = CodigoAux == null ? String.Empty : (CodigoAux).ToString();
                CodigoActividad = CodigoAux.Value;
                FechaHoraServidor = TAFuncionesSistema.ObtenerFechaHoraServidor().Value;
                dateFechaRegistroDiarioActividades.Value = FechaHoraServidor;

            }
            else
            {
                MessageBox.Show(this, "Aún no ha seleccionado ningún Paciente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnGuardarActividad_Click(object sender, EventArgs e)
        {
            if (validarControleS())
            {
                try
                {
                    int CodigoAux = int.Parse(TxtNumeroActividad.Text);
                    string ActividadRealizada = (cBoxActividadRealizada.SelectedItem as DataRowView)["NombreActividad"].ToString();
                    if (TipoOperacion == "I")
                    {
                        TAActividadesPacientes.Insert(NumeroPacienteActual > 0 ? NumeroPacienteActual : (int?)null, FechaHoraServidor, int.Parse(cBoxActividadRealizada.SelectedValue.ToString()),
                            int.Parse(cBoxTrabajadorSocial.SelectedValue.ToString()), "P", txtObservaciones.Text);

                        DataRow DRActividad = DTActividadesPacientes.AddActividadesRow(int.Parse(cBoxActividadRealizada.SelectedValue.ToString()), int.Parse(cBoxTrabajadorSocial.SelectedValue.ToString()),
                            NumeroPacienteActual.Value, CodigoAux, FechaHoraServidor, "P", txtObservaciones.Text, 1);
                        DRActividad["NombreActividad"] = ActividadRealizada;
                        DTActividadesPacientes.AcceptChanges();

                        CodigoActividad = CodigoAux;
                    }
                    else
                    {
                        TAActividadesPacientes.ActualizarActividad(NumeroPacienteActual > 0 ? NumeroPacienteActual : (int?)null, CodigoAux, FechaHoraServidor, int.Parse(cBoxActividadRealizada.SelectedValue.ToString()),
                            int.Parse(cBoxTrabajadorSocial.SelectedValue.ToString()), "P", txtObservaciones.Text);
                        DSTrabajo_Social.ActividadesRow DRActvidadesEdicion = DTActividadesPacientes.FindByCodigoActividadFechaActividad(CodigoAux, dateFechaRegistroDiarioActividades.Value);
                        DRActvidadesEdicion.CodigoActividadTipo = int.Parse(cBoxActividadRealizada.SelectedValue.ToString());
                        DRActvidadesEdicion.CodigoUsuario = int.Parse(cBoxTrabajadorSocial.SelectedValue.ToString());
                        DRActvidadesEdicion.Observaciones = txtObservaciones.Text;
                        //DRActvidadesEdicion.FechaActividad = dateFechaRegistroDiarioActividades.Value;
                        DRActvidadesEdicion.AcceptChanges();
                    }

                    if (ActividadRealizada.CompareTo("TRÁMITE DE DOCUMENTOS PERSONALES DEL PACIENTE") == 0)
                    {
                        registrarDocumentos();
                    }

                    MessageBox.Show(this, "Operación realizada Correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitarBotones(true, false, false, true, true, true, true);
                    habilitarControles(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se pudo Registrar el registro, debido a las siguientes dificultades " + ex.Message,
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            
        }

        public void registrarDocumentos()
        {
            
            FDocumentos formDocumentos = new FDocumentos(NumeroPacienteActual.Value, TipoOperacion == "I", TAFuncionesSistema.ObtenerNumeroHistorialClinicoPaciente(NumeroPacienteActual));
            formDocumentos.cargarDocumentosPacienteTable(NumeroPacienteActual.Value, DTPacientesDocumentos);
            formDocumentos.ShowDialog();
            if (formDocumentos.DTDocumentosPaciente.Count > 0)
            {
                DTPacientesDocumentos.Clear();
                foreach (DSTrabajo_Social.DocumentosRow DRDocumento in formDocumentos.DTDocumentosPaciente.Rows)
                {
                    DTPacientesDocumentos.Rows.Add(DRDocumento.ItemArray);
                }
                DTPacientesDocumentos.AcceptChanges();

                foreach (DSTrabajo_Social.DocumentosRow DRDocumento in DTPacientesDocumentos.Rows)
                {
                    TAPacientesDocumentos.Insert(NumeroPacienteActual, DRDocumento.FechaRegistro, DRDocumento.TramitoTrabSocial, DRDocumento.CodigoDocumentoTipo);
                }
            }

            formDocumentos.Dispose();
            
        }

        private void btnEditarActividad_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false, false, false);
        }

        private void btnEliminarActividad_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se Encuentra seguro de Eliminar el Registro Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                TAActividadesPacientes.Delete(int.Parse(TxtNumeroActividad.Text), FechaHoraServidor);
                //DTActividadesPacientes.Rows.Remove(DTActividadesPacientes.FindByCodigoActividadFechaActividad(int.Parse(TxtNumeroActividad.Text), dateFechaRegistroDiarioActividades.Value));
                limpiarControles();
                habilitarBotones(true, false, false, false, false, true, false);
                DTActividadesPacientes.Rows.RemoveAt(dtGVActividades.CurrentRow.Index );
                DTActividadesPacientes.AcceptChanges();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            eProviderActividades.Clear();
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false, true, false);
            DTPacientesDocumentos.RejectChanges();
        }

        private void btnCerrarActividad_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnModificarResponsable_Click(object sender, EventArgs e)
        {
            if (NumeroPacienteActual != null)
            {
                FFichaSocial f4 = new FFichaSocial(-1);
                f4.cargarDatosPaciente(NumeroPacienteActual.Value);
                f4.HabilitarPestaniaSoloResponsable();
                if (dtGVResponsables.CurrentRow != null)
                    f4.cargarDatosResponsables(NumeroPacienteActual.Value, int.Parse(dtGVResponsables.CurrentRow.Cells["DGCCodigoResponsable"].Value.ToString()));
                f4.ShowDialog();
                f4.Dispose();
                DTResponsablesPaciente = TAResponsablesPaciente.GetDataByPaciente(NumeroPacienteActual, "V");
                dtGVResponsables.DataSource = DTResponsablesPaciente;
                FechaHoraServidor = TAFuncionesSistema.ObtenerFechaHoraServidor().Value;
            }
        }

        private void btnCerrarActividad_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void btnAgregarActividad_Click(object sender, EventArgs e)
        //{
        //    if (!validarControleS()) return;
        //    if(DTActividadesPacientesTemp.Select(String.Format( "CodigoActividadTipo = {0}",cBoxActividadRealizada.SelectedValue.ToString()  )).Length > 0)
        //    {
        //        MessageBox.Show("Ya se encuentra registrado en la lista actual la actividad seleccionada");
        //        return;
        //    }

        //    DataRow DRActividadNueva = DTActividadesPacientesTemp.AddActividadesRow(int.Parse(cBoxActividadRealizada.SelectedValue.ToString()), int.Parse(cBoxTrabajadorSocial.SelectedValue.ToString()),
        //        NumeroPacienteActual, CodigoActividad, FechaHoraServidor, "P", txtObservaciones.Text, int.Parse(txtHClinico.Text));
        //    DRActividadNueva["NombreActividad"] = (cBoxActividadRealizada.SelectedItem as DataRowView)["NombreActividad"].ToString();
        //    //DRActividadNueva["Observaciones"] = txtObservaciones.Text;
        //    DRActividadNueva.AcceptChanges();
        //    CodigoActividad++;
        //    TxtNumeroActividad.Text = CodigoActividad.ToString();
        //    txtObservaciones.Clear();

        //    if ((cBoxActividadRealizada.SelectedItem as DataRowView)["NombreActividad"].ToString().CompareTo("TRAMITE DE DOCUMENTOS PERSONALES DEL PACIENTE") == 0)
        //    {
        //        registrarDocumentos();
        //    }
        //    cBoxActividadRealizada.SelectedIndex = -1;
        //}

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //FBuscarPacientesOperaciones formBuscarOperaciones = new FBuscarPacientesOperaciones("V");
            //if (formBuscarOperaciones.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    NumeroPacienteActual = formBuscarOperaciones.NumeroPaciente;
            //    CodigoActividad = formBuscarOperaciones.NumeroOperacion;
            //    cargarDatosActividadDiaria(CodigoActividad, formBuscarOperaciones.DRPacientes.FechaOperacion);
            //}
            //else
            //{
            //    MessageBox.Show(this, "Aún no ha Seleccionado ningun Paciente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}
            TipoOperacion = String.Empty;
            NumeroPacienteActual = null;   
            limpiarControles();
            FBusquedaPacientes formBuscarPacientes = new FBusquedaPacientes();
            formBuscarPacientes.ShowDialog();
            if (formBuscarPacientes.NumeroPaciente > 0)
            {                
                this.NumeroPacienteActual = formBuscarPacientes.NumeroPaciente;
                FechaHoraServidor = TAFuncionesSistema.ObtenerFechaHoraServidor().Value;
                dateFechaRegistroDiarioActividades.Value = FechaHoraServidor;
                cargarDatosPaciente(formBuscarPacientes.NumeroPaciente);                
                
                

                DTActividadesPacientes = TAActividadesPacientes.GetDataByPaciente(null, NumeroPacienteActual, null, null);
                bdSourceActividades.DataSource = DTActividadesPacientes;
                dtGVActividades.DataSource = bdSourceActividades;
                habilitarBotones(true, false, false, false, false, false, true);
                dateFechaHasta.Enabled = dateFechaDesde.Enabled = cBoxTrabajadoraSocialFiltro.Enabled = true;
            }
            else
            {
                MessageBox.Show(this, "Aún no ha Seleccionado ningún Paciente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                habilitarBotones(true, false, false, false, false, false, false);
                dateFechaHasta.Enabled = dateFechaDesde.Enabled = cBoxTrabajadoraSocialFiltro.Enabled = false;
            }
        }

        private void dateFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            
            DTActividadesPacientes = TAActividadesPacientes.GetDataByPaciente(null, NumeroPacienteActual, dateFechaDesde.Value, dateFechaHasta.Value);
            if (cBoxTrabajadoraSocialFiltro.SelectedIndex >= 0)
            {
                DTActividadesPacientes.DefaultView.RowFilter = "CodigoUsuario = " + int.Parse(cBoxTrabajadoraSocialFiltro.SelectedValue.ToString());
            }
            bdSourceActividades.DataSource = DTActividadesPacientes;
            dtGVActividades.DataSource = bdSourceActividades;
        }

        private void dtGVActividades_SelectionChanged(object sender, EventArgs e)
        {
            if (dtGVActividades.CurrentRow != null)
            {
                int codigo = int.Parse(dtGVActividades.CurrentRow.Cells["DGCCodigoActividadTipo"].Value.ToString());
                DateTime Fecha =DateTime.Parse(dtGVActividades.CurrentRow.Cells["DGCFechaActividad"].Value.ToString());
                cargarDatosActividadDiaria(codigo, Fecha);
            }
        }

        private void cBoxTrabajadoraSocialFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateFechaDesde_ValueChanged(sender, e);
        }



        private void cBoxTrabajadoraSocialFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                cBoxTrabajadoraSocialFiltro.SelectedIndex = -1;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ListarActividadesReporteTableAdapter TAListarActividadesReporte = new ListarActividadesReporteTableAdapter();
            ListarDatosPacienteReporteTableAdapter TAListarDatosPacienteReporte = new ListarDatosPacienteReporteTableAdapter();
            DataTable DTActividades = TAListarActividadesReporte.GetData(NumeroPacienteActual, "P", dateFechaDesde.Value, dateFechaHasta.Value);
            String NombreUsuario  = "   ";
            if (cBoxTrabajadoraSocialFiltro.SelectedIndex >= 0)
            {
                DTActividades.DefaultView.RowFilter = "CodigoUsuario = " + int.Parse(cBoxTrabajadoraSocialFiltro.SelectedValue.ToString());
                NombreUsuario = "Trabajadora Social :" + (cBoxTrabajadoraSocialFiltro.SelectedItem as DataRowView)["NombreCompleto"].ToString();
            }
            
                
            FReporteFormulariosIndividuales formReporte = new FReporteFormulariosIndividuales();
            formReporte.ListarActividadesReporte(DTActividades.DefaultView.ToTable(), TAListarDatosPacienteReporte.GetData(NumeroPacienteActual), 
                TAResponsablesPaciente.GetDataByPaciente(NumeroPacienteActual, "V"), "P", NombreUsuario,
                dateFechaDesde.Value, dateFechaHasta.Value);

            
            formReporte.ShowDialog();
            formReporte.Dispose();
        }

    }
}
