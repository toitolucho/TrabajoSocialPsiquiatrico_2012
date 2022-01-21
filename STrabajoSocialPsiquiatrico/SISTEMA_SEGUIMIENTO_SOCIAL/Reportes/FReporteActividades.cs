using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.ReportesCR;

namespace SISTEMA_SEGUIMIENTO_SOCIAL.Reportes
{
    public partial class FReporteActividades : SISTEMA_SEGUIMIENTO_SOCIAL.Reportes.FReporteGeneral
    {
        public FReporteActividades()
        {
            InitializeComponent();
        }

        public void ListarActividadesPorUsuarioReporte(DataTable DTListarActividadesPorUsuarioReporte)
        {
            this.fuenteReporteGeneral = new CRListarActividadesPorUsuarioReporte();
            fuenteReporteGeneral.SetDataSource(DTListarActividadesPorUsuarioReporte);
        }
        public void ListarCantidadActividadesTipoPorMes(DataTable DTListarCantidadActividadesTipoPorMes)
        {
            this.fuenteReporteGeneral = new CRListarCantidadActividadesTipoPorMes();
            fuenteReporteGeneral.SetDataSource(DTListarCantidadActividadesTipoPorMes);
        }
    }
}
