using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_SocialTableAdapters;
using SISTEMA_SEGUIMIENTO_SOCIAL.Reportes;

namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    public partial class FRepActividadesDiarias : Form
    {
        ListarCantidadActividadesTipoPorMesTableAdapter TAListarCantidadActividadesTipoPorMes;
        DSTrabajo_Social.ListarCantidadActividadesTipoPorMesDataTable DTListarCantidadActividadesTipoPorMes;

        ListarActividadesPorUsuarioReporteTableAdapter TAListarActividadesPorUsuarioReporte;
        DSTrabajo_Social.ListarActividadesPorUsuarioReporteDataTable DTListarActividadesPorUsuarioReporte;
        UsuariosTableAdapter TAUsuarios = new UsuariosTableAdapter();

        public FRepActividadesDiarias()
        {
            InitializeComponent();
            TAListarActividadesPorUsuarioReporte = new ListarActividadesPorUsuarioReporteTableAdapter();
            TAListarCantidadActividadesTipoPorMes = new ListarCantidadActividadesTipoPorMesTableAdapter();
            TAUsuarios = new UsuariosTableAdapter();
            DataTable DTUsuarios = TAUsuarios.GetDataByTrabajadorSocial();
            
            cBoxTrabajadoraSocial.DataSource = DTUsuarios;
            cBoxTrabajadoraSocial.DisplayMember = "NombreCompleto";
            cBoxTrabajadoraSocial.ValueMember = "CodigoUsuario";
            cBoxTrabajadoraSocial.SelectedIndex = -1;
        }

        private void FRepEvacionesPacientes_Load(object sender, EventArgs e)
        {

        }

        private void btnAñadirUsuario_Click(object sender, EventArgs e)
        {
            if (!rBtnActividadesDiarias.Checked && !checkTrabajadoraSocial.Checked)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ninguna opción");
                return;
            }
            if (checkTrabajadoraSocial.Checked && cBoxTrabajadoraSocial.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ninguna Trabajador Social");
                return;
            }

            FReporteActividades formReportes;
            formReportes = new FReporteActividades();
            if (rBtnActividadesDiarias.Checked)
            {                
                DataTable DTListarMeses = TAListarCantidadActividadesTipoPorMes.GetData(dateFechaInicio.Value.Month, dateFechaFin.Value.Month, dateFechaFin.Value.Year);
                formReportes.ListarCantidadActividadesTipoPorMes(DTListarMeses);
                
            }
            else if (checkTrabajadoraSocial.Checked)
            {
                DataTable DTPorTrabajadorSocial = TAListarActividadesPorUsuarioReporte.GetData(int.Parse(cBoxTrabajadoraSocial.SelectedValue.ToString()),
                    dateFechaInicio.Value, dateFechaFin.Value);
                formReportes.ListarActividadesPorUsuarioReporte(DTPorTrabajadorSocial);
            }
            formReportes.ShowDialog();
            formReportes.Dispose();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateFechaFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateFechaInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkTrabajadoraSocial_CheckedChanged(object sender, EventArgs e)
        {
            cBoxTrabajadoraSocial.Enabled = checkTrabajadoraSocial.Checked;
            if (checkTrabajadoraSocial.Checked)
                cBoxTrabajadoraSocial.Focus();
            else
                cBoxTrabajadoraSocial.SelectedIndex = -1;
        }
    }
}
