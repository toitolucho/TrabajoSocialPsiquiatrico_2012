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
    public partial class FRepUbicacionPacientesHospitalizados : Form
    {
        UnidadesTableAdapter TAUnidades;
        SeccionesTableAdapter TASecciones;
        ListarHistorialPacientesReportesTableAdapter TAListarHistorialPacientesReportes;
        DSTrabajo_Social.ListarHistorialPacientesReportesDataTable DTListarHistorialPacientesReportes;
        ListarMovimientoResumenTableAdapter TAListarMovimientoResumen;
        public FRepUbicacionPacientesHospitalizados()
        {
            InitializeComponent();
            TASecciones = new SeccionesTableAdapter();
            TAUnidades = new UnidadesTableAdapter();
            TAListarHistorialPacientesReportes = new ListarHistorialPacientesReportesTableAdapter();
            TAListarMovimientoResumen = new ListarMovimientoResumenTableAdapter();

            cBoxSeccion.DataSource = TASecciones.GetData();
            cBoxSeccion.DisplayMember = "Seccion";
            cBoxSeccion.ValueMember = "Seccion";
            cBoxSeccion.SelectedIndex = -1;

            cBoxUnidad.DataSource = TAUnidades.GetData();
            cBoxUnidad.DisplayMember = "Unidad";
            cBoxUnidad.ValueMember = "Unidad";
            cBoxUnidad.SelectedIndex = -1;
            dtGVPacientes.AutoGenerateColumns = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (rBtnHospitalizados.Checked)
            {
                DTListarHistorialPacientesReportes = TAListarHistorialPacientesReportes.GetData(null, null, null, null, null, null, null, null,
                    null, null, null, (cBoxUnidad.SelectedIndex >= 0 ? int.Parse(cBoxUnidad.SelectedIndex.ToString()) : (int?)null),
                    cBoxSeccion.SelectedIndex >= 0 ? cBoxSeccion.SelectedValue.ToString() : null, null, null,
                    null, null, null, null, null, null);
                dtGVPacientes.DataSource = DTListarHistorialPacientesReportes;
                txtTotalPacientes.Text = DTListarHistorialPacientesReportes.Count.ToString();
                if (DTListarHistorialPacientesReportes.Count == 0)
                {
                    MessageBox.Show(this, "No se encontró ningún registro");
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (checkCantidad.Checked)
            {
                Reportes.FReporteListarMovimientoResumen formReporteMovimiento = new Reportes.FReporteListarMovimientoResumen();
                formReporteMovimiento.ListarMovimientoResumen(TAListarMovimientoResumen.GetData(  dateFechaInicio.Value, dateFechaFin.Value));
                formReporteMovimiento.ShowDialog();
                formReporteMovimiento.Dispose();
            }
            else if (rBtnHospitalizados.Checked)
            {
                Reportes.FReportesAdmisionPacientes formReporteAdmision = new Reportes.FReportesAdmisionPacientes();
                formReporteAdmision.cargarDatos(DTListarHistorialPacientesReportes);
                formReporteAdmision.ShowDialog();
                formReporteAdmision.Dispose();
            }
        }
    }
}
