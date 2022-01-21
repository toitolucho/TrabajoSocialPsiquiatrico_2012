using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades
{
    public static class EventosValidacionTexto
    {
        public static void TextBoxEnteros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && (((Keys)e.KeyChar)) != Keys.Back)
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        public static void TextBoxFlotantes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && (((Keys)e.KeyChar)) != Keys.Back
                && (((Keys)e.KeyChar)) != (Keys) ',')
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        public static string ConvertirTextoNormalizadoSinAcentos(string Texto)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9 ]");
            return reg.Replace(Texto.Normalize(NormalizationForm.FormD), "");            
        }
    }
}
