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
    public partial class FInformeSocial : Form
    {
        PacientesTableAdapter TAPacientes;
        InformesSocialesTableAdapter TAInformeSocial;
        FamiliaresTableAdapter TAFamiliares;
        UsuariosTableAdapter TAUsuarios;
        TrabajadoresSocialesTableAdapter TATrabajadoresSociales;
        QTAFuncionesSistema TAFuncionesSistemas;
        PaisesTableAdapter TAPaises;
        DepartamentosTableAdapter TADepartamentos;
        LocalidadesTableAdapter TALocalidades;
        ProvinciasTableAdapter TAProvincias;
        ValoracionSocioeconomicaTableAdapter TAValoracionSocioEconomica;
        CategoriasTableAdapter TACategorias;


        DSTrabajo_Social.TrabajadoresSocialesDataTable DTTrabajadoresSociales;
        DSTrabajo_Social.PacientesDataTable DTPacientes;
        DSTrabajo_Social.InformesSocialesDataTable DTInformeSocial;
        DSTrabajo_Social.FamiliaresDataTable DTFamiliares;
        DSTrabajo_Social.UsuariosDataTable DTUsuarios;
        DSTrabajo_Social.PaisesDataTable DTPaises;
        DSTrabajo_Social.DepartamentosDataTable DTDepartamentos;
        DSTrabajo_Social.ProvinciasDataTable DTProvincias;
        DSTrabajo_Social.LocalidadesDataTable DTLocalidades;
        DSTrabajo_Social.CategoriasDataTable DTCategorias;
        
        String TipoOperacion = "";
        public int NumeroPacienteActual { get; set; }
        public int NumeroInformeSocialActual { get; set; }
        ErrorProvider eProviderInformeSocial;
        private int CodigoUsuario;
        private string CodigoCategoriaPaciente { get; set; }
		public DateTime FechaHoraValoracionSocioEconomica { get; set; }

        public FInformeSocial()
        {
            InitializeComponent();

            eProviderInformeSocial = new ErrorProvider();
            TAPacientes = new PacientesTableAdapter();
            TAInformeSocial = new InformesSocialesTableAdapter();
            TAFamiliares = new FamiliaresTableAdapter();
            TAUsuarios = new UsuariosTableAdapter();
            TATrabajadoresSociales = new TrabajadoresSocialesTableAdapter();
            TAFuncionesSistemas = new QTAFuncionesSistema();
            TAPaises = new PaisesTableAdapter();
            TADepartamentos = new DepartamentosTableAdapter();
            TAProvincias = new ProvinciasTableAdapter();
            TALocalidades = new LocalidadesTableAdapter();
            TAValoracionSocioEconomica = new ValoracionSocioeconomicaTableAdapter();
            TACategorias = new CategoriasTableAdapter();
            
            DTFamiliares = new DSTrabajo_Social.FamiliaresDataTable();
            DTCategorias = new DSTrabajo_Social.CategoriasDataTable();

            DTUsuarios = TAUsuarios.GetData();
            foreach (DataRow DRUsuarios in DTUsuarios.Select("TipoUsuario = 'A'"))
            {
                DTUsuarios.Rows.Remove(DRUsuarios);
            }
            DTUsuarios.Columns.Add("NombreCompleto");
            DTUsuarios.Columns["NombreCompleto"].Expression = String.Format("{0} +' ' + {1} + ' ' + {2}", DTUsuarios.NombreColumn.ColumnName, DTUsuarios.ApellidoPaternoColumn.ColumnName, DTUsuarios.ApellidoMaternoColumn.ColumnName);
            cBoxDeTrabSocial.DataSource = DTUsuarios;
            cBoxDeTrabSocial.DisplayMember = "NombreCompleto";
            cBoxDeTrabSocial.ValueMember = "CodigoUsuario";
            cBoxDeTrabSocial.SelectedIndex = -1;
            dtGVGrupoFamiliares.AutoGenerateColumns = false;
            
            cBoxGradoInstruccion.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaGradoInstruccion();
            cBoxGradoInstruccion.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxGradoInstruccion.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxGradoInstruccion.SelectedIndex = -1;
            dtGVSituacionSocioEconomica.AutoGenerateColumns = false;
            cargarDatosInformeSocial(-1, -1);
        }

        public void limpiarControles()
        {
            DTFamiliares.Clear();
            TxtAquien.Text = String.Empty;
            TxtCargoOcupacionalA.Text = String.Empty;
            //TxtCargoOcupacionalTrabSocial.Text = String.Empty;
            TxtDptoNacimiento.Text = String.Empty;
            TxtEdadPaciente.Text = String.Empty;
            TxtHClinicoPaciente.Text = String.Empty;
            TxtLocalidadNacimiento.Text = String.Empty;
            cBoxGradoInstruccion.SelectedIndex = -1;
            TxtNombreApellidoPacienteInforme.Text = String.Empty;
            TxtPacienteInformeSocial.Text = String.Empty;
            TxtPaisNacimiento.Text = String.Empty;
            TxtProvNacimiento.Text = String.Empty;
            TxtReferenciaInformeSocial.Text = String.Empty;
            rTextBoxAntecedentesPersonales.Text = String.Empty;
            rTextBoxDiagnoticoSocial.Text = String.Empty;
            rTextBoxReferenciaCaso.Text = String.Empty;
            rTextBoxSituacionActual.Text = String.Empty;
            rTextBoxSituacionInstitucional.Text = String.Empty;
            txtObservaciones.Text = String.Empty;
            dateFechaInformeSocial.Value = DateTime.Now;
            dateFechaNacimiento.Value = DateTime.Now;
            txtObservacionesComplementarias.Clear();

            cBoxDeTrabSocial.SelectedIndex = -1;
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            TxtAquien.ReadOnly = !estadoHabilitacion;
            TxtCargoOcupacionalA.ReadOnly = !estadoHabilitacion;
            cBoxDeTrabSocial.Enabled = estadoHabilitacion;
            TxtReferenciaInformeSocial.ReadOnly = !estadoHabilitacion;
            TxtPacienteInformeSocial.ReadOnly = !estadoHabilitacion;
            dateFechaInformeSocial.Enabled = estadoHabilitacion;

            rTextBoxAntecedentesPersonales.Enabled = estadoHabilitacion;
            rTextBoxDiagnoticoSocial.Enabled = estadoHabilitacion;
            rTextBoxReferenciaCaso.Enabled = estadoHabilitacion;
            txtObservaciones.ReadOnly = !estadoHabilitacion;
            rTextBoxSituacionActual.Enabled = estadoHabilitacion;
            rTextBoxSituacionInstitucional.Enabled = estadoHabilitacion;
            txtObservacionesComplementarias.ReadOnly = !estadoHabilitacion;
            btnModificarCategoria.Enabled = estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool eliminar, bool modificar, bool buscar, bool reportes)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardarInformeSocial.Enabled = aceptar;
            btnCancelar.Enabled = cancelar;
            btnEditarInformeSocial.Enabled = modificar;
            btnBuscarInformeSocial.Enabled = buscar;
            //btnVerInformeSocial.Enabled = btnImprimirInformeSocial.Enabled = reportes;
            btnEliminar.Enabled = eliminar;
        }

        public bool validarControles()
        {
            eProviderInformeSocial.Clear();
            if (String.IsNullOrEmpty(TxtAquien.Text))
            {
                tabControl1.SelectedTab = tabPage1;
                eProviderInformeSocial.SetError(TxtAquien, "No ha Ingresado a quién va dirigido");
                TxtAquien.Focus();
                return false;
            }
            if (cBoxDeTrabSocial.SelectedIndex < 0)
            {
                tabControl1.SelectedTab = tabPage1;
                eProviderInformeSocial.SetError(cBoxDeTrabSocial,"No ha seleccionado la Trabajadora Social");
                cBoxDeTrabSocial.Focus();
                return false;
            }
            //if(String.IsNullOrEmpty(TxtReferenciaInformeSocial.Text))
            //{
            //    tabControl1.SelectedTab = tabPage1;
            //    eProviderInformeSocial.SetError(TxtReferenciaInformeSocial, "No ha ingresado la Referencia del Informe");
            //    TxtReferenciaInformeSocial.Focus();
            //    return false;
            //}
            //if (String.IsNullOrEmpty(rTextBoxReferenciaCaso.Text))
            //{
            //    tabControl1.SelectedTab = tabPage1;
            //    eProviderInformeSocial.SetError(rTextBoxReferenciaCaso, "No ha Ingresado la Referencia del Caso");
            //    rTextBoxReferenciaCaso.Focus();
            //    return false;
            //}
            //if (String.IsNullOrEmpty(rTextBoxAntecedentesPersonales.Text))
            //{
            //    tabControl1.SelectedTab = tabPage3;
            //    eProviderInformeSocial.SetError(rTextBoxAntecedentesPersonales, "No ha Ingresado los Antecedentes Personales");
            //    rTextBoxAntecedentesPersonales.Focus();
            //    return false;
            //}

            //if (String.IsNullOrEmpty(rTextBoxSituacionInstitucional.Text))
            //{
            //    tabControl1.SelectedTab = tabPage4;
            //    eProviderInformeSocial.SetError(rTextBoxSituacionInstitucional, "No ha Ingresado la Situación Institucional");
            //    rTextBoxSituacionInstitucional.Focus();
            //    return false;
            //}

            //if (String.IsNullOrEmpty(rTextBoxSituacionActual.Text))
            //{
            //    tabControl1.SelectedTab = tabPage5;
            //    eProviderInformeSocial.SetError(rTextBoxSituacionActual, "No ha Ingresado la Situación Actual");
            //    rTextBoxSituacionActual.Focus();
            //    return false;
            //}

            //if (String.IsNullOrEmpty(rTextBoxDiagnoticoSocial.Text))
            //{
            //    tabControl1.SelectedTab = tabPage5;
            //    eProviderInformeSocial.SetError(rTextBoxDiagnoticoSocial, "No ha Ingresado el Diagnóstico Social");
            //    rTextBoxDiagnoticoSocial.Focus();
            //    return false;
            //}
            return true;
        }

        public void cargarProcedencia(int NumeroPacienteAux)
        {
            if (DTPacientes != null)
                DTPacientes = TAPacientes.GetDataBy11(NumeroPacienteAux);

            if (!DTPacientes[0].IsCodigoPaisNull())
            {
                TxtPaisNacimiento.Text = TAPaises.GetDataBy1(DTPacientes[0].CodigoPais)[0].NombrePais;
                if (!DTPacientes[0].IsCodigoDepartamentoNull())
                {
                    TxtDptoNacimiento.Text = TADepartamentos.GetDataBy1(DTPacientes[0].CodigoPais, DTPacientes[0].CodigoDepartamento)[0].NombreDepartamento;
                    if (!DTPacientes[0].IsCodigoProvinciaNull())
                    {
                        TxtProvNacimiento.Text = TAProvincias.GetDataBy1(DTPacientes[0].CodigoPais, DTPacientes[0].CodigoDepartamento, DTPacientes[0].CodigoProvincia)[0].NombreProvincia;
                        if (!DTPacientes[0].IsCodigoLocalidadNull())
                        {
                            TxtLocalidadNacimiento.Text = TALocalidades.GetDataBy1(DTPacientes[0].CodigoPais,
                                DTPacientes[0].CodigoDepartamento, DTPacientes[0].CodigoProvincia, DTPacientes[0].CodigoLocalidad)[0].NombreLocalidad;
                        }
                        else
                            TxtLocalidadNacimiento.Text = "";
                    }
                    else
                    {
                        TxtProvNacimiento.Text = "";
                        TxtLocalidadNacimiento.Text = "";
                    }
                }
                else
                {
                    TxtDptoNacimiento.Text = "";
                    TxtProvNacimiento.Text = "";
                    TxtLocalidadNacimiento.Text = "";
                }
            }
            else
            {
                TxtPaisNacimiento.Text = "";
                TxtDptoNacimiento.Text = "";
                TxtProvNacimiento.Text = "";
                TxtLocalidadNacimiento.Text = "";
            }
        }

        public void cargarDatosInformeSocial(int NumeroPaciente, int NumeroInformeSocial)
        {
            limpiarControles();
            DTInformeSocial = TAInformeSocial.GetDataBy1(NumeroPaciente, NumeroInformeSocial);
            if (DTInformeSocial.Count > 0)
            {
                this.NumeroInformeSocialActual = NumeroInformeSocial;
                this.NumeroPacienteActual = NumeroPaciente;

                DTPacientes = TAPacientes.GetDataBy11(NumeroPaciente);
                TxtNombreApellidoPacienteInforme.Text = string.Format("{0} {1} {2}", DTPacientes[0].Nombre, DTPacientes[0].ApellidoPaterno, DTPacientes[0].ApellidoMaterno);
                TxtPacienteInformeSocial.Text = string.Format("{0} {1} {2}", DTPacientes[0].Nombre, DTPacientes[0].ApellidoPaterno, DTPacientes[0].ApellidoMaterno);
                dateFechaNacimiento.Value = DTPacientes[0].FechaNacimiento;
                TxtEdadPaciente.Text = TAFuncionesSistemas.ObtenerEdadPaciente(NumeroPaciente).Value.ToString();
                if (DTPacientes[0].IsGradoInstruccionNull())
                    cBoxGradoInstruccion.SelectedIndex = -1;
                else
                    cBoxGradoInstruccion.SelectedValue = DTPacientes[0].GradoInstruccion;
                TxtHClinicoPaciente.Text = DTPacientes[0].IsHClinicoNull() ? String.Empty : DTPacientes[0].HClinico.ToString();

                if (DTInformeSocial[0].IsCodigoUsuarioNull())
                    cBoxDeTrabSocial.SelectedIndex = -1;
                else
                    cBoxDeTrabSocial.SelectedValue = DTInformeSocial[0].CodigoUsuario;


                cargarProcedencia(NumeroPaciente);

                TxtAquien.Text = DTInformeSocial[0].DirigidoA;
                TxtCargoOcupacionalA.Text = DTInformeSocial[0].OcupacionDirigidoA;
                TxtReferenciaInformeSocial.Text = DTInformeSocial[0].IsReferenciaNull() ? String.Empty : DTInformeSocial[0].Referencia;
                dateFechaInformeSocial.Value = DTInformeSocial[0].FechaISocial;
                rTextBoxReferenciaCaso.Text = DTInformeSocial[0].ReferenciaCaso;
                DTFamiliares = TAFamiliares.GetDataByPaciente(NumeroPaciente);
                dtGVGrupoFamiliares.DataSource = DTFamiliares;
                rTextBoxAntecedentesPersonales.Text = DTInformeSocial[0].AntecedentesPersonales;
                rTextBoxSituacionInstitucional.Text = DTInformeSocial[0].SituacionInstitucional;
                rTextBoxSituacionActual.Text = DTInformeSocial[0].SituacionActual;
                rTextBoxDiagnoticoSocial.Text = DTInformeSocial[0].DiagnosticoSocial;
                txtObservaciones.Text = DTInformeSocial[0].IsObservacionesNull() ? String.Empty : DTInformeSocial[0].Observaciones;
                cargarDatosSubvencion();
                habilitarBotones(true, false, true, true, true, true, true);
            }
            else
            {
                habilitarBotones(true, false, false, false, false, true, false);
            }
            habilitarControles(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FBusquedaPacientes formBuscarPacientes = new FBusquedaPacientes();
            if (formBuscarPacientes.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                limpiarControles();
                TipoOperacion = "I";
                NumeroPacienteActual = formBuscarPacientes.NumeroPaciente;

                DTPacientes = TAPacientes.GetDataBy11(NumeroPacienteActual);
                TxtNombreApellidoPacienteInforme.Text = string.Format("{0} {1} {2}", DTPacientes[0].Nombre, DTPacientes[0].ApellidoPaterno, DTPacientes[0].ApellidoMaterno);
                TxtPacienteInformeSocial.Text = string.Format("{0} {1} {2}", DTPacientes[0].Nombre, DTPacientes[0].ApellidoPaterno, DTPacientes[0].ApellidoMaterno);
                dateFechaNacimiento.Value = DTPacientes[0].FechaNacimiento;
                TxtEdadPaciente.Text = TAFuncionesSistemas.ObtenerEdadPaciente(NumeroPacienteActual).Value.ToString();
                if (DTPacientes[0].IsGradoInstruccionNull())
                    cBoxGradoInstruccion.SelectedIndex = -1;
                else
                    cBoxGradoInstruccion.SelectedValue = DTPacientes[0].GradoInstruccion;
                TxtHClinicoPaciente.Text = DTPacientes[0].IsHClinicoNull() ? String.Empty : DTPacientes[0].HClinico.ToString();

                
                cargarProcedencia(NumeroPacienteActual);

                DTFamiliares = TAFamiliares.GetDataByPaciente(NumeroPacienteActual);
                dtGVGrupoFamiliares.DataSource = DTFamiliares;

                cargarDatosSubvencion();

                NumeroInformeSocialActual = TAFuncionesSistemas.ObtenerSiguienteIdPacienteRelaciones(NumeroPacienteActual, "I").Value;
                habilitarControles(true);
                habilitarBotones(false, true, true, false, false, false, false);
            }
            else
            {
                MessageBox.Show(this, "Aún no ha Seleccionado ningún Paciente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void cargarDatosSubvencion()
        {
            double SubvencionInstitucional = 0;
            CodigoCategoriaPaciente = TAFuncionesSistemas.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPacienteActual, true);
            if (!String.IsNullOrEmpty(CodigoCategoriaPaciente))
            {
                DTCategorias = TACategorias.GetDataBy1(int.Parse(CodigoCategoriaPaciente));
                //SubvencionInstitucional = DTCategorias.FindByCodigoCategoria(DTPagosServicios[0].CodigoCategoria).SubvencionInstitucional;
                SubvencionInstitucional = DTCategorias[0].SubvencionInstitucional;
                txtCategoria.Text = DTCategorias[0].NombreCategoria;
                //txtSubvencionInstitucional.Text = SubvencionInstitucional.ToString();
            }
            else
            {
                SubvencionInstitucional = 0;
                txtCategoria.Text = string.Empty;
            }


            txtSubvencionInstitucional.Text = SubvencionInstitucional.ToString();
            dtGVSituacionSocioEconomica.DataSource = TAValoracionSocioEconomica.GetDataByNombreRespuesta(NumeroPacienteActual, null);
        }

        private void btnGuardarInformeSocial_Click(object sender, EventArgs e)
        {
            if (validarControles())
            {
                try
                {
                    
                    if (TipoOperacion == "I")
                    {
                        TAInformeSocial.Insert(NumeroPacienteActual, TxtAquien.Text, TxtCargoOcupacionalA.Text, TxtReferenciaInformeSocial.Text,
                            dateFechaInformeSocial.Value, rTextBoxReferenciaCaso.Text, rTextBoxAntecedentesPersonales.Text,
                            rTextBoxSituacionInstitucional.Text, rTextBoxSituacionActual.Text, rTextBoxDiagnoticoSocial.Text, int.Parse(cBoxDeTrabSocial.SelectedValue.ToString()), txtObservaciones.Text + ". " + txtObservacionesComplementarias.Text);
                    }
                    else
                    {
                        TAInformeSocial.ActualizarInformeSocial(NumeroPacienteActual, NumeroInformeSocialActual, TxtAquien.Text, TxtCargoOcupacionalA.Text, TxtReferenciaInformeSocial.Text,
                            dateFechaInformeSocial.Value, rTextBoxReferenciaCaso.Text, rTextBoxAntecedentesPersonales.Text,
                            rTextBoxSituacionInstitucional.Text, rTextBoxSituacionActual.Text, rTextBoxDiagnoticoSocial.Text, int.Parse(cBoxDeTrabSocial.SelectedValue.ToString()), txtObservaciones.Text + ". " + txtObservacionesComplementarias.Text);
                    }
                    MessageBox.Show(this, "Registro satisfactorio", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TipoOperacion = "";
                    habilitarBotones(true, false, false, true, true, true, true);
                    habilitarControles(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrió la siguiente Excepción " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "Existen campos que son considerados obligatorios", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnBuscarInformeSocial_Click(object sender, EventArgs e)
        {
            FBuscarPacientesOperaciones formBusqueda = new FBuscarPacientesOperaciones("I");
            if (formBusqueda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                NumeroInformeSocialActual = formBusqueda.NumeroOperacion;
                NumeroPacienteActual = formBusqueda.NumeroPaciente;
                cargarDatosInformeSocial(NumeroPacienteActual, NumeroInformeSocialActual);
            }
        }

        private void btnEditarInformeSocial_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            habilitarBotones(false, true, true, false, false, false, false);
            habilitarControles(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "";
            eProviderInformeSocial.Clear();
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false, true, false);
        }

        private void btnCerrarInformeSocial_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            FNivelSocioEconomico formNivelSocioEconomico = new FNivelSocioEconomico(TxtPacienteInformeSocial.Text,
                TipoOperacion, NumeroPacienteActual);
            if (formNivelSocioEconomico.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (formNivelSocioEconomico.DTRespuestasValoracion.Count > 0)
                {
                    DataSet DSValoracionSocioEconomica = new DataSet("ValoracionSocioEconomica");
                    DataTable DTAux = formNivelSocioEconomico.DTRespuestasValoracion.Clone();
                    foreach (DSTrabajo_Social.RespuestasValoracionRow DRRespuestas in formNivelSocioEconomico.DTRespuestasValoracion.Select("Seleccionar = True"))
                    {
                        DTAux.ImportRow(DRRespuestas);
                    }

                    DTAux.Columns.Remove(DTAux.Columns["NombreRespuestaValoracion"]);
                    DTAux.Columns.Remove(DTAux.Columns["Descripcion"]);
                    DTAux.TableName = "RespuestasValoracion";
                    DSValoracionSocioEconomica.Tables.Add(DTAux);
                    FechaHoraValoracionSocioEconomica = TAFuncionesSistemas.ObtenerFechaHoraServidor().Value;
                    TAValoracionSocioEconomica.InsertarActualizarValoracionSocioEconomicaXML(NumeroPacienteActual, FechaHoraValoracionSocioEconomica, DTAux.DataSet.GetXml());


                }
                cargarDatosSubvencion();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Se encuentra seguro de eliminar el registro actual?", this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                TAInformeSocial.Delete(NumeroPacienteActual, NumeroInformeSocialActual);
                limpiarControles();
                habilitarBotones(true, false, false, false, false, true, false);
            }
        }

        private void FInformeSocial_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimirInformeSocial_Click(object sender, EventArgs e)
        {
            ListarDatosPacienteReporteTableAdapter TAListarDatosPacienteReporte = new ListarDatosPacienteReporteTableAdapter();
            ObtenerFamiliaresTableAdapter TAObtenerFamiliares = new ObtenerFamiliaresTableAdapter();
            ObtenerInformeSocialTableAdapter TAObtenerInformeSocial = new ObtenerInformeSocialTableAdapter();
            FReporteFormulariosIndividuales formReporte = new FReporteFormulariosIndividuales();
            formReporte.ListarInformeSocialReporte(TAListarDatosPacienteReporte.GetData(NumeroPacienteActual), TAObtenerFamiliares.GetData(NumeroPacienteActual),
                TAObtenerInformeSocial.GetData(NumeroPacienteActual, NumeroInformeSocialActual));
            formReporte.ShowDialog();
            formReporte.Dispose();
        }
    }
}
