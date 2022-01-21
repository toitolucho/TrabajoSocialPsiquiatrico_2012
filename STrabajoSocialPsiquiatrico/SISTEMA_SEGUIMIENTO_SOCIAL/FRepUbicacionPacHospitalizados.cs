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
    public partial class FRepUbicacionPacHospitalizados : Form
    {
        UnidadesTableAdapter TAUnidades;
        SeccionesTableAdapter TASecciones;
        ListarHistorialPacientesReportesTableAdapter TAListarHistorialPacientesReportes;
        DSTrabajo_Social.ListarHistorialPacientesReportesDataTable DTListarHistorialPacientesReportes;
        ListarMovimientoResumenTableAdapter TAListarMovimientoResumen;
        public FRepUbicacionPacHospitalizados()
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
                DTListarHistorialPacientesReportes = TAListarHistorialPacientesReportes.GetData("D", null, null, null, null, null, null, null,
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
                //formReporteMovimiento.ListarMovimientoResumen(TAListarMovimientoResumen.GetData(  dateFechaInicio.Value, dateFechaFin.Value));
                formReporteMovimiento.ShowDialog();
                formReporteMovimiento.Dispose();
            }
            else if (rBtnHospitalizados.Checked)
            {

                if (rBtnListadoDetallado.Checked)
                {
                    //DTListarHistorialPacientesReportes.Columns.Remove(DTListarHistorialPacientesReportes.Documento1Column);
                    //DTListarHistorialPacientesReportes.Columns.Remove(DTListarHistorialPacientesReportes.Documento2Column);
                    //DTListarHistorialPacientesReportes.Columns.Remove(DTListarHistorialPacientesReportes.Documento3Column);
                    //DTListarHistorialPacientesReportes.Columns.Remove(DTListarHistorialPacientesReportes.Documento4Column);

                    //DTListarHistorialPacientesReportes.Documento1Column.Expression = "CASE Substring(LiteralCodigoDocumentos,1,1)  WHEN '1' THEN 'SI' ELSE 'NO' END";
                    DTListarHistorialPacientesReportes.Documento1Column.Expression = "IIF(Substring(LiteralCodigoDocumentos,1,1)  = '1', 'SI','NO')";
                    DTListarHistorialPacientesReportes.Documento2Column.Expression = "IIF(Substring(LiteralCodigoDocumentos,2,1)  = '1', 'SI','NO')";
                    DTListarHistorialPacientesReportes.Documento3Column.Expression = "IIF(Substring(LiteralCodigoDocumentos,3,1)  = '1', 'SI','NO')";
                    DTListarHistorialPacientesReportes.Documento4Column.Expression = "IIF(Substring(LiteralCodigoDocumentos,4,1)  = '1', 'SI','NO')";
                    
                    DTListarHistorialPacientesReportes.AcceptChanges();

                    Reportes.FReportesAdmisionPacientes formReporteAdmision = new Reportes.FReportesAdmisionPacientes();
                    formReporteAdmision.ListarPacientesHospitalizadosDetalle(DTListarHistorialPacientesReportes);
                    formReporteAdmision.ShowDialog();
                    formReporteAdmision.Dispose();
                }
                else
                {
                    Reportes.FReportesAdmisionPacientes formReporteAdmision = new Reportes.FReportesAdmisionPacientes();
                    formReporteAdmision.ListarPacientesHospitalizadosSimple(DTListarHistorialPacientesReportes);
                    formReporteAdmision.ShowDialog();
                    formReporteAdmision.Dispose();
                }
                    
                
            }
        }
    }
}
