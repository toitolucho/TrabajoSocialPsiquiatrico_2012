using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.Reportes;
using SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_SocialTableAdapters;

namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    public partial class FRepInterconsultaRealizada : Form
    {
        ListarReferenciasMensualesTableAdapter TAListarReferenciasMensuales;
        ListarHistorialPacientesReportesTableAdapter TAListarHistorialPacientesReportes;
        DataTable DTReporte;

        public FRepInterconsultaRealizada()
        {
            InitializeComponent();
            TAListarHistorialPacientesReportes = new ListarHistorialPacientesReportesTableAdapter();
            TAListarReferenciasMensuales = new ListarReferenciasMensualesTableAdapter();
            DTReporte = new DataTable();
            dtGVPacientes.AutoGenerateColumns = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkSexo_CheckedChanged(object sender, EventArgs e)
        {
            cBoxSexo.Enabled = checkSexo.Checked;
            if (checkSexo.Checked)
                cBoxSexo.Focus();
            else
                cBoxSexo.SelectedIndex = -1;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (!checkCantidades.Checked && checkSexo.Checked && cBoxSexo.SelectedIndex < 0)
            {
                MessageBox.Show("Aún no ha seleccionado el Sexo");
                return;
            }
            try
            {
                FReporteInterConsultasRealizadas formReporte = new FReporteInterConsultasRealizadas();
                if (checkCantidades.Checked)
                {
                    DTReporte = TAListarReferenciasMensuales.GetData(dateFechaInicio.Value.Month, dateFechaFin.Value.Month, dateFechaFin.Value.Year);
                    formReporte.ListarReferenciasMensuales(DTReporte);
                }
                else
                {
                    DTReporte = TAListarHistorialPacientesReportes.GetData("F", null, null, null, checkSexo.Checked ? cBoxSexo.SelectedValue.ToString() : null,
                        null, null, null, null, null, null, null, null, null, null, null, null,
                        null, null, dateFechaInicio.Value, dateFechaFin.Value);
                    formReporte.ListarInterConsultasRealizadas(DTReporte);

                    dtGVPacientes.DataSource = DTReporte;
                    txtCantidad.Text = DTReporte.Rows.Count.ToString();
                    

                }
                formReporte.ShowDialog();
                formReporte.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió la siguiente Excepcion " + ex.Message);
            }
        }
    }
}
