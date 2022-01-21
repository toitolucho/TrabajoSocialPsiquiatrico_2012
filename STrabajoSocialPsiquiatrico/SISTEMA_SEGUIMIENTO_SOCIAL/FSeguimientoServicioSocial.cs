using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_SocialTableAdapters;
using SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades;
using SISTEMA_SEGUIMIENTO_SOCIAL.Reportes;

namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    public partial class FSeguimientoServicioSocial : Form
    {
        ErrorProvider eProviderSeguimientoAnual;

        SeguimientoAnualTableAdapter TASeguimientoAnual;
        QTAFuncionesSistema TAFuncionesSistema;
        PacientesTableAdapter TAPacientes;
        ResponsablesTableAdapter TAResponsables;
        DireccionesTableAdapter TADirecciones;
        ListarHistorialPacienteActividadesTableAdapter TAListarHistorialPacientesActividades;
        TrabajadoresSocialesTableAdapter TATrabajadoresSociales;

        DSTrabajo_Social.PacientesDataTable DTPacientes;
        DSTrabajo_Social.ResponsablesDataTable DTResponsables;
        DSTrabajo_Social.DireccionesDataTable DTDirecciones;
        DSTrabajo_Social.SeguimientoAnualDataTable DTSeguimientoAnual;
        DSTrabajo_Social.ListarHistorialPacienteActividadesDataTable DTHistorialPaciente;
        DSTrabajo_Social.ResponsablesDataTable DTResponsablesPaciente;
        DSTrabajo_Social.TrabajadoresSocialesDataTable DTTrabajadoresSociales;
        public int NumeroPacienteActual { get; set; }
        public int CodigoSeguimientoAnualActual { get; set; }
        private String TipoOperacion;

        public FSeguimientoServicioSocial()
        {
            InitializeComponent(); 

            TASeguimientoAnual = new SeguimientoAnualTableAdapter();
            TAFuncionesSistema = new QTAFuncionesSistema();
            TAPacientes = new PacientesTableAdapter();
            TAResponsables = new ResponsablesTableAdapter();
            TATrabajadoresSociales = new TrabajadoresSocialesTableAdapter();
            TADirecciones = new DireccionesTableAdapter();            
            TAListarHistorialPacientesActividades = new ListarHistorialPacienteActividadesTableAdapter();
            eProviderSeguimientoAnual = new ErrorProvider();
            dtGVResponsables.ReadOnly = true;
            dtGVResponsables.AutoGenerateColumns = false;
            DTHistorialPaciente = new DSTrabajo_Social.ListarHistorialPacienteActividadesDataTable();
            DTResponsablesPaciente = new DSTrabajo_Social.ResponsablesDataTable();
            
            //DTTrabajadoresSociales = TATrabajadoresSociales.GetData();
            //DataColumn DCNombreCompleto = new DataColumn("NombreCompleto", Type.GetType("System.String"));
            //DCNombreCompleto.Expression = "NombreTS + ' '+ ApellidoPaternoTS + ' ' + ApellidoMaternoTS";
            //DTTrabajadoresSociales.Columns.Add(DCNombreCompleto);
            //DTTrabajadoresSociales.DefaultView.Sort = " NombreCompleto ASC";
            //cBoxTrabajadoraSocial.DataSource = DTTrabajadoresSociales;
            //cBoxTrabajadoraSocial.DisplayMember = "NombreCompleto";
            //cBoxTrabajadoraSocial.ValueMember = "CodigoTrabajadorSocial";
            //cBoxTrabajadoraSocial.SelectedIndex = -1;

            cargarDatosSeguimientoAnual(1, -1);
        }

        public void limpiarControles()
        {
            TxtApellidoPReingreso.Text = String.Empty;
            TxtDiagnostico.Text = String.Empty;
            TxtHClinicoSegAnual.Text = String.Empty;
            TxtSeccion.Text = String.Empty;
            txtDenominacion.Text = String.Empty;
            TxtUnidad.Text = String.Empty;
            rTextBoxEncomiendasRecibidas.Text = String.Empty;
            rTextBoxGatosAdministrativos.Text = String.Empty;
            rTextBoxInterconsultaRealizadas.Text = String.Empty;
            rTextBoxRelacionesFamiliares.Text = String.Empty;
            rTextBoxSituacionInstitucional.Text = String.Empty;
            rTextBoxTramitesRealizados.Text = String.Empty;
            dateSeguimientoAnual.Value = DateTime.Now;
            DTHistorialPaciente.Clear();
            DTResponsablesPaciente.Clear();
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            rTextBoxEncomiendasRecibidas.Enabled = estadoHabilitacion;
            rTextBoxGatosAdministrativos.Enabled = estadoHabilitacion;
            rTextBoxInterconsultaRealizadas.Enabled = estadoHabilitacion;
            rTextBoxRelacionesFamiliares.Enabled = estadoHabilitacion;
            rTextBoxSituacionInstitucional.Enabled = estadoHabilitacion;
            rTextBoxTramitesRealizados.Enabled = estadoHabilitacion;
            dateFechaDesde.Enabled = dateFechaHasta.Enabled = estadoHabilitacion;
            btnModificarResponsable.Enabled = estadoHabilitacion;
        }

        public bool validarControles()
        {
            eProviderSeguimientoAnual.Clear();
            if (String.IsNullOrEmpty(rTextBoxSituacionInstitucional.Text))
            {
                eProviderSeguimientoAnual.SetError(rTextBoxSituacionInstitucional, "Aún no ha Ingresado la Situación Institucional");
                rTextBoxSituacionInstitucional.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(rTextBoxInterconsultaRealizadas.Text))
            {
                eProviderSeguimientoAnual.SetError(rTextBoxInterconsultaRealizadas, "Aún no ha Ingresado las Interconsultas Realizadas");
                rTextBoxInterconsultaRealizadas.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(rTextBoxRelacionesFamiliares.Text))
            {
                eProviderSeguimientoAnual.SetError(rTextBoxRelacionesFamiliares, "Aún no ha Ingresado la Relacion Familiar");
                rTextBoxRelacionesFamiliares.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(rTextBoxGatosAdministrativos.Text))
            {
                eProviderSeguimientoAnual.SetError(rTextBoxGatosAdministrativos, "Aún no ha Ingresado los Gastos Administrativos");
                rTextBoxGatosAdministrativos.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(rTextBoxTramitesRealizados.Text))
            {
                eProviderSeguimientoAnual.SetError(rTextBoxTramitesRealizados, "Aún no ha Ingresado los Trámites Realizados");
                rTextBoxTramitesRealizados.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(rTextBoxSituacionInstitucional.Text))
            {
                eProviderSeguimientoAnual.SetError(rTextBoxSituacionInstitucional, "Aún no ha Ingresado la Situación Institucional");
                rTextBoxSituacionInstitucional.Focus();
                return false;
            }
            return true;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool eliminar, bool modificar, bool buscar, bool imprimir)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardarSegAnual.Enabled = aceptar;
            btnCancelar.Enabled = cancelar;
            btnEliminar.Enabled = eliminar;
            btnEditarSegSocial.Enabled = modificar;
            btnBuscarSegSocial.Enabled = buscar;
            btnImprimir.Enabled = imprimir;
        }

        public void cargarDatosSeguimientoAnual(int NumeroPaciente, int CodigoSeguimientoAnual)
        {
            limpiarControles();
            DTSeguimientoAnual = TASeguimientoAnual.GetDataBy1(NumeroPaciente, CodigoSeguimientoAnual);
            if (DTSeguimientoAnual.Count > 0)
            {
                this.NumeroPacienteActual = NumeroPaciente;
                this.CodigoSeguimientoAnualActual = CodigoSeguimientoAnual;

                DTPacientes = TAPacientes.GetDataBy11(NumeroPaciente);
                TxtApellidoPReingreso.Text = String.Format("{0} {1} {2}", DTPacientes[0].Nombre, DTPacientes[0].ApellidoPaterno, DTPacientes[0].ApellidoMaterno);
                TxtUnidad.Text = DTPacientes[0].IsUnidadNull() ? String.Empty : DTPacientes[0].Unidad.ToString();
                TxtSeccion.Text = DTPacientes[0].IsSeccionNull() ? String.Empty : DTPacientes[0].Seccion;
                txtDenominacion.Text = DTPacientes[0].IsDenominacionNull() ? String.Empty : DTPacientes[0].Denominacion;
                TxtHClinicoSegAnual.Text = DTPacientes[0].IsHClinicoNull() ? String.Empty : DTPacientes[0].HClinico.ToString();
                TxtDiagnostico.Text = DTPacientes[0].IsDiagnosticoNull() ? String.Empty : DTPacientes[0].Diagnostico;
                dateSeguimientoAnual.Value = DTSeguimientoAnual[0].FechaHoraRegistro;
                
                DTHistorialPaciente = TAListarHistorialPacientesActividades.GetData(NumeroPacienteActual, null, null);
                bdSourceActividades.DataSource = DTHistorialPaciente;
                dtGVListadoDatos.DataSource = bdSourceActividades;
                DTResponsablesPaciente = TAResponsables.GetDataByPaciente(NumeroPacienteActual, "V");
                dtGVResponsables.DataSource = DTResponsablesPaciente;

                rTextBoxEncomiendasRecibidas.Text = DTSeguimientoAnual[0].IsEncomiendasRecibidasNull() ? String.Empty : DTSeguimientoAnual[0].EncomiendasRecibidas;
                rTextBoxGatosAdministrativos.Text = DTSeguimientoAnual[0].IsGastosAdministrativosNull() ? String.Empty : DTSeguimientoAnual[0].GastosAdministrativos;
                rTextBoxInterconsultaRealizadas.Text = DTSeguimientoAnual[0].IsInterconsultasRelalizadasNull() ? String.Empty : DTSeguimientoAnual[0].InterconsultasRelalizadas;
                rTextBoxRelacionesFamiliares.Text = DTSeguimientoAnual[0].IsRelacionesFamiliaresNull() ? String.Empty : DTSeguimientoAnual[0].RelacionesFamiliares;
                rTextBoxSituacionInstitucional.Text = DTSeguimientoAnual[0].IsSituacionInstitucionalNull() ? String.Empty : DTSeguimientoAnual[0].SituacionInstitucional;
                rTextBoxTramitesRealizados.Text = DTSeguimientoAnual[0].IsTramitesRealizadosNull() ? String.Empty : DTSeguimientoAnual[0].TramitesRealizados;

                habilitarBotones(true, false, false, true, true, true, true);
            }
            else
                habilitarBotones(true, false, false, false, false, true, false);
            habilitarControles(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FBusquedaPacientes formbuscar = new FBusquedaPacientes();
            if (formbuscar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                limpiarControles();
                NumeroPacienteActual = formbuscar.NumeroPaciente;                

                DTPacientes = TAPacientes.GetDataBy11(NumeroPacienteActual);
                TxtApellidoPReingreso.Text = String.Format("{0} {1} {2}", DTPacientes[0].Nombre, DTPacientes[0].ApellidoPaterno, DTPacientes[0].ApellidoMaterno);
                TxtUnidad.Text = DTPacientes[0].IsUnidadNull() ? String.Empty : DTPacientes[0].Unidad.ToString();
                TxtSeccion.Text = DTPacientes[0].IsSeccionNull() ? String.Empty : DTPacientes[0].Seccion;
                txtDenominacion.Text = DTPacientes[0].IsDenominacionNull() ? String.Empty : DTPacientes[0].Denominacion;
                TxtHClinicoSegAnual.Text = DTPacientes[0].IsHClinicoNull() ? String.Empty : DTPacientes[0].HClinico.ToString();
                TxtDiagnostico.Text = DTPacientes[0].IsDiagnosticoNull() ? String.Empty : DTPacientes[0].Diagnostico;
                dateSeguimientoAnual.Value = TAFuncionesSistema.ObtenerFechaHoraServidor().Value;
                
                DTResponsablesPaciente = TAResponsables.GetDataByPaciente(NumeroPacienteActual, "V");
                dtGVResponsables.DataSource = DTResponsablesPaciente;

                DTHistorialPaciente = TAListarHistorialPacientesActividades.GetData(formbuscar.NumeroPaciente, null, null);
                dtGVListadoDatos.AutoGenerateColumns = false;
                bdSourceActividades.DataSource = DTHistorialPaciente;
                dtGVListadoDatos.DataSource = bdSourceActividades;

                CodigoSeguimientoAnualActual = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(NumeroPacienteActual, "N").Value;

                TipoOperacion = "I";
                habilitarBotones(false, true, true, false, false, false, false);
                habilitarControles(true);
                
            }
            else
            {
                MessageBox.Show(this, "Aún no ha seleccionado ningún Paciente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            
        }

        private void btnGuardarSegAnual_Click(object sender, EventArgs e)
        {
            if (validarControles())
            {
                try
                {
                    
                    if (TipoOperacion == "I")
                    {
                        TASeguimientoAnual.Insert(NumeroPacienteActual, rTextBoxSituacionInstitucional.Text, rTextBoxRelacionesFamiliares.Text,
                            rTextBoxEncomiendasRecibidas.Text, rTextBoxInterconsultaRealizadas.Text,
                            rTextBoxGatosAdministrativos.Text, rTextBoxTramitesRealizados.Text);
                        //int? codigoAux = -1;
                        ////TAFuncionesSistema.ObtenerUltimoIndiceTabla("SeguimientoAnual", ref codigoAux);
                        //codigoAux = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(NumeroPacienteActual, "N").Value;
                        //CodigoSeguimientoAnualActual = codigoAux.Value;
                    }
                    else
                    {
                        TASeguimientoAnual.ActualizarSeguimientoAnual(NumeroPacienteActual, CodigoSeguimientoAnualActual, rTextBoxSituacionInstitucional.Text, rTextBoxRelacionesFamiliares.Text,
                            rTextBoxEncomiendasRecibidas.Text, rTextBoxInterconsultaRealizadas.Text,
                            rTextBoxGatosAdministrativos.Text, rTextBoxTramitesRealizados.Text);
                    }
                    MessageBox.Show(this, "Operación realizada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TipoOperacion = "";
                    habilitarBotones(true, false, false, true, true, true, true);
                    habilitarControles(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se pudo culminar la operación Actual, ocurrió la siguiente excepción " + ex.Message, this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show(this,"Existen valores que son considerados obligatorios, por favor proceda a completar o corregirlos");
            }
        }

        private void btnEditarSegSocial_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            habilitarBotones(false, true, true, false, false, false, false);
            habilitarControles(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            eProviderSeguimientoAnual.Clear();
            TipoOperacion = "";
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false, true, false);
            limpiarControles();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de Eliminar el Registro Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                TASeguimientoAnual.Delete(NumeroPacienteActual, CodigoSeguimientoAnualActual);
                limpiarControles();
                habilitarBotones(true, false, false, false, false, true, false);
                NumeroPacienteActual = -1;
                CodigoSeguimientoAnualActual = -1;
            }
        }

        private void btnBuscarSegSocial_Click(object sender, EventArgs e)
        {
            FBuscarPacientesOperaciones formBuscarOperaciones = new FBuscarPacientesOperaciones("A");
            if (formBuscarOperaciones.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                NumeroPacienteActual = formBuscarOperaciones.NumeroPaciente;
                CodigoSeguimientoAnualActual = formBuscarOperaciones.NumeroOperacion;

                cargarDatosSeguimientoAnual(NumeroPacienteActual, CodigoSeguimientoAnualActual);
            }
            else
            {
                MessageBox.Show(this, "Aún no ha Seleccionado ningun Paciente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtUnidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void dateFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TipoOperacion))
            {
                DTHistorialPaciente = TAListarHistorialPacientesActividades.GetData(NumeroPacienteActual, dateFechaDesde.Value, dateFechaHasta.Value);
                if (cBoxTipoActividad.SelectedIndex >= 0)
                {
                    DTHistorialPaciente.DefaultView.RowFilter = "TipoHistorial = '" + cBoxTipoActividad.SelectedItem.ToString() + "'";
                }
                bdSourceActividades.DataSource = DTHistorialPaciente;
                dtGVListadoDatos.DataSource = bdSourceActividades;
            }
        }

        private void dtGVListadoDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificarResponsable_Click(object sender, EventArgs e)
        {
            FFichaSocial f4 = new FFichaSocial(-1);
            f4.cargarDatosPaciente(NumeroPacienteActual);
            f4.HabilitarPestaniaSoloResponsable();
            if (dtGVResponsables.CurrentRow != null)
                f4.cargarDatosResponsables(NumeroPacienteActual, int.Parse(dtGVResponsables.CurrentRow.Cells["DGCCodigoResponsable"].Value.ToString()));
            f4.ShowDialog();
            f4.Dispose();
            DTResponsablesPaciente = TAResponsables.GetDataByPaciente(NumeroPacienteActual, "V");
            dtGVResponsables.DataSource = DTResponsablesPaciente;
            //FechaHoraServidor = TAFuncionesSistema.ObtenerFechaHoraServidor().Value;
        
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkObtenerFechaIngresoPaciente.Checked && 
                !string.IsNullOrEmpty(TipoOperacion )  && DTPacientes != null && DTPacientes.Count != 0
                )
            {
                dateFechaDesde.Value = DTPacientes[0].FechaIngreso;
            }
        }

        private void cBoxTipoActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateFechaHasta_ValueChanged(sender, e);
        }

        private void cBoxTipoActividad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                cBoxTipoActividad.SelectedIndex = -1;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ListarDatosPacienteReporteTableAdapter TAListarDatosPacienteReporte = new ListarDatosPacienteReporteTableAdapter();
            ObtenerResponsablesTableAdapter TAObtenerResponsable = new ObtenerResponsablesTableAdapter();
            FReporteFormulariosIndividuales formReporte = new FReporteFormulariosIndividuales();
            formReporte.ListarSeguimientoAnualReporte(TAListarDatosPacienteReporte.GetData(NumeroPacienteActual), TAObtenerResponsable.GetData(NumeroPacienteActual, "V"),
                TASeguimientoAnual.GetDataBy1(NumeroPacienteActual, CodigoSeguimientoAnualActual));
            formReporte.ShowDialog();
            formReporte.Dispose();
        }
        
    }
}
