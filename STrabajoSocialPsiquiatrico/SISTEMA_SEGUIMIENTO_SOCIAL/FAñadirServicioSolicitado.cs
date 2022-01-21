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
    public partial class FAñadirServicioSolicitado : Form
    {
        EspecialidadesTableAdapter TAEspecialidades;
        DSTrabajo_Social.EspecialidadesDataTable DTEspecialidades;
        QTAFuncionesSistema TAFuncionesSistema;
        ErrorProvider eProviderEspecialidades;
        string TipoOperacion = "";
        private bool soloInsertarEditar = false;
        public int CodigoEspecialidad { get; set; }
        public FAñadirServicioSolicitado()
        {
            InitializeComponent();

            try
            {
                TAEspecialidades = new EspecialidadesTableAdapter();
                TAFuncionesSistema = new QTAFuncionesSistema();

                eProviderEspecialidades = new ErrorProvider();
                DTEspecialidades = TAEspecialidades.GetData();
                bdSourceEspecialidades.DataSource = DTEspecialidades;
                CargarDatosConcepto(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió la siguiente excepción al momento de cargar el Formulario " + ex.Message);
                throw;
            }
            Visible = true;
        }

        public void CargarDatosConcepto(int CodigoEspecialidad)
        {

            DSTrabajo_Social.EspecialidadesRow DRCategoria = DTEspecialidades.FindByCodigoEspecialidad(CodigoEspecialidad);
            if (DRCategoria == null)
            {
                DSTrabajo_Social.EspecialidadesDataTable DTEspecialidadesAux = TAEspecialidades.GetDataBy1(CodigoEspecialidad);
                if (DTEspecialidadesAux.Count > 0)
                    DRCategoria = DTEspecialidadesAux[0];
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
                TxtCodigoEspecialidad.Text = DRCategoria.CodigoEspecialidad.ToString();
                TxtNombreEspecialidad.Text = DRCategoria.NombreEspecialidad;
                TxtDescripcion.Text = DRCategoria.Descripcion.ToString();
                


                habilitarBotones(true, false, false, true, true);
                habilitarControles(false);
            }
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            TxtNombreEspecialidad.ReadOnly = !estadoHabilitacion;
            TxtDescripcion.ReadOnly = !estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool editar, bool eliminar)
        {
            this.btnAñadirEspecialidad.Enabled = nuevo;
            this.btnGuardarEspecidalidad.Enabled = aceptar;
            this.btnCancelar.Enabled = cancelar;
            this.btnEditarESpecialidad.Enabled = editar;
            this.btnEliminarEspecialidad.Enabled = eliminar;
        }

        public void limpiarControles()
        {
            TxtCodigoEspecialidad.Text = String.Empty;
            TxtNombreEspecialidad.Text = String.Empty;
            TxtDescripcion.Text = String.Empty;
        }

        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(TxtNombreEspecialidad.Text.Trim()))
            {
                eProviderEspecialidades.SetError(TxtNombreEspecialidad, "Aún no ha Ingresado el Nombre de la Especialidad");
                TxtNombreEspecialidad.Focus();
                TxtNombreEspecialidad.SelectAll();
                return false;
            }
            
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarControles();
            int? NumeroEspecialidadesiguiente = 0;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("Especialidades", ref NumeroEspecialidadesiguiente);
            NumeroEspecialidadesiguiente = NumeroEspecialidadesiguiente == -1
                 ? 1 : NumeroEspecialidadesiguiente.Value + 1;
            TxtCodigoEspecialidad.Text = NumeroEspecialidadesiguiente.ToString();
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
                eProviderEspecialidades.Clear();
                if (validarDatos())
                {
                    int CodigoNumeroAuxiliar = int.Parse(TxtCodigoEspecialidad.Text);
                    if (TipoOperacion == "I")
                    {
                        TAEspecialidades.Insert(TxtNombreEspecialidad.Text.Trim(), TxtDescripcion.Text);
                        DSTrabajo_Social.EspecialidadesRow DRConceptoNuevo = DTEspecialidades.AddEspecialidadesRow(-1,TxtNombreEspecialidad.Text.Trim(), TxtDescripcion.Text);
                        DRConceptoNuevo.CodigoEspecialidad = CodigoNumeroAuxiliar;
                        DRConceptoNuevo.AcceptChanges();
                        DTEspecialidades.AcceptChanges();
                    }

                    else
                    {
                        TAEspecialidades.ActualizarEspecialidad(int.Parse(TxtCodigoEspecialidad.Text),  TxtNombreEspecialidad.Text.Trim(), TxtDescripcion.Text);
                        int indiceEdicion = DTEspecialidades.Rows.IndexOf(DTEspecialidades.FindByCodigoEspecialidad(int.Parse(TxtCodigoEspecialidad.Text)));
                        DTEspecialidades[indiceEdicion].NombreEspecialidad = TxtNombreEspecialidad.Text;
                        
                        DTEspecialidades[indiceEdicion].Descripcion = TxtDescripcion.Text;
                        
                        DTEspecialidades.AcceptChanges();
                    }
                    habilitarBotones(true, false, false, true, true);
                    habilitarControles(false);
                    TipoOperacion = "";
                    MessageBox.Show(this, "Operación realizada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CodigoEspecialidad = CodigoNumeroAuxiliar;
                    if (soloInsertarEditar)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        bdSourceEspecialidades.MoveLast();
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
            eProviderEspecialidades.Clear();
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false);
            bdSourceEspecialidades_CurrentChanged(bdSourceEspecialidades, e);
            if (soloInsertarEditar)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de Eliminar el Registro Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    habilitarBotones(true, false, false, false, false);
                    TAEspecialidades.Delete(int.Parse(TxtCodigoEspecialidad.Text));
                    DTEspecialidades.Rows.Remove(DTEspecialidades.FindByCodigoEspecialidad(int.Parse(TxtCodigoEspecialidad.Text)));
                    DTEspecialidades.AcceptChanges();
                    limpiarControles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede eliminar el registro actual, probablemente se encuentra en uso en alguna otra operación ya registrada");
                }
            }
        }



        private void bdSourceEspecialidades_CurrentChanged(object sender, EventArgs e)
        {

            if (bdSourceEspecialidades.Position >= 0)
            {
                CargarDatosConcepto(DTEspecialidades[bdSourceEspecialidades.Position].CodigoEspecialidad);

                if (soloInsertarEditar && (DialogResult == System.Windows.Forms.DialogResult.OK || DialogResult == System.Windows.Forms.DialogResult.Cancel))
                {
                    CodigoEspecialidad = DTEspecialidades[bdSourceEspecialidades.Position].CodigoEspecialidad;
                    this.Close();
                }
            }

        }

        public void configurarFormularioIA(int? CodigoEspecialidad)
        {
            CargarDatosConcepto(CodigoEspecialidad != null ? CodigoEspecialidad.Value : -1);
            if (CodigoEspecialidad == null)
            {
                int? NumeroEspecialidadesiguiente = 0;
                TAFuncionesSistema.ObtenerUltimoIndiceTabla("Especialidades", ref NumeroEspecialidadesiguiente);
                NumeroEspecialidadesiguiente = NumeroEspecialidadesiguiente == -1
                     ? 1 : NumeroEspecialidadesiguiente.Value + 1;
                TxtCodigoEspecialidad.Text = NumeroEspecialidadesiguiente.ToString();
            }
            TipoOperacion = CodigoEspecialidad == null ? "I" : "E";
            soloInsertarEditar = true;
            dtGVListadoEspecialidad.Visible = false;
            //290
            btnEditarESpecialidad.Visible = btnAñadirEspecialidad.Visible = btnEliminarEspecialidad.Visible = false;
            //this.Size = new Size(this.Size.Width, 200);
            this.Size = new Size(this.Size.Width, gBoxDatos.Size.Height + pnlBotones.Size.Height + 35);
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
