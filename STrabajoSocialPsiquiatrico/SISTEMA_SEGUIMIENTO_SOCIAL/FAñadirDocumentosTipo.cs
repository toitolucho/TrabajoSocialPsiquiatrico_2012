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
    public partial class FAñadirDocumentosTipo : Form
    {

        DocumentosTipoTableAdapter TADocumentosTipo;
        DSTrabajo_Social.DocumentosTipoDataTable DTDocumentosTipo;
        QTAFuncionesSistema TAFuncionesSistema;
        ErrorProvider eProviderDocumentosTipo;
        string TipoOperacion = "";
        private bool soloInsertarEditar = false;
        public int CodigoDocumentoTipo { get; set; }
        public FAñadirDocumentosTipo()
        {
            InitializeComponent();

            try
            {
                DTDocumentosTipo = new DSTrabajo_Social.DocumentosTipoDataTable();
                TADocumentosTipo = new DocumentosTipoTableAdapter();
                TAFuncionesSistema = new QTAFuncionesSistema();

                eProviderDocumentosTipo = new ErrorProvider();
                DTDocumentosTipo = TADocumentosTipo.GetData();
                bdSourceDocumentosTipos.DataSource = DTDocumentosTipo;
                CargarDatosConcepto(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió la siguiente excepción al momento de cargar el Formulario " + ex.Message);
                throw;
            }
            Visible = true;
        }

        public void CargarDatosConcepto(int CodigoDocumentoTipo)
        {

            DSTrabajo_Social.DocumentosTipoRow DRConcepto = DTDocumentosTipo.FindByCodigoDocumentoTipo(CodigoDocumentoTipo);
            if (DRConcepto == null)
            {
                DSTrabajo_Social.DocumentosTipoDataTable DTDocumentosTipoAux = TADocumentosTipo.GetDataBy1(CodigoDocumentoTipo);
                if (DTDocumentosTipoAux.Count > 0)
                    DRConcepto = DTDocumentosTipoAux[0];
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
                TxtCodigoTipoDocumento.Text = DRConcepto.CodigoDocumentoTipo.ToString();
                TxtNombreDocumento.Text = DRConcepto.NombreDocumento;
                rTextBoxDescripcionDocumento.Text = DRConcepto.IsDescripcionNull() ? String.Empty : DRConcepto.Descripcion;


                habilitarBotones(true, false, false, true, true);
                habilitarControles(false);
            }
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            TxtNombreDocumento.ReadOnly = !estadoHabilitacion;
            rTextBoxDescripcionDocumento.Enabled = estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool editar, bool eliminar)
        {
            this.btnAñadirDocumento.Enabled = nuevo;
            this.btnGuardarDocumento.Enabled = aceptar;
            this.btnCancelar.Enabled = cancelar;
            this.btnEditarDocumento.Enabled = editar;
            this.btnEliminarDocumento.Enabled = eliminar;
        }

        public void limpiarControles()
        {
            TxtNombreDocumento.Text = string.Empty;
            rTextBoxDescripcionDocumento.Text = string.Empty;
        }

        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(TxtNombreDocumento.Text.Trim()))
            {
                eProviderDocumentosTipo.SetError(TxtNombreDocumento, "Aún no ha Ingresado el Nombre de Tipo de Documento");
                TxtNombreDocumento.Focus();
                TxtNombreDocumento.SelectAll();
                return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int? NumeroDocumentosTipoiguiente = 0;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("DocumentosTipo", ref NumeroDocumentosTipoiguiente);
            NumeroDocumentosTipoiguiente = NumeroDocumentosTipoiguiente == -1
                 ? 1 : NumeroDocumentosTipoiguiente.Value + 1;
            TxtCodigoTipoDocumento.Text = NumeroDocumentosTipoiguiente.ToString();
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
                eProviderDocumentosTipo.Clear();
                if (validarDatos())
                {
                    int CodigoNumeroAuxiliar = int.Parse(TxtCodigoTipoDocumento.Text);
                    if (TipoOperacion == "I")
                    {
                        
                        TADocumentosTipo.Insert(TxtNombreDocumento.Text.Trim(), rTextBoxDescripcionDocumento.Text);
                        DSTrabajo_Social.DocumentosTipoRow DRDocumentoNuevo = DTDocumentosTipo.AddDocumentosTipoRow(TxtNombreDocumento.Text.Trim(), rTextBoxDescripcionDocumento.Text);
                        DRDocumentoNuevo.CodigoDocumentoTipo = CodigoNumeroAuxiliar;
                        DRDocumentoNuevo.AcceptChanges();
                        DTDocumentosTipo.AcceptChanges();
                    }

                    else
                    {
                        TADocumentosTipo.ActualizarDocumentoTipo(int.Parse(TxtCodigoTipoDocumento.Text), TxtNombreDocumento.Text, rTextBoxDescripcionDocumento.Text);
                        int indiceEdicion = DTDocumentosTipo.Rows.IndexOf(DTDocumentosTipo.FindByCodigoDocumentoTipo(int.Parse(TxtCodigoTipoDocumento.Text)));
                        DTDocumentosTipo[indiceEdicion].NombreDocumento = TxtNombreDocumento.Text;
                        DTDocumentosTipo[indiceEdicion].Descripcion = rTextBoxDescripcionDocumento.Text;
                        DTDocumentosTipo.AcceptChanges();
                        
                    }
                    this.CodigoDocumentoTipo = CodigoNumeroAuxiliar;
                    habilitarBotones(true, false, false, true, true);
                    habilitarControles(false);
                    TipoOperacion = "";
                    MessageBox.Show(this, "Operación realizada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (soloInsertarEditar)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        bdSourceDocumentosTipos.MoveLast();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Falta completar el llenado de algunos campos que son necesarios, revise sus datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
            eProviderDocumentosTipo.Clear();
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false);
            bdSourceDocumentosTipos_CurrentChanged(bdSourceDocumentosTipos, e);
            if (soloInsertarEditar)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se Encuentra seguro de Eliminar el Registro Actual??", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DTDocumentosTipo.AcceptChanges();
                try
                {
                    TADocumentosTipo.Delete(int.Parse(TxtCodigoTipoDocumento.Text));
                    limpiarControles();
                    habilitarBotones(true, false, false, false, false);                    
                    DTDocumentosTipo.Rows.Remove(DTDocumentosTipo.FindByCodigoDocumentoTipo(int.Parse(TxtCodigoTipoDocumento.Text)));
                    //
                }
                catch (Exception )
                {
                    MessageBox.Show(this, "No se pudo culminar la operación actual, seguramente el registro se encuentra en uso en otras operaciones del sistema", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }



        private void bdSourceDocumentosTipos_CurrentChanged(object sender, EventArgs e)
        {

            if (bdSourceDocumentosTipos.Position >= 0)
            {
                CargarDatosConcepto(DTDocumentosTipo[bdSourceDocumentosTipos.Position].CodigoDocumentoTipo);

                if (soloInsertarEditar && (DialogResult == System.Windows.Forms.DialogResult.OK || DialogResult == System.Windows.Forms.DialogResult.Cancel))
                {
                    CodigoDocumentoTipo = DTDocumentosTipo[bdSourceDocumentosTipos.Position].CodigoDocumentoTipo;
                    this.Close();
                }
            }

        }

        public void configurarFormularioIA(int? CodigoDocumentoTipo)
        {
            CargarDatosConcepto(CodigoDocumentoTipo != null ? CodigoDocumentoTipo.Value : -1);
            if (CodigoDocumentoTipo == null)
            {
                int? NumeroDocumentosTipoiguiente = 0;
                TAFuncionesSistema.ObtenerUltimoIndiceTabla("DocumentosTipo", ref NumeroDocumentosTipoiguiente);
                NumeroDocumentosTipoiguiente = NumeroDocumentosTipoiguiente == -1
                     ? 1 : NumeroDocumentosTipoiguiente.Value + 1;
                TxtCodigoTipoDocumento.Text = NumeroDocumentosTipoiguiente.ToString();
            }
            TipoOperacion = CodigoDocumentoTipo == null ? "I" : "E";
            soloInsertarEditar = true;
            dtGVListadoDocumentos.Visible = false;
            //290
            btnEditarDocumento.Visible = btnAñadirDocumento.Visible = btnEliminarDocumento.Visible = false;
            this.Size = new Size(this.Size.Width, gBoxDetalle.Size.Height + pnlBotones.Size.Height + 35);
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false);
        }

        private void btnCerrarAñadirDocumento_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }
    }
}
