using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.ReportesCR;

namespace SISTEMA_SEGUIMIENTO_SOCIAL.Reportes
{
    public partial class FReporteInformeSociales : FReporteGeneral
    {
        public FReporteInformeSociales()
        {
            InitializeComponent();
        }

        public void cargarDatos(DataTable DTPacientes)
        {
            this.fuenteReporteGeneral = new CRInformeSociales();
            fuenteReporteGeneral.SetDataSource(DTPacientes);
            AgregarParametro(" ", "TrabajadoraSocial");
        }
    }
}
