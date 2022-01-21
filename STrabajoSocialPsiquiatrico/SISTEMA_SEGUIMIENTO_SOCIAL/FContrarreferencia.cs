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
    public partial class FContrarreferencia : Form
    {
        ReferenciasTableAdapter TAReferencias;
        ContrarreferenciasTableAdapter TAContraReferencias;
        PacientesTableAdapter TAPacientes;
        DepartamentosTableAdapter TADepartamentos;
        QTAFuncionesSistema TAFuncionesSistema;
        UnidadesMedicasTableAdapter TAUnidadesMedicas;
        TrabajadoresSocialesTableAdapter TATRabajadorSocial;
        EspecialidadesTableAdapter TAEspecialidades;

        DSTrabajo_Social.ReferenciasDataTable DTReferencias;
        DSTrabajo_Social.ContrarreferenciasDataTable DTContraReferencias;
        DSTrabajo_Social.PacientesDataTable DTPacientes;
        DSTrabajo_Social.DepartamentosDataTable DTDepartamentos;
        DSTrabajo_Social.UnidadesMedicasDataTable DTUnidadesMedicas;
        

        string TipoOperacion;
        public int NumeroPacienteActual { get; set; }
        public int NumeroContraReferenciaActual { get; set; }
        public int NumeroReferencia { get; set; }
        ErrorProvider eProviderContraReferencia;

        

        public FContrarreferencia()
        {
            InitializeComponent();

            eProviderContraReferencia = new ErrorProvider();
            TAReferencias = new ReferenciasTableAdapter();
            TAContraReferencias = new ContrarreferenciasTableAdapter();
            TAPacientes = new PacientesTableAdapter();
            TADepartamentos = new DepartamentosTableAdapter();
            TAFuncionesSistema = new QTAFuncionesSistema();
            TAUnidadesMedicas = new UnidadesMedicasTableAdapter();
            TATRabajadorSocial = new TrabajadoresSocialesTableAdapter();
            TAEspecialidades = new EspecialidadesTableAdapter();

            cBoxEstadoCivilContraref.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaEstadoCivil();
            cBoxEstadoCivilContraref.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxEstadoCivilContraref.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxEstadoCivilContraref.SelectedValue = -1;

            cBoxGradoInstContraref.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaGradoInstruccion();
            cBoxGradoInstContraref.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxGradoInstContraref.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxGradoInstContraref.SelectedIndex = -1;

            DTUnidadesMedicas = TAUnidadesMedicas.GetData();
            cBoxUnidadqueContraref.DataSource = DTUnidadesMedicas;
            cBoxUnidadqueContraref.DisplayMember = "NombreUnidadMedica";
            cBoxUnidadqueContraref.ValueMember = "CodigoUnidadMedica";
            cBoxUnidadqueContraref.SelectedIndex = -1;

            cargarDatosContraReferencia(-1, -1, -1);
        }

        public void limpiarControles()
        {
            TxtEdadContraref.Text = string.Empty;
            TxtMedicoReferenciadoContrarref.Text = string.Empty;
            TxtNombrePacienteContraref.Text = string.Empty;
            TxtNroHijosContrarref.Text = string.Empty;
            TxtNumeroContrarreferencia.Text = string.Empty;
            TxtOcupacionContraref.Text = string.Empty;
            TxtServicioAtencionContrarref.Text = string.Empty;
            rTexBoxObservaciones.Text = string.Empty;
            txtProcedencia.Text = String.Empty;

            cBoxEstadoCivilContraref.SelectedIndex = -1;
            cBoxGradoInstContraref.SelectedIndex = -1;
            
            cBoxUnidadqueContraref.SelectedIndex = -1;
            dateFechaContrarreferencia.Value = DateTime.Now;
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            TxtMedicoReferenciadoContrarref.Enabled = estadoHabilitacion;
            rTexBoxObservaciones.Enabled = estadoHabilitacion;
            dateFechaContrarreferencia.Enabled = estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool eliminar, bool editar, bool buscar)
        {
            btnAñadirContrarreferencia.Enabled = nuevo;
            btnGuardarContraref.Enabled = aceptar;
            btnCancelar.Enabled = cancelar;
            btnEditarContrareferencia.Enabled = editar;
            btnBuscarContrarreferencia.Enabled = buscar;
        }
        public bool validarControles()
        {
            eProviderContraReferencia.Clear();
            if(String.IsNullOrEmpty(TxtMedicoReferenciadoContrarref.Text))
            {
                eProviderContraReferencia.SetError(TxtMedicoReferenciadoContrarref, "Aún no ha Ingresado los datos del Médico de Contrarreferencia");
                MessageBox.Show("Aún no ha Ingresado los datos del Médico de Contrarreferencia");
                TxtMedicoReferenciadoContrarref.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(rTexBoxObservaciones.Text))
            {
                eProviderContraReferencia.SetError(rTexBoxObservaciones, "Aún no ha Ingresado alguna observación para la Contrarreferencia");
                MessageBox.Show("Aún no ha Ingresado alguna observación para la Contrarreferencia");
                rTexBoxObservaciones.Focus();
                return false;
            }
            return true;
        }

        public void cargarDatosContraReferencia(int NumeroPacienteAux, int NumeroReferenciaAux, int NumeroContraReferneciaAux)
        {
            limpiarControles();
            DTContraReferencias = TAContraReferencias.GetDataBy1(NumeroPacienteAux, NumeroReferenciaAux, NumeroContraReferneciaAux);
            if (DTContraReferencias.Count != 0)
            {
                this.NumeroPacienteActual = NumeroPacienteAux;
                this.NumeroReferencia = NumeroReferenciaAux;
                this.NumeroContraReferenciaActual = NumeroContraReferneciaAux;


                TxtNumeroContrarreferencia.Text = DTContraReferencias[0].NumeroContrarreferencia.ToString();                
                TxtEdadContraref.Text = TAFuncionesSistema.ObtenerEdadPaciente(NumeroPacienteActual).Value.ToString();
                DTPacientes = TAPacientes.GetDataBy11(NumeroPacienteAux);
                TxtNombrePacienteContraref.Text = DTPacientes[0].Nombre.Trim() + " " + DTPacientes[0].ApellidoPaterno.Trim() + " " + DTPacientes[0].ApellidoMaterno.Trim();

                

                if (DTPacientes[0].IsEstadoCivilNull())
                    cBoxEstadoCivilContraref.SelectedIndex = -1;
                else
                    cBoxEstadoCivilContraref.SelectedValue = DTPacientes[0].EstadoCivil;
                if (DTPacientes[0].IsGradoInstruccionNull())
                    cBoxGradoInstContraref.SelectedIndex = -1;
                else
                    cBoxGradoInstContraref.SelectedValue = DTPacientes[0].GradoInstruccion;

                TxtOcupacionContraref.Text = DTPacientes[0].Ocupacion;
                TxtMedicoReferenciadoContrarref.Text = DTContraReferencias[0].NombreMedicoAtendio;
                rTexBoxObservaciones.Text = DTContraReferencias[0].IsObservacionesNull() ? String.Empty : DTContraReferencias[0].Observaciones;
                
                DTReferencias = TAReferencias.GetDataBy1(NumeroReferencia, NumeroPacienteActual);
                cBoxUnidadqueContraref.SelectedValue = TATRabajadorSocial.GetDataBy1(DTReferencias[0].CodigoTrabajadorSocial)[0].CodigoUnidadMedica;
                TxtNroHijosContrarref.Text = TAFuncionesSistema.ObtenerNumeroFamiliaresParentescoAsociadosPaciente(NumeroPacienteActual, 2).Value.ToString();

                TxtServicioAtencionContrarref.Text = TAEspecialidades.GetDataBy1(DTReferencias[0].CodigoEspecialidad )[0].NombreEspecialidad;

                if (DTPacientes[0].IsCodigoDepartamentoResidenciaNull())
                    txtProcedencia.Text = String.Empty;
                else
                    txtProcedencia.Text = TADepartamentos.GetDataBy1(DTPacientes[0].CodigoPaisResidencia, DTPacientes[0].CodigoDepartamentoResidencia)[0].NombreDepartamento;

                habilitarBotones(true, false, true, true, true, true);
            }
            else
            {
                habilitarBotones(true, false, false, false, false, true);
            }
            habilitarControles(false);
        }

        private void btnAñadirContrarreferencia_Click(object sender, EventArgs e)
        {
            FBuscarPacientesOperaciones formBuscarPacientes = new FBuscarPacientesOperaciones("N");
            if (formBuscarPacientes.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                limpiarControles();

                cBoxUnidadqueContraref.SelectedValue = TATRabajadorSocial.GetDataBy1(int.Parse(formBuscarPacientes.DRPacientes["CodigoTrabajadorSocial"].ToString()))[0].CodigoUnidadMedica;

                int? NumeroContraReferenciaAux = -1;
               // TAFuncionesSistema.ObtenerUltimoIndiceTabla("Contrarreferencias", ref NumeroContraReferenciaAux);
                NumeroContraReferenciaAux = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(formBuscarPacientes.NumeroPaciente, "C").Value;
                NumeroPacienteActual = formBuscarPacientes.NumeroPaciente;

                TxtNumeroContrarreferencia.Text = (NumeroContraReferenciaAux).ToString();
                TxtNombrePacienteContraref.Text = formBuscarPacientes.DRPacientes.NombreCompleto;
                TxtEdadContraref.Text = TAFuncionesSistema.ObtenerEdadPaciente(NumeroPacienteActual).Value.ToString();
                TxtNroHijosContrarref.Text = formBuscarPacientes.DRPacientes["NumeroHijos"].ToString();
                
                cBoxEstadoCivilContraref.SelectedValue = formBuscarPacientes.DRPacientes["EstadoCivil"];
                cBoxGradoInstContraref.SelectedValue = formBuscarPacientes.DRPacientes["GradoInstruccion"];
                TxtOcupacionContraref.Text = formBuscarPacientes.DRPacientes["Ocupacion"].ToString();

                DTPacientes = TAPacientes.GetDataBy11(formBuscarPacientes.NumeroPaciente);
                if (DTPacientes[0].IsCodigoDepartamentoResidenciaNull())
                    txtProcedencia.Text = String.Empty;
                else
                    txtProcedencia.Text = TADepartamentos.GetDataBy1(DTPacientes[0].CodigoPaisResidencia, DTPacientes[0].CodigoDepartamentoResidencia)[0].NombreDepartamento;

                TxtServicioAtencionContrarref.Text = TAEspecialidades.GetDataBy1(int.Parse(formBuscarPacientes.DRPacientes["CodigoEspecialidad"].ToString()))[0].NombreEspecialidad;

                NumeroReferencia = formBuscarPacientes.NumeroOperacion;
                NumeroPacienteActual = formBuscarPacientes.NumeroPaciente;

                

                habilitarBotones(false, true, true, false, false, false);
                habilitarControles(true);
                TipoOperacion = "I";

            }
            else
            {
                MessageBox.Show(this, "Aún no ha Seleccionado ningún Paciente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnGuardarContraref_Click(object sender, EventArgs e)
        {
            if (validarControles())
            {
                if (TipoOperacion == "I")
                {
                    TAContraReferencias.Insert(NumeroPacienteActual, NumeroReferencia, dateFechaContrarreferencia.Value, TxtMedicoReferenciadoContrarref.Text, rTexBoxObservaciones.Text); 
                }
                else
                    TAContraReferencias.ActualizarContrarreferencia(NumeroPacienteActual, NumeroReferencia, int.Parse(TxtNumeroContrarreferencia.Text), dateFechaContrarreferencia.Value, TxtMedicoReferenciadoContrarref.Text, rTexBoxObservaciones.Text);
                MessageBox.Show(this, "Operación realizada satisfactoriamente");
                habilitarControles(false);
                habilitarBotones(true, false, false, true, true, true);
                TipoOperacion = "";
            }
            else
            {
                MessageBox.Show(this, "Existen parámetros considerados obligatorios, proceda a llenarlos o a corregirlos por favor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditarContrareferencia_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false, false);
        }

        private void btnBuscarContrarreferencia_Click(object sender, EventArgs e)
        {
            FBuscarPacientesOperaciones formBuscar = new FBuscarPacientesOperaciones("C");
            if (formBuscar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cargarDatosContraReferencia(formBuscar.NumeroPaciente, int.Parse(formBuscar.DRPacientes["NumeroReferencia"].ToString()), formBuscar.NumeroOperacion);
                
            }
            formBuscar.Dispose();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            eProviderContraReferencia.Clear();
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false, true);
        }

        private void btnCerrarContrarreferencia_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
