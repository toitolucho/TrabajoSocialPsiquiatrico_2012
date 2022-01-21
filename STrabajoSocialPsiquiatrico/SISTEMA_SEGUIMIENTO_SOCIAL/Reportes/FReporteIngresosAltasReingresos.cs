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
    public partial class FReporteIngresosAltasReingresos : FReporteGeneral
    {
        public FReporteIngresosAltasReingresos()
        {
            InitializeComponent();
        }

        public void ListarIngresosReingresosMensuales(DataTable DTFuenteDatos)
        {
            this.fuenteReporteGeneral = new CRListarIngresosReingresosMensuales();
            this.fuenteReporteGeneral.SetDataSource(DTFuenteDatos);

        }

        public void ListarAltasMensuales(DataTable DTFuenteDatos)
        {
            this.fuenteReporteGeneral = new CRListarAltasMensuales();
            this.fuenteReporteGeneral.SetDataSource(DTFuenteDatos);
        }
    }
}
