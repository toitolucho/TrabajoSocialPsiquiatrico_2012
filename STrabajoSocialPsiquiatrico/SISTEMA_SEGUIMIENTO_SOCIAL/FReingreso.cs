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
    public partial class FReingreso : Form
    {
        PacientesTableAdapter TAPacientes;
        ReingresosTableAdapter TAPacientesReingresos;
        QTAFuncionesSistema TAFuncionesSistema;
        ResponsablesTableAdapter TAResponsablesPaciente;
        PagoServicios2TableAdapter TAPagosServicios;
        ValoracionSocioeconomicaTableAdapter TAValoracionSocioEconomica;
        ListarPagosServiciosDetalleReporteTableAdapter TAPagosServiciosDetalle;
        CategoriasTableAdapter TACategorias;
        ServiciosTableAdapter TAServicios;
        ParentescosTableAdapter TAParentesco;
        DSTrabajo_Social.PacientesDataTable DTPacientes;
        DSTrabajo_Social.CategoriasDataTable DTCategorias;
        DSTrabajo_Social.ServiciosDataTable DTServicios;
        DSTrabajo_Social.ReingresosDataTable DTPacientesReingresos;
        DSTrabajo_Social.ResponsablesDataTable DTResponsablesPaciente;
        ErrorProvider eProviderReingreso = new ErrorProvider();
        private int NumeroPacienteActual;
        private int NumeroReingresoActual;
        private string TipoOperacion = "";
        private int CodigoPagoServicio = -1;
        private int CodigoUsuario;

        public FReingreso(int CodigoUsuario)
        {
            InitializeComponent();

            this.CodigoUsuario = CodigoUsuario;


            TAPacientes = new PacientesTableAdapter();
            TAFuncionesSistema = new QTAFuncionesSistema();
            TAPacientesReingresos = new ReingresosTableAdapter();
            TAResponsablesPaciente = new ResponsablesTableAdapter();
            TAParentesco = new ParentescosTableAdapter();
            TAPagosServicios = new PagoServicios2TableAdapter();
            TAValoracionSocioEconomica = new ValoracionSocioeconomicaTableAdapter();
            TACategorias = new CategoriasTableAdapter();
            TAServicios = new ServiciosTableAdapter();
            TAPagosServiciosDetalle = new ListarPagosServiciosDetalleReporteTableAdapter();

            DTPacientes = new DSTrabajo_Social.PacientesDataTable();
            DTPacientesReingresos = new DSTrabajo_Social.ReingresosDataTable();
            dtGVResponsables.AutoGenerateColumns = false;

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

            cargarDatosPacienteReingreso(-1, -1);
            btnNuevo.Visible = false;
            dtGVServicios.AutoGenerateColumns = false;
            txtIngresoEventual.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress);
            txtIngresoMensual.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress);
            dtGVServicios.DataError += new DataGridViewDataErrorEventHandler(dtGVServicios_DataError);
            //btnEditarReingreso.Text = "Completar Datos";
        }

        void dtGVServicios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        
        

        

        public void habilitarBotones(bool nuevo, bool editar, bool aceptar, bool buscar,bool cancelar, bool reportes)
        {
            btnNuevo.Enabled = nuevo;
            btnEditarReingreso.Enabled = editar;
            btnAceptarReingeso.Enabled = aceptar;
            btnBuscarReingreso.Enabled = buscar;
            btnCancelar.Enabled = cancelar;
            btnReporte.Enabled = reportes;
        }
        public void limpiarControles()
        {
            TxtNombrePacienteReingreso.Text = String.Empty;
            //TxtAsignaciónMensualDatAdmi.Text = string.Empty;            
            TxtDiagnosticoPsiquiatricoReingreso.Text = string.Empty;
            TxtEdadReingreso.Text = string.Empty;
            TxtHClinicoReingreso.Text = string.Empty;
            //TxtMedicacionReingreso.Text = string.Empty;
            TxtNombrePacienteReingreso.Text = string.Empty;
            TxtNumeroReingreso.Text = string.Empty;
            //TxtPasajeRetornoReingreso.Text = string.Empty;
            TxtSeccionReingreso.Text = string.Empty;
            txtDenominacion.Text = string.Empty;
            TxtTipoDiscapacidadReingreso.Text = string.Empty;
            txtNroFolio.Text = string.Empty;
            TxtUnidadReingreso.Text = string.Empty;
            dateFechaReingreso.Value = DateTime.Now;
            //TxtDenominacion.Text = string.Empty;

            cBoxPredisposicionTratPaciente.SelectedIndex = cBoxRelacionFamiliarPaciente.SelectedIndex = -1;
            rTextBoxAntecedentesReingreso.Text = string.Empty;
            rTextBoxObservacionesReingreso.Text = string.Empty;
            txtIngresoEventual.Text = txtIngresoMensual.Text = String.Empty;
            checkPacienteInstitucionalizado.Checked = false;
            if (dtGVServicios.DataSource != null)
            {
                (dtGVServicios.DataSource as DataTable).Clear();
            }
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            TxtNombrePacienteReingreso.ReadOnly = !estadoHabilitacion;
            //TxtAsignaciónMensualDatAdmi.ReadOnly = !estadoHabilitacion;
            //TxtMedicacionReingreso.ReadOnly = !estadoHabilitacion;
            ////TxtParentescoReingreso.ReadOnly = !estadoHabilitacion;
            //TxtPasajeRetornoReingreso.ReadOnly = !estadoHabilitacion;
            //TxtSeccionReingreso.ReadOnly = !estadoHabilitacion;
            TxtTipoDiscapacidadReingreso.ReadOnly = !estadoHabilitacion;
            txtNroFolio.ReadOnly = !estadoHabilitacion;
            //TxtUnidadReingreso.ReadOnly = !estadoHabilitacion;
            dateFechaReingreso.Enabled = estadoHabilitacion;

            cBoxPredisposicionTratPaciente.Enabled = cBoxRelacionFamiliarPaciente.Enabled = estadoHabilitacion;
            rTextBoxAntecedentesReingreso.Enabled = estadoHabilitacion;
            rTextBoxObservacionesReingreso.Enabled = estadoHabilitacion;
            btnModificarResponsable.Enabled = estadoHabilitacion;
            btnRegistroServicios.Enabled = estadoHabilitacion;
            txtIngresoMensual.ReadOnly = txtIngresoEventual.ReadOnly = !estadoHabilitacion;
            checkPacienteInstitucionalizado.Enabled = estadoHabilitacion;
            
        }

        public void cargarDatosPaciente(int NumeroPaciente)
        {
            DTPacientes = TAPacientes.GetDataBy11(NumeroPaciente);
            if (DTPacientes.Count > 0)
            {
                TxtNombrePacienteReingreso.Text = DTPacientes[0].Nombre.Trim() + " " + DTPacientes[0].ApellidoPaterno.Trim() + " " + DTPacientes[0].ApellidoMaterno.Trim();
                TxtEdadReingreso.Text =  string.Empty;
                TxtHClinicoReingreso.Text = DTPacientes[0].IsHClinicoNull() ? string.Empty : DTPacientes[0].HClinico.ToString();
                TxtDiagnosticoPsiquiatricoReingreso.Text = DTPacientes[0].IsDiagnosticoNull() ? string.Empty : DTPacientes[0].Diagnostico;
                TxtEdadReingreso.Text = TAFuncionesSistema.ObtenerEdadPaciente(NumeroPaciente).Value.ToString();
                checkPacienteInstitucionalizado.Checked =  !DTPacientes[0].IsPacienteInstitucionalizadoNull() && DTPacientes[0].PacienteInstitucionalizado;
                //TxtDenominacion.Text = DTPacientes[0].IsDenominacionNull() ? String.Empty : DTPacientes[0].Denominacion;
                DTResponsablesPaciente = TAResponsablesPaciente.GetDataByPaciente(NumeroPacienteActual,"V");
                dtGVResponsables.DataSource = DTResponsablesPaciente;
                //TxtParentescoReingreso.Text = DTPacientes[0].isc string.Empty;
                //TxtResponsableReingreso.Text = string.Empty;
                //TxtTelefonoReingreso.Text = DTPacientes[0]. string.Empty;
                //TxtCelularReingreso.Text = string.Empty;

                NumeroPacienteActual = NumeroPaciente;
                
            }
            else
            {
                limpiarControles();
            }
            habilitarControles(false);
        }

        public void cargarDatosPacienteReingreso(int NumeroPaciente, int NumeroReingreso)
        {
            limpiarControles();
            cargarDatosPaciente(NumeroPaciente);
            DTPacientesReingresos = TAPacientesReingresos.GetDataBy1(NumeroPaciente, NumeroReingreso);
            if (DTPacientesReingresos.Count > 0)
            {
                //TxtAsignaciónMensualDatAdmi.Text = DTPacientesReingresos[0].IsAsignacionMensualNull() ? String.Empty : DTPacientesReingresos[0].AsignacionMensual.ToString();
                //TxtMedicacionReingreso.Text = DTPacientesReingresos[0].IsMedicacionNull() ? string.Empty : DTPacientesReingresos[0].Medicacion;
                TxtNumeroReingreso.Text = DTPacientesReingresos[0].NumeroReingreso.ToString();
                //TxtPasajeRetornoReingreso.Text = DTPacientesReingresos[0].IsPasajeRetornoNull() ? string.Empty : DTPacientesReingresos[0].PasajeRetorno.ToString();
                TxtSeccionReingreso.Text = DTPacientesReingresos[0].IsSeccionNull() ? string.Empty : DTPacientesReingresos[0].Seccion;
                txtDenominacion.Text = DTPacientesReingresos[0].IsDenominacionNull() ? String.Empty : DTPacientesReingresos[0].Denominacion;
                TxtTipoDiscapacidadReingreso.Text = DTPacientesReingresos[0].IsTipoDiscapacidadNull() ? string.Empty : DTPacientesReingresos[0].TipoDiscapacidad;
                txtNroFolio.Text = DTPacientesReingresos[0].IsNumeroFolioNull() ? String.Empty : DTPacientesReingresos[0].NumeroFolio.ToString();
                TxtUnidadReingreso.Text = DTPacientesReingresos[0].IsUnidadNull() ? string.Empty : DTPacientesReingresos[0].Unidad.ToString();
                txtIngresoEventual.Text = DTPacientesReingresos[0].IsIngresoEventualNull() ? string.Empty : DTPacientesReingresos[0].IngresoEventual.ToString();
                txtIngresoMensual.Text = DTPacientesReingresos[0].IsIngresoMensualNull() ? string.Empty : DTPacientesReingresos[0].IngresoMensual.ToString();
                dateFechaReingreso.Value = DTPacientesReingresos[0].FechaReingreso;

                if (!DTPacientesReingresos[0].IsRelacionesFamiliaresNull())
                {
                    cBoxRelacionFamiliarPaciente.SelectedValue = DTPacientesReingresos[0].RelacionesFamiliares;
                }
                else
                {
                    cBoxRelacionFamiliarPaciente.SelectedIndex = -1;
                }

                if (!DTPacientesReingresos[0].IsPredisTratamientoNull())
                {
                    cBoxPredisposicionTratPaciente.SelectedValue = DTPacientesReingresos[0].PredisTratamiento;
                }
                else
                {
                    cBoxPredisposicionTratPaciente.SelectedIndex = -1;
                }

                dtGVServicios.DataSource = TAPagosServiciosDetalle.GetData(NumeroPacienteActual, NumeroReingreso, "R");                
                rTextBoxAntecedentesReingreso.Text = DTPacientesReingresos[0].IsAntecedentesNull() ? string.Empty : DTPacientesReingresos[0].Antecedentes;
                rTextBoxObservacionesReingreso.Text = DTPacientesReingresos[0].IsObservacionesNull() ? string.Empty : DTPacientesReingresos[0].Observaciones;
                habilitarBotones(true, true, false, true, true, true);
                NumeroReingresoActual = NumeroReingreso;
            }
            else
            {
                habilitarBotones(true, DTPacientesReingresos.Count > 0, false, true, false, false);
                cBoxPredisposicionTratPaciente.SelectedIndex = cBoxRelacionFamiliarPaciente.SelectedIndex = -1;
            }
            habilitarControles(false);
        }

        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(TxtUnidadReingreso.Text))
            {
                eProviderReingreso.SetError(TxtUnidadReingreso, "Aún no ha Ingresado la Unidad");
                TxtUnidadReingreso.Focus();
                TxtUnidadReingreso.SelectAll();
                return false;
            }
            if (String.IsNullOrEmpty(TxtSeccionReingreso.Text))
            {
                eProviderReingreso.SetError(TxtSeccionReingreso, "Aún no ha Ingresado la Sección");
                TxtSeccionReingreso.Focus();
                TxtSeccionReingreso.SelectAll();
                return false;
            }

            if(cBoxRelacionFamiliarPaciente.SelectedIndex < 0)
            {
                eProviderReingreso.SetError(cBoxRelacionFamiliarPaciente, "Aún no ha Ingresado el Tipo de Relación Familiar");
                cBoxRelacionFamiliarPaciente.Focus();                
                return false;
            }
            if (cBoxPredisposicionTratPaciente.SelectedIndex < 0)
            {
                eProviderReingreso.SetError(cBoxPredisposicionTratPaciente, "Aún no ha Ingresado la Predisposición al Tratamiento");
                cBoxPredisposicionTratPaciente.Focus();
                return false;
            }
            //double valor = -1;
            //if (String.IsNullOrEmpty(TxtAsignaciónMensualDatAdmi.Text))
            //{
            //    eProviderReingreso.SetError(TxtAsignaciónMensualDatAdmi, "Aún no ha ingresado la Asignación Mensual");
            //    TxtAsignaciónMensualDatAdmi.Focus();
            //    TxtAsignaciónMensualDatAdmi.SelectAll();
            //    return false;
            //}
            //if (!double.TryParse(TxtAsignaciónMensualDatAdmi.Text, out valor))
            //{
            //    eProviderReingreso.SetError(TxtAsignaciónMensualDatAdmi, "La Asignación Mensual se encuentra mal escrita");
            //    TxtAsignaciónMensualDatAdmi.Focus();
            //    TxtAsignaciónMensualDatAdmi.SelectAll();
            //    return false;
            //}
            //if (valor < 0)
            //{
            //    eProviderReingreso.SetError(TxtAsignaciónMensualDatAdmi, "La Asignación debe ser un entero Positivo");
            //    TxtAsignaciónMensualDatAdmi.Focus();
            //    TxtAsignaciónMensualDatAdmi.SelectAll();
            //    return false;
            //}
            //if (String.IsNullOrEmpty(TxtMedicacionReingreso.Text))
            //{
            //    eProviderReingreso.SetError(TxtMedicacionReingreso, "Aún no ha ingresado la Medicación");
            //    TxtMedicacionReingreso.Focus();
            //    TxtMedicacionReingreso.SelectAll();
            //    return false;
            //}


            //if (String.IsNullOrEmpty(TxtPasajeRetornoReingreso.Text))
            //{
            //    eProviderReingreso.SetError(TxtPasajeRetornoReingreso, "Aún no ha ingresado el monto correspondiente al Pasaje de Retorno");
            //    TxtPasajeRetornoReingreso.Focus();
            //    TxtPasajeRetornoReingreso.SelectAll();
            //    return false;
            //}
            //if (!double.TryParse(TxtPasajeRetornoReingreso.Text, out valor))
            //{
            //    eProviderReingreso.SetError(TxtPasajeRetornoReingreso, "El Pasaje de Retorno se encuentra mal escrito");
            //    TxtPasajeRetornoReingreso.Focus();
            //    TxtPasajeRetornoReingreso.SelectAll();
            //    return false;
            //}
            //if (valor < 0)
            //{
            //    eProviderReingreso.SetError(TxtPasajeRetornoReingreso, "El Pasaje de Retorno debe ser un entero Positivo");
            //    TxtPasajeRetornoReingreso.Focus();
            //    TxtPasajeRetornoReingreso.SelectAll();
            //    return false;
            //}

            int numeroCalle = -1;
            if (!String.IsNullOrEmpty(txtIngresoMensual.Text.Trim()) && !int.TryParse(txtIngresoMensual.Text, out numeroCalle))
            {

                eProviderReingreso.SetError(txtIngresoMensual, "El Ingreso Mensual se se encuentra mal escrita");
                txtIngresoMensual.Focus();
                txtIngresoMensual.SelectAll();
                return false;
            }

            if (!String.IsNullOrEmpty(txtIngresoEventual.Text.Trim()) && !int.TryParse(txtIngresoEventual.Text, out numeroCalle))
            {

                eProviderReingreso.SetError(txtIngresoEventual, "El Ingreso Mensual se se encuentra mal escrita");
                txtIngresoMensual.Focus();
                txtIngresoMensual.SelectAll();
                return false;
            }

            if(dtGVServicios.RowCount == 0)
            {
                eProviderReingreso.SetError(btnRegistroServicios, "Aún no ha ingresado ningún servicio");
                btnRegistroServicios.Focus();                
                return false;
            }

            return true;
        }

        private void btnBuscarReingreso_Click(object sender, EventArgs e)
        {
            FBuscarPacientesOperaciones formBuscarPaciente = new FBuscarPacientesOperaciones("R");
            formBuscarPaciente.ShowDialog();
            if (formBuscarPaciente.NumeroPaciente > 0)
            {
                NumeroPacienteActual = formBuscarPaciente.NumeroPaciente;
                cargarDatosPacienteReingreso(NumeroPacienteActual, formBuscarPaciente.NumeroOperacion);
            }
            formBuscarPaciente.Dispose();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtNombrePacienteReingreso.Text))
            {
                FBusquedaPacientes formPacientesbusqueda = new FBusquedaPacientes();
                formPacientesbusqueda.ShowDialog();
                if (formPacientesbusqueda.NumeroPaciente < 0)
                {
                    MessageBox.Show(this, "Aún no ha seleccionado ningún Paciente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                NumeroPacienteActual = formPacientesbusqueda.NumeroPaciente;
            }
            limpiarControles();
            //TxtAsignaciónMensualDatAdmi.Text = TxtPasajeRetornoReingreso.Text = "0.00";
            cargarDatosPaciente(NumeroPacienteActual);
            habilitarControles(true);
            habilitarBotones(false, false, true, false, true, false);
            TipoOperacion = "I";
        }

        private void btnEditarReingreso_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
            habilitarBotones(false, false, true, false, true, false);
            //TxtTipoDiscapacidadReingreso.Text = string.Empty;
            TipoOperacion = "E";
            btnRegistroServicios.Enabled = dtGVServicios.Rows.Count == 0;
            checkPacienteInstitucionalizado.Enabled = cBoxRelacionFamiliarPaciente.SelectedIndex < 0;
        }

        private void btnCerrarReingreso_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnAceptarReingeso_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                

                //bool TieneCategoria = !(String.IsNullOrEmpty(TAFuncionesSistema.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPacienteActual, true)));

                //if (MessageBox.Show(this, "Se registrará los Datos Administrativos. ¿El Paciente solicita una Subvención?",
                //                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                //{

                //    String Mensaje = TieneCategoria ?
                //        "El paciente ya tiene una Valoración Socioeconómica y una categoría Asignada. ¿Desea Modificar algún Dato?"
                //        : "El Paciente no cuenta con una Valoración Socioeconómica y una categoría Asignada. ¿Desea Registrarla?";
                //    if (MessageBox.Show(this, Mensaje,
                //        this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                //    {
                //        FNivelSocioEconomico formNivelSocioEconomico = new FNivelSocioEconomico(TxtNombrePacienteReingreso.Text,
                //        TipoOperacion, NumeroPacienteActual);
                //        if (formNivelSocioEconomico.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //        {
                //            String NombreCategoria = formNivelSocioEconomico.NombreCategoria;

                //            if (formNivelSocioEconomico.DTRespuestasValoracion.Count > 0)
                //            {
                //                DataSet DSValoracionSocioEconomica = new DataSet("ValoracionSocioEconomica");
                //                //DataTable DTAux = formNivelSocioEconomico.DTRespuestasValoracion.Select("Seleccionar = True").CopyToDataTable(DTAux,   .Copy();
                //                DataTable DTAux = formNivelSocioEconomico.DTRespuestasValoracion.Clone();
                //                foreach (DSTrabajo_Social.RespuestasValoracionRow DRRespuestas in formNivelSocioEconomico.DTRespuestasValoracion.Select("Seleccionar = True"))
                //                {
                //                    DTAux.ImportRow(DRRespuestas);
                //                }

                //                DTAux.Columns.Remove(DTAux.Columns["NombreRespuestaValoracion"]);
                //                DTAux.Columns.Remove(DTAux.Columns["Descripcion"]);
                //                DTAux.TableName = "RespuestasValoracion";
                //                DSValoracionSocioEconomica.Tables.Add(DTAux);

                //                TAValoracionSocioEconomica.InsertarActualizarValoracionSocioEconomicaXML(NumeroPacienteActual, DTAux.DataSet.GetXml());

                                
                //            }
                //        }

                        
                //    }
                    
                //    TieneCategoria = !(String.IsNullOrEmpty(TAFuncionesSistema.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPacienteActual, true)));
                //    //if(TieneCategoria)
                //    //{
                       
                //    //}

                    
                //}

                //FPagoServicio formPapeletaPago = new FPagoServicio("R");
                //formPapeletaPago.configurarFormularioIA(NumeroPacienteActual, null);
                //formPapeletaPago.ShowDialog();
                //this.rTextBoxObservacionesReingreso.Text = formPapeletaPago.TxtObservaciones.Text;
                //formPapeletaPago.Dispose();

                double IngresoMensual = -1, IngresoEvental = -1;

                DateTime FechaHoraServidor = TAFuncionesSistema.ObtenerFechaHoraServidor().Value;

                if (TipoOperacion == "I")
                {
                    TAPacientesReingresos.Insert(NumeroPacienteActual, int.Parse(TxtHClinicoReingreso.Text), FechaHoraServidor,
                        int.Parse(TxtUnidadReingreso.Text), TxtSeccionReingreso.Text, "A", TxtTipoDiscapacidadReingreso.Text,
                        rTextBoxAntecedentesReingreso.Text, cBoxRelacionFamiliarPaciente.SelectedValue.ToString(),
                        cBoxPredisposicionTratPaciente.SelectedValue.ToString(),
                        null, txtDenominacion.Text, (String.IsNullOrEmpty(txtNroFolio.Text) ? null : (int?)int.Parse(txtNroFolio.Text)),
                        double.TryParse(txtIngresoMensual.Text, out IngresoMensual) ? IngresoMensual : (double?)null ,
                        double.TryParse(txtIngresoEventual.Text, out IngresoEvental) ? IngresoEvental : (double?)null, 
                        rTextBoxObservacionesReingreso.Text);
                }
                else
                {
                    TAPacientesReingresos.ActualizarReingreso(NumeroPacienteActual, int.Parse(TxtNumeroReingreso.Text), int.Parse(TxtHClinicoReingreso.Text), FechaHoraServidor,
                        int.Parse(TxtUnidadReingreso.Text), TxtSeccionReingreso.Text, "A", TxtTipoDiscapacidadReingreso.Text,
                        rTextBoxAntecedentesReingreso.Text, cBoxRelacionFamiliarPaciente.SelectedValue.ToString(),
                        cBoxPredisposicionTratPaciente.SelectedValue.ToString(),
                        null, ( String.IsNullOrEmpty(txtNroFolio.Text) ? null : (int?)int.Parse(txtNroFolio.Text) ),
                        double.TryParse(txtIngresoMensual.Text, out IngresoMensual) ? IngresoMensual : (double?)null,
                        double.TryParse(txtIngresoEventual.Text, out IngresoEvental) ? IngresoEvental : (double?)null,
                        txtDenominacion.Text, rTextBoxObservacionesReingreso.Text);
                }


                if (checkPacienteInstitucionalizado.Checked)
                {
                    TAFuncionesSistema.ActualizarPacienteInstitucionalizacion(NumeroPacienteActual, FechaHoraServidor, CodigoUsuario, checkPacienteInstitucionalizado.Checked);
                }

                habilitarControles(false);
                habilitarBotones(true, true, false, true, false, true);
                MessageBox.Show(this,"Operación realizada satisfactoriamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            habilitarControles(false);
            TipoOperacion = "";
            habilitarBotones(true, false, false, true, false, false);
            TAPagosServicios.Delete(NumeroPacienteActual, CodigoPagoServicio);
        }

        private void btnModificarResponsable_Click(object sender, EventArgs e)
        {
            FFichaSocial f4 = new FFichaSocial(-1);
            f4.cargarDatosPaciente(NumeroPacienteActual);
            f4.HabilitarPestaniaSoloResponsable();
            if(dtGVResponsables.CurrentRow != null)
                f4.cargarDatosResponsables(NumeroPacienteActual, int.Parse(dtGVResponsables.CurrentRow.Cells["DGCCodigoResponsable"].Value.ToString()));
            f4.ShowDialog();            
            f4.Dispose();
            DTResponsablesPaciente = TAResponsablesPaciente.GetDataByPaciente(NumeroPacienteActual, "V");
            dtGVResponsables.DataSource = DTResponsablesPaciente;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void TxtTipoDiscapacidadReingreso_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistroServicios_Click(object sender, EventArgs e)
        {
			if (!TAFuncionesSistema.TienePacienteDatosCompleto(NumeroPacienteActual).Value)
            {
                MessageBox.Show(this, "No puede registrar las actividades para el paciente en este reingreso, debido a que aún no ha completado de llenar su Ficha Social ",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FPagoServicio formPagoServicio = new FPagoServicio("R", NumeroReingresoActual);
            formPagoServicio.configurarFormularioIA(NumeroPacienteActual, null);
            if (formPagoServicio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataTable DTServicios = formPagoServicio.DTServiciosDetalle;
                dtGVServicios.DataSource = DTServicios;

                //txtIngresoEventual.Text = formPagoServicio.txtIngresoEventual.Text;
                //txtIngresoMensual.Text = formPagoServicio.txtIngresoMensual.Text;
                btnRegistroServicios.Enabled = false;
            }
            else
            {
                TAPagosServicios.Delete(NumeroPacienteActual, formPagoServicio.NumeroPagoServicio);
            }
            CodigoPagoServicio = formPagoServicio.NumeroPagoServicio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FReporteFormulariosIndividuales formReporte = new FReporteFormulariosIndividuales();
            ListarDatosPacienteReporteTableAdapter TAListarDatosPacienteReporte = new ListarDatosPacienteReporteTableAdapter();
            formReporte.ListarReingresosReporte(TAListarDatosPacienteReporte.GetData(NumeroPacienteActual),
                TAPacientesReingresos.GetDataBy1(NumeroPacienteActual, NumeroReingresoActual),                
                TAResponsablesPaciente.GetDataByPaciente(NumeroPacienteActual, "V"),
                TAPagosServiciosDetalle.GetData(NumeroPacienteActual, NumeroReingresoActual, "R"));
            formReporte.ShowDialog();
            formReporte.Dispose();
        }

    }
}
