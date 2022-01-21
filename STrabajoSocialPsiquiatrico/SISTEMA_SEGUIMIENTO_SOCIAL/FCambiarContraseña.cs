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
    public partial class FCambiarContraseña : Form
    {
        static private UsuariosTableAdapter TAUsuarios = new UsuariosTableAdapter();
        int CodigoUsuario; string NombreUsuario;
        public FCambiarContraseña(int CodigoUsuario, string NombreUsuario)
        {
            InitializeComponent();
            this.CodigoUsuario = CodigoUsuario;
            this.NombreUsuario = NombreUsuario;
            
        }
        public FCambiarContraseña()
        {
            InitializeComponent();
            
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            int? respuesta = TAUsuarios.VerificarUsuario(NombreUsuario, tBContrasenaActual.Text);
            if (respuesta != null && respuesta.Value != 0)
            {
                if (tBContrasenaNueva.Text.CompareTo(tBContrasenaNuevaRepetida.Text) == 0)
                {
                    if (string.IsNullOrEmpty(tBContrasenaNueva.Text) 
                        && MessageBox.Show(this,"¿Se Encuentra seguro de dejar en blanco su Contraseña?", 
                        this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }

                    TAUsuarios.ActualizarContrasenaUsuario(CodigoUsuario, tBContrasenaNueva.Text);                    
                    MessageBox.Show("Se ha registrado exitosamente su nueva contraseña");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La Contraseña Nueva no coindice en los dos cuadros de texto");
                }
            }
            else
            {
                MessageBox.Show("La Contraseña Actual escrita no es correcta. Por Favor vuelva a escribir");
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
