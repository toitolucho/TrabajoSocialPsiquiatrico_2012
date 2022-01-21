using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_SocialTableAdapters;
using SISTEMA_SEGUIMIENTO_SOCIAL;
namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    public partial class FAñadirOcupaciones : Form
    {

        OcupacionesTableAdapter TAOcupaciones;
        
        SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_Social.OcupacionesDataTable DTOcupaciones;
        QTAFuncionesSistema TAFuncionesSistema;
        ErrorProvider eProviderOcupaciones;
        string TipoOperacion = "";
        public byte CodigoOcupacion { get; set; }
        private bool soloInsertarEditar = false;
        public string CodigoTipoMarca { get; set; }
        public FAñadirOcupaciones()
        {
            InitializeComponent();
            this.CodigoTipoMarca = CodigoTipoMarca;
            DTOcupaciones = new DSTrabajo_Social.OcupacionesDataTable();
            TAOcupaciones = new OcupacionesTableAdapter();
            TAFuncionesSistema = new QTAFuncionesSistema();

            eProviderOcupaciones = new ErrorProvider();
            DTOcupaciones = TAOcupaciones.GetData();
            bdSourceOcupaciones.DataSource = DTOcupaciones;
            CargarDatosOcupacion(0);
            
        }

        public void configurarFormularioIA(byte? CodigoProductoTipo)
        {

            limpiarControles();
            soloInsertarEditar = true;
			CargarDatosOcupacion(CodigoProductoTipo ?? 0);
            if (CodigoProductoTipo == null)
            {

                int? NumeroOcupacionesiguiente = 0;
                TAFuncionesSistema.ObtenerUltimoIndiceTabla("Ocupaciones", ref NumeroOcupacionesiguiente);
                NumeroOcupacionesiguiente = NumeroOcupacionesiguiente == -1
                     ? 1 : NumeroOcupacionesiguiente.Value + 1;
                txtCodigo.Text = NumeroOcupacionesiguiente.ToString();
            }
            TipoOperacion = CodigoProductoTipo == null ? "I" : "E";
            soloInsertarEditar = true;
            gBoxGrilla.Visible = false;
            //290
            btnEditar.Visible = btnNuevo.Visible = btnEliminar.Visible = false;
            this.Size = new Size(gBoxDatos.Size.Width +20, this.Size.Height);
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false);
			txtNombre.Clear();
        }

        public void CargarDatosOcupacion(byte CodigoOcupacionAux)
        {

            DSTrabajo_Social.OcupacionesRow DRNombreOcupacion = DTOcupaciones.FindByCodigoOcupacion(CodigoOcupacionAux);
            if (DRNombreOcupacion == null)
            {
                DSTrabajo_Social.OcupacionesDataTable DTOcupacionesAux = TAOcupaciones.GetDataBy1(CodigoOcupacionAux);
                if (DTOcupacionesAux.Count > 0)
                    DRNombreOcupacion = DTOcupacionesAux[0];
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
                txtCodigo.Text = DRNombreOcupacion.CodigoOcupacion.ToString();
                txtNombre.Text = DRNombreOcupacion.NombreOcupacion;
                


                habilitarBotones(true, false, false, true, true);
                habilitarControles(false);
            }
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            txtNombre.ReadOnly = !estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool editar, bool eliminar)
        {
            this.btnNuevo.Enabled = nuevo;
            this.btnAceptar.Enabled = aceptar;
            this.btnCancelar.Enabled = cancelar;
            this.btnEditar.Enabled = editar;
            this.btnEliminar.Enabled = eliminar;
        }

        public void limpiarControles()
        {
            txtNombre.Text = String.Empty;
        }

        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                eProviderOcupaciones.SetError(txtNombre, "Aún no ha ingresado el Nombre del NombreOcupacion");
                txtNombre.Focus();
                txtNombre.SelectAll();
                return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int? NumeroOcupacionesiguiente = 0;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("Ocupaciones", ref NumeroOcupacionesiguiente);
            NumeroOcupacionesiguiente = NumeroOcupacionesiguiente == -1
                 ? 1 : NumeroOcupacionesiguiente.Value + 1;
            txtCodigo.Text = NumeroOcupacionesiguiente.ToString();
            TipoOperacion = "I";
            habilitarControles(true);
            limpiarControles();
            habilitarBotones(false, true, true, false, false);
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
                eProviderOcupaciones.Clear();
                if (validarDatos())
                {
                    if (TipoOperacion == "I")
                    {
                        byte CodigoAuxiliar = byte.Parse(txtCodigo.Text);
                        TAOcupaciones.Insert(txtNombre.Text.Trim(), CodigoTipoMarca);
                        
                        DSTrabajo_Social.OcupacionesRow DRNombreOcupacionNuevo = DTOcupaciones.AddOcupacionesRow(CodigoAuxiliar, txtNombre.Text.Trim(), "");
                        DRNombreOcupacionNuevo.CodigoOcupacion = CodigoAuxiliar;
                        DRNombreOcupacionNuevo.AcceptChanges();
                        DTOcupaciones.AcceptChanges();
                        
                        CodigoOcupacion = CodigoOcupacion;
                    }

                    else
                    {
                        TAOcupaciones.ActualizarOcupacion(byte.Parse(txtCodigo.Text), txtNombre.Text, "");
                        int indiceEdicion = DTOcupaciones.Rows.IndexOf(DTOcupaciones.FindByCodigoOcupacion(byte.Parse(txtCodigo.Text)));
                        DTOcupaciones[indiceEdicion].NombreOcupacion = txtNombre.Text;
                        DTOcupaciones.AcceptChanges();
                    }
                    habilitarBotones(true, false, false, true, true);
                    habilitarControles(false);
                    TipoOperacion = "";
                    //MessageBox.Show(this, "Operación realizada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (soloInsertarEditar)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        bdSourceOcupaciones.MoveLast();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Falta completar el llenado de alguno campos qu eson necesarios, revise su datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
            eProviderOcupaciones.Clear();
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false);
            bdSourceOcupaciones_CurrentChanged(bdSourceOcupaciones, e);
            if (soloInsertarEditar)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de Eliminar el registro Actual??", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    TAOcupaciones.Delete(int.Parse(txtCodigo.Text));
                    DTOcupaciones.Rows.Remove(DTOcupaciones.FindByCodigoOcupacion(byte.Parse(txtCodigo.Text)));
                    DTOcupaciones.AcceptChanges();
                    limpiarControles();
                    habilitarBotones(true, false, false, false, false);

                }
                catch (Exception)
                {
                    MessageBox.Show(this, "No se pudo culminar la operación actual, seguramente el registro se encuentra en uso en otras operaciones del sistema", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }           
            }
        }

        private void dtGVOcupaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && DTOcupaciones.Count > 0)
            //{
            //    CargarDatosNombreOcupacion(DTOcupaciones[e.RowIndex].CodigoMarca);
            //}
        }

        private void bdSourceOcupaciones_CurrentChanged(object sender, EventArgs e)
        {
            //if(dtGVOcupaciones.CurrentCell != null)
            //    dtGVOcupaciones_CellContentClick(dtGVOcupaciones, new DataGridViewCellEventArgs(0, bdSourceOcupaciones.Position));
            //if (bdSourceOcupaciones.Position >= 0 && !soloInsertarEditar)
            //{
            //    CargarDatosOcupacion(DTOcupaciones[bdSourceOcupaciones.Position].CodigoOcupacion);
            //    CodigoOcupacion = DTOcupaciones[bdSourceOcupaciones.Position].CodigoOcupacion;
            //}
            //if (soloInsertarEditar && (DialogResult == System.Windows.Forms.DialogResult.OK || DialogResult == System.Windows.Forms.DialogResult.Cancel))
            //    this.Close();

            if (bdSourceOcupaciones.Position >= 0)
            {
                CodigoOcupacion = DTOcupaciones[bdSourceOcupaciones.Position].CodigoOcupacion;
                CargarDatosOcupacion(CodigoOcupacion);

                if (soloInsertarEditar && (DialogResult == System.Windows.Forms.DialogResult.OK || DialogResult == System.Windows.Forms.DialogResult.Cancel))
                    this.Close();
            }
        }

        private void FOcupaciones_Shown(object sender, EventArgs e)
        {
            this.txtNombre.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
