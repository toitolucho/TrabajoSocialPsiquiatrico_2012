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
    public partial class FRepIngresosAltasReingresos : Form
    {
        ListarHistorialPacientesReportesTableAdapter TAListarHistorialPacientesReportes;
        DSTrabajo_Social.ListarHistorialPacientesReportesDataTable DTListarHistorialPacientesReportes;
        ListarAltasMensualesTableAdapter TAListarAltasMensuales;
        ListarIngresosReingresosMensualesTableAdapter TAListarIngresosReingresosMensuales;
        CategoriasTableAdapter TACategorias;
        DepartamentosTableAdapter TADepartamentos;
        ErrorProvider eProviderReporte = new ErrorProvider();

        DataTable DTIngresoReingresoAltas;
        public FRepIngresosAltasReingresos()
        {
            InitializeComponent();

            TAListarHistorialPacientesReportes = new ListarHistorialPacientesReportesTableAdapter();
            TAListarIngresosReingresosMensuales = new ListarIngresosReingresosMensualesTableAdapter();
            TAListarAltasMensuales = new ListarAltasMensualesTableAdapter();
            TACategorias = new CategoriasTableAdapter();
            TADepartamentos = new DepartamentosTableAdapter();



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

            cBoxReligion.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaReligion();
            cBoxReligion.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxReligion.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxReligion.SelectedIndex = -1;

            cBoxIdioma.DataSource = Utilidades.ObjetoCodigoDescripcion.generarListaIdioma();
            cBoxIdioma.DisplayMember = Utilidades.ObjetoCodigoDescripcion.DisplayMember;
            cBoxIdioma.ValueMember = Utilidades.ObjetoCodigoDescripcion.ValueMember;
            cBoxIdioma.SelectedIndex = -1;

            cboxCategoria.DataSource = TACategorias.GetData();
            cboxCategoria.DisplayMember = "NombreCategoria";
            cboxCategoria.ValueMember = "CodigoCategoria";
            cboxCategoria.SelectedIndex = -1;

            cBoxProcedencia.DataSource = TADepartamentos.GetDataByPais("BO");
            cBoxProcedencia.DisplayMember = "NombreDepartamento";
            cBoxProcedencia.ValueMember = "CodigoDepartamento";
            cBoxProcedencia.SelectedIndex = -1;

            dtGVPacientes.AutoGenerateColumns = false;
            DGCFechaOperacion.DataPropertyName = "FechaConsulta";
            checkPacientesHospitalizados.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rBtnIngresos_CheckedChanged(object sender, EventArgs e)
        {
            DGCFechaOperacion.HeaderText = "Fecha Ingreso";
            rBtnCantidadTotalAltas.Checked = rBtnCantidadTotalIngRe.Checked = false;
            checkPacientesHospitalizados.Enabled = rBtnIngresos.Checked;
        }

        private void rBtnReingresos_CheckedChanged(object sender, EventArgs e)
        {
            DGCFechaOperacion.HeaderText = "Fecha Reingreso";
            rBtnCantidadTotalAltas.Checked = rBtnCantidadTotalIngRe.Checked = false;
        }

        private void rBtnAltas_CheckedChanged(object sender, EventArgs e)
        {
            DGCFechaOperacion.HeaderText = "Fecha Alta Hospitalaria";
            rBtnCantidadTotalAltas.Checked = rBtnCantidadTotalIngRe.Checked = false;
        }

        private void checkSexo_CheckedChanged(object sender, EventArgs e)
        {
            cBoxSexo.Enabled = checkSexo.Checked;
            if (checkSexo.Checked)
                cBoxSexo.Focus();
            else
                cBoxSexo.SelectedIndex = -1;
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
            if (checkEdad.Checked && cboxEdad.SelectedIndex >= 0)
            {
                if (cboxEdad.SelectedIndex < 3 && String.IsNullOrEmpty(txtEdad1.Text))
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

            if (checkReligion.Checked && cBoxReligion.SelectedIndex < 0)
            {
                eProviderReporte.SetError(cBoxReligion, "Aún no ha seleccionado la religión");
                cBoxReligion.Focus();
                return false;
            }

            if (checkIdioma.Checked && cBoxIdioma.SelectedIndex < 0)
            {
                eProviderReporte.SetError(cBoxIdioma, "Aún no ha seleccionado el idioma");
                cBoxIdioma.Focus();
                return false;
            }

            if (checkCategoria.Checked && cboxCategoria.SelectedIndex < 0)
            {
                eProviderReporte.SetError(cboxCategoria, "Aún no ha seleccionado la Categoria");
                cboxCategoria.Focus();
                return false;
            }

            if (checkEdad.Checked && cboxEdad.SelectedIndex < 0)
            {
                eProviderReporte.SetError(cboxEdad, "Aún no ha seleccionado Ningun operador de comparación para la edad");
                cboxEdad.Focus();
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
            int edad1 = 0, edad2 = 0; String operadorComparacion = String.Empty;
            if (checkEdad.Checked)
            {
                switch (cboxEdad.SelectedIndex)
                {
                    case 0: operadorComparacion = "="; break;
                    case 1: operadorComparacion = ">"; break;
                    case 2: operadorComparacion = "<"; break;
                    case 3: operadorComparacion = String.Empty; edad2 = int.Parse(txtEdad2.Text); break;
                }
                edad1 = int.Parse(txtEdad1.Text);

            }



            if (!rBtnAltas.Checked && !rBtnIngresos.Checked && !rBtnReingresos.Checked && !rBtnCantidadTotalAltas.Checked && !rBtnCantidadTotalIngRe.Checked)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ninguna Opcion");
                return;
            }

            if (checkSexo.Checked && cBoxSexo.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ningún filtro");
                return;
            }
            string TipoReporte = "";
            if (rBtnIngresos.Checked)
            {
                TipoReporte = "I";                
            }
            if (rBtnReingresos.Checked)
                TipoReporte = "R";
            if (rBtnAltas.Checked)
                TipoReporte = "A";

            DTListarHistorialPacientesReportes = TAListarHistorialPacientesReportes.GetData(TipoReporte, String.IsNullOrEmpty(operadorComparacion) ? null : operadorComparacion,
                null, null, checkSexo.Checked ? cBoxSexo.SelectedValue.ToString() : null,
                checkEdad.Checked ? (int?)edad1 : null, (checkEdad.Checked && cboxEdad.SelectedIndex == 3) ? (int?)edad2 : null, checkEstadoCivil.Checked ? cBoxEstadoCivil.SelectedValue.ToString() : null, 
                checkProcedencia.Checked ? cBoxProcedencia.SelectedValue.ToString() : null, null, null, null, null, 
                checkCategoria.Checked ? int.Parse(cboxCategoria.SelectedValue.ToString()) : (int?)null,
                null, null, checkGradoInstruccion.Checked ? cBoxGradoInstruccion.SelectedValue.ToString() : null,
                checkReligion.Checked ? cBoxReligion.SelectedValue.ToString() : null,
                checkIdioma.Checked ? cBoxIdioma.SelectedValue.ToString() : null, dateFechaInicio.Value, dateFechaFin.Value);
            dtGVPacientes.DataSource = DTListarHistorialPacientesReportes;
            txtNroPacientes.Text = DTListarHistorialPacientesReportes.Count.ToString();
            if (DTListarHistorialPacientesReportes.Count == 0)
            {
                MessageBox.Show("No existe ningún registro");
            }
        }

        private void btnAñadirUsuario_Click(object sender, EventArgs e)
        {
            if (rBtnAltas.Checked || rBtnIngresos.Checked || rBtnReingresos.Checked)
            {
                Reportes.FReporteInformeSociales formReporte = new Reportes.FReporteInformeSociales();
                formReporte.cargarDatos(DTListarHistorialPacientesReportes);
                formReporte.ShowDialog();
                formReporte.Dispose();
            }
            else
            {

                try
                {
                    FReporteIngresosAltasReingresos formReporteResumenMensual = new FReporteIngresosAltasReingresos();
                    if (rBtnCantidadTotalAltas.Checked)
                    {
                        DTIngresoReingresoAltas = TAListarAltasMensuales.GetData(dateFechaInicio.Value.Month, dateFechaFin.Value.Month, dateFechaFin.Value.Year);
                        formReporteResumenMensual.ListarAltasMensuales(DTIngresoReingresoAltas);
                    }
                    else if (rBtnCantidadTotalIngRe.Checked)
                    {
                        DTIngresoReingresoAltas = TAListarIngresosReingresosMensuales.GetData(dateFechaInicio.Value.Month, dateFechaFin.Value.Month, dateFechaFin.Value.Year);
                        formReporteResumenMensual.ListarIngresosReingresosMensuales(DTIngresoReingresoAltas);
                    }

                    formReporteResumenMensual.ShowDialog();
                    formReporteResumenMensual.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrió la siguiente excepción " + ex.Message);
                }
                
            }
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

        private void checkReligion_CheckedChanged(object sender, EventArgs e)
        {
            cBoxReligion.Enabled = checkReligion.Checked;
            if (checkReligion.Checked)
                cBoxReligion.Focus();
            else
                cBoxReligion.SelectedIndex = -1;
        }

        private void checkIdioma_CheckedChanged(object sender, EventArgs e)
        {
            cBoxIdioma.Enabled = checkIdioma.Checked;
            if (checkIdioma.Checked)
                cBoxIdioma.Focus();
            else
                cBoxIdioma.SelectedIndex = -1;
        }

        private void checkCategoria_CheckedChanged(object sender, EventArgs e)
        {
            cboxCategoria.Enabled = checkCategoria.Checked;
            if (checkCategoria.Checked)
                cboxCategoria.Focus();
            else
                cboxCategoria.SelectedIndex = -1;
        }

        private void checkEdad_CheckedChanged(object sender, EventArgs e)
        {
            cboxEdad.Enabled = txtEdad1.Enabled = txtEdad2.Enabled = checkEdad.Checked;
            if (checkEdad.Checked)
                txtEdad1.Focus();
            else
                cboxEdad.SelectedIndex = -1;
        }

        private void rBtnCantidadTotalIngRe_CheckedChanged(object sender, EventArgs e)
        {
            rBtnAltas.Checked = rBtnIngresos.Checked = rBtnReingresos.Checked = false;
        }
    }
}
