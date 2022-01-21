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
    public partial class FAñadirInstitución : Form
    {

        UnidadesMedicasTableAdapter TAUnidadesMedicas;
        DSTrabajo_Social.UnidadesMedicasDataTable DTUnidadesMedicas;
        QTAFuncionesSistema TAFuncionesSistema;
        ErrorProvider eProviderUnidadesMedicas;
        string TipoOperacion = "";
        private bool soloInsertarEditar = false;
        public int CodigoUnidadMedica { get; set; }
        public FAñadirInstitución()
        {
            InitializeComponent();

            try
            {
                DTUnidadesMedicas = new DSTrabajo_Social.UnidadesMedicasDataTable();
                TAUnidadesMedicas = new UnidadesMedicasTableAdapter();
                TAFuncionesSistema = new QTAFuncionesSistema();

                eProviderUnidadesMedicas = new ErrorProvider();
                DTUnidadesMedicas = TAUnidadesMedicas.GetData();
                bdSourceUnidadesMedicas.DataSource = DTUnidadesMedicas;

                cBoxTipoUnidadMedica.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaTipoReferencia();
                cBoxTipoUnidadMedica.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
                cBoxTipoUnidadMedica.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
                cBoxTipoUnidadMedica.SelectedIndex = -1;

                CargarDatosConcepto(-1);
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió la siguiente excepción al momento de cargar el Formulario " + ex.Message);
                throw;
            }
            
        }

        public void CargarDatosConcepto(int CodigoUnidadMedica)
        {

            DSTrabajo_Social.UnidadesMedicasRow DRUnidadMedica = DTUnidadesMedicas.FindByCodigoUnidadMedica(CodigoUnidadMedica);
            if (DRUnidadMedica == null)
            {
                DSTrabajo_Social.UnidadesMedicasDataTable DTUnidadesMedicasAux = TAUnidadesMedicas.GetDataBy1(CodigoUnidadMedica);
                if (DTUnidadesMedicasAux.Count > 0)
                    DRUnidadMedica = DTUnidadesMedicasAux[0];
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
                TxtCodigoUnidadMedica.Text = DRUnidadMedica.CodigoUnidadMedica.ToString();
                TxtNombreUnidadMedica.Text = DRUnidadMedica.NombreUnidadMedica;
                rTextBoxDescripcionUMedica.Text = DRUnidadMedica.IsDescripcionNull() ? String.Empty : DRUnidadMedica.Descripcion;
                TxtTelefonoUnidadMedica.Text = DRUnidadMedica.TelefonoUnidadMedica;
                TxtDireccionUnidadMedica.Text = DRUnidadMedica.DireccionUnidadMedica;
                if (DRUnidadMedica.IsCodigoTipoUnidadMedicaNull())
                    cBoxTipoUnidadMedica.SelectedIndex = -1;
                else
                    cBoxTipoUnidadMedica.SelectedValue = DRUnidadMedica.CodigoTipoUnidadMedica;

                habilitarBotones(true, false, false, true, true);
                habilitarControles(false);
            }
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            TxtNombreUnidadMedica.ReadOnly = !estadoHabilitacion;
            rTextBoxDescripcionUMedica.Enabled = estadoHabilitacion;
            TxtDireccionUnidadMedica.Enabled = estadoHabilitacion;
            TxtTelefonoUnidadMedica.Enabled = estadoHabilitacion;
            cBoxTipoUnidadMedica.Enabled = estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool editar, bool eliminar)
        {
            this.btnAñadirUMedica.Enabled = nuevo;
            this.btnGuardarUMedica.Enabled = aceptar;
            this.btnCancelar.Enabled = cancelar;
            this.btnEditarUMedica.Enabled = editar;
            this.btnEliminarUMedica.Enabled = eliminar;
        }

        public void limpiarControles()
        {
            TxtNombreUnidadMedica.Text = string.Empty;
            rTextBoxDescripcionUMedica.Text = string.Empty;
            TxtDireccionUnidadMedica.Text = string.Empty;
            TxtTelefonoUnidadMedica.Text = string.Empty;
            cBoxTipoUnidadMedica.SelectedIndex = -1;
        }

        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(TxtNombreUnidadMedica.Text.Trim()))
            {
                eProviderUnidadesMedicas.SetError(TxtNombreUnidadMedica, "Aún no ha Ingresado el Nombre de la Institución");
                TxtNombreUnidadMedica.Focus();
                TxtNombreUnidadMedica.SelectAll();
                return false;
            }
            if (String.IsNullOrEmpty(TxtDireccionUnidadMedica.Text.Trim()))
            {
                eProviderUnidadesMedicas.SetError(TxtDireccionUnidadMedica, "Aún no ha Ingresado la Dirección de la Institución");
                TxtDireccionUnidadMedica.Focus();
                TxtDireccionUnidadMedica.SelectAll();
                return false;
            }
            if (cBoxTipoUnidadMedica.SelectedIndex == -1)
            {
                eProviderUnidadesMedicas.SetError(cBoxTipoUnidadMedica, "Aún no ha seleccionado el Tipo de Institución");
                cBoxTipoUnidadMedica.Focus();
                cBoxTipoUnidadMedica.SelectAll();
                return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int? NumeroUnidadesMedicasiguiente = 0;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("UnidadesMedicas", ref NumeroUnidadesMedicasiguiente);
            NumeroUnidadesMedicasiguiente = NumeroUnidadesMedicasiguiente == -1
                 ? 1 : NumeroUnidadesMedicasiguiente.Value + 1;
            TxtCodigoUnidadMedica.Text = NumeroUnidadesMedicasiguiente.ToString();
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
                eProviderUnidadesMedicas.Clear();
                if (validarDatos())
                {
                    int CodigoNumeroAuxiliar = int.Parse(TxtCodigoUnidadMedica.Text);
                    if (TipoOperacion == "I")
                    {
                        TAUnidadesMedicas.Insert(TxtNombreUnidadMedica.Text.Trim(), TxtDireccionUnidadMedica.Text, TxtTelefonoUnidadMedica.Text, 
                            cBoxTipoUnidadMedica.SelectedValue.ToString(), rTextBoxDescripcionUMedica.Text);
                        DSTrabajo_Social.UnidadesMedicasRow DRUnidadMedicaNuevo = DTUnidadesMedicas.AddUnidadesMedicasRow(TxtNombreUnidadMedica.Text.Trim(), TxtDireccionUnidadMedica.Text,
                            TxtDireccionUnidadMedica.Text, cBoxTipoUnidadMedica.SelectedValue.ToString(), TxtTelefonoUnidadMedica.Text);
                        DRUnidadMedicaNuevo.CodigoUnidadMedica = CodigoNumeroAuxiliar;
                        DRUnidadMedicaNuevo.AcceptChanges();
                        DTUnidadesMedicas.AcceptChanges();
                    }

                    else
                    {
                        TAUnidadesMedicas.ActualizarUnidadMedica(int.Parse(TxtCodigoUnidadMedica.Text), TxtNombreUnidadMedica.Text.Trim(),
                            TxtDireccionUnidadMedica.Text, TxtTelefonoUnidadMedica.Text, cBoxTipoUnidadMedica.SelectedValue.ToString(), rTextBoxDescripcionUMedica.Text);
                        int indiceEdicion = DTUnidadesMedicas.Rows.IndexOf(DTUnidadesMedicas.FindByCodigoUnidadMedica(int.Parse(TxtCodigoUnidadMedica.Text)));
                        DTUnidadesMedicas[indiceEdicion].NombreUnidadMedica = TxtNombreUnidadMedica.Text;
                        DTUnidadesMedicas[indiceEdicion].Descripcion = rTextBoxDescripcionUMedica.Text;
                        DTUnidadesMedicas[indiceEdicion].TelefonoUnidadMedica = TxtTelefonoUnidadMedica.Text;
                        DTUnidadesMedicas[indiceEdicion].DireccionUnidadMedica = TxtDireccionUnidadMedica.Text;
                        DTUnidadesMedicas[indiceEdicion].CodigoTipoUnidadMedica = cBoxTipoUnidadMedica.SelectedValue.ToString();
                        DTUnidadesMedicas.AcceptChanges();
                    }
                    habilitarBotones(true, false, false, true, true);
                    habilitarControles(false);
                    TipoOperacion = "";
                    MessageBox.Show(this, "Operación realizada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CodigoUnidadMedica = CodigoNumeroAuxiliar;
                    if (soloInsertarEditar)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        bdSourceUnidadesMedicas.MoveLast();
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
            eProviderUnidadesMedicas.Clear();
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false);
            bdSourceUnidadesMedicas_CurrentChanged(bdSourceUnidadesMedicas, e);
            if (soloInsertarEditar)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se Encuentra seguro de Eliminar el Registro Actual??", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    limpiarControles();
                    habilitarBotones(true, false, false, false, false);
                    TAUnidadesMedicas.Delete(int.Parse(TxtCodigoUnidadMedica.Text));
                    DTUnidadesMedicas.Rows.Remove(DTUnidadesMedicas.FindByCodigoUnidadMedica(int.Parse(TxtCodigoUnidadMedica.Text)));
                    DTUnidadesMedicas.AcceptChanges();
                }
                catch (Exception )
                {
                    MessageBox.Show(this, "No se pudo Eliminar el Registro Actual, probablemente se encuentra en uso en otros registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }



        private void bdSourceUnidadesMedicas_CurrentChanged(object sender, EventArgs e)
        {

            if (bdSourceUnidadesMedicas.Position >= 0)
            {
                CargarDatosConcepto(DTUnidadesMedicas[bdSourceUnidadesMedicas.Position].CodigoUnidadMedica);

                if (soloInsertarEditar && (DialogResult == System.Windows.Forms.DialogResult.OK || DialogResult == System.Windows.Forms.DialogResult.Cancel))
                {
                    CodigoUnidadMedica = DTUnidadesMedicas[bdSourceUnidadesMedicas.Position].CodigoUnidadMedica;
                    this.Close();
                }
            }

        }

        public void configurarFormularioIA(int? CodigoUnidadMedica)
        {
            CargarDatosConcepto(CodigoUnidadMedica != null ? CodigoUnidadMedica.Value : -1);
            if (CodigoUnidadMedica == null)
            {
                int? NumeroUnidadesMedicasiguiente = 0;
                TAFuncionesSistema.ObtenerUltimoIndiceTabla("UnidadesMedicas", ref NumeroUnidadesMedicasiguiente);
                NumeroUnidadesMedicasiguiente = NumeroUnidadesMedicasiguiente == -1
                     ? 1 : NumeroUnidadesMedicasiguiente.Value + 1;
                TxtCodigoUnidadMedica.Text = NumeroUnidadesMedicasiguiente.ToString();
            }
            TipoOperacion = CodigoUnidadMedica == null ? "I" : "E";
            soloInsertarEditar = true;
            groupBox1.Visible = false;
            //295
            btnEditarUMedica.Visible = btnAñadirUMedica.Visible = btnEliminarUMedica.Visible = false;
            this.Size = new Size(this.Size.Width, gBoxDetalle.Size.Height + pnlBotones.Size.Height + 50);
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
