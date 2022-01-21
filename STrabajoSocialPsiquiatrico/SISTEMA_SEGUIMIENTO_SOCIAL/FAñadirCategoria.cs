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
    public partial class FAñadirCategoria : Form
    {

        CategoriasTableAdapter TACategorias;
        DSTrabajo_Social.CategoriasDataTable DTCategorias;
        QTAFuncionesSistema TAFuncionesSistema;
        ErrorProvider eProviderCategorias;
        string TipoOperacion = "";
        private bool soloInsertarEditar = false;
        public int CodigoCategoria { get; set; }
        public FAñadirCategoria()
        {
            InitializeComponent();

            try
            {
                DTCategorias = new DSTrabajo_Social.CategoriasDataTable();
                TACategorias = new CategoriasTableAdapter();
                TAFuncionesSistema = new QTAFuncionesSistema();

                eProviderCategorias = new ErrorProvider();
                DTCategorias = TACategorias.GetData();
                bdSourceCategorias.DataSource = DTCategorias;
                TxtPuntajeMaximo.KeyPress += Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress;
                TxtPuntajeMinimo.KeyPress += Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress;
                TxtAporteUsuario.KeyPress += Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress;
                TxtSubvencionInstitucional.KeyPress += Utilidades.EventosValidacionTexto.TextBoxFlotantes_KeyPress;
                CargarDatosConcepto(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió la siguiente excepción al momento de cargar el Formulario " + ex.Message);
                throw;
            }
            Visible = true;
        }

        public void CargarDatosConcepto(int CodigoCategoria)
        {

            DSTrabajo_Social.CategoriasRow DRCategoria = DTCategorias.FindByCodigoCategoria(CodigoCategoria);
            if (DRCategoria == null)
            {
                DSTrabajo_Social.CategoriasDataTable DTCategoriasAux = TACategorias.GetDataBy1(CodigoCategoria);
                if (DTCategoriasAux.Count > 0)
                    DRCategoria = DTCategoriasAux[0];
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
                TxtCodigoCategoria.Text = DRCategoria.CodigoCategoria.ToString();
                TxtNombreCategoria.Text = DRCategoria.NombreCategoria;
                TxtAporteUsuario.Text = DRCategoria.AporteUsuario.ToString();
                TxtSubvencionInstitucional.Text = DRCategoria.SubvencionInstitucional.ToString();
                TxtPuntajeMaximo.Text = DRCategoria.PuntajeMaximo.ToString();
                TxtPuntajeMinimo.Text = DRCategoria.PuntajeMinimo.ToString();


                habilitarBotones(true, false, false, true, true);
                habilitarControles(false);
            }
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            //TxtCodigoCategoria.ReadOnly = !estadoHabilitacion;
            TxtNombreCategoria.ReadOnly = !estadoHabilitacion;
            TxtAporteUsuario.ReadOnly = !estadoHabilitacion;
            TxtSubvencionInstitucional.ReadOnly = !estadoHabilitacion;
            TxtPuntajeMaximo.ReadOnly = !estadoHabilitacion;
            TxtPuntajeMinimo.ReadOnly = !estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool editar, bool eliminar)
        {
            this.btnAñadirCategoria.Enabled = nuevo;
            this.btnGuardarCategoria.Enabled = aceptar;
            this.btnCancelar.Enabled = cancelar;
            this.btnEditarCategoria.Enabled = editar;
            this.btnEliminarCategoria.Enabled = eliminar;
        }

        public void limpiarControles()
        {
            TxtCodigoCategoria.Text = String.Empty;
            TxtNombreCategoria.Text = String.Empty;
            TxtAporteUsuario.Text = String.Empty;
            TxtSubvencionInstitucional.Text = String.Empty;
            TxtPuntajeMaximo.Text = String.Empty;
            TxtPuntajeMinimo.Text = String.Empty;
        }

        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(TxtNombreCategoria.Text.Trim()))
            {
                eProviderCategorias.SetError(TxtNombreCategoria, "Aún no ha Ingresado el Nombre de la Categoría");
                TxtNombreCategoria.Focus();
                TxtNombreCategoria.SelectAll();
                return false;
            }

            if (TxtNombreCategoria.Text.Trim().Length > 1)
            {
                eProviderCategorias.SetError(TxtNombreCategoria, "El Nombre de la Categoría debe ser identificado por un SOLO CARACTER ALFABÉTICO");
                TxtNombreCategoria.Focus();
                TxtNombreCategoria.SelectAll();
                return false;
            }
            
            if (String.IsNullOrEmpty(TxtAporteUsuario.Text.Trim()))
            {
                eProviderCategorias.SetError(TxtAporteUsuario, "Aún no ha Ingresado el Aporte del Usuario");
                TxtAporteUsuario.Focus();
                TxtAporteUsuario.SelectAll();
                return false;
            }
            decimal ValorValidacion = -1;
            if (!decimal.TryParse(TxtAporteUsuario.Text, out ValorValidacion) || ValorValidacion < 0 || ValorValidacion > 100)
            {
                eProviderCategorias.SetError(TxtAporteUsuario, "El aporte del Usuario debe ser un Entero Positivo comprendido entre 0 y 100");
                TxtAporteUsuario.Focus();
                TxtAporteUsuario.SelectAll();
                return false;                
            }


            if (String.IsNullOrEmpty(TxtSubvencionInstitucional.Text.Trim()))
            {
                eProviderCategorias.SetError(TxtSubvencionInstitucional, "Aún no ha Ingresado la Subvención Institucional");
                TxtSubvencionInstitucional.Focus();
                TxtSubvencionInstitucional.SelectAll();
                return false;
            }
            if (!decimal.TryParse(TxtSubvencionInstitucional.Text, out ValorValidacion) || ValorValidacion < 0 || ValorValidacion > 100)
            {
                eProviderCategorias.SetError(TxtSubvencionInstitucional, "la Subvención Institucional debe ser un Entero Positivo comprendido entre 0 y 100");
                TxtSubvencionInstitucional.Focus();
                TxtSubvencionInstitucional.SelectAll();
                return false;
            }


            if (String.IsNullOrEmpty(TxtPuntajeMaximo.Text.Trim()))
            {
                eProviderCategorias.SetError(TxtPuntajeMaximo, "Aún no ha Ingresado el Puntaje Máximo");
                TxtPuntajeMaximo.Focus();
                TxtPuntajeMaximo.SelectAll();
                return false;
            }
            int ValorValidacion2 = -1;
            if (!int.TryParse(TxtPuntajeMaximo.Text, out ValorValidacion2) || ValorValidacion2 < 0)
            {
                eProviderCategorias.SetError(TxtPuntajeMaximo, "El Puntaje Máximo debe ser un Entero Positivo");
                TxtPuntajeMaximo.Focus();
                TxtPuntajeMaximo.SelectAll();
                return false;
            }

            if (String.IsNullOrEmpty(TxtPuntajeMinimo.Text.Trim()))
            {
                eProviderCategorias.SetError(TxtPuntajeMinimo, "Aún no ha Ingresado el Puntaje Mínimo");
                TxtPuntajeMinimo.Focus();
                TxtPuntajeMinimo.SelectAll();
                return false;
            }
            if (!int.TryParse(TxtPuntajeMinimo.Text, out ValorValidacion2) || ValorValidacion2 < 0)
            {
                eProviderCategorias.SetError(TxtPuntajeMinimo, "El Puntaje Mínimo debe ser un Entero Positivo");
                TxtPuntajeMinimo.Focus();
                TxtPuntajeMinimo.SelectAll();
                return false;
            }
            if (int.Parse(TxtPuntajeMinimo.Text) > int.Parse(TxtPuntajeMaximo.Text))
            {
                eProviderCategorias.SetError(TxtPuntajeMinimo, "El Puntaje Mínimo debe ser menor al Puntaje Máximo");
                TxtPuntajeMinimo.Focus();
                TxtPuntajeMinimo.SelectAll();
                return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarControles();
            int? NumeroCategoriasiguiente = 0;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("Categorias", ref NumeroCategoriasiguiente);
            NumeroCategoriasiguiente = NumeroCategoriasiguiente == -1
                 ? 1 : NumeroCategoriasiguiente.Value + 1;
            TxtCodigoCategoria.Text = NumeroCategoriasiguiente.ToString();
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
                eProviderCategorias.Clear();
                if (validarDatos())
                {
                    int CodigoNumeroAuxiliar = int.Parse(TxtCodigoCategoria.Text);
                    if (TipoOperacion == "I")
                    {
                        TACategorias.Insert(TxtNombreCategoria.Text.Trim(), int.Parse(TxtAporteUsuario.Text), int.Parse(TxtSubvencionInstitucional.Text),
                            int.Parse(TxtPuntajeMinimo.Text), int.Parse(TxtPuntajeMaximo.Text));
                        DSTrabajo_Social.CategoriasRow DRConceptoNuevo = DTCategorias.AddCategoriasRow(int.Parse(TxtAporteUsuario.Text), int.Parse(TxtSubvencionInstitucional.Text),
                            int.Parse(TxtPuntajeMinimo.Text), int.Parse(TxtPuntajeMaximo.Text), TxtNombreCategoria.Text.Trim());
                        DRConceptoNuevo.CodigoCategoria = CodigoNumeroAuxiliar;
                        DRConceptoNuevo.AcceptChanges();
                        DTCategorias.AcceptChanges();
                    }

                    else
                    {
                        TACategorias.ActualizarCategoria(int.Parse(TxtCodigoCategoria.Text),  TxtNombreCategoria.Text.Trim(), int.Parse(TxtAporteUsuario.Text), int.Parse(TxtSubvencionInstitucional.Text),
                            int.Parse(TxtPuntajeMinimo.Text), int.Parse(TxtPuntajeMaximo.Text));
                        int indiceEdicion = DTCategorias.Rows.IndexOf(DTCategorias.FindByCodigoCategoria(int.Parse(TxtCodigoCategoria.Text)));
                        DTCategorias[indiceEdicion].NombreCategoria = TxtNombreCategoria.Text;
                        DTCategorias[indiceEdicion].SubvencionInstitucional = int.Parse(TxtSubvencionInstitucional.Text);
                        DTCategorias[indiceEdicion].AporteUsuario = int.Parse(TxtAporteUsuario.Text);
                        DTCategorias[indiceEdicion].PuntajeMaximo = int.Parse(TxtPuntajeMaximo.Text);
                        DTCategorias[indiceEdicion].PuntajeMinimo= int.Parse(TxtPuntajeMinimo.Text);

                        DTCategorias.AcceptChanges();
                    }
                    habilitarBotones(true, false, false, true, true);
                    habilitarControles(false);
                    TipoOperacion = "";
                    MessageBox.Show(this, "Operación realizada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CodigoCategoria = CodigoNumeroAuxiliar;
                    if (soloInsertarEditar)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        bdSourceCategorias.MoveLast();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Falta completar el llenado de algunos campos que son necesarios, Revise sus datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
            eProviderCategorias.Clear();
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false);
            bdSourceCategorias_CurrentChanged(bdSourceCategorias, e);
            if (soloInsertarEditar)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se Encuentra seguro de Eliminar el Registro Actual??", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {                    
                    
                    TACategorias.Delete(int.Parse(TxtCodigoCategoria.Text));
                    DTCategorias.Rows.Remove(DTCategorias.FindByCodigoCategoria(int.Parse(TxtCodigoCategoria.Text)));
                    DTCategorias.AcceptChanges();
                    limpiarControles();
                    habilitarBotones(true, false, false, false, false);
                }
                catch (Exception )
                {
                    MessageBox.Show(this, "No se pudo Eliminar el registro actual, probablemente se encuentra en uso en otros registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }



        private void bdSourceCategorias_CurrentChanged(object sender, EventArgs e)
        {

            if (bdSourceCategorias.Position >= 0)
            {
                CargarDatosConcepto(DTCategorias[bdSourceCategorias.Position].CodigoCategoria);

                if (soloInsertarEditar && (DialogResult == System.Windows.Forms.DialogResult.OK || DialogResult == System.Windows.Forms.DialogResult.Cancel))
                {
                    CodigoCategoria = DTCategorias[bdSourceCategorias.Position].CodigoCategoria;
                    this.Close();
                }
            }

        }

        public void configurarFormularioIA(int? CodigoCategoria)
        {
            CargarDatosConcepto(CodigoCategoria != null ? CodigoCategoria.Value : -1);
            if (CodigoCategoria == null)
            {
                int? NumeroCategoriasiguiente = 0;
                TAFuncionesSistema.ObtenerUltimoIndiceTabla("Categorias", ref NumeroCategoriasiguiente);
                NumeroCategoriasiguiente = NumeroCategoriasiguiente == -1
                     ? 1 : NumeroCategoriasiguiente.Value + 1;
                TxtCodigoCategoria.Text = NumeroCategoriasiguiente.ToString();
            }
            TipoOperacion = CodigoCategoria == null ? "I" : "E";
            soloInsertarEditar = true;
            dtGVListadoCategorias.Visible = false;
            //290
            btnEditarCategoria.Visible = btnAñadirCategoria.Visible = btnEliminarCategoria.Visible = false;
            this.Size = new Size(groupBox2.Size.Width, this.Size.Height);
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
