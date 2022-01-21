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
    public partial class FDocumentos : Form
    {
        public SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_Social.DocumentosDataTable DTDocumentosPaciente;
        SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_Social.DocumentosTipoDataTable DTDocumentosTipos;

        bool esPacienteNuevo = true;
        string TipoOperacion = "";
        public DocumentosTableAdapter TADocumentosPacientes;
        DocumentosTipoTableAdapter TADocumentosTipo;
        int NumeroPacienteActual = -1;
        int NumeroDocumentoActual = -1;
        ErrorProvider eProviderDocumentosPaciente;
        int? NumeroHistorialClinico;

        public FDocumentos(int NumeroPacienteActual, bool esPacienteNuevo, int? NumeroHistorialClinico)
        {
            try
            {
                InitializeComponent();
                DTDocumentosPaciente = new DSTrabajo_Social.DocumentosDataTable();
                DTDocumentosTipos = new DSTrabajo_Social.DocumentosTipoDataTable();
                TADocumentosPacientes = new DocumentosTableAdapter();
                TADocumentosTipo = new DocumentosTipoTableAdapter();
                eProviderDocumentosPaciente = new ErrorProvider();

                this.NumeroPacienteActual = NumeroPacienteActual;
                this.esPacienteNuevo = esPacienteNuevo;
                this.NumeroHistorialClinico = NumeroHistorialClinico;

                DTDocumentosTipos = TADocumentosTipo.GetData();
                cBoxNombreDocumento.DataSource = DTDocumentosTipos;
                cBoxNombreDocumento.DisplayMember = "NombreDocumento";
                cBoxNombreDocumento.ValueMember = "CodigoDocumentoTipo";

                DGCNombreDocumento.DataSource = DTDocumentosTipos;
                DGCNombreDocumento.DataPropertyName = "CodigoDocumentoTipo";
                DGCNombreDocumento.DisplayMember = "NombreDocumento";
                DGCNombreDocumento.ValueMember = "CodigoDocumentoTipo";
                
                this.TxtNumeroPaciente.Text = NumeroPacienteActual.ToString();
                if (this.NumeroHistorialClinico != null)
                    txtBoxHistorialClinico.Text = NumeroHistorialClinico.ToString();
                DTDocumentosPaciente.NumeroDocumentoColumn.AutoIncrement = true;
                DTDocumentosPaciente.NumeroRegistroColumn.AutoIncrement = true;
                if (!esPacienteNuevo)
                {
                    DTDocumentosPaciente = TADocumentosPacientes.GetDataByPaciente(NumeroPacienteActual);
                    DTDocumentosPaciente.NumeroDocumentoColumn.AutoIncrementSeed = DTDocumentosPaciente.Count > 0 ? DTDocumentosPaciente[DTDocumentosPaciente.Count - 1].NumeroDocumento + 1 : 1;
                    DTDocumentosPaciente.NumeroRegistroColumn.AutoIncrementSeed = DTDocumentosPaciente.Count + 1;
                }
                else
                {

                    DTDocumentosPaciente.NumeroDocumentoColumn.AutoIncrementSeed = 1;
                    DTDocumentosPaciente.NumeroRegistroColumn.AutoIncrementSeed = 1;
                    
                }
                DTDocumentosPaciente.NumeroDocumentoColumn.AutoIncrementStep = +1;
                DTDocumentosPaciente.NumeroRegistroColumn.AutoIncrementStep = +1;
                
                bdSourceDocumentosPacientes.DataSource = DTDocumentosPaciente;
                //bdSourceDocumentosPacientes.MoveFirst();
                DGCNumeroDocumento.Visible = false;
                cargarDocumentosPaciente(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el Formulario Satisfactoriamente, ocurrió la siguiente excepción " + ex.Message);
                throw;
            }
                
        }

        public void limpiarControles()
        {
            TxtNumeroPaciente.Text = String.Empty;
            TxtNumeroDocumento.Text = String.Empty;
            dateFechaRegistroDoc.Value = DateTime.Now;
            cBoxNombreDocumento.SelectedIndex = -1;
            rbtnNoTramitoTSocial.Checked = rbtnSiTramitoTSocial.Checked = false;
            txtBoxHistorialClinico.Text = String.Empty;
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            //TxtNumeroPaciente.ReadOnly = !estadoHabilitacion;
            dateFechaRegistroDoc.Enabled = estadoHabilitacion;
            cBoxNombreDocumento.Enabled = estadoHabilitacion;
            rbtnNoTramitoTSocial.Enabled = rbtnSiTramitoTSocial.Enabled = btnAnadirDocumentos.Enabled =  estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool aceptar, bool cancelar, bool modificar, bool eliminar)
        {
            this.btnAnadirDocumento.Enabled = nuevo;
            this.btnGuardarDocumento.Enabled = aceptar;
            this.btnCancelar.Enabled = cancelar;
            this.btnModificar.Enabled = modificar;
            this.btnEliminar.Enabled = eliminar;
        }

        public void cargarDocumentosPaciente(int NumeroDocumento)
        {
            DSTrabajo_Social.DocumentosRow DRDocumentoPaciente = DTDocumentosPaciente.FindByNumeroPacienteNumeroDocumento(NumeroPacienteActual, NumeroDocumento);
            if (DRDocumentoPaciente == null)
            {
                DSTrabajo_Social.DocumentosDataTable DTDocumentosAux = TADocumentosPacientes.GetDataBy1(NumeroPacienteActual, NumeroDocumento);
                if (DTDocumentosAux.Count > 0)
                    DRDocumentoPaciente = DTDocumentosAux[0];
                else
                {
                    limpiarControles();
                    habilitarControles(false);
                    habilitarBotones(true, false, false, false, false);
                    return;
                }
            }
            
            this.NumeroDocumentoActual = NumeroDocumento;
            TxtNumeroDocumento.Text = DRDocumentoPaciente.NumeroRegistro.ToString();
            TxtNumeroPaciente.Text = DRDocumentoPaciente.NumeroPaciente.ToString();
            txtBoxHistorialClinico.Text = DRDocumentoPaciente["HClinico"].ToString();
            cBoxNombreDocumento.SelectedValue = DRDocumentoPaciente.CodigoDocumentoTipo;
            if (DRDocumentoPaciente.TramitoTrabSocial.CompareTo("S") == 0)
                rbtnSiTramitoTSocial.Checked = true;
            else
                rbtnNoTramitoTSocial.Checked = true;


            habilitarBotones(true, false, false, true, true);
            habilitarControles(false);
            
        }


        private void btnAnadirDocumento_Click(object sender, EventArgs e)
        {
            TipoOperacion = "I";
            limpiarControles();
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false);
            cBoxNombreDocumento.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";            
            habilitarControles(true);
            habilitarBotones(false, true, true, false, false);
            cBoxNombreDocumento.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dtGVListadoDocumento.CurrentCell != null && bdSourceDocumentosPacientes.Position >= 0
                && MessageBox.Show(this,"¿Se Encuentra seguro de Eliminar el Registro Actual?", this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DTDocumentosPaciente.AcceptChanges();
                //int posicion = bdSourceDocumentosPacientes.Position;                
                //DTDocumentosPaciente.Rows.RemoveAt(posicion);
                
                //int NumDocumento = DTDocumentosPaciente[bdSourceDocumentosPacientes.Position].NumeroDocumento;
                int NumDocumento = int.Parse(dtGVListadoDocumento.CurrentRow.Cells["DGCNumeroDocumento"].Value.ToString());
                DTDocumentosPaciente.RemoveDocumentosRow(DTDocumentosPaciente.FindByNumeroPacienteNumeroDocumento(NumeroPacienteActual, NumDocumento));
                TADocumentosPacientes.Delete(NumeroPacienteActual, NumDocumento);
                

                MessageBox.Show(this, "Transacción realizada correctamente", this.Text , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            eProviderDocumentosPaciente.Clear();
            TipoOperacion = "";            
            habilitarControles(false);
            habilitarBotones(true, false, false, false, false);
            limpiarControles();
        }

        private void btnCerrarDocumento_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool validarControles()
        {
            eProviderDocumentosPaciente.Clear();
            if (cBoxNombreDocumento.SelectedIndex < 0)
            {
                eProviderDocumentosPaciente.SetError(cBoxNombreDocumento, "Aún no ha seleccionado un Documento");
                cBoxNombreDocumento.Focus();
                return false;
            }
            if (!rbtnNoTramitoTSocial.Checked && !rbtnSiTramitoTSocial.Checked)
            {
                eProviderDocumentosPaciente.SetError(rbtnSiTramitoTSocial, "No ha seleccionado ninguna de las opciones referentes a quien tramitó el Documento");
                //rbtnSiTramitoTSocial.Focus();
                return false;
            }
            //if (DTDocumentosPaciente.FindByNumeroPacienteNumeroDocumento(NumeroPacienteActual, int.Parse(cBoxNombreDocumento.SelectedValue.ToString())) != null)
            int CantidadRegistros = DTDocumentosPaciente.Select(String.Format("NumeroPaciente = {0} and CodigoDocumentoTipo = {1}", NumeroPacienteActual, int.Parse((cBoxNombreDocumento.SelectedItem as DataRowView)["CodigoDocumentoTipo"].ToString())), "").Length;
			if ( CantidadRegistros > 0 && TipoOperacion == "I")
            {
                eProviderDocumentosPaciente.SetError(cBoxNombreDocumento, "El paciente ya cuenta con el documento seleccionado. Por favor seleccione otro documento");
                MessageBox.Show("El paciente ya cuenta con el documento seleccionado. Por favor verifique");
                cBoxNombreDocumento.Focus();
                return false;
            }

            if (CantidadRegistros > 1 && TipoOperacion == "E")
            {
                eProviderDocumentosPaciente.SetError(cBoxNombreDocumento, "El paciente ya cuenta con el documento seleccionado. Por favor verifique");
                cBoxNombreDocumento.Focus();
                return false;
            }
            return true;
        }

        private void btnGuardarDocumento_Click(object sender, EventArgs e)
        {
            if (!validarControles())
            {
                //MessageBox.Show(this,"Existen algunos datos que aún no han sido Ingresados, probablemente se encuentran mal escritos o quizas ya haya seleccionado el Documento. Por favor proceda a corregir las observaciones");
                return;
            }
            int CodigoDocumentoSeleccionado = int.Parse((cBoxNombreDocumento.SelectedItem as DataRowView)["CodigoDocumentoTipo"].ToString());

            string TramitoTrabajoSocial = rbtnSiTramitoTSocial.Checked ? "S" : "N";
            try
            {
                if (TipoOperacion == "I")
                {
                    DSTrabajo_Social.DocumentosRow DRDocumentoNuevo = DTDocumentosPaciente.AddDocumentosRow(NumeroPacienteActual, DateTime.Now, TramitoTrabajoSocial, CodigoDocumentoSeleccionado, -1, "", 0);
                    if (NumeroHistorialClinico == null)
                        DRDocumentoNuevo.SetHClinicoNull();
                    else
                        DRDocumentoNuevo.HClinico = NumeroHistorialClinico.Value;
                    DTDocumentosPaciente.AcceptChanges();
                    if (!esPacienteNuevo)
                    {
                        TADocumentosPacientes.Insert(NumeroPacienteActual, DateTime.Now, TramitoTrabajoSocial, CodigoDocumentoSeleccionado);
                    }

                }
                else
                {
                    DSTrabajo_Social.DocumentosRow DRDocumentosPacienteEdicion = DTDocumentosPaciente[bdSourceDocumentosPacientes.Position]; 
                    DRDocumentosPacienteEdicion.FechaRegistro = dateFechaRegistroDoc.Value;
                    DRDocumentosPacienteEdicion.CodigoDocumentoTipo = CodigoDocumentoSeleccionado;
                    DRDocumentosPacienteEdicion.TramitoTrabSocial = TramitoTrabajoSocial;
                    DRDocumentosPacienteEdicion.AcceptChanges();

                    if (!esPacienteNuevo)
                    {
                        TADocumentosPacientes.ActualizarDocumento(NumeroPacienteActual, DTDocumentosPaciente[bdSourceDocumentosPacientes.Position].NumeroDocumento, 
                            DTDocumentosPaciente[bdSourceDocumentosPacientes.Position].NumeroRegistro,
                            dateFechaRegistroDoc.Value, TramitoTrabajoSocial, CodigoDocumentoSeleccionado);
                    }

                    //bdSourceDocumentosPacientes.MoveLast();
                    habilitarBotones(true, false, false, true, true);
                    habilitarControles(false);
                }
            }
            catch (Exception )
            {
                MessageBox.Show(this, "No se puede ingresar correctamente el Registro, probablemente esta tratando de ingresar un Documento que ya fue registrado, revise sus datos porfavor");
            }

            //DTDocumentosPaciente.AcceptChanges();
        }

        private void btnAnadirDocumentos_Click(object sender, EventArgs e)
        {
            FAñadirDocumentosTipo formDocumentosTipos = new FAñadirDocumentosTipo();

            formDocumentosTipos.configurarFormularioIA(null);
            formDocumentosTipos.Visible = false;
            formDocumentosTipos.StartPosition = FormStartPosition.CenterScreen;
            if (formDocumentosTipos.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                DTDocumentosTipos.FindByCodigoDocumentoTipo(formDocumentosTipos.CodigoDocumentoTipo) == null)
            {
                DTDocumentosTipos.Rows.Add(TADocumentosTipo.GetDataBy1(formDocumentosTipos.CodigoDocumentoTipo)[0].ItemArray);
                DTDocumentosTipos.DefaultView.Sort = "NombreDocumento ASC";
                cBoxNombreDocumento.SelectedValue = formDocumentosTipos.CodigoDocumentoTipo;

            }
            formDocumentosTipos.Dispose();
        }





        public void cargarDocumentosPacienteTable(int NumeroPaciente, DSTrabajo_Social.DocumentosDataTable DTPacientesDocumentos)
        {
            foreach (DSTrabajo_Social.DocumentosRow DRDocumento in DTPacientesDocumentos)
            {
            //    if(DTDocumentosPaciente.FindByNumeroPacienteNumeroDocumento(NumeroPaciente, DRDocumento.NumeroDocumento) == null)
            //        this.DTDocumentosPaciente.Rows.Add(DRDocumento.ItemArray);

                if(DTDocumentosPaciente.Select("CodigoDocumentoTipo = " + DRDocumento.CodigoDocumentoTipo, "" ).Length == 0)
                    this.DTDocumentosPaciente.Rows.Add(DRDocumento.ItemArray);
            }

        }

        private void TxtNumeroDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtGVListadoDocumento_SelectionChanged(object sender, EventArgs e)
        {
            if (DTDocumentosPaciente.Count > 0 && bdSourceDocumentosPacientes.Position >= 0)
            {
                //cargarDocumentosPaciente(DTDocumentosPaciente[bdSourceDocumentosPacientes.Position].NumeroDocumento);
                int NumDocumento = int.Parse(dtGVListadoDocumento.CurrentRow.Cells["DGCNumeroDocumento"].Value.ToString());
                cargarDocumentosPaciente(NumDocumento);
            }
            else
            {
                cargarDocumentosPaciente(-1);
            }
        }
    }
}
