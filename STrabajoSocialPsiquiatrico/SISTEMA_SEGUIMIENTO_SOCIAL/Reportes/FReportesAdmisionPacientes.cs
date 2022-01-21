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
    public partial class FReportesAdmisionPacientes : FReporteGeneral
    {
        public FReportesAdmisionPacientes()
        {
            InitializeComponent();
        }

        public void cargarDatos(DataTable DTPacientes)
        {            
            this.fuenteReporteGeneral = new CRAdmisionPacientes();
            this.fuenteReporteGeneral.SetDataSource(DTPacientes);
        }

        public void ListarPacientesHospitalizadosDetalle(DataTable DTPacientes)
        {
            this.fuenteReporteGeneral = new CRListadoPacientesHospitalizados();
            this.fuenteReporteGeneral.SetDataSource(DTPacientes);
        }

        public void ListarPacientesHospitalizadosSimple(DataTable DTPacientes)
        {
            this.fuenteReporteGeneral = new CRListarPacientesHospitalizadosSimple();
            this.fuenteReporteGeneral.SetDataSource(DTPacientes);
        }
    }
}
