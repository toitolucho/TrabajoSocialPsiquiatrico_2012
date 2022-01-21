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
    public partial class FRepPacientesExternos : Form
    {
        ListarHistorialPacientesReportesTableAdapter TAListarHistorialPacientesReportes;
        DSTrabajo_Social.ListarHistorialPacientesReportesDataTable DTListarHistorialPacientesReportes;
        DepartamentosTableAdapter TADepartamentos;        
        ServiciosTableAdapter TAServicios;
        CategoriasTableAdapter TACategorias;

        ErrorProvider eProviderReporte;
        public FRepPacientesExternos()
        {
            InitializeComponent();
            TAListarHistorialPacientesReportes = new ListarHistorialPacientesReportesTableAdapter();
            DTListarHistorialPacientesReportes = new DSTrabajo_Social.ListarHistorialPacientesReportesDataTable();
            TADepartamentos = new DepartamentosTableAdapter();
            TAServicios = new ServiciosTableAdapter();
            TACategorias = new CategoriasTableAdapter();
            dtGVPacientes.AutoGenerateColumns = false;
            eProviderReporte = new ErrorProvider();
            txtEdad1.KeyPress += Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress;
            txtEdad2.KeyPress += Utilidades.EventosValidacionTexto.TextBoxEnteros_KeyPress;


            cBoxSexo.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaSexo();
            cBoxSexo.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxSexo.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxSexo.SelectedIndex = -1;

            cBoxEstadoCivil.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaEstadoCivil();
            cBoxEstadoCivil.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxEstadoCivil.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxEstadoCivil.SelectedIndex = -1;

            cBoxGradoInstruccion.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaGradoInstruccion();
            cBoxGradoInstruccion.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxGradoInstruccion.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxGradoInstruccion.SelectedIndex = -1;

            cBoxProcedencia.DataSource = TADepartamentos.GetData();
            cBoxProcedencia.DisplayMember = "NombreDepartamento";
            cBoxProcedencia.ValueMember = "CodigoDepartamento";
            cBoxProcedencia.SelectedIndex = -1;

            cBoxCategoria.DataSource = TACategorias.GetData();
            cBoxCategoria.DisplayMember = "NombreCategoria";
            cBoxCategoria.ValueMember = "CodigoCategoria";
            cBoxCategoria.SelectedIndex = -1;

            cBoxServicio.DataSource = TAServicios.GetData();
            cBoxServicio.DisplayMember = "NombreServicio";
            cBoxServicio.ValueMember = "CodigoServicio";
            cBoxServicio.SelectedIndex = -1;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkSexo_CheckedChanged(object sender, EventArgs e)
        {
            cBoxSexo.Enabled = checkSexo.Checked;
            if (checkSexo.Checked)
                cBoxSexo.Focus();
            else
                cBoxSexo.SelectedIndex = -1;
        }

        private void checkEdad_CheckedChanged(object sender, EventArgs e)
        {
            cBoxEdad.Enabled = txtEdad1.Enabled = txtEdad2.Enabled = checkEdad.Checked;
            if (checkEdad.Checked)
                txtEdad1.Focus();
            else
                cBoxEdad.SelectedIndex = -1;
        }

        private void checkEstadoCivil_CheckedChanged(object sender, EventArgs e)
        {
            cBoxEstadoCivil.Enabled = checkEstadoCivil.Checked;
            if (checkEstadoCivil.Checked)
                cBoxEstadoCivil.Focus();
            else
                cBoxEstadoCivil.SelectedIndex = -1;
        }

        private void checkGradoInstruccion_CheckedChanged(object sender, EventArgs e)
        {
            cBoxGradoInstruccion.Enabled = checkGradoInstruccion.Checked;
            if (checkGradoInstruccion.Checked)
                cBoxGradoInstruccion.Focus();
            else
                cBoxGradoInstruccion.SelectedIndex = -1;
        }

        private void checkProcedencia_CheckedChanged(object sender, EventArgs e)
        {
            cBoxProcedencia.Enabled = checkProcedencia.Checked;
            if (checkProcedencia.Checked)
                cBoxProcedencia.Focus();
            else
                cBoxProcedencia.SelectedIndex = -1;
        }

        public bool validarControles()
        {
            eProviderReporte.Clear();
            if (checkSexo.Checked && cBoxSexo.SelectedIndex < 0)
            {
                eProviderReporte.SetError(cBoxSexo, "Aún no ha seleccionado el Sexo");
                cBoxSexo.Focus();
                return false;
            }
            if (checkEdad.Checked && cBoxEdad.SelectedIndex >= 0)
            {
                if (cBoxEdad.SelectedIndex < 3 && String.IsNullOrEmpty(txtEdad1.Text))
                {
                    eProviderReporte.SetError(txtEdad1, "Aún no ha ingresado la Edad de Comparación");
                    txtEdad1.Focus();
                    return false;
                }
                else
                {
                    if (String.IsNullOrEmpty(txtEdad1.Text))
                    {
                        eProviderReporte.SetError(txtEdad1, "Aún no ha ingresado la Primera Edad de Comparación");
                        txtEdad1.Focus();
                        return false;
                    }
                    else if (String.IsNullOrEmpty(txtEdad1.Text))
                    {
                        eProviderReporte.SetError(txtEdad1, "Aún no ha ingresado la Segunda Edad de Comparación");
                        txtEdad1.Focus();
                        return false;
                    }
                }
            }
            if (checkEstadoCivil.Checked && cBoxEstadoCivil.SelectedIndex < 0)
            {
                eProviderReporte.SetError(cBoxEstadoCivil, "Aún no ha seleccionado el Estado Civil");
                cBoxEstadoCivil.Focus();
                return false;
            }
            if (checkGradoInstruccion.Checked && cBoxGradoInstruccion.SelectedIndex < 0)
            {
                eProviderReporte.SetError(cBoxGradoInstruccion, "Aún no ha seleccionado el Grado de Instrucción");
                cBoxGradoInstruccion.Focus();
                return false;
            }
            if (checkProcedencia.Checked && cBoxProcedencia.SelectedIndex < 0)
            {
                eProviderReporte.SetError(cBoxProcedencia, "Aún no ha seleccionado la Procedencia");
                cBoxProcedencia.Focus();
                return false;
            }
            return true;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (!validarControles())
            {
                MessageBox.Show(this, "Existen algunos friltros que no pueden ser aplicados debido a que no ha selecionado una opción. Para mas detalle aproxime el cursor del Mouse el punto Rojo Parpadeante");
                return;
            }
            int edad1 = 0, edad2 = 0; String operadorComparacion = String.Empty;
            if (checkEdad.Checked)
            {
                switch (cBoxEdad.SelectedIndex)
                {
                    case 0: operadorComparacion = "="; break;
                    case 1: operadorComparacion = ">"; break;
                    case 2: operadorComparacion = "<"; break;
                    case 3: operadorComparacion = String.Empty; edad2 = int.Parse(txtEdad2.Text); break;
                }
                edad1 = int.Parse(txtEdad1.Text);

            }

            DTListarHistorialPacientesReportes = TAListarHistorialPacientesReportes.GetData(checkServicio.Checked ? "P": null, String.IsNullOrEmpty(operadorComparacion) ? null : operadorComparacion, null, 
                txtNombrePaciente.Text, checkSexo.Checked ? cBoxSexo.SelectedValue.ToString() : null,
                checkEdad.Checked ? (int?)edad1 : null, (checkEdad.Checked && cBoxEdad.SelectedIndex == 3) ? (int?)edad2 : null, checkEstadoCivil.Checked ? cBoxEstadoCivil.SelectedValue.ToString() : null, checkProcedencia.Checked ? cBoxProcedencia.SelectedValue.ToString() : null,
                "E", null, null, null, 
                checkCategoria.Checked ? int.Parse(cBoxCategoria.SelectedValue.ToString()) : (int?) null, 
                checkServicio.Checked ? int.Parse(cBoxServicio.SelectedValue.ToString()) : (int?)null, 
                null, checkGradoInstruccion.Checked ? cBoxGradoInstruccion.SelectedValue.ToString() : null,null,null, null, null);

            dtGVPacientes.DataSource = DTListarHistorialPacientesReportes;
            txtTotalPacientes.Text = DTListarHistorialPacientesReportes.Count.ToString();
            if (DTListarHistorialPacientesReportes.Count == 0)
            {
                MessageBox.Show(this, "No se encontró ningún registro con la información provista", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.FReporteAdmisionPacientes formReporteAdmision = new Reportes.FReporteAdmisionPacientes();
            formReporteAdmision.cargarDatos(DTListarHistorialPacientesReportes);
            formReporteAdmision.ShowDialog();
            formReporteAdmision.Dispose();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkServicio_CheckedChanged(object sender, EventArgs e)
        {
            cBoxServicio.Enabled = checkServicio.Checked;
            if (checkServicio.Checked)
                cBoxServicio.Focus();
            else
                cBoxServicio.SelectedIndex = -1;
        }

        private void checkCategoria_CheckedChanged(object sender, EventArgs e)
        {
            cBoxCategoria.Enabled = checkCategoria.Checked;
            if (checkCategoria.Checked)
                cBoxCategoria.Focus();
            else
                cBoxCategoria.SelectedIndex = -1;
        }


    }
}
