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
    public partial class FRepPacientesInstitucionalizados : Form
    {
        ListarActividadesPacienteReporteTableAdapter TAListarActividadesPacienteReporte;
        DSTrabajo_Social.ListarActividadesPacienteReporteDataTable DTListarHistorialPacientesReportes;
        public FRepPacientesInstitucionalizados()
        {
            InitializeComponent();
            TAListarActividadesPacienteReporte = new ListarActividadesPacienteReporteTableAdapter();
            DTListarHistorialPacientesReportes = new DSTrabajo_Social.ListarActividadesPacienteReporteDataTable();
            dtGVPacientes.AutoGenerateColumns = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            DTListarHistorialPacientesReportes = TAListarActividadesPacienteReporte.GetData(null, 1, null, dateFechaInicio.Value, dateFechaFin.Value);

            if (DTListarHistorialPacientesReportes.Count > 0 && checkPacHospitalizados.Checked)
                DTListarHistorialPacientesReportes.DefaultView.RowFilter = "CodigoEstadoPaciente = 'A'";

            bdSourcePacientes.DataSource = DTListarHistorialPacientesReportes;
            dtGVPacientes.DataSource = bdSourcePacientes;
            if (DTListarHistorialPacientesReportes.Count == 0)
            {
                MessageBox.Show(this, "No se encontró ningun registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (DTListarHistorialPacientesReportes.Count == 0)
            {
                MessageBox.Show(this, "No existen datos que mostrar en el informe");
                return;
            }


            Reportes.FReportePacientesSeguimientoSocial formReporte = new Reportes.FReportePacientesSeguimientoSocial();
            formReporte.mostrarDatos(DTListarHistorialPacientesReportes.DefaultView.ToTable(), dateFechaInicio.Value, dateFechaFin.Value);
            formReporte.ShowDialog();
            formReporte.Dispose();
        }
    }
}
