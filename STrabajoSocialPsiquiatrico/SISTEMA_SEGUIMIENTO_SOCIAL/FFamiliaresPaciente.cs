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

    public partial class FFamiliaresPaciente : Form
    {
        private FamiliaresTableAdapter TAFamiliares;
        private DSTrabajo_Social.FamiliaresDataTable DTFamiliares;
        
        private String NombreCompletoPaciente;

        public int NumeroPaciente { get; set; }
        public DSTrabajo_Social.FamiliaresRow DRFamiliares{get; set;}


        public FFamiliaresPaciente(int NumeroPaciente, String NombreCompletoPaciente)
        {
            InitializeComponent();
            TAFamiliares = new FamiliaresTableAdapter();
            DTFamiliares = TAFamiliares.GetDataByPaciente(NumeroPaciente);

            this.NumeroPaciente = NumeroPaciente;
            this.NombreCompletoPaciente = NombreCompletoPaciente;

            dtgvListadoFamiliares.AutoGenerateColumns = false;
            dtgvListadoFamiliares.DataSource = DTFamiliares;
            tsLblNombreCompleto.Text = NombreCompletoPaciente;

            this.Shown += new EventHandler(FFamiliaresPaciente_Shown);

        }

        void FFamiliaresPaciente_Shown(object sender, EventArgs e)
        {
            if (DTFamiliares.Count == 0)
            {
                MessageBox.Show(this, "El Paciente Actual no cuenta con ningun familiar registrado en el Sistema", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Visible = false;
                this.Close();
            }
        }

        public void agregarDatosFamiliaresTemporales(DSTrabajo_Social.FamiliaresDataTable DTPacientesFamiliaresTemporal)
        {
            foreach (DSTrabajo_Social.FamiliaresRow Familiar in DTPacientesFamiliaresTemporal.Rows)
            {
                if (DTFamiliares.FindByNumeroPacienteNumeroFamiliar(NumeroPaciente, Familiar.NumeroFamiliar) == null)
                {
                    DTFamiliares.Rows.Add(Familiar.ItemArray);
                }
            }

            DTFamiliares.AcceptChanges();

        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dtgvListadoFamiliares_CellDoubleClick(dtgvListadoFamiliares, 
                new DataGridViewCellEventArgs(dtgvListadoFamiliares.CurrentCell.ColumnIndex, dtgvListadoFamiliares.CurrentCell.RowIndex));
        }

        private void dtgvListadoFamiliares_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvListadoFamiliares.CurrentCell != null && e.RowIndex >= 0)
            {
                int CodigoFamiliar = int.Parse(dtgvListadoFamiliares.CurrentRow.Cells["DGCNumeroFamiliar"].Value.ToString());

                DRFamiliares = DTFamiliares.FindByNumeroPacienteNumeroFamiliar(NumeroPaciente, CodigoFamiliar);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
