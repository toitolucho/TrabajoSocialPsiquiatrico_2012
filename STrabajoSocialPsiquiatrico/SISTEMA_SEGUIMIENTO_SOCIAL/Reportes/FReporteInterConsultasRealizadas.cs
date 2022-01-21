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
    public partial class FReporteInterConsultasRealizadas : FReporteGeneral
    {
        public FReporteInterConsultasRealizadas()
        {
            InitializeComponent();
        }

        public void ListarReferenciasMensuales(DataTable DTListarReferenciasMensuales)
        {
            this.fuenteReporteGeneral = new CRListarReferenciasMensuales();
            this.fuenteReporteGeneral.SetDataSource(DTListarReferenciasMensuales);
        }

        public void ListarInterConsultasRealizadas(DataTable DTPacientes)
        {
            this.fuenteReporteGeneral = new CRInterConsultasRealizadas();
            this.fuenteReporteGeneral.SetDataSource(DTPacientes);
        }
    }
}
