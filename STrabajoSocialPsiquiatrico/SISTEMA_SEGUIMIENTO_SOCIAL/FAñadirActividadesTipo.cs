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
    public partial class FAñadirActividadesTipo : Form
    {
        
        ActividadesTipoTableAdapter TAActividadesTipo;        
        DSTrabajo_Social.ActividadesTipoDataTable DTActividadesTipo;
        QTAFuncionesSistema TAFuncionesSistema;
        ErrorProvider eProviderActividadesTipo;
        string TipoOperacion = "";
        private bool soloInsertarEditar = false;
        public int CodigoActividadTipo { get; set; }
        public FAñadirActividadesTipo()
        {
            InitializeComponent();

            try
            {
                DTActividadesTipo = new DSTrabajo_Social.ActividadesTipoDataTable();
                TAActividadesTipo = new ActividadesTipoTableAdapter();
                TAFuncionesSistema = new QTAFuncionesSistema();

                eProviderActividadesTipo = new ErrorProvider();
                DTActividadesTipo = TAActividadesTipo.GetData();
                bdSourceActividadesTipos.DataSource = DTActividadesTipo;
                cBoxClaseActividad.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaClasesActividades();
                cBoxClaseActividad.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
                cBoxClaseActividad.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
                CargarDatosConcepto(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió la siguiente excepción al momento de cargar el Formulario " + ex.Message);
                throw;
            }
            Visible = true;
        }

        public void CargarDatosConcepto(int CodigoActividadTipo)
        {

            DSTrabajo_Social.ActividadesTipoRow DRConcepto = DTActividadesTipo.FindByCodigoActividadTipo(CodigoActividadTipo);
            if (DRConcepto == null)
            {
                DSTrabajo_Social.ActividadesTipoDataTable DTActividadesTipoAux = TAActividadesTipo.GetDataBy1(CodigoActividadTipo);
                if (DTActividadesTipoAux.Count > 0)
                    DRConcepto = DTActividadesTipoAux[0];
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
                TxtCodigoTipoActividad.Text = DRConcepto.CodigoActividadTipo.ToString();
                TxtNombreActividad.Text = DRConcepto.NombreActividad;
                rTextBoxDescripcionActividad.Text = DRConcepto.IsDescripcionNull() ? String.Empty : DRConcepto.Descripcion;
                if (DRConcepto.IsCodigoClaseActividadNull())
                    cBoxClaseActividad.SelectedIndex = -1;
                else
                    cBoxClaseActividad.SelectedValue = DRConcepto.CodigoClaseActividad;

                habilitarBotones(true, false, false, true, true);
                habilitarControles(false);
            }
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            TxtNombreActividad.ReadOnly = !estadoHabilitacion;
            rTextBoxDescripcionActividad.Enabled = estadoHabilitacion;
            cBoxClaseActividad.Enabled = estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool editar, bool eliminar)
        {
            this.btnAñadirActividad.Enabled = nuevo;
            this.btnGuardarActividad.Enabled = aceptar;
            this.btnCancelar.Enabled = cancelar;
            this.btnEditarActividad.Enabled = editar;
            this.btnEliminarActividad.Enabled = eliminar;
        }

        public void limpiarControles()
        {
            TxtNombreActividad.Text = string.Empty;
            rTextBoxDescripcionActividad.Text = string.Empty;
            cBoxClaseActividad.SelectedIndex = -1;
        }

        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(TxtNombreActividad.Text.Trim()))
            {
                eProviderActividadesTipo.SetError(TxtNombreActividad, "Aún no ha Ingresado el Nombre de Tipo de Actividad");
                TxtNombreActividad.Focus();
                TxtNombreActividad.SelectAll();
                return false;
            }
            if (cBoxClaseActividad.SelectedIndex == -1)
            {
                eProviderActividadesTipo.SetError(cBoxClaseActividad, "Aún no ha seleccionado la Clase de Actividad");
                cBoxClaseActividad.Focus();
                cBoxClaseActividad.SelectAll();
                return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int? NumeroActividadesTipoiguiente = 0;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("ActividadesTipo", ref NumeroActividadesTipoiguiente);
            NumeroActividadesTipoiguiente = NumeroActividadesTipoiguiente == -1
                 ? 1 : NumeroActividadesTipoiguiente.Value + 1;
            TxtCodigoTipoActividad.Text = NumeroActividadesTipoiguiente.ToString();
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
                eProviderActividadesTipo.Clear();
                if (validarDatos())
                {
                    int CodigoNumeroAuxiliar = int.Parse(TxtCodigoTipoActividad.Text);
                    if (TipoOperacion == "I")
                    {
                        TAActividadesTipo.Insert(TxtNombreActividad.Text.Trim(), rTextBoxDescripcionActividad.Text, cBoxClaseActividad.SelectedValue.ToString());
                        DSTrabajo_Social.ActividadesTipoRow DRConceptoNuevo = DTActividadesTipo.AddActividadesTipoRow(TxtNombreActividad.Text.Trim(), rTextBoxDescripcionActividad.Text, cBoxClaseActividad.SelectedValue.ToString());
                        DRConceptoNuevo.CodigoActividadTipo = CodigoNumeroAuxiliar;
                        DRConceptoNuevo.AcceptChanges();
                        DTActividadesTipo.AcceptChanges();
                    }

                    else
                    {
                        TAActividadesTipo.ActualizarActividadeTipo(int.Parse(TxtCodigoTipoActividad.Text), TxtNombreActividad.Text, rTextBoxDescripcionActividad.Text, cBoxClaseActividad.SelectedValue.ToString());
                        int indiceEdicion = DTActividadesTipo.Rows.IndexOf(DTActividadesTipo.FindByCodigoActividadTipo(int.Parse(TxtCodigoTipoActividad.Text)));
                        DTActividadesTipo[indiceEdicion].NombreActividad= TxtNombreActividad.Text;
                        DTActividadesTipo[indiceEdicion].Descripcion = rTextBoxDescripcionActividad.Text;
                        DTActividadesTipo[indiceEdicion].CodigoClaseActividad = cBoxClaseActividad.SelectedValue.ToString();
                        DTActividadesTipo.AcceptChanges();
                    }
                    habilitarBotones(true, false, false, true, true);
                    habilitarControles(false);
                    TipoOperacion = "";
                    MessageBox.Show(this, "Operación Realizada Correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CodigoActividadTipo = CodigoNumeroAuxiliar;
                    if (soloInsertarEditar)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        bdSourceActividadesTipos.MoveLast();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Falta completar el llenado de algunos campos que son necesarios. Por favor revise su datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudo Culminar satisfactoriamente la operación actual, debido a que ocurrió la siguiente excepción " +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            eProviderActividadesTipo.Clear();
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false);
            bdSourceActividadesTipos_CurrentChanged(bdSourceActividadesTipos, e);
            if (soloInsertarEditar)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de Eliminar el registro Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    TAActividadesTipo.Delete(int.Parse(TxtCodigoTipoActividad.Text));
                    limpiarControles();
                    habilitarBotones(true, false, false, false, false);
                    DTActividadesTipo.Rows.Remove(DTActividadesTipo.FindByCodigoActividadTipo(int.Parse(TxtCodigoTipoActividad.Text)));
                    DTActividadesTipo.AcceptChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "No se pudo Eliminar el Registro Actual, probablemente se encuentra en uso en otros registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }



        private void bdSourceActividadesTipos_CurrentChanged(object sender, EventArgs e)
        {
            
            if (bdSourceActividadesTipos.Position >= 0)
            {
                CargarDatosConcepto(DTActividadesTipo[bdSourceActividadesTipos.Position].CodigoActividadTipo);

                if (soloInsertarEditar && (DialogResult == System.Windows.Forms.DialogResult.OK || DialogResult == System.Windows.Forms.DialogResult.Cancel))
                {
                    CodigoActividadTipo = DTActividadesTipo[bdSourceActividadesTipos.Position].CodigoActividadTipo;
                    this.Close();
                }
            }
            
        }

        public void configurarFormularioIA(int? CodigoActividadTipo)
        {
            CargarDatosConcepto(CodigoActividadTipo != null ? CodigoActividadTipo.Value : -1);
            if (CodigoActividadTipo == null)
            {
                int? NumeroActividadesTipoiguiente = 0;
                TAFuncionesSistema.ObtenerUltimoIndiceTabla("ActividadesTipo", ref NumeroActividadesTipoiguiente);
                NumeroActividadesTipoiguiente = NumeroActividadesTipoiguiente == -1
                     ? 1 : NumeroActividadesTipoiguiente.Value + 1;
                TxtCodigoTipoActividad.Text = NumeroActividadesTipoiguiente.ToString();
            }
            TipoOperacion = CodigoActividadTipo == null ? "I" : "E";
            soloInsertarEditar = true;
            dtGVListadoACtividades.Visible = false;
            //290
            btnEditarActividad.Visible = btnAñadirActividad.Visible = btnEliminarActividad.Visible = false;
            this.Size = new Size(this.Size.Width, gBoxDetalle.Size.Height + pnlBotones.Size.Height + 35 );
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false);
        }

        private void btnCerrarAñadirActividad_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }


    }
}
