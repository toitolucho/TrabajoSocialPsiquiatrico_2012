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
    public partial class FRepValoracionSocioeconomica : Form
    {
        ErrorProvider eProviderReporte;
        ListarHistorialPacientesReportesTableAdapter TAListarHistorialPacientesReportes;
        CategoriasTableAdapter TACategorias;
        EspecialidadesTableAdapter TAEspecialidades;
        ServiciosTableAdapter TAServicios;
        ListarCantidadSubvencionSocialPorServicioTableAdapter TAListarCantidadSubvencionSocialPorServicio;

        DSTrabajo_Social.ListarHistorialPacientesReportesDataTable DTListarHistorialPacientesReportes;

        public FRepValoracionSocioeconomica()
        {
            InitializeComponent();
            eProviderReporte = new ErrorProvider();
            TAListarHistorialPacientesReportes = new ListarHistorialPacientesReportesTableAdapter();
            TACategorias = new CategoriasTableAdapter();
            TAEspecialidades = new EspecialidadesTableAdapter();
            TAServicios = new ServiciosTableAdapter();
            TAListarCantidadSubvencionSocialPorServicio = new ListarCantidadSubvencionSocialPorServicioTableAdapter();

            cBoxCategoria.DataSource = TACategorias.GetData();
            cBoxCategoria.DisplayMember = "NombreCategoria";
            cBoxCategoria.ValueMember = "CodigoCategoria";
            cBoxCategoria.SelectedIndex = -1;

            cBoxEspecialidad.DataSource = TAEspecialidades.GetData();
            cBoxEspecialidad.DisplayMember = "NombreEspecialidad";
            cBoxEspecialidad.ValueMember = "CodigoEspecialidad";
            cBoxEspecialidad.SelectedIndex = -1;

            cBoxSexo.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaSexo();
            cBoxSexo.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxSexo.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxSexo.SelectedIndex = -1;

            cBoxServicio.DataSource = TAServicios.GetData();
            cBoxServicio.DisplayMember = "NombreServicio";
            cBoxServicio.ValueMember = "CodigoServicio";
            cBoxServicio.SelectedIndex = -1;

            dtGVPacientes.AutoGenerateColumns = false;
        }

        private void checkServicio_CheckedChanged(object sender, EventArgs e)
        {
            cBoxServicio.Enabled = checkServicio.Checked;
            if (checkServicio.Checked)
                cBoxServicio.Focus();
            else
                cBoxServicio.SelectedIndex = -1;
        }

        private void checkEspecialidad_CheckedChanged(object sender, EventArgs e)
        {
            cBoxEspecialidad.Enabled = checkEspecialidad.Checked;
            if (checkEspecialidad.Checked)
                cBoxEspecialidad.Focus();
            else
                cBoxEspecialidad.SelectedIndex = -1;
        }

        private void checkSexo_CheckedChanged(object sender, EventArgs e)
        {
            cBoxSexo.Enabled = checkSexo.Checked;
            if (checkSexo.Checked)
                cBoxSexo.Focus();
            else
                cBoxSexo.SelectedIndex = -1;
        }

        private void checkCategoria_CheckedChanged(object sender, EventArgs e)
        {
            cBoxCategoria.Enabled = checkCategoria.Checked;
            if (checkCategoria.Checked)
                cBoxCategoria.Focus();
            else
                cBoxCategoria.SelectedIndex = -1;
        }

        public bool validarControles()
        {
            eProviderReporte.Clear();
            if (checkServicio.Checked && cBoxServicio.SelectedIndex < 0)
            {
                eProviderReporte.SetError(cBoxServicio, "Aún no ha seleccionado el Servicio");
                cBoxServicio.Focus();
                return false;
            }
            if (checkEspecialidad.Checked && cBoxEspecialidad.SelectedIndex < 0)
            {
                eProviderReporte.SetError(cBoxEspecialidad, "Aún no ha seleccionado la Especialidad");
                cBoxEspecialidad.Focus();
                return false;
            }
            if (checkSexo.Checked && cBoxSexo.SelectedIndex < 0)
            {
                eProviderReporte.SetError(cBoxSexo, "Aún no ha seleccionado el Sexo");
                cBoxSexo.Focus();
                return false;
            }
            if (checkCategoria.Checked && cBoxCategoria.SelectedIndex < 0)
            {
                eProviderReporte.SetError(cBoxCategoria, "Aún no ha seleccionado la Categoria");
                cBoxCategoria.Focus();
                return false;
            }
            
            return true;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (!validarControles())
            {
                MessageBox.Show(this, "Existen algunos friltros que no pueden ser aplicados debido a que no ha selecionado una opción. Para mas detalle aproxime el cursor del Mouse el punto Rojo Parpadeante");
                return;
            }

            string TipoPaciente = rbtnPacientesExternos.Checked ? "E" : rbtnPacientesInternos.Checked ? "I" : "";

            DTListarHistorialPacientesReportes = TAListarHistorialPacientesReportes.GetData("P", null, null, null, checkSexo.Checked ? cBoxSexo.SelectedValue.ToString() : null,
                null, null, null, null,
                String.IsNullOrEmpty(TipoPaciente) ? null : TipoPaciente, null, null, null, cBoxCategoria.SelectedIndex >= 0 ? int.Parse(cBoxCategoria.SelectedValue.ToString()) : (int?)null, 
                cBoxServicio.SelectedIndex >= 0 ? int.Parse(cBoxServicio.SelectedValue.ToString()) : (int?)null, 
                cBoxEspecialidad.SelectedIndex >= 0 ? int.Parse(cBoxEspecialidad.SelectedValue.ToString()) : (int?) null ,
                null, null, null, dateFechaInicio.Value, dateFechaFin.Value);

            dtGVPacientes.DataSource = DTListarHistorialPacientesReportes;
            txtTotalPacientes.Text = DTListarHistorialPacientesReportes.Count.ToString();
            if (DTListarHistorialPacientesReportes.Count == 0)
            {
                MessageBox.Show(this, "No se encontró ningún registro con la información provista", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string TipoPaciente = rbtnPacientesExternos.Checked ? "E" : rbtnPacientesInternos.Checked ? "I" : "";
            if (checkCantidad.Checked)
            {
                Reportes.FReporteListarMovimientoResumen formReporteMovimientoEconomico = new Reportes.FReporteListarMovimientoResumen();
                formReporteMovimientoEconomico.ListarCantidadSubvencionSocialPorServicio(TAListarCantidadSubvencionSocialPorServicio.GetData(dateFechaInicio.Value, 
                    dateFechaFin.Value, String.IsNullOrEmpty(TipoPaciente) ? null : TipoPaciente));
                formReporteMovimientoEconomico.ShowDialog();
                formReporteMovimientoEconomico.Dispose();
                return;
            }
            else
            {
                Reportes.FReportesAdmisionPacientes formReporteAdmision = new Reportes.FReportesAdmisionPacientes();
                formReporteAdmision.cargarDatos(DTListarHistorialPacientesReportes);
                formReporteAdmision.ShowDialog();
                formReporteAdmision.Dispose();
            }
        }
    }
}
