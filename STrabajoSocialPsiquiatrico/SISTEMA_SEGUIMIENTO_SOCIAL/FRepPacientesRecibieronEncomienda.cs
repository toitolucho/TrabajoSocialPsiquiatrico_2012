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
    public partial class FRepPacientesRecibieronEncomienda : Form
    {
        ListarHistorialSeguimientoSocialPacientesReportesTableAdapter TAListarHistorialSeguimientoSocialPacientesReportes;
        DSTrabajo_Social.ListarHistorialSeguimientoSocialPacientesReportesDataTable DTListarHistorialSeguimientoSocialPacientesReportes;
        public FRepPacientesRecibieronEncomienda()
        {
            InitializeComponent();
            TAListarHistorialSeguimientoSocialPacientesReportes = new ListarHistorialSeguimientoSocialPacientesReportesTableAdapter();
            DTListarHistorialSeguimientoSocialPacientesReportes = new DSTrabajo_Social.ListarHistorialSeguimientoSocialPacientesReportesDataTable();
            dtGVPacientes.AutoGenerateColumns = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string orden = String.Empty;
            if (rBtnOrdenFecha.Checked)
                orden = "F";
            else if (rBtnOrdenHClinico.Checked)
                orden = "H";

            DTListarHistorialSeguimientoSocialPacientesReportes = TAListarHistorialSeguimientoSocialPacientesReportes.GetData(true, null, null, null, null, null, dateFechaInicio.Value, dateFechaFin.Value, orden);
            bdSourcePacientes.DataSource = DTListarHistorialSeguimientoSocialPacientesReportes;
            dtGVPacientes.DataSource = bdSourcePacientes;
            if (DTListarHistorialSeguimientoSocialPacientesReportes.Count == 0)
            {
                MessageBox.Show(this, "No se encontró ningun registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (DTListarHistorialSeguimientoSocialPacientesReportes.Count == 0)
            {
                MessageBox.Show(this, "No existen datos que mostrar en el informe");
                return;
            }

            Reportes.FReportePacientesSeguimientoSocial formReporte = new Reportes.FReportePacientesSeguimientoSocial();
            formReporte.mostrarDatos(DTListarHistorialSeguimientoSocialPacientesReportes, dateFechaInicio.Value, dateFechaFin.Value);
            formReporte.ShowDialog();
            formReporte.Dispose();
        }
    }
}
