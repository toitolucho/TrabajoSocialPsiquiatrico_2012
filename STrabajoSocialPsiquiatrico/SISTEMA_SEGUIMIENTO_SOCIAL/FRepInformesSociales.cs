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
    public partial class FRepInformeSocial : Form
    {
        ListarHistorialPacientesReportesTableAdapter TAListarHistorialPacientesReportes;
        UsuariosTableAdapter TATrabajadoraSocial;
        DSTrabajo_Social.ListarHistorialPacientesReportesDataTable DTListarHistorialPacientesReportes;
        public FRepInformeSocial()
        {
            InitializeComponent();
            TAListarHistorialPacientesReportes = new ListarHistorialPacientesReportesTableAdapter();
            TATrabajadoraSocial = new UsuariosTableAdapter();
            cBoxTrabajadoraSocial.DataSource = TATrabajadoraSocial.GetDataByTrabajadorSocial();
            cBoxTrabajadoraSocial.DisplayMember = "NombreCompleto";
            cBoxTrabajadoraSocial.ValueMember = "CodigoUsuario";
            cBoxTrabajadoraSocial.SelectedIndex = -1;

            DTListarHistorialPacientesReportes = new DSTrabajo_Social.ListarHistorialPacientesReportesDataTable();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.FReporteInformeSociales formReporte = new Reportes.FReporteInformeSociales();
            DTListarHistorialPacientesReportes = TAListarHistorialPacientesReportes.GetData("S", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, dateTimePicker1.Value, dateTimePicker2.Value);
            if (checkTrabajdoraSocial.Checked && cBoxTrabajadoraSocial.SelectedIndex >= 0)
                DTListarHistorialPacientesReportes.DefaultView.RowFilter = "CodigoUsuario = " + int.Parse(cBoxTrabajadoraSocial.SelectedValue.ToString());
            formReporte.cargarDatos(DTListarHistorialPacientesReportes);
            formReporte.ShowDialog();
            formReporte.Dispose();
        }

        private void checkTrabajdoraSocial_CheckedChanged(object sender, EventArgs e)
        {
            cBoxTrabajadoraSocial.Enabled = checkTrabajdoraSocial.Checked;
            if (checkTrabajdoraSocial.Checked)
                cBoxTrabajadoraSocial.Focus();
            else
                cBoxTrabajadoraSocial.SelectedIndex = -1;
        }

        
    }
}
