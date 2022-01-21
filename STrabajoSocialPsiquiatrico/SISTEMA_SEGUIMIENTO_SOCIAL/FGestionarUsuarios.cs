using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_SocialTableAdapters;
using SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades;

namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    public partial class FGestionarUsuarios : Form
    {
        QTAFuncionesSistema TAFuncionesSistema;
        UsuariosTableAdapter TAUsuarios;
        UnidadesMedicasTableAdapter TAUnidadesMedicas;

        DSTrabajo_Social.UsuariosDataTable DTUsuarios;
        DSTrabajo_Social.UnidadesMedicasDataTable DTUnidadesMedicas;

        ErrorProvider eProviderUsuarios;
        private string TipoOperación;
        private int CodigoUsuarioActual;

        public FGestionarUsuarios()
        {
            InitializeComponent();
            TAFuncionesSistema = new QTAFuncionesSistema();
            TAUsuarios = new UsuariosTableAdapter();
            eProviderUsuarios = new ErrorProvider();
            TAUnidadesMedicas = new UnidadesMedicasTableAdapter();

            DTUsuarios = TAUsuarios.GetData();
            DTUsuarios.Columns.Add("NombreCompleto");
            DTUsuarios.Columns[DTUsuarios.Columns.Count - 1].Expression = "Nombre + ' ' + ApellidoPaterno + ' ' + ApellidoMaterno";
            bdSourceUsuarios.DataSource = DTUsuarios;
            dtGVListadoUsuarios.DataSource = bdSourceUsuarios;
            
            bdSourceUsuarios.MoveFirst();

            cBoxTipoUsuario.DataSource = ObjetoCodigoDescripcion.generarListaTipoUsuario();
            cBoxTipoUsuario.DisplayMember = ObjetoCodigoDescripcion.DisplayMember;
            cBoxTipoUsuario.ValueMember = ObjetoCodigoDescripcion.ValueMember;
            cBoxTipoUsuario.SelectedIndex = -1;

            DTUnidadesMedicas = TAUnidadesMedicas.GetDataBy1(1);
            cBoxUnidadMedicaUsuario.DataSource = DTUnidadesMedicas;
            cBoxUnidadMedicaUsuario.DisplayMember = "NombreUnidadMedica";
            cBoxUnidadMedicaUsuario.ValueMember = "CodigoUnidadMedica";
            cBoxUnidadMedicaUsuario.SelectedIndex = -1;

            TxtTelefonoUsuario.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress);
            TxtCelularUsuario.KeyPress += new KeyPressEventHandler(SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress);

            cargarDatosUsuario(-1);
        }

        public void limpiarControles()
        {
            TxtApellidoMaternoUsuario.Text = string.Empty;
            TxtApellidoPaternoUsuario.Text = string.Empty;
            TxtCedulaIdentidadUsuario.Text = string.Empty;
            TxtCelularUsuario.Text = string.Empty;
            TxtConfirmarUsuario.Text = string.Empty;
            TxtContraseñaUsuario.Text = string.Empty;
            TxtDirecciónUsuario.Text = string.Empty;
            TxtNombresUsuario.Text = string.Empty;
            TxtNombreUsuario.Text = string.Empty;
            TxtNumeroEmpleado.Text = string.Empty;
            TxtTelefonoUsuario.Text = string.Empty;
            cBoxTipoUsuario.SelectedIndex = -1;
            cBoxUnidadMedicaUsuario.SelectedIndex = -1;

           // checkActualizar.Checked = checkEliminar.Checked = checkInsertar.Checked = checkSoloLectura.Checked = false;
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            TxtApellidoMaternoUsuario.Enabled = estadoHabilitacion;
            TxtApellidoPaternoUsuario.Enabled = estadoHabilitacion;
            TxtCedulaIdentidadUsuario.Enabled = estadoHabilitacion;
            TxtCelularUsuario.Enabled = estadoHabilitacion;
            TxtConfirmarUsuario.Enabled = estadoHabilitacion;
            TxtContraseñaUsuario.Enabled = estadoHabilitacion;
            TxtDirecciónUsuario.Enabled = estadoHabilitacion;
            TxtNombresUsuario.Enabled = estadoHabilitacion;
            TxtNombreUsuario.Enabled = estadoHabilitacion;
            TxtNumeroEmpleado.Enabled = estadoHabilitacion;
            TxtTelefonoUsuario.Enabled = estadoHabilitacion;
            cBoxTipoUsuario.Enabled = estadoHabilitacion;
            cBoxUnidadMedicaUsuario.Enabled = estadoHabilitacion;
            //btnAgregarUnidadMedica.Enabled = estadoHabilitacion;

           // checkActualizar.Enabled = checkEliminar.Enabled = checkInsertar.Enabled = checkSoloLectura.Enabled = estadoHabilitacion;
            dtGVListadoUsuarios.Enabled = !estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool editar, bool eliminar,bool cancelar)
        {
            this.btnAñadirUsuario.Enabled = nuevo;
            this.btnGuardarUsuario.Enabled = aceptar;
            this.btnEditarUsuario.Enabled = editar;
            this.btnEliminarUsuario.Enabled = eliminar;
            btnCancelar.Enabled = cancelar;
        }

        public bool validarControles()
        {
            if (string.IsNullOrEmpty(TxtNombresUsuario.Text))
            {
                eProviderUsuarios.SetError(TxtNombresUsuario, "Aún no ha Ingresado el Nombre del Usuario");
                MessageBox.Show("Aún no ha Ingresado el Nombre del Usuario");
                TxtNombresUsuario.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(TxtApellidoPaternoUsuario.Text))
            {
                eProviderUsuarios.SetError(TxtApellidoPaternoUsuario, "Aún no ha Ingresado el Apellido Paterno");
                MessageBox.Show("Aún no ha Ingresado el Apellido Paterno");
                TxtApellidoPaternoUsuario.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(TxtApellidoMaternoUsuario.Text) && MessageBox.Show(this,"¿Se encuentra seguro de dejar en blanco el Apellido Materno?"
                , this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                eProviderUsuarios.SetError(TxtApellidoMaternoUsuario, "Aún no ha Ingresado el Apellido Materno");
                MessageBox.Show("Aún no ha Ingresado el Apellido Materno");
                TxtApellidoMaternoUsuario.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TxtCedulaIdentidadUsuario.Text))
            {
                eProviderUsuarios.SetError(TxtCedulaIdentidadUsuario, "Aún no ha ingresado el C.I. del Usuario");
                MessageBox.Show("Aún no ha ingresado el C.I. del Usuario");
                TxtCedulaIdentidadUsuario.Focus();
                return false;
            }

            if (cBoxTipoUsuario.SelectedIndex < 0)
            {
                eProviderUsuarios.SetError(cBoxTipoUsuario, "Aún no ha Seleccionado el Tipo de Usuario");
                MessageBox.Show("Aún no ha Seleccionado el Tipo de Usuario");
                cBoxTipoUsuario.Focus();
                return false;
            }
            if (cBoxUnidadMedicaUsuario.SelectedIndex < 0)
            {
                eProviderUsuarios.SetError(cBoxUnidadMedicaUsuario, "Aún no ha Seleccionado la Unidad Médica");
                MessageBox.Show("Aún no ha Seleccionado la Unidad Médica");
                cBoxUnidadMedicaUsuario.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TxtNombreUsuario.Text))
            {
                eProviderUsuarios.SetError(TxtNombreUsuario, "Aún no ha Ingresado el nombre de la Cuenta del Usuario");
                MessageBox.Show("Aún no ha Seleccionado la Unidad Médica");
                TxtNombreUsuario.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(TxtContraseñaUsuario.Text))
            {
                eProviderUsuarios.SetError(TxtContraseñaUsuario, "Aún no ha Ingresado la Contraseña del Usuario");
                MessageBox.Show("Aún no ha Ingresado la Contraseña del Usuario");
                TxtContraseñaUsuario.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(TxtConfirmarUsuario.Text))
            {
                eProviderUsuarios.SetError(TxtConfirmarUsuario, "Aún no ha Confirmado la Contraseña del Usuario");
                MessageBox.Show("Aún no ha Confirmado la Contraseña del Usuario");
                TxtConfirmarUsuario.Focus();
                return false;
            }

            if (TxtConfirmarUsuario.Text.CompareTo(TxtContraseñaUsuario.Text) != 0)
            {
                eProviderUsuarios.SetError(TxtConfirmarUsuario, "La contraseña de confirmación no coincide con la primera contraseña ingresada. Por Favor proceda a corregir el dato");
                MessageBox.Show("La contraseña de confirmación no coincide con la primera contraseña ingresada. Por Favor proceda a corregir el dato");
                TxtConfirmarUsuario.Focus();
                return false;
            }
            return true;
        }

        public void cargarDatosUsuario(int CodigoUsuario)
        {
            limpiarControles();
            habilitarControles(false);
            DSTrabajo_Social.UsuariosRow DRUsuario = DTUsuarios.FindByCodigoUsuario(CodigoUsuario);
            if (DRUsuario == null)
            {
                DSTrabajo_Social.UsuariosDataTable DTUsuariosAux = TAUsuarios.GetDataBy11(CodigoUsuario);
                if (DTUsuariosAux.Count > 0)
                    DRUsuario = DTUsuariosAux[0];
                else
                {
                    habilitarBotones(true, false, false, false, false);
                    return;
                }
            }
            CodigoUsuarioActual = CodigoUsuario;
            TxtApellidoMaternoUsuario.Text = DRUsuario.IsApellidoMaternoNull() ? String.Empty : DRUsuario.ApellidoMaterno;
            TxtApellidoPaternoUsuario.Text = DRUsuario.ApellidoPaterno;
            TxtCedulaIdentidadUsuario.Text = DRUsuario.IsCIUsuarioNull() ? String.Empty : DRUsuario.CIUsuario;
            TxtCelularUsuario.Text = DRUsuario.IsCelularNull() ? String.Empty : DRUsuario.Celular;
            TxtConfirmarUsuario.Text = DRUsuario.Contraseña;
            TxtContraseñaUsuario.Text = DRUsuario.Contraseña;
            TxtDirecciónUsuario.Text = DRUsuario.IsDireccionNull() ? String.Empty : DRUsuario.Direccion;
            TxtNombreUsuario.Text = DRUsuario.Usuario;
            TxtNombresUsuario.Text = DRUsuario.Nombre;
            TxtTelefonoUsuario.Text = DRUsuario.IsTelefonoNull() ? String.Empty : DRUsuario.Telefono;
            cBoxTipoUsuario.SelectedValue = DRUsuario.TipoUsuario;
            TxtNumeroEmpleado.Text = CodigoUsuario.ToString();
            if (DRUsuario.IsCodigoUnidadMedicaNull())
                cBoxUnidadMedicaUsuario.SelectedIndex = -1;
            else
                cBoxUnidadMedicaUsuario.SelectedValue = DRUsuario.CodigoUnidadMedica;

            habilitarBotones(true, false, true, true, false);
        }

        private void btnAñadirUsuario_Click(object sender, EventArgs e)
        {
            TipoOperación = "I";
            habilitarControles(true);
            limpiarControles();
            habilitarBotones(false, true, false, false, true);
            int? CodigoUsuarioAux = -1;
            TAFuncionesSistema.ObtenerUltimoIndiceTabla("Usuarios", ref CodigoUsuarioAux);
            TxtNumeroEmpleado.Text = (++CodigoUsuarioAux).ToString();
            if(DTUnidadesMedicas.Count > 0)
                cBoxUnidadMedicaUsuario.SelectedValue = 1;
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (validarControles())
            {
                try
                {
                    CodigoUsuarioActual = int.Parse(TxtNumeroEmpleado.Text);
                    DSTrabajo_Social.UsuariosRow DRUsuarioNuevo;
                    DRUsuarioNuevo = TipoOperación == "I" ? DTUsuarios.NewUsuariosRow() : DTUsuarios[bdSourceUsuarios.Position];

                    DRUsuarioNuevo.Nombre = TxtNombresUsuario.Text;
                    DRUsuarioNuevo.Contraseña = TxtContraseñaUsuario.Text;
                    DRUsuarioNuevo.Usuario = TxtNombreUsuario.Text;
                    DRUsuarioNuevo.ApellidoPaterno = TxtApellidoPaternoUsuario.Text;
                    DRUsuarioNuevo.ApellidoMaterno = TxtApellidoMaternoUsuario.Text;
                    DRUsuarioNuevo.CIUsuario = TxtCedulaIdentidadUsuario.Text;
                    DRUsuarioNuevo.Direccion = TxtDirecciónUsuario.Text;
                    DRUsuarioNuevo.Telefono = TxtTelefonoUsuario.Text;
                    DRUsuarioNuevo.Celular = TxtCelularUsuario.Text;
                    DRUsuarioNuevo.TipoUsuario = cBoxTipoUsuario.SelectedValue.ToString();
                    if (cBoxUnidadMedicaUsuario.SelectedIndex >= 0)
                        DRUsuarioNuevo.CodigoUnidadMedica = int.Parse(cBoxUnidadMedicaUsuario.SelectedValue.ToString());
                    else
                        DRUsuarioNuevo.SetCodigoUnidadMedicaNull();

                    if (TipoOperación == "I")
                    {
                        TAUsuarios.Insert(TxtNombreUsuario.Text, TxtContraseñaUsuario.Text, TxtNombresUsuario.Text,
                            TxtApellidoPaternoUsuario.Text, TxtApellidoMaternoUsuario.Text, TxtCedulaIdentidadUsuario.Text,
                            TxtDirecciónUsuario.Text, TxtTelefonoUsuario.Text, TxtCelularUsuario.Text,
                            cBoxTipoUsuario.SelectedValue.ToString(),
                            cBoxUnidadMedicaUsuario.SelectedIndex >= 0 ? (int?)int.Parse(cBoxUnidadMedicaUsuario.SelectedValue.ToString()) : null);
                        DRUsuarioNuevo.CodigoUsuario = CodigoUsuarioActual;
                        DTUsuarios.AddUsuariosRow(DRUsuarioNuevo);
                    }
                    else
                    {
                        TAUsuarios.ActualizarUsuario(CodigoUsuarioActual, TxtNombreUsuario.Text, TxtContraseñaUsuario.Text, TxtNombresUsuario.Text,
                            TxtApellidoPaternoUsuario.Text, TxtApellidoMaternoUsuario.Text, TxtCedulaIdentidadUsuario.Text,
                            TxtDirecciónUsuario.Text, TxtTelefonoUsuario.Text, TxtCelularUsuario.Text,
                            cBoxTipoUsuario.SelectedValue.ToString(),
                            cBoxUnidadMedicaUsuario.SelectedIndex >= 0 ? (int?)int.Parse(cBoxUnidadMedicaUsuario.SelectedValue.ToString()) : null);

                        DRUsuarioNuevo.AcceptChanges();
                    }
                    DTUsuarios.AcceptChanges();
                    MessageBox.Show(this, "Operación realizada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitarBotones(true, false, true, true, false);
                    habilitarControles(false);                    
                    TipoOperación = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "ocurrió la siguiente excepción " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bdSourceUsuarios_CurrentChanged(object sender, EventArgs e)
        {
            if (DTUsuarios.Count > 0 && bdSourceUsuarios.Position >= 0)
            {
                cargarDatosUsuario(DTUsuarios[bdSourceUsuarios.Position].CodigoUsuario);
            }
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            TipoOperación = "E";
            habilitarBotones(false, true, false, false, true);
            habilitarControles(true);
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de Eliminar el registro actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    TAUsuarios.Delete(CodigoUsuarioActual);
                    limpiarControles();
                    DTUsuarios.Rows.RemoveAt(bdSourceUsuarios.Position);
                    CodigoUsuarioActual = -1;
                }
                catch (Exception EX)
                {
                    MessageBox.Show(this, "No se pudo Eliminar el registro actual, probablemente el Usuario ya se encuentra en uso y realizó operaciones dentro del sistema",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TipoOperación = "";
            habilitarBotones(true, false, false, false, false);
            habilitarControles(false);
            limpiarControles();
            eProviderUsuarios.Clear();
        }

        private void btnCerrarUsuario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarUnidadMedica_Click(object sender, EventArgs e)
        {
            FAñadirInstitución formUnidadesMedicas = new FAñadirInstitución();
            formUnidadesMedicas.configurarFormularioIA(null);
            formUnidadesMedicas.Visible = false;
            if (formUnidadesMedicas.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && DTUnidadesMedicas.FindByCodigoUnidadMedica(formUnidadesMedicas.CodigoUnidadMedica) == null)
            {
                DSTrabajo_Social.UnidadesMedicasDataTable DTUnidadMedicaAux = TAUnidadesMedicas.GetDataBy1(formUnidadesMedicas.CodigoUnidadMedica);
                if (DTUnidadMedicaAux.Count > 0)
                {
                    DTUnidadesMedicas.Rows.Add(DTUnidadMedicaAux[0].ItemArray);

                    DTUnidadMedicaAux.DefaultView.Sort = "NombreUnidadMedica ASC";
                    cBoxUnidadMedicaUsuario.SelectedValue = formUnidadesMedicas.CodigoUnidadMedica;
                }
            }
            formUnidadesMedicas.Dispose();
        }

        private void FGestionarUsuarios_Load(object sender, EventArgs e)
        {

        }


    }
}
