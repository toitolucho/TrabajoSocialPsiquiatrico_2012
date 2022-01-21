using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_SocialTableAdapters;
using SISTEMA_SEGUIMIENTO_SOCIAL.ReportesCR;

namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    public partial class FKardex : Form
    {
        DSTrabajo_SocialTableAdapters.PacientesTableAdapter TAPacientes;
        DSTrabajo_Social.PacientesDataTable DTPacientes;
        DSTrabajo_SocialTableAdapters.ListarKardexPersonalPacienteTableAdapter TAKardexPaciente;
        DSTrabajo_Social.ListarKardexPersonalPacienteDataTable DTKardexPaciente;
        public FKardex()
        {
            TAPacientes = new PacientesTableAdapter();
            InitializeComponent();
            dtGVListadoPaciente.AutoGenerateColumns = false;
            cBoxBuscarPor.SelectedIndex = 0;
            TAKardexPaciente = new ListarKardexPersonalPacienteTableAdapter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cBoxBuscarPor.SelectedIndex < 0)
            {
                MessageBox.Show("Aún no ha seleccionado ninguna opción de busqueda");
                return;
            }

            if (cBoxBuscarPor.SelectedIndex.Equals(4) || cBoxBuscarPor.SelectedIndex.Equals(0))
            {
                int numero = -1;
                if (!(int.TryParse(TxtInformacionKardex.Text, out numero)))
                {
                    MessageBox.Show(this,"Debe ingresar la información a buscar de forma numeral");
                    return;
                }
            }
            DTPacientes = TAPacientes.GetDataByKardex(cBoxBuscarPor.SelectedIndex.ToString(), TxtInformacionKardex.Text);
            dtGVListadoPaciente.DataSource = DTPacientes;
            dtGVListadoPaciente.ClearSelection();
            if (DTPacientes.Count == 0)
            {
                MessageBox.Show(this, "No se encontró ningun registro con la información provista", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

            TxtInformacionKardex.Focus();
            TxtInformacionKardex.SelectAll();
        }

        private void FKardex_Shown(object sender, EventArgs e)
        {
            TxtInformacionKardex.Focus();
        }

        private void dtGVListadoPaciente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtGVListadoPaciente.CurrentCell != null)
            {
                TxtNombrePacienteKardex.Text = String.Format("{0} {1} {2}", dtGVListadoPaciente.CurrentRow.Cells["DGCNombre"].Value,
                     dtGVListadoPaciente.CurrentRow.Cells["DGCApellidoPaterno"].Value,
                      dtGVListadoPaciente.CurrentRow.Cells["DGCApellidoMaterno"].Value);


                int NumeroPaciente = int.Parse(dtGVListadoPaciente.CurrentRow.Cells["DGCNumeroPaciente"].Value.ToString());
                DTKardexPaciente = TAKardexPaciente.GetData(NumeroPaciente);
                CRPacienteKardex CRKardex = new CRPacienteKardex();
                CRKardex.SetDataSource((DataTable)DTKardexPaciente);
                this.CRVKardexPaciente.ReportSource = CRKardex;

            }
            else
                TxtNombrePacienteKardex.Text = string.Empty;
        }

        private void TxtInformacionKardex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(btnBuscar, e as EventArgs);
            }
        }
    }
}
