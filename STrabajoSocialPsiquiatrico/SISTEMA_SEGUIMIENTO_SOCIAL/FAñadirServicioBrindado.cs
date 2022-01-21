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
    public partial class FAñadirServicioBrindado : Form
    {

        ServiciosTableAdapter TAServicios;
        DSTrabajo_Social.ServiciosDataTable DTServicios;
        QTAFuncionesSistema TAFuncionesSistema;
        ErrorProvider eProviderServicios;
        string TipoOperacion = "";
        private bool soloInsertarEditar = false;
        public int CodigoServicio { get; set; }
        public FAñadirServicioBrindado()
        {
            InitializeComponent();

            try
            {
                DTServicios = new DSTrabajo_Social.ServiciosDataTable();
                TAServicios = new ServiciosTableAdapter();
                TAFuncionesSistema = new QTAFuncionesSistema();

                eProviderServicios = new ErrorProvider();
                DTServicios = TAServicios.GetData();
                bdSourceServicios.DataSource = DTServicios;
                CargarDatosConcepto(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió la siguiente excepcion al momento de cargar el Formulario " + ex.Message);
                throw;
            }
            Visible = true;
        }

        public void CargarDatosConcepto(int CodigoServicio)
        {

            DSTrabajo_Social.ServiciosRow DRServicio = DTServicios.FindByCodigoServicio(CodigoServicio);
            if (DRServicio == null)
            {
                DSTrabajo_Social.ServiciosDataTable DTServiciosAux = TAServicios.GetDataBy1(CodigoServicio);
                if (DTServiciosAux.Count > 0)
                    DRServicio = DTServiciosAux[0];
                else
                {
                    limpiarControles();
                    habilitarControles(false);
                    habilitarBotones(true, false, false, false, false);
                    return;
                }
            }
            else
            {
                TxtCodigoServicio.Text = DRServicio.CodigoServicio.ToString();
                TxtServicio.Text = DRServicio.NombreServicio;
                rTextBoxDescripciónServicio.Text = DRServicio.IsDescripcionNull() ? String.Empty : DRServicio.Descripcion;
                TxtPrecio.Text = DRServicio.Precio.ToString();

                habilitarBotones(true, false, false, true, true);
                habilitarControles(false);
            }
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            TxtServicio.ReadOnly = !estadoHabilitacion;
            rTextBoxDescripciónServicio.Enabled = estadoHabilitacion;
            TxtPrecio.ReadOnly = !estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool editar, bool eliminar)
        {
            this.btnAñadirServicio.Enabled = nuevo;
            this.btnGuardarServicio.Enabled = aceptar;
            this.btnCancelar.Enabled = cancelar;
            this.btnEditarServicio.Enabled = editar;
            this.btnEliminarSErvicio.Enabled = eliminar;
        }

        public void limpiarControles()
        {
            TxtServicio.Text = string.Empty;
            rTextBoxDescripciónServicio.Text = string.Empty;
            TxtPrecio.Text = string.Empty;
        }

        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(TxtServicio.Text.Trim()))
            {
                eProviderServicios.SetError(TxtServicio, "Aún no ha Ingresado el Nombre del Servicio");
                TxtServicio.Focus();
                TxtServicio.SelectAll();
                return false;
            }

            

            if (String.IsNullOrEmpty(TxtPrecio.Text.Trim()))
            {
                eProviderServicios.SetError(TxtPrecio, "Aún no ha Ingresado el Precio del Servicio");
                TxtPrecio.Focus();
                TxtPrecio.SelectAll();
                return false;
            }
            double precio = -1;
            if (!double.TryParse(TxtPrecio.Text, out precio) || precio < 0)
            {
                eProviderServicios.SetError(TxtPrecio, "El Precio del Servicio debe ser un Entero Positivo");
                TxtPrecio.Focus();
                TxtPrecio.SelectAll();
                return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int? NumeroServiciosiguiente = 0;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("Servicios", ref NumeroServiciosiguiente);
            NumeroServiciosiguiente = NumeroServiciosiguiente == -1
                 ? 1 : NumeroServiciosiguiente.Value + 1;
            TxtCodigoServicio.Text = NumeroServiciosiguiente.ToString();
            TipoOperacion = "I";
            habilitarControles(true);
            limpiarControles();
            habilitarBotones(false, true, true, false, false);
            TxtPrecio.Text = "0.00";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                eProviderServicios.Clear();
                if (validarDatos())
                {
                    int CodigoNumeroAuxiliar = int.Parse(TxtCodigoServicio.Text);
                    if (TipoOperacion == "I")
                    {
                        TAServicios.Insert(TxtServicio.Text.Trim(), double.Parse(TxtPrecio.Text), rTextBoxDescripciónServicio.Text);
                        DSTrabajo_Social.ServiciosRow DRServicioNuevo = DTServicios.AddServiciosRow(TxtServicio.Text.Trim(), double.Parse(TxtPrecio.Text), rTextBoxDescripciónServicio.Text);
                        DRServicioNuevo.CodigoServicio = CodigoNumeroAuxiliar;
                        DRServicioNuevo.AcceptChanges();
                        DTServicios.AcceptChanges();
                    }

                    else
                    {
                        TAServicios.ActualizarServicio(int.Parse(TxtCodigoServicio.Text), TxtServicio.Text, double.Parse(TxtPrecio.Text), rTextBoxDescripciónServicio.Text);
                        int indiceEdicion = DTServicios.Rows.IndexOf(DTServicios.FindByCodigoServicio(int.Parse(TxtCodigoServicio.Text)));
                        DTServicios[indiceEdicion].NombreServicio = TxtServicio.Text;
                        DTServicios[indiceEdicion].Descripcion = rTextBoxDescripciónServicio.Text;
                        DTServicios[indiceEdicion].Precio = double.Parse(TxtPrecio.Text);
                        DTServicios.AcceptChanges();
                    }
                    habilitarBotones(true, false, false, true, true);
                    habilitarControles(false);
                    TipoOperacion = "";
                    MessageBox.Show(this, "Operación realizada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CodigoServicio = CodigoNumeroAuxiliar;
                    if (soloInsertarEditar)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        bdSourceServicios.MoveLast();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Falta completar el llenado de algunos campos que son necesarios, revise su datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudo culminar satisfactoriamente la operación actual, debido a que ocurrió la siguiente excepcion " +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            eProviderServicios.Clear();
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false);
            bdSourceServicios_CurrentChanged(bdSourceServicios, e);
            if (soloInsertarEditar)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de Eliminar el registro Actual??", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    limpiarControles();
                    habilitarBotones(true, false, false, false, false);
                    TAServicios.Delete(int.Parse(TxtCodigoServicio.Text));
                    DTServicios.Rows.Remove(DTServicios.FindByCodigoServicio(int.Parse(TxtCodigoServicio.Text)));
                    DTServicios.AcceptChanges();
                }
                catch (Exception )
                {
                    MessageBox.Show(this, "No se pudo Eliminar el registro actual, probablemente se encuentra en uso en otras trasacciones", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }



        private void bdSourceServicios_CurrentChanged(object sender, EventArgs e)
        {

            if (bdSourceServicios.Position >= 0)
            {
                CargarDatosConcepto(DTServicios[bdSourceServicios.Position].CodigoServicio);

                if (soloInsertarEditar && (DialogResult == System.Windows.Forms.DialogResult.OK || DialogResult == System.Windows.Forms.DialogResult.Cancel))
                {
                    CodigoServicio = DTServicios[bdSourceServicios.Position].CodigoServicio;
                    this.Close();
                }
            }

        }

        public void configurarFormularioIA(int? CodigoServicio)
        {
            CargarDatosConcepto(CodigoServicio != null ? CodigoServicio.Value : -1);
            if (CodigoServicio == null)
            {
                int? NumeroServiciosiguiente = 0;
                TAFuncionesSistema.ObtenerUltimoIndiceTabla("Servicios", ref NumeroServiciosiguiente);
                NumeroServiciosiguiente = NumeroServiciosiguiente == -1
                     ? 1 : NumeroServiciosiguiente.Value + 1;
                TxtCodigoServicio.Text = NumeroServiciosiguiente.ToString();
            }
            TipoOperacion = CodigoServicio == null ? "I" : "E";
            soloInsertarEditar = true;
            dtGVListadoServicios.Visible = false;
            //290
            btnEditarServicio.Visible = btnAñadirServicio.Visible = btnEliminarSErvicio.Visible = false;
            //this.Size = new Size(this.Size.Width, 245);
            this.Size = new Size(this.Size.Width, gBoxDatos.Size.Height + pnlBotones.Size.Height + 35);
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false);
        }

        private void btnCerrarAñadirServicio_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }
    }
}
