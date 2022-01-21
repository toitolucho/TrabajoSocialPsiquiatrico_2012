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
    public partial class FGeograficoBusqueda : Form
    {
        public string TipoBusquedaRegion { get; set; }
        BuscarRegionGeograficoTableAdapter TABuscarRegionGeografico = new BuscarRegionGeograficoTableAdapter();
        public DSTrabajo_Social.BuscarRegionGeograficoDataTable DTBuscarRegionGeografico;
        public DSTrabajo_Social.BuscarRegionGeograficoRow DRBuscarRegionGeografico;

        public FGeograficoBusqueda(string TipoBusquedaRegion)
        {
            this.TipoBusquedaRegion = TipoBusquedaRegion;
            InitializeComponent();
            DTBuscarRegionGeografico = new DSTrabajo_Social.BuscarRegionGeograficoDataTable();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Shown += new EventHandler(FGeograficoBusqueda_Shown);
        }

        void FGeograficoBusqueda_Shown(object sender, EventArgs e)
        {
            txtTextoBusqueda.Clear();
            txtTextoBusqueda.Focus();
            DTBuscarRegionGeografico.Clear();
            bdSourceRegiones.DataSource = DTBuscarRegionGeografico;
            switch(TipoBusquedaRegion)
            {
                case "P":
                    DGCCodigo.DataPropertyName = "CodigoPais";
                    break;
                case "D":
                    DGCCodigo.DataPropertyName = "CodigoDepartamento";
                    break;
                case "R":
                    DGCCodigo.DataPropertyName = "CodigoProvincia";
                    break;
                case "L":
                    DGCCodigo.DataPropertyName = "CodigoLocalidad";
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTextoBusqueda.Text))
            {
                MessageBox.Show("Aún no ha ingresado níngun texto");                    
                return;
            }
            DTBuscarRegionGeografico = TABuscarRegionGeografico.GetData(TipoBusquedaRegion, txtTextoBusqueda.Text);
            bdSourceRegiones.DataSource = DTBuscarRegionGeografico;
            txtTextoBusqueda.Focus();
            txtTextoBusqueda.SelectAll();
            if (DTBuscarRegionGeografico.Count == 0)
            {
                MessageBox.Show(this, "No se encontró ningún registro con la información provista", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTextoBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(btnBuscar, e as EventArgs);
            }
        }

        private void dtGVRegiones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DTBuscarRegionGeografico.Count > 0 && dtGVRegiones.CurrentCell != null)
            {
                DRBuscarRegionGeografico = DTBuscarRegionGeografico.FindByCodigoPaisCodigoDepartamentoCodigoProvinciaCodigoLocalidad(
                    dtGVRegiones.CurrentRow.Cells["DGCCodigoPais"].Value.ToString(),
                    dtGVRegiones.CurrentRow.Cells["DGCCodigoDepartamento"].Value.ToString(),
                    dtGVRegiones.CurrentRow.Cells["DGCCodigoProvincia"].Value.ToString(),
                    dtGVRegiones.CurrentRow.Cells["DGCCodigoLocalidad"].Value.ToString()
                    );
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtGVRegiones.CurrentCell != null)
                dtGVRegiones_CellDoubleClick(dtGVRegiones, new DataGridViewCellEventArgs(dtGVRegiones.CurrentCell.ColumnIndex, dtGVRegiones.CurrentCell.RowIndex));
            else
                this.Close();
        }
    }
}
