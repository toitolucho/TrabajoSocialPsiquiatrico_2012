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
    public partial class FPagoServicio : Form
    {
        PagoServicios2TableAdapter TAPagosServicios;
        PacientesTableAdapter TAPacientes;
        QTAFuncionesSistema TAFuncionesSistema;
        ServiciosTableAdapter TAServicios;        
        CategoriasTableAdapter TACategorias;
        ValoracionSocioeconomicaTableAdapter TAValoracionSocioEocnomica;
        ListarPagosServiciosDetalleReporteTableAdapter TAPagosServiciosDetalle;
        ValoracionSocioeconomicaTableAdapter TAValoracionSocioEconomica;

        DSTrabajo_Social.ServiciosDataTable DTServicios;
        public DSTrabajo_Social.ListarPagosServiciosDetalleReporteDataTable DTServiciosDetalle { get; set; }
        DSTrabajo_Social.ServiciosDataTable DTServiciosGrilla;
        DSTrabajo_Social.CategoriasDataTable DTCategorias;
        DSTrabajo_Social.PagoServicios2DataTable DTPagosServicios;
        string MensajeError;

        ErrorProvider eProviderPapeletaPago;
        String TipoOperacion = "";
        public int NumeroPaciente { get; set; }
        public int NumeroPagoServicio { get; set; }
        string CodigoCategoriaPaciente { get; set; }
        float SubvencionInstitucional;
        int? NumeroReingreso;
        string ClaseServicio = "S";
        DateTime? FechaHoraValoracionSocioEconomica; 

        public TextBox TxtObservaciones { get { return TxtObservacionesRecibo; } }

        public FPagoServicio(string ClaseServicio = "S", int NumeroReingreso = -1)
        {
            InitializeComponent();
            this.ClaseServicio = ClaseServicio;
            TAPagosServicios = new PagoServicios2TableAdapter();
            TAPacientes = new PacientesTableAdapter();
            TAFuncionesSistema = new QTAFuncionesSistema();
            TAServicios = new ServiciosTableAdapter();
            TAPagosServiciosDetalle = new ListarPagosServiciosDetalleReporteTableAdapter();
            TAValoracionSocioEconomica = new ValoracionSocioeconomicaTableAdapter();

            DTServiciosDetalle = new DSTrabajo_Social.ListarPagosServiciosDetalleReporteDataTable();
            if(NumeroReingreso != -1)
                this.NumeroReingreso = NumeroReingreso;
            TACategorias = new CategoriasTableAdapter();
            eProviderPapeletaPago = new ErrorProvider();
            TAValoracionSocioEocnomica = new ValoracionSocioeconomicaTableAdapter();

            

            DTCategorias = new DSTrabajo_Social.CategoriasDataTable();
            DTServicios = TAServicios.GetData();
            DTServiciosGrilla = (DSTrabajo_Social.ServiciosDataTable)DTServicios.Copy();
            cBoxServicios.DataSource = DTServicios;
            cBoxServicios.DisplayMember = "NombreServicio";
            cBoxServicios.ValueMember = "CodigoServicio";
            cBoxServicios.SelectedIndex = -1;


            DGCCodigoCategoria.DataSource = TACategorias.GetData();
            DGCCodigoCategoria.DisplayMember = "NombreCategoria";
            DGCCodigoCategoria.ValueMember = "CodigoCategoria";
            DGCCodigoCategoria.DataPropertyName = "CodigoCategoria";

            
            DGCNombreServicio.DataSource = DTServiciosGrilla;
            DGCNombreServicio.DisplayMember = "NombreServicio";
            DGCNombreServicio.ValueMember = "CodigoServicio";
            DGCNombreServicio.DataPropertyName = "CodigoServicio";

            cBoxTipoServicio.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaTiposServicios();
            cBoxTipoServicio.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxTipoServicio.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxTipoServicio.SelectedIndex = -1;

            cBoxClaseServicio.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaClasesServicios();
            cBoxClaseServicio.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxClaseServicio.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxClaseServicio.SelectedIndex = -1;

            dtGVServicios.AutoGenerateColumns = false;
            bdSourceServicios.DataSource = DTServiciosDetalle;
            bdNavServicios.BindingSource = bdSourceServicios;
            dtGVServicios.DataSource = bdSourceServicios;

            this.StartPosition = FormStartPosition.CenterScreen;

            txtIngresoEventual.KeyPress += Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress;
            txtIngresoMensual.KeyPress += Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress;
            txtNroPapeleta.KeyPress += Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress;
            txtMontoPagoCategoriaZ.KeyPress += Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress;
            txtDirigidoA.CharacterCasing = CharacterCasing.Upper;
            dtGVSituacionSocioEconomica.AutoGenerateColumns = false;
            cargarDatosPapeletaPago(-1 ,-1);

            if (ClaseServicio.Equals("S"))
            {
                txtIngresoEventual.Visible = txtIngresoMensual.Visible = checkPacienteInstitucionalizado.Visible = false;
                lblIngresoEventual.Visible = lblIngresoMensual.Visible = false;
            }

            txtIngresoEventual.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress);
            txtIngresoMensual.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress);
            DGCSubvencion.ReadOnly = true;
            checkCategoriaZ.Visible = false;
        }

        public void configurarFormularioIA(int? NumeroPaciente, int? CodigoPagoServicio)
        {
            limpiarControles();
            string NombreCategoria = string.Empty;
            if (NumeroPaciente != null && CodigoPagoServicio == null)
            {
                cargardDatosPaciente(NumeroPaciente.Value);
            }
            else if (NumeroPaciente != null && CodigoPagoServicio != null)
            {
                cargarDatosPapeletaPago(CodigoPagoServicio.Value, NumeroPaciente.Value);
            }

            this.NumeroPaciente = NumeroPaciente.Value;
            CodigoCategoriaPaciente = TAFuncionesSistema.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPaciente, true);

            if (!String.IsNullOrEmpty(CodigoCategoriaPaciente))
            {
                DTCategorias = TACategorias.GetDataBy1(int.Parse(CodigoCategoriaPaciente));
                SubvencionInstitucional = DTCategorias.FindByCodigoCategoria(int.Parse(CodigoCategoriaPaciente)).SubvencionInstitucional;
                NombreCategoria = TAFuncionesSistema.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPaciente, false); 
            }
            else
            {
                SubvencionInstitucional = 0;
            }

        

            
            txtCategoria.Text = NombreCategoria;
            txtSubvencionInstitucional.Text = SubvencionInstitucional.ToString();

            dtGVSituacionSocioEconomica.DataSource = TAValoracionSocioEocnomica.GetDataByNombreRespuesta(NumeroPaciente, null);
            cBoxClaseServicio.SelectedValue = ClaseServicio;

            habilitarControles(true);
            TipoOperacion = "I";
            habilitarBotones(false, true, false, false, false, false);
            btnImprimirPapeletaPago.Visible = false;
            txtNroPapeleta.Focus();

            int? CodigoPagoAux = -1;
            
            CodigoPagoAux = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(NumeroPaciente, "P");
            tsLblNumeroPago.Text = (CodigoPagoAux).ToString();
            tsLblFechaRegistro.Text = TAFuncionesSistema.ObtenerFechaHoraServidor().ToString();
            DTServiciosDetalle.Clear();
            txtNroPapeleta.Focus();
            txtNroPapeleta.Text = TAFuncionesSistema.ObtenerCodigoPagoServicioGenerado();
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("PagoServicios", ref CodigoPagoAux);
            this.NumeroPagoServicio = CodigoPagoAux.Value + 1;
            //txtNroPapeleta.Text = "1";
            //txtDirigidoA.Text = "Servicios por Ingresos o Reingresos";
            //lblNroPapeleta.Visible = txtNroPapeleta.Visible = txtDirigidoA.Visible = lblDirigidoA.Visible = false;
            //lblObservaciones.Visible = TxtObservacionesRecibo.Visible = false;

            lblIngresoEventual.Visible = lblIngresoMensual.Visible = txtIngresoEventual.Visible = txtIngresoMensual.Visible = checkPacienteInstitucionalizado.Visible = false;
            
            DTServiciosDetalle.RowChanged += new DataRowChangeEventHandler(DTServiciosDetalle_RowChanged);
        }

        public void limpiarControles()
        {
            eProviderPapeletaPago.Clear();
            txtCostoServicio.Text = txtPrecioSubTotal.Text = txtPrecioTotal.Text = txtSubvencionTotal.Text = "0.00";
            txtCategoria.Text = txtDirigidoA.Text = txtNombreCompletoPaciente.Text = txtIngresoEventual.Text = txtIngresoMensual.Text =
                txtNombreCompletoPaciente.Text = txtNroPapeleta.Text = TxtObservacionesRecibo.Text =
                TxtEdadPaciente.Text = txtSubvencionInstitucional.Text = String.Empty;

            tsLblFechaRegistro.Text = "00-00-00"; tsLblNumeroPago.Text = " ";
            tsLblNumeroPapeleta.Text = "  ";

            cBoxClaseServicio.SelectedIndex = cBoxServicios.SelectedIndex = cBoxTipoServicio.SelectedIndex = -1;
            checkCategoriaZ.Checked = checkPacienteInstitucionalizado.Checked = false;
            MensajeError = string.Empty;

            lblPagoCatZ.Visible = txtMontoPagoCategoriaZ.Visible = false;

            if ((dtGVSituacionSocioEconomica.DataSource as DataTable) != null)
                (dtGVSituacionSocioEconomica.DataSource as DataTable).Clear();
        }

        public void cargardDatosPaciente(int NumeroPaciente)
        {
            this.NumeroPaciente = NumeroPaciente;
            String NombreCategoria = String.Empty;
            CodigoCategoriaPaciente = TAFuncionesSistema.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPaciente, true);
            
            limpiarControles();
            if (!String.IsNullOrEmpty(CodigoCategoriaPaciente))
            {
                DTCategorias = TACategorias.GetDataBy1(int.Parse(CodigoCategoriaPaciente));
                NombreCategoria = TAFuncionesSistema.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPaciente, false);
                //txtCategoria.Text = NombreCategoria;
                //txtSubvencionInstitucional.Text = DTCategorias.FindByCodigoCategoria(int.Parse(CodigoCategoriaPaciente)).SubvencionInstitucional.ToString();
                SubvencionInstitucional = DTCategorias.FindByCodigoCategoria(int.Parse(CodigoCategoriaPaciente)).SubvencionInstitucional;
                
            }
            else
            {
                txtCategoria.Text = txtSubvencionInstitucional.Text = String.Empty;
                SubvencionInstitucional = 0;

            }
            txtSubvencionInstitucional.Text = SubvencionInstitucional.ToString();
            txtNombreCompletoPaciente.Text = TAFuncionesSistema.ObtenerNombreCompleto(this.NumeroPaciente);
            TxtEdadPaciente.Text = TAFuncionesSistema.ObtenerEdadPaciente(NumeroPaciente).Value.ToString();


            
            txtCategoria.Text = NombreCategoria;

            dtGVSituacionSocioEconomica.DataSource = TAValoracionSocioEocnomica.GetDataByNombreRespuesta(NumeroPaciente, null);


            habilitarControles(true);
            TipoOperacion = "I";
            habilitarBotones(false, true, true, false, false, false);
            txtNroPapeleta.Focus();

            int? CodigoPagoAux = -1;
            //TAFuncionesSistema.ObtenerUltimoIndiceTabla("PagoServicios", ref CodigoPagoAux);
            CodigoPagoAux = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(NumeroPaciente, "P");
            tsLblNumeroPago.Text = (++CodigoPagoAux).ToString();
            txtNroPapeleta.Text = TAFuncionesSistema.ObtenerCodigoPagoServicioGenerado();
            cBoxClaseServicio.SelectedValue = "S";
            DTServiciosDetalle.RowChanged += new DataRowChangeEventHandler(DTServiciosDetalle_RowChanged);
        }

        public void cargarDatosPapeletaPago(int NumeroPagoServicio, int NumeroPaciente)
        {
            limpiarControles(); 
            DTPagosServicios = TAPagosServicios.GetDataBy2(NumeroPaciente, NumeroPagoServicio);
            if (DTPagosServicios.Count > 0)
            {
                this.NumeroPagoServicio = NumeroPagoServicio;
                this.NumeroPaciente = NumeroPaciente;
                NumeroPagoServicio = DTPagosServicios[0].NumeroPagoServicio;

                txtDirigidoA.Text = DTPagosServicios[0].NombreSubvencionA;
                txtNombreCompletoPaciente.Text = TAFuncionesSistema.ObtenerNombreCompleto(this.NumeroPaciente);
                TxtEdadPaciente.Text = TAFuncionesSistema.ObtenerEdadPaciente(this.NumeroPaciente).Value.ToString();

                //txtNroPapeleta.Text = DTPagosServicios[0].NumeroPapeleta.ToString();
                txtNroPapeleta.Text = DTPagosServicios[0].CodigoPagoServicio;
                cBoxTipoServicio.SelectedValue = DTPagosServicios[0].TipoServicio;

                DTServiciosDetalle = TAPagosServiciosDetalle.GetData(NumeroPaciente, NumeroPagoServicio, ClaseServicio);
                bdSourceServicios.DataSource = DTServiciosDetalle;
                dtGVServicios.DataSource = bdSourceServicios;
                cBoxClaseServicio.SelectedValue = DTPagosServicios[0].CodigoClaseServicio;
                txtIngresoEventual.Text = DTPagosServicios[0].IsIngresoPacienteEventualNull() ? "" : DTPagosServicios[0].IngresoPacienteEventual.ToString();
                txtIngresoMensual.Text = DTPagosServicios[0].IsIngresoPacienteMensualNull() ? "" : DTPagosServicios[0].IngresoPacienteMensual.ToString();
                checkCategoriaZ.Checked = (!DTPagosServicios[0].IsCategoriaZNull() && DTPagosServicios[0].CategoriaZ);
                //checkPacienteInstitucionalizado.Checked = (!DTPagosServicios[0].IsPacienteInstitucionalizadoNull() && DTPagosServicios[0].PacienteInstitucionalizado);
                //checkPacienteInstitucionalizado.Visible = (!DTPagosServicios[0].IsPacienteInstitucionalizadoNull() && DTPagosServicios[0].PacienteInstitucionalizado);
                DSTrabajo_Social.PacientesDataTable DTPacientes = TAPacientes.GetDataBy11(NumeroPaciente);
                checkPacienteInstitucionalizado.Visible = checkPacienteInstitucionalizado.Checked =
                    !DTPacientes[0].IsPacienteInstitucionalizadoNull()
                    && DTPacientes[0].PacienteInstitucionalizado;

                TxtObservacionesRecibo.Text = DTPagosServicios[0].IsObservacionesNull() ? "" : DTPagosServicios[0].Observaciones;
                tsLblFechaRegistro.Text = DTPagosServicios[0].FechaSubvencion.ToString();
                //tsLblNumeroPago.Text = DTPagosServicios[0].CodigoPagoServicio.ToString();                
                //tsLblNumeroPapeleta.Text = DTPagosServicios[0].NumeroPapeleta.ToString();
                tsLblNumeroPago.Text = DTPagosServicios[0].NumeroPapeleta.ToString();
                tsLblNumeroPapeleta.Text = DTPagosServicios[0].CodigoPagoServicio.ToString();
                CodigoCategoriaPaciente = DTPagosServicios[0].IsCodigoCategoriaNull() ? String.Empty : DTPagosServicios[0].CodigoCategoria.ToString();
                if (!String.IsNullOrEmpty(CodigoCategoriaPaciente))
                {
                    DTCategorias = TACategorias.GetDataBy1(DTPagosServicios[0].CodigoCategoria);
                    //SubvencionInstitucional = DTCategorias.FindByCodigoCategoria(DTPagosServicios[0].CodigoCategoria).SubvencionInstitucional;
                    SubvencionInstitucional = int.Parse(DTPagosServicios[0] ["PorcentajeSubvencion"].ToString() ?? "0");
                    txtCategoria.Text = DTCategorias[0].NombreCategoria;
                    //txtSubvencionInstitucional.Text = SubvencionInstitucional.ToString();
                }
                else
                {
                    SubvencionInstitucional = 0;
                }


                txtSubvencionInstitucional.Text = SubvencionInstitucional.ToString();
                dtGVSituacionSocioEconomica.DataSource = TAValoracionSocioEocnomica.GetDataByNombreRespuesta(NumeroPaciente, null);

                string MontoPagoSubTotal = DTServiciosDetalle.Compute("Sum(CostoServicio)", "").ToString();
                string Subvencion = DTServiciosDetalle.Compute("Sum(MontoSubvencion)", "").ToString();
                string MontoPagoReal = DTServiciosDetalle.Compute("Sum(MontoCancelado)", "").ToString();

                txtPrecioSubTotal.Text = (!String.IsNullOrEmpty(MontoPagoSubTotal) ? MontoPagoSubTotal : "0.00");
                txtSubvencionTotal.Text = (!String.IsNullOrEmpty(Subvencion) ? Subvencion : "0.00");
                txtPrecioTotal.Text = (!String.IsNullOrEmpty(MontoPagoReal) ? MontoPagoReal : "0.00");

                
                lblPagoCatZ.Visible = txtMontoPagoCategoriaZ.Visible = !DTPagosServicios[0].IsCategoriaZNull() &&  DTPagosServicios[0].CategoriaZ;
                txtMontoPagoCategoriaZ.Text = DTPagosServicios[0].IsMontoPagadoNull() ? "0.00" : DTPagosServicios[0].MontoPagado.ToString();
                
                habilitarBotones(true, false, true, true, true, true);
            }
            else
            {
                dtGVSituacionSocioEconomica.DataSource = null;
                habilitarBotones(true, false, false, false, false, true);
            }
            habilitarControles(false);
        }


        public void habilitarControles(bool estadoHabilitacion)
        {

            txtDirigidoA.ReadOnly = txtIngresoEventual.ReadOnly = txtIngresoMensual.ReadOnly = TxtObservacionesRecibo.ReadOnly = !estadoHabilitacion;
            //txtNroPapeleta.ReadOnly = 
            cBoxServicios.Enabled = cBoxTipoServicio.Enabled = estadoHabilitacion;
            checkCategoriaZ.Enabled = estadoHabilitacion;
            bindingNavigatorDeleteItem.Visible = estadoHabilitacion;
            btnAñadirServicio.Enabled = btnAgregarServicio.Enabled = estadoHabilitacion;
            dtGVServicios.ReadOnly = !estadoHabilitacion;
            btnAgregarServicio.Enabled = estadoHabilitacion;
            btnModificarCategoria.Enabled = estadoHabilitacion;
            txtIngresoEventual.ReadOnly = txtIngresoMensual.ReadOnly = !estadoHabilitacion;
        }


        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool modificar, bool eliminar, bool buscar)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardarPapeletaPago.Enabled = aceptar;
            btnCancelar.Enabled = cancelar;
            btnModificar.Enabled = modificar;
            btnEliminar.Enabled = eliminar;
            btnBuscarPapeletaPago.Enabled = buscar;
        }

        public bool validarControles()
        {

            MensajeError = string.Empty;
            eProviderPapeletaPago.Clear();            
            if (string.IsNullOrEmpty(txtNroPapeleta.Text))
            {                
                MensajeError = MensajeError + "\nAún no ha ingresado el Número de Recibo";
                eProviderPapeletaPago.SetError(txtNroPapeleta, "Aún no ha ingresado el Número de Recibo");
                txtNroPapeleta.Focus();                
            }
            int numero = -1;
            if (!int.TryParse(txtNroPapeleta.Text, out numero))
            {
                eProviderPapeletaPago.SetError(txtNroPapeleta, "El número de Recibo se encuentra mal Escrito");
                MensajeError = MensajeError + "\nEl número de Recibo se encuentra mal Escrito";
                txtNroPapeleta.Focus();                
            }

            if (string.IsNullOrEmpty(txtDirigidoA.Text))
            {
                MensajeError = MensajeError + "\nAún no ha ingresado el nombre de la Persona a quien va dirigido la Papeleta";
                eProviderPapeletaPago.SetError(txtDirigidoA, "Aún no ha ingresado el nombre de la Persona a quien va dirigido la Papeleta");
                txtDirigidoA.Focus();                
            }

            if (cBoxTipoServicio.SelectedIndex < 0)
            {
                MensajeError = MensajeError + "\nAún no ha seleccionado el Tipo de Servicio";
                eProviderPapeletaPago.SetError(cBoxTipoServicio, "Aún no ha seleccionado el Tipo de Servicio");
                cBoxTipoServicio.Focus();                
            }

            double monto = -1;
            if (String.IsNullOrEmpty(txtMontoPagoCategoriaZ.Text))
            {
                MensajeError = MensajeError + "\nAún no ha ingresado el Monto que debe cancelar el paciente dentro de la Categoria Z";
                eProviderPapeletaPago.SetError(txtMontoPagoCategoriaZ, "Aún no ha ingresado el Monto que debe cancelar el paciente dentro de la Categoria Z");
                txtMontoPagoCategoriaZ.Focus();    
            }

            if (!double.TryParse(txtMontoPagoCategoriaZ.Text, out monto))
            {
                MensajeError = MensajeError + "\nEl Monto que debe cancelar el paciente dentro de la Categoria Z se encuentra mal escrito";
                eProviderPapeletaPago.SetError(txtMontoPagoCategoriaZ, "El Monto que debe cancelar el paciente dentro de la Categoria Z se encuentra mal escrito");
                txtMontoPagoCategoriaZ.Focus(); 
            }

            if (dtGVServicios.Rows.Count <= 0)
            {
                MensajeError = MensajeError + "\nAún no ha seleccionado ningun Servicio";
                eProviderPapeletaPago.SetError(gBoxDatosPagoServicioDetalle, "Aún no ha seleccionado ningun Servicio");
                gBoxDatosPagoServicioDetalle.Focus();                
            }
           
            //if (checkBox1.Checked)
            //{
            //    if (string.IsNullOrEmpty(txtMontoLibrePago.Text))
            //    {
            //        eProviderPapeletaPago.SetError(txtMontoLibrePago, "Aún no ha ingresado el Monto Libre de Pago");
            //        txtMontoLibrePago.Focus();
            //        txtMontoLibrePago.SelectAll();
            //        return false;
            //    }

            //    double monto = -1;
            //    if (!double.TryParse(txtMontoLibrePago.Text, out monto))
            //    {
            //        eProviderPapeletaPago.SetError(txtMontoLibrePago, "El Monto Libre de Pago ingresado se encuentra mal escrito");
            //        txtMontoLibrePago.Focus();
            //        txtMontoLibrePago.SelectAll();
            //        return false;
            //    }
            //}
            return String.IsNullOrEmpty(MensajeError);
        }

        private void btnAñadirServicio_Click(object sender, EventArgs e)
        {
            FAñadirServicioBrindado formServicios = new FAñadirServicioBrindado();
            formServicios.configurarFormularioIA(null);
            formServicios.Visible = false;
            if (formServicios.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                DTServicios.FindByCodigoServicio(formServicios.CodigoServicio) == null)
            {
                DSTrabajo_Social.ServiciosDataTable DTServicioAux = TAServicios.GetDataBy1(formServicios.CodigoServicio);
                if (DTServicioAux.Count > 0)
                {
                    DTServicios.Rows.Add(DTServicioAux[0].ItemArray);
                    DTServicios.DefaultView.Sort = "NombreServicio ASC";

                    DTServiciosGrilla.Rows.Add(DTServicioAux[0].ItemArray);
                    DTServiciosGrilla.DefaultView.Sort = "NombreServicio ASC";

                    cBoxServicios.SelectedValue = formServicios.CodigoServicio;
                }
            }
            formServicios.Dispose();
        }

        private void cBoxServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxServicios.SelectedIndex >= 0)
            {
                txtCostoServicio.Text = (cBoxServicios.SelectedItem as DataRowView)["Precio"].ToString();
            }
            else
                txtCostoServicio.Text = "0.00";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FBusquedaPacientes formBuscarPacientes = new FBusquedaPacientes();
            if (formBuscarPacientes.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                NumeroPaciente = formBuscarPacientes.NumeroPaciente;
                CodigoCategoriaPaciente = TAFuncionesSistema.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPaciente, true);

                if (!String.IsNullOrEmpty(CodigoCategoriaPaciente))
                {
                    DTCategorias = TACategorias.GetDataBy1(int.Parse(CodigoCategoriaPaciente));
                    SubvencionInstitucional = DTCategorias.FindByCodigoCategoria(int.Parse(CodigoCategoriaPaciente)).SubvencionInstitucional;
                }
                else
                {
                    SubvencionInstitucional = 0;
                }
                


                limpiarControles();

                
                txtNombreCompletoPaciente.Text = String.Format("{0} {1} {2}", formBuscarPacientes.DRPacienteSeleccionado.Nombre, formBuscarPacientes.DRPacienteSeleccionado.ApellidoPaterno, formBuscarPacientes.DRPacienteSeleccionado.ApellidoMaterno);
                TxtEdadPaciente.Text = TAFuncionesSistema.ObtenerEdadPaciente(NumeroPaciente).Value.ToString();
                string NombreCategoria = TAFuncionesSistema.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPaciente, false);
                txtCategoria.Text = String.IsNullOrEmpty(NombreCategoria) ? "" : NombreCategoria;
                txtSubvencionInstitucional.Text = SubvencionInstitucional.ToString();

                dtGVSituacionSocioEconomica.DataSource = TAValoracionSocioEocnomica.GetDataByNombreRespuesta(NumeroPaciente, null);


                habilitarControles(true);
                TipoOperacion = "I";
                habilitarBotones(false, true, true, false, false, false);
                txtNroPapeleta.Focus();
                DGCSubvencion.ReadOnly = true;
                int? CodigoPagoAux = -1;
                
                CodigoPagoAux = TAFuncionesSistema.ObtenerSiguienteIdPacienteRelaciones(NumeroPaciente, "P");
                tsLblNumeroPago.Text = (CodigoPagoAux).ToString();
                tsLblFechaRegistro.Text = TAFuncionesSistema.ObtenerFechaHoraServidor().ToString();
                DTServiciosDetalle.Clear();
                txtNroPapeleta.Text = TAFuncionesSistema.ObtenerCodigoPagoServicioGenerado();

                TAFuncionesSistema.ObtenerUltimoIndiceTabla("PagoServicios", ref CodigoPagoAux);
                this.NumeroPagoServicio = CodigoPagoAux.Value + 1;
                
                //dtGVServicios.AutoGenerateColumns = false;
                //bdSourceServicios.DataSource = DTServiciosDetalle;
                //dtGVServicios.DataSource = bdSourceServicios;

                txtNroPapeleta.Focus();                
                //DTServiciosDetalle.MontoPagadoColumn.Expression = "(CostoServicio * " + (100 - SubvencionInstitucional).ToString() + "/100) * Cantidad";
                //DTServiciosDetalle.PrecioTotalRealColumn.Expression = "Cantidad * CostoServicio";
                //DTServiciosDetalle.MontoSubvencionColumn.Expression = "PrecioTotalReal - MontoPagado";
                DTServiciosDetalle.RowChanged += new DataRowChangeEventHandler(DTServiciosDetalle_RowChanged);
                cBoxClaseServicio.SelectedValue = "S";
                DSTrabajo_Social.PacientesDataTable DTPacientes = TAPacientes.GetDataBy11(NumeroPaciente);
                checkPacienteInstitucionalizado.Visible = checkPacienteInstitucionalizado.Checked =
                    !DTPacientes[0].IsPacienteInstitucionalizadoNull()
                    && DTPacientes[0].PacienteInstitucionalizado;
            }
            else
            {
                MessageBox.Show(this, "Aún no ha seleccionado ningun Paciente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void DTServiciosDetalle_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (!String.IsNullOrEmpty(TipoOperacion))
            {
                string MontoPagoSubTotal = DTServiciosDetalle.Compute("Sum(CostoServicio)", "").ToString();//CostoServicio
                string Subvencion = DTServiciosDetalle.Compute("Sum(MontoSubvencion)", "").ToString();
                string MontoPagoReal = DTServiciosDetalle.Compute("Sum(MontoCancelado)", "").ToString();

                txtPrecioSubTotal.Text = (!String.IsNullOrEmpty(MontoPagoSubTotal) ? MontoPagoSubTotal : "0.00");
                txtSubvencionTotal.Text = (!String.IsNullOrEmpty(Subvencion) ? Subvencion : "0.00");
                txtPrecioTotal.Text = (!String.IsNullOrEmpty(MontoPagoReal) ? MontoPagoReal : "0.00");
            }
        }

        private void btnGuardarPapeletaPago_Click(object sender, EventArgs e)
        {
            if (validarControles())
            {
                try
                {
                    //NumeroPagoServicio = int.Parse(tsLblNumeroPago.Text);
                    
                    DataSet DSServiciosDetalle = new DataSet("PagoServicios");
                    DataTable DTAuxiliar = DTServiciosDetalle.Copy();
                    DTAuxiliar.TableName = "PagoServiciosDetalle";
                    DSServiciosDetalle.Tables.Add(DTAuxiliar);
                    DSServiciosDetalle.Tables[0].Constraints.Clear();
                    DSServiciosDetalle.Tables[0].Columns.Remove(DSServiciosDetalle.Tables[0].Columns["NombreServicio"]);
                    string DetalleXML = DSServiciosDetalle.GetXml();
                    this.cBoxClaseServicio.SelectedValue = ClaseServicio;

                    double MontoMensual = -1, MontoEventual = -1;
                    double.TryParse(txtIngresoMensual.Text, out MontoMensual);
                    double.TryParse(txtIngresoEventual.Text, out MontoEventual);
                    double MontoCategoriaZ = -1;
                    double.TryParse(txtMontoPagoCategoriaZ.Text, out MontoCategoriaZ);

                    if (TipoOperacion == "I")
                    {

                        //TAPagosServicios.Insert(NumeroPaciente, int.Parse(CodigoCategoriaPaciente), int.Parse(cBoxServicioRecibo.SelectedValue.ToString()),
                        //    rbtnServicioExterno.Checked ? "E" : "I", dateFechaPapeletaPago.Value, int.Parse(TxtNumeroRecibo.Text), TxtPersonaA.Text,
                        //    double.Parse(TxtCostoPapeleta.Text), double.Parse(TxtSubvencion.Text), double.Parse(TxtTotalCancelar.Text),
                        //    checkBox1.Checked, checkBox1.Checked ? double.Parse(txtMontoLibrePago.Text) : 0, TxtObservacionesRecibo.Text,
                        //    null, cBoxEspecialidadRecibo.SelectedIndex >= 0 ? int.Parse(cBoxEspecialidadRecibo.SelectedValue.ToString()) : (int?)null);

                        TAPagosServicios.InsertarPagoServicioXMLDetalle(NumeroPaciente, null, txtNroPapeleta.Text,
                            String.IsNullOrEmpty(CodigoCategoriaPaciente) ? null : (int?)int.Parse(CodigoCategoriaPaciente), 
                            cBoxTipoServicio.SelectedValue.ToString(), cBoxClaseServicio.SelectedValue.ToString(),
                            TAFuncionesSistema.ObtenerFechaHoraServidor(), int.Parse(txtNroPapeleta.Text), txtDirigidoA.Text,
                            double.Parse(txtPrecioSubTotal.Text), double.Parse(txtSubvencionTotal.Text), 
                            //double.Parse(txtPrecioTotal.Text),
                            checkCategoriaZ.Checked ? double.Parse(txtMontoPagoCategoriaZ.Text) : double.Parse(txtPrecioTotal.Text),

                            double.Parse(txtPrecioTotal.Text), checkCategoriaZ.Checked, null, checkPacienteInstitucionalizado.Checked,
                            MontoMensual > 0 ? (int?)MontoMensual : null, MontoEventual > 0 ? (int?) MontoEventual : null, 
                            NumeroReingreso, TxtObservacionesRecibo.Text, DetalleXML);
                    }
                    else
                    {
                        //TAPagosServicios.ActualizarPagoServicio(NumeroPaciente, CodigoPagoServicio, int.Parse(CodigoCategoriaPaciente), int.Parse(cBoxServicioRecibo.SelectedValue.ToString()),
                        //    rbtnServicioExterno.Checked ? "E" : "I", dateFechaPapeletaPago.Value, int.Parse(TxtNumeroRecibo.Text), TxtPersonaA.Text,
                        //    double.Parse(TxtCostoPapeleta.Text), double.Parse(TxtSubvencion.Text), double.Parse(TxtTotalCancelar.Text),
                        //    checkBox1.Checked, checkBox1.Checked ? double.Parse(txtMontoLibrePago.Text) : 0, TxtObservacionesRecibo.Text,
                        //    null, cBoxEspecialidadRecibo.SelectedIndex >= 0 ? int.Parse(cBoxEspecialidadRecibo.SelectedValue.ToString()) : (int?)null);

                        TAPagosServicios.ActualizarPagoServicioXMLDetalle(NumeroPaciente, NumeroPagoServicio, int.Parse(tsLblNumeroPago.Text), null,
                            String.IsNullOrEmpty(CodigoCategoriaPaciente) ? null : (int?)int.Parse(CodigoCategoriaPaciente), 
                            cBoxTipoServicio.SelectedValue.ToString(),
                            cBoxClaseServicio.SelectedValue.ToString(),
                            TAFuncionesSistema.ObtenerFechaHoraServidor(), int.Parse(txtNroPapeleta.Text), txtDirigidoA.Text,
                            int.Parse(txtPrecioSubTotal.Text), int.Parse(txtSubvencionTotal.Text), 
                            //int.Parse(txtPrecioTotal.Text),
                            checkCategoriaZ.Checked ? double.Parse(txtMontoPagoCategoriaZ.Text) : double.Parse(txtPrecioTotal.Text),
                            int.Parse(txtPrecioTotal.Text), checkCategoriaZ.Checked, null, checkPacienteInstitucionalizado.Checked,
                            MontoMensual > 0 ? (int?)MontoMensual : null, MontoEventual > 0 ? (int?)MontoEventual : null, 
                            NumeroReingreso, TxtObservacionesRecibo.Text, DetalleXML);
                    }

                    TipoOperacion = "";
                    habilitarBotones(true, false, false, true, true, true);
                    habilitarControles(false);
                    
                    MessageBox.Show(this, "Operación Realizada Correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnImprimirPapeletaPago_Click(btnImprimirPapeletaPago, e);
                    if (ClaseServicio.Equals("I") || ClaseServicio.Equals("R"))
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrió la siguiente Excepcion " + ex.Message);
                }
            }
            else
                MessageBox.Show(this, "Porfavor corriga la(s) siguiente(s) Observación(es)" + MensajeError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            habilitarBotones(false, true, true, false, false, false);
            habilitarControles(true);
            //DTServiciosDetalle.MontoPagadoColumn.Expression = "(CostoServicio * " + (100 - SubvencionInstitucional).ToString() + "/100) * Cantidad";
            //DTServiciosDetalle.PrecioTotalRealColumn.Expression = "Cantidad * CostoServicio";
            //DTServiciosDetalle.MontoSubvencionColumn.Expression = "PrecioTotalReal - MontoPagado";
            DTServiciosDetalle.RowChanged += new DataRowChangeEventHandler(DTServiciosDetalle_RowChanged);
        }

        private void btnBuscarPapeletaPago_Click(object sender, EventArgs e)
        {
            FBuscarPacientesOperaciones formBuscarOperaciones = new FBuscarPacientesOperaciones("P");
            if (formBuscarOperaciones.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cargarDatosPapeletaPago(formBuscarOperaciones.NumeroOperacion, formBuscarOperaciones.NumeroPaciente);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {            
            habilitarBotones(true, false, false, false, false, true);
            limpiarControles();
            habilitarControles(false);
            TipoOperacion = "";
            DTServiciosDetalle.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de Eliminar el Registro Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                TAPagosServicios.Delete(NumeroPaciente, NumeroPagoServicio);
                limpiarControles();
                NumeroPagoServicio = -1;
                habilitarBotones(true, false, false, false, false, true);
            }
        }

        private void btnCerrarPapeletaPago_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            if (cBoxServicios.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ningún servicio", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (DTServiciosDetalle.FindByCodigoServicio(int.Parse(cBoxServicios.SelectedValue.ToString())) == null)
            {
                try
                {
                    DSTrabajo_Social.ListarPagosServiciosDetalleReporteRow DRServicioSeleccionado = DTServiciosDetalle.NewListarPagosServiciosDetalleReporteRow();

                    //SELECT PSD.CodigoServicio, PSD.Cantidad, PSD.CostoServicio, 
                    //S.NombreServicio, PSD.MontoCancelado, 
                    //PSD.CodigoCategoria, C.NombreCategoria,
                    //CostoServicio -  MontoCancelado AS MontoSubvencion,
                    //--MontoCancelado AS MontoPagado, 
                    //psd.Cantidad * psd.CostoServicio as PrecioTotalReal,
                    //MontoCancelado * 100 / CostoServicio as PorcentajeSubvencion


                    DRServicioSeleccionado.CodigoServicio = int.Parse(cBoxServicios.SelectedValue.ToString());
                    DRServicioSeleccionado.NombreServicio = (cBoxServicios.SelectedItem as DataRowView)["NombreServicio"].ToString();
                    DRServicioSeleccionado.CostoServicio = double.Parse((cBoxServicios.SelectedItem as DataRowView)["Precio"].ToString());
                    DRServicioSeleccionado.PorcentajeSubvencion = SubvencionInstitucional;
                    DRServicioSeleccionado.Cantidad = 1;
                    if (String.IsNullOrEmpty(CodigoCategoriaPaciente))
                    {
                        DRServicioSeleccionado.SetCodigoCategoriaNull();
                        DRServicioSeleccionado.SetNombreCategoriaNull();
                    }
                    else
                    {
                        DRServicioSeleccionado.CodigoCategoria = int.Parse(CodigoCategoriaPaciente);
                        DRServicioSeleccionado.NombreCategoria = txtCategoria.Text.Trim();                        
                    }
                    DRServicioSeleccionado.MontoCancelado = Math.Round(DRServicioSeleccionado.CostoServicio - DRServicioSeleccionado.CostoServicio * DRServicioSeleccionado.PorcentajeSubvencion / 100, 2);
                    DRServicioSeleccionado.MontoSubvencion = Math.Round(DRServicioSeleccionado.CostoServicio - DRServicioSeleccionado.MontoCancelado , 2);
                    DRServicioSeleccionado.PrecioTotalReal = Math.Round(DRServicioSeleccionado.Cantidad * DRServicioSeleccionado.MontoCancelado , 2);

                    DTServiciosDetalle.AddListarPagosServiciosDetalleReporteRow(DRServicioSeleccionado);
                    DTServiciosDetalle.AcceptChanges();
                    cBoxServicios.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrió la siguiente excepción " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this,"El Servicio que desea agregar a la lista, ya se encuentra dentro de la misma", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtGVServicios_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!string.IsNullOrEmpty(TipoOperacion))
            {
                decimal CantidadNuevaDeEntrega;

                this.dtGVServicios.Rows[e.RowIndex].ErrorText = "";

                // No cell validation for new rows. New rows are validated on Row Validation.
                if (this.dtGVServicios.Rows[e.RowIndex].IsNewRow) { return; }

                if (this.dtGVServicios.IsCurrentCellDirty)
                {
                    switch (this.dtGVServicios.Columns[e.ColumnIndex].Name)
                    {

                        case "DGCCantidad":
                            if (e.FormattedValue.ToString().Trim().Length < 1)
                            {
                                this.dtGVServicios.Rows[e.RowIndex].ErrorText = "   La Cantidad es necesaria y no puede estar vacia.";
                                e.Cancel = true;
                            }
                            else if (!decimal.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega) || CantidadNuevaDeEntrega <= 0)
                            {
                                this.dtGVServicios.Rows[e.RowIndex].ErrorText = "   La Cantidad debe ser un real positivo.";
                                e.Cancel = true;
                            }
                            break;
                        case "DGCPrecio":                            
                            if (e.FormattedValue.ToString().Trim().Length < 1)
                            {
                                this.dtGVServicios.Rows[e.RowIndex].ErrorText = "   El Costo del Servicio es necesario y no puede estar vacio.";
                                e.Cancel = true;
                            }
                            else if (!decimal.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega) || CantidadNuevaDeEntrega < 0)
                            {
                                this.dtGVServicios.Rows[e.RowIndex].ErrorText = "   El Costo del Servicio debe ser ser un real positivo.";
                                e.Cancel = true;
                            }
                            break;
                        case "DGCMontoCancelado":                                                 
                            if (dtGVServicios.CurrentRow.Cells["DGCCodigoCategoria"].Value.ToString().CompareTo("7") == 0)
                            {
                                decimal CostoServicio = decimal.Parse(dtGVServicios.CurrentRow.Cells["DGCPrecio"].Value.ToString());
                                if (e.FormattedValue.ToString().Trim().Length < 1)
                                {
                                    this.dtGVServicios.Rows[e.RowIndex].ErrorText = "   El Precio es necesario y no puede estar vacio.";
                                    e.Cancel = true;
                                }
                                else if (!decimal.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega) || CantidadNuevaDeEntrega < 0)
                                {
                                    this.dtGVServicios.Rows[e.RowIndex].ErrorText = "   El Precio debe ser ser un real positivo.";
                                    e.Cancel = true;
                                }
                                
                                else if(CantidadNuevaDeEntrega >  CostoServicio)
                                {
                                    this.dtGVServicios.Rows[e.RowIndex].ErrorText = "   El Mongo Cancelado no puede superior al Costo del Servicio Seleccionado.";
                                    e.Cancel = true;
                                }
                            }
                            else
                            {
                                this.dtGVServicios.Rows[e.RowIndex].ErrorText = "No puede modificar el Precio debido a que no tiene seleccionada la categoria Z";
                                e.Cancel = true;
                            }
                            
                            break;
                        //case "DGCNombreServicio":
                        //    if(DTServiciosDetalle.FindByCodigoServicio(int.Parse(e.FormattedValue.ToString())) != null)
                        //    {
                        //        this.dtGVServicios.Rows[e.RowIndex].ErrorText = "   El Servicio que ha seleccionado ya se encuentra dentro de la lista.";
                        //        e.Cancel = true;
                        //    }
                        //    break;
                    }

                }
            }
        }

        private void dtGVServicios_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TipoOperacion) && dtGVServicios.IsCurrentCellDirty && 
                (dtGVServicios.CurrentCell.ColumnIndex == DGCNombreServicio.Index
                && dtGVServicios.CurrentCell.ColumnIndex == DGCCodigoCategoria.Index ))
            {
                dtGVServicios.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtGVServicios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!String.IsNullOrEmpty(TipoOperacion) && DTServiciosDetalle != null && DTServiciosDetalle.Count != 0
                && dtGVServicios.CurrentCell != null)
            {
                //double Precio = 0; int cantidad = 1; 
                int CodigoServicio;
                CodigoServicio = int.Parse(dtGVServicios.CurrentRow.Cells["DGCCodigoServicio"].Value.ToString());
                SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_Social.ListarPagosServiciosDetalleReporteRow DRServicioSeleccionado = DTServiciosDetalle.FindByCodigoServicio(CodigoServicio);
                if (DRServicioSeleccionado == null)
                {
                    dtGVServicios.CancelEdit();
                    return;
                }

                if (e.ColumnIndex == DGCMontoCancelado.Index)
                {
                    if (!DRServicioSeleccionado.IsNombreCategoriaNull() )//&& DRServicioSeleccionado.NombreCategoria.CompareTo("Z") == 0)
                    {
                        
                        dtGVServicios.CurrentRow.Cells["DGCSubvencion"].Value = Math.Round(DRServicioSeleccionado.CostoServicio - double.Parse(dtGVServicios.CurrentRow.Cells["DGCMontoCancelado"].Value.ToString()),2);
                        //DRServicioSeleccionado.MontoSubvencion = DRServicioSeleccionado.CostoServicio - double.Parse(dtGVServicios.CurrentRow.Cells["DGCMontoCancelado"].Value.ToString());
                        dtGVServicios.CurrentRow.Cells["DGCPrecioTotal"].Value = Math.Round(DRServicioSeleccionado.Cantidad * DRServicioSeleccionado.MontoCancelado,2);
                        dtGVServicios.UpdateCellValue(DGCSubvencion.Index, e.RowIndex);
                        dtGVServicios.Update();
                    }
                }

                if (e.ColumnIndex == DGCCodigoCategoria.Index)
                {
                    DSTrabajo_Social.CategoriasDataTable DTCategoriasAux = DGCCodigoCategoria.DataSource as DSTrabajo_Social.CategoriasDataTable;
                    int CodigoCategoriaSeleccionada = int.Parse(dtGVServicios.CurrentRow.Cells["DGCCodigoCategoria"].Value.ToString());
                    double porcentajeSubvencion = DTCategoriasAux.FindByCodigoCategoria(CodigoCategoriaSeleccionada).SubvencionInstitucional;

                    DRServicioSeleccionado.PorcentajeSubvencion = porcentajeSubvencion;
                    DRServicioSeleccionado.MontoCancelado =  Math.Round(DRServicioSeleccionado.CostoServicio - DRServicioSeleccionado.CostoServicio * DRServicioSeleccionado.PorcentajeSubvencion / 100, 2);
                    DRServicioSeleccionado.MontoSubvencion = Math.Round(DRServicioSeleccionado.CostoServicio - DRServicioSeleccionado.MontoCancelado, 2);
                    DRServicioSeleccionado.PrecioTotalReal = Math.Round(DRServicioSeleccionado.Cantidad * DRServicioSeleccionado.MontoCancelado, 2);

                    DRServicioSeleccionado.MontoCancelado = Math.Round(DRServicioSeleccionado.MontoCancelado, 2);
                    DRServicioSeleccionado.MontoSubvencion = Math.Round(DRServicioSeleccionado.MontoSubvencion, 2);
                    DRServicioSeleccionado.PrecioTotalReal = Math.Round(DRServicioSeleccionado.PrecioTotalReal, 2);
                    dtGVServicios.UpdateCellValue(DGCMontoCancelado.Index, e.RowIndex);
                    dtGVServicios.UpdateCellValue(DGCSubvencion.Index, e.RowIndex);                    
                }

                if (e.ColumnIndex == DGCPrecio.Index)
                {
                    DSTrabajo_Social.CategoriasDataTable DTCategoriasAux = DGCCodigoCategoria.DataSource as DSTrabajo_Social.CategoriasDataTable;
                    int CodigoCategoriaSeleccionada = 0;
                    if(!String.IsNullOrEmpty(dtGVServicios.CurrentRow.Cells["DGCCodigoCategoria"].Value.ToString()))
                        CodigoCategoriaSeleccionada = int.Parse(dtGVServicios.CurrentRow.Cells["DGCCodigoCategoria"].Value.ToString() ?? "0");
                    double porcentajeSubvencion = 0;
                    if (DTCategoriasAux.FindByCodigoCategoria(CodigoCategoriaSeleccionada) != null)
                    {
                        porcentajeSubvencion = DTCategoriasAux.FindByCodigoCategoria(CodigoCategoriaSeleccionada).SubvencionInstitucional;
                    }

                    DRServicioSeleccionado.CostoServicio = double.Parse(dtGVServicios.CurrentRow.Cells["DGCPrecio"].Value.ToString());

                    DRServicioSeleccionado.PorcentajeSubvencion = porcentajeSubvencion;
                    DRServicioSeleccionado.MontoCancelado = Math.Round(DRServicioSeleccionado.CostoServicio - DRServicioSeleccionado.CostoServicio * DRServicioSeleccionado.PorcentajeSubvencion / 100, 2);
                    DRServicioSeleccionado.MontoSubvencion = Math.Round(DRServicioSeleccionado.CostoServicio - DRServicioSeleccionado.MontoCancelado, 2);
                    DRServicioSeleccionado.PrecioTotalReal = Math.Round(DRServicioSeleccionado.Cantidad * DRServicioSeleccionado.MontoCancelado, 2);

                    DRServicioSeleccionado.MontoCancelado = Math.Round(DRServicioSeleccionado.MontoCancelado, 2);
                    DRServicioSeleccionado.MontoSubvencion = Math.Round(DRServicioSeleccionado.MontoSubvencion, 2);
                    DRServicioSeleccionado.PrecioTotalReal = Math.Round(DRServicioSeleccionado.PrecioTotalReal, 2);
                    dtGVServicios.UpdateCellValue(DGCMontoCancelado.Index, e.RowIndex);
                    dtGVServicios.UpdateCellValue(DGCSubvencion.Index, e.RowIndex);                    
                }

                if (e.ColumnIndex == DGCNombreServicio.Index)
                {
                    dtGVServicios.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    DTServiciosDetalle.AcceptChanges();
                    DRServicioSeleccionado = DTServiciosDetalle.FindByCodigoServicio(CodigoServicio);
                    DRServicioSeleccionado.CostoServicio = DTServicios.FindByCodigoServicio(CodigoServicio).Precio;
                    DTServiciosDetalle.AcceptChanges();
                    dtGVServicios.Update();
                }
            }
        }

        private void dtGVServicios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(this, "Probablemente el Servicio que ha seleccionado ya se encuentra en la lista, o quizas alguno de los datos se encuentra mal escrito",
                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void checkCategoriaZ_CheckedChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TipoOperacion))
            {
                //if (dtGVServicios.Rows.Count == 0)
                //{
                //    MessageBox.Show(this, "No tiene seleccionado ningún servicio, no puede modificar esta opción",
                //        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    checkCategoriaZ.CheckedChanged -= checkCategoriaZ_CheckedChanged;
                //    checkCategoriaZ.Checked = !checkCategoriaZ.Checked;
                //    checkCategoriaZ.CheckedChanged += checkCategoriaZ_CheckedChanged;
                //    return;
                //}
                //if (!checkCategoriaZ.Checked)
                //{
                //    foreach (DSTrabajo_Social.ListarPagosServiciosDetalleReporteRow DRServicios in DTServiciosDetalle.Rows)
                //    {
                //        DRServicios.CostoServicio = DTServicios.FindByCodigoServicio(DRServicios.CodigoServicio).Precio;
                //    }
                //    DTServiciosDetalle.AcceptChanges();
                //    dtGVServicios.Update();
                //}
                //else
                //{
                //    if (MessageBox.Show(this, "La dotación de servicios en esta categoría obtiene un costo minimo,"
                //        + "por lo cual todos los servicios seleccionados pasaran a tener un costo minimo de 0.00. ¿Desea Continuar?",
                //        this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                //        checkCategoriaZ.Checked = false;
                //    else
                //    {
                //        foreach (DSTrabajo_Social.ListarPagosServiciosDetalleReporteRow DRServicios in DTServiciosDetalle.Rows)
                //        {
                //            DRServicios.CostoServicio = 0;
                //        }
                //        DTServiciosDetalle.AcceptChanges();
                //        dtGVServicios.Update();
                //    }
                //}

                lblPagoCatZ.Visible = txtMontoPagoCategoriaZ.Visible = checkCategoriaZ.Checked;

            }
        }

        private void FPagoServicio_Shown(object sender, EventArgs e)
        {
            txtNroPapeleta.Focus();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DTServiciosDetalle.AcceptChanges();
        }


        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            FNivelSocioEconomico formNivelSocioEconomico = new FNivelSocioEconomico(txtNombreCompletoPaciente.Text,
                TipoOperacion, NumeroPaciente);
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

                    FechaHoraValoracionSocioEconomica = TAFuncionesSistema.ObtenerFechaHoraServidor();
                    TAValoracionSocioEconomica.InsertarActualizarValoracionSocioEconomicaXML(NumeroPaciente, FechaHoraValoracionSocioEconomica, DTAux.DataSet.GetXml());


                }

                String NombreCategoria = formNivelSocioEconomico.NombreCategoria;
                CodigoCategoriaPaciente = TAFuncionesSistema.ObtenerCategoriaValoracionSocioEconomicaPaciente(NumeroPaciente, true);
                if (!String.IsNullOrEmpty(CodigoCategoriaPaciente))
                {
                    DTCategorias = TACategorias.GetDataBy1(int.Parse(CodigoCategoriaPaciente));
                    txtCategoria.Text = NombreCategoria;
                    //txtSubvencionInstitucional.Text = DTCategorias.FindByCodigoCategoria(int.Parse(CodigoCategoriaPaciente)).SubvencionInstitucional.ToString();
                    SubvencionInstitucional = DTCategorias.FindByCodigoCategoria(int.Parse(CodigoCategoriaPaciente)).SubvencionInstitucional;
                    txtSubvencionInstitucional.Text = SubvencionInstitucional.ToString();
                    dtGVSituacionSocioEconomica.DataSource = TAValoracionSocioEocnomica.GetDataByNombreRespuesta(NumeroPaciente, FechaHoraValoracionSocioEconomica);
                }
                else
                {
                    txtCategoria.Text = "";
                    txtSubvencionInstitucional.Text = "0";
                    SubvencionInstitucional = 0;
                }
            }            

        }

        private void gBoxDatosPagoServicio_Enter(object sender, EventArgs e)
        {

        }

        private void btnImprimirPapeletaPago_Click(object sender, EventArgs e)
        {
            ListarPagosServiciosReporteTableAdapter TAListarPagosServiciosReporte = new ListarPagosServiciosReporteTableAdapter();
            FReporteFormulariosIndividuales formReporte = new FReporteFormulariosIndividuales();
            formReporte.ListarPagosServiciosReporte(TAListarPagosServiciosReporte.GetData(NumeroPaciente, NumeroPagoServicio) , DTServiciosDetalle.Copy(), TAValoracionSocioEocnomica.GetDataByNombreRespuesta(NumeroPaciente, null));
            formReporte.ShowDialog();
            formReporte.Dispose();
        }

    }
}
