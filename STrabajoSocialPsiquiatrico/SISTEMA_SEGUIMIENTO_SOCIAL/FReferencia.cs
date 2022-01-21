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
    public partial class FReferencia : Form
    {
        PacientesTableAdapter TAPacientes;
        ReferenciasTableAdapter TAReferencias;
        TrabajadoresSocialesTableAdapter TATrabajadoresSociales;
        UnidadesMedicasTableAdapter TAUnidadesMedicas;
        QTAFuncionesSistema TAFuncionesSistema;
        EspecialidadesTableAdapter TAEspeciliadades;
        UsuariosTableAdapter TAUsuarios;
        DepartamentosTableAdapter TADepartamentos;
        ContrarreferenciasTableAdapter TAContrarreferencias;
        OcupacionesTableAdapter TAOcupaciones;

        DSTrabajo_Social.PacientesDataTable DTPacientes;
        DSTrabajo_Social.ReferenciasDataTable DTReferencias;
        DSTrabajo_Social.TrabajadoresSocialesDataTable DTPersonasReferenciadas;
        DSTrabajo_Social.TrabajadoresSocialesDataTable DTPersonasReferenciadas2;
        DSTrabajo_Social.TrabajadoresSocialesDataTable DTMedicoResponsable;
        DSTrabajo_Social.UnidadesMedicasDataTable DTUnidadesMedicas;
        DSTrabajo_Social.EspecialidadesDataTable DTServiciosEspecialidades;
        DSTrabajo_Social.EspecialidadesDataTable DTServiciosEspecialidades2;
        DSTrabajo_Social.UsuariosDataTable DTTRabajadorasSociales;
        DSTrabajo_Social.UsuariosDataTable DTTRabajadorasSociales2;
        DSTrabajo_Social.ContrarreferenciasDataTable DTContrarreferencias;
        DSTrabajo_Social.OcupacionesDataTable DTOcupaciones;

        public int NumeroPacienteActual { get; set; }
        private string TipoOperacion = "";
        private ErrorProvider eProviderReferencia = new ErrorProvider();
        private int CodigoUsuario;
        public FReferencia(int CodigoUsuario)
        {
            InitializeComponent();
            this.CodigoUsuario = CodigoUsuario;

            TAPacientes = new PacientesTableAdapter();
            TAReferencias = new ReferenciasTableAdapter();
            TATrabajadoresSociales = new TrabajadoresSocialesTableAdapter();
            TADepartamentos = new DepartamentosTableAdapter();
            TAUnidadesMedicas = new UnidadesMedicasTableAdapter();
            TAFuncionesSistema = new QTAFuncionesSistema();
            TAEspeciliadades = new EspecialidadesTableAdapter();
            TAUsuarios = new UsuariosTableAdapter();
            TAContrarreferencias = new ContrarreferenciasTableAdapter();
            TAOcupaciones = new OcupacionesTableAdapter();
            DTPacientes = new DSTrabajo_Social.PacientesDataTable();
            DTReferencias = new DSTrabajo_Social.ReferenciasDataTable();
            DTPersonasReferenciadas = new DSTrabajo_Social.TrabajadoresSocialesDataTable();
            DTMedicoResponsable = new DSTrabajo_Social.TrabajadoresSocialesDataTable();
            DTUnidadesMedicas = new DSTrabajo_Social.UnidadesMedicasDataTable();
            DTServiciosEspecialidades = new DSTrabajo_Social.EspecialidadesDataTable();
            DTTRabajadorasSociales = new DSTrabajo_Social.UsuariosDataTable();
            DTContrarreferencias = new DSTrabajo_Social.ContrarreferenciasDataTable();

            DTOcupaciones = TAOcupaciones.GetData();

            cBoxGradoInstReferencia.Items.Clear();
            cBoxGradoInstReferencia.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaGradoInstruccion();
            cBoxGradoInstReferencia.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxGradoInstReferencia.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;

            cBoxEstadoCivilReferencia.Items.Clear();
            cBoxEstadoCivilReferencia.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaEstadoCivil();
            cBoxEstadoCivilReferencia.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxEstadoCivilReferencia.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;

            cBoxGradoInstruccion2.Items.Clear();
            cBoxGradoInstruccion2.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaGradoInstruccion();
            cBoxGradoInstruccion2.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxGradoInstruccion2.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxGradoInstruccion2.SelectedIndex = -1;

            cBoxEstadoCivil2.Items.Clear();
            cBoxEstadoCivil2.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaEstadoCivil();
            cBoxEstadoCivil2.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxEstadoCivil2.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxEstadoCivil2.SelectedIndex = -1;

            DTPersonasReferenciadas = TATrabajadoresSociales.GetData();
            DataColumn DCNombreCompleto = new DataColumn("NombreCompleto", Type.GetType("System.String"));
            DCNombreCompleto.Expression = "NombreTS + ' '+ ApellidoPaternoTS + ' ' + ApellidoMaternoTS";
            DTPersonasReferenciadas.Columns.Add(DCNombreCompleto);
            DTPersonasReferenciadas.DefaultView.Sort = " NombreCompleto ASC";

            DTPersonasReferenciadas2 = DTPersonasReferenciadas.Copy() as DSTrabajo_Social.TrabajadoresSocialesDataTable;
            cBoxTrabajadorSocial.DataSource = DTPersonasReferenciadas2;
            cBoxTrabajadorSocial.DisplayMember = "NombreCompleto";
            cBoxTrabajadorSocial.ValueMember = "CodigoTrabajadorSocial";
            cBoxTrabajadorSocial.SelectedIndex = -1;


            cBoxPersonaRefiere2.DataSource = DTPersonasReferenciadas;
            cBoxPersonaRefiere2.DisplayMember = "NombreCompleto";
            cBoxPersonaRefiere2.ValueMember = "CodigoTrabajadorSocial";
            cBoxPersonaRefiere2.SelectedIndex = -1;


            DTMedicoResponsable = (DSTrabajo_Social.TrabajadoresSocialesDataTable)DTPersonasReferenciadas.Copy();
            DTMedicoResponsable.DefaultView.RowFilter = "CodigoOcupacion = 1";
            cBoxMedicoResponsable.DataSource = DTMedicoResponsable;
            cBoxMedicoResponsable.DisplayMember = "NombreCompleto";
            cBoxMedicoResponsable.ValueMember = "CodigoTrabajadorSocial";
            cBoxMedicoResponsable.SelectedIndex = -1;

            
            
            DTServiciosEspecialidades = TAEspeciliadades.GetData();
            cBoxEspecialidad.DataSource = DTServiciosEspecialidades;
            cBoxEspecialidad.DisplayMember = "NombreEspecialidad";
            cBoxEspecialidad.ValueMember = "CodigoEspecialidad";
            cBoxEspecialidad.SelectedIndex = -1;


            DTServiciosEspecialidades2 = DTServiciosEspecialidades.Copy() as DSTrabajo_Social.EspecialidadesDataTable;
            cBoxServicio.DataSource = DTServiciosEspecialidades2;
            cBoxServicio.DisplayMember = "NombreEspecialidad";
            cBoxServicio.ValueMember = "CodigoEspecialidad";
            cBoxServicio.SelectedIndex = -1;


            DTTRabajadorasSociales = TAUsuarios.GetDataByTrabajadorSocial();
            //DTUsuarios.Columns.Add("NombreCompleto");
            //DTUsuarios.Columns["NombreCompleto"].Expression = String.Format("{0} + ' ' +  {1}  + ' ' + {2}", DTUsuarios.NombreColumn,
                //DTUsuarios.ApellidoPaternoColumn, DTUsuarios.ApellidoMaternoColumn);
            cBoxTrabSocialDelPsiquitrico.DataSource = DTTRabajadorasSociales;
            cBoxTrabSocialDelPsiquitrico.DisplayMember = "NombreCompleto";
            cBoxTrabSocialDelPsiquitrico.ValueMember = "CodigoUsuario";
            cBoxTrabSocialDelPsiquitrico.SelectedValue = CodigoUsuario;

            DTTRabajadorasSociales2 = DTTRabajadorasSociales.Copy() as DSTrabajo_Social.UsuariosDataTable;
            cBoxTrabajdoraSocialContra2.DataSource = DTTRabajadorasSociales2;
            cBoxTrabajdoraSocialContra2.DisplayMember = "NombreCompleto";
            cBoxTrabajdoraSocialContra2.ValueMember = "CodigoUsuario";
            cBoxTrabajdoraSocialContra2.SelectedValue = CodigoUsuario;


            cBoxTipoReferencia.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaTipoReferencia();
            cBoxTipoReferencia.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxTipoReferencia.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxTipoReferencia.SelectedIndex = -1;

            cargarDatosPaciente(-1);
            limpiarControles2();
            habilitarControles2(false);
            habilitarBotones2(true, false, false, true, false, false, false);

        }

        public void limpiarControles()
        {
            TxtDiagPsiquiatricoReferencia.Text = String.Empty;
            TxtEdadReferencia.Text = String.Empty;
            TxtNombrePacienteReferencia.Text = String.Empty;
            TxtNroHijosReferencia.Text = String.Empty;            
            TxtNumeroReferencia.Text = String.Empty;
            txtOcupacionReferencia.Text = String.Empty;
            TxtUnidadMedica.Text = String.Empty;
            TxtUnidadMedicaPsiquiatrico.Text = String.Empty;
            cBoxEspecialidad.SelectedIndex = -1;
            cBoxEstadoCivilReferencia.SelectedIndex = -1;
            rTextBoxObservacionesReferencia.Text = String.Empty;
            cBoxGradoInstReferencia.SelectedIndex = -1;
            txtProcedencia.Text = string.Empty;
            cBoxTrabajadorSocial.SelectedIndex = cBoxMedicoResponsable.SelectedIndex = cBoxTipoReferencia.SelectedIndex = - 1;
            cBoxTrabSocialDelPsiquitrico.SelectedIndex = -1;
            dateFechaReferencia.Value = DateTime.Now;
            rTextBoxObservacionesReferencia.Text = String.Empty;
            txtObservacionesContra.Clear();
            txtOcupacionRef.Clear();
        }

        public void limpiarControles2()
        {
            txtOcupacionContra.Text = txtNombrePaciente2.Text = txtNumeroReferencia2.Text =
                txtEdad2.Text = txtProcedencia2.Text = txtOcupacion.Text =
                txtCentroMedicoRefiere.Text = txtNumeroReferencia2.Text =
                txtUnidadContrareferencia.Text = string.Empty;
            cBoxEstadoCivil2.SelectedIndex = cBoxGradoInstruccion2.SelectedIndex =
                cBoxPersonaRefiere2.SelectedIndex = cBoxServicio.SelectedIndex =
                cBoxTrabajdoraSocialContra2.SelectedIndex = -1;
            dateFechaRef2.Value = dateContraReferencia.Value = DateTime.Now;
            checkInformacionContraReferencia.Checked = false;
            txtObservacionesContra2.Clear();
            
        }

        public void habilitarControles2(bool estadoHabilitacion)
        {
            cBoxServicio.Enabled = cBoxPersonaRefiere2.Enabled = estadoHabilitacion;
            btnAgregarPersona.Enabled = btnAgregarServicio2.Enabled = estadoHabilitacion;
            dateFechaRef2.Enabled = dateContraReferencia.Enabled = estadoHabilitacion;
            cBoxTrabajdoraSocialContra2.Enabled = estadoHabilitacion;
            txtObservacionesContra2.Enabled = TxtDiagPsiquiatricoReferencia.Enabled = estadoHabilitacion;
            btnAnadirMedicoResponsable.Enabled = estadoHabilitacion;
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            //TxtDiagPsiquiatricoReferencia.ReadOnly = !estadoHabilitacion;
            //TxtNroHijosReferencia.ReadOnly = !estadoHabilitacion;            
            //TxtUnidadMedica.ReadOnly = !estadoHabilitacion;
            //TxtUnidadMedicaPsiquiatrico.ReadOnly = !estadoHabilitacion;
            cBoxEspecialidad.Enabled = estadoHabilitacion;
            rTextBoxObservacionesReferencia.Enabled = txtObservacionesContra.Enabled = estadoHabilitacion;

            cBoxTrabajadorSocial.Enabled = cBoxMedicoResponsable.Enabled = estadoHabilitacion;
            //cBoxTipoReferencia.Enabled = 
            cBoxTrabSocialDelPsiquitrico.Enabled = estadoHabilitacion;
            dateFechaReferencia.Enabled = estadoHabilitacion;
            rTextBoxObservacionesReferencia.Enabled = estadoHabilitacion;
            btnAñadirEspecialidad.Enabled = estadoHabilitacion;
            btnAñadirTrabajadorSocial.Enabled = estadoHabilitacion;
            dateFechaObservacion.Enabled = estadoHabilitacion;
            //txtProcedencia.ReadOnly = !estadoHabilitacion;

            
        }


        public void habilitarTabReferenciaEnviada(bool estadoHabilitacion)
        {
            foreach(Control control in tabPageReferenciaEnviada.Controls )
            {
                control.Enabled = estadoHabilitacion;
            }
        }

        public void habilitarTabReferenciaRecibida(bool estadoHabilitacion)
        {
            foreach (Control control in tabPageReferenciaRecibida.Controls)
            {
                control.Enabled = estadoHabilitacion;
            }
        }

        public void habilitarBotones2(bool nuevo, bool guardar, bool editar, bool buscar, bool imprimir, bool cancelar, bool eliminar)
        {
            btnNuevo2.Enabled = nuevo;
            btnGuardar2.Enabled = guardar;
            btnModificar2.Enabled = editar;
            btnBuscar2.Enabled = buscar;
            btnReporte2.Enabled = imprimir;
            btnCancelar2.Enabled = cancelar;
            btnEliminar2.Enabled = eliminar;
            
        }
        

        public void habilitarBotones(bool nuevo, bool guardar, bool editar, bool buscar, bool verSolicitud, bool imprimir, bool cancelar, bool eliminar)
        {
            btnNuevo.Enabled = nuevo;
            btnAceptarReferencia.Enabled = guardar;
            btnEditarReferencia.Enabled = editar;
            btnBuscarReferencia.Enabled = buscar;
           //btnVerSolicitud.Enabled = verSolicitud;
            btnReporte1.Enabled = imprimir;
            btnCancelar.Enabled = cancelar;
            btnEliminar.Enabled = eliminar;
        }

        public void cargarDatosPaciente2(int NumeroPaciente)
        {
            DTPacientes = TAPacientes.GetDataBy11(NumeroPaciente);
            if (DTPacientes.Count > 0)
            {
                this.NumeroPacienteActual = NumeroPaciente;
                this.txtNombrePaciente2.Text = DTPacientes[0].Nombre.Trim() + " " + DTPacientes[0].ApellidoPaterno.Trim() + " " + DTPacientes[0].ApellidoMaterno.Trim();
                txtOcupacion.Text = DTPacientes[0].IsOcupacionNull() ? String.Empty : DTPacientes[0].Ocupacion;
                //TxtUnidadMedica.Text = DTPacientes[0].IsUnidadNull() ? String.Empty : DTPacientes[0].Unidad.ToString();
                txtEdad2.Text = TAFuncionesSistema.ObtenerEdadPaciente(NumeroPaciente).Value.ToString();
                txtOcupacion.Text = DTPacientes[0].IsOcupacionNull() ? String.Empty : DTPacientes[0].Ocupacion;
                
                if (DTPacientes[0].IsEstadoCivilNull())
                    cBoxEstadoCivil2.SelectedIndex = -1;
                else
                    cBoxEstadoCivil2.SelectedValue = DTPacientes[0].EstadoCivil;

                if (DTPacientes[0].IsGradoInstruccionNull())
                    cBoxGradoInstruccion2.SelectedIndex = -1;
                else
                    cBoxGradoInstruccion2.SelectedValue = DTPacientes[0].GradoInstruccion;
                //txtProcedencia.SelectedValue = DTPacientes[0].;
                if (DTPacientes[0].IsCodigoDepartamentoResidenciaNull())
                    txtProcedencia2.Text = String.Empty;
                else
                    txtProcedencia2.Text = TADepartamentos.GetDataBy1(DTPacientes[0].CodigoPaisResidencia, DTPacientes[0].CodigoDepartamentoResidencia)[0].NombreDepartamento;
                habilitarBotones2(true, false, false, true, true, false, false);

            }
            else
            {
                limpiarControles2();
                habilitarBotones2(true, false, false, false, false, false, false);

            }
            habilitarControles2(false);
        }

        public void cargarDatosPaciente(int NumeroPaciente)
        {
            DTPacientes = TAPacientes.GetDataBy11(NumeroPaciente);
            if (DTPacientes.Count > 0)
            {
                this.NumeroPacienteActual = NumeroPaciente;
                this.TxtNombrePacienteReferencia.Text = DTPacientes[0].Nombre.Trim() + " " + DTPacientes[0].ApellidoPaterno.Trim() + " " + DTPacientes[0].ApellidoMaterno.Trim();
                txtOcupacionReferencia.Text = DTPacientes[0].IsOcupacionNull() ? String.Empty : DTPacientes[0].Ocupacion;
                //TxtUnidadMedica.Text = DTPacientes[0].IsUnidadNull() ? String.Empty : DTPacientes[0].Unidad.ToString();
                TxtEdadReferencia.Text = TAFuncionesSistema.ObtenerEdadPaciente(NumeroPaciente).Value.ToString();
                TxtNroHijosReferencia.Text = TAFuncionesSistema.ObtenerNumeroFamiliaresParentescoAsociadosPaciente(NumeroPaciente, 4).Value.ToString();
                TxtDiagPsiquiatricoReferencia.Text = DTPacientes[0].IsDiagnosticoNull() ? String.Empty : DTPacientes[0].Diagnostico;
                if (DTPacientes[0].IsEstadoCivilNull())
                    cBoxEstadoCivilReferencia.SelectedIndex = -1;
                else
                    cBoxEstadoCivilReferencia.SelectedValue = DTPacientes[0].EstadoCivil;

                if (DTPacientes[0].IsGradoInstruccionNull())
                    cBoxGradoInstReferencia.SelectedIndex = -1;
                else
                    cBoxGradoInstReferencia.SelectedValue = DTPacientes[0].GradoInstruccion;
                //txtProcedencia.SelectedValue = DTPacientes[0].;
                if (DTPacientes[0].IsCodigoDepartamentoResidenciaNull())
                    txtProcedencia.Text = String.Empty; 
                else
                    txtProcedencia.Text = TADepartamentos.GetDataBy1(DTPacientes[0].CodigoPaisResidencia, DTPacientes[0].CodigoDepartamentoResidencia)[0].NombreDepartamento;
                habilitarBotones(true, false, true, true, true, true, true, true);
                
            }
            else
            {
                limpiarControles();
                habilitarBotones(true, false, false, true, false, false, false, false);
                
            }
            habilitarControles(false);
        }

        public bool validarControles()
        {

            eProviderReferencia.Clear();
            tabControlReferencia.SelectedTab = tabPageReferenciaEnviada;
            if (String.IsNullOrEmpty(TxtNroHijosReferencia.Text))
            {
                eProviderReferencia.SetError(TxtNroHijosReferencia, "Aún no ha ingresado el Nro de Hijos");
                MessageBox.Show("Aún no ha ingresado el Nro de Hijos");
                TxtNroHijosReferencia.Focus();
                return false;
            }
            int numero = -1;
            if (!int.TryParse(TxtNroHijosReferencia.Text, out numero))
            {
                eProviderReferencia.SetError(TxtNroHijosReferencia, "El Nro de Hijos se encuentra mal Escritos");
                MessageBox.Show("El Nro de Hijos se encuentra mal Escritos");
                TxtNroHijosReferencia.Focus();
                return false;
            }
            
            if (cBoxTrabajadorSocial.SelectedIndex < 0)
            {
                eProviderReferencia.SetError(cBoxTrabajadorSocial, "Aún no ha seleccionado el Nombre de la Personal a quién va dirigida la Solicitud de Referencia");
                MessageBox.Show("Aún no ha seleccionado el Nombre de la Persona a quién va dirigida la Referencia");
                cBoxTrabajadorSocial.Focus();
                return false;
            }
            if (cBoxTrabSocialDelPsiquitrico.SelectedIndex < 0)
            {
                eProviderReferencia.SetError(cBoxTrabSocialDelPsiquitrico, "Aún no ha seleccionado el nombre de la Trabajadora Social que remite la Solicitud de Referencia");
                MessageBox.Show("Aún no ha seleccionado el nombre de la Trabajadora Social que remite la Solicitud de Referencia");
                cBoxTrabSocialDelPsiquitrico.Focus();
                return false;
            }

            //if (cBoxTipoReferencia.SelectedIndex < 0)
            //{
            //    eProviderReferencia.SetError(cBoxTipoReferencia, "Aún no ha seleccionado el Tipo de Referencia");
            //    MessageBox.Show("Aún no ha seleccionado el Tipo de Referencia");
            //    cBoxTipoReferencia.Focus();
            //    return false;
            //}

            if (cBoxEspecialidad.SelectedIndex < 0)
            {
                eProviderReferencia.SetError(cBoxEspecialidad, "Aún no ha seleccionado el Servicio que se está solicitando");
                MessageBox.Show("Aún no ha seleccionado el Servicio que se está solicitando");
                cBoxEspecialidad.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(TxtDiagPsiquiatricoReferencia.Text))
            {
                eProviderReferencia.SetError(TxtDiagPsiquiatricoReferencia, "Aún no ha Ingresado el diagnóstico Psiquiátrico");
                MessageBox.Show("Aún no ha Ingresado el diagnóstico Psiquiátrico");
                TxtDiagPsiquiatricoReferencia.Focus();
                return false;
            }

           

            if (String.IsNullOrEmpty(rTextBoxObservacionesReferencia.Text))
            {
                eProviderReferencia.SetError(rTextBoxObservacionesReferencia, "Aún no ha Ingresado las Observaciones");
                MessageBox.Show("Aún no ha Ingresado las Observaciones");
                rTextBoxObservacionesReferencia.Focus();
                return false;
            }
            return true;
        }



        public bool validarControles2()
        {

            eProviderReferencia.Clear();
            tabControlReferencia.SelectedTab = tabPageReferenciaRecibida;
            
            if (cBoxPersonaRefiere2.SelectedIndex < 0)
            {
                eProviderReferencia.SetError(cBoxPersonaRefiere2, "Aún no ha seleccionado el Nombre de la Persona de quién viene la Solicitud de Referencia");
                MessageBox.Show("Aún no ha seleccionado el Nombre de la Persona de quién viene la Solicitud de Referencia");
                cBoxPersonaRefiere2.Focus();
                return false;
            }           


            if (cBoxServicio.SelectedIndex < 0)
            {
                eProviderReferencia.SetError(cBoxServicio, "Aún no ha seleccionado el Servicio que se ha solicitado");
                MessageBox.Show("Aún no ha seleccionado el Servicio que se ha solicitado");
                cBoxServicio.Focus();
                return false;
            }

            if (checkInformacionContraReferencia.Checked)
            {
                if (cBoxTrabajdoraSocialContra2.SelectedIndex < 0)
                {
                    eProviderReferencia.SetError(cBoxTrabajdoraSocialContra2, "Aún no ha seleccionado el nombre de la Trabajadora Social que responde la Solicitud de Referencia");
                    MessageBox.Show("Aún no ha seleccionado el nombre de la Trabajadora Social que responde la Solicitud de Referencia");
                    cBoxTrabajdoraSocialContra2.Focus();
                    return false;
                }
                if (String.IsNullOrEmpty(txtObservacionesContra2.Text))
                {
                    eProviderReferencia.SetError(txtObservacionesContra2, "Aún no ha Ingresado las Observaciones");
                    MessageBox.Show("Aún no ha Ingresado las Observaciones");
                    txtObservacionesContra2.Focus();
                    return false;
                }
            }
            return true;
        }

        


        private void btnBuscarReferencia_Click(object sender, EventArgs e)
        {
            FBuscarPacientesOperaciones formBuscarPaciente = new FBuscarPacientesOperaciones("F");
            formBuscarPaciente.FiltroAdicional = "E";
            formBuscarPaciente.ShowDialog();
            if (formBuscarPaciente.NumeroPaciente > 0)
            {
                NumeroPacienteActual = formBuscarPaciente.NumeroPaciente;
                cargarDatosPaciente(NumeroPacienteActual);

                TxtNumeroReferencia.Text = formBuscarPaciente.NumeroOperacion.ToString();
                //cBoxEstadoReferencia.SelectedValue = formBuscarPaciente.DRPacientes["EstadoReferencia"].ToString();
                cBoxTrabajadorSocial.SelectedValue = formBuscarPaciente.DRPacientes["CodigoTrabajadorSocial"].ToString();
                if (formBuscarPaciente.DRPacientes["CodigoMedicoResponsable"] != null)
                    cBoxMedicoResponsable.SelectedValue = formBuscarPaciente.DRPacientes["CodigoMedicoResponsable"];
                else
                    cBoxMedicoResponsable.SelectedIndex = -1;
                cBoxTrabSocialDelPsiquitrico.SelectedValue = formBuscarPaciente.DRPacientes["CodigoUsuario"].ToString();
                //cBoxTipoReferencia.SelectedValue = formBuscarPaciente.DRPacientes["CodigoUsuario"].ToString();
                cBoxEspecialidad.SelectedValue = formBuscarPaciente.DRPacientes["CodigoEspecialidad"].ToString();
                //cBoxTipoReferencia.SelectedValue = formBuscarPaciente.DRPacientes["CodigoTipoReferencia"].ToString();
                //TxtNroHijosReferencia.Text = formBuscarPaciente.DRPacientes["NumeroHijos"].ToString();
                TxtNroHijosReferencia.Text = TAFuncionesSistema.ObtenerNumeroFamiliaresParentescoAsociadosPaciente(NumeroPacienteActual, 4).Value.ToString();
                TxtDiagPsiquiatricoReferencia.Text = formBuscarPaciente.DRPacientes["DiagnosticoPsiquiatrico"].ToString();
                rTextBoxObservacionesReferencia.Text = formBuscarPaciente.DRPacientes["Observaciones"].ToString();
                txtObservacionesContra.Text = formBuscarPaciente.DRPacientes["ObservacionesContra"].ToString();
                if(!String.IsNullOrEmpty(formBuscarPaciente.DRPacientes["FechaContraReferencia"].ToString()))
                    dateFechaObservacion.Value = DateTime.Parse(formBuscarPaciente.DRPacientes["FechaContraReferencia"].ToString());

                
            }
            formBuscarPaciente.Dispose();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            FBusquedaPacientes formBuscarPaciente = new FBusquedaPacientes();
            formBuscarPaciente.ShowDialog();
            if (formBuscarPaciente.NumeroPaciente > 0)
            {

                TipoOperacion = "I";
                limpiarControles();

                int? NumeroReferencia = -1;
                //TAFuncionesSistema.ObtenerUltimoIndiceTabla("Referencias", ref NumeroReferencia);
                NumeroReferencia = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(formBuscarPaciente.NumeroPaciente, "E").Value;
                TxtNumeroReferencia.Text = (NumeroReferencia).ToString();

                NumeroPacienteActual = formBuscarPaciente.NumeroPaciente;
                cargarDatosPaciente(NumeroPacienteActual);
                habilitarControles(true);
                habilitarBotones(false, true, false, false, false, false, true, false);
                cBoxTrabSocialDelPsiquitrico.SelectedValue = CodigoUsuario;                
                TxtNroHijosReferencia.Text = TAFuncionesSistema.ObtenerNumeroFamiliaresParentescoAsociadosPaciente(NumeroPacienteActual, 4).Value.ToString();
                cBoxMedicoResponsable.Enabled = false;
                habilitarTabReferenciaRecibida(false);
                btnAnadirMedicoResponsable.Enabled = false;
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun Paciente");
            }
            formBuscarPaciente.Dispose();
        }

        private void btnEditarReferencia_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            habilitarControles(true);
            habilitarBotones(false, true, false, false, false, false, true, false);
            habilitarTabReferenciaRecibida(false);
            btnAnadirMedicoResponsable.Enabled = false;
        }

        private void btnAceptarReferencia_Click(object sender, EventArgs e)
        {
            if (validarControles())
            {
                try
                {
                    if (TipoOperacion == "I")
                    {
                        TAReferencias.Insert(NumeroPacienteActual, dateFechaReferencia.Value, TxtDiagPsiquiatricoReferencia.Text,
                            cBoxMedicoResponsable.SelectedIndex >= 0 ? (int?)int.Parse(cBoxMedicoResponsable.SelectedValue.ToString()) : null,
                            int.Parse(cBoxTrabajadorSocial.SelectedValue.ToString()),
                            int.Parse(cBoxTrabSocialDelPsiquitrico.SelectedValue.ToString()) , 
                            //cBoxTipoReferencia.SelectedValue.ToString(),
                            "E",
                            int.Parse(cBoxEspecialidad.SelectedValue.ToString()), dateFechaObservacion.Value, txtObservacionesContra.Text, rTextBoxObservacionesReferencia.Text);
                        
                    }
                    else
                    {
                        TAReferencias.ActualizarReferencia(int.Parse(TxtNumeroReferencia.Text), NumeroPacienteActual, dateFechaReferencia.Value, TxtDiagPsiquiatricoReferencia.Text,
                            cBoxMedicoResponsable.SelectedIndex >= 0 ? (int?)int.Parse(cBoxMedicoResponsable.SelectedValue.ToString()) : null,
                            int.Parse(cBoxTrabajadorSocial.SelectedValue.ToString()),
                            int.Parse(cBoxTrabSocialDelPsiquitrico.SelectedValue.ToString()),
                            //cBoxTipoReferencia.SelectedValue.ToString(),
                            "E",
                            int.Parse(cBoxEspecialidad.SelectedValue.ToString()), dateFechaObservacion.Value, txtObservacionesContra.Text, rTextBoxObservacionesReferencia.Text);
                    }
                    habilitarTabReferenciaRecibida(true);
                    habilitarControles(false);
                    habilitarBotones(true, false, true, true, true, true, false, true);
                    TipoOperacion = "";
                    MessageBox.Show(this, "Se registró correctamente el Registro Actual", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrió la siguiente excepción " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //else
            //{
            //    MessageBox.Show("Existen algunos campos que son requeridos y que probablemente se encuentren mal escritos, por favor proceda a corregirlos");
            //}
        }

        private void btnCerrarReferencia_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cBoxTrabajadorSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxTrabajadorSocial.SelectedIndex >= 0
                && tabControlReferencia.SelectedTab == tabPageReferenciaEnviada)
            {
                //DTUnidadesMedicas = TAUnidadesMedicas.GetDataBy1(int.Parse(DTTrabajadoresSociales[cBoxTrabajadorSocial.SelectedIndex].CodigoUnidadMedica));
                DTUnidadesMedicas = TAUnidadesMedicas.GetDataBy1(int.Parse((cBoxTrabajadorSocial.SelectedItem as DataRowView)["CodigoUnidadMedica"].ToString()));
                if (DTUnidadesMedicas.Count > 0)
                {
                    TxtUnidadMedica.Text = DTUnidadesMedicas[0].NombreUnidadMedica;
                    cBoxTipoReferencia.SelectedValue = DTUnidadesMedicas[0].CodigoTipoUnidadMedica;
                    if (!string.IsNullOrEmpty(TipoOperacion))
                    {
                        btnAnadirMedicoResponsable.Enabled = DTUnidadesMedicas[0].CodigoTipoUnidadMedica.CompareTo("I") == 0;
                    }
                }

                DSTrabajo_Social.OcupacionesRow DROcupacion = DTOcupaciones.FindByCodigoOcupacion(
                    DTPersonasReferenciadas.FindByCodigoTrabajadorSocial(
                    int.Parse((cBoxTrabajadorSocial.SelectedItem as DataRowView)["CodigoTrabajadorSocial"].ToString())).CodigoOcupacion);
                if (DROcupacion != null)
                {

                    txtOcupacionRef.Text = DROcupacion.NombreOcupacion;
                }
                else
                {
                    DTOcupaciones = TAOcupaciones.GetData();
                    txtOcupacionRef.Text = DTOcupaciones.FindByCodigoOcupacion(
                        DTPersonasReferenciadas.FindByCodigoTrabajadorSocial(
                        int.Parse((cBoxTrabajadorSocial.SelectedItem as DataRowView)["CodigoTrabajadorSocial"].ToString())).CodigoOcupacion).NombreOcupacion;
                }
            }
        }

        private void btnAñadirEspecialidad_Click(object sender, EventArgs e)
        {
            FAñadirServicioSolicitado formTrabajadoraSocial = new FAñadirServicioSolicitado();
            formTrabajadoraSocial.configurarFormularioIA(null);
            formTrabajadoraSocial.Visible = false;
            if (formTrabajadoraSocial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int CodigoEspecialidad = formTrabajadoraSocial.CodigoEspecialidad;
                DataTable DTEspecialidadAux = TAEspeciliadades.GetDataBy1(CodigoEspecialidad);
                if (CodigoEspecialidad > 0 && DTEspecialidadAux.Rows.Count > 0 && DTServiciosEspecialidades.FindByCodigoEspecialidad(CodigoEspecialidad) == null)
                {
                    DTServiciosEspecialidades.Rows.Add(DTEspecialidadAux.Rows[0].ItemArray);
                    DTServiciosEspecialidades.DefaultView.Sort = "NombreEspecialidad ASC";

                    cBoxEspecialidad.SelectedValue = CodigoEspecialidad;
                }
            }
        }

        private void cBoxTrabSocialDelPsiquitrico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxTrabSocialDelPsiquitrico.SelectedIndex >= 0)
            {
                //DTUnidadesMedicas = TAUnidadesMedicas.GetDataBy1(int.Parse(DTTrabajadoresSociales[cBoxTrabajadorSocial.SelectedIndex].CodigoUnidadMedica));
                DTUnidadesMedicas = TAUnidadesMedicas.GetDataBy1(DTTRabajadorasSociales[cBoxTrabSocialDelPsiquitrico.SelectedIndex].CodigoUnidadMedica);
                if (DTUnidadesMedicas.Count > 0)
                {
                    TxtUnidadMedicaPsiquiatrico.Text = DTUnidadesMedicas[0].NombreUnidadMedica;
                }
            }
        }

        private void cBoxEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void TxtNroHijosReferencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, true, false, false, false, false);
            habilitarTabReferenciaRecibida(true);
        }

        private void txtMedicoSolicitante_TextChanged(object sender, EventArgs e)
        {


        }

        private void btnAgregarTrabajadoraSocial_Click(object sender, EventArgs e)
        {
            FAñadirDatosPersona formTrabajadoraSocial = new FAñadirDatosPersona();
            formTrabajadoraSocial.configurarFormularioIA(null);
            formTrabajadoraSocial.quitarInstituto();
            formTrabajadoraSocial.Visible = false;
            if (formTrabajadoraSocial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int CodigoTrabajadoraSocial = formTrabajadoraSocial.CodigoTrabajadorSocial;
                DataTable DTTRabajdora = TATrabajadoresSociales.GetDataBy1(CodigoTrabajadoraSocial);
                if (CodigoTrabajadoraSocial > 0 && DTTRabajdora.Rows.Count > 0 && DTPersonasReferenciadas.FindByCodigoTrabajadorSocial(CodigoTrabajadoraSocial) == null)
                {
                    DTPersonasReferenciadas.Rows.Add(DTTRabajdora.Rows[0].ItemArray);
                    DTPersonasReferenciadas.DefaultView.Sort = "NombreCompleto ASC";

                    DTPersonasReferenciadas2.Rows.Add(DTTRabajdora.Rows[0].ItemArray);
                    DTPersonasReferenciadas2.DefaultView.Sort = "NombreCompleto ASC";
                    cBoxPersonaRefiere2.SelectedIndex = -1;

                    cBoxTrabajadorSocial.SelectedValue = CodigoTrabajadoraSocial;

                    if (DTTRabajdora.Rows[0]["CodigoOcupacion"].Equals(1))
                    {
                        DTMedicoResponsable.Rows.Add(DTTRabajdora.Rows[0].ItemArray);
                        DTMedicoResponsable.DefaultView.Sort = "NombreCompleto ASC";
                    }
                }
                DTOcupaciones = TAOcupaciones.GetData();
            }

            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void cBoxTipoReferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cBoxTipoReferencia.SelectedValue.ToString().CompareTo("") == 0)
            if (!String.IsNullOrEmpty(TipoOperacion) && cBoxTipoReferencia.SelectedValue != null)
            {
                cBoxMedicoResponsable.Enabled = cBoxTipoReferencia.SelectedValue.ToString().CompareTo("I") == 0;
            }

        }

        private void btnAnadirMedicoResponsable_Click(object sender, EventArgs e)
        {
            FAñadirDatosPersona formTrabajadoraSocial = new FAñadirDatosPersona();
            formTrabajadoraSocial.configurarFormularioIA(null);
            formTrabajadoraSocial.cargarComoMedico();
            formTrabajadoraSocial.Visible = false;
            if (formTrabajadoraSocial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int CodigoTrabajadoraSocial = formTrabajadoraSocial.CodigoTrabajadorSocial;
                DataTable DTTRabajdora = TATrabajadoresSociales.GetDataBy1(CodigoTrabajadoraSocial);
                if (CodigoTrabajadoraSocial > 0 && DTTRabajdora.Rows.Count > 0 && DTPersonasReferenciadas.FindByCodigoTrabajadorSocial(CodigoTrabajadoraSocial) == null)
                {
                    DTMedicoResponsable.Rows.Add(DTTRabajdora.Rows[0].ItemArray);
                    DTMedicoResponsable.DefaultView.Sort = "NombreCompleto ASC";
                    cBoxMedicoResponsable.SelectedValue = CodigoTrabajadoraSocial;


                    DTPersonasReferenciadas.Rows.Add(DTTRabajdora.Rows[0].ItemArray);
                    DTMedicoResponsable.DefaultView.Sort = "NombreCompleto ASC";

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int NumReferencia = -1;
            if (MessageBox.Show(this, "¿Se encuentra seguro de eliminar la Referencia Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes
                && int.TryParse(TxtNumeroReferencia.Text, out NumReferencia))
            {
                TAReferencias.Delete(NumReferencia, NumeroPacienteActual);
                limpiarControles();
                habilitarBotones(true, false, false, true, false, false, false, false);
            }
        }

        private void btnNuevo2_Click(object sender, EventArgs e)
        {
            FBusquedaPacientes formBuscarPaciente = new FBusquedaPacientes();
            formBuscarPaciente.ShowDialog();
            if (formBuscarPaciente.NumeroPaciente > 0)
            {

                TipoOperacion = "I";
                limpiarControles2();
                habilitarTabReferenciaEnviada(false);
                NumeroPacienteActual = formBuscarPaciente.NumeroPaciente;
                cargarDatosPaciente2(NumeroPacienteActual);
                habilitarControles2(true);
                habilitarBotones2(false, true, false, false, false, true, false);

                

                int? NumeroReferencia = -1;                
                NumeroReferencia = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(formBuscarPaciente.NumeroPaciente, "E").Value;
                txtNumeroReferencia2.Text = (NumeroReferencia).ToString();


                //int? NumeroContraReferencia = -1;                
                //NumeroContraReferencia = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(formBuscarPaciente.NumeroPaciente, "C").Value;
                //txtNumeroContraReferencia2.Text = (NumeroContraReferencia).ToString();

                dateContraReferencia.Enabled = cBoxTrabajdoraSocialContra2.Enabled = checkInformacionContraReferencia.Checked;
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun Paciente");
            }
            formBuscarPaciente.Dispose();

            
            
        }

        private void btnAgregarPersona_Click(object sender, EventArgs e)
        {
            FAñadirDatosPersona formTrabajadoraSocial = new FAñadirDatosPersona();
            formTrabajadoraSocial.configurarFormularioIA(null);
            formTrabajadoraSocial.quitarInstituto();
            formTrabajadoraSocial.Visible = false;
            if (formTrabajadoraSocial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int CodigoTrabajadoraSocial = formTrabajadoraSocial.CodigoTrabajadorSocial;
                DataTable DTTRabajdora = TATrabajadoresSociales.GetDataBy1(CodigoTrabajadoraSocial);
                if (CodigoTrabajadoraSocial > 0 && DTTRabajdora.Rows.Count > 0 && DTPersonasReferenciadas.FindByCodigoTrabajadorSocial(CodigoTrabajadoraSocial) == null)
                {
                    DTPersonasReferenciadas2.Rows.Add(DTTRabajdora.Rows[0].ItemArray);
                    DTPersonasReferenciadas2.DefaultView.Sort = "NombreCompleto ASC";

                    DTPersonasReferenciadas.Rows.Add(DTTRabajdora.Rows[0].ItemArray);
                    DTPersonasReferenciadas.DefaultView.Sort = "NombreCompleto ASC";
                    cBoxTrabajadorSocial.SelectedIndex = -1;

                    cBoxPersonaRefiere2.SelectedValue = CodigoTrabajadoraSocial;

                    if (DTTRabajdora.Rows[0]["CodigoOcupacion"].Equals(1))
                    {
                        DTMedicoResponsable.Rows.Add(DTTRabajdora.Rows[0].ItemArray);
                        DTMedicoResponsable.DefaultView.Sort = "NombreCompleto ASC";
                    }
                }
                DTOcupaciones = TAOcupaciones.GetData();
            }
        }

        private void cBoxPersonaRefiere2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxPersonaRefiere2.SelectedIndex >= 0 
                && tabControlReferencia.SelectedTab == tabPageReferenciaRecibida)
            {
                //DTUnidadesMedicas = TAUnidadesMedicas.GetDataBy1(int.Parse(DTTrabajadoresSociales[cBoxTrabajadorSocial.SelectedIndex].CodigoUnidadMedica));
                DTUnidadesMedicas = TAUnidadesMedicas.GetDataBy1(int.Parse((cBoxPersonaRefiere2.SelectedItem as DataRowView)["CodigoUnidadMedica"].ToString()));
                if (DTUnidadesMedicas.Count > 0)
                {
                    txtCentroMedicoRefiere.Text = DTUnidadesMedicas[0].NombreUnidadMedica;                    
                }

                DSTrabajo_Social.OcupacionesRow DROcupacion = DTOcupaciones.FindByCodigoOcupacion(
                    DTPersonasReferenciadas.FindByCodigoTrabajadorSocial(
                    int.Parse((cBoxPersonaRefiere2.SelectedItem as DataRowView)["CodigoTrabajadorSocial"].ToString())).CodigoOcupacion);
                if (DROcupacion != null)
                {

                    txtOcupacionContra.Text = DROcupacion.NombreOcupacion;
                }
                else
                {
                    DTOcupaciones = TAOcupaciones.GetData();
                    txtOcupacionContra.Text = DTOcupaciones.FindByCodigoOcupacion(
                        DTPersonasReferenciadas.FindByCodigoTrabajadorSocial(
                        int.Parse((cBoxPersonaRefiere2.SelectedItem as DataRowView)["CodigoTrabajadorSocial"].ToString())).CodigoOcupacion).NombreOcupacion;
                }



                //txtOcupacionContra.Text = DTOcupaciones.FindByCodigoOcupacion(
                //    DTPersonasReferenciadas.FindByCodigoTrabajadorSocial(
                //    int.Parse((cBoxPersonaRefiere2.SelectedItem as DataRowView)["CodigoTrabajadorSocial"].ToString())).CodigoOcupacion).NombreOcupacion;
            }
        }

        private void btnAgregarServicio2_Click(object sender, EventArgs e)
        {
            FAñadirServicioSolicitado formServicioEspecialidad = new FAñadirServicioSolicitado();
            formServicioEspecialidad.configurarFormularioIA(null);
            formServicioEspecialidad.Visible = false;
            if (formServicioEspecialidad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int CodigoEspecialidad = formServicioEspecialidad.CodigoEspecialidad;
                DataTable DTEspecialidadAux = TAEspeciliadades.GetDataBy1(CodigoEspecialidad);
                if (CodigoEspecialidad > 0 && DTEspecialidadAux.Rows.Count > 0 && DTServiciosEspecialidades.FindByCodigoEspecialidad(CodigoEspecialidad) == null)
                {

                    DTServiciosEspecialidades2.Rows.Add(DTEspecialidadAux.Rows[0].ItemArray);
                    DTServiciosEspecialidades2.DefaultView.Sort = "NombreEspecialidad ASC";
                    cBoxServicio.SelectedValue = CodigoEspecialidad;

                    DTServiciosEspecialidades.Rows.Add(DTEspecialidadAux.Rows[0].ItemArray);
                    DTServiciosEspecialidades.DefaultView.Sort = "NombreEspecialidad ASC";
                    cBoxEspecialidad.SelectedIndex = -1;
                }
            }
        }

        private void cBoxTrabajdoraSocialContra2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxTrabajdoraSocialContra2.SelectedIndex >= 0)
            {
                //DTUnidadesMedicas = TAUnidadesMedicas.GetDataBy1(int.Parse(DTTrabajadoresSociales[cBoxTrabajadorSocial.SelectedIndex].CodigoUnidadMedica));
                //DTUnidadesMedicas = TAUnidadesMedicas.GetDataBy1(DTTRabajadorasSociales[cBoxTrabajdoraSocialContra2.SelectedIndex].CodigoUnidadMedica);
                DTUnidadesMedicas = TAUnidadesMedicas.GetDataBy1(int.Parse((cBoxTrabajdoraSocialContra2.SelectedItem as DataRowView)["CodigoUnidadMedica"].ToString()));
                if (DTUnidadesMedicas.Count > 0)
                {
                    txtUnidadContrareferencia.Text = DTUnidadesMedicas[0].NombreUnidadMedica;
                }
            }
        }

        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            if (validarControles2())
            {
                try
                {
                    if (TipoOperacion == "I")
                    {
                        
                        TAReferencias.Insert(NumeroPacienteActual, dateFechaRef2.Value, "Ninguno", null,
                            int.Parse(cBoxPersonaRefiere2.SelectedValue.ToString()),checkInformacionContraReferencia.Checked ? int.Parse(cBoxTrabajdoraSocialContra2.SelectedValue.ToString()) : (int?) null,
                            "R", int.Parse(cBoxServicio.SelectedValue.ToString()), 
                            checkInformacionContraReferencia.Checked ?dateContraReferencia.Value : (DateTime?) null,
                            txtObservacionesContra2.Text, "");
                        if(checkInformacionContraReferencia.Checked)
                            TAContrarreferencias.Insert(NumeroPacienteActual, int.Parse(txtNumeroReferencia2.Text), dateContraReferencia.Value,
                                " ", txtObservacionesContra2.Text);
                    }
                    else
                    {
                        
                        TAReferencias.ActualizarReferencia(int.Parse(txtNumeroReferencia2.Text), NumeroPacienteActual, dateFechaRef2.Value, "Ninguno", null,
                            int.Parse(cBoxPersonaRefiere2.SelectedValue.ToString()), 
                            cBoxTrabajdoraSocialContra2.SelectedIndex >= 0 ?
                            int.Parse(cBoxTrabajdoraSocialContra2.SelectedValue.ToString()) : (int?)null,
                            "R", int.Parse(cBoxServicio.SelectedValue.ToString()),
                            checkInformacionContraReferencia.Checked ? dateContraReferencia.Value : (DateTime?)null,
                            txtObservacionesContra2.Text, "");

                        if (checkInformacionContraReferencia.Checked)
                        {
                            if (!String.IsNullOrEmpty(txtNumeroContraReferencia2.Text))
                            {
                                TAContrarreferencias.ActualizarContrarreferencia(NumeroPacienteActual, int.Parse(txtNumeroReferencia2.Text),
                                    int.Parse(txtNumeroContraReferencia2.Text), dateContraReferencia.Value,
                                    " ", txtObservacionesContra2.Text);
                            }
                            //else
                            //{
                            //    TAContrarreferencias.Insert(NumeroPacienteActual, int.Parse(txtNumeroReferencia2.Text), dateContraReferencia.Value,
                            //        " ", txtObservacionesContra2.Text);
                            //}
                        }
                    }
                    habilitarTabReferenciaEnviada(true);
                    habilitarControles2(false);
                    habilitarBotones2(true, false, true, true, true, false, true);
                    TipoOperacion = "";
                    MessageBox.Show(this, "Se registró correctamente el Registro Actual", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrió la siguiente excepción " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnModificar2_Click(object sender, EventArgs e)
        {
            habilitarTabReferenciaEnviada(false);
            TipoOperacion = "E";
            habilitarControles2(true);
            habilitarBotones2(false, true, false, false, false, true, false);
            checkInformacionContraReferencia.Checked = false;
            checkInformacionContraReferencia_CheckedChanged(checkInformacionContraReferencia, e);
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            FBuscarPacientesOperaciones formBuscarPaciente = new FBuscarPacientesOperaciones("F");
            formBuscarPaciente.FiltroAdicional = "R";
            formBuscarPaciente.ShowDialog();
            if (formBuscarPaciente.NumeroPaciente > 0)
            {
                NumeroPacienteActual = formBuscarPaciente.NumeroPaciente;
                cargarDatosPaciente2(NumeroPacienteActual);

                //TxtNumeroReferencia.Text = formBuscarPaciente.NumeroOperacion.ToString();
                ////cBoxEstadoReferencia.SelectedValue = formBuscarPaciente.DRPacientes["EstadoReferencia"].ToString();
                //cBoxTrabajadorSocial.SelectedValue = formBuscarPaciente.DRPacientes["CodigoTrabajadorSocial"].ToString();
                //cBoxMedicoResponsable.SelectedValue = formBuscarPaciente.DRPacientes["CodigoMedicoResponsable"].ToString();
                //cBoxTrabSocialDelPsiquitrico.SelectedValue = formBuscarPaciente.DRPacientes["CodigoUsuario"].ToString();
                //cBoxTipoReferencia.SelectedValue = formBuscarPaciente.DRPacientes["CodigoUsuario"].ToString();
                //cBoxEspecialidad.SelectedValue = formBuscarPaciente.DRPacientes["CodigoEspecialidad"].ToString();
                //cBoxTipoReferencia.SelectedValue = formBuscarPaciente.DRPacientes["CodigoTipoReferencia"].ToString();
                ////TxtNroHijosReferencia.Text = formBuscarPaciente.DRPacientes["NumeroHijos"].ToString();
                //TxtNroHijosReferencia.Text = TAFuncionesSistema.ObtenerNumeroFamiliaresParentescoAsociadosPaciente(NumeroPacienteActual, 4).Value.ToString();
                //TxtDiagPsiquiatricoReferencia.Text = formBuscarPaciente.DRPacientes["DiagnosticoPsiquiatrico"].ToString();
                //rTextBoxObservacionesReferencia.Text = formBuscarPaciente.DRPacientes["Observaciones"].ToString();
                //txtObservacionesContra.Text = formBuscarPaciente.DRPacientes["ObservacionesContra"].ToString();
                //if (!String.IsNullOrEmpty(formBuscarPaciente.DRPacientes["FechaContraReferencia"].ToString()))
                //    dateFechaObservacion.Value = DateTime.Parse(formBuscarPaciente.DRPacientes["FechaContraReferencia"].ToString());
                txtNumeroReferencia2.Text = formBuscarPaciente.NumeroOperacion.ToString();
                cBoxPersonaRefiere2.SelectedValue = formBuscarPaciente.DRPacientes["CodigoTrabajadorSocial"];
                cBoxServicio.SelectedValue = formBuscarPaciente.DRPacientes["CodigoEspecialidad"];
                cBoxTrabajdoraSocialContra2.SelectedValue = formBuscarPaciente.DRPacientes["CodigoUsuario"];
                dateFechaRef2.Value = DateTime.Parse(formBuscarPaciente.DRPacientes["FechaReferencia"].ToString());
                txtNumeroContraReferencia2.Text = formBuscarPaciente.DRPacientes["NumeroContrarreferencia"].ToString();

                DateTime FechaContraReferencia;
                if (DateTime.TryParse(formBuscarPaciente.DRPacientes["FechaContrarreferencia"].ToString(), out FechaContraReferencia))
                {
                    dateContraReferencia.Value = FechaContraReferencia;
                }
                else
                    dateContraReferencia.Value = DateTime.Now;


                txtObservacionesContra2.Text = formBuscarPaciente.DRPacientes["ObservacionesCR"].ToString();

                habilitarBotones2(true, false, true, true, true, true, true);

            }
            else
            {
                limpiarControles2();
                habilitarBotones2(true, false, false, true, false, false, false);
            }

            formBuscarPaciente.Dispose();
        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            TipoOperacion = "";
            limpiarControles2();
            habilitarControles2(false);
            habilitarBotones2(true, false, false, true, false, false, false);
            habilitarTabReferenciaEnviada(true);   
        }

        private void btnEliminar2_Click(object sender, EventArgs e)
        {
            int NumReferencia = -1;
            if (MessageBox.Show(this, "¿Se encuentra seguro de eliminar la Referencia Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes
                && int.TryParse(txtNumeroReferencia2.Text, out NumReferencia))
            {
                TAReferencias.Delete(NumReferencia, NumeroPacienteActual);
                limpiarControles2();
                habilitarBotones2(true, false, false, true, false, false, false);
            }
        }

        private void checkInformacionContraReferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TipoOperacion))
            {
                dateContraReferencia.Enabled = cBoxTrabajdoraSocialContra2.Enabled = checkInformacionContraReferencia.Checked;
                if (checkInformacionContraReferencia.Checked)
                {
                    //int? NumeroContraReferencia = -1;
                    //NumeroContraReferencia = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(NumeroPacienteActual, "C").Value;
                    //txtNumeroContraReferencia2.Text = (NumeroContraReferencia).ToString();
                    txtNumeroContraReferencia2.Text = txtNumeroReferencia2.Text;
                }
                else
                {
                    txtNumeroContraReferencia2.Clear();
                }
            }
        }

        private void btnReporte1_Click(object sender, EventArgs e)
        {
            FReporteFormulariosIndividuales formReporte = new FReporteFormulariosIndividuales();
            ListarReferenciaReporteTableAdapter TAListarDatosPacienteReporte = new ListarReferenciaReporteTableAdapter();
            formReporte.ListarReferenciaReporte(TAListarDatosPacienteReporte.GetData(int.Parse(TxtNumeroReferencia.Text), NumeroPacienteActual), "E");
            formReporte.ShowDialog();
            formReporte.Dispose();
        }

        private void btnReporte2_Click(object sender, EventArgs e)
        {
            FReporteFormulariosIndividuales formReporte = new FReporteFormulariosIndividuales();
            ListarReferenciaReporteTableAdapter TAListarDatosPacienteReporte = new ListarReferenciaReporteTableAdapter();
            formReporte.ListarReferenciaReporte(TAListarDatosPacienteReporte.GetData(int.Parse(txtNumeroReferencia2.Text), NumeroPacienteActual), "R");
            formReporte.ShowDialog();
            formReporte.Dispose();
        }


    }
}
