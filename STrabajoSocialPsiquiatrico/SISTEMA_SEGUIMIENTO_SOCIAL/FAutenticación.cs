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
    public partial class FAutenticación : Form
    {
        UsuariosTableAdapter TAUsuarios;
        ErrorProvider eProviderAutenticacion;
        public string NombreUsuario { get; set; }
        public int? CodigoUsuario { get; set; }
        
        public FAutenticación()
        {
            InitializeComponent();
            TAUsuarios = new UsuariosTableAdapter();
            eProviderAutenticacion = new ErrorProvider();
            TxtContraseñaIngresarSistema.Text = TxtNombreUsuarioIngresarSistema.Text = "administrador";
        }

        private void btnAceptarIngresoSistema_Click(object sender, EventArgs e)
        {
            eProviderAutenticacion.Clear();
            if (String.IsNullOrEmpty(TxtNombreUsuarioIngresarSistema.Text.Trim()))
            {
                eProviderAutenticacion.SetError(TxtNombreUsuarioIngresarSistema, "Aún no ha Ingresado el Nombre de Usuario");
                TxtNombreUsuarioIngresarSistema.Focus();
                TxtNombreUsuarioIngresarSistema.SelectAll();
                return;
            }

            if (String.IsNullOrEmpty(TxtContraseñaIngresarSistema.Text.Trim()))
            {
                eProviderAutenticacion.SetError(TxtContraseñaIngresarSistema, "Aún no ha Ingresado la Contraseña del Usuario");
                TxtContraseñaIngresarSistema.Focus();
                TxtContraseñaIngresarSistema.SelectAll();
                return;
            }

            CodigoUsuario = TAUsuarios.VerificarUsuario(TxtNombreUsuarioIngresarSistema.Text, TxtContraseñaIngresarSistema.Text);
            if (CodigoUsuario != null && CodigoUsuario != 0)
            {
                NombreUsuario = TxtNombreUsuarioIngresarSistema.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show(this, "Los datos se encuentran mal escritos. Por favor verifique y vuelva a intentarlo", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnCancelarIngresoSistema_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Application.Exit();
        }

        private void TxtContraseñaIngresarSistema_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnAceptarIngresoSistema_Click(btnAceptarIngresoSistema, e as EventArgs);
        }


    }
}
