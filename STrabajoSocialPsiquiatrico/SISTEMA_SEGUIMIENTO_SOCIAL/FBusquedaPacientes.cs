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
    public partial class FBusquedaPacientes : Form
    {
        DSTrabajo_Social.PacientesDataTable DTPacientesBusqueda;
        public DSTrabajo_Social.PacientesRow DRPacienteSeleccionado;
        PacientesTableAdapter TAPacientes;
        public int NumeroPaciente { get; set; }
        private Button btnCancelar;
        ErrorProvider eProviderBuscar = new ErrorProvider();
        public FBusquedaPacientes()
        {
            InitializeComponent();
            TAPacientes = new PacientesTableAdapter();
            DTPacientesBusqueda = new DSTrabajo_Social.PacientesDataTable();
            dtGVListadoPacientesBusqueda.AutoGenerateColumns = false;
            NumeroPaciente = -1;
            btnCancelar = new Button();
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
            this.CancelButton = btnCancelar;
        }

        void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            eProviderBuscar.Clear();
            TxtInformación.Focus();
            TxtInformación.SelectAll();
            String tipoBusqueda = (!checkPacientesConsultaExterna.Checked && !checkPacientesHospitalizados.Checked ? null
                : (checkPacientesConsultaExterna.Checked ? "E" : "H"));
            if (!String.IsNullOrEmpty(TxtInformación.Text))
            {
                DTPacientesBusqueda = TAPacientes.GetDataByBuscar(tipoBusqueda, TxtInformación.Text);
                bdSourcePacientes.DataSource = DTPacientesBusqueda;
                dtGVListadoPacientesBusqueda.DataSource = bdSourcePacientes;

                if (DTPacientesBusqueda.Count == 0)
                {
                    MessageBox.Show(this, "No se Encontró Ningun Registro con la Información Introducida");
                }
            }
            else
            {
                eProviderBuscar.SetError(TxtInformación, "Aún no ha Ingresado ningun texto o parámetro para realizar la búsqueda");
            }
        }

        private void dtGVListadoPacientesBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVListadoPacientesBusqueda.CurrentCell != null && dtGVListadoPacientesBusqueda.Rows.Count > 0)
            {
                NumeroPaciente = DTPacientesBusqueda[dtGVListadoPacientesBusqueda.CurrentRow.Index].NumeroPaciente;
                DRPacienteSeleccionado = DTPacientesBusqueda[dtGVListadoPacientesBusqueda.CurrentRow.Index];
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        private void TxtInformación_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(btnBuscar, e as EventArgs);
            }
        }

        private void btnSubvencionFichaAtencion_Click(object sender, EventArgs e)
        {
            FRegistroPacientesExternos formValoracion = new FRegistroPacientesExternos();
			formValoracion.configurarFormularioIA(null);
            formValoracion.ShowDialog();
            formValoracion.Dispose();
        }

        
        
    }
}
