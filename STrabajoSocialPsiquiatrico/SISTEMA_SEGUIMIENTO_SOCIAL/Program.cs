using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FRepActividadesDiarias());
            Application.Run(new FPrincipal());

            //FPagoServicio formPagoServicio = new FPagoServicio();
            ////formPagoServicio.configurarFormularioIA(1441, null);
            //Application.Run(formPagoServicio);

            //Application.Run(new FNivelSocioEconomico("SAMUEL TOOTLILLON", "I"));

        }
    }
}
