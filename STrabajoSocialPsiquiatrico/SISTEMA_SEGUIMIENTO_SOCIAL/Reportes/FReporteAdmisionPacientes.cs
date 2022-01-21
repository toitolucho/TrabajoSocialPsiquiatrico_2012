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
    public partial class FReporteAdmisionPacientes : FReporteGeneral
    {
        public FReporteAdmisionPacientes()
        {
            InitializeComponent();
        }

        public void cargarDatos(DataTable DTListaPacientes)
        {
            this.fuenteReporteGeneral  = new CRAdmisionPacientes();
            this.fuenteReporteGeneral.SetDataSource(DTListaPacientes);
        }
    }
}
