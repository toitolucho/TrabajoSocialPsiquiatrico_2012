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
    public partial class FAñadirParentesco : Form
    {
        
        ParentescosTableAdapter TAParentescos;
        SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_Social.ParentescosDataTable DTParentescos;
        SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_Social.ParentescosDataTable DTParentescosCBox;
        QTAFuncionesSistema TAFuncionesSistema;
        ErrorProvider eProviderParentescos;
        private string TipoOperacion = "";
        public int CodigoParentesco { get; set; }
        private bool soloInsertarEditar = false;
        public FAñadirParentesco()
        {
            InitializeComponent();

            DTParentescos = new DSTrabajo_Social.ParentescosDataTable();
            TAParentescos = new ParentescosTableAdapter();
            TAFuncionesSistema = new QTAFuncionesSistema();
            //TAParentescos.Connection = Utilidades.DAOUtilidades.conexion;

            eProviderParentescos = new ErrorProvider();
            DTParentescos = TAParentescos.GetData();
            bdSourceParentescos.DataSource = DTParentescos;
            DialogResult = System.Windows.Forms.DialogResult.None;

            
            CargarDatosParentesco(-1);
            
        }

        public void configurarFormularioIA(int? CodigoParentescoConfiguracion)
        {
            

            CargarDatosParentesco(CodigoParentescoConfiguracion != null ? CodigoParentescoConfiguracion.Value : -1);
            TipoOperacion = CodigoParentescoConfiguracion == null ? "I" : "E";
            soloInsertarEditar = true;
            gBoxGrilla.Visible = false;
            //290
            btnEditar.Visible = btnNuevo.Visible = btnEliminar.Visible = false;
            this.Size = new Size(this.Size.Width, gBoxDatos.Size.Height + pnlBotones.Size.Height + 35);
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false);

            int? NumeroParentescosiguiente = -1;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("Parentescos", ref NumeroParentescosiguiente);
            NumeroParentescosiguiente = NumeroParentescosiguiente.Value == -1 ? 1 : NumeroParentescosiguiente.Value + 1;
            TxtCodigoParentesco.Text = NumeroParentescosiguiente.Value.ToString();
        }

        public void CargarDatosParentesco(int CodigoParentescoCargar)
        {

            SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_Social.ParentescosRow DRProductoTipo = DTParentescos.FindByCodigoParentesco(CodigoParentescoCargar);
            if (DRProductoTipo == null)
            {
                SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_Social.ParentescosDataTable DTParentescosAux = TAParentescos.GetDataBy1(CodigoParentescoCargar);
                if (DTParentescosAux.Count > 0)
                    DRProductoTipo = DTParentescosAux[0];
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
                TxtCodigoParentesco.Text = DRProductoTipo.CodigoParentesco.ToString();
                TxtNombreParentesco.Text = DRProductoTipo.NombreParentesco;
                
                rtextBoxDescripcionParentesco.Text = DRProductoTipo.IsDescripcionNull() ? String.Empty : DRProductoTipo.Descripcion;

                habilitarBotones(true, false, false, true, true);
                habilitarControles(false);
            }
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            TxtNombreParentesco.ReadOnly = !estadoHabilitacion;            
            rtextBoxDescripcionParentesco.ReadOnly = !estadoHabilitacion;
            
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
            TxtNombreParentesco.Text = String.Empty;
            TxtCodigoParentesco.Text = String.Empty;
            rtextBoxDescripcionParentesco.Text = String.Empty;
            
        }

        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(TxtNombreParentesco.Text.Trim()))
            {
                eProviderParentescos.SetError(TxtNombreParentesco, "Aún no ha ingresado el Nombre del Parentesco");
                TxtNombreParentesco.Focus();
                TxtNombreParentesco.SelectAll();
                return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarControles();
            int? NumeroParentescosiguiente = -1;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("Parentescos", ref NumeroParentescosiguiente);
            NumeroParentescosiguiente = NumeroParentescosiguiente.Value == -1 ? 1 : NumeroParentescosiguiente.Value + 1;
            TxtCodigoParentesco.Text = NumeroParentescosiguiente.Value.ToString();
            TipoOperacion = "I";
            habilitarControles(true);            
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
                eProviderParentescos.Clear();
                if (validarDatos())
                {
                    int CodigoNumeroAuxiliar = int.Parse(TxtCodigoParentesco.Text);
                    if (TipoOperacion == "I")
                    {
                        TAParentescos.Insert(TxtNombreParentesco.Text.Trim(), rtextBoxDescripcionParentesco.Text);
                        SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_Social.ParentescosRow DRParentescoNuevo = DTParentescos.AddParentescosRow(TxtNombreParentesco.Text.Trim(), rtextBoxDescripcionParentesco.Text);
                        DRParentescoNuevo.CodigoParentesco = CodigoNumeroAuxiliar;
                        DRParentescoNuevo.AcceptChanges();
                        DTParentescos.AcceptChanges();

                    }

                    else
                    {
                        TAParentescos.ActualizarParentesco(int.Parse(TxtCodigoParentesco.Text), TxtNombreParentesco.Text.Trim(), rtextBoxDescripcionParentesco.Text);
                        int indiceEdicion = DTParentescos.Rows.IndexOf(DTParentescos.FindByCodigoParentesco(int.Parse(TxtCodigoParentesco.Text)));
                        DTParentescos[indiceEdicion].NombreParentesco= TxtNombreParentesco.Text;                        
                        DTParentescos[indiceEdicion].Descripcion = rtextBoxDescripcionParentesco.Text;
                        DTParentescos.AcceptChanges();
                    }
                    habilitarBotones(true, false, false, true, true);
                    habilitarControles(false);
                    TipoOperacion = "";
                    MessageBox.Show(this, "Operación Realizada Correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CodigoParentesco = CodigoNumeroAuxiliar;
                    if (soloInsertarEditar)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        bdSourceParentescos.MoveLast();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Falta completar el llenado de algunos campos que son necesarios, revise su datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudo culminar satisfactoriamente la operación actual, debido a que ocurrió la siguiente excepción " +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            eProviderParentescos.Clear();
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false);
            bdSourceParentescos_CurrentChanged(bdSourceParentescos, e);
            if (soloInsertarEditar)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de Eliminar el Registro Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    DTParentescos.Rows.RemoveAt(bdSourceParentescos.Position);
                    TAParentescos.Delete(int.Parse(TxtCodigoParentesco.Text));
                    DTParentescos.AcceptChanges();
                    limpiarControles();
                    habilitarBotones(true, false, false, false, false);
                }
                catch (Exception)
                {
                    MessageBox.Show("No se puede eliminar este registro, probablemente se encuentra en uso en otras Operaciones realizadas");
                }
            }
        }

        private void bdSourceParentescos_CurrentChanged(object sender, EventArgs e)
        {
            
            if (bdSourceParentescos.Position >= 0)
            {
                CodigoParentesco = DTParentescos[bdSourceParentescos.Position].CodigoParentesco;
                CargarDatosParentesco(CodigoParentesco);

                if (soloInsertarEditar && (DialogResult == System.Windows.Forms.DialogResult.OK || DialogResult == System.Windows.Forms.DialogResult.Cancel))
                    this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

    }
}
