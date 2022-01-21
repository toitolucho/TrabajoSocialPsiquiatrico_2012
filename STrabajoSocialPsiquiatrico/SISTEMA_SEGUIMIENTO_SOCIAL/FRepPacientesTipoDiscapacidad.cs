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
    public partial class FRepPacientesTipoDiscapacidad : Form
    {
        ListarHistorialPacientesReportesTableAdapter TAListarHistorialPacientesReportes;
        DSTrabajo_Social.ListarHistorialPacientesReportesDataTable DTListarHistorialPacientesReportes;
        public FRepPacientesTipoDiscapacidad()
        {
            InitializeComponent();
            TAListarHistorialPacientesReportes = new ListarHistorialPacientesReportesTableAdapter();
            TAListarHistorialPacientesReportes = new ListarHistorialPacientesReportesTableAdapter();
            dtGVPacientes.AutoGenerateColumns = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            DTListarHistorialPacientesReportes = TAListarHistorialPacientesReportes.GetData("D", null, null, null, null, 
                null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, dateFechaInicio.Value, dateFechaFin.Value);
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

            Reportes.FReportePacientesDiscapacitados formReporte = new Reportes.FReportePacientesDiscapacitados();
            formReporte.mostrarDatos(DTListarHistorialPacientesReportes, dateFechaInicio.Value, dateFechaFin.Value);
            formReporte.ShowDialog();
            formReporte.Dispose();
        }
    }
}
