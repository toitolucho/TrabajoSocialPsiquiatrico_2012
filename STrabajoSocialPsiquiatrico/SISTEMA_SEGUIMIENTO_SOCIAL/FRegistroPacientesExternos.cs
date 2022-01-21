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
    public partial class FRegistroPacientesExternos : Form
    {

        PacientesTableAdapter TAPacientes;
        ValoracionSocioeconomicaTableAdapter TAValoracionSocioEconomica;
        QTAFuncionesSistema TAFuncionesSistema;
        PaisesTableAdapter TAPaises;
        DepartamentosTableAdapter TADepartamentos;
        ProvinciasTableAdapter TAProvincias;
        LocalidadesTableAdapter TALocalidades;

        DSTrabajo_Social.PacientesDataTable DTPacientes;
        DSTrabajo_Social.PaisesDataTable DTPaisesNacimiento;
        DSTrabajo_Social.DepartamentosDataTable DTDepartamentosNacimiento;
        DSTrabajo_Social.ProvinciasDataTable DTProvinciasNacimiento;
        DSTrabajo_Social.LocalidadesDataTable DTLocalidadesNacimiento;
        DSTrabajo_Social.RespuestasValoracionDataTable DTRespuestasValoracion;

        public int NumeroPaciente { get; set; }
        private string NombreCategoriaPaciente;
        private int CodigoCategoriaPaciente;
        private string TipoOperacion = "";
        ErrorProvider eProviderPacientes;
		bool soloInsertarEditar;
		DateTime? FechaHoraValoracionSocioEconomica; 

        public FRegistroPacientesExternos()
        {
            InitializeComponent();

            TAPacientes = new PacientesTableAdapter();
            TAValoracionSocioEconomica = new ValoracionSocioeconomicaTableAdapter();
            TAFuncionesSistema = new QTAFuncionesSistema();
            TAPaises = new PaisesTableAdapter();
            TADepartamentos = new DepartamentosTableAdapter();
            TALocalidades = new LocalidadesTableAdapter();
            TAProvincias = new ProvinciasTableAdapter();

            eProviderPacientes = new ErrorProvider();

            DTRespuestasValoracion = new DSTrabajo_Social.RespuestasValoracionDataTable();
            cBoxEstadoCivilValSocioeconomica.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaEstadoCivil();
            cBoxEstadoCivilValSocioeconomica.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxEstadoCivilValSocioeconomica.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxEstadoCivilValSocioeconomica.SelectedIndex = -1;

            cBoxGradoInstrucciónVal.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaGradoInstruccion();
            cBoxGradoInstrucciónVal.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxGradoInstrucciónVal.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxGradoInstrucciónVal.SelectedIndex = -1;

            cBoxSexoPacienteVal.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaSexo();
            cBoxSexoPacienteVal.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxSexoPacienteVal.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxSexoPacienteVal.SelectedIndex = -1;

			TxtIngresoEconomico.KeyPress += Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress;
            cargarProcedenciaNacimiento();

            cargarDatosPaciente(-1);
        }

        public void cargarProcedenciaNacimiento()
        {
            DTPaisesNacimiento = TAPaises.GetData(); 
            cBoxPais.DataSource = DTPaisesNacimiento;
            cBoxPais.ValueMember = "CodigoPais";
            cBoxPais.DisplayMember = "NombrePais";
            cBoxPais.SelectedValue = "BO";

        }

        private void CargarPaisesNacimiento()
        {
            DTPaisesNacimiento = TAPaises.GetData(); 
            cBoxPais.DataSource = DTPaisesNacimiento.DefaultView;
            cBoxPais.DisplayMember = "NombrePais";
            cBoxPais.ValueMember = "CodigoPais";
            if (DTPaisesNacimiento.Count == 0)
            {
                if (DTDepartamentosNacimiento != null)
                    DTDepartamentosNacimiento.Clear();
                if (DTProvinciasNacimiento != null)
                    DTProvinciasNacimiento.Clear();
                if (DTLocalidadesNacimiento != null)
                    DTLocalidadesNacimiento.Clear();
            }
        }

        private void CargarDepartamentosNacimiento(string CodigoPais)
        {
            DTDepartamentosNacimiento = TADepartamentos.GetDataByPais(CodigoPais);
            cBoxProcedenciaDep.DataSource = DTDepartamentosNacimiento.DefaultView;
            cBoxProcedenciaDep.DisplayMember = "NombreDepartamento";
            cBoxProcedenciaDep.ValueMember = "CodigoDepartamento";
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
            cBoxProvinciaProc.DataSource = DTProvinciasNacimiento.DefaultView;
            cBoxProvinciaProc.DisplayMember = "NombreProvincia";
            cBoxProvinciaProc.ValueMember = "CodigoProvincia";
            if (DTProvinciasNacimiento.Count == 0)
            {
                if (DTLocalidadesNacimiento != null)
                    DTLocalidadesNacimiento.Clear();
            }
        }

        private void CargarLocalidadesNacimiento(string CodigoPais, string CodigoDepartamento, string CodigoProvincia)
        {
            DTLocalidadesNacimiento = TALocalidades.GetDataByProvincia(CodigoPais, CodigoDepartamento, CodigoProvincia);
            cBoxLocalidadProc.DataSource = DTLocalidadesNacimiento.DefaultView;
            cBoxLocalidadProc.DisplayMember = "NombreLocalidad";
            cBoxLocalidadProc.ValueMember = "CodigoLocalidad";
        }

        private void cBoxPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.Equals(cBoxPais) && cBoxPais.SelectedIndex >= 0)
            {
                CargarDepartamentosNacimiento(cBoxPais.SelectedValue.ToString());
                cBoxProcedenciaDep.SelectedIndex = -1;
            }
        }

        private void cBoxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.Equals(cBoxProcedenciaDep) && cBoxPais.SelectedIndex >= 0 && cBoxProcedenciaDep.SelectedIndex >= 0)
            {
                CargarProvinciasNacimiento(cBoxPais.SelectedValue.ToString(), cBoxProcedenciaDep.SelectedValue.ToString());
                cBoxProvinciaProc.SelectedIndex = -1;
            }

        }

        private void cBoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.Equals(cBoxProvinciaProc) && cBoxPais.SelectedIndex >= 0 && cBoxProcedenciaDep.SelectedIndex >= 0 && cBoxProvinciaProc.SelectedIndex >= 0)
            {
                CargarLocalidadesNacimiento(cBoxPais.SelectedValue.ToString(), cBoxProcedenciaDep.SelectedValue.ToString(), cBoxProvinciaProc.SelectedValue.ToString());
                cBoxLocalidadProc.SelectedIndex = -1;
            }

        }

        public void habilitarControles(bool estadoHabilitacion )        
        {
            TxtApellidoMaterno.ReadOnly = !estadoHabilitacion;
            TxtApellidoPaterno.ReadOnly = !estadoHabilitacion;
            //TxtCategoria.ReadOnly = !estadoHabilitacion;
            TxtEdadVal.ReadOnly = !estadoHabilitacion;
            TxtIngresoEconomico.ReadOnly = !estadoHabilitacion;
            TxtNombrePaciente.ReadOnly = !estadoHabilitacion;
            TxtNumeroPaciente.ReadOnly = !estadoHabilitacion;            
            TxtOcupaciónVal.ReadOnly = !estadoHabilitacion;
            cBoxEstadoCivilValSocioeconomica.Enabled = estadoHabilitacion;
            cBoxGradoInstrucciónVal.Enabled = estadoHabilitacion;
            cBoxLocalidadProc.Enabled = estadoHabilitacion;
            cBoxProcedenciaDep.Enabled = estadoHabilitacion;
            cBoxProvinciaProc.Enabled = estadoHabilitacion;
            cBoxSexoPacienteVal.Enabled = estadoHabilitacion;
            cBoxPais.Enabled = estadoHabilitacion;
            dateFechaNacimientoPaciente.Enabled = estadoHabilitacion;
            nUpDownGrupoFamiliar.Enabled = estadoHabilitacion;

            btnSubvencionServicioSocial.Enabled = estadoHabilitacion;
            btnDeterminarCategoria.Enabled = estadoHabilitacion;
        }

        public void limpiarControles()
        {
            TxtApellidoMaterno.Text = String.Empty;
            TxtApellidoPaterno.Text = String.Empty;
            TxtCategoria.Text = String.Empty;
            TxtEdadVal.Text = String.Empty;
            TxtIngresoEconomico.Text = String.Empty;
            TxtNombrePaciente.Text = String.Empty;
            TxtNumeroPaciente.Text = String.Empty;            
            TxtOcupaciónVal.Text = String.Empty;
            cBoxEstadoCivilValSocioeconomica.SelectedIndex = -1;
            cBoxGradoInstrucciónVal.SelectedIndex = -1;
            cBoxLocalidadProc.SelectedIndex = -1;
            cBoxProcedenciaDep.SelectedIndex = -1;
            cBoxProvinciaProc.SelectedIndex = -1;
            cBoxSexoPacienteVal.SelectedIndex = -1;
            cBoxPais.SelectedIndex = -1;
            nUpDownGrupoFamiliar.Value = 0;            

        }

        public void cargarDatosPaciente(int NumeroPaciente)
        {
            limpiarControles();
            DTPacientes = TAPacientes.GetDataBy11(NumeroPaciente);
            if (DTPacientes.Count > 0)
            {
                TxtApellidoMaterno.Text = DTPacientes[0].IsApellidoMaternoNull() ? String.Empty : DTPacientes[0].ApellidoMaterno;
                TxtApellidoPaterno.Text = DTPacientes[0].IsApellidoPaternoNull() ? String.Empty : DTPacientes[0].ApellidoPaterno;
                TxtCategoria.Text = TAFuncionesSistema.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPaciente, false);
                TxtEdadVal.Text = TAFuncionesSistema.ObtenerEdadPaciente(NumeroPaciente).Value.ToString();
                TxtIngresoEconomico.Text = DTPacientes[0].IsIngresoMensualNull() ? "0.00" : DTPacientes[0].IngresoMensual.ToString();
                TxtNombrePaciente.Text = DTPacientes[0].IsNombreNull() ? String.Empty : DTPacientes[0].Nombre;
                TxtNumeroPaciente.Text = NumeroPaciente.ToString();                
                TxtOcupaciónVal.Text = DTPacientes[0].IsOcupacionNull() ? string.Empty : DTPacientes[0].Ocupacion;
                if (DTPacientes[0].IsEstadoCivilNull())
                    cBoxEstadoCivilValSocioeconomica.SelectedIndex = -1;
                else
                    cBoxEstadoCivilValSocioeconomica.SelectedValue = DTPacientes[0].EstadoCivil;
                if(DTPacientes[0].IsSexoNull())
                    cBoxSexoPacienteVal.SelectedIndex = -1;
                else
                    cBoxSexoPacienteVal.SelectedValue = DTPacientes[0].Sexo;
                if(DTPacientes[0].IsGradoInstruccionNull())
                    cBoxGradoInstrucciónVal.SelectedIndex = -1;
                else
                    cBoxGradoInstrucciónVal.SelectedValue = DTPacientes[0].GradoInstruccion;

                if (DTPacientes[0].IsCodigoPaisResidenciaNull())
                    cBoxPais.SelectedIndex = -1;
                else
                    cBoxPais.SelectedValue = DTPacientes[0].CodigoPaisResidencia;

                if (DTPacientes[0].IsCodigoDepartamentoResidenciaNull())
                    cBoxProcedenciaDep.SelectedIndex = -1;
                else
                    cBoxProcedenciaDep.SelectedValue = DTPacientes[0].CodigoDepartamentoResidencia;

                if (DTPacientes[0].IsCodigoProvinciaResidenciaNull())
                    cBoxProvinciaProc.SelectedIndex = -1;
                else
                    cBoxProvinciaProc.SelectedValue = DTPacientes[0].CodigoProvinciaResidencia;

                if (DTPacientes[0].IsCodigoLocalidadResidenciaNull())
                    cBoxLocalidadProc.SelectedIndex = -1;
                else
                    cBoxLocalidadProc.SelectedValue = DTPacientes[0].CodigoLocalidadResidencia;

                if (DTPacientes[0].IsGrupoFamiliarNull())
                    nUpDownGrupoFamiliar.Value = 0;
                else
                    nUpDownGrupoFamiliar.Value = DTPacientes[0].GrupoFamiliar;
                dateFechaNacimientoPaciente.Value = DTPacientes[0].FechaNacimiento;
                habilitarBotones(true, false, false, true, true, true);
            }
            else
            {
                habilitarBotones(true, false, false, false, false, true);   
            }
            habilitarControles(false);
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool modificar, bool eliminar, bool buscar)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardarValSocioeconomica.Enabled = aceptar;
            btnCancelar.Enabled = cancelar;
            btnEditarValSocioeconomica.Enabled = modificar;
            btnBuscarValSocioeconomica.Enabled = buscar;
        }
        
        private void btnCerrarVal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarValSocioeconomica_Click(object sender, EventArgs e)
        {
            FBusquedaPacientes formBuscarPacientes = new FBusquedaPacientes();
            formBuscarPacientes.ShowDialog();
            if (formBuscarPacientes.NumeroPaciente > 0)
            {
                NumeroPaciente = formBuscarPacientes.NumeroPaciente;
                cargarDatosPaciente(NumeroPaciente);
                DTRespuestasValoracion.Clear();
            }
        }

		public void configurarFormularioIA(int? NumeroPacienteConfiguracion)
        {

            cargarDatosPaciente(NumeroPacienteConfiguracion != null ? NumeroPacienteConfiguracion.Value : -1);
            
            TipoOperacion = NumeroPacienteConfiguracion == null ? "I" : "E";
            soloInsertarEditar = true;
            
            //290
            btnEditarValSocioeconomica.Visible = btnNuevo.Visible = false;
            
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false, false);

            int? NumeroParentescosiguiente = -1;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("Pacientes", ref NumeroParentescosiguiente);
            NumeroParentescosiguiente = NumeroParentescosiguiente.Value == -1 ? 1 : NumeroParentescosiguiente.Value + 1;
            TxtNumeroPaciente.Text = NumeroParentescosiguiente.Value.ToString();
            btnSubvencionServicioSocial.Enabled = false;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show(this, "¿Desea primeramente Buscar los datos del posible Nuevo Paciente antes de Registrarlo?", this.Text,
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    FBusquedaPacientes formBuscarPacientes = new FBusquedaPacientes();
            //    if (formBuscarPacientes.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
            //        MessageBox.Show(this, "Ha Encontrado y Seleccionado un paciente tras la búsqueda. ¿Desea cancelar el Nuevo Registro?", this.Text,
            //        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        NumeroPaciente = formBuscarPacientes.NumeroPaciente;
            //        cargarDatosPaciente(NumeroPaciente);
            //        return;
            //    }
            //}

            DTRespuestasValoracion.Clear();
            TipoOperacion = "I";
            limpiarControles();
            int? CodigoAux = -1;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("Pacientes", ref CodigoAux);
            TxtNumeroPaciente.Text = (++CodigoAux).ToString();
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false, false);
            btnSubvencionServicioSocial.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            eProviderPacientes.Clear();
            limpiarControles();
            TipoOperacion = "";
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false, true);
            btnSubvencionServicioSocial.Enabled = false;            
        }

        private void btnDeterminarCategoria_Click(object sender, EventArgs e)
        {
            bool TieneCategoria = !(String.IsNullOrEmpty(TAFuncionesSistema.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPaciente, true)));
            if(TieneCategoria && MessageBox.Show(this,"El paciente ya tiene una Valoración Socioeconómica y una categoría Asignada. ¿Desea Modificar algún Dato?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;

            FNivelSocioEconomico formNivelSocioEconomico = new FNivelSocioEconomico(TipoOperacion == "I" ? (TxtNombrePaciente.Text + ' '  +TxtApellidoPaterno.Text + ' ' +TxtApellidoMaterno.Text) 
                :   TAFuncionesSistema.ObtenerNombreCompleto(NumeroPaciente), TipoOperacion, NumeroPaciente);
            if (formNivelSocioEconomico.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtCategoria.Text = formNivelSocioEconomico.NombreCategoria;
                DTRespuestasValoracion.Clear();
                foreach (DSTrabajo_Social.RespuestasValoracionRow DRRespuestas in formNivelSocioEconomico.DTRespuestasValoracion.Select("Seleccionar = True"))
                {
                    DTRespuestasValoracion.ImportRow(DRRespuestas);
                }
            }
        }

        public bool validarDatos()
        {
            eProviderPacientes.Clear();
            if (String.IsNullOrEmpty(TxtNombrePaciente.Text))
            {
                eProviderPacientes.SetError(TxtNombrePaciente, "Aún no ha Ingresado el Nombre del Paciente");
                TxtNombrePaciente.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(TxtApellidoMaterno.Text) && String.IsNullOrEmpty(TxtApellidoPaterno.Text))
            {
                eProviderPacientes.SetError(TxtApellidoPaterno, "Debe al menos Ingresar uno de los Apellidos del Paciente");
                TxtApellidoPaterno.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(TxtApellidoPaterno.Text) && MessageBox.Show(this, "¿Se encuentra seguro de dejar en blanco el Apellido Paterno del Paciente?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                eProviderPacientes.SetError(TxtApellidoPaterno, "Aún no ha Ingresado el Apellido Paterno del Paciente");
                TxtApellidoPaterno.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(TxtApellidoMaterno.Text) && MessageBox.Show(this, "¿Se encuentra seguro de dejar en blanco el Apellido Materno del Paciente?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                eProviderPacientes.SetError(TxtApellidoMaterno, "Aún no ha ingresado el Apellido Materno del Paciente");
                TxtApellidoMaterno.Focus();
                return false;
            }

            if (cBoxEstadoCivilValSocioeconomica.SelectedIndex < 0)
            {
                eProviderPacientes.SetError(cBoxEstadoCivilValSocioeconomica, "Aún no ha seleccionado el Estado Civil del Paciente");
                cBoxEstadoCivilValSocioeconomica.Focus();
                return false;
            }
            if (cBoxSexoPacienteVal.SelectedIndex < 0)
            {
                eProviderPacientes.SetError(cBoxSexoPacienteVal, "Aún no ha seleccionado el Sexo del Paciente");
                cBoxSexoPacienteVal.Focus();
                return false;
            }
            if (cBoxGradoInstrucciónVal.SelectedIndex < 0)
            {
                eProviderPacientes.SetError(cBoxGradoInstrucciónVal, "Aún no ha seleccionado el Grado de Instrucción del Paciente");
                cBoxGradoInstrucciónVal.Focus();
                return false;
            }

           // if (String.IsNullOrEmpty(TxtIngresoEconomico.Text) && MessageBox.Show(this, "¿Se encuentra seguro de dejar en blanco el Ingreso Económico del Paciente?",
           //     this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
           //{
           //     eProviderPacientes.SetError(TxtIngresoEconomico, "Aún no ha ingresado el Ingreso Económico del Paciente");
           //     TxtIngresoEconomico.Focus();
           //     return false;
           // }
            if (String.IsNullOrEmpty(TxtCategoria.Text))
            {
                eProviderPacientes.SetError(TxtCategoria, "Aún no ha determinado la Categoria del Paciente");
                TxtCategoria.Focus();
                return false;
            }

            #region Validacion para Datos de Paciente
            if (cBoxProcedenciaDep.SelectedIndex >= 0 && cBoxPais.SelectedIndex == -1)
            {
                eProviderPacientes.SetError(cBoxProcedenciaDep, "No puede registrar los Datos del Departamento del Paciente sin haber seleccionado su correspondiente"
                    + "Pais");
                cBoxProcedenciaDep.Focus();
                return false;
            }

            if (cBoxProvinciaProc.SelectedIndex >= 0 &&
                (cBoxProcedenciaDep.SelectedIndex == -1
                || cBoxPais.SelectedIndex == -1))
            {                
                eProviderPacientes.SetError(cBoxProvinciaProc, "No puede registrar los Datos de la provincia del Paciente sin haber seleccionado su correspondiente"
                    + " Departamento y Pais");
                cBoxProvinciaProc.Focus();
                return false;
            }
            
            if (cBoxLocalidadProc.SelectedIndex >= 0 &&
                (cBoxProvinciaProc.SelectedIndex == -1 || cBoxProcedenciaDep.SelectedIndex == -1
                || cBoxPais.SelectedIndex == -1))
            {
                
                eProviderPacientes.SetError(cBoxLocalidadProc, "No puede registrar los Datos de la localidad del Paciente sin haber seleccionado su correspondiente"
                    + " Provincia, Departamento y Pais");
                cBoxLocalidadProc.Focus();
                return false;
            }

            #endregion
            return true;
        }
        private void btnGuardarValSocioeconomica_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                try
                {
                    if (TipoOperacion == "I")
                    {
                        NumeroPaciente = int.Parse(TxtNumeroPaciente.Text);
                        TAPacientes.Insert(null, null, TAFuncionesSistema.ObtenerFechaHoraServidor(), TxtNombrePaciente.Text, TxtApellidoPaterno.Text, TxtApellidoMaterno.Text,
                            dateFechaNacimientoPaciente.Value, cBoxSexoPacienteVal.SelectedValue.ToString(), (int?)nUpDownGrupoFamiliar.Value, cBoxEstadoCivilValSocioeconomica.SelectedValue.ToString(),
                            cBoxGradoInstrucciónVal.SelectedValue.ToString(), null, null, null, TAFuncionesSistema.ObtenerFechaHoraServidor(), null, null,
                            TxtOcupaciónVal.Text, null, null, null, "S", null, String.IsNullOrEmpty(TxtIngresoEconomico.Text) ? 0 : double.Parse(TxtIngresoEconomico.Text),
                            null, null, null, null, null, null, null, null, null, 
                            null, null, null, null,
                            cBoxPais.SelectedIndex >= 0 ? cBoxPais.SelectedValue.ToString() : null,
                            cBoxProcedenciaDep.SelectedIndex >= 0 ? cBoxProcedenciaDep.SelectedValue.ToString() : null,
                            cBoxProvinciaProc.SelectedIndex >= 0 ? cBoxProvinciaProc.SelectedValue.ToString() : null,
                            cBoxLocalidadProc.SelectedIndex >= 0 ? cBoxLocalidadProc.SelectedValue.ToString() : null
                            );
                    }
                    else
                    {
                        TAPacientes.ActualizarPacienteIncompleto(NumeroPaciente, TAFuncionesSistema.ObtenerFechaHoraServidor(), TxtNombrePaciente.Text, TxtApellidoPaterno.Text, TxtApellidoMaterno.Text,
                            dateFechaNacimientoPaciente.Value, cBoxSexoPacienteVal.SelectedValue.ToString(), (int?)nUpDownGrupoFamiliar.Value, cBoxEstadoCivilValSocioeconomica.SelectedValue.ToString(),
                            cBoxGradoInstrucciónVal.SelectedValue.ToString(), String.IsNullOrEmpty(TxtIngresoEconomico.Text) ? 0 : double.Parse(TxtIngresoEconomico.Text), TxtOcupaciónVal.Text,
                            cBoxPais.SelectedIndex >= 0 ? cBoxPais.SelectedValue.ToString() : null,
                            cBoxProcedenciaDep.SelectedIndex >= 0 ? cBoxProcedenciaDep.SelectedValue.ToString() : null,
                            cBoxProvinciaProc.SelectedIndex >= 0 ? cBoxProvinciaProc.SelectedValue.ToString() : null,
                            cBoxLocalidadProc.SelectedIndex >= 0 ? cBoxLocalidadProc.SelectedValue.ToString() : null);
                    }

                    if (DTRespuestasValoracion.Count > 0)
                    {
                        DataSet DSValoracionSocioEconomica = new DataSet("ValoracionSocioEconomica");
                        DataTable DTAux = DTRespuestasValoracion.Copy();
                        DTAux.Columns.Remove(DTAux.Columns["NombreRespuestaValoracion"]);
                        DTAux.Columns.Remove(DTAux.Columns["Descripcion"]);
                        DTAux.TableName = "RespuestasValoracion";
                        DSValoracionSocioEconomica.Tables.Add(DTAux);

                        FechaHoraValoracionSocioEconomica = TAFuncionesSistema.ObtenerFechaHoraServidor();
                        TAValoracionSocioEconomica.InsertarActualizarValoracionSocioEconomicaXML(NumeroPaciente, FechaHoraValoracionSocioEconomica, DTAux.DataSet.GetXml());
                    }

					if (soloInsertarEditar)
                    {
                        //DialogResult = System.Windows.Forms.DialogResult.OK;
                        //this.Close();
                    }
                    habilitarControles(false);
                    habilitarBotones(true, false, false, true, true, true);
                    MessageBox.Show(this, "Operación Realizada Correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSubvencionServicioSocial.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrió la siguiente Excepción " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(this, "Existen parámetros y campos que son considerados obligatorios. Por Favor proceda a corregirlos y vuelva a intentar");
            }
        }

        private void btnEditarValSocioeconomica_Click(object sender, EventArgs e)
        {
            habilitarBotones(false, true, true, false, false, false);            
            habilitarControles(true);
            TipoOperacion = "E";
            btnSubvencionServicioSocial.Enabled = false;
        }

        private void dateFechaNacimientoPaciente_ValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TipoOperacion))
            {
                TxtEdadVal.Text = TAFuncionesSistema.ObtenerEdad(dateFechaNacimientoPaciente.Value, TAFuncionesSistema.ObtenerFechaHoraServidor()).Value.ToString();
            }
        }

        private void btnSubvencionServicioSocial_Click(object sender, EventArgs e)
        {
            FPagoServicio formPagoServicio = new FPagoServicio("S");
            formPagoServicio.cargardDatosPaciente(NumeroPaciente);
            formPagoServicio.ShowDialog();
            formPagoServicio.Dispose();

        }

        private void cBoxPais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                (sender as ComboBox).SelectedIndex = -1;
        }

        private void btnAñadirPaisResi_Click(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            //fgeografico.seleccionarPestaniaPais();
            fgeografico.configurarFormularioIA("P");
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK
                && !String.IsNullOrEmpty(fgeografico.CodigoPais))
            {
                CargarPaisesNacimiento();
                cBoxPais.SelectedValue = fgeografico.CodigoPais;
            }
            fgeografico.Dispose();
        }

        private void btnAgregarDepartamento_Click(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            fgeografico.cargarAutomaticamente = false;
            //fgeografico.seleccionarPestaniaDepartamento();
            fgeografico.CargarPaises();
            fgeografico.seleccionarPais(cBoxPais.SelectedValue.ToString());
            fgeografico.configurarFormularioIA("D");
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK &&
                !String.IsNullOrEmpty(fgeografico.CodigoDepartamento))
            {
                CargarDepartamentosNacimiento(cBoxPais.SelectedValue.ToString());
                cBoxProcedenciaDep.SelectedValue = fgeografico.CodigoDepartamento;
            }
        }

        private void btnAgregarProvincia_Click(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            fgeografico.cargarAutomaticamente = false;
            //fgeografico.seleccionarPestaniaProvincia();
            fgeografico.CargarPaisesP();
            fgeografico.CargarDepartamentos(cBoxPais.SelectedValue.ToString());
            fgeografico.seleccionarPaisDepartamento(cBoxPais.SelectedValue.ToString(),
                cBoxProcedenciaDep.SelectedValue != null ? cBoxProcedenciaDep.SelectedValue.ToString() : null);
            fgeografico.configurarFormularioIA("V");
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK &&
                !String.IsNullOrEmpty(fgeografico.CodigoProvincia))
            {
                CargarProvinciasNacimiento(cBoxPais.SelectedValue.ToString(),
                cBoxProcedenciaDep.SelectedValue != null ? cBoxProcedenciaDep.SelectedValue.ToString() : null);
                cBoxProvinciaProc.SelectedValue = fgeografico.CodigoProvincia;
            }
        }

        private void btnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            fgeografico.cargarAutomaticamente = false;
            //fgeografico.seleccionarPestaniaLugar();
            fgeografico.CargarPaisesL();
            fgeografico.CargarDepartamentosL(cBoxPais.SelectedValue.ToString());
            fgeografico.CargarProvincias(cBoxPais.SelectedValue.ToString(),
                cBoxProcedenciaDep.SelectedValue != null ? cBoxProcedenciaDep.SelectedValue.ToString() : null);
            fgeografico.seleccionarPaisDepartamentoProvincia(cBoxPais.SelectedValue.ToString(),
                cBoxProcedenciaDep.SelectedValue != null ? cBoxProcedenciaDep.SelectedValue.ToString() : "",
                cBoxProvinciaProc.SelectedValue != null ? cBoxProvinciaProc.SelectedValue.ToString() : null);
            fgeografico.configurarFormularioIA("L");
            
            
            if (fgeografico.ShowDialog(this) == System.Windows.Forms.DialogResult.OK
                && !String.IsNullOrEmpty(fgeografico.CodigoLugar))
            {
                CargarLocalidadesNacimiento(cBoxPais.SelectedValue.ToString(),
                cBoxProcedenciaDep.SelectedValue != null ? cBoxProcedenciaDep.SelectedValue.ToString() : null,
                cBoxProvinciaProc.SelectedValue != null ? cBoxProvinciaProc.SelectedValue.ToString() : null);
                cBoxProcedenciaDep.SelectedValue = fgeografico.CodigoLugar;
            }
        }

        
    }
}
