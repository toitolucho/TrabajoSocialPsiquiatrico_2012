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
    public partial class FAñadirDatosPersona : Form
    {

        TrabajadoresSocialesTableAdapter TATrabajadoresSociales;
        UnidadesMedicasTableAdapter TAUnidadesMedicas;
        OcupacionesTableAdapter TAOcupaciones;
        DSTrabajo_Social.TrabajadoresSocialesDataTable DTTrabajadoresSociales;
        DSTrabajo_Social.UnidadesMedicasDataTable DTUnidadesMedicas;
        DSTrabajo_Social.OcupacionesDataTable DTOcupaciones;
        QTAFuncionesSistema TAFuncionesSistema;
        ErrorProvider eProviderTrabajadoresSociales;
        string TipoOperacion = "";
        private bool soloInsertarEditar = false;
        public int CodigoTrabajadorSocial { get; set; }
        public FAñadirDatosPersona()
        {
            InitializeComponent();

            try
            {
                DTTrabajadoresSociales = new DSTrabajo_Social.TrabajadoresSocialesDataTable();
                TATrabajadoresSociales = new TrabajadoresSocialesTableAdapter();                
                TAFuncionesSistema = new QTAFuncionesSistema();
                TAUnidadesMedicas = new UnidadesMedicasTableAdapter();
                TAOcupaciones = new OcupacionesTableAdapter();


                eProviderTrabajadoresSociales = new ErrorProvider();
                DTTrabajadoresSociales = TATrabajadoresSociales.GetData();
                bdSourceTrabajadoresSociales.DataSource = DTTrabajadoresSociales;

                DTUnidadesMedicas = new DSTrabajo_Social.UnidadesMedicasDataTable();
                DTUnidadesMedicas = TAUnidadesMedicas.GetData();
                cBoxUnidadMedica.DataSource = DTUnidadesMedicas;
                cBoxUnidadMedica.DisplayMember = "NombreUnidadMedica";
                cBoxUnidadMedica.ValueMember = "CodigoUnidadMedica";
                cBoxUnidadMedica.SelectedIndex = -1;

                DTOcupaciones = new DSTrabajo_Social.OcupacionesDataTable();
                DTOcupaciones = TAOcupaciones.GetData();
                cBoxOcupacion.DataSource = DTOcupaciones;
                cBoxOcupacion.DisplayMember = "NombreOcupacion";
                cBoxOcupacion.ValueMember = "CodigoOcupacion";
                cBoxOcupacion.SelectedIndex = -1;

                TxtTelefonoTrabSocial.KeyPress += new KeyPressEventHandler(Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress);
                TxtCelularTrabSocial.KeyPress += new KeyPressEventHandler(Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress);

                CargarDatosConcepto(-1);
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió la siguiente excepción al momento de cargar el Formulario " + ex.Message);
                throw;
            }
            Visible = true;
        }

        public void CargarDatosConcepto(int CodigoTrabajadorSocial)
        {

            DSTrabajo_Social.TrabajadoresSocialesRow DRTrabajaadorSocial = DTTrabajadoresSociales.FindByCodigoTrabajadorSocial(CodigoTrabajadorSocial);
            if (DRTrabajaadorSocial == null)
            {
                DSTrabajo_Social.TrabajadoresSocialesDataTable DTTrabajadoresSocialesAux = TATrabajadoresSociales.GetDataBy1(CodigoTrabajadorSocial);
                if (DTTrabajadoresSocialesAux.Count > 0)
                    DRTrabajaadorSocial = DTTrabajadoresSocialesAux[0];
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
                
                TxtCodigoTrabajoSocial.Text = DRTrabajaadorSocial.CodigoTrabajadorSocial.ToString();
                TxtNombreTrabSocial.Text = DRTrabajaadorSocial.NombreTS;
                TxtApellidoMTrabSocial.Text = DRTrabajaadorSocial.ApellidoMaternoTS;
                TxtApellidoPTrabSocial.Text = DRTrabajaadorSocial.ApellidoPaternoTS;
                TxtTelefonoTrabSocial.Text = DRTrabajaadorSocial.IsTelefonoNull() ? "" : DRTrabajaadorSocial.Telefono;
                TxtCelularTrabSocial.Text = DRTrabajaadorSocial.IsCelularNull() ? "" : DRTrabajaadorSocial.Celular;
                TxtDireccionTrabSocial.Text = DRTrabajaadorSocial.IsDirecciónNull() ? "" : DRTrabajaadorSocial.Dirección;
                cBoxUnidadMedica.SelectedValue = DRTrabajaadorSocial.CodigoUnidadMedica;
                if (DRTrabajaadorSocial.IsCodigoOcupacionNull())
                    cBoxOcupacion.SelectedIndex = -1;
                else
                    cBoxOcupacion.SelectedValue = DRTrabajaadorSocial.CodigoOcupacion;

                habilitarBotones(true, false, false, true, true);
                habilitarControles(false);
            }
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            TxtNombreTrabSocial.ReadOnly = !estadoHabilitacion;
            TxtApellidoMTrabSocial.ReadOnly = !estadoHabilitacion;
            TxtApellidoPTrabSocial.ReadOnly = !estadoHabilitacion;
            TxtTelefonoTrabSocial.ReadOnly = !estadoHabilitacion;
            TxtCelularTrabSocial.ReadOnly = !estadoHabilitacion;
            TxtDireccionTrabSocial.ReadOnly = !estadoHabilitacion;
            cBoxUnidadMedica.Enabled = estadoHabilitacion;
            cBoxOcupacion.Enabled = estadoHabilitacion;
            btnAñadirUnidadMedica.Enabled = estadoHabilitacion;
            btnAnadirOcupacion.Enabled = estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool editar, bool eliminar)
        {
            this.btnAñadirTrabSocial.Enabled = nuevo;
            this.btnGuardarTrabSocial.Enabled = aceptar;
            this.btnCancelar.Enabled = cancelar;
            this.btnEditarTrabSocial.Enabled = editar;
            this.btnEliminarTrabSocial.Enabled = eliminar;
        }

        public void limpiarControles()
        {
            TxtNombreTrabSocial.Text = String.Empty;
            TxtApellidoMTrabSocial.Text = String.Empty;
            TxtApellidoPTrabSocial.Text = String.Empty;
            TxtTelefonoTrabSocial.Text = String.Empty;
            TxtCelularTrabSocial.Text = String.Empty;
            TxtDireccionTrabSocial.Text = String.Empty;
            cBoxUnidadMedica.SelectedIndex = -1;
            cBoxOcupacion.SelectedIndex = -1;
        }

        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(TxtNombreTrabSocial.Text.Trim()))
            {
                eProviderTrabajadoresSociales.SetError(TxtNombreTrabSocial, "Aún no ha Ingresado el Nombre de la Persona");
                TxtNombreTrabSocial.Focus();
                TxtNombreTrabSocial.SelectAll();
                return false;
            }
            if (String.IsNullOrEmpty(TxtApellidoPTrabSocial.Text.Trim()))
            {
                eProviderTrabajadoresSociales.SetError(TxtApellidoPTrabSocial, "Aún no ha Ingresado el Apellido Paterno de la Persona");
                TxtApellidoPTrabSocial.Focus();
                TxtApellidoPTrabSocial.SelectAll();
                return false;
            }

            if (String.IsNullOrEmpty(TxtApellidoMTrabSocial.Text.Trim()) &&
                MessageBox.Show(this,"¿Se Encuentra seguro de dejar en blanco el Apellido Materno?",this.Text, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                eProviderTrabajadoresSociales.SetError(TxtApellidoMTrabSocial, "Aún no ha Ingresado el Apellido Materno de la Persona");
                TxtApellidoMTrabSocial.Focus();
                TxtApellidoMTrabSocial.SelectAll();
                return false;
            }

            if (cBoxUnidadMedica.SelectedIndex < 0)
            {
                eProviderTrabajadoresSociales.SetError(cBoxUnidadMedica, "Aún no ha Seleccionado la Institución donde trabaja la Persona");
                cBoxUnidadMedica.Focus();                
                return false;
            }
            if (cBoxOcupacion.SelectedIndex < 0)
            {
                eProviderTrabajadoresSociales.SetError(cBoxOcupacion, "Aún no ha Seleccionado la Ocupación de la Persona");
                cBoxOcupacion.Focus();
                return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int? NumeroTrabajadoresSocialesiguiente = 0;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("TrabajadoresSociales", ref NumeroTrabajadoresSocialesiguiente);
            NumeroTrabajadoresSocialesiguiente = NumeroTrabajadoresSocialesiguiente == -1
                 ? 1 : NumeroTrabajadoresSocialesiguiente.Value + 1;
            TxtCodigoTrabajoSocial.Text = NumeroTrabajadoresSocialesiguiente.ToString();
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
                eProviderTrabajadoresSociales.Clear();
                if (validarDatos())
                {
                    int CodigoNumeroAuxiliar = int.Parse(TxtCodigoTrabajoSocial.Text);
                    if (TipoOperacion == "I")
                    {
                        TATrabajadoresSociales.Insert(TxtNombreTrabSocial.Text.Trim(), TxtApellidoPTrabSocial.Text, TxtApellidoMTrabSocial.Text, 
                            TxtDireccionTrabSocial.Text, TxtTelefonoTrabSocial.Text, TxtCelularTrabSocial.Text, 
                            int.Parse(cBoxUnidadMedica.SelectedValue.ToString()), byte.Parse(cBoxOcupacion.SelectedValue.ToString()));
                        DSTrabajo_Social.TrabajadoresSocialesRow DRUnidadMedicaNuevo = DTTrabajadoresSociales.AddTrabajadoresSocialesRow(TxtNombreTrabSocial.Text.Trim(), TxtApellidoPTrabSocial.Text, TxtApellidoMTrabSocial.Text,
                            TxtDireccionTrabSocial.Text, TxtTelefonoTrabSocial.Text, TxtCelularTrabSocial.Text, 
                            int.Parse(cBoxUnidadMedica.SelectedValue.ToString()), byte.Parse(cBoxOcupacion.SelectedValue.ToString()));
                        DRUnidadMedicaNuevo.CodigoTrabajadorSocial = CodigoNumeroAuxiliar;
                        DRUnidadMedicaNuevo.AcceptChanges();
                        DTTrabajadoresSociales.AcceptChanges();
                    }

                    else
                    {
                        TATrabajadoresSociales.ActualizarTrabajadorSocial(int.Parse(TxtCodigoTrabajoSocial.Text), TxtNombreTrabSocial.Text.Trim(), TxtApellidoPTrabSocial.Text, TxtApellidoMTrabSocial.Text,
                            TxtDireccionTrabSocial.Text, TxtTelefonoTrabSocial.Text, TxtCelularTrabSocial.Text, 
                            int.Parse(cBoxUnidadMedica.SelectedValue.ToString()), byte.Parse(cBoxOcupacion.SelectedValue.ToString()));                            
                        int indiceEdicion = DTTrabajadoresSociales.Rows.IndexOf(DTTrabajadoresSociales.FindByCodigoTrabajadorSocial(int.Parse(TxtCodigoTrabajoSocial.Text)));
                        DTTrabajadoresSociales[indiceEdicion].NombreTS = TxtNombreTrabSocial.Text;
                        DTTrabajadoresSociales[indiceEdicion].ApellidoMaternoTS = TxtApellidoMTrabSocial.Text;
                        DTTrabajadoresSociales[indiceEdicion].ApellidoPaternoTS = TxtApellidoPTrabSocial.Text;
                        DTTrabajadoresSociales[indiceEdicion].Dirección = TxtDireccionTrabSocial.Text;
                        DTTrabajadoresSociales[indiceEdicion].Telefono = TxtTelefonoTrabSocial.Text;
                        DTTrabajadoresSociales[indiceEdicion].Celular = TxtCelularTrabSocial.Text;
                        DTTrabajadoresSociales[indiceEdicion].CodigoUnidadMedica = int.Parse(cBoxUnidadMedica.SelectedValue.ToString());
                        DTTrabajadoresSociales[indiceEdicion].CodigoOcupacion = byte.Parse(cBoxOcupacion.SelectedValue.ToString());
                        DTTrabajadoresSociales.AcceptChanges();
                    }
                    habilitarBotones(true, false, false, true, true);
                    habilitarControles(false);
                    TipoOperacion = "";
                    MessageBox.Show(this, "Operación realizada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CodigoTrabajadorSocial = CodigoNumeroAuxiliar;
                    if (soloInsertarEditar)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        bdSourceTrabajadoresSociales.MoveLast();
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
            eProviderTrabajadoresSociales.Clear();
            TipoOperacion = "";
            limpiarControles();
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false);
            bdSourceTrabajadoresSociales_CurrentChanged(bdSourceTrabajadoresSociales, e);
            if (soloInsertarEditar)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se Encuentra seguro de Eliminar el registro Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    limpiarControles();
                    habilitarBotones(true, false, false, false, false);
                    TATrabajadoresSociales.Delete(int.Parse(TxtCodigoTrabajoSocial.Text));
                    DTTrabajadoresSociales.Rows.Remove(DTTrabajadoresSociales.FindByCodigoTrabajadorSocial(int.Parse(TxtCodigoTrabajoSocial.Text)));
                    DTTrabajadoresSociales.AcceptChanges();
                }
                catch (Exception )
                {
                    MessageBox.Show(this, "No se pudo Eliminar el Registro Actual, probablemente se encuentra en uso en otros registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }



        private void bdSourceTrabajadoresSociales_CurrentChanged(object sender, EventArgs e)
        {

            if (bdSourceTrabajadoresSociales.Position >= 0)
            {
                CargarDatosConcepto(DTTrabajadoresSociales[bdSourceTrabajadoresSociales.Position].CodigoTrabajadorSocial);

                if (soloInsertarEditar && (DialogResult == System.Windows.Forms.DialogResult.OK || DialogResult == System.Windows.Forms.DialogResult.Cancel))
                {
                    CodigoTrabajadorSocial = DTTrabajadoresSociales[bdSourceTrabajadoresSociales.Position].CodigoTrabajadorSocial;
                    this.Close();
                }
            }

        }

        public void configurarFormularioIA(int? CodigoTrabajadorSocial)
        {
            CargarDatosConcepto(CodigoTrabajadorSocial != null ? CodigoTrabajadorSocial.Value : -1);
            if (CodigoTrabajadorSocial == null)
            {
                int? NumeroTrabajadoresSocialesiguiente = 0;
                TAFuncionesSistema.ObtenerUltimoIndiceTabla("TrabajadoresSociales", ref NumeroTrabajadoresSocialesiguiente);
                NumeroTrabajadoresSocialesiguiente = NumeroTrabajadoresSocialesiguiente == -1
                     ? 1 : NumeroTrabajadoresSocialesiguiente.Value + 1;
                TxtCodigoTrabajoSocial.Text = NumeroTrabajadoresSocialesiguiente.ToString();
            }
            TipoOperacion = CodigoTrabajadorSocial == null ? "I" : "E";
            soloInsertarEditar = true;
            dtGVListadoTrabSociales.Visible = false;
            //290
            btnEditarTrabSocial.Visible = btnAñadirTrabSocial.Visible = btnEliminarTrabSocial.Visible = false;
            this.Size = new Size(this.Size.Width, gBoxDetalle.Size.Height + pnlBotones.Size.Height + 35);
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false);
        }

        public void quitarInstituto()
        {
            DTUnidadesMedicas.Rows.Remove(DTUnidadesMedicas.FindByCodigoUnidadMedica(1));
			cBoxUnidadMedica.SelectedIndex = -1;
        }

        public void cargarComoMedico()
        {
            cBoxOcupacion.SelectedValue = "1";
            cBoxOcupacion.Enabled = false;

            cBoxUnidadMedica.SelectedValue = "1";
            cBoxUnidadMedica.Enabled = false;
        }

        private void btnCerrarAñadirDocumento_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }

        private void btnAñadirUnidadMedica_Click(object sender, EventArgs e)
        {
            FAñadirInstitución formUnidadMedica = new FAñadirInstitución();
            formUnidadMedica.configurarFormularioIA(null);
            if (formUnidadMedica.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && DTUnidadesMedicas.FindByCodigoUnidadMedica(formUnidadMedica.CodigoUnidadMedica) == null)
            {
                DataTable DTUnidadAux = TAUnidadesMedicas.GetDataBy1(formUnidadMedica.CodigoUnidadMedica);
                if(DTUnidadAux.Rows.Count > 0)
                {
                    DTUnidadesMedicas.Rows.Add(DTUnidadAux.Rows[0].ItemArray);
                    DTUnidadesMedicas.DefaultView.Sort = "NombreUnidadMedica ASC";
                    cBoxUnidadMedica.SelectedValue = formUnidadMedica.CodigoUnidadMedica;
                }
                
            }

            formUnidadMedica.Dispose();
        }

        private void btnAnadirOcupacion_Click(object sender, EventArgs e)
        {
            FAñadirOcupaciones formUnidadMedica = new FAñadirOcupaciones();
            formUnidadMedica.configurarFormularioIA(null);
            if (formUnidadMedica.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && DTOcupaciones.FindByCodigoOcupacion(formUnidadMedica.CodigoOcupacion) == null)
            {
                DataTable DTUnidadAux = TAOcupaciones.GetDataBy1(formUnidadMedica.CodigoOcupacion);
                if (DTUnidadAux.Rows.Count > 0)
                {
                    DTOcupaciones.Rows.Add(DTUnidadAux.Rows[0].ItemArray);
                    DTOcupaciones.DefaultView.Sort = "NombreOcupacion ASC";
                    cBoxOcupacion.SelectedValue = formUnidadMedica.CodigoOcupacion;
                }

            }

            formUnidadMedica.Dispose();
        }
    }
}
