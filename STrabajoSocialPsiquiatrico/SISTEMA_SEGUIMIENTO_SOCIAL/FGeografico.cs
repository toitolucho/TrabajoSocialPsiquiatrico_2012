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
    public partial class FGeografico : Form
    {
        private PaisesTableAdapter Paises = new PaisesTableAdapter();
        private DepartamentosTableAdapter Departamentos = new DepartamentosTableAdapter();
        private ProvinciasTableAdapter Provincias = new ProvinciasTableAdapter();        
        private LocalidadesTableAdapter Localidades = new LocalidadesTableAdapter();
        private QTAFuncionesSistema qtFuncionesSistemas = new QTAFuncionesSistema();
        private string TipoOperacion = "";
        public string vRegion = "";
        public bool cargarAutomaticamente = true;
        public string CodigoDepartamento;
        public string CodigoPais;
        public string CodigoProvincia;
        public string CodigoLugar;
        private bool soloInsertarEditar = false;
        System.Data.SqlClient.SqlConnection Coneccion;
        FGeograficoBusqueda fBuscarRegion = new FGeograficoBusqueda("P");
        public FGeografico()
        {
            InitializeComponent();
            Paises = new PaisesTableAdapter();
            Departamentos = new DepartamentosTableAdapter();
            Provincias = new ProvinciasTableAdapter();
            Localidades = new LocalidadesTableAdapter();
        }

        public FGeografico(System.Data.SqlClient.SqlConnection Coneccion)
        {
            InitializeComponent();
            this.Coneccion = Coneccion;

            Paises = new PaisesTableAdapter();
            Paises.Connection = Coneccion;
            Departamentos = new DepartamentosTableAdapter();
            Departamentos.Connection = Coneccion;
            Provincias = new ProvinciasTableAdapter();
            Provincias.Connection = Coneccion;
            Localidades = new LocalidadesTableAdapter();
            Localidades.Connection = Coneccion;
        }


        public void configurarFormularioIA(string TipoGeografico)
        {

            if (TipoGeografico == "P")
            {
                bNuevo_Click(bNuevo, new EventArgs());
                bNuevo.Visible = bCancelar.Visible = bEliminar.Visible = bEditar.Visible = bBuscarPais.Visible = false;
                seleccionarPestaniaPais();
            }

            if (TipoGeografico == "D")
            {

                bNuevoD_Click(bNuevoD, new EventArgs());
                bNuevoD.Visible = bCancelarD.Visible = bEliminarD.Visible = bEditarD.Visible = bBuscarDep.Visible = false;
                seleccionarPestaniaDepartamento();
            }

            if (TipoGeografico == "V")
            {

                bNuevoP_Click(bNuevoP, new EventArgs());
                bNuevoP.Visible = bCancelarP.Visible = bEliminarP.Visible = bEditarP.Visible = bBuscarProv.Visible = false;
                seleccionarPestaniaProvincia();
            }

            if (TipoGeografico == "L")
            {

                bNuevoL_Click(bNuevoL, new EventArgs());
                bNuevoL.Visible = bCancelarL.Visible = bEliminarL.Visible = bEditarL.Visible = bBuscarLugar.Visible = false;
                seleccionarPestaniaLugar();
            }
            soloInsertarEditar = true;
        }


        public void CargarPaises()
        {
            DataTable DTPaises = new DataTable();
            DTPaises = Paises.GetData();
            //cBNombrePais.DataSource = DTPaises.DefaultView;
            cBNombrePais.DataSource = DTPaises;
            cBNombrePais.DisplayMember = "NombrePais";
            cBNombrePais.ValueMember = "CodigoPais";

        }

        public void CargarPaisesP()
        {
            DataTable DTPaisesP = new DataTable();
            DTPaisesP = Paises.GetData();
            //cBNombrePaisP.DataSource = DTPaisesP.DefaultView;
            cBNombrePaisP.DataSource = DTPaisesP;
            cBNombrePaisP.DisplayMember = "NombrePais";
            cBNombrePaisP.ValueMember = "CodigoPais";

        }

        public void CargarPaisesL()
        {
            DataTable DTPaisesL = new DataTable();
            DTPaisesL = Paises.GetData();
            //cBNombrePaisL.DataSource = DTPaisesL.DefaultView;
            cBNombrePaisL.DataSource = DTPaisesL;
            cBNombrePaisL.DisplayMember = "NombrePais";
            cBNombrePaisL.ValueMember = "CodigoPais";
        }

        public void CargarDepartamentos(string CodigoPais)
        {
            DataTable DTDepartamentos = new DataTable();
            DTDepartamentos = Departamentos.GetDataByPais(CodigoPais);            
            //cBDepartamentoN.DataSource = DTDepartamentos.DefaultView;
            cBDepartamentoN.DataSource = DTDepartamentos;
            cBDepartamentoN.DisplayMember = "NombreDepartamento";
            cBDepartamentoN.ValueMember = "CodigoDepartamento";

        }

        public void CargarDepartamentosL(string CodigoPais)
        {
            DataTable DTDepartamentosL = new DataTable();
            DTDepartamentosL = Departamentos.GetDataByPais(CodigoPais);
            //cBNombreDepartamentoL.DataSource = DTDepartamentosL.DefaultView;
            cBNombreDepartamentoL.DataSource = DTDepartamentosL;
            cBNombreDepartamentoL.DisplayMember = "NombreDepartamento";
            cBNombreDepartamentoL.ValueMember = "CodigoDepartamento";
        }

        public void CargarProvincias(string CodigoPais, string CodigoDepartamento)
        {
            DataTable DTProvincias = new DataTable();
            DTProvincias = Provincias.GetDataByDepartamento(CodigoPais, CodigoDepartamento);
            //cBNombreProvinciaL.DataSource = DTProvincias.DefaultView;
            cBNombreProvinciaL.DataSource = DTProvincias;
            cBNombreProvinciaL.DisplayMember = "NombreProvincia";
            cBNombreProvinciaL.ValueMember = "CodigoProvincia";
        }

        private void FGeografico_Load(object sender, EventArgs e)
        {
            if (cargarAutomaticamente)
            {
                CargarPaises();
                CargarPaisesP();
                CargarPaisesL();
            }
        }

        private void cBNombrePaisP_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cBNombrePaisP.SelectedValue != null)
                CargarDepartamentos(cBNombrePaisP.SelectedValue.ToString());
        }

        private void cBNombrePaisL_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cBNombrePaisL.SelectedValue != null)
                CargarDepartamentosL(cBNombrePaisL.SelectedValue.ToString());
        }

        private void cBNombreDepartamentoL_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((cBNombrePaisL.SelectedValue != null) && (cBNombreDepartamentoL.SelectedValue != null))
                CargarProvincias(cBNombrePaisL.SelectedValue.ToString(), cBNombreDepartamentoL.SelectedValue.ToString());
        }


        //botones para paises     
        private void bNuevo_Click(object sender, EventArgs e)
        {
            bCancelar.Enabled = true;
            bAceptar.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            TipoOperacion = "I";

            //tBCodigoPais.ReadOnly = false;
            tBNombrePais.ReadOnly = false;
            tBNacionalidad.ReadOnly = false;
            
            tBCodigoPais.Text = "";
            tBNombrePais.Text = "";
            tBNacionalidad.Text = "";
            tBCodigoPais.Text = qtFuncionesSistemas.GenerarCodigoPais();
            CodigoPais = tBCodigoPais.Text;
            tBNombrePais.Focus();
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            bCancelar.Enabled = true;
            bAceptar.Enabled = true;
            TipoOperacion = "A";

            //tBCodigoPais.ReadOnly = true;
            tBNombrePais.ReadOnly = false;
            tBNacionalidad.ReadOnly = false;
        }


        private void bEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = "Esta seguro de Eliminar" + tBNombrePais.Text;
            string caption = "Eliminar";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult Resultado;
            Resultado = MessageBox.Show(mensaje, caption, botones);
            if (Resultado == DialogResult.OK)
            {
                Paises.Delete(tBCodigoPais.Text);
                tBCodigoPais.ReadOnly = true;
                tBNombrePais.ReadOnly = true;
                tBNacionalidad.ReadOnly = true;
                
                tBCodigoPais.Text = "";
                tBNombrePais.Text = "";
                tBNacionalidad.Text = "";
            }
            else
                tPPaises.Show();

        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
            {
                if (tBCodigoPais.Text == "")
                {
                    MessageBox.Show("Debe Ingresar el código de País");
                }
                if (tBNombrePais.Text == "")
                {
                    MessageBox.Show("Debe ingresar un nombre de País");
                }
                //if (tBNacionalidad.Text == "")
                //{
                //    MessageBox.Show("Debe ingresar la nacionalidad");
                //}
                else
                {
                    try
                    {
                        Paises.Insert(tBCodigoPais.Text, tBNombrePais.Text);
                        DataTable DTPaises = cBNombrePais.DataSource as DataTable;
                        if (DTPaises != null)
                        {
                            DTPaises.Rows.Add(new object[] { tBCodigoPais.Text, tBNombrePais.Text });
                            DTPaises.AcceptChanges();
                            DTPaises.DefaultView.Sort = "NombrePais ASC";
                            cBNombrePais.SelectedValue = tBCodigoPais.Text;
                        }
                        DataTable DTPaisesL = cBNombrePaisL.DataSource as DataTable;
                        if (DTPaisesL != null)
                        {
                            DTPaisesL.Rows.Add(new object[] { tBCodigoPais.Text, tBNombrePais.Text });
                            DTPaisesL.AcceptChanges();
                            DTPaisesL.DefaultView.Sort = "NombrePais ASC";
                            cBNombrePaisL.SelectedValue = tBCodigoPais.Text;
                        }
                        DataTable DTPaisesP = cBNombrePaisP.DataSource as DataTable;
                        if (DTPaisesP != null)
                        {
                            DTPaisesP.Rows.Add(new object[] { tBCodigoPais.Text, tBNombrePais.Text });
                            DTPaisesP.AcceptChanges();
                            DTPaisesP.DefaultView.Sort = "NombrePais ASC";
                            cBNombrePaisP.SelectedValue = tBCodigoPais.Text;
                        }
                        MessageBox.Show("Ingreso Satisfactorio");
                        if (soloInsertarEditar)
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                    }

                    catch (FormatException)
                    {
                        MessageBox.Show("Datos Incorrectos");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Ya existe un pais con la descripción provista:  " + tBCodigoPais.Text + ", " + tBNombrePais.Text + " No se pudo Insertar el Pais. Ocurrió la siguiente excepcion " + ex.Message);
                    }
                }
                tBCodigoPais.ReadOnly = true;
                tBNombrePais.ReadOnly = true;
                tBNacionalidad.ReadOnly = true;
                bCancelar.Enabled = false;
            }

            else
            {
                if (TipoOperacion == "A")
                {
                    if (tBNombrePais.Text == "")
                    {
                        MessageBox.Show("Debe Ingresar un Nombre de País");
                    }
                    //if (tBNacionalidad.Text == "")
                    //{
                    //    MessageBox.Show("Debe Ingresar la Nacionalidad");
                    //}
                    else
                    {

                        try
                        {
                            Paises.ActualizarPais(tBCodigoPais.Text, tBNombrePais.Text, tBNacionalidad.Text);
                            MessageBox.Show("Actualización satisfactoria");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se pudo realizar la actualización");

                        }
                    }
                    tBCodigoPais.ReadOnly = true;
                    tBNombrePais.ReadOnly = true;
                    tBNacionalidad.ReadOnly = true;
                }

            }
            bCancelar.Enabled = false;
            bAceptar.Enabled = true;
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            tPPaises.Show();
            tBCodigoPais.ReadOnly = true;
            tBNombrePais.ReadOnly = true;
            tBNacionalidad.ReadOnly = true;
            bCancelar.Enabled = false;
            bAceptar.Enabled = false;
        }


        private void Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //botones papa departamentos
        private void bNuevoD_Click(object sender, EventArgs e)
        {
            cBNombrePais.Enabled = true;
            bCancelarD.Enabled = true;
            bAceptarD.Enabled = true;
            bEliminarD.Enabled = true;
            bEditarD.Enabled = true;
            TipoOperacion = "I";

            tBCodigoDepartamento.ReadOnly = false;
            tBNombreDepartamento.ReadOnly = false;

            cBNombrePais.Text = "";
            //tBCodigoDepartamento.Text = "";
            tBNombreDepartamento.Text = "";

            
            CodigoDepartamento = qtFuncionesSistemas.GenerarCodigoDepartamento(cBNombrePais.SelectedValue.ToString());
            tBCodigoDepartamento.Text = String.IsNullOrEmpty(CodigoDepartamento) ? String.Empty : CodigoDepartamento;
            tBNombreDepartamento.Focus();
        }

        private void bEditarD_Click(object sender, EventArgs e)
        {
            bCancelarD.Enabled = true;
            bAceptarD.Enabled = true;
            TipoOperacion = "A";

            //tBCodigoDepartamento.ReadOnly = true;
            tBNombreDepartamento.ReadOnly = false;
        }

        private void bEliminarD_Click(object sender, EventArgs e)
        {
            string mensaje = "Esta seguro de Eliminar" + tBNombreDepartamento.Text;
            string caption = "Eliminar";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult Resultado;
            Resultado = MessageBox.Show(mensaje, caption, botones);
            if (Resultado == DialogResult.OK)
            {
                Departamentos.Delete(cBNombrePais.SelectedValue.ToString(), tBCodigoDepartamento.Text);

                tBCodigoDepartamento.Text = "";
                tBNombreDepartamento.Text = "";

            }
            else
                tPPaises.Show();

        }


        private void bAceptarD_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
            {
                if (cBNombrePais.SelectedValue.ToString() == "00")
                {
                    MessageBox.Show("Debe seleccionar un Pais");
                }
                if (tBCodigoDepartamento.Text == "")
                {
                    MessageBox.Show("Debe Ingresar el código del Departamento");
                }
                if (tBNombreDepartamento.Text == "")
                {
                    MessageBox.Show("Debe Ingresar el nombre de un Departamento");
                }
                else
                {
                    try
                    {
                        Departamentos.Insert(cBNombrePais.SelectedValue.ToString(), tBCodigoDepartamento.Text, tBNombreDepartamento.Text);
                        CodigoDepartamento = tBCodigoDepartamento.Text;


                        DataTable DTDepartamentosN = cBDepartamentoN.DataSource as DataTable;
                        if (DTDepartamentosN != null)
                        {
                            DTDepartamentosN.Rows.Add(new object[] { cBNombrePais.SelectedValue.ToString(), tBCodigoDepartamento.Text, tBNombreDepartamento.Text });
                            DTDepartamentosN.AcceptChanges();
                            DTDepartamentosN.DefaultView.Sort = "NombreDepartamento ASC";
                            cBNombrePaisP.SelectedValue = cBNombrePais.SelectedValue;
                            cBDepartamentoN.SelectedValue = tBCodigoDepartamento.Text;
                        }


                        DataTable DTDepartamentosL = cBNombreDepartamentoL.DataSource as DataTable;
                        if (DTDepartamentosL != null)
                        {
                            DTDepartamentosL.Rows.Add(new object[] { cBNombrePais.SelectedValue.ToString(), tBCodigoDepartamento.Text, tBNombreDepartamento.Text });
                            DTDepartamentosL.AcceptChanges();
                            DTDepartamentosL.DefaultView.Sort = "NombreDepartamento ASC";
                            cBNombrePaisL.SelectedValue = cBNombrePais.SelectedValue;
                            cBNombreDepartamentoL.SelectedValue = tBCodigoDepartamento.Text;
                        }

                        MessageBox.Show("Ingreso Satisfactorio");
                        if (soloInsertarEditar)
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Datos Incorrectos");
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Ya existe un Departamento con el código:  " + tBCodigoDepartamento.Text +
                            " No se pudo Insertar el Departamento!!!");
                    }
                }
                cBNombrePais.Enabled = false;
                tBCodigoDepartamento.ReadOnly = true;
                tBNombreDepartamento.ReadOnly = true;
            }
            else
            {
                if (TipoOperacion == "A")
                {
                    if (tBNombreDepartamento.Text == "")
                    {
                        MessageBox.Show("Debe Ingresar un nombre para el Departamento");
                    }
                    else
                    {
                        try
                        {
                            Departamentos.ActualizarDepartamento(cBNombrePais.SelectedValue.ToString(), tBCodigoDepartamento.Text, tBNombreDepartamento.Text);
                            MessageBox.Show("Actualización Satisfactoria");
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("No se pudo Actualizar los Datos");
                        }
                    }

                    tBCodigoDepartamento.ReadOnly = true;
                    tBNombreDepartamento.ReadOnly = true;
                }
            }
            bCancelarD.Enabled = false;
            bAceptarD.Enabled = false;
        }

        private void bCancelarD_Click(object sender, EventArgs e)
        {
            tPDepartamentos.Show();
            tBCodigoDepartamento.ReadOnly = true;
            tBNombreDepartamento.ReadOnly = true;
            bCancelarD.Enabled = false;
            bAceptarD.Enabled = false;
            cBNombrePais.Enabled = false;
        }

        private void SalirD_Click(object sender, EventArgs e)
        {
            Close();
        }


        //botones para provincias
        private void bNuevoP_Click(object sender, EventArgs e)
        {
            cBNombrePaisP.Enabled = true;
            cBDepartamentoN.Enabled = true;
            bCancelarP.Enabled = true;
            bAceptarP.Enabled = true;
            bEditarP.Enabled = true;
            bEliminarP.Enabled = true;
            TipoOperacion = "I";

            if(cargarAutomaticamente)
                CargarDepartamentos(cBNombrePaisP.SelectedValue.ToString());
            //tBCodigoProvincia.ReadOnly = false;
            tBNombreProvincia.ReadOnly = false;

            cBNombrePaisP.Text = "";
            cBDepartamentoN.Text = "";
            tBCodigoProvincia.Text = "";
            tBNombreProvincia.Text = "";

            CodigoProvincia = qtFuncionesSistemas.GenerarCodigoProvincia(cBNombrePaisP.SelectedValue.ToString(), cBDepartamentoN.SelectedValue != null ? cBDepartamentoN.SelectedValue.ToString() : null);
            tBCodigoProvincia.Text = String.IsNullOrEmpty(CodigoProvincia) ? String.Empty : CodigoProvincia;
            tBNombreProvincia.Focus();
        }

        private void bEditarP_Click(object sender, EventArgs e)
        {
            bCancelarP.Enabled = true;
            bAceptarP.Enabled = true;
            TipoOperacion = "A";

            //tBCodigoProvincia.ReadOnly = true;
            tBNombreProvincia.ReadOnly = false;
        }

        private void bEliminarP_Click(object sender, EventArgs e)
        {
            string mensaje = "Esta Seguro de Eliminar" + tBNombreProvincia.Text;
            string caption = "Eliminar";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult Resultado;
            Resultado = MessageBox.Show(mensaje, caption, botones);
            if (Resultado == DialogResult.OK)
            {
                Provincias.Delete(cBNombrePaisP.SelectedValue.ToString(), cBDepartamentoN.SelectedValue.ToString(), tBCodigoProvincia.Text);
                tBCodigoProvincia.ReadOnly = true;
                tBNombreProvincia.ReadOnly = true;

                tBCodigoProvincia.Text = "";
                tBNombreProvincia.Text = "";
            }
            else
                tPProvincias.Show();

        }

        private void bAceptarP_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
            {
                if (cBNombrePaisP.SelectedValue.ToString() == "00")
                {
                    MessageBox.Show("Debe Seleccionar un País");
                }
                if (tBCodigoProvincia.Text == "")
                {
                    MessageBox.Show("Debe Ingresar el código de la Provincia");
                }
                if (tBNombreProvincia.Text == "")
                {
                    MessageBox.Show("Debe Ingresar un nombre para la Provincia");
                }

                else
                {
                    try
                    {
                        Provincias.Insert(cBNombrePaisP.SelectedValue.ToString(), cBDepartamentoN.SelectedValue.ToString(), tBCodigoProvincia.Text, tBNombreProvincia.Text);
                        CodigoProvincia = tBCodigoProvincia.Text;

                        DataTable DTProvincias = cBNombreProvinciaL.DataSource as DataTable;
                        if (DTProvincias != null)
                        {
                            DTProvincias.Rows.Add(new object[] { cBNombrePaisP.SelectedValue.ToString(), cBDepartamentoN.SelectedValue.ToString(), tBCodigoProvincia.Text, tBNombreProvincia.Text});
                            DTProvincias.AcceptChanges();
                            DTProvincias.DefaultView.Sort = "NombreProvincia ASC";
                            cBNombrePaisL.SelectedValue = cBNombrePaisP.SelectedValue;
                            cBNombreDepartamentoL.SelectedValue = cBDepartamentoN.SelectedValue;
                            cBNombreProvinciaL.SelectedValue = tBCodigoProvincia.Text;
                        }

                        MessageBox.Show("Ingreso Satisfactorio");
                        if (soloInsertarEditar)
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Datos Incorrectos");
                    }

                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Debe Seleccionar un Departamento");
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Ya existe la Provincia" + tBNombreProvincia.Text + " No se pudo Insertar la Provincia");
                    }
                }

                tBCodigoProvincia.ReadOnly = true;
                tBNombreProvincia.ReadOnly = true;
            }
            else
            {
                if (TipoOperacion == "A")
                {
                    if (tBNombreProvincia.Text == "")
                    {
                        MessageBox.Show("Debe Ingresar un nombre para la Provincia");
                    }
                    else
                    {
                        try
                        {
                            Provincias.ActualizarProvincia(cBNombrePaisP.SelectedValue.ToString(), cBDepartamentoN.SelectedValue.ToString(), tBCodigoProvincia.Text, tBNombreProvincia.Text);
                            MessageBox.Show("Actualizacion Satisfactoria");
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("No se pudo Actualizar");
                        }
                    }

                    tBCodigoProvincia.ReadOnly = true;
                    tBNombreProvincia.ReadOnly = true;
                }
            }
            bCancelarP.Enabled = false;
            bAceptarP.Enabled = false;
        }

        private void bCancelarP_Click(object sender, EventArgs e)
        {
            tPProvincias.Show();
            tBCodigoProvincia.ReadOnly = true;
            tBNombreProvincia.ReadOnly = true;
            bCancelarP.Enabled = false;
            bAceptarP.Enabled = false;
            cBNombrePaisP.Enabled = false;
            cBDepartamentoN.Enabled = false;
        }

        private void SalirP_Click(object sender, EventArgs e)
        {
            Close();
        }

        // botones de Localidades
        private void bNuevoL_Click(object sender, EventArgs e)
        {
            cBNombrePaisL.Enabled = true;
            cBNombreDepartamentoL.Enabled = true;
            cBNombreProvinciaL.Enabled = true;
            bCancelarL.Enabled = true;
            bAceptarL.Enabled = true;
            bEliminarL.Enabled = true;
            bEliminarL.Enabled = true;
            TipoOperacion = "I";
            if (cargarAutomaticamente)
            {
                CargarDepartamentosL(cBNombrePaisL.SelectedValue.ToString());
                CargarProvincias(cBNombrePaisL.SelectedValue.ToString(), cBNombreDepartamentoL.SelectedValue == null ? null : cBNombreDepartamentoL.SelectedValue.ToString());
            }
            //tBCodigoLugar.ReadOnly = false;
            tBNombreLugar.ReadOnly = false;

            cBNombrePaisL.Text = "";
            cBNombreDepartamentoL.Text = "";
            cBNombreProvinciaL.Text = "";
            tBCodigoLugar.Text = "";
            tBNombreLugar.Text = "";

            CodigoLugar = qtFuncionesSistemas.GenerarCodigoLugar(cBNombrePaisL.SelectedValue.ToString(), cBNombreDepartamentoL.SelectedValue != null ? cBNombreDepartamentoL.SelectedValue.ToString() : null, cBNombreProvinciaL.SelectedValue != null ? cBNombreProvinciaL.SelectedValue.ToString() : null);
            tBCodigoLugar.Text = String.IsNullOrEmpty(CodigoLugar) ? String.Empty : CodigoLugar;
            tBNombreLugar.Focus();
        }

        private void bEditarL_Click(object sender, EventArgs e)
        {
            bCancelarL.Enabled = true;
            bAceptarL.Enabled = true;
            TipoOperacion = "A";

            //tBCodigoLugar.ReadOnly = true;
            tBNombreLugar.ReadOnly = false;
        }

        private void bEliminarL_Click(object sender, EventArgs e)
        {
            string mensaje = "Esta Seguro de Eliminar" + tBNombreLugar.Text;
            string caption = "Eliminar";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult Resultado;
            Resultado = MessageBox.Show(mensaje, caption, botones);
            if (Resultado == DialogResult.OK)
            {
                Localidades.Delete(cBNombrePaisL.SelectedValue.ToString(), cBNombreDepartamentoL.SelectedValue.ToString(), cBNombreProvinciaL.SelectedValue.ToString(), tBCodigoLugar.Text);
                tBCodigoLugar.ReadOnly = true;
                tBNombreLugar.ReadOnly = true;

                tBCodigoLugar.Text = "";
                tBNombreLugar.Text = "";

            }
            else
                tPLugares.Show();

        }

        private void bAceptarL_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
            {
                if (cBNombrePaisL.SelectedValue.ToString() == "00")
                {
                    MessageBox.Show("Debe Seleccionar un País");
                }
                if (tBCodigoLugar.Text == "")
                {
                    MessageBox.Show("Debe Ingresar el Código del Lugar");
                }
                if (tBNombreLugar.Text == "")
                {
                    MessageBox.Show("Debe Ingresar un nombre para la Provincia");
                }
                else
                {
                    try
                    {
                        Localidades.Insert(cBNombrePaisL.SelectedValue.ToString(), cBNombreDepartamentoL.SelectedValue.ToString(), cBNombreProvinciaL.SelectedValue.ToString(), tBCodigoLugar.Text, tBNombreLugar.Text);
                        CodigoLugar = tBCodigoLugar.Text;
                        MessageBox.Show("Ingreso Satisfactorio");
                        if (soloInsertarEditar)
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Datos erróneos");
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Debe selecionar un Departamento y una Provincia");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ya existe el Lugar" + tBNombreProvincia.Text + " No se pudo Insertar el Lugar!!!");
                    }
                }

                tBCodigoLugar.ReadOnly = true;
                tBNombreLugar.ReadOnly = true;
            }
            else
            {
                if (TipoOperacion == "A")
                {
                    if (tBNombreLugar.Text == "")
                    {
                        MessageBox.Show("Debe Ingresar un nombre para el Lugar");
                    }
                    else
                    {
                        try
                        {
                            Localidades.ActualizarLocalidad(cBNombrePaisL.SelectedValue.ToString(), cBNombreDepartamentoL.SelectedValue.ToString(), cBNombreProvinciaL.SelectedValue.ToString(), tBCodigoLugar.Text, tBNombreLugar.Text);
                            MessageBox.Show("Actualización Satisfactoria");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se pudo Actualizar");
                        }
                    }

                    tBCodigoLugar.ReadOnly = true;
                    tBNombreLugar.ReadOnly = true;
                }

            }
            bCancelarL.Enabled = false;
            bAceptarL.Enabled = false;
        }

        private void bCancelarL_Click(object sender, EventArgs e)
        {
            tPLugares.Show();
            tBCodigoLugar.ReadOnly = true;
            tBNombreLugar.ReadOnly = true;
            bCancelarL.Enabled = false;
            bAceptarL.Enabled = false;
            cBNombrePaisL.Enabled = false;
            cBNombreDepartamentoL.Enabled = false;
            cBNombreProvinciaL.Enabled = false;
        }

        private void SalirL_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tBCodigoPais_TextChanged(object sender, EventArgs e)
        {
            tBCodigoPais.MaxLength = 2;
        }

        private void tBCodigoDepartamento_TextChanged(object sender, EventArgs e)
        {
            tBCodigoDepartamento.MaxLength = 2;
        }

        private void tBCodigoProvincia_TextChanged(object sender, EventArgs e)
        {
            tBCodigoProvincia.MaxLength = 2;
        }

        private void tBCodigoLugar_TextChanged(object sender, EventArgs e)
        {
            tBCodigoLugar.MaxLength = 2;
        }

        private void bBuscarPais_Click(object sender, EventArgs e)
        {
            bEditar.Enabled = true;
            bEliminar.Enabled = true;            
            fBuscarRegion.TipoBusquedaRegion = "P";
            if (fBuscarRegion.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                DSTrabajo_Social.BuscarRegionGeograficoRow DRRegionEncontrada = fBuscarRegion.DRBuscarRegionGeografico;
                tBCodigoPais.Text = DRRegionEncontrada.CodigoPais;
                tBNombrePais.Text = DRRegionEncontrada.NombreRegion;
                tBNacionalidad.Text = String.Empty;
            }
            

        }

        private void bBuscarDep_Click(object sender, EventArgs e)
        {
            bEditarD.Enabled = true;
            bEliminarD.Enabled = true;
            fBuscarRegion.TipoBusquedaRegion= "D";            
            if (fBuscarRegion.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                DSTrabajo_Social.BuscarRegionGeograficoRow DRRegionEncontrada = fBuscarRegion.DRBuscarRegionGeografico;
                cBNombrePais.SelectedValue = DRRegionEncontrada.CodigoPais;
                tBCodigoDepartamento.Text = DRRegionEncontrada.CodigoDepartamento;
                tBNombreDepartamento.Text = DRRegionEncontrada.NombreRegion;
            }            
        }

        private void bBuscarProv_Click(object sender, EventArgs e)
        {
            bEditarP.Enabled = true;
            bEliminarP.Enabled = true;
            fBuscarRegion.TipoBusquedaRegion = "R";
            if (fBuscarRegion.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                DSTrabajo_Social.BuscarRegionGeograficoRow DRRegionEncontrada = fBuscarRegion.DRBuscarRegionGeografico;
                cBNombrePaisP.SelectedValue = DRRegionEncontrada.CodigoPais;
                cBDepartamentoN.SelectedValue = DRRegionEncontrada.CodigoDepartamento;
                tBCodigoProvincia.Text = DRRegionEncontrada.CodigoProvincia;
                tBNombreProvincia.Text = DRRegionEncontrada.NombreRegion;
            }
        }

        private void bBuscarLugar_Click(object sender, EventArgs e)
        {
            bEditarL.Enabled = true;
            bEliminarL.Enabled = true;            
            fBuscarRegion.TipoBusquedaRegion = "L";
            if (fBuscarRegion.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                DSTrabajo_Social.BuscarRegionGeograficoRow DRRegionEncontrada = fBuscarRegion.DRBuscarRegionGeografico;
                cBNombrePaisL.SelectedValue = DRRegionEncontrada.CodigoPais;
                cBNombreDepartamentoL.SelectedValue = DRRegionEncontrada.CodigoDepartamento;
                cBNombreProvinciaL.SelectedValue = DRRegionEncontrada.CodigoProvincia;
                tBCodigoLugar.Text = DRRegionEncontrada.CodigoLocalidad;
                tBNombreLugar.Text = DRRegionEncontrada.NombreRegion;
            }

        }

        public void seleccionarPestaniaPais()
        {
            tabControl1.SelectedTab = tPPaises;
            tabControl1.Controls[0].Enabled = true;
            tabControl1.Controls[1].Enabled = false;
            tabControl1.Controls[2].Enabled = false;
            tabControl1.Controls[3].Enabled = false;
        }

        public void seleccionarPestaniaDepartamento()
        {
            tabControl1.SelectedTab = tPDepartamentos;
            tabControl1.Controls[0].Enabled = false;
            tabControl1.Controls[1].Enabled = true;
            tabControl1.Controls[2].Enabled = false;
            tabControl1.Controls[3].Enabled = false;
        }

        public void seleccionarPestaniaProvincia()
        {
            tabControl1.SelectedTab = tPProvincias;
            tabControl1.Controls[0].Enabled = false;
            tabControl1.Controls[1].Enabled = false;
            tabControl1.Controls[2].Enabled = true;
            tabControl1.Controls[3].Enabled = false;
        }

        public void seleccionarPestaniaLugar()
        {
            tabControl1.SelectedTab = tPLugares;
            tabControl1.Controls[0].Enabled = false;
            tabControl1.Controls[1].Enabled = false;
            tabControl1.Controls[2].Enabled = false;
            tabControl1.Controls[3].Enabled = true;
        }

        private void cBNombrePais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bAceptarD.Enabled && TipoOperacion == "I")
            {
                CodigoDepartamento = qtFuncionesSistemas.GenerarCodigoDepartamento(cBNombrePais.SelectedValue.ToString());
                tBCodigoDepartamento.Text = String.IsNullOrEmpty(CodigoDepartamento) ? String.Empty : CodigoDepartamento;
            }
        }

        private void cBDepartamentoN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bAceptarP.Enabled && TipoOperacion == "I")
            {
                CodigoProvincia = qtFuncionesSistemas.GenerarCodigoProvincia(cBNombrePaisP.SelectedValue.ToString(), cBDepartamentoN.SelectedValue != null ? cBDepartamentoN.SelectedValue.ToString() : null);
                tBCodigoProvincia.Text = String.IsNullOrEmpty(CodigoProvincia) ? String.Empty : CodigoProvincia;
            }
        }

        private void cBNombreProvinciaL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bAceptarL.Enabled && TipoOperacion == "I")
            {
                CodigoLugar = qtFuncionesSistemas.GenerarCodigoLugar(cBNombrePaisL.SelectedValue.ToString(), cBNombreDepartamentoL.SelectedValue != null ? cBNombreDepartamentoL.SelectedValue.ToString() : null, cBNombreProvinciaL.SelectedValue != null ? cBNombreProvinciaL.SelectedValue.ToString() : null);
                tBCodigoLugar.Text = String.IsNullOrEmpty(CodigoLugar) ? String.Empty : CodigoLugar;
            }
        }

        public void seleccionarPais(string CodigoPais)
        {
            cBNombrePais.SelectedValue = CodigoPais;            
        }

        public void seleccionarPaisDepartamento(string CodigoPais, string CodigoDepartamento)
        {
            cBNombrePaisP.SelectedValue = CodigoPais;
            if(!String.IsNullOrEmpty(CodigoDepartamento))
                cBDepartamentoN.SelectedValue = CodigoDepartamento;
        }

        public void seleccionarPaisDepartamentoProvincia(string CodigoPais, string CodigoDepartamento, string CodigoProvincia)
        {
            cBNombrePaisL.SelectedValue = CodigoPais;
            if (!String.IsNullOrEmpty(CodigoDepartamento))
                cBNombreDepartamentoL.SelectedValue = CodigoDepartamento;
            if (!String.IsNullOrEmpty(CodigoProvincia))
                cBNombreProvinciaL.SelectedValue = CodigoProvincia;
        }
    }
}
