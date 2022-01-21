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
    public partial class FReporteListarMovimientoResumen : FReporteGeneral
    {
        public FReporteListarMovimientoResumen()
        {
            InitializeComponent();
        }

        public void ListarMovimientoResumen(DataTable DTListarMovimientoResumen)
        {
            this.fuenteReporteGeneral = new CRListarMovimientoResumen();
            this.fuenteReporteGeneral.SetDataSource(DTListarMovimientoResumen);
        }

        public void ListarCantidadSubvencionSocialPorServicio(DataTable DTListarMovimientoResumen)
        {
            this.fuenteReporteGeneral = new CRListarCantidadSubvencionSocialPorServicio();
            this.fuenteReporteGeneral.SetDataSource(DTListarMovimientoResumen);
        }
    }
}
