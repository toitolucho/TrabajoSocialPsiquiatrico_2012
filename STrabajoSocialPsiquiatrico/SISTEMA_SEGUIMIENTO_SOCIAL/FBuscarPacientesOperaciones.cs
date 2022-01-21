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
    public partial class FBuscarPacientesOperaciones : Form
    {
        BuscarPacienteOperacionesTableAdapter TABuscarPaciente;
        DSTrabajo_Social.BuscarPacienteOperacionesDataTable DTPacientes;

        public int NumeroPaciente { get; set; }
        public int NumeroOperacion { get; set; }
        public string FiltroAdicional { set; get;}
        public DSTrabajo_Social.BuscarPacienteOperacionesRow DRPacientes;
        /// <summary>
        /// Tipo Operacion que se debe buscar
        /// 'R'->Reingreso, 'C'->ContraReferencia, 'F'->Referencia
        /// </summary>
        string TipoOperacion;
        Button btnCerrar;

        /// <summary>
        /// Tipo Operacion que se debe buscar
        /// 'R'->Reingreso, 'C'->ContraReferencia, 'F'->Referencia
        /// 'I'->Informes Sociales, 'S'->seguimiento Social
        /// 'A'->Seguimiento Anual, 'V' -> Actividades
        /// </summary>
        /// <param name="TipoOperacion"></param>
        public FBuscarPacientesOperaciones(string TipoOperacion)
        {
            InitializeComponent();
            TABuscarPaciente = new BuscarPacienteOperacionesTableAdapter();
            this.TipoOperacion = TipoOperacion;
            btnCerrar = new Button();
            btnCerrar.Click += new EventHandler(btnCerrar_Click);
            this.CancelButton = btnCerrar;

            switch (TipoOperacion)
            {
                case "F":
                    DGCCIPaciente.DataPropertyName = "MedicoResponsable";
                    DGCCIPaciente.HeaderText = "Medico Resp";

                    DGCDatoExtra1.DataPropertyName = "NombreUnidadMedica";
                    DGCDatoExtra1.HeaderText = "Unidad Medica";

                    DGCDatoExtra2.DataPropertyName = "NombreEspecialidad";
                    DGCDatoExtra2.HeaderText = "Servicio";
                    DGCDatoExtra1.Visible = DGCDatoExtra2.Visible = true;
                    break;
                case "V":
                    DGCDatoExtra1.DataPropertyName = "NombreTrabajadoraSocial";
                    DGCDatoExtra1.HeaderText = "Trab. Social";

                    DGCDatoExtra2.DataPropertyName = "NombreActividad";
                    DGCDatoExtra2.HeaderText = "Actividad";
                    DGCDatoExtra1.Visible = DGCDatoExtra2.Visible = true;
                    break;
                case "P":
                    DGCDatoExtra1.DataPropertyName = "ClaseServicio";
                    DGCDatoExtra1.HeaderText = "Clase";
                    DGCDatoExtra1.Visible = true;
                    break;
                case "R":
                    checkListarUltimosRegistros.Visible = true;
                    break;
                default :
                    DGCDatoExtra1.Visible = DGCDatoExtra2.Visible = false;
                    break;
                
            }
        }

        void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtTextoBusqueda.Focus();
            txtTextoBusqueda.SelectAll();
            if (!String.IsNullOrEmpty(txtTextoBusqueda.Text))
            {
                string TextoBusqueda = txtTextoBusqueda.Text;
                if (TipoOperacion == "F" && !String.IsNullOrEmpty(FiltroAdicional))
                {
                    TextoBusqueda += "|" + FiltroAdicional;
                }
                DTPacientes = TABuscarPaciente.GetData(TextoBusqueda, 
                    checkBox1.Checked ? (DateTime?)dateTimePicker1.Value : null, 
                    checkBox1.Checked ? (DateTime?)dateTimePicker2.Value : null, TipoOperacion);

                if (checkListarUltimosRegistros.Checked)
                {
                    DSTrabajo_Social.BuscarPacienteOperacionesDataTable DTPrueba = (DSTrabajo_Social.BuscarPacienteOperacionesDataTable)DTPacientes.Clone();
                    
                    foreach (DSTrabajo_Social.BuscarPacienteOperacionesRow DRFila in DTPacientes.Rows)
                    {
                        if (DTPrueba.Select("NumeroPaciente = " + DRFila.NumeroPaciente).Length == 0)
                            DTPrueba.Rows.Add(DTPacientes.Select("NumeroPaciente = " + DRFila.NumeroPaciente, " NumeroOperacion DESC")[0].ItemArray);
                    }

                    DTPacientes = DTPrueba;
                }

                bdSourcePacientes.DataSource = DTPacientes;
                bindingNavigator1.BindingSource = bdSourcePacientes;
                dtgvPacientes.DataSource = bdSourcePacientes;

                if (DTPacientes.Count == 0)
                {
                    MessageBox.Show(this, "No se ha encontrado ningún registro con la Información Introducida", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Aún no ha Ingresado ningun texto");
            }
        }

        private void txtTextoBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnBuscar_Click(btnBuscar, e as EventArgs);
        }

        private void dtgvPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvPacientes.CurrentCell != null && dtgvPacientes.Rows.Count > 0
                && bdSourcePacientes.Position >= 0)
            {
                NumeroPaciente = DTPacientes[bdSourcePacientes.Position].NumeroPaciente;
                NumeroOperacion = DTPacientes[bdSourcePacientes.Position].NumeroOperacion;
                DRPacientes = DTPacientes[bdSourcePacientes.Position];
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = dateTimePicker2.Enabled = checkBox1.Checked;            
        }

        private void FBuscarPacientesOperaciones_Shown(object sender, EventArgs e)
        {
            txtTextoBusqueda.Focus();
            txtTextoBusqueda.SelectAll();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
