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
    public partial class FFichaSocial : Form
    {

        PacientesTableAdapter TAPacientes;
        FamiliaresTableAdapter TAFamiliares;
        ResponsablesTableAdapter TAResponsables;
        PersonasEncargadasTableAdapter TAPersonasEncargadas;
        ViviendasTableAdapter TAViviendas;
        DireccionesTableAdapter TADirecciones;
        DatosAdministrativosTableAdapter TADatosAdministrativos;
        PaisesTableAdapter TAPaises;
        DepartamentosTableAdapter TADepartamentos;
        ProvinciasTableAdapter TAProvincias;
        LocalidadesTableAdapter TALocalidades;
        ParentescosTableAdapter TAParentesco;
        QTAFuncionesSistema TAFuncionesSistema;
        DocumentosTableAdapter TAPacientesDocumentos;
        CategoriasTableAdapter TACategorias;
        ValoracionSocioeconomicaTableAdapter TAValoracionSocioEconomica;
        ServiciosTableAdapter TAServicios;
        PagoServicios2TableAdapter TAPagosServicios;
        ListarPagosServiciosDetalleReporteTableAdapter TAPagosServiciosDetalle;

        DSTrabajo_Social.PacientesDataTable DTPacientes;
        DSTrabajo_Social.FamiliaresDataTable DTPacientesFamiliares;
        DSTrabajo_Social.FamiliaresDataTable DTPacientesFamiliaresTemporal;
        DSTrabajo_Social.ResponsablesDataTable DTPacientesResponsables;
        DSTrabajo_Social.ResponsablesDataTable DTPacientesResponsablesTemporal;
        DSTrabajo_Social.PersonasEncargadasDataTable DTPersonasEncargadas;
        DSTrabajo_Social.DatosAdministrativosDataTable DTPacientesDatosAdministrativos;
        DSTrabajo_Social.PaisesDataTable DTPaisesResponsable;
        DSTrabajo_Social.DepartamentosDataTable DTDepartamentosResponsable;
        DSTrabajo_Social.ProvinciasDataTable DTProvinciasResponsable;
        DSTrabajo_Social.LocalidadesDataTable DTLocalidadesResponsable;
        DSTrabajo_Social.PaisesDataTable DTPaisesNacimiento;
        DSTrabajo_Social.DepartamentosDataTable DTDepartamentosNacimiento;
        DSTrabajo_Social.ProvinciasDataTable DTProvinciasNacimiento;
        DSTrabajo_Social.LocalidadesDataTable DTLocalidadesNacimiento;
        DSTrabajo_Social.PaisesDataTable DTPaisesResidencia;
        DSTrabajo_Social.DepartamentosDataTable DTDepartamentosResidencia;
        DSTrabajo_Social.ProvinciasDataTable DTProvinciasResidencia;
        DSTrabajo_Social.LocalidadesDataTable DTLocalidadesResidencia;
        DSTrabajo_Social.DireccionesDataTable DTPacientesDirecciones;
        DSTrabajo_Social.ParentescosDataTable DTParentescoFamiliar;
        DSTrabajo_Social.ParentescosDataTable DTParentescoResponsable;
        DSTrabajo_Social.ViviendasDataTable DTPacientesVivienda;
        DSTrabajo_Social.DocumentosDataTable DTPacientesDocumentos;
        DSTrabajo_Social.CategoriasDataTable DTCategorias;
        DSTrabajo_Social.ServiciosDataTable DTServicios;

        private String TipoOperacionGeneral = "";
        private String TipoOperacionResponsables = "";
        private String TipoOperacionFamiliares = "";
        private ErrorProvider eProviderPacientes;
        private int? NumeroPacienteActual = -1;
        private int CodigoPagoServicio = 0;
        private int CodigoUsuario = 0;

        public FFichaSocial(int CodigoUsuario)
        {
            InitializeComponent();

            this.CodigoUsuario = CodigoUsuario;
            eProviderPacientes = new ErrorProvider();

            TAPacientes = new PacientesTableAdapter();
            TAFamiliares = new FamiliaresTableAdapter();
            TAResponsables = new ResponsablesTableAdapter();
            TAPersonasEncargadas = new PersonasEncargadasTableAdapter();
            TAViviendas = new ViviendasTableAdapter();
            TADatosAdministrativos = new DatosAdministrativosTableAdapter();
            TAParentesco = new ParentescosTableAdapter();
            TADirecciones = new DireccionesTableAdapter();
            TAFuncionesSistema = new QTAFuncionesSistema();
            TAPaises = new PaisesTableAdapter();
            TADepartamentos = new DepartamentosTableAdapter();
            TAProvincias = new ProvinciasTableAdapter();
            TALocalidades = new LocalidadesTableAdapter();
            TAPacientesDocumentos = new DocumentosTableAdapter();
            TAValoracionSocioEconomica = new ValoracionSocioeconomicaTableAdapter();
            TAPagosServicios = new PagoServicios2TableAdapter();
            TACategorias = new CategoriasTableAdapter();
            TAServicios = new ServiciosTableAdapter();
            TAPagosServiciosDetalle = new ListarPagosServiciosDetalleReporteTableAdapter();

            DTPacientes = new DSTrabajo_Social.PacientesDataTable();
            DTPacientesFamiliares = new DSTrabajo_Social.FamiliaresDataTable();
            DTPacientesFamiliaresTemporal = new DSTrabajo_Social.FamiliaresDataTable();
            DTPacientesResponsables = new DSTrabajo_Social.ResponsablesDataTable();
            DTPacientesResponsablesTemporal = new DSTrabajo_Social.ResponsablesDataTable();
            DTPersonasEncargadas = new DSTrabajo_Social.PersonasEncargadasDataTable();
            DTPacientesDatosAdministrativos = new DSTrabajo_Social.DatosAdministrativosDataTable();
            DTPaisesResponsable = new DSTrabajo_Social.PaisesDataTable();
            DTDepartamentosResponsable = new DSTrabajo_Social.DepartamentosDataTable();
            DTProvinciasResponsable = new DSTrabajo_Social.ProvinciasDataTable();
            DTLocalidadesResponsable = new DSTrabajo_Social.LocalidadesDataTable();
            DTPacientesDirecciones = new DSTrabajo_Social.DireccionesDataTable();
            DTParentescoFamiliar = new DSTrabajo_Social.ParentescosDataTable();
            DTParentescoResponsable = new DSTrabajo_Social.ParentescosDataTable();
            DTPacientesVivienda = new DSTrabajo_Social.ViviendasDataTable();
            DTPacientesDocumentos = new DSTrabajo_Social.DocumentosDataTable();

            
            DTCategorias = TACategorias.GetData();
            DGCCodigoCategoria.DataSource = DTCategorias.Copy();
            DGCCodigoCategoria.DisplayMember = "NombreCategoria";
            DGCCodigoCategoria.ValueMember = "CodigoCategoria";
            DGCCodigoCategoria.DataPropertyName = "CodigoCategoria";

            DTServicios = TAServicios.GetData();
            DGCNombreServicio.DataSource = DTServicios;
            DGCNombreServicio.DisplayMember = "NombreServicio";
            DGCNombreServicio.ValueMember = "CodigoServicio";
            DGCNombreServicio.DataPropertyName = "CodigoServicio";

            DTParentescoFamiliar = TAParentesco.GetData();
            cBoxParentescoFamiliar.DataSource = DTParentescoFamiliar;
            cBoxParentescoFamiliar.DisplayMember = "NombreParentesco";
            cBoxParentescoFamiliar.ValueMember = "CodigoParentesco";

            DTParentescoResponsable = (DSTrabajo_Social.ParentescosDataTable)DTParentescoFamiliar.Copy();
            cBoxParentescoResponsable.DataSource = DTParentescoFamiliar;
            cBoxParentescoResponsable.DisplayMember = "NombreParentesco";
            cBoxParentescoResponsable.ValueMember = "CodigoParentesco";

            cBoxTipoResponsable.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaTipoResponsable();
            cBoxTipoResponsable.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxTipoResponsable.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxTipoResponsable.SelectedIndex = -1;

            cargarProcedenciaNacimiento();
            cargarProcedenciaResidencia();
            cargarProcedenciaResponsable();

            cBoxSexo.Items.Clear();
            cBoxSexo.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaSexo();
            cBoxSexo.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxSexo.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxSexo.SelectedIndex = -1;

            cBoxEstadocivil.Items.Clear();
            cBoxEstadocivil.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaEstadoCivil();
            cBoxEstadocivil.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxEstadocivil.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxEstadocivil.SelectedIndex = -1;

            cBoxEstadoCivilFamiliar.Items.Clear();
            cBoxEstadoCivilFamiliar.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaEstadoCivil();
            cBoxEstadoCivilFamiliar.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxEstadoCivilFamiliar.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxEstadoCivilFamiliar.SelectedIndex = -1;

            cBoxGradoInstruccion.Items.Clear();
            cBoxGradoInstruccion.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaGradoInstruccion();
            cBoxGradoInstruccion.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxGradoInstruccion.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxGradoInstruccion.SelectedIndex = -1;

            cBoxGradoInstrucciónFamiliar.Items.Clear();
            cBoxGradoInstrucciónFamiliar.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaGradoInstruccion();
            cBoxGradoInstrucciónFamiliar.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxGradoInstrucciónFamiliar.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxGradoInstrucciónFamiliar.SelectedIndex = -1;

            cBoxRelacionFamiliarPaciente.Items.Clear();
            cBoxRelacionFamiliarPaciente.DataSource = Utilidades.ObjetoCodigoDescripcion.generarRelacionesFamiliares();
            cBoxRelacionFamiliarPaciente.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxRelacionFamiliarPaciente.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxRelacionFamiliarPaciente.SelectedIndex = -1;

            cBoxPredisposicionTratPaciente.Items.Clear();
            cBoxPredisposicionTratPaciente.DataSource = Utilidades.ObjetoCodigoDescripcion.generarRelacionesFamiliares();
            cBoxPredisposicionTratPaciente.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxPredisposicionTratPaciente.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxPredisposicionTratPaciente.SelectedIndex = -1;

            cBoxCondicionesVivienda.Items.Clear();
            cBoxCondicionesVivienda.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaCondicionesVivienda();
            cBoxCondicionesVivienda.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxCondicionesVivienda.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxCondicionesVivienda.SelectedIndex = -1;

            cBoxLugarVivienda.Items.Clear();
            cBoxLugarVivienda.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaLugarVivienda();
            cBoxLugarVivienda.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxLugarVivienda.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxLugarVivienda.SelectedIndex = -1;

            cBoxTipoVivienda.Items.Clear();
            cBoxTipoVivienda.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaTipoVivienda();
            cBoxTipoVivienda.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxTipoVivienda.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxTipoVivienda.SelectedIndex = -1;

            cBoxReligion.Items.Clear();
            cBoxReligion.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaReligion();
            cBoxReligion.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxReligion.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxReligion.SelectedIndex = -1;

            cBoxIdioma.Items.Clear();
            cBoxIdioma.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaIdioma();
            cBoxIdioma.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxIdioma.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxIdioma.SelectedIndex = -1;

            DTPacientesFamiliaresTemporal.NumeroFamiliarColumn.AutoIncrement = true;
            DTPacientesResponsablesTemporal.CodigoResponsableColumn.AutoIncrement = true;

            //TxtCarnetIdentidad.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress);
            TxtEdad.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress);
            //TxtNumeroHabitaciones.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress);
            TxtEdadFamiliar.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress);
            TxtIngresoEconomicoFamiliar.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress);
            TxtTelefono.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress);
            txtTeléfonoResponsable.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress);
            txtCelular.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress);
            txtIngresoEventual.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress);
            txtIngresoMensual.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress);
            TxtNumeroFolio.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress);
            dtGVServicios.AutoGenerateColumns = false;
            cargarDatosPaciente(-1);
              
        }

        public bool validarDatosPaciente()
        {
            eProviderPacientes.Clear();
            DateTime FechaHoraServidor = TAFuncionesSistema.ObtenerFechaHoraServidor().Value;  
            if(dateFechaNacimiento.Value > FechaHoraServidor)
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(dateFechaNacimiento, "La Fecha de Nacimiento del Paciente no puede superar a la Fecha Actual");
                dateFechaNacimiento.Focus();
                return false;
            }
            //if (String.IsNullOrEmpty(TxtNumeroFolio.Text.Trim()))
            //{
            //    tabControlPacientes.SelectedTab = tabPageDatosPersonales;
            //    eProviderPacientes.SetError(TxtNumeroFolio, "Aún no ha ingresado el Numero de Folio del Paciente");
            //    TxtNumeroFolio.Focus();
            //    TxtNumeroFolio.SelectAll();
            //    return false;
            //}

            if (String.IsNullOrEmpty(TxtNumeroHClinico.Text.Trim()))
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(TxtNumeroHClinico, "Aún no ha Ingresado el Número de Historial Clínico del Paciente");
                TxtNumeroHClinico.Focus();
                TxtNumeroHClinico.SelectAll();
                return false;
            }

            if (String.IsNullOrEmpty(TxtRemitidoPor.Text.Trim()))
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(TxtRemitidoPor, "Aún no ha Ingresado el Campo del Remitente del Paciente");
                TxtRemitidoPor.Focus();
                TxtRemitidoPor.SelectAll();
                return false;
            }


            if (String.IsNullOrEmpty(TxtNombrePaciente.Text.Trim()))
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(TxtNombrePaciente, "Aún no ha Ingresado el Nombre del Paciente");
                TxtNombrePaciente.Focus();
                TxtNombrePaciente.SelectAll();
                return false;
            }
            if (String.IsNullOrEmpty(TxtApellidoPaterno.Text.Trim()))
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(TxtApellidoPaterno, "Aún no ha Ingresado el Apellido Paterno del Paciente");
                TxtApellidoPaterno.Focus();
                TxtApellidoPaterno.SelectAll();
                return false;
            }
            if (String.IsNullOrEmpty(TxtApellidoMaterno.Text.Trim()) &&
                MessageBox.Show(this,"¿Se Encuentra seguro de dejar en blanco el Apellido Materno del Paciente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(TxtApellidoMaterno, "Aún no ha Ingresado el Apellido Materno del Paciente");
                TxtApellidoMaterno.Focus();
                TxtApellidoMaterno.SelectAll();
                return false;
            }

            if (cBoxSexo.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(cBoxSexo, "Aún no ha seleccionado el sexo del Paciente");
                cBoxSexo.Focus();
                return false;
            }

            if (cBoxPaisNacimiento.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(cBoxPaisNacimiento, "Aún no ha seleccionado el País donde Nació el Paciente");
                cBoxPaisNacimiento.Focus();
                return false;
            }
            if (cBoxDepartamentoNacimiento.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(cBoxDepartamentoNacimiento, "Aún no ha seleccionado el Departamento donde Nació el Paciente");
                cBoxPaisNacimiento.Focus();
                return false;
            }



            if (String.IsNullOrEmpty(TxtZonaBarrio.Text.Trim()))
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(TxtZonaBarrio, "Aún no ha ingresado la Zona/Barrio del Paciente");
                TxtZonaBarrio.Focus();
                TxtZonaBarrio.SelectAll();
                return false;
            }

            //if (String.IsNullOrEmpty(TxtCalleAvenida.Text.Trim()))
            //{
            //    tabControlPacientes.SelectedTab = tabPageDatosPersonales;
            //    eProviderPacientes.SetError(TxtCalleAvenida, "Aún no ha ingresado la Calle/Avenida del Paciente");
            //    TxtCalleAvenida.Focus();
            //    TxtCalleAvenida.SelectAll();
            //    return false;
            //}

            //int numeroCalle = -1;
            //if (!String.IsNullOrEmpty(TxtNumeroDireccion.Text.Trim()) && !int.TryParse(TxtNumeroDireccion.Text, out numeroCalle))
            //{
            //    tabControlPacientes.SelectedTab = tabPageDatosPersonales;
            //    eProviderPacientes.SetError(TxtNumeroDireccion, "El Número de la Calle se encuentra mal escrita");
            //    TxtNumeroDireccion.Focus();
            //    TxtNumeroDireccion.SelectAll();
            //    return false;
            //}

            int numeroCalle = -1;
            if (!String.IsNullOrEmpty(txtIngresoMensual.Text.Trim()) && !int.TryParse(txtIngresoMensual.Text, out numeroCalle))
            {
                tabControlPacientes.SelectedTab = tabPageDatosAdministrativos;
                eProviderPacientes.SetError(txtIngresoMensual, "El Ingreso Mensual se se encuentra mal escrita");
                txtIngresoMensual.Focus();
                txtIngresoMensual.SelectAll();
                return false;
            }

            if (!String.IsNullOrEmpty(txtIngresoEventual.Text.Trim()) && !int.TryParse(txtIngresoEventual.Text, out numeroCalle))
            {
                tabControlPacientes.SelectedTab = tabPageDatosAdministrativos;
                eProviderPacientes.SetError(txtIngresoEventual, "El Ingreso Mensual se se encuentra mal escrita");
                txtIngresoMensual.Focus();
                txtIngresoMensual.SelectAll();
                return false;
            }

            if (cBoxGradoInstruccion.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(cBoxGradoInstruccion, "Aún no ha Seleccionado el Grado de Instrucción del Paciente");
                cBoxGradoInstruccion.Focus();
                return false;
            }

            if (cBoxEstadocivil.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(cBoxEstadocivil, "Aún no ha Seleccionado el Estado Civil del Paciente");
                cBoxEstadocivil.Focus();
                return false;
            }
            if (cBoxReligion.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(cBoxReligion, "Aún no ha Seleccionado la Religión del Paciente");
                cBoxReligion.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(TxtOcupacion.Text.Trim()))
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(TxtOcupacion, "Aún no ha Ingresado la Ocupación del Paciente");
                TxtOcupacion.Focus();
                TxtOcupacion.SelectAll();
                return false;
            }
            if (cBoxIdioma.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(cBoxIdioma, "Aún no ha Ingresado el Idioma del Paciente");
                cBoxIdioma.Focus();                
                return false;
            }

            if (!rbtnSiDependiente.Checked && !rbtnNoDependiente.Checked)
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;                
                eProviderPacientes.SetError(rbtnSiDependiente, "Aún no ha Seleccionado el Estado de Dependencia del Paciente");
                rbtnSiDependiente.Focus();                
                return false;
            }

            if (rbtnSiDependiente.Checked && String.IsNullOrEmpty(TxtTipoDiscapacidad.Text.Trim()))
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(TxtTipoDiscapacidad, "Aún no ha Ingresado el Tipo de Discapacidad del Paciente");
                TxtTipoDiscapacidad.Focus();
                TxtTipoDiscapacidad.SelectAll();
                return false;
            }

            if (TxtTipoDiscapacidad.Text.Length > 50)
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(TxtTipoDiscapacidad, "El Tipo de discapacidad debe ser un campo resumido menor a 50 caracteres");
                TxtTipoDiscapacidad.Focus();
                TxtTipoDiscapacidad.SelectAll();
                return false;
            }

            if (dtGVFamiliares.Rows.Count == 0 && MessageBox.Show(this,"¿Se Encuentra Seguro de no Ingresar ningún Familiar para este Paciente?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                tabControlPacientes.SelectedTab = tabPageGrupoFamiliar;
                eProviderPacientes.SetError(TxtNumeroFamilar, "No ha Ingresado ningún Familiar para el Paciente");
                return false;
            }

            if (dtGVResponsables.Rows.Count == 0 && MessageBox.Show(this, "¿Se Encuentra Seguro de no Ingresar ningún Responsable para este Paciente?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                tabControlPacientes.SelectedTab = tabPageDatosResponsable;
                eProviderPacientes.SetError(txtCodigoResponsable, "No ha Ingresado ningún Responsable para el Paciente");
                return false;
            }

            if (cBoxLugarVivienda.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageTipoVivienda;
                eProviderPacientes.SetError(cBoxLugarVivienda, "Debe seleccionar la Vivienda del Paciente");
                cBoxLugarVivienda.Focus();
                return false;
            }

            if (cBoxTipoVivienda.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageTipoVivienda;
                eProviderPacientes.SetError(cBoxTipoVivienda, "Aún no ha Seleccionado el Tipo de Vivienda del Paciente");
                cBoxTipoVivienda.Focus();
                return false;
            }

            //if (String.IsNullOrEmpty(TxtNumeroHabitaciones.Text.Trim()))
            //{
            //    tabControlPacientes.SelectedTab = tabPageTipoVivienda;
            //    eProviderPacientes.SetError(TxtNumeroHabitaciones, "Aún no ha Ingresado el número de Habitaciones de Lugar de Vivienda");
            //    TxtNumeroHabitaciones.Focus();
            //    TxtNumeroHabitaciones.SelectAll();
            //    return false;
            //}

			//int numeroCalle = -1;
            //if (!String.IsNullOrEmpty(TxtNumeroHabitaciones.Text.Trim()) && !int.TryParse(TxtNumeroHabitaciones.Text, out numeroCalle))
            //{
            //    tabControlPacientes.SelectedTab = tabPageTipoVivienda;
            //    eProviderPacientes.SetError(TxtNumeroHabitaciones, "El Número de Habitaciones se encuentra mal escrita");
            //    TxtNumeroHabitaciones.Focus();
            //    TxtNumeroHabitaciones.SelectAll();
            //    return false;
            //}

            
            //if (cBoxRelacionFamiliarPaciente.SelectedIndex < 0)
            //{
            //    tabControlPacientes.SelectedTab = tabPageTipoVivienda;
            //    eProviderPacientes.SetError(cBoxRelacionFamiliarPaciente, "Aún no ha seleccionado la Relación Familiar del Paciente");
            //    cBoxRelacionFamiliarPaciente.Focus();
            //    return false;
            //}

            if (cBoxPredisposicionTratPaciente.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageTipoVivienda;
                eProviderPacientes.SetError(cBoxPredisposicionTratPaciente, "Aún no ha seleccionado la Predisposición de Tratamiento del Paciente");
                cBoxPredisposicionTratPaciente.Focus();
                return false;
            }

            if (dtGVServicios.RowCount == 0)
            {
                tabControlPacientes.SelectedTab = tabPageDatosAdministrativos;
                eProviderPacientes.SetError(btnRegistrarServicios, "Aun no ha registrado ningún servicio");
                btnRegistrarServicios.Focus();
                return false;
            }


            #region Validacion para Datos de Nacimiento
            if (cBoxDepartamentoNacimiento.SelectedIndex >= 0 && cBoxPaisNacimiento.SelectedIndex == -1)
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(cBoxDepartamentoNacimiento, "No puede registrar los Datos del Departamento de Nacimiento sin haber seleccionado su correspondiente"
                    + "Pais");
                cBoxDepartamentoNacimiento.Focus();
                return false;
            }

            if (cBoxProvinciaNacimiento.SelectedIndex >= 0 &&
                (cBoxDepartamentoNacimiento.SelectedIndex == -1
                || cBoxPaisNacimiento.SelectedIndex == -1))
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(cBoxProvinciaNacimiento, "No puede registrar los Datos de la provincia de Nacimiento sin haber seleccionado su correspondiente"
                    + " Departamento y Pais");
                cBoxProvinciaNacimiento.Focus();
                return false;
            }

            if (cBoxLocalidaNacimiento.SelectedIndex >= 0 &&
                (cBoxProvinciaNacimiento.SelectedIndex == -1 || cBoxDepartamentoNacimiento.SelectedIndex == -1
                || cBoxPaisNacimiento.SelectedIndex == -1))
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(cBoxLocalidaNacimiento, "No puede registrar los Datos de la localidad de Nacimiento sin haber seleccionado su correspondiente"
                    + " Provincia, Departamento y Pais");
                cBoxLocalidaNacimiento.Focus();
                return false;
            }
            
            #endregion


            #region Validacion para Datos de Residencia
            if (cBoxDepartamentoResidencia.SelectedIndex >= 0 && cBoxPaisResidencia.SelectedIndex == -1)
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(cBoxDepartamentoResidencia, "No puede registrar los Datos del Departamento de Residencia sin haber seleccionado su correspondiente"
                    + "Pais");
                cBoxDepartamentoResidencia.Focus();
                return false;
            }

            if (cBoxProvinciaResidencia.SelectedIndex >= 0 &&
                (cBoxDepartamentoResidencia.SelectedIndex == -1
                || cBoxPaisResidencia.SelectedIndex == -1))
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(cBoxProvinciaResidencia, "No puede registrar los Datos de la provincia de Residencia sin haber seleccionado su correspondiente"
                    + " Departamento y Pais");
                cBoxProvinciaResidencia.Focus();
                return false;
            }

            if (cBoxLocalidadResidencia.SelectedIndex >= 0 &&
                (cBoxProvinciaResidencia.SelectedIndex == -1 || cBoxDepartamentoResidencia.SelectedIndex == -1
                || cBoxPaisResidencia.SelectedIndex == -1))
            {
                tabControlPacientes.SelectedTab = tabPageDatosPersonales;
                eProviderPacientes.SetError(cBoxLocalidadResidencia, "No puede registrar los Datos de la localidad de Residencia sin haber seleccionado su correspondiente"
                    + " Provincia, Departamento y Pais");
                cBoxLocalidadResidencia.Focus();
                return false;
            }

            #endregion


            return true;
        }

        public bool validarDatosResponsable()
        {
            eProviderPacientes.Clear();
            if (String.IsNullOrEmpty(txtNombreResponsable.Text.Trim()))
            {
                tabControlPacientes.SelectedTab = tabPageDatosResponsable;
                eProviderPacientes.SetError(txtNombreResponsable, "Aún no ha Ingresado el Nombre del Responsable");
                txtNombreResponsable.Focus();
                txtNombreResponsable.SelectAll(); 
                return false;
            }
            if (cBoxParentescoResponsable.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageDatosResponsable;
                eProviderPacientes.SetError(cBoxParentescoResponsable, "Aún no ha Seleccionado el Parentesco del Responsable");
                cBoxParentescoResponsable.Focus();                
                return false;
            }
            if (String.IsNullOrEmpty(txtDirecciónResponsable.Text))
            {
                tabControlPacientes.SelectedTab = tabPageDatosResponsable;
                eProviderPacientes.SetError(txtDirecciónResponsable, "Aún no ha Ingresado la dirección del Responsable");
                txtDirecciónResponsable.Focus();
                txtDirecciónResponsable.SelectAll();
                return false;
            }

            if (cBoxTipoResponsable.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageDatosResponsable;
                eProviderPacientes.SetError(cBoxTipoResponsable, "Aún no ha Seleccionado el Tipo de Responsabilidad Asignada al Responsable");
                cBoxTipoResponsable.Focus();
                return false;
            }


            #region Validacion para Datos de Responsable
            if (cBoxDepartamentoResponsable.SelectedIndex >= 0 && cboxPaisResponsable.SelectedIndex == -1)
            {
                tabControlPacientes.SelectedTab = tabPageDatosResponsable;
                eProviderPacientes.SetError(cBoxDepartamentoResponsable, "No puede registrar los Datos del Departamento del Responsable sin haber seleccionado su correspondiente"
                    + "Pais");
                cBoxDepartamentoResponsable.Focus();
                return false;
            }

            if (cBoxProvinciaResponsable.SelectedIndex >= 0 &&
                (cBoxDepartamentoResponsable.SelectedIndex == -1
                || cboxPaisResponsable.SelectedIndex == -1))
            {
                tabControlPacientes.SelectedTab = tabPageDatosResponsable;
                eProviderPacientes.SetError(cBoxProvinciaResponsable, "No puede registrar los Datos de la provincia del Responsable sin haber seleccionado su correspondiente"
                    + " Departamento y Pais");
                cBoxProvinciaResponsable.Focus();
                return false;
            }

            if (cBoxLocalidadResponsable.SelectedIndex >= 0 &&
                (cBoxProvinciaResponsable.SelectedIndex == -1 || cBoxDepartamentoResponsable.SelectedIndex == -1
                || cboxPaisResponsable.SelectedIndex == -1))
            {
                tabControlPacientes.SelectedTab = tabPageDatosResponsable;
                eProviderPacientes.SetError(cBoxLocalidadResponsable, "No puede registrar los Datos de la localidad del Responsable sin haber seleccionado su correspondiente"
                    + " Provincia, Departamento y Pais");
                cBoxLocalidadResponsable.Focus();
                return false;
            }

            #endregion

            return true;
        }

        public bool validarDatosFamiliares()
        {
            eProviderPacientes.Clear();
            if (String.IsNullOrEmpty(TxtNombreFamiliar.Text))
            {
                tabControlPacientes.SelectedTab = tabPageGrupoFamiliar;
                eProviderPacientes.SetError(TxtNombreFamiliar, "Aún no ha Ingresado el Nombre del Familiar");
                TxtNombreFamiliar.Focus();
                TxtNombreFamiliar.SelectAll();
                return false;
            }
            if (String.IsNullOrEmpty(TxtEdadFamiliar.Text))
            {
                tabControlPacientes.SelectedTab = tabPageGrupoFamiliar;
                eProviderPacientes.SetError(TxtEdadFamiliar, "Aún no ha Ingresado la Edad del Familiar");
                TxtEdadFamiliar.Focus();
                TxtEdadFamiliar.SelectAll();
                return false;
            }
            int numero = -1;
            if (!int.TryParse(TxtEdadFamiliar.Text, out numero))
            {
                tabControlPacientes.SelectedTab = tabPageGrupoFamiliar;
                eProviderPacientes.SetError(TxtEdadFamiliar, "La Edad del Familiar se encuentra mal escrita");
                TxtEdadFamiliar.Focus();
                TxtEdadFamiliar.SelectAll();
                return false;
            }
            if (numero < 0 || numero > 110)
            {
                tabControlPacientes.SelectedTab = tabPageGrupoFamiliar;
                eProviderPacientes.SetError(TxtEdadFamiliar, "La Edad del Familiar supera el rango valido del Sistema [Max = 110]");
                MessageBox.Show("La Edad del Familiar supera el rango valido del Sistema [Max = 110]");
                TxtEdadFamiliar.Focus();
                TxtEdadFamiliar.SelectAll();
                return false;
            }
            if (cBoxParentescoFamiliar.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageGrupoFamiliar;
                eProviderPacientes.SetError(cBoxParentescoFamiliar, "Aún no ha seleccionado el Parentesco del Familiar");
                cBoxParentescoFamiliar.Focus();
                return false;
            }
            if (cBoxGradoInstrucciónFamiliar.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageGrupoFamiliar;
                eProviderPacientes.SetError(cBoxGradoInstrucciónFamiliar, "Aún no ha seleccionado el Grado de Instrucción del Familiar");
                cBoxGradoInstrucciónFamiliar.Focus();
                return false;
            }
            if (cBoxEstadoCivilFamiliar.SelectedIndex < 0)
            {
                tabControlPacientes.SelectedTab = tabPageGrupoFamiliar;
                eProviderPacientes.SetError(cBoxEstadoCivilFamiliar, "Aún no ha seleccionado el Estado Civil del Familiar");
                cBoxEstadoCivilFamiliar.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(TxtOcupacionFamiliar.Text) && 
                MessageBox.Show(this,"¿Se Encuentra seguro de dejar en blanco la Ocupación del Familiar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                tabControlPacientes.SelectedTab = tabPageGrupoFamiliar;
                eProviderPacientes.SetError(TxtOcupacionFamiliar, "Aún no ha Ingresado la Ocupación del Familiar");
                TxtOcupacionFamiliar.Focus();
                TxtOcupacionFamiliar.SelectAll();
                return false;
            }

            //if (String.IsNullOrEmpty(TxtIngresoEconomicoFamiliar.Text))
            //{
            //    tabControlPacientes.SelectedTab = tabPageGrupoFamiliar;
            //    eProviderPacientes.SetError(TxtIngresoEconomicoFamiliar, "Aún no ha ingresado el Monto de Ingreso Económico con el que cuenta el Familiar");
            //    TxtIngresoEconomicoFamiliar.Focus();
            //    TxtIngresoEconomicoFamiliar.SelectAll();
            //    return false;
            //}
            double monto = -1;
            if (!String.IsNullOrEmpty(TxtIngresoEconomicoFamiliar.Text)  && !double.TryParse(TxtIngresoEconomicoFamiliar.Text, out monto))
            {
                tabControlPacientes.SelectedTab = tabPageGrupoFamiliar;
                eProviderPacientes.SetError(TxtIngresoEconomicoFamiliar, "El Monto de Ingreso Económico con el que cuenta el Familiar se encuentra mal escrito");
                TxtIngresoEconomicoFamiliar.Focus();
                TxtIngresoEconomicoFamiliar.SelectAll();
                return false;
            }
            return true;
        }


        public void cargarDatosPaciente(int NumeroPaciente)
        {
            limpiarControlesPestaniaFamiliares();
            limpiarControlesPestaniaResponsable();
            bool tieneDatosCompletos = TAFuncionesSistema.TienePacienteDatosCompleto(NumeroPacienteActual).Value;
            tabControlPacientes.SelectedTab = tabPageDatosPersonales;
            DTPacientes = TAPacientes.GetDataBy11(NumeroPaciente);
            if (DTPacientes.Count > 0)
            {
                this.NumeroPacienteActual = NumeroPaciente;

                dateFechaIngreso.Value = DTPacientes[0].IsFechaIngresoNull() ? DateTime.Now : DTPacientes[0].FechaIngreso;
                TxtNumeroPaciente.Text = DTPacientes[0].NumeroPaciente.ToString();
                TxtNumeroFolio.Text = DTPacientes[0].IsNumeroFolioNull() ? String.Empty : DTPacientes[0].NumeroFolio.ToString();
                TxtNumeroHClinico.Text = DTPacientes[0].IsHClinicoNull() ? String.Empty : DTPacientes[0].HClinico.ToString();
                TxtRemitidoPor.Text = DTPacientes[0].IsNombreRemitidorNull() ? String.Empty : DTPacientes[0].NombreRemitidor;
                TxtNombrePaciente.Text = DTPacientes[0].IsNombreNull() ? String.Empty : DTPacientes[0].Nombre;
                TxtApellidoMaterno.Text = DTPacientes[0].IsApellidoMaternoNull() ? String.Empty : DTPacientes[0].ApellidoMaterno;
                TxtApellidoPaterno.Text = DTPacientes[0].IsApellidoPaternoNull() ? String.Empty : DTPacientes[0].ApellidoPaterno;
                TxtDiagnostico.Text = DTPacientes[0].IsDiagnosticoNull() ? String.Empty : DTPacientes[0].Diagnostico;
                TxtUnidad.Text = DTPacientes[0].IsUnidadNull() ? String.Empty : DTPacientes[0].Unidad.ToString();
                TxtSeccion.Text = DTPacientes[0].IsSeccionNull() ? String.Empty : DTPacientes[0].Seccion.ToString();
                TxtDenominacion.Text = DTPacientes[0].IsDenominacionNull() ? String.Empty : DTPacientes[0].Denominacion;
                dateFechaNacimiento.Value = DTPacientes[0].IsFechaNacimientoNull() ? DateTime.Now : DTPacientes[0].FechaNacimiento;
                TxtEdad.Text = "0";
                TxtCarnetIdentidad.Text = DTPacientes[0].IsCIPacienteNull() ? String.Empty : DTPacientes[0].CIPaciente;
                TxtEdad.Text = TAFuncionesSistema.ObtenerEdadPaciente(NumeroPacienteActual).Value.ToString();

                if (DTPacientes[0].IsCodigoPaisNull())
                    cBoxPaisNacimiento.SelectedIndex = -1;
                else
                    cBoxPaisNacimiento.SelectedValue = DTPacientes[0].CodigoPais;

                if (DTPacientes[0].IsCodigoDepartamentoNull())
                    cBoxDepartamentoNacimiento.SelectedIndex = -1;
                else
                    cBoxDepartamentoNacimiento.SelectedValue = DTPacientes[0].CodigoDepartamento;

                if(DTPacientes[0].IsCodigoProvinciaNull())
                    cBoxProvinciaNacimiento.SelectedIndex = -1;
                else
                    cBoxProvinciaNacimiento.SelectedValue =DTPacientes[0].CodigoProvincia;

                if( DTPacientes[0].IsCodigoLocalidadNull() )
                    cBoxLocalidaNacimiento.SelectedIndex = -1;
                else
                    cBoxLocalidaNacimiento.SelectedValue = DTPacientes[0].CodigoLocalidad;



                if (DTPacientes[0].IsCodigoPaisResidenciaNull())
                    cBoxPaisResidencia.SelectedIndex = -1;
                else
                    cBoxPaisResidencia.SelectedValue = DTPacientes[0].CodigoPaisResidencia;

                if (DTPacientes[0].IsCodigoDepartamentoResidenciaNull())
                    cBoxDepartamentoResidencia.SelectedIndex = -1;
                else
                    cBoxDepartamentoResidencia.SelectedValue = DTPacientes[0].CodigoDepartamentoResidencia;

                if (DTPacientes[0].IsCodigoProvinciaResidenciaNull())
                    cBoxProvinciaResidencia.SelectedIndex = -1;
                else
                    cBoxProvinciaResidencia.SelectedValue = DTPacientes[0].CodigoProvinciaResidencia;

                if (DTPacientes[0].IsCodigoLocalidadResidenciaNull())
                    cBoxLocalidadResidencia.SelectedIndex = -1;
                else
                    cBoxLocalidadResidencia.SelectedValue = DTPacientes[0].CodigoLocalidadResidencia;


                cBoxSexo.SelectedValue = DTPacientes[0].Sexo;
                //reviscar Geografico en Referencia

                DTPacientesDirecciones = TADirecciones.GetDataBy1(NumeroPaciente);
                if (DTPacientesDirecciones.Count > 0)
                {
                    TxtZonaBarrio.Text = DTPacientesDirecciones[0].IsZonaBarrioNull() ? string.Empty : DTPacientesDirecciones[0].ZonaBarrio;
                    //TxtNumeroDireccion.Text = DTPacientesDirecciones[0].IsNumeroNull() ? String.Empty : DTPacientesDirecciones[0].Numero.ToString();
                    TxtTelefono.Text = DTPacientesDirecciones[0].IsTelefonoNull() ? String.Empty : DTPacientesDirecciones[0].Telefono;
                    TxtCalleAvenida.Text = DTPacientesDirecciones[0].IsCalleAvenidaNull() ? String.Empty : DTPacientesDirecciones[0].CalleAvenida;
                }
                else
                {
                    TxtZonaBarrio.Text = String.Empty;
                    //TxtNumeroDireccion.Text = String.Empty;
                    TxtTelefono.Text = String.Empty;
                    TxtCalleAvenida.Text = String.Empty;
                }

                if (DTPacientes[0].IsGradoInstruccionNull())
                    cBoxGradoInstruccion.SelectedIndex = -1;
                else
                    cBoxGradoInstruccion.SelectedValue = DTPacientes[0].GradoInstruccion;
                cBoxEstadocivil.SelectedValue = DTPacientes[0].IsEstadoCivilNull() ? null : DTPacientes[0].EstadoCivil;
                if( DTPacientes[0].IsReligionNull())
                    cBoxReligion.SelectedIndex = -1;
                else
                    cBoxReligion.SelectedValue = DTPacientes[0].Religion;
                TxtOcupacion.Text = DTPacientes[0].IsOcupacionNull() ? String.Empty : DTPacientes[0].Ocupacion;
                TxtLugartrabajo.Text = DTPacientes[0].IsLugarTrabajoNull() ? String.Empty : DTPacientes[0].LugarTrabajo;
                if (DTPacientes[0].IsIdiomaNull())
                    cBoxIdioma.SelectedIndex = -1;
                else
                    cBoxIdioma.SelectedValue = DTPacientes[0].Idioma;
                TxtTipoDiscapacidad.Text = DTPacientes[0].IsTipoDiscapacidadNull() ? String.Empty : DTPacientes[0].TipoDiscapacidad;
                if (!DTPacientes[0].IsPacienteDependienteNull() && DTPacientes[0].PacienteDependiente == "S")
                    rbtnSiDependiente.Checked = true;
                else if (!DTPacientes[0].IsPacienteDependienteNull() && DTPacientes[0].PacienteDependiente == "N")
                    rbtnNoDependiente.Checked = true;
                else
                    rbtnSiDependiente.Checked = rbtnNoDependiente.Checked = false;
                rTextBoxAntecedentesPersonales.Text = DTPacientes[0].IsAntecedentesNull() ? String.Empty : DTPacientes[0].Antecedentes;

                txtIngresoMensual.Text = DTPacientes[0].IsIngresoMensualNull() ? String.Empty : DTPacientes[0].IngresoMensual.ToString();
                txtIngresoEventual.Text = DTPacientes[0].IsIngresoEventualNull() ? String.Empty : DTPacientes[0].IngresoEventual.ToString();
                checkPacienteInstitucionalizado.Checked = !DTPacientes[0].IsPacienteInstitucionalizadoNull() && DTPacientes[0].PacienteInstitucionalizado;

                //CARGAMOS LA SEGUNDA PESTAÑA (Familiares)
                DTPacientesFamiliares = TAFamiliares.GetDataByPaciente(NumeroPaciente);
                bdSourceFamiliares.DataSource = DTPacientesFamiliares;
                dtGVFamiliares.DataSource = bdSourceFamiliares;
                //habilitarBotonesPestaniaFamiliares(true, false, DTPacientesFamiliares.Count != 0, false, DTPacientesFamiliares.Count != 0);
                habilitarBotonesPestaniaFamiliares(false, false, false, false, false);

                //CARGAMOS LA TERCERA PESTAÑA (Responsables)
                DTPacientesResponsables = TAResponsables.GetDataByPaciente(NumeroPaciente, null);
                bdSourceResponsables.DataSource = DTPacientesResponsables;
                dtGVResponsables.DataSource = bdSourceResponsables;
                //habilitarBotonesPestaniaResponsable(true, false, DTPacientesResponsables.Count != 0, false, DTPacientesResponsables.Count != 0);
                habilitarBotonesPestaniaResponsable(false, false, false, false, false);

                //CARGAMOS LA QUINTA PESTAÑA (TiposVivienda)
                DTPacientesVivienda = TAViviendas.GetDataBy1(NumeroPaciente);
                if (DTPacientesVivienda.Count > 0)
                {
                    if (!DTPacientesVivienda[0].IsViviendaNull())
                    {
                        cBoxLugarVivienda.SelectedValue = DTPacientesVivienda[0].Vivienda;
                    }
                    else
                        cBoxLugarVivienda.SelectedIndex = -1;

                    if (!DTPacientesVivienda[0].IsTipoViviendaNull())
                        cBoxTipoVivienda.SelectedValue = DTPacientesVivienda[0].TipoVivienda;
                    else
                        cBoxTipoVivienda.SelectedIndex = -1;
                    //TxtNumeroHabitaciones.Text = DTPacientesVivienda[0].IsNumeroHabitacionesNull() ? null : DTPacientesVivienda[0].NumeroHabitaciones.ToString();
                    rTextBoxObservaciones.Text = DTPacientesVivienda[0].IsObservacionesNull() ? null : DTPacientesVivienda[0].Observaciones;
                    cBoxCondicionesVivienda.SelectedValue = DTPacientesVivienda[0].CondicionVivienda;
                    checkLuz.Checked = (DTPacientesVivienda[0].Luz == "S");              
                    checkTelefono.Checked = (DTPacientesVivienda[0].Telefono == "S");                     
                    checkAgua.Checked = (DTPacientesVivienda[0].Agua == "S");                        
                    checkAlcantarillado.Checked = (DTPacientesVivienda[0].Alcantarillado == "S");                        
                    checkGas.Checked = (DTPacientesVivienda[0].Gas == "S");
                        
                }
                else
                    limpiarControlesPestaniaTipoVivienda();

                if (!DTPacientes[0].IsRelacionesFamiliaresNull())
                    cBoxRelacionFamiliarPaciente.SelectedValue = DTPacientes[0].RelacionesFamiliares;
                else
                    cBoxRelacionFamiliarPaciente.SelectedIndex = -1;

                if (!DTPacientes[0].IsPredisposicionTratamientoNull())
                    cBoxPredisposicionTratPaciente.SelectedValue = DTPacientes[0].PredisposicionTratamiento;
                else
                    cBoxPredisposicionTratPaciente.SelectedIndex = -1;
                richTxtObservacionesRelacionesFam.Text = DTPacientes[0].IsObservacionRelFamiliaresNull() ? String.Empty : DTPacientes[0].ObservacionRelFamiliares;

                DTPacientesDocumentos = TAPacientesDocumentos.GetDataByPaciente(NumeroPacienteActual);
                dtGVServicios.DataSource = TAPagosServiciosDetalle.GetData(NumeroPacienteActual, 1, "I");                

                habilitarBotonesPacientes(!tieneDatosCompletos, false, true, true, tieneDatosCompletos, true, true);
            }
            else
            {
                limpiarControlesPestaniaDatosPersonales();                
                limpiarControlesPestaniaFamiliares();
                limpiarControlesPestaniaResponsable();
                limpiarControlesPestaniaTipoVivienda();

                habilitarBotonesPacientes(false, false, false, false, false, false, true);
                habilitarBotonesPestaniaFamiliares(false, false, false, false, false);
                habilitarBotonesPestaniaResponsable(false, false, false, false, false);
            }

            habilitarControlesPestaniaDatosPersonales(false);            
            habilitarControlesPestaniaFamiliares(false);
            habilitarControlesPestaniaResponsable(false);
            habilitarControlesPestaniaTipoVivienda(false);
        }

        public void cargarDatosFamiliares(int NumeroPaciente, int CodigoFamiliar)
        {
            DSTrabajo_Social.FamiliaresRow DRFamiliar;
            if (String.IsNullOrEmpty(TipoOperacionGeneral))
            {
                if (DTPacientesFamiliares.Count > 0)
                {
                    DRFamiliar = DTPacientesFamiliares.FindByNumeroPacienteNumeroFamiliar(NumeroPaciente, CodigoFamiliar);
                    if (DRFamiliar == null)
                    {
                        DSTrabajo_Social.FamiliaresDataTable DTFAmiliaresAux = TAFamiliares.GetDataBy1(NumeroPaciente, CodigoFamiliar);
                        if (DTFAmiliaresAux.Count > 0)
                            DRFamiliar = DTFAmiliaresAux[0];
                    }

                    if (DRFamiliar != null)
                    {
                        TxtNumeroFamilar.Text = DRFamiliar.NumeroFamiliar.ToString();
                        TxtEdadFamiliar.Text = DRFamiliar.IsEdadNull() ? String.Empty : DRFamiliar.Edad.ToString();
                        TxtNombreFamiliar.Text = DRFamiliar.IsNombreApellidosNull() ? String.Empty : DRFamiliar.NombreApellidos;
                        cBoxGradoInstrucciónFamiliar.SelectedValue = DRFamiliar.IsGradoInstruccionNull() ? null : DRFamiliar.GradoInstruccion;
                        cBoxEstadoCivilFamiliar.SelectedValue = DRFamiliar.IsEstadoCivilNull() ? null : DRFamiliar.EstadoCivil;
                        cBoxParentescoFamiliar.SelectedValue = DRFamiliar.IsCodigoParentescoNull() ? null : (int?)DRFamiliar.CodigoParentesco;
                        TxtOcupacionFamiliar.Text = DRFamiliar.IsOcupacionNull() ? String.Empty : DRFamiliar.Ocupacion;
                        TxtIngresoEconomicoFamiliar.Text = DRFamiliar.IsIngresoEconomicoNull() ? String.Empty : DRFamiliar.IngresoEconomico.ToString();
                        rTextBoxObservacionesFamiliar.Text = DRFamiliar.IsObservacionNull() ? String.Empty : DRFamiliar.Observacion;

                        habilitarBotonesPestaniaFamiliares(true, false, true, false, true);
                    }
                    else
                    {
                        limpiarControlesPestaniaFamiliares();
                        habilitarBotonesPestaniaFamiliares(true, false, false, false, false);
                    }
                }
                else
                {
                    limpiarControlesPestaniaFamiliares();
                    habilitarBotonesPestaniaFamiliares(true, false, false, false, false);
                }
            }
            else
            {
                DRFamiliar = ((DataTable)bdSourceFamiliares.DataSource).Rows[bdSourceFamiliares.Position] as DSTrabajo_Social.FamiliaresRow;
                if (DRFamiliar != null)
                {
                    TxtNumeroFamilar.Text = DRFamiliar.NumeroFamiliar.ToString();
                    TxtEdadFamiliar.Text = DRFamiliar.IsEdadNull() ? String.Empty : DRFamiliar.Edad.ToString();
                    TxtNombreFamiliar.Text = DRFamiliar.IsNombreApellidosNull() ? String.Empty : DRFamiliar.NombreApellidos;
                    cBoxGradoInstrucciónFamiliar.SelectedValue = DRFamiliar.IsGradoInstruccionNull() ? null : DRFamiliar.GradoInstruccion;
                    cBoxEstadoCivilFamiliar.SelectedValue = DRFamiliar.IsEstadoCivilNull() ? null : DRFamiliar.EstadoCivil;
                    cBoxParentescoFamiliar.SelectedValue = DRFamiliar.IsCodigoParentescoNull() ? null : (int?)DRFamiliar.CodigoParentesco;
                    TxtOcupacionFamiliar.Text = DRFamiliar.IsOcupacionNull() ? String.Empty : DRFamiliar.Ocupacion;
                    TxtIngresoEconomicoFamiliar.Text = DRFamiliar.IsIngresoEconomicoNull() ? String.Empty : DRFamiliar.IngresoEconomico.ToString();
                    rTextBoxObservacionesFamiliar.Text = DRFamiliar.IsObservacionNull() ? String.Empty : DRFamiliar.Observacion;

                    habilitarBotonesPestaniaFamiliares(true, false, true, false, true);
                }
                else
                {
                    limpiarControlesPestaniaFamiliares();
                    habilitarBotonesPestaniaFamiliares(true, false, false, false, false);
                }
            }
            habilitarControlesPestaniaFamiliares(false);

        }

        public void cargarDatosResponsables(int NumeroPaciente, int CodigoResponsable)
        {
            DSTrabajo_Social.ResponsablesRow DRResponsable;
            if (String.IsNullOrEmpty(TipoOperacionGeneral))
            {
                if (DTPacientesResponsables.Count > 0)
                {
                    DRResponsable = DTPacientesResponsables.FindByNumeroPacienteCodigoResponsable(NumeroPaciente, CodigoResponsable);
                    if (DRResponsable == null)
                    {
                        DSTrabajo_Social.ResponsablesDataTable DTResponsablesAux = TAResponsables.GetDataBy1(NumeroPaciente, CodigoResponsable);
                        if (DTResponsablesAux.Count > 0)
                            DRResponsable = DTResponsablesAux[0];
                    }

                    if (DRResponsable != null)
                    {
                        txtCodigoResponsable.Text = DRResponsable.CodigoResponsable.ToString();
                        txtNombreResponsable.Text = DRResponsable.IsNombreApellidosNull() ? String.Empty : DRResponsable.NombreApellidos;
                        txtDirecciónResponsable.Text = DRResponsable.IsDireccionNull() ? String.Empty : DRResponsable.Direccion;
                        txtTeléfonoResponsable.Text = DRResponsable.IsTelefonoNull() ? String.Empty : DRResponsable.Telefono;
                        txtCelular.Text = DRResponsable.IsCelularNull() ? String.Empty : DRResponsable.Celular;
                        cBoxParentescoResponsable.SelectedValue = DRResponsable.IsCodigoParentescoNull() ? null : (int?)DRResponsable.CodigoParentesco;
                        if (DRResponsable.IsCodigoTipoResponsableNull())
                            cBoxTipoResponsable.SelectedIndex = -1;
                        else
                            cBoxTipoResponsable.SelectedValue = DRResponsable.CodigoTipoResponsable;

                        checkVigente.Checked = (!DRResponsable.IsCodigoEstadoResponsableNull() && DRResponsable.CodigoEstadoResponsable.CompareTo("V") == 0);

                        if (DRResponsable.IsCodigoPaisNull())
                            cboxPaisResponsable.SelectedIndex = -1;
                        else
                            cboxPaisResponsable.SelectedValue = DRResponsable.CodigoPais;

                        if (DRResponsable.IsCodigoDepartamentoNull())
                            cBoxDepartamentoResponsable.SelectedIndex = -1;
                        else
                            cBoxDepartamentoResponsable.SelectedValue = DRResponsable.CodigoDepartamento;

                        if (DRResponsable.IsCodigoProvinciaNull())
                            cBoxProvinciaResponsable.SelectedIndex = -1;
                        else
                            cBoxProvinciaResponsable.SelectedValue = DRResponsable.CodigoProvincia;

                        if (DRResponsable.IsCodigoLocalidadNull())
                            cBoxLocalidadResponsable.SelectedIndex = -1;
                        else
                            cBoxLocalidadResponsable.SelectedValue = DRResponsable.CodigoLocalidad;

                        
                        
                        habilitarBotonesPestaniaResponsable(true, false, true, false, true);
                    }
                    else
                    {
                        limpiarControlesPestaniaResponsable();
                        habilitarBotonesPestaniaResponsable(true, false, false, false, false);
                    }
                }
                else
                {
                    limpiarControlesPestaniaResponsable();
                    habilitarBotonesPestaniaResponsable(true, false, false, false, false);
                }
            }
            else
            {
                DRResponsable = ((DataTable)bdSourceResponsables.DataSource).Rows[bdSourceResponsables.Position] as DSTrabajo_Social.ResponsablesRow;
                if (DRResponsable != null)
                {
                    txtCodigoResponsable.Text = DRResponsable.CodigoResponsable.ToString();
                    txtNombreResponsable.Text = DRResponsable.IsNombreApellidosNull() ? String.Empty : DRResponsable.NombreApellidos;
                    txtDirecciónResponsable.Text = DRResponsable.IsDireccionNull() ? String.Empty : DRResponsable.Direccion;
                    txtTeléfonoResponsable.Text = DRResponsable.IsTelefonoNull() ? String.Empty : DRResponsable.Telefono;
                    txtCelular.Text = DRResponsable.IsCelularNull() ? String.Empty : DRResponsable.Celular;
                    cBoxParentescoResponsable.SelectedValue = DRResponsable.IsCodigoParentescoNull() ? null : (int?)DRResponsable.CodigoParentesco;
                    checkVigente.Checked = (!DRResponsable.IsCodigoEstadoResponsableNull() && DRResponsable.CodigoEstadoResponsable.CompareTo("V") == 0);
                    if (DRResponsable.IsCodigoTipoResponsableNull())
                        cBoxTipoResponsable.SelectedIndex = -1;
                    else
                        cBoxTipoResponsable.SelectedValue = DRResponsable.CodigoTipoResponsable;

                    if (DRResponsable.IsCodigoPaisNull())
                        cboxPaisResponsable.SelectedIndex = -1;
                    else
                        cboxPaisResponsable.SelectedValue = DRResponsable.CodigoPais;

                    if (DRResponsable.IsCodigoDepartamentoNull())
                        cBoxDepartamentoResponsable.SelectedIndex = -1;
                    else
                        cBoxDepartamentoResponsable.SelectedValue = DRResponsable.CodigoDepartamento;

                    if (DRResponsable.IsCodigoProvinciaNull())
                        cBoxProvinciaResponsable.SelectedIndex = -1;
                    else
                        cBoxProvinciaResponsable.SelectedValue = DRResponsable.CodigoProvincia;


                    if (DRResponsable.IsCodigoLocalidadNull())
                        cBoxLocalidadResponsable.SelectedIndex = -1;
                    else
                        cBoxLocalidadResponsable.SelectedValue = DRResponsable.CodigoLocalidad;

                    habilitarBotonesPestaniaResponsable(true, false, true, false, true);
                }
                else
                {
                    limpiarControlesPestaniaResponsable();
                    habilitarBotonesPestaniaResponsable(true, false, false, false, false);
                }
            }
            
            habilitarControlesPestaniaResponsable(false);

        }



        public void limpiarControlesPestaniaTipoVivienda()
        {
            
            cBoxLugarVivienda.SelectedIndex = cBoxTipoVivienda.SelectedIndex = cBoxCondicionesVivienda.SelectedIndex =
                cBoxPredisposicionTratPaciente.SelectedIndex = cBoxRelacionFamiliarPaciente.SelectedIndex = -1;
            //TxtNumeroHabitaciones.Text = String.Empty;
            richTxtObservacionesRelacionesFam.Text = rTextBoxObservaciones.Text = String.Empty;
            checkLuz.Checked = checkTelefono.Checked = checkAgua.Checked = checkAlcantarillado.Checked = checkGas.Checked = false;
            
        }

        public void habilitarControlesPestaniaTipoVivienda(bool estadoHabilitacion)
        {
            
            cBoxLugarVivienda.Enabled = cBoxTipoVivienda.Enabled = cBoxCondicionesVivienda.Enabled =
              cBoxPredisposicionTratPaciente.Enabled = cBoxRelacionFamiliarPaciente.Enabled = estadoHabilitacion;
            //TxtNumeroHabitaciones.ReadOnly = !estadoHabilitacion;
            richTxtObservacionesRelacionesFam.ReadOnly = rTextBoxObservaciones.ReadOnly = !estadoHabilitacion;            
            checkLuz.Enabled = checkTelefono.Enabled = checkAgua.Enabled = checkAlcantarillado.Enabled = checkGas.Enabled = estadoHabilitacion;
        }





        public void limpiarControlesPestaniaResponsable()
        {
            txtCodigoResponsable.Text = string.Empty;
            txtNombreResponsable.Text = String.Empty;
            txtDirecciónResponsable.Text = String.Empty;
            txtTeléfonoResponsable.Text = String.Empty;
            txtCelular.Text = String.Empty;
            cBoxParentescoResponsable.SelectedIndex = -1;
            cBoxTipoResponsable.SelectedIndex = -1;
            cboxPaisResponsable.SelectedIndex = -1;
            cBoxDepartamentoResponsable.SelectedIndex = -1;
            cBoxProvinciaResponsable.SelectedIndex = -1;
            cBoxLocalidadResponsable.SelectedIndex = -1;
            checkVigente.Checked = false;
            //DTPacientesResponsables.Clear();

        }

        public void habilitarControlesPestaniaResponsable(bool estadoHabilitacion)
        {
            //txtCodigoResponsable.ReadOnly = !estadoHabilitacion;
            txtNombreResponsable.ReadOnly = !estadoHabilitacion;
            txtDirecciónResponsable.ReadOnly = !estadoHabilitacion;
            txtTeléfonoResponsable.ReadOnly = !estadoHabilitacion;
            txtCelular.ReadOnly = !estadoHabilitacion;
            cBoxParentescoResponsable.Enabled = estadoHabilitacion;
            checkVigente.Enabled = estadoHabilitacion;
            cBoxTipoResponsable.Enabled = estadoHabilitacion;
            cboxPaisResponsable.Enabled = estadoHabilitacion;
            cBoxDepartamentoResponsable.Enabled = estadoHabilitacion;
            cBoxProvinciaResponsable.Enabled = estadoHabilitacion;
            cBoxLocalidadResponsable.Enabled = estadoHabilitacion;
            btnAñadirPaisResponsabl.Enabled = estadoHabilitacion;
            btnAñadirDeptoResponsable.Enabled = estadoHabilitacion;
            btnAñadirProvinciaResponsable.Enabled = estadoHabilitacion;
            btnAñadirLocalidadResponsable.Enabled = estadoHabilitacion;

        }

        public void habilitarBotonesPestaniaResponsable(bool nuevo, bool aceptar, bool editar, bool cancelar, bool eliminar)
        {
            btnAñadirResponsable.Enabled = nuevo;
            btnGuardarResponsable.Enabled = aceptar;
            btnEditarResponsable.Enabled = editar;
            btnCancelarResponsable.Enabled = cancelar;
            btnEliminarResponsable.Enabled = eliminar;
        }

        public void limpiarControlesPestaniaFamiliares()
        {
            TxtNumeroFamilar.Text = String.Empty;
            TxtEdadFamiliar.Text = String.Empty;
            TxtNombreFamiliar.Text = String.Empty;
            cBoxGradoInstrucciónFamiliar.SelectedIndex = -1;
            cBoxEstadoCivilFamiliar.SelectedIndex = -1;
            cBoxParentescoFamiliar.SelectedIndex = -1;
            TxtOcupacionFamiliar.Text = String.Empty;
            TxtIngresoEconomicoFamiliar.Text = String.Empty;
            rTextBoxObservacionesFamiliar.Text = String.Empty;

            //DTPacientesFamiliares.Clear();
        }

        public void habilitarControlesPestaniaFamiliares(bool estadoHabilitacion)
        {
            //TxtNumeroFamilar.ReadOnly = !estadoHabilitacion;
            TxtEdadFamiliar.ReadOnly = !estadoHabilitacion;
            TxtNombreFamiliar.ReadOnly = !estadoHabilitacion;
            cBoxGradoInstrucciónFamiliar.Enabled = estadoHabilitacion;
            cBoxEstadoCivilFamiliar.Enabled = estadoHabilitacion;
            cBoxParentescoFamiliar.Enabled = estadoHabilitacion;
            TxtOcupacionFamiliar.ReadOnly = !estadoHabilitacion;
            TxtIngresoEconomicoFamiliar.ReadOnly = !estadoHabilitacion;
            rTextBoxObservacionesFamiliar.ReadOnly = !estadoHabilitacion;
            btnAñadirParentesco.Enabled = estadoHabilitacion;
        }

        public void habilitarBotonesPestaniaFamiliares(bool nuevo, bool aceptar, bool editar, bool cancelar, bool eliminar)
        {
            btnAñadirFamiliar.Enabled = nuevo;
            btnGuardarFamiliar.Enabled = aceptar;
            btnEditarFamiliar.Enabled = editar;
            btnCancelarFamiliar.Enabled = cancelar;
            btnEliminarFamiliar.Enabled = eliminar;
        }



        public void limpiarControlesPestaniaDatosPersonales()
        {
            dateFechaIngreso.Value = DateTime.Now;
            TxtNumeroPaciente.Text = String.Empty;
            TxtNumeroFolio.Text = String.Empty;
            TxtNumeroHClinico.Text = String.Empty;
            TxtRemitidoPor.Text = String.Empty;
            TxtNombrePaciente.Text = String.Empty;
            TxtApellidoMaterno.Text = String.Empty;
            TxtApellidoPaterno.Text = String.Empty;
            TxtDiagnostico.Text = String.Empty;
            TxtUnidad.Text = String.Empty;
            TxtDenominacion.Text = String.Empty;
            dateFechaNacimiento.Value = DateTime.Now;
            TxtEdad.Text = String.Empty;
            TxtCarnetIdentidad.Text = String.Empty;
            TxtSeccion.Text = String.Empty;

            cBoxPaisNacimiento.SelectedIndex = -1;
            cBoxPaisResidencia.SelectedIndex = -1;
            cBoxDepartamentoNacimiento.SelectedIndex = -1;
            cBoxDepartamentoResidencia.SelectedIndex = -1;
            cBoxProvinciaNacimiento.SelectedIndex = -1;
            cBoxProvinciaResidencia.SelectedIndex = -1;
            cBoxLocalidadResidencia.SelectedIndex = -1;
            cBoxLocalidaNacimiento.SelectedIndex = -1;
            cBoxSexo.SelectedIndex = -1;
            cBoxIdioma.SelectedIndex = -1;

            TxtZonaBarrio.Text = String.Empty;
            //TxtNumeroDireccion.Text = String.Empty;
            TxtTelefono.Text = String.Empty;
            TxtCalleAvenida.Text = String.Empty;
            cBoxGradoInstruccion.SelectedIndex = -1;
            cBoxEstadocivil.SelectedIndex = -1;
            cBoxReligion.SelectedIndex = -1;
            TxtOcupacion.Text = String.Empty;
            TxtLugartrabajo.Text = String.Empty;            
            TxtTipoDiscapacidad.Text = String.Empty;
            rbtnSiDependiente.Checked = rbtnNoDependiente.Checked = false;
            rTextBoxAntecedentesPersonales.Text = String.Empty;
            txtIngresoEventual.Text = txtIngresoMensual.Text = string.Empty;
            checkPacienteInstitucionalizado.Checked = false;
            TxtTipoDiscapacidad.Enabled = false;
            dtGVServicios.DataSource = null;
        }

        public void habilitarBotonesPacientes(bool nuevo, bool aceptar, bool cancelar, bool eliminar, bool editar, bool reportes, bool buscar)
        {
            btnAñadir.Enabled = nuevo;
            btnGuardar.Enabled = aceptar;
            btnCancelar.Enabled = cancelar;
            //btnEliminar.Enabled = eliminar;
            btnEditar.Enabled = editar;
            //btnImprimir.Enabled = reportes;
            btnVerFichaSocial.Enabled = reportes;
            btnBuscar.Enabled = buscar;

        }

        public void habilitarControlesPestaniaDatosPersonales(bool estadoHabilitacion)
        {
            
            dateFechaIngreso.Enabled = estadoHabilitacion;
            //TxtNumeroPaciente.ReadOnly = !estadoHabilitacion;
            TxtNumeroFolio.ReadOnly = !estadoHabilitacion;
            //TxtNumeroHClinico.ReadOnly = !estadoHabilitacion;
            TxtRemitidoPor.ReadOnly = !estadoHabilitacion;
            TxtNombrePaciente.ReadOnly = !estadoHabilitacion;
            TxtApellidoMaterno.ReadOnly = !estadoHabilitacion;
            TxtApellidoPaterno.ReadOnly = !estadoHabilitacion;
            TxtDiagnostico.ReadOnly = !estadoHabilitacion;
            //TxtUnidad.ReadOnly = !estadoHabilitacion;
            //TxtDenominacion.ReadOnly = !estadoHabilitacion;
            dateFechaNacimiento.Enabled = estadoHabilitacion;
            TxtEdad.ReadOnly = !estadoHabilitacion;
            TxtCarnetIdentidad.ReadOnly = !estadoHabilitacion;
            //TxtSeccion.ReadOnly = !estadoHabilitacion;
            cBoxPaisNacimiento.Enabled = estadoHabilitacion;
            cBoxPaisResidencia.Enabled = estadoHabilitacion;
            cBoxDepartamentoNacimiento.Enabled = estadoHabilitacion;
            cBoxDepartamentoResidencia.Enabled = estadoHabilitacion;
            cBoxProvinciaNacimiento.Enabled = estadoHabilitacion;
            cBoxProvinciaResidencia.Enabled = estadoHabilitacion;
            cBoxLocalidadResidencia.Enabled = estadoHabilitacion;
            cBoxLocalidaNacimiento.Enabled = estadoHabilitacion;
            cBoxSexo.Enabled = estadoHabilitacion;
            btnAñadirPais.Enabled = estadoHabilitacion;
            btnAñadirPaisResi.Enabled = estadoHabilitacion;
            btnAñadirDpto.Enabled = estadoHabilitacion;
            btnAñadirDptoResi.Enabled = estadoHabilitacion;
            btnAñadirProvincia.Enabled = estadoHabilitacion;
            btnAñadirProvinciaResi.Enabled = estadoHabilitacion;
            btnAñadirLocalidad.Enabled = estadoHabilitacion;
            btnAñadirLocalidadResi.Enabled = estadoHabilitacion;
            cBoxIdioma.Enabled = estadoHabilitacion;

            TxtZonaBarrio.ReadOnly = !estadoHabilitacion;
            //TxtNumeroDireccion.ReadOnly = !estadoHabilitacion;
            TxtTelefono.ReadOnly = !estadoHabilitacion;
            TxtCalleAvenida.ReadOnly = !estadoHabilitacion;
            cBoxGradoInstruccion.Enabled = estadoHabilitacion;
            cBoxEstadocivil.Enabled = estadoHabilitacion;
            cBoxReligion.Enabled = estadoHabilitacion;
            TxtOcupacion.ReadOnly = !estadoHabilitacion;
            TxtLugartrabajo.ReadOnly = !estadoHabilitacion;            
            TxtTipoDiscapacidad.ReadOnly = !estadoHabilitacion;
            rbtnSiDependiente.Enabled = rbtnNoDependiente.Enabled = estadoHabilitacion;
            rTextBoxAntecedentesPersonales.ReadOnly = !estadoHabilitacion;
            txtIngresoMensual.ReadOnly = txtIngresoEventual.ReadOnly = !estadoHabilitacion;
            checkPacienteInstitucionalizado.Enabled = estadoHabilitacion;
            btnRegistrarServicios.Enabled = estadoHabilitacion;

            btnDocumentos.Enabled = estadoHabilitacion;
        }


        public void cargarProcedenciaNacimiento()
        {
            DTPaisesNacimiento = TAPaises.GetData();
            cBoxPaisNacimiento.DataSource = DTPaisesNacimiento;
            cBoxPaisNacimiento.ValueMember = "CodigoPais";
            cBoxPaisNacimiento.DisplayMember = "NombrePais";
            cBoxPaisNacimiento.SelectedValue = "BO";            

        }

        private void CargarPaisesNacimiento()
        {
            DTPaisesNacimiento = TAPaises.GetData();
            cBoxPaisNacimiento.DataSource = DTPaisesNacimiento.DefaultView;
            cBoxPaisNacimiento.DisplayMember = "NombrePais";
            cBoxPaisNacimiento.ValueMember = "CodigoPais";
            if (DTPaisesNacimiento.Count == 0)
            {
                if (DTDepartamentosNacimiento != null)
                    DTDepartamentosNacimiento.Clear();
                if (DTProvinciasNacimiento != null)
                    DTProvinciasNacimiento.Clear();
                if (DTLocalidadesNacimiento != null)
                    DTLocalidadesNacimiento.Clear();
            }
            cBoxPaisNacimiento.SelectedIndex = -1;
        }

        private void CargarDepartamentosNacimiento(string CodigoPais)
        {
            DTDepartamentosNacimiento = TADepartamentos.GetDataByPais(CodigoPais);
            cBoxDepartamentoNacimiento.DataSource = DTDepartamentosNacimiento.DefaultView;
            cBoxDepartamentoNacimiento.DisplayMember = "NombreDepartamento";
            cBoxDepartamentoNacimiento.ValueMember = "CodigoDepartamento";
            if (DTDepartamentosNacimiento.Count == 0)
            {
                if (DTProvinciasNacimiento != null)
                    DTProvinciasNacimiento.Clear();
                if (DTLocalidadesNacimiento != null)
                    DTLocalidadesNacimiento.Clear();
            }
        }

        private void CargarProvinciasNacimiento(string CodigoPais, string CodigoDepartamento)
        {
            DTProvinciasNacimiento = TAProvincias.GetDataByDepartamento(CodigoPais, CodigoDepartamento);
            cBoxProvinciaNacimiento.DataSource = DTProvinciasNacimiento.DefaultView;
            cBoxProvinciaNacimiento.DisplayMember = "NombreProvincia";
            cBoxProvinciaNacimiento.ValueMember = "CodigoProvincia";
            cBoxProvinciaNacimiento.SelectedIndex = -1;
            if (DTProvinciasNacimiento.Count == 0)
            {
                if (DTLocalidadesNacimiento != null)
                    DTLocalidadesNacimiento.Clear();
            }
            
        }

        private void CargarLocalidadesNacimiento(string CodigoPais, string CodigoDepartamento, string CodigoProvincia)
        {
            DTLocalidadesNacimiento = TALocalidades.GetDataByProvincia(CodigoPais, CodigoDepartamento, CodigoProvincia);
            cBoxLocalidaNacimiento.DataSource = DTLocalidadesNacimiento.DefaultView;
            cBoxLocalidaNacimiento.DisplayMember = "NombreLocalidad";
            cBoxLocalidaNacimiento.ValueMember = "CodigoLocalidad";
            cBoxLocalidaNacimiento.SelectedIndex = -1;
        }



        public void cargarProcedenciaResidencia()
        {
            DTPaisesResidencia = TAPaises.GetData();
            cBoxPaisResidencia.DataSource = DTPaisesResidencia;
            cBoxPaisResidencia.ValueMember = "CodigoPais";
            cBoxPaisResidencia.DisplayMember = "NombrePais";
            cBoxPaisResidencia.SelectedValue = "BO";

        }

        private void CargarPaisesResidencia()
        {
            DTPaisesResidencia = TAPaises.GetData();
            cBoxPaisResidencia.DataSource = DTPaisesResidencia.DefaultView;
            cBoxPaisResidencia.DisplayMember = "NombrePais";
            cBoxPaisResidencia.ValueMember = "CodigoPais";
            cBoxPaisResidencia.SelectedIndex = -1;
            if (DTPaisesResidencia.Count == 0)
            {
                if (DTDepartamentosResidencia != null)
                    DTDepartamentosResidencia.Clear();
                if (DTProvinciasResidencia != null)
                    DTProvinciasResidencia.Clear();
                if (DTLocalidadesResidencia != null)
                    DTLocalidadesResidencia.Clear();
            }
        }

        private void CargarDepartamentosResidencia(string CodigoPais)
        {
            DTDepartamentosResidencia = TADepartamentos.GetDataByPais(CodigoPais);
            cBoxDepartamentoResidencia.DataSource = DTDepartamentosResidencia.DefaultView;
            cBoxDepartamentoResidencia.DisplayMember = "NombreDepartamento";
            cBoxDepartamentoResidencia.ValueMember = "CodigoDepartamento";
            cBoxDepartamentoResidencia.SelectedIndex = -1;
            if (DTDepartamentosResidencia.Count == 0)
            {
                if (DTProvinciasResidencia != null)
                    DTProvinciasResidencia.Clear();
                if (DTLocalidadesResidencia != null)
                    DTLocalidadesResidencia.Clear();
            }
        }

        private void CargarProvinciasResidencia(string CodigoPais, string CodigoDepartamento)
        {
            DTProvinciasResidencia = TAProvincias.GetDataByDepartamento(CodigoPais, CodigoDepartamento);
            cBoxProvinciaResidencia.DataSource = DTProvinciasResidencia.DefaultView;
            cBoxProvinciaResidencia.DisplayMember = "NombreProvincia";
            cBoxProvinciaResidencia.ValueMember = "CodigoProvincia";
            cBoxProvinciaResidencia.SelectedIndex = -1;
            if (DTProvinciasResidencia.Count == 0)
            {
                if (DTLocalidadesResidencia != null)
                    DTLocalidadesResidencia.Clear();
            }
        }

        private void CargarLocalidadesResidencia(string CodigoPais, string CodigoDepartamento, string CodigoProvincia)
        {
            DTLocalidadesResidencia = TALocalidades.GetDataByProvincia(CodigoPais, CodigoDepartamento, CodigoProvincia);
            cBoxLocalidadResidencia.DataSource = DTLocalidadesResidencia.DefaultView;
            cBoxLocalidadResidencia.DisplayMember = "NombreLocalidad";
            cBoxLocalidadResidencia.ValueMember = "CodigoLocalidad";
            cBoxLocalidadResidencia.SelectedIndex = -1;
        }

        //
        public void cargarProcedenciaResponsable()
        {
            DTPaisesResponsable = TAPaises.GetData();
            cboxPaisResponsable.DataSource = DTPaisesResponsable;
            cboxPaisResponsable.ValueMember = "CodigoPais";
            cboxPaisResponsable.DisplayMember = "NombrePais";
            cboxPaisResponsable.SelectedValue = "BO";

        }

        private void CargarPaisesResponsable()
        {
            DTPaisesResponsable = TAPaises.GetData();
            cboxPaisResponsable.DataSource = DTPaisesResponsable.DefaultView;
            cboxPaisResponsable.DisplayMember = "NombrePais";
            cboxPaisResponsable.ValueMember = "CodigoPais";
            cboxPaisResponsable.SelectedIndex = -1;
            if (DTPaisesResponsable.Count == 0)
            {
                if (DTDepartamentosResponsable != null)
                    DTDepartamentosResponsable.Clear();
                if (DTProvinciasResponsable != null)
                    DTProvinciasResponsable.Clear();
                if (DTLocalidadesResponsable != null)
                    DTLocalidadesResponsable.Clear();
            }
        }

        private void CargarDepartamentosResponsable(string CodigoPais)
        {
            DTDepartamentosResponsable = TADepartamentos.GetDataByPais(CodigoPais);
            cBoxDepartamentoResponsable.DataSource = DTDepartamentosResponsable.DefaultView;
            cBoxDepartamentoResponsable.DisplayMember = "NombreDepartamento";
            cBoxDepartamentoResponsable.ValueMember = "CodigoDepartamento";
            cBoxDepartamentoResponsable.SelectedIndex = -1;
            if (DTDepartamentosResponsable.Count == 0)
            {
                if (DTProvinciasResponsable != null)
                    DTProvinciasResponsable.Clear();
                if (DTLocalidadesResponsable != null)
                    DTLocalidadesResponsable.Clear();
            }
        }

        private void CargarProvinciasResponsable(string CodigoPais, string CodigoDepartamento)
        {
            DTProvinciasResponsable = TAProvincias.GetDataByDepartamento(CodigoPais, CodigoDepartamento);
            cBoxProvinciaResponsable .DataSource = DTProvinciasResponsable.DefaultView;
            cBoxProvinciaResponsable.DisplayMember = "NombreProvincia";
            cBoxProvinciaResponsable.ValueMember = "CodigoProvincia";
            cBoxProvinciaResponsable.SelectedIndex = -1;
            if (DTProvinciasResponsable.Count == 0)
            {
                if (DTLocalidadesResponsable != null)
                    DTLocalidadesResponsable.Clear();
            }
        }

        private void CargarLocalidadesResponsable(string CodigoPais, string CodigoDepartamento, string CodigoProvincia)
        {
            DTLocalidadesResponsable = TALocalidades.GetDataByProvincia(CodigoPais, CodigoDepartamento, CodigoProvincia);
            cBoxLocalidadResponsable.DataSource = DTLocalidadesResponsable.DefaultView;
            cBoxLocalidadResponsable.DisplayMember = "NombreLocalidad";
            cBoxLocalidadResponsable.ValueMember = "CodigoLocalidad";
            cBoxLocalidadResponsable.SelectedIndex = -1;
        }

        private void cBoxPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.Equals(cBoxPaisNacimiento) && cBoxPaisNacimiento.SelectedIndex >= 0) 
            {
                CargarDepartamentosNacimiento(cBoxPaisNacimiento.SelectedValue.ToString());
                cBoxDepartamentoNacimiento.SelectedIndex = -1;
            }
            if (sender.Equals(cBoxPaisResidencia) && cBoxPaisResidencia.SelectedIndex >= 0)
            {
                CargarDepartamentosResidencia(cBoxPaisResidencia.SelectedValue.ToString());
                cBoxDepartamentoResidencia.SelectedIndex = -1;
            }
            if (sender.Equals(cboxPaisResponsable) && cboxPaisResponsable.SelectedIndex >= 0)
            {
                CargarDepartamentosResponsable(cboxPaisResponsable.SelectedValue.ToString());
                cBoxDepartamentoResponsable.SelectedIndex = -1;
            }
        }

        private void cBoxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.Equals(cBoxDepartamentoNacimiento) && cBoxPaisNacimiento.SelectedIndex >= 0 && cBoxDepartamentoNacimiento.SelectedIndex >= 0)
            {
                CargarProvinciasNacimiento(cBoxPaisNacimiento.SelectedValue.ToString(), cBoxDepartamentoNacimiento.SelectedValue.ToString());
                cBoxProvinciaNacimiento.SelectedIndex = -1;
            }

            if (sender.Equals(cBoxDepartamentoResidencia) && cBoxPaisResidencia.SelectedIndex >= 0 && cBoxDepartamentoResidencia.SelectedIndex >= 0)
            {
                CargarProvinciasResidencia(cBoxPaisResidencia.SelectedValue.ToString(), cBoxDepartamentoResidencia.SelectedValue.ToString());
                cBoxProvinciaResidencia.SelectedIndex = -1;
            }

            if (sender.Equals(cBoxDepartamentoResponsable) && cboxPaisResponsable.SelectedIndex >= 0 && cBoxDepartamentoResponsable.SelectedIndex >= 0)
            {
                CargarProvinciasResponsable(cboxPaisResponsable.SelectedValue.ToString(), cBoxDepartamentoResponsable.SelectedValue.ToString());
                cBoxProvinciaResponsable.SelectedIndex = -1;
            }
        }

        private void cBoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.Equals(cBoxProvinciaNacimiento) && cBoxPaisNacimiento.SelectedIndex >= 0 && cBoxDepartamentoNacimiento.SelectedIndex >= 0 && cBoxProvinciaNacimiento.SelectedIndex >= 0)
            {
                CargarLocalidadesNacimiento(cBoxPaisNacimiento.SelectedValue.ToString(), cBoxDepartamentoNacimiento.SelectedValue.ToString(), cBoxProvinciaNacimiento.SelectedValue.ToString());
                cBoxLocalidaNacimiento.SelectedIndex = -1;
            }

            if (sender.Equals(cBoxProvinciaResidencia) && cBoxPaisResidencia.SelectedIndex >= 0 && cBoxDepartamentoResidencia.SelectedIndex >= 0 && cBoxProvinciaResidencia.SelectedIndex >= 0)
            {
                CargarLocalidadesResidencia(cBoxPaisResidencia.SelectedValue.ToString(), cBoxDepartamentoResidencia.SelectedValue.ToString(), cBoxProvinciaResidencia.SelectedValue.ToString());
                cBoxLocalidadResidencia.SelectedIndex = -1;
            }

            if (sender.Equals(cBoxProvinciaResponsable) && cboxPaisResponsable.SelectedIndex >= 0 && cBoxDepartamentoResponsable.SelectedIndex >= 0 && cBoxProvinciaResponsable.SelectedIndex >= 0)
            {
                CargarLocalidadesResponsable(cboxPaisResponsable.SelectedValue.ToString(), cBoxDepartamentoResponsable.SelectedValue.ToString(), cBoxProvinciaResponsable.SelectedValue.ToString());
                cBoxLocalidadResponsable.SelectedIndex = -1;
            }
        }


        private void BTdocumento_Click(object sender, EventArgs e)
        {
            FDocumentos formDocumentos = new FDocumentos(NumeroPacienteActual.Value, TipoOperacionGeneral == "I", TAFuncionesSistema.ObtenerNumeroHistorialClinicoPaciente(NumeroPacienteActual.Value));
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
            }
            
            formDocumentos.Dispose();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void button9_Click(object sender, EventArgs e)
        {
            FBusquedaPacientes f2 = new FBusquedaPacientes();
            f2.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FBusquedaPacientes f2 = new FBusquedaPacientes();
            f2.ShowDialog();
            if (f2.NumeroPaciente >= 0)
            {
                NumeroPacienteActual = f2.NumeroPaciente;
                cargarDatosPaciente(f2.NumeroPaciente);
            }
            f2.Dispose();
        }

        


        
        private void btnAñadir_Click(object sender, EventArgs e)
        {

            if(NumeroPacienteActual == -1)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ningún Paciente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rbtnSiDependiente.Checked = rbtnNoDependiente.Checked = false;
            tabControlPacientes.SelectedTab = tabPageDatosPersonales;
            limpiarControlesPestaniaFamiliares();
            limpiarControlesPestaniaResponsable();
            limpiarControlesPestaniaTipoVivienda();

            habilitarControlesPestaniaDatosPersonales(true);
            habilitarControlesPestaniaFamiliares(false);
            habilitarControlesPestaniaResponsable(false);
            habilitarControlesPestaniaTipoVivienda(true);

            habilitarBotonesPacientes(false, true, true, false, false, false, false);
            habilitarBotonesPestaniaFamiliares(true, false, false, false, false);
            habilitarBotonesPestaniaResponsable(true, false, false, false, false);

            DTPacientesResponsablesTemporal.Clear();
            DTPacientesFamiliaresTemporal.Clear();            
            DTPacientesFamiliaresTemporal.NumeroFamiliarColumn.AutoIncrementSeed = 1;
            DTPacientesFamiliaresTemporal.NumeroFamiliarColumn.AutoIncrementStep = +1;

            DTPacientesFamiliaresTemporal.Clear();
            bdSourceFamiliares.DataSource = DTPacientesFamiliaresTemporal;
            dtGVFamiliares.DataSource = bdSourceFamiliares;

            DTPacientesDocumentos.Clear();
            
            DTPacientesResponsablesTemporal.Clear();
            DTPacientesResponsablesTemporal.CodigoResponsableColumn.AutoIncrementSeed = 1;
            DTPacientesResponsablesTemporal.CodigoResponsableColumn.AutoIncrementStep = +1;
            bdSourceResponsables.DataSource = DTPacientesResponsablesTemporal;
            dtGVResponsables.DataSource = bdSourceResponsables;

            //TAFuncionesSistema.ObtenerUltimoIndiceTabla("Pacientes", ref NumeroPacienteActual);
            //NumeroPacienteActual = NumeroPacienteActual.Value + 1;
            //TxtNumeroPaciente.Text = NumeroPacienteActual.Value.ToString();
            TipoOperacionGeneral = "I";
            TxtNumeroFolio.Focus();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControlesPestaniaDatosPersonales();
            limpiarControlesPestaniaFamiliares();
            limpiarControlesPestaniaResponsable();
            limpiarControlesPestaniaTipoVivienda();

            habilitarControlesPestaniaDatosPersonales(false);
            habilitarControlesPestaniaFamiliares(false);
            habilitarControlesPestaniaResponsable(false);
            habilitarControlesPestaniaTipoVivienda(false);

            habilitarBotonesPacientes(false, false, false, false, false, false, true);
            habilitarBotonesPestaniaFamiliares(false, false, false, false, false);
            habilitarBotonesPestaniaResponsable(false, false, false, false, false);

            eProviderPacientes.Clear();
            TipoOperacionGeneral = "";

            DTPacientesFamiliares.Clear();
            DTPacientesFamiliaresTemporal.Clear();
            DTPacientesResponsables.Clear();
            DTPacientesResponsablesTemporal.Clear();

            bdSourceResponsables.DataSource = DTPacientesResponsables;
            bdSourceFamiliares.DataSource = DTPacientesFamiliares;

            TAPagosServicios.Delete(NumeroPacienteActual, CodigoPagoServicio);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarControlesPestaniaDatosPersonales(true);
            //habilitarControlesPestaniaFamiliares(true);
            //habilitarControlesPestaniaResponsable(true);
            habilitarControlesPestaniaTipoVivienda(true);

            habilitarBotonesPacientes(false, true, true, false, false, false, false);
            habilitarBotonesPestaniaFamiliares(true, false, dtGVFamiliares.Rows.Count > 0, false, dtGVFamiliares.Rows.Count > 0);
            habilitarBotonesPestaniaResponsable(true, false, dtGVResponsables.Rows.Count > 0, false, dtGVResponsables.Rows.Count > 0);
            btnRegistrarServicios.Enabled = dtGVServicios.RowCount == 0;
            TipoOperacionGeneral = "E";
            checkPacienteInstitucionalizado.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            eProviderPacientes.Clear();
            if (validarDatosPaciente())
            {
                //DSTrabajo_Social.PacientesRow DRPacienteNuevo = TipoOperacionGeneral == "I" ? DTPacientes.NewPacientesRow() : TAPacientes.GetDataBy1(int.Parse(TxtNumeroPaciente.Text))[0];

                DSTrabajo_Social.PacientesRow DRPacienteNuevo = TAPacientes.GetDataBy11(int.Parse(TxtNumeroPaciente.Text))[0];
                    //DRPacienteNuevo = DTPacientes.NewPacientesRow();
                    int numeroFolio = -1;
                    if (int.TryParse(TxtNumeroHClinico.Text, out numeroFolio))
                        DRPacienteNuevo.HClinico = int.Parse(TxtNumeroHClinico.Text);
                    else
                        DRPacienteNuevo.SetHClinicoNull();
                    
                    if (int.TryParse(TxtNumeroFolio.Text, out numeroFolio))
                        DRPacienteNuevo.NumeroFolio = int.Parse(TxtNumeroFolio.Text);
                    else
                        DRPacienteNuevo.SetNumeroFolioNull();
                    DRPacienteNuevo.FechaConsulta = TAFuncionesSistema.ObtenerFechaHoraServidor().Value;
                    DRPacienteNuevo.Nombre = TxtNombrePaciente.Text.Trim();
                    DRPacienteNuevo.ApellidoPaterno = TxtApellidoPaterno.Text.Trim();
                    DRPacienteNuevo.ApellidoMaterno = TxtApellidoMaterno.Text.Trim();
                    DRPacienteNuevo.FechaNacimiento = dateFechaNacimiento.Value;
                    DRPacienteNuevo.Sexo = cBoxSexo.SelectedIndex == 0 ? "M" : "F";
                    //DRPacienteNuevo.GrupoFamiliar = 
                    DRPacienteNuevo.EstadoCivil = cBoxEstadocivil.SelectedValue.ToString();
                    DRPacienteNuevo.GradoInstruccion = cBoxGradoInstruccion.SelectedValue.ToString();
                    if (int.TryParse(TxtUnidad.Text, out numeroFolio))
                        DRPacienteNuevo.Unidad = int.Parse(TxtUnidad.Text);
                    else
                        DRPacienteNuevo.SetUnidadNull();
                    DRPacienteNuevo.Seccion = TxtSeccion.Text;
                    DRPacienteNuevo.Denominacion = TxtDenominacion.Text;
                    DRPacienteNuevo.FechaIngreso = dateFechaIngreso.Value;
                    DRPacienteNuevo.Religion = cBoxReligion.SelectedValue.ToString();
                    DRPacienteNuevo.Idioma = cBoxIdioma.SelectedValue.ToString();
                    DRPacienteNuevo.Ocupacion = TxtOcupacion.Text;
                    DRPacienteNuevo.NombreRemitidor = TxtRemitidoPor.Text;
                    DRPacienteNuevo.LugarTrabajo = TxtLugartrabajo.Text;
                    DRPacienteNuevo.CIPaciente = TxtCarnetIdentidad.Text;
                    DRPacienteNuevo.PacienteDependiente = rbtnSiDependiente.Checked ? "S" : "N";
                    DRPacienteNuevo.TipoDiscapacidad = TxtTipoDiscapacidad.Text;
                    DRPacienteNuevo.SetIngresoEventualNull();
                    DRPacienteNuevo.SetIngresoMensualNull();
                    double valor = -1;
                    if (double.TryParse(txtIngresoMensual.Text, out valor))
                        DRPacienteNuevo.IngresoMensual = double.Parse(txtIngresoMensual.Text);
                    else
                        DRPacienteNuevo.SetIngresoMensualNull();

                    if (double.TryParse(txtIngresoEventual.Text, out valor))
                        DRPacienteNuevo.IngresoEventual = double.Parse(txtIngresoEventual.Text);
                    else
                        DRPacienteNuevo.SetIngresoEventualNull();

                    //DRPacienteNuevo.Ninguno = checkNinguno.Checked;
                    
                    
                    DRPacienteNuevo.SetNingunoNull();
                    DRPacienteNuevo.PacienteInstitucionalizado = checkPacienteInstitucionalizado.Checked;
                    if (cBoxRelacionFamiliarPaciente.SelectedIndex >= 0)
                        DRPacienteNuevo.RelacionesFamiliares = cBoxRelacionFamiliarPaciente.SelectedValue.ToString();
                    else
                        DRPacienteNuevo.SetRelacionesFamiliaresNull();
                    DRPacienteNuevo.ObservacionRelFamiliares = richTxtObservacionesRelacionesFam.Text;
                    DRPacienteNuevo.PredisposicionTratamiento = cBoxPredisposicionTratPaciente.SelectedValue.ToString();
                    DRPacienteNuevo.Antecedentes = rTextBoxAntecedentesPersonales.Text;
                    //DRPacienteNuevo.CodigoDiagnostico 
                    DRPacienteNuevo.Diagnostico = TxtDiagnostico.Text;
                    DRPacienteNuevo.CodigoPais = cBoxPaisNacimiento.SelectedValue.ToString();
                    DRPacienteNuevo.CodigoDepartamento = cBoxDepartamentoNacimiento.SelectedIndex >= 0 ? cBoxDepartamentoNacimiento.SelectedValue.ToString() : null;
                    DRPacienteNuevo.CodigoProvincia = cBoxProvinciaNacimiento.SelectedIndex >= 0 ? cBoxProvinciaNacimiento.SelectedValue.ToString() : null;
                    DRPacienteNuevo.CodigoLocalidad = cBoxLocalidaNacimiento.SelectedIndex >= 0 ? cBoxLocalidaNacimiento.SelectedValue.ToString() : null;
                    DRPacienteNuevo.CodigoPaisResidencia = cBoxPaisResidencia.SelectedIndex >= 0 ? cBoxPaisResidencia.SelectedValue.ToString() : null;
                    DRPacienteNuevo.CodigoDepartamentoResidencia = cBoxDepartamentoResidencia.SelectedIndex >= 0 ? cBoxDepartamentoResidencia.SelectedValue.ToString() : null;
                    DRPacienteNuevo.CodigoProvinciaResidencia = cBoxProvinciaResidencia.SelectedIndex >= 0 ? cBoxProvinciaResidencia.SelectedValue.ToString() : null;
                    DRPacienteNuevo.CodigoLocalidadResidencia = cBoxLocalidadResidencia.SelectedIndex >= 0 ? cBoxLocalidadResidencia.SelectedValue.ToString() : null;


                    try
                    {
                        string vivienda = cBoxLugarVivienda.SelectedValue.ToString();
                        

                        if (TipoOperacionGeneral == "I")
                        {
                            //DTPacientes.AddPacientesRow(DRPacienteNuevo);
                            TAPacientes.Update(DRPacienteNuevo);

                            int? UltimoNumeroPaciente = 0;
                            TAFuncionesSistema.ObtenerUltimoIndiceTabla("Pacientes", ref UltimoNumeroPaciente);

                            foreach (DSTrabajo_Social.FamiliaresRow DRFamiliarNuevo in DTPacientesFamiliaresTemporal.Rows)
                            {
                                TAFamiliares.Insert(DRFamiliarNuevo.NumeroPaciente, DRFamiliarNuevo.CodigoParentesco, DRFamiliarNuevo.NombreApellidos,
                                    DRFamiliarNuevo.Edad, DRFamiliarNuevo.GradoInstruccion, DRFamiliarNuevo.EstadoCivil,
                                    DRFamiliarNuevo.Ocupacion, DRFamiliarNuevo.IngresoEconomico, DRFamiliarNuevo.Observacion);

                                DTPacientesFamiliares.Rows.Add(DRFamiliarNuevo.ItemArray);
                            }
                            DTPacientesFamiliares.AcceptChanges();

                            foreach (DSTrabajo_Social.ResponsablesRow DRResponsableNuevo in DTPacientesResponsablesTemporal.Rows)
                            {
                                TAResponsables.Insert(DRResponsableNuevo.NumeroPaciente, DRResponsableNuevo.CodigoParentesco, DRResponsableNuevo.NombreApellidos,
                                    DRResponsableNuevo.Direccion, DRResponsableNuevo.Telefono, DRResponsableNuevo.Celular,
                                    DRResponsableNuevo.IsCodigoPaisNull() ? null : DRResponsableNuevo.CodigoPais,
                                    DRResponsableNuevo.IsCodigoDepartamentoNull() ? null : DRResponsableNuevo.CodigoDepartamento,
                                    DRResponsableNuevo.IsCodigoProvinciaNull() ? null : DRResponsableNuevo.CodigoProvincia,
                                    DRResponsableNuevo.IsCodigoLocalidadNull() ? null : DRResponsableNuevo.CodigoLocalidad,
                                    DRResponsableNuevo.CodigoEstadoResponsable, DRResponsableNuevo.CodigoTipoResponsable);
                            }

                            foreach (DSTrabajo_Social.DocumentosRow DRDocumento in DTPacientesDocumentos.Rows)
                            {
                                TAPacientesDocumentos.Insert(NumeroPacienteActual, DRDocumento.FechaRegistro, DRDocumento.TramitoTrabSocial, DRDocumento.CodigoDocumentoTipo);
                            }


                            TAViviendas.Insert(NumeroPacienteActual, vivienda, cBoxTipoVivienda.SelectedValue.ToString(),
                                0, cBoxCondicionesVivienda.SelectedValue.ToString(),
                                rTextBoxObservaciones.Text, checkLuz.Checked ? "S" : "N", checkAgua.Checked ? "S" : "N",
                                checkAlcantarillado.Checked ? "S" : "N", checkTelefono.Checked ? "S" : "N", checkGas.Checked ? "S" : "N");

                            
                            //int numero = -1;
                            //int.TryParse(TxtNumeroDireccion.Text, out numero);
                            TADirecciones.Insert(NumeroPacienteActual, TxtZonaBarrio.Text, TxtCalleAvenida.Text, null, TxtTelefono.Text);

                            if (checkPacienteInstitucionalizado.Checked)
                            {
                                TAFuncionesSistema.ActualizarPacienteInstitucionalizacion(NumeroPacienteActual, TAFuncionesSistema.ObtenerFechaHoraServidor().Value, CodigoUsuario, checkPacienteInstitucionalizado.Checked);
                            }

                            bdSourceResponsables.DataSource = DTPacientesResponsables;
                            bdSourceFamiliares.DataSource = DTPacientesFamiliares;

                            //if (MessageBox.Show(this, "Se registrará los Datos Administrativos. ¿El Paciente solicita una Subvención?",
                            //    this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            //{
                            //    bool TieneCategoria = !(String.IsNullOrEmpty(TAFuncionesSistema.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPacienteActual, true)));
                            //    if (TieneCategoria && MessageBox.Show(this, "El paciente ya tiene una Valoración Socioeconómica y una categoría Asignada. ¿Desea Modificar algún Dato?",
                            //        this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                            //        return;

                            //    FNivelSocioEconomico formNivelSocioEconomico = new FNivelSocioEconomico((TxtNombrePaciente.Text + ' ' + TxtApellidoPaterno.Text + ' ' + TxtApellidoMaterno.Text),
                            //        TipoOperacionGeneral, NumeroPacienteActual);
                            //    if (formNivelSocioEconomico.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            //    {
                            //        String NombreCategoria = formNivelSocioEconomico.NombreCategoria;

                            //        if (formNivelSocioEconomico.DTRespuestasValoracion.Count > 0)
                            //        {
                            //            DataSet DSValoracionSocioEconomica = new DataSet("ValoracionSocioEconomica");
                            //            //DataTable DTAux = formNivelSocioEconomico.DTRespuestasValoracion.Select("Seleccionar = True").CopyToDataTable(DTAux,   .Copy();
                            //            DataTable DTAux = formNivelSocioEconomico.DTRespuestasValoracion.Clone();
                            //            foreach (DSTrabajo_Social.RespuestasValoracionRow DRRespuestas in formNivelSocioEconomico.DTRespuestasValoracion.Select("Seleccionar = True"))
                            //            {
                            //                DTAux.ImportRow(DRRespuestas);
                            //            }

                            //            DTAux.Columns.Remove(DTAux.Columns["NombreRespuestaValoracion"]);
                            //            DTAux.Columns.Remove(DTAux.Columns["Descripcion"]);
                            //            DTAux.TableName = "RespuestasValoracion";
                            //            DSValoracionSocioEconomica.Tables.Add(DTAux);

                            //            TAValoracionSocioEconomica.InsertarActualizarValoracionSocioEconomicaXML(NumeroPacienteActual, DTAux.DataSet.GetXml());

                                        
                            //        }
                            //    }
                            //}

                            //FPagoServicio formPapeletaPago = new FPagoServicio("I");
                            //formPapeletaPago.configurarFormularioIA(NumeroPacienteActual, null);
                            //formPapeletaPago.ShowDialog();
                            //formPapeletaPago.Dispose();


                            //QUITAR REPORTE
                            //ListarPagosServiciosReporteTableAdapter TAListarPagosServiciosReporte = new ListarPagosServiciosReporteTableAdapter();
                            //ValoracionSocioeconomicaTableAdapter TAValoracionSocioEocnomica = new ValoracionSocioeconomicaTableAdapter();
                            //FReporteFormulariosIndividuales formReporte = new FReporteFormulariosIndividuales();
                            //formReporte.ListarPagosServiciosReporte(TAListarPagosServiciosReporte.GetData(NumeroPacienteActual, 1), 
                            //    TAPagosServiciosDetalle.GetData(NumeroPacienteActual, 1, "I"), 
                            //    TAValoracionSocioEocnomica.GetDataByNombreRespuesta(NumeroPacienteActual, null));
                            //formReporte.ShowDialog();
                            //formReporte.Dispose();

                        }
                        else
                        {
                            TAPacientes.Update(DRPacienteNuevo);

                            int UltimoNumeroPaciente = int.Parse(TxtNumeroPaciente.Text);

                            TAViviendas.ActualizarVivienda(UltimoNumeroPaciente, vivienda, cBoxTipoVivienda.SelectedValue.ToString(),
                                0, cBoxCondicionesVivienda.SelectedValue.ToString(),
                                rTextBoxObservaciones.Text, checkLuz.Checked ? "S" : "N", checkAgua.Checked ? "S" : "N",
                                checkAlcantarillado.Checked ? "S" : "N", checkTelefono.Checked ? "S" : "N", checkGas.Checked ? "S" : "N");

                            //int numero = 1;
                            //int.TryParse(TxtNumeroDireccion.Text, out numero);
                            TADirecciones.ActualizarDireccion(UltimoNumeroPaciente, TxtZonaBarrio.Text, TxtCalleAvenida.Text, null , TxtTelefono.Text);

                            
                        }

                        MessageBox.Show(this, "Operación realizada Correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatosPaciente(NumeroPacienteActual.Value);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this,"No se pudo Culminar la Operación Actual. Ocurrió la siguiente Excepción " +
                            ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                habilitarControlesPestaniaDatosPersonales(false);
                habilitarControlesPestaniaFamiliares(false);
                habilitarControlesPestaniaResponsable(false);
                habilitarControlesPestaniaTipoVivienda(false);

                habilitarBotonesPacientes(false, false, false, true, true, true, true);
                habilitarBotonesPestaniaFamiliares(false, false, false, false, false);
                habilitarBotonesPestaniaResponsable(false, false, false, false, false);

                TipoOperacionGeneral = "";
            }
            else
            {
                MessageBox.Show(this, "Existen algunos campos e información que son necesarios para el registro satisfactorio del Paciente, Por favor proceda a corregirlos o completarlos",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnAñadirFamiliar_Click(object sender, EventArgs e)
        {
			if (string.IsNullOrEmpty(TipoOperacionGeneral))
                TipoOperacionGeneral = "E";
            TipoOperacionFamiliares = "I";
            habilitarControlesPestaniaFamiliares(true);
            limpiarControlesPestaniaFamiliares();
            habilitarBotonesPestaniaFamiliares(false, true, false, true, false);
            dtGVFamiliares.Enabled = false;
            TxtIngresoEconomicoFamiliar.Text = "0";
        }

        private void btnEditarFamiliar_Click(object sender, EventArgs e)
        {
			if (String.IsNullOrEmpty(TipoOperacionGeneral))
                TipoOperacionGeneral = "E";
            TipoOperacionFamiliares = "E";
            habilitarControlesPestaniaFamiliares(true);            
            habilitarBotonesPestaniaFamiliares(false, true, false, true, false);
            dtGVFamiliares.Enabled = false;
        }

        private void btnEliminarFamiliar_Click(object sender, EventArgs e)
        {
            if (TipoOperacionGeneral == "I")
            {
                if (DTPacientesFamiliaresTemporal.Count > 0 && dtGVFamiliares.CurrentCell != null && bdSourceFamiliares.Position >= 0
                && MessageBox.Show(this, "¿Se Encuentra seguro de Eliminar el Registro Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
                {

                    DTPacientesFamiliaresTemporal.Rows.RemoveAt(bdSourceFamiliares.Position);
                    DTPacientesFamiliaresTemporal.AcceptChanges();

                    habilitarBotonesPestaniaFamiliares(true, false, DTPacientesFamiliaresTemporal.Count > 0, false, DTPacientesFamiliaresTemporal.Count > 0);
                }
            }
            else
            {
                if (DTPacientesFamiliares.Count > 0 && dtGVFamiliares.CurrentCell != null && bdSourceFamiliares.Position >= 0
                && MessageBox.Show(this, "¿Se Encuentra seguro de Eliminar el Registro Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
                {
                    TAFamiliares.Delete(DTPacientesFamiliares[bdSourceFamiliares.Position].NumeroPaciente,
                        DTPacientesFamiliares[bdSourceFamiliares.Position].NumeroFamiliar);

                    DTPacientesFamiliares.Rows.RemoveAt(bdSourceFamiliares.Position);
                    DTPacientesFamiliares.AcceptChanges();

                    habilitarBotonesPestaniaFamiliares(true, false, DTPacientesFamiliares.Count > 0, false, DTPacientesFamiliares.Count > 0);
                }
            }
            limpiarControlesPestaniaFamiliares();
            
        }

        private void btnGuardarFamiliar_Click(object sender, EventArgs e)
        {
            if (!validarDatosFamiliares())
            {
                //MessageBox.Show(this, "Existen algunos campos que estan mal escritos o probablemente se encuentran vacíos. Proceda a corregirlos para continuar con la Operación Actual",
                //    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            try
            {
                if (TipoOperacionFamiliares == "I" && TipoOperacionGeneral == "I")
                {
                    DTPacientesFamiliaresTemporal.AddFamiliaresRow(NumeroPacienteActual.Value, int.Parse(cBoxParentescoFamiliar.SelectedValue.ToString()),
                        TxtNombreFamiliar.Text, int.Parse(TxtEdadFamiliar.Text), cBoxGradoInstrucciónFamiliar.SelectedValue.ToString(),
                        cBoxEstadoCivilFamiliar.SelectedValue.ToString(), TxtOcupacionFamiliar.Text,
                        String.IsNullOrEmpty(TxtIngresoEconomicoFamiliar.Text) ? 0 : double.Parse(TxtIngresoEconomicoFamiliar.Text), rTextBoxObservacionesFamiliar.Text);
                    DTPacientesFamiliaresTemporal.AcceptChanges();
                }
                else if (TipoOperacionFamiliares == "E" && TipoOperacionGeneral == "E")
                {
                    DTPacientesFamiliares[bdSourceFamiliares.Position].CodigoParentesco = int.Parse(cBoxParentescoFamiliar.SelectedValue.ToString());
                    DTPacientesFamiliares[bdSourceFamiliares.Position].NombreApellidos = TxtNombreFamiliar.Text;
                    DTPacientesFamiliares[bdSourceFamiliares.Position].Edad = int.Parse(TxtEdadFamiliar.Text);
                    DTPacientesFamiliares[bdSourceFamiliares.Position].GradoInstruccion = cBoxGradoInstrucciónFamiliar.SelectedValue.ToString();
                    DTPacientesFamiliares[bdSourceFamiliares.Position].EstadoCivil = cBoxEstadoCivilFamiliar.SelectedValue.ToString();
                    DTPacientesFamiliares[bdSourceFamiliares.Position].Ocupacion = TxtOcupacionFamiliar.Text;
                    if (String.IsNullOrEmpty(TxtIngresoEconomicoFamiliar.Text))
                        DTPacientesFamiliares[bdSourceFamiliares.Position].SetIngresoEconomicoNull();
                    else
                        DTPacientesFamiliares[bdSourceFamiliares.Position].IngresoEconomico = double.Parse(TxtIngresoEconomicoFamiliar.Text);
                    DTPacientesFamiliares[bdSourceFamiliares.Position].Observacion = rTextBoxObservacionesFamiliar.Text;

                    TAFamiliares.ActualizarFamiliar(NumeroPacienteActual.Value, DTPacientesFamiliares[bdSourceFamiliares.Position].NumeroFamiliar,
                        int.Parse(cBoxParentescoFamiliar.SelectedValue.ToString()),
                        TxtNombreFamiliar.Text, int.Parse(TxtEdadFamiliar.Text), cBoxGradoInstrucciónFamiliar.SelectedValue.ToString(),
                        cBoxEstadoCivilFamiliar.SelectedValue.ToString(), TxtOcupacionFamiliar.Text,
                        double.Parse(TxtIngresoEconomicoFamiliar.Text), rTextBoxObservacionesFamiliar.Text);

                    DTPacientesFamiliares.AcceptChanges();
                }
                else if (TipoOperacionFamiliares == "I"  && !string.IsNullOrEmpty(TipoOperacionGeneral)) 
                {
                    TAFamiliares.Insert(NumeroPacienteActual.Value, int.Parse(cBoxParentescoFamiliar.SelectedValue.ToString()),
                        TxtNombreFamiliar.Text, int.Parse(TxtEdadFamiliar.Text), cBoxGradoInstrucciónFamiliar.SelectedValue.ToString(),
                        cBoxEstadoCivilFamiliar.SelectedValue.ToString(), TxtOcupacionFamiliar.Text,
                        String.IsNullOrEmpty(TxtIngresoEconomicoFamiliar.Text) ? 0 : double.Parse(TxtIngresoEconomicoFamiliar.Text), 
                        rTextBoxObservacionesFamiliar.Text);

                    DTPacientesFamiliares.AddFamiliaresRow(NumeroPacienteActual.Value, int.Parse(cBoxParentescoFamiliar.SelectedValue.ToString()),
                        TxtNombreFamiliar.Text, int.Parse(TxtEdadFamiliar.Text), cBoxGradoInstrucciónFamiliar.SelectedValue.ToString(),
                        cBoxEstadoCivilFamiliar.SelectedValue.ToString(), TxtOcupacionFamiliar.Text,
                        String.IsNullOrEmpty(TxtIngresoEconomicoFamiliar.Text) ? 0 : double.Parse(TxtIngresoEconomicoFamiliar.Text), 
                        rTextBoxObservacionesFamiliar.Text);
                    DTPacientesFamiliares.AcceptChanges();

                    int? NumeroFamiliarActual = -1;
                    //TAFuncionesSistema.ObtenerUltimoIndiceTabla("Familiares", ref NumeroFamiliarActual);
                    NumeroFamiliarActual = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(NumeroPacienteActual, "F").Value -1;

                    DTPacientesFamiliares[DTPacientesFamiliares.Count - 1].NumeroPaciente = NumeroFamiliarActual.Value;
                    DTPacientesFamiliares.AcceptChanges();
                                      
                }
                else if (TipoOperacionFamiliares == "E" && TipoOperacionGeneral == "I")
                {
                    DTPacientesFamiliaresTemporal[bdSourceFamiliares.Position].CodigoParentesco = int.Parse(cBoxParentescoFamiliar.SelectedValue.ToString());
                    DTPacientesFamiliaresTemporal[bdSourceFamiliares.Position].NombreApellidos = TxtNombreFamiliar.Text;
                    DTPacientesFamiliaresTemporal[bdSourceFamiliares.Position].Edad = int.Parse(TxtEdadFamiliar.Text);
                    DTPacientesFamiliaresTemporal[bdSourceFamiliares.Position].GradoInstruccion = cBoxGradoInstrucciónFamiliar.SelectedValue.ToString();
                    DTPacientesFamiliaresTemporal[bdSourceFamiliares.Position].EstadoCivil = cBoxEstadoCivilFamiliar.SelectedValue.ToString();
                    DTPacientesFamiliaresTemporal[bdSourceFamiliares.Position].Ocupacion = TxtOcupacionFamiliar.Text;
                    if (String.IsNullOrEmpty(TxtIngresoEconomicoFamiliar.Text))
                        DTPacientesFamiliaresTemporal[bdSourceFamiliares.Position].SetIngresoEconomicoNull();
                    else
                        DTPacientesFamiliaresTemporal[bdSourceFamiliares.Position].IngresoEconomico = double.Parse(TxtIngresoEconomicoFamiliar.Text);
                    DTPacientesFamiliaresTemporal[bdSourceFamiliares.Position].Observacion = rTextBoxObservacionesFamiliar.Text;

                    DTPacientesFamiliaresTemporal.AcceptChanges();
                }

                dtGVFamiliares.Enabled = true;
                //bdSourceFamiliares.DataSource = DTPacientesFamiliares;
                habilitarBotonesPestaniaFamiliares(true, false, true, false, true);
                habilitarControlesPestaniaFamiliares(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudo completar la Operación. Ocurrió la Siguiente Excepción " + ex.Message, this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnCancelarFamiliar_Click(object sender, EventArgs e)
        {
            dtGVFamiliares.Enabled = true;
            dtGVFamiliares.ClearSelection();
            limpiarControlesPestaniaFamiliares();
            habilitarControlesPestaniaFamiliares(false);
            habilitarBotonesPestaniaFamiliares(true, false, false, false, false);
            TipoOperacionFamiliares = "";
        }

        private void btnAñadirResponsable_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(TipoOperacionGeneral))
                TipoOperacionGeneral = "E";
            TipoOperacionResponsables = "I";
            limpiarControlesPestaniaResponsable();
            habilitarControlesPestaniaResponsable(true);
            habilitarBotonesPestaniaResponsable(false, true, false, true, false);
            checkVigente.Enabled = false; checkVigente.Checked = true; cBoxTipoResponsable.SelectedValue = "R";
            dtGVResponsables.Enabled = false;

            if (MessageBox.Show(this, "¿El Responsable que desea registrar es un familiar del Paciente Actual?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                FFamiliaresPaciente formFamiliares = new FFamiliaresPaciente(NumeroPacienteActual.Value, (TxtNombrePaciente.Text + " " + TxtApellidoPaterno.Text + " " + TxtApellidoMaterno.Text));
                formFamiliares.agregarDatosFamiliaresTemporales(DTPacientesFamiliaresTemporal);
                formFamiliares.Visible = false;
                if (formFamiliares.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (formFamiliares.DRFamiliares != null)
                    {
                        //DTPacientesResponsablesTemporal[0].
                        if (DTPacientesResponsables.Select("NombreApellidos = '" + formFamiliares.DRFamiliares.NombreApellidos + "'", "").Length == 0)
                        {
                            txtNombreResponsable.Text = formFamiliares.DRFamiliares.NombreApellidos;
                            cBoxParentescoResponsable.SelectedValue = formFamiliares.DRFamiliares.CodigoParentesco;
                            cBoxTipoResponsable.SelectedValue = "R";
                        }
                        else
                        {
                            MessageBox.Show(this, "El Familiar ya se encuentra registrado como responsable");
                        }
                    }

                }

            }

        }

        private void btnCancelarResponsable_Click(object sender, EventArgs e)
        {
            TipoOperacionResponsables = "";
            limpiarControlesPestaniaResponsable();
            habilitarControlesPestaniaResponsable(false);
            habilitarBotonesPestaniaResponsable(true, false, false, false, false);

            dtGVResponsables.ClearSelection();
            dtGVResponsables.Enabled = true;
        }

        private void btnEditarResponsable_Click(object sender, EventArgs e)
        {
            TipoOperacionResponsables = "E";            
            habilitarControlesPestaniaResponsable(true);
            habilitarBotonesPestaniaResponsable(false, true, false, true, false);
            dtGVResponsables.Enabled = false;
        }

        private void btnEliminarResponsable_Click(object sender, EventArgs e)
        {
            if (TipoOperacionGeneral == "I")
            {
                if (DTPacientesResponsablesTemporal.Count > 0 && dtGVResponsables.CurrentCell != null && bdSourceResponsables.Position >= 0
                && MessageBox.Show(this, "¿Se Encuentra seguro de Eliminar el Registro Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
                {

                    DTPacientesResponsablesTemporal.Rows.RemoveAt(bdSourceResponsables.Position);
                    DTPacientesResponsablesTemporal.AcceptChanges();

                    habilitarBotonesPestaniaResponsable(true, false, DTPacientesResponsablesTemporal.Count > 0, false, DTPacientesResponsablesTemporal.Count > 0);
                }
            }
            else
            {
                if (DTPacientesResponsables.Count > 0 && dtGVResponsables.CurrentCell != null && bdSourceResponsables.Position >= 0
                && MessageBox.Show(this, "¿Se Encuentra seguro de Eliminar el Registro Actual.? Recuerde que el Proceso es Irreversible", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
                {
                    TAResponsables.Delete(DTPacientesResponsables[bdSourceResponsables.Position].NumeroPaciente,
                        DTPacientesResponsables[bdSourceResponsables.Position].CodigoResponsable);

                    DTPacientesResponsables.Rows.RemoveAt(bdSourceResponsables.Position);
                    DTPacientesResponsables.AcceptChanges();

                    habilitarBotonesPestaniaResponsable(true, false, DTPacientesResponsables.Count > 0, false, DTPacientesResponsables.Count > 0);
                }
            }
            limpiarControlesPestaniaResponsable();
        }

        private void btnGuardarResponsable_Click(object sender, EventArgs e)
        {
            if (!validarDatosResponsable())
            {
                MessageBox.Show(this, "Existen algunos campos que estan mal escritos o probablemente se encuentran vacíos. Proceda a corregirlos para continuar con la operación actual",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            try
            {
                if (TipoOperacionResponsables== "I" && TipoOperacionGeneral == "I")
                {
                    if (DTPacientesResponsablesTemporal.Select("NombreApellidos = '" + txtNombreResponsable.Text + "'", "").Length == 0)
                    {
                        DTPacientesResponsablesTemporal.AddResponsablesRow(NumeroPacienteActual.Value, int.Parse(cBoxParentescoResponsable.SelectedValue.ToString()),
                            txtNombreResponsable.Text, txtDirecciónResponsable.Text, txtTeléfonoResponsable.Text,
                            txtCelular.Text, cboxPaisResponsable.SelectedIndex >= 0 ? cboxPaisResponsable.SelectedValue.ToString() : null,
                            cBoxDepartamentoResponsable.SelectedIndex >= 0 ? cBoxDepartamentoResponsable.SelectedValue.ToString() : null,
                            cBoxProvinciaResponsable.SelectedIndex >= 0 ? cBoxProvinciaResponsable.SelectedValue.ToString() : null,
                            cBoxLocalidadResponsable.SelectedIndex >= 0 ? cBoxLocalidadResponsable.SelectedValue.ToString() : null,
                             checkVigente.Checked ? "V" : "B", cBoxTipoResponsable.SelectedValue.ToString());
                    }
                    else
                        MessageBox.Show(this, "Ya ha registrado a esta persona como responsable");
                }
                else if (TipoOperacionResponsables == "E" && TipoOperacionGeneral == "E")
                {
                    DTPacientesResponsables[bdSourceResponsables.Position].CodigoParentesco = int.Parse(cBoxParentescoResponsable.SelectedValue.ToString());
                    DTPacientesResponsables[bdSourceResponsables.Position].NombreApellidos = txtNombreResponsable.Text;
                    DTPacientesResponsables[bdSourceResponsables.Position].Direccion = txtDirecciónResponsable.Text;
                    DTPacientesResponsables[bdSourceResponsables.Position].Telefono = txtTeléfonoResponsable.Text;
                    DTPacientesResponsables[bdSourceResponsables.Position].Celular = txtCelular.Text;
                    if (cboxPaisResponsable.SelectedIndex >= 0)
                        DTPacientesResponsables[bdSourceResponsables.Position].CodigoPais = cboxPaisResponsable.SelectedValue.ToString();
                    else
                        DTPacientesResponsables[bdSourceResponsables.Position].SetCodigoPaisNull();
                    if (cBoxDepartamentoResponsable.SelectedIndex >= 0)
                        DTPacientesResponsables[bdSourceResponsables.Position].CodigoDepartamento = cBoxDepartamentoResponsable.SelectedValue.ToString();
                    else
                        DTPacientesResponsables[bdSourceResponsables.Position].SetCodigoDepartamentoNull();
                    if (cBoxProvinciaResponsable.SelectedIndex >= 0)
                        DTPacientesResponsables[bdSourceResponsables.Position].CodigoProvincia = cBoxProvinciaResponsable.SelectedValue.ToString();
                    else
                        DTPacientesResponsables[bdSourceResponsables.Position].SetCodigoProvinciaNull();
                    if (cBoxLocalidadResponsable.SelectedIndex >= 0)
                        DTPacientesResponsables[bdSourceResponsables.Position].CodigoLocalidad = cBoxLocalidadResponsable.SelectedValue.ToString();
                    else
                        DTPacientesResponsables[bdSourceResponsables.Position].SetCodigoLocalidadNull();

                    if (cBoxTipoResponsable.SelectedIndex >= 0)
                        DTPacientesResponsables[bdSourceResponsables.Position].CodigoTipoResponsable = cBoxTipoResponsable.SelectedValue.ToString();
                    else
                        DTPacientesResponsables[bdSourceResponsables.Position].SetCodigoTipoResponsableNull();

                    DTPacientesResponsables[bdSourceResponsables.Position].CodigoEstadoResponsable = checkVigente.Checked ? "V" : "B";

                    TAResponsables.ActualizarResponsable(NumeroPacienteActual.Value, DTPacientesResponsables[bdSourceResponsables.Position].CodigoResponsable,
                        int.Parse(cBoxParentescoResponsable.SelectedValue.ToString()),
                        txtNombreResponsable.Text, txtDirecciónResponsable.Text, txtTeléfonoResponsable.Text,
                        txtCelular.Text, cboxPaisResponsable.SelectedIndex >= 0 ? cboxPaisResponsable.SelectedValue.ToString() : null,
                        cBoxDepartamentoResponsable.SelectedIndex >= 0 ? cBoxDepartamentoResponsable.SelectedValue.ToString() : null,
                        cBoxProvinciaResponsable.SelectedIndex >= 0 ? cBoxProvinciaResponsable.SelectedValue.ToString() : null,
                        cBoxLocalidadResponsable.SelectedIndex >= 0 ? cBoxLocalidadResponsable.SelectedValue.ToString() : null,
                         checkVigente.Checked ? "V" : "B", cBoxTipoResponsable.SelectedValue.ToString());
                        
                }
                else if (TipoOperacionResponsables == "I" && !string.IsNullOrEmpty(TipoOperacionGeneral))
                {
                    if (DTPacientesResponsables.Select("NombreApellidos = '" + txtNombreResponsable.Text + "'", "").Length == 0)
                    {
                        TAResponsables.Insert(NumeroPacienteActual.Value, int.Parse(cBoxParentescoResponsable.SelectedValue.ToString()),
                            txtNombreResponsable.Text, txtDirecciónResponsable.Text, txtTeléfonoResponsable.Text,
                            txtCelular.Text, cboxPaisResponsable.SelectedIndex >= 0 ? cboxPaisResponsable.SelectedValue.ToString() : null,
                            cBoxDepartamentoResponsable.SelectedIndex >= 0 ? cBoxDepartamentoResponsable.SelectedValue.ToString() : null,
                            cBoxProvinciaResponsable.SelectedIndex >= 0 ? cBoxProvinciaResponsable.SelectedValue.ToString() : null,
                            cBoxLocalidadResponsable.SelectedIndex >= 0 ? cBoxLocalidadResponsable.SelectedValue.ToString() : null,
                            checkVigente.Checked ? "V" : "B", cBoxTipoResponsable.SelectedValue.ToString());


                        DTPacientesResponsables.AddResponsablesRow(NumeroPacienteActual.Value, int.Parse(cBoxParentescoResponsable.SelectedValue.ToString()),
                            txtNombreResponsable.Text, txtDirecciónResponsable.Text, txtTeléfonoResponsable.Text,
                            txtCelular.Text, cboxPaisResponsable.SelectedIndex >= 0 ? cboxPaisResponsable.SelectedValue.ToString() : null,
                            cBoxDepartamentoResponsable.SelectedIndex >= 0 ? cBoxDepartamentoResponsable.SelectedValue.ToString() : null,
                            cBoxProvinciaResponsable.SelectedIndex >= 0 ? cBoxProvinciaResponsable.SelectedValue.ToString() : null,
                            cBoxLocalidadResponsable.SelectedIndex >= 0 ? cBoxLocalidadResponsable.SelectedValue.ToString() : null,
                            checkVigente.Checked ? "V" : "B", cBoxTipoResponsable.SelectedValue.ToString());
                        DTPacientesResponsables.AcceptChanges();

                        int? NumeroFamiliarActual = -1;
                        //TAFuncionesSistema.ObtenerUltimoIndiceTabla("Responsables", ref NumeroFamiliarActual);
                        NumeroFamiliarActual = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(NumeroPacienteActual, "R").Value - 1;

                        DTPacientesResponsables[DTPacientesResponsables.Count - 1].NumeroPaciente = NumeroFamiliarActual.Value;
                        DTPacientesResponsables.AcceptChanges();
                    }
                    else
                        MessageBox.Show(this, "Ya ha registrado a esta persona como responsable");

                }
                else if ( TipoOperacionResponsables == "E" && TipoOperacionGeneral == "I")
                {
                    DTPacientesResponsablesTemporal[bdSourceResponsables.Position].CodigoParentesco = int.Parse(cBoxParentescoResponsable.SelectedValue.ToString());
                    DTPacientesResponsablesTemporal[bdSourceResponsables.Position].NombreApellidos = txtNombreResponsable.Text;
                    DTPacientesResponsablesTemporal[bdSourceResponsables.Position].Direccion = txtDirecciónResponsable.Text;
                    DTPacientesResponsablesTemporal[bdSourceResponsables.Position].Telefono = txtTeléfonoResponsable.Text;
                    DTPacientesResponsablesTemporal[bdSourceResponsables.Position].Celular = txtCelular.Text;
                    if (cboxPaisResponsable.SelectedIndex >= 0)
                        DTPacientesResponsablesTemporal[bdSourceResponsables.Position].CodigoPais = cboxPaisResponsable.SelectedValue.ToString();
                    else
                        DTPacientesResponsablesTemporal[bdSourceResponsables.Position].SetCodigoPaisNull();
                    if (cBoxDepartamentoResponsable.SelectedIndex >= 0)
                        DTPacientesResponsablesTemporal[bdSourceResponsables.Position].CodigoDepartamento = cBoxDepartamentoResponsable.SelectedValue.ToString();
                    else
                        DTPacientesResponsablesTemporal[bdSourceResponsables.Position].SetCodigoDepartamentoNull();
                    if (cBoxProvinciaResponsable.SelectedIndex >= 0)
                        DTPacientesResponsablesTemporal[bdSourceResponsables.Position].CodigoProvincia = cBoxProvinciaResponsable.SelectedValue.ToString();
                    else
                        DTPacientesResponsablesTemporal[bdSourceResponsables.Position].SetCodigoProvinciaNull();
                    if (cBoxLocalidadResponsable.SelectedIndex >= 0)
                        DTPacientesResponsablesTemporal[bdSourceResponsables.Position].CodigoLocalidad = cBoxLocalidadResponsable.SelectedValue.ToString();
                    else
                        DTPacientesResponsablesTemporal[bdSourceResponsables.Position].SetCodigoLocalidadNull();
                    DTPacientesResponsablesTemporal[bdSourceResponsables.Position].CodigoEstadoResponsable = checkVigente.Checked ? "V" : "B";
                    DTPacientesResponsablesTemporal.AcceptChanges();
                }

                dtGVResponsables.Enabled = true;
                habilitarBotonesPestaniaResponsable(true, false, true, false, true);
                habilitarControlesPestaniaResponsable(false);
                //bdSoruceResponsables.DataSource = DTPacientesResponsables;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudo completar la Operación. Ocurrió la Siguiente Excepción " + ex.Message, this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnAñadirPais_Click(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            //fgeografico.seleccionarPestaniaPais();
            fgeografico.configurarFormularioIA("P");                        
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK && !String.IsNullOrEmpty(fgeografico.CodigoPais))
            {
                CargarPaisesNacimiento();
                CargarPaisesResidencia();
                CargarPaisesResponsable();
                cBoxPaisNacimiento.SelectedValue = fgeografico.CodigoPais;
            }
            fgeografico.Dispose();
        }

        private void btnAñadirDpto_Click(object sender, EventArgs e)
        {
            if (cBoxPaisNacimiento.SelectedValue == null)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ningún Pais", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FGeografico fgeografico = new FGeografico();
            fgeografico.cargarAutomaticamente = false;
            //fgeografico.seleccionarPestaniaDepartamento();            
            fgeografico.CargarPaises();
            fgeografico.seleccionarPais(cBoxPaisNacimiento.SelectedValue.ToString());
            fgeografico.configurarFormularioIA("D");
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK &&
                !String.IsNullOrEmpty(fgeografico.CodigoDepartamento))
            {
                CargarDepartamentosNacimiento(cBoxPaisNacimiento.SelectedValue.ToString());
                cBoxDepartamentoNacimiento.SelectedValue = fgeografico.CodigoDepartamento;
            }
        }

        private void btnAñadirProvincia_Click(object sender, EventArgs e)
        {
            if (cBoxPaisNacimiento.SelectedValue == null && cBoxDepartamentoNacimiento.SelectedValue == null)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ningún Departamento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FGeografico fgeografico = new FGeografico();
            fgeografico.cargarAutomaticamente = false;
            //fgeografico.seleccionarPestaniaProvincia();
            fgeografico.CargarPaisesP();
            fgeografico.CargarDepartamentos(cBoxPaisNacimiento.SelectedValue.ToString());
            fgeografico.seleccionarPaisDepartamento(cBoxPaisNacimiento.SelectedValue.ToString(), 
                cBoxDepartamentoNacimiento.SelectedValue != null ? cBoxDepartamentoNacimiento.SelectedValue.ToString() : null);
            fgeografico.configurarFormularioIA("V");            
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK &&
                !String.IsNullOrEmpty(fgeografico.CodigoProvincia))
            {
                CargarProvinciasNacimiento(cBoxPaisNacimiento.SelectedValue.ToString(),
                cBoxDepartamentoNacimiento.SelectedValue != null ? cBoxDepartamentoNacimiento.SelectedValue.ToString() : null);
                cBoxProvinciaNacimiento.SelectedValue = fgeografico.CodigoProvincia;
            }
        }

        private void btnAñadirLocalidad_Click(object sender, EventArgs e)
        {
            if (cBoxPaisNacimiento.SelectedValue == null 
                && cBoxDepartamentoNacimiento.SelectedValue == null
                && cBoxProvinciaNacimiento.SelectedValue == null)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ninguna Provincia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FGeografico fgeografico = new FGeografico();
            fgeografico.cargarAutomaticamente = false;
            //fgeografico.seleccionarPestaniaLugar();
            fgeografico.CargarPaisesL();
            fgeografico.CargarDepartamentosL(cBoxPaisNacimiento.SelectedValue.ToString());
            fgeografico.CargarProvincias(cBoxPaisNacimiento.SelectedValue.ToString(), 
                cBoxDepartamentoNacimiento.SelectedValue != null ? cBoxDepartamentoNacimiento.SelectedValue.ToString() : null);
            fgeografico.seleccionarPaisDepartamentoProvincia(cBoxPaisNacimiento.SelectedValue.ToString(), 
                cBoxDepartamentoNacimiento.SelectedValue != null ? cBoxDepartamentoNacimiento.SelectedValue.ToString() : "", 
                cBoxProvinciaNacimiento.SelectedValue != null ? cBoxProvinciaNacimiento.SelectedValue.ToString() : null);
            fgeografico.configurarFormularioIA("L");
            
            
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK
                && !String.IsNullOrEmpty(fgeografico.CodigoLugar))
            {
                CargarLocalidadesNacimiento(cBoxPaisNacimiento.SelectedValue.ToString(),
                cBoxDepartamentoNacimiento.SelectedValue != null ? cBoxDepartamentoNacimiento.SelectedValue.ToString() : null,
                cBoxProvinciaNacimiento.SelectedValue != null ? cBoxProvinciaNacimiento.SelectedValue.ToString() : null);

                cBoxLocalidaNacimiento.SelectedValue = fgeografico.CodigoLugar;
            }
        }

        private void btnAñadirPaisResi_Click(object sender, EventArgs e)
        {
            
            FGeografico fgeografico = new FGeografico();
            //fgeografico.seleccionarPestaniaPais();
            fgeografico.configurarFormularioIA("P");
            
            
            if (fgeografico.ShowDialog(this)== System.Windows.Forms.DialogResult.OK
                && !String.IsNullOrEmpty(fgeografico.CodigoPais))
            {
                CargarPaisesResidencia();
                cBoxPaisResidencia.SelectedValue = fgeografico.CodigoPais;
            }
            fgeografico.Dispose();
        }

        private void btnAñadirDptoResi_Click(object sender, EventArgs e)
        {
            if (cBoxPaisResidencia.SelectedValue == null)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ningún Pais", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FGeografico fgeografico = new FGeografico();
            fgeografico.cargarAutomaticamente = false;
            //fgeografico.seleccionarPestaniaDepartamento();
            fgeografico.CargarPaises();
            fgeografico.seleccionarPais(cBoxPaisResidencia.SelectedValue.ToString());
            fgeografico.configurarFormularioIA("D");
            
            
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK
                && !String.IsNullOrEmpty(fgeografico.CodigoDepartamento))
            {
                CargarDepartamentosResidencia(cBoxPaisResidencia.SelectedValue.ToString());
                cBoxDepartamentoResidencia.SelectedValue = fgeografico.CodigoDepartamento;
            }
        }

        private void btnAñadirProvinciaResi_Click(object sender, EventArgs e)
        {

            if (cBoxPaisResidencia.SelectedValue == null && cBoxDepartamentoResidencia.SelectedValue == null)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ningún Departamento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
            
            FGeografico fgeografico = new FGeografico();
            fgeografico.cargarAutomaticamente = false;
            fgeografico.seleccionarPestaniaProvincia();
            fgeografico.CargarPaisesP();
            fgeografico.CargarDepartamentos(cBoxPaisResidencia.SelectedValue.ToString());
            fgeografico.seleccionarPaisDepartamento(cBoxPaisResidencia.SelectedValue.ToString(), 
                cBoxDepartamentoResidencia.SelectedValue != null ? cBoxDepartamentoResidencia.SelectedValue.ToString() : null);
            fgeografico.configurarFormularioIA("V");            
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK
                && !String.IsNullOrEmpty(fgeografico.CodigoProvincia))
            {
                CargarProvinciasResidencia(cBoxPaisResidencia.SelectedValue.ToString(),
                cBoxDepartamentoResidencia.SelectedValue != null ? cBoxDepartamentoResidencia.SelectedValue.ToString() : null);
                cBoxProvinciaResidencia.SelectedValue = fgeografico.CodigoProvincia;
            }
        }

        private void btnAñadirLocalidadResi_Click(object sender, EventArgs e)
        {
            if (cBoxPaisResidencia.SelectedValue == null
                && cBoxDepartamentoResidencia.SelectedValue == null
                && cBoxProvinciaResidencia.SelectedValue == null)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ninguna Provincia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FGeografico fgeografico = new FGeografico();
            fgeografico.cargarAutomaticamente = false;
            //fgeografico.seleccionarPestaniaLugar();
            fgeografico.CargarPaisesL();
            fgeografico.CargarDepartamentosL(cBoxPaisResidencia.SelectedValue.ToString());
            fgeografico.CargarProvincias(cBoxPaisResidencia.SelectedValue.ToString(), 
                cBoxDepartamentoResidencia.SelectedValue != null ? cBoxDepartamentoResidencia.SelectedValue.ToString() : null);
            fgeografico.seleccionarPaisDepartamentoProvincia(cBoxPaisResidencia.SelectedValue.ToString(), 
                cBoxDepartamentoResidencia.SelectedValue != null ? cBoxDepartamentoResidencia.SelectedValue.ToString() : "", 
                cBoxProvinciaResidencia.SelectedValue != null ? cBoxProvinciaResidencia.SelectedValue.ToString() : null);
            fgeografico.configurarFormularioIA("L");            
            
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK
                && !String.IsNullOrEmpty(fgeografico.CodigoLugar))
            {
                CargarLocalidadesResidencia(cBoxPaisResidencia.SelectedValue.ToString(),
                cBoxDepartamentoResidencia.SelectedValue != null ? cBoxDepartamentoResidencia.SelectedValue.ToString() : null,
                cBoxProvinciaResidencia.SelectedValue != null ? cBoxProvinciaResidencia.SelectedValue.ToString() : null);

                cBoxLocalidadResidencia.SelectedValue = fgeografico.CodigoLugar;
            }
        }

        private void btnAñadirPaisResponsabl_Click(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            //fgeografico.seleccionarPestaniaPais();
            fgeografico.configurarFormularioIA("P");
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK && 
                !String.IsNullOrEmpty(fgeografico.CodigoPais))
            {
                CargarPaisesResponsable();
                cboxPaisResponsable.SelectedValue = fgeografico.CodigoPais;
            }
            fgeografico.Dispose();
        }

        private void btnAñadirDeptoResponsable_Click(object sender, EventArgs e)
        {
            if (cboxPaisResponsable.SelectedValue == null)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ningún Pais", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FGeografico fgeografico = new FGeografico();
            fgeografico.cargarAutomaticamente = false;
            //fgeografico.seleccionarPestaniaDepartamento();
            fgeografico.CargarPaises();
            fgeografico.seleccionarPais(cboxPaisResponsable.SelectedValue.ToString());
            fgeografico.configurarFormularioIA("D");
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK &&
                !String.IsNullOrEmpty(fgeografico.CodigoDepartamento))
            {
                CargarDepartamentosResponsable(cboxPaisResponsable.SelectedValue.ToString());
                cBoxDepartamentoResponsable.SelectedValue = fgeografico.CodigoDepartamento;
            }
        }

        private void btnAñadirProvinciaResponsable_Click(object sender, EventArgs e)
        {
            if (cboxPaisResponsable.SelectedValue == null && cBoxDepartamentoResponsable.SelectedValue == null)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ningún Departamento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
            FGeografico fgeografico = new FGeografico();
            fgeografico.cargarAutomaticamente = false;
            //fgeografico.seleccionarPestaniaProvincia();
            fgeografico.CargarPaisesP();
            fgeografico.CargarDepartamentos(cboxPaisResponsable.SelectedValue.ToString());
            fgeografico.seleccionarPaisDepartamento(cboxPaisResponsable.SelectedValue.ToString(), 
                cBoxDepartamentoResponsable.SelectedValue != null ? cBoxDepartamentoResponsable.SelectedValue.ToString() : null);
            fgeografico.configurarFormularioIA("V");
            
            
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK &&
                !String.IsNullOrEmpty(fgeografico.CodigoProvincia))
            {
                CargarProvinciasResponsable(cboxPaisResponsable.SelectedValue.ToString(),
                cBoxDepartamentoResponsable.SelectedValue != null ? cBoxDepartamentoResponsable.SelectedValue.ToString() : null);
                cBoxProvinciaResponsable.SelectedValue = fgeografico.CodigoProvincia;
            }
        }

        private void btnAñadirLocalidadResponsable_Click(object sender, EventArgs e)
        {
            if (cboxPaisResponsable.SelectedValue == null
                && cBoxDepartamentoResponsable.SelectedValue == null
                && cBoxProvinciaResponsable.SelectedValue == null)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ninguna Provincia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FGeografico fgeografico = new FGeografico();
            fgeografico.cargarAutomaticamente = false;
            //fgeografico.seleccionarPestaniaLugar();
            fgeografico.CargarPaisesL();
            fgeografico.CargarDepartamentosL(cboxPaisResponsable.SelectedValue.ToString());
            fgeografico.CargarProvincias(cboxPaisResponsable.SelectedValue.ToString(), 
                cBoxDepartamentoResponsable.SelectedValue != null ? cBoxDepartamentoResponsable.SelectedValue.ToString() : null);
            fgeografico.seleccionarPaisDepartamentoProvincia(cboxPaisResponsable.SelectedValue.ToString(), 
                cBoxDepartamentoResponsable.SelectedValue != null ? cBoxDepartamentoResponsable.SelectedValue.ToString() : "", 
                cBoxProvinciaResponsable.SelectedValue != null ? cBoxProvinciaResponsable.SelectedValue.ToString() : null);
            fgeografico.configurarFormularioIA("L");
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK &&
                !String.IsNullOrEmpty(fgeografico.CodigoLugar))
            {
                CargarLocalidadesResponsable(cboxPaisResponsable.SelectedValue.ToString(),
                cBoxDepartamentoResponsable.SelectedValue != null ? cBoxDepartamentoResponsable.SelectedValue.ToString() : null,
                cBoxProvinciaResponsable.SelectedValue != null ? cBoxProvinciaResponsable.SelectedValue.ToString() : null);
                cBoxLocalidadResponsable.SelectedValue = fgeografico.CodigoLugar;
            }
        }

        private void btnAñadirParentesco_Click(object sender, EventArgs e)
        {
            FAñadirParentesco formParentesco = new FAñadirParentesco();
            
            formParentesco.configurarFormularioIA(null);
            if (formParentesco.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                DTParentescoFamiliar.FindByCodigoParentesco(formParentesco.CodigoParentesco) == null)
            {
                DTParentescoFamiliar.Rows.Add(TAParentesco.GetDataBy1(formParentesco.CodigoParentesco)[0].ItemArray);
                DTParentescoFamiliar.DefaultView.Sort = "NombreParentesco ASC";
                cBoxParentescoFamiliar.DataSource = DTParentescoFamiliar;
                cBoxParentescoFamiliar.SelectedValue = formParentesco.CodigoParentesco;

                int? CodigoSeleccionado = cBoxParentescoResponsable.SelectedIndex < 0 ? null : (int?)int.Parse(cBoxParentescoResponsable.SelectedValue.ToString());

                DTParentescoResponsable.Rows.Add(TAParentesco.GetDataBy1(formParentesco.CodigoParentesco)[0].ItemArray);
                DTParentescoResponsable.DefaultView.Sort = "NombreParentesco ASC";
                cBoxParentescoResponsable.DataSource = DTParentescoResponsable;
                if (CodigoSeleccionado == null)
                    cBoxParentescoResponsable.SelectedIndex = -1;
                else
                    cBoxParentescoResponsable.SelectedValue = CodigoSeleccionado;


            }
            formParentesco.Dispose();
        }

        public void HabilitarPestaniaSoloResponsable()
        {
            
                //
            
            this.tabControlPacientes.Controls["tabPageDatosPersonales"].Enabled = false;
            this.tabControlPacientes.Controls["tabPageGrupoFamiliar"].Enabled = false;
            this.tabControlPacientes.Controls["tabPageDatosResponsable"].Enabled = true;
            this.tabControlPacientes.Controls["tabPageTipoVivienda"].Enabled = false;
            //this.tabControlPacientes.Controls[4].Enabled = false;
            //this.tabControlPacientes.Controls[5].Enabled = false;
            foreach (Control control in panel1.Controls)
                control.Enabled = false;
            //panel1.Controls[0].Enabled = false;
            TipoOperacionGeneral = "E";
            habilitarBotonesPestaniaResponsable(true, false, dtGVFamiliares.Rows.Count > 0, false, false);
            tabControlPacientes.SelectedTab = tabPageDatosResponsable;

        }

        private void btnAñadirParentescoResponsable_Click(object sender, EventArgs e)
        {
            FAñadirParentesco formParentesco = new FAñadirParentesco();

            formParentesco.configurarFormularioIA(null);
            if (formParentesco.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                DTParentescoFamiliar.FindByCodigoParentesco(formParentesco.CodigoParentesco) == null)
            {
                DTParentescoResponsable.Rows.Add(TAParentesco.GetDataBy1(formParentesco.CodigoParentesco)[0].ItemArray);
                DTParentescoResponsable.DefaultView.Sort = "NombreParentesco ASC";
                cBoxParentescoResponsable.DataSource = DTParentescoResponsable;
                cBoxParentescoResponsable.SelectedValue = formParentesco.CodigoParentesco;

                int? CodigoSeleccionado = cBoxParentescoFamiliar.SelectedIndex < 0 ? null : (int?)int.Parse(cBoxParentescoFamiliar.SelectedValue.ToString());

                DTParentescoFamiliar.Rows.Add(TAParentesco.GetDataBy1(formParentesco.CodigoParentesco)[0].ItemArray);
                DTParentescoFamiliar.DefaultView.Sort = "NombreParentesco ASC";
                cBoxParentescoFamiliar.DataSource = DTParentescoFamiliar;
                if (CodigoSeleccionado != null)
                    cBoxParentescoFamiliar.SelectedValue = CodigoSeleccionado;
                else
                    cBoxParentescoFamiliar.SelectedIndex = -1;
            }
            formParentesco.Dispose();
        }

        private void bdSourceFamiliares_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void bdSoruceResponsables_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void rbtnSiDependiente_CheckedChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TipoOperacionGeneral))
            {
                TxtTipoDiscapacidad.Enabled = rbtnSiDependiente.Checked;
            }
        }



        private void cBoxPaisNacimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                (sender as ComboBox).SelectedIndex = -1;
        }

        private void tabPageDatosPersonales_Click(object sender, EventArgs e)
        {

        }

        private void dtGVFamiliares_SelectionChanged(object sender, EventArgs e)
        {
            if (dtGVFamiliares.Enabled && dtGVFamiliares.Rows.Count > 0 && dtGVFamiliares.CurrentCell != null
                && bdSourceFamiliares.Position >= 0 && !string.IsNullOrEmpty(TipoOperacionGeneral))
            {
                cargarDatosFamiliares(NumeroPacienteActual.Value, TipoOperacionGeneral == "I" ?
                    DTPacientesFamiliaresTemporal[bdSourceFamiliares.Position].NumeroFamiliar :
                    DTPacientesFamiliares[bdSourceFamiliares.Position].NumeroFamiliar);
            }
        }

        private void dtGVResponsables_SelectionChanged(object sender, EventArgs e)
        {
            if (dtGVResponsables.Enabled && dtGVResponsables.Rows.Count > 0 && dtGVResponsables.CurrentCell != null
                && bdSourceResponsables.Position >= 0 && !string.IsNullOrEmpty(TipoOperacionGeneral))
            {
                cargarDatosResponsables(NumeroPacienteActual.Value, TipoOperacionGeneral == "I" ?
                    DTPacientesResponsablesTemporal[bdSourceResponsables.Position].CodigoResponsable :
                    DTPacientesResponsables[bdSourceResponsables.Position].CodigoResponsable);
            }
        }

        private void btnRegistrarServicios_Click(object sender, EventArgs e)
        {
            FPagoServicio formPagoServicio = new FPagoServicio("I");
            formPagoServicio.configurarFormularioIA(NumeroPacienteActual, null);            
            if (formPagoServicio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataTable DTServicios =formPagoServicio.DTServiciosDetalle;
                dtGVServicios.DataSource = DTServicios;

                //txtIngresoEventual.Text = formPagoServicio.txtIngresoEventual.Text;
                //txtIngresoMensual.Text = formPagoServicio.txtIngresoMensual.Text;
                //checkPacienteInstitucionalizado.Checked = formPagoServicio.checkPacienteInstitucionalizado.Checked;

                btnRegistrarServicios.Enabled = false;
            }
            else
            {                
                TAPagosServicios.Delete(NumeroPacienteActual, formPagoServicio.NumeroPagoServicio);
            }
            CodigoPagoServicio = formPagoServicio.NumeroPagoServicio;
            //formPagoServicio.Dispose();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnVerFichaSocial_Click(object sender, EventArgs e)
        {
            FReporteFormulariosIndividuales formReporte = new FReporteFormulariosIndividuales();
            ListarDatosPacienteReporteTableAdapter TAListarDatosPacienteReporte = new ListarDatosPacienteReporteTableAdapter();
            formReporte.ListarDatosPacienteReporte(TAListarDatosPacienteReporte.GetData(NumeroPacienteActual),
                TAPacientesDocumentos.GetDataByPaciente(NumeroPacienteActual),
                TAFamiliares.GetDataByPaciente(NumeroPacienteActual),
                TAResponsables.GetDataByPaciente(NumeroPacienteActual, "V"),
                TAPagosServiciosDetalle.GetData(NumeroPacienteActual, 1, "I"));
            formReporte.ShowDialog();
            formReporte.Dispose();
        }

        

        
    }
}

