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
    public partial class FRepDocumentoPaciente : Form
    {
        ListarPacientesDocumentosTableAdapter TAListarPacientesDocumentos;
        DSTrabajo_Social.ListarPacientesDocumentosDataTable DTListarPacientesDocumentos;
        DocumentosTipoTableAdapter TADocumentosTipos;
        public FRepDocumentoPaciente()
        {
            InitializeComponent();
            TAListarPacientesDocumentos = new ListarPacientesDocumentosTableAdapter();
            TADocumentosTipos = new DocumentosTipoTableAdapter();

            cBoxTiposDocumentos.DataSource = TADocumentosTipos.GetData();
            cBoxTiposDocumentos.ValueMember = "CodigoDocumentoTipo";
            cBoxTiposDocumentos.DisplayMember = "NombreDocumento";
            cBoxTiposDocumentos.SelectedIndex = -1;

            DTListarPacientesDocumentos = new DSTrabajo_Social.ListarPacientesDocumentosDataTable();
            dtGVPacientesDocumentos.AutoGenerateColumns = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if(!rBtnAmbos.Checked && !rBtnTramitoPac.Checked && !rBtnTramitoTS.Checked)
            {
                MessageBox.Show(this,"Aún no ha seleccionado ninguna opción de filtrado");
                rBtnTramitoPac.Focus();
                return;
            }

            string TramitoTrabajoSocial = String.Empty;
            if(rBtnTramitoTS.Checked)
                TramitoTrabajoSocial = "S";
            else if(rBtnTramitoPac.Checked)
                TramitoTrabajoSocial = "N";
            else
                TramitoTrabajoSocial = null;
            string Orden = string.Empty;
            //if (rbtnOrdenFechaRegistro.Checked)
            //    Orden = "F";
            //else if (rBtnOrdenHClinico.Checked)
            //    Orden = "H";

            DTListarPacientesDocumentos = TAListarPacientesDocumentos.GetData(dateFechaInicio.Value, dateFechaFin.Value, TramitoTrabajoSocial, "D", Orden);
            if (checkTiposDocumentos.Checked && cBoxTiposDocumentos.SelectedIndex >= 0 && !checkActualmenteHospitalizados.Checked)
                DTListarPacientesDocumentos.DefaultView.RowFilter = "CodigoDocumentoTipo = " + int.Parse(cBoxTiposDocumentos.SelectedValue.ToString());
            else if (checkTiposDocumentos.Checked && cBoxTiposDocumentos.SelectedIndex >= 0 && checkActualmenteHospitalizados.Checked)
                DTListarPacientesDocumentos.DefaultView.RowFilter = "CodigoDocumentoTipo = " + int.Parse(cBoxTiposDocumentos.SelectedValue.ToString()) + " AND CodigoEstadoPaciente = 'A'";
            else if (!checkTiposDocumentos.Checked && checkActualmenteHospitalizados.Checked)
                DTListarPacientesDocumentos.DefaultView.RowFilter = "CodigoEstadoPaciente = 'A'";
            bdSourcePacientesDocumentos.DataSource = DTListarPacientesDocumentos;
            dtGVPacientesDocumentos.DataSource = bdSourcePacientesDocumentos;
            if (DTListarPacientesDocumentos.Count == 0)
            {
                MessageBox.Show(this, "No se encontró ningun registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (DTListarPacientesDocumentos.Count == 0)
            {
                MessageBox.Show(this, "No existen datos que mostrar en el informe");
                return;
            }

            Reportes.FReporteDocumentosPacientes formReporte = new Reportes.FReporteDocumentosPacientes();
            formReporte.cargarDatos(DTListarPacientesDocumentos.DefaultView.ToTable(), dateFechaInicio.Value, dateFechaFin.Value);
            formReporte.ShowDialog();
            formReporte.Dispose();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cBoxTiposDocumentos.Enabled = checkTiposDocumentos.Checked;
            if (checkTiposDocumentos.Checked)
                cBoxTiposDocumentos.Focus();
            else
                cBoxTiposDocumentos.SelectedIndex = -1;
        }
    }
}
