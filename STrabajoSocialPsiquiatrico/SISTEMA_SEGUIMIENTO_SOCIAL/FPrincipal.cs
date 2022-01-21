using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    public partial class FPrincipal : Form
    {
        string NombreUsuario;
        int CodigoUsuario;
        SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_SocialTableAdapters.QTAFuncionesSistema TAFuncionesSistema = new DSTrabajo_SocialTableAdapters.QTAFuncionesSistema();
        SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_SocialTableAdapters.UsuariosTableAdapter TAUsuarios = new DSTrabajo_SocialTableAdapters.UsuariosTableAdapter();
        public FPrincipal()
        {
            FAutenticación formAutenticacion = new FAutenticación();
            if (formAutenticacion.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
                return;
            }
            NombreUsuario = formAutenticacion.NombreUsuario;
            CodigoUsuario = formAutenticacion.CodigoUsuario.Value;
            formAutenticacion.Dispose();
            InitializeComponent();
            restaurarCopiaDeSeguridadToolStripMenuItem.Visible = false;
            
            SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_Social.UsuariosDataTable DTUsuario = TAUsuarios.GetDataByTrabajadorSocial();
            SISTEMA_SEGUIMIENTO_SOCIAL.DSTrabajo_Social.UsuariosRow DRUsuario = DTUsuario.FindByCodigoUsuario(CodigoUsuario);
            if (DRUsuario != null)
            {
                this.Text = this.Text + "(Usuario :" + DRUsuario["NombreCompleto"].ToString() + ", Cargo: TRABAJADORA SOCIAL)";
            }
            else
            {
                this.Text = this.Text + "(Usuario :" + NombreUsuario + ", Cargo: ADMINISTRADOR)";
            }
        }



        private void BTValoraciónSocioeconómica_Click(object sender, EventArgs e)
        {
            FRegistroPacientesExternos formValoracionSocioeconomica = new FRegistroPacientesExternos();
            formValoracionSocioeconomica.Visible = false;
            formValoracionSocioeconomica.ShowDialog();
            formValoracionSocioeconomica.Dispose();
        }

        private void BTFichaSocial_Click(object sender, EventArgs e)
        {
            FFichaSocial formFichaSocial = new FFichaSocial(CodigoUsuario);
            formFichaSocial.Visible = false;
            formFichaSocial.ShowDialog();
            formFichaSocial.Dispose();
        }

        private void BTReingreso_Click(object sender, EventArgs e)
        {
            FReingreso formReingreso = new FReingreso(CodigoUsuario);
            formReingreso.Visible = false;
            formReingreso.ShowDialog();
            formReingreso.Dispose();
        }

        private void BTReferencia_Click(object sender, EventArgs e)
        {
            FReferencia formReferencia = new FReferencia(1);
            formReferencia.Visible = false;
            formReferencia.ShowDialog();
            formReferencia.Dispose();
         }

        private void BTContrarreferencia_Click(object sender, EventArgs e)
        {
            FContrarreferencia formContrarreferencia = new FContrarreferencia();
            formContrarreferencia.Visible = false;
            formContrarreferencia.ShowDialog();
            //formContrarreferencia.Dispose();
        }

        private void BTInterconsulta_Click(object sender, EventArgs e)
        {
            
        }

       /* private void seguimientoSocialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSeguimientoSocial formSeguimientoSocial = new FSeguimientoSocial();
            formSeguimientoSocial.Visible = false;
            formSeguimientoSocial.ShowDialog();
            formSeguimientoSocial.Dispose();
            FSeguimientoSocial f20 = new FSeguimientoSocial();
            f20.Show();
        }
        */
        private void BTKardex_Click(object sender, EventArgs e)
        {
            FKardex f21 = new FKardex();
            f21.Show();
        }

        
        private void reciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            FPagoServicio formPagoServicio = new FPagoServicio();
            formPagoServicio.ShowDialog();
            formPagoServicio.Dispose();
        }

                
        private void valoraciónSocioeconómicaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRegistroPacientesExternos f3 = new FRegistroPacientesExternos();
            f3.Show();
        }

        private void fichaSocialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FFichaSocial f4 = new FFichaSocial(CodigoUsuario);
            f4.Show();
        }

       /* private void informeSocialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSeguimientoSocial f20 = new FSeguimientoSocial();
            f20.Show();
        }*/

        private void informeSocialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FInformeSocial f24 = new FInformeSocial();
            f24.Show();
        }

        private void registroDeReingresoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FReingreso f13 = new FReingreso(CodigoUsuario);
            f13.Show();
        }

        private void registroDeReferenciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FReferencia f5 = new FReferencia(1);
            f5.Show();
        }

        private void registroDeContrarreferenciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FContrarreferencia f9 = new FContrarreferencia();
            f9.Show();
        }


        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FKardex f21 = new FKardex();
            f21.Show();
        }
       
        private void btnSeguimientoSocial_Click(object sender, EventArgs e)
        {
            FRegistroActividadesDiariasPacientes f20 = new FRegistroActividadesDiariasPacientes();
            f20.Show();
        }

        private void btnInformeSocial_Click(object sender, EventArgs e)
        {
          
            FInformeSocial formInformeSocial = new FInformeSocial();
            formInformeSocial.Visible = false;
            formInformeSocial.ShowDialog();
            formInformeSocial.Dispose();
        }

       
        private void btnSeguimientoAnual_Click_1(object sender, EventArgs e)
        {
            FSeguimientoServicioSocial seguimientoanual = new FSeguimientoServicioSocial();
            seguimientoanual.Show();
        }

        private void btnActividadesDiarias_Click(object sender, EventArgs e)
        {
            FRegistroActividadeDiariasAdministrativas actividaddiaria = new FRegistroActividadeDiariasAdministrativas();
            actividaddiaria.Show();
        }

        private void salirToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void gestionDeUsuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FGestionarUsuarios formUsuarios = new FGestionarUsuarios();
            formUsuarios.ShowDialog();
            formUsuarios.Dispose();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCambiarContraseña formCambiarContrasenia = new FCambiarContraseña(CodigoUsuario, NombreUsuario);
            formCambiarContrasenia.ShowDialog();
            formCambiarContrasenia.Dispose();
        }

        private void tiposDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAñadirDocumentosTipo formDocumentosTipos = new FAñadirDocumentosTipo();
            formDocumentosTipos.Visible = false;
            formDocumentosTipos.ShowDialog();
            formDocumentosTipos.Dispose();
        }

        private void administracionDePreguntasValSocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAñadirPreguntaValoración formPreguntas = new FAñadirPreguntaValoración();
            formPreguntas.Visible = false;
            formPreguntas.ShowDialog();
            formPreguntas.Dispose();
        }

      

        private void nacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            fgeografico.seleccionarPestaniaPais();
            fgeografico.Visible = false;
            fgeografico.ShowDialog();
            fgeografico.Dispose();
        }

        private void departamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            fgeografico.seleccionarPestaniaDepartamento();
            fgeografico.Visible = false;
            fgeografico.ShowDialog();
            fgeografico.Dispose();
        }

        private void provinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            fgeografico.seleccionarPestaniaProvincia();
            fgeografico.Visible = false;
            fgeografico.ShowDialog();
            fgeografico.Dispose();
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            fgeografico.seleccionarPestaniaLugar();
            fgeografico.Visible = false;
            fgeografico.ShowDialog();
            fgeografico.Dispose();
        }

        private void tiposDeActividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAñadirActividadesTipo formActividadesTipo = new FAñadirActividadesTipo();
            formActividadesTipo.Visible = false;
            formActividadesTipo.ShowDialog();
            formActividadesTipo.Dispose();
        }

       /* private void trabajadorSocialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAñadirDatosPersona formTrabajadorSocial = new FAñadirDatosPersona();
            formTrabajadorSocial.Visible = false;
            formTrabajadorSocial.ShowDialog();
            formTrabajadorSocial.Dispose();

        }*/

        /*private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAñadirServicioBrindado formServicios = new FAñadirServicioBrindado();
            formServicios.Visible = false;
            formServicios.ShowDialog();
            formServicios.Dispose();
        }
        */
        /*private void unidadesMedicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAñadirInstitución formUnidadesMedicas = new FAñadirInstitución();
            formUnidadesMedicas.Visible = false;
            formUnidadesMedicas.ShowDialog();
            formUnidadesMedicas.Dispose();
        }*/

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            FBusquedaPacientes formbuscar = new FBusquedaPacientes();
            formbuscar.btnSubvencionFichaAtencion.Visible = true;
            formbuscar.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //FPapeletaPago formPapeleta = new FPapeletaPago();
            //formPapeleta.ShowDialog();
            //formPapeleta.Dispose();

            FPagoServicio formPagoServicio = new FPagoServicio();
            formPagoServicio.ShowDialog();
            formPagoServicio.Dispose();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage5)
            {
                gestionDeUsuariosToolStripMenuItem1_Click(gestionDeUsuariosToolStripMenuItem, e);
            }
        }

        private void copiaDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se encuentra seguro de realizar una Copia de Seguridad de la Base de Datos?", "Copia de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {

                SaveFileDialog ofdArchivo = new SaveFileDialog();
                if (ofdArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //string archivo = ofdArchivo.FileName;
                    
                    DSTrabajo_SocialTableAdapters.QTAFuncionesSistema TAFunciones = new DSTrabajo_SocialTableAdapters.QTAFuncionesSistema();
                    //TAFunciones.CrearBackup(Application.StartupPath + "\\Backup");
                    TAFunciones.CrearBackup(ofdArchivo.FileName);


                    MessageBox.Show("Se Realizo Correctamente la copia de seguridad en el directorio " + Application.StartupPath + "\\Backup", "Copia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio la siguiente Excepcion " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void restaurarCopiaDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileBackup = new OpenFileDialog();
            openFileBackup.Title = "Seleccione el Archivo de Respaldo(Backup Base de Datos)";
            openFileBackup.FileName = "Backup Archivo de Respaldo";

            if (openFileBackup.ShowDialog(this) == DialogResult.OK)
            {

                if (!System.IO.File.Exists(openFileBackup.FileName))
                {
                    MessageBox.Show(this, "El Archivo que desea restaurar no existe", "Restauración de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {                    
                    DSTrabajo_SocialTableAdapters.UsuariosTableAdapter TAUsuarios = new DSTrabajo_SocialTableAdapters.UsuariosTableAdapter();
                    System.Data.SqlClient.SqlConnection sqlConnection = TAUsuarios.Connection;                    
                    string consultaSQL = @"RESTORE DATABASE [TRABAJO_SOCIAL] FROM  DISK = '" + openFileBackup.FileName + @"' WITH  FILE = 1, NOUNLOAD, REPLACE, STATS = 10";

                    System.Data.SqlClient.SqlCommand comand = new System.Data.SqlClient.SqlCommand(consultaSQL, sqlConnection);
                    comand.ExecuteNonQuery();
                    MessageBox.Show("Restauración Correcta");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se Pudo Restaurar Correctamente, seguramente no tiene los permisos suficientes. Ocurrió la siguiente excepción " + ex.Message);
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            FRepIngresosAltasReingresos ingresosaltasreingresos = new FRepIngresosAltasReingresos();
            ingresosaltasreingresos.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FRepAdmisionPacientes admisionpacientes = new FRepAdmisionPacientes();
            admisionpacientes.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FRepUbicacionPacHospitalizados pacienteshospitalizados = new FRepUbicacionPacHospitalizados();
            pacienteshospitalizados.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FRepInterconsultaRealizada interconsultarealizada = new FRepInterconsultaRealizada();
            interconsultarealizada.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            FRepInformeSocial informesocial = new FRepInformeSocial();
            informesocial.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            FRepActividadesDiarias actividadesdiarias = new FRepActividadesDiarias();
            actividadesdiarias.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            //FRepValoracionSocioeconomica valoracionsocioeconomica = new FRepValoracionSocioeconomica();
            //valoracionsocioeconomica.Show();
            FRepServiciosBrindados formValoracion = new FRepServiciosBrindados();
            formValoracion.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            FRepPacientesExternos pacienteexterno = new FRepPacientesExternos();
            pacienteexterno.Show();
        }

        private void administracionDeCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAñadirCategoria añadircategoria = new FAñadirCategoria();
            añadircategoria.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            FRepPacientesTipoDiscapacidad pacientetipodiscapacidad = new FRepPacientesTipoDiscapacidad();
            pacientetipodiscapacidad.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            FRepPacientesInstitucionalizados pacientesinstitucionalizados = new FRepPacientesInstitucionalizados();
            pacientesinstitucionalizados.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            FRepDocumentoPaciente documentopaciente = new FRepDocumentoPaciente();
            documentopaciente.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            FRepPacientesRecibieronEncomienda pacientesrecibieronencomienda = new FRepPacientesRecibieronEncomienda();
            pacientesrecibieronencomienda.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            FRepListadoPacientesFallecidos pacientesfallecidos = new FRepListadoPacientesFallecidos();
            pacientesfallecidos.Show();
        }

        private void archivoToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void actividadesDiariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRepActividadesDiarias formReportes = new FRepActividadesDiarias();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void admisiónDePacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRepAdmisionPacientes formReportes = new FRepAdmisionPacientes();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void documentosPacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formReportes = new FRepDocumentoPaciente();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void seguimientoSocialToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //Form formReportes = new FRep();
            //formReportes.ShowDialog();
            //formReportes.Dispose();
        }

        private void informeSocialToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form formReportes = new FRepInformeSocial();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void ingresosAltasYReingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formReportes = new FRepIngresosAltasReingresos();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void interconsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formReportes = new FRepInterconsultaRealizada();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void pacientesExternosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formReportes = new FRepPacientesExternos();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void pacientesInstitucionalizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formReportes = new FRepPacientesTipoDiscapacidad();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void valoracionSocioEconómicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formReportes = new FRepServiciosBrindados();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void pacientesInstitucionalizadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form formReportes = new FRepPacientesInstitucionalizados();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void encomiendasRecibidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formReportes = new FRepPacientesRecibieronEncomienda();
            formReportes.ShowDialog();
            formReportes.Dispose();
            
        }

        private void pacientesFallecidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formReportes = new FRepListadoPacientesFallecidos();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void evacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formReportes = new FRepFugasEvasiones();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void geográficoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      /*  private void procedenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            fgeografico.Visible = false;
            fgeografico.ShowDialog();
            fgeografico.Dispose();
        }*/

      /*  private void trabajadorSocialToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FAñadirDatosPersona formTrabajadorSocial = new FAñadirDatosPersona();
            formTrabajadorSocial.Visible = false;
            formTrabajadorSocial.ShowDialog();
            formTrabajadorSocial.Dispose();
        }*/

        /*private void serviciosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FAñadirInstitución formUnidadesMedicas = new FAñadirInstitución();
            formUnidadesMedicas.Visible = false;
            formUnidadesMedicas.ShowDialog();
            formUnidadesMedicas.Dispose(); 
            
        }*/

        private void tiposDeActividadesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FAñadirServicioSolicitado formEspecialidad = new FAñadirServicioSolicitado();
            formEspecialidad.Visible = false;
            formEspecialidad.ShowDialog();
            formEspecialidad.Dispose();


        }

        private void tiposDeDocumentosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            FAñadirServicioBrindado formServicios = new FAñadirServicioBrindado();
            formServicios.Visible = false;
            formServicios.ShowDialog();
            formServicios.Dispose();

        }

        private void administraciónDePregYRespDeValSocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAñadirActividadesTipo formActividadesTipo = new FAñadirActividadesTipo();
            formActividadesTipo.Visible = false;
            formActividadesTipo.ShowDialog();
            formActividadesTipo.Dispose();
        }

        private void administraciónDePregYRespDeValSocToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FAñadirDocumentosTipo formDocumentosTipos = new FAñadirDocumentosTipo();
            formDocumentosTipos.Visible = false;
            formDocumentosTipos.ShowDialog();
            formDocumentosTipos.Dispose();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAñadirPreguntaValoración formPreguntas = new FAñadirPreguntaValoración();
            formPreguntas.Visible = false;
            formPreguntas.ShowDialog();
            formPreguntas.Dispose();   
        }

        private void registroDiarioDeActividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRegistroActividadeDiariasAdministrativas formActividadDiaria = new FRegistroActividadeDiariasAdministrativas();
            formActividadDiaria.Visible = false;
            formActividadDiaria.ShowDialog();
            formActividadDiaria.Dispose(); 
        }

        private void seguimientoSocialDeServicioSocialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSeguimientoServicioSocial formSeguimientoAnual = new FSeguimientoServicioSocial();
            formSeguimientoAnual.Visible = false;
            formSeguimientoAnual.ShowDialog();
            formSeguimientoAnual.Dispose(); 
        }

       /* private void subvenciónDeTrabajoSocialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FPapeletaPago formPapeletaPago = new FPapeletaPago();
            formPapeletaPago.Visible = false;
            formPapeletaPago.ShowDialog();
            formPapeletaPago.Dispose(); 
        }
        */
        private void kardexToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FKardex formKardex = new FKardex();
            formKardex.Visible = false;
            formKardex.ShowDialog();
            formKardex.Dispose(); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ingresosAltasYReingresosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form formReportes = new FRepIngresosAltasReingresos();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void informeDetalladoDePacientesAdmitidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRepAdmisionPacientes formReportes = new FRepAdmisionPacientes();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void ubicaciónDePacientesActualmenteHospializadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRepUbicacionPacHospitalizados formReportes = new FRepUbicacionPacHospitalizados();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void interconsultasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FRepInterconsultaRealizada formReportes = new FRepInterconsultaRealizada();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void pacientesInstitucionalizadosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FRepPacientesInstitucionalizados formReportes = new FRepPacientesInstitucionalizados();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void encomiendasRecibidasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FRepPacientesRecibieronEncomienda formReportes = new FRepPacientesRecibieronEncomienda();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void pacientesFallecidosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FRepListadoPacientesFallecidos formReportes = new FRepListadoPacientesFallecidos();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void evasionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRepFugasEvasiones formReportes = new FRepFugasEvasiones();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void informesSocialeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRepInformeSocial formReportes = new FRepInformeSocial();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void actividadesDiariasRealizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRepActividadesDiarias formReportes = new FRepActividadesDiarias();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void valoraciónSocioeconómicaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FRepServiciosBrindados formReportes = new FRepServiciosBrindados();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void pacientesExternosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FRepPacientesExternos formReportes = new FRepPacientesExternos();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void pacientesConDiscapacidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRepPacientesTipoDiscapacidad formReportes = new FRepPacientesTipoDiscapacidad();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void documentosDePacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRepDocumentoPaciente formReportes = new FRepDocumentoPaciente();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void categoriasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FAñadirCategoria formCategorias = new FAñadirCategoria();
            formCategorias.Visible = false;
            formCategorias.ShowDialog();
            formCategorias.Dispose(); 
        }

        private void parentescoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAñadirParentesco formParentesco = new FAñadirParentesco();
            formParentesco.Visible = false;
            formParentesco.ShowDialog();
            formParentesco.Dispose();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            FRegistroActividadesDiariasPacientes formRegistroActPacientes = new FRegistroActividadesDiariasPacientes();
            formRegistroActPacientes.Visible = false;
            formRegistroActPacientes.ShowDialog();
            formRegistroActPacientes.Dispose();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FRegistroActividadeDiariasAdministrativas formRegistroActAdministrativas = new FRegistroActividadeDiariasAdministrativas();
            formRegistroActAdministrativas.Visible = false;
            formRegistroActAdministrativas.ShowDialog();
            formRegistroActAdministrativas.Dispose();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            FCambiarContraseña formCambiarContrasenia = new FCambiarContraseña(CodigoUsuario, NombreUsuario);
            formCambiarContrasenia.ShowDialog();
            formCambiarContrasenia.Dispose();
        }

        private void gestionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FGestionarUsuarios formUsuarios = new FGestionarUsuarios();
            formUsuarios.ShowDialog();
            formUsuarios.Dispose();
        }

        private void gestiónDeProcedenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestiónDeProcedenciasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            fgeografico.Visible = false;
            fgeografico.ShowDialog();
            fgeografico.Dispose();
        }

        private void gestiónDePersonasReferenciadasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FAñadirDatosPersona formDatosPersona = new FAñadirDatosPersona();
            formDatosPersona.Visible = false;
            formDatosPersona.ShowDialog();
            formDatosPersona.Dispose();

         }

        private void gestiónDeInstitucionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FAñadirInstitución formaAñadirInstitucion = new FAñadirInstitución();
            formaAñadirInstitucion.Visible = false;
            formaAñadirInstitucion.ShowDialog();
            formaAñadirInstitucion.Dispose();

        }

        private void gestiónDeServiciosSolicitadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            FAñadirServicioSolicitado formEspecialidad = new FAñadirServicioSolicitado();
            formEspecialidad.Visible = false;
            formEspecialidad.ShowDialog();
            formEspecialidad.Dispose();

        }

        private void gestiónDeServiciosBrindadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FAñadirServicioBrindado formServicios = new FAñadirServicioBrindado();
            formServicios.Visible = false;
            formServicios.ShowDialog();
            formServicios.Dispose();
        }

        private void gestiónDeTiposDeActividadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FAñadirActividadesTipo formActividadesTipo = new FAñadirActividadesTipo();
            formActividadesTipo.Visible = false;
            formActividadesTipo.ShowDialog();
            formActividadesTipo.Dispose();
        }

        private void gestiónDeTiposDeDocumentosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FAñadirDocumentosTipo formDocumentosTipos = new FAñadirDocumentosTipo();
            formDocumentosTipos.Visible = false;
            formDocumentosTipos.ShowDialog();
            formDocumentosTipos.Dispose();
        }

        private void gestiónDePreguntasYRespuestasSocioeconómicasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FAñadirPreguntaValoración formPreguntas = new FAñadirPreguntaValoración();
            formPreguntas.Visible = false;
            formPreguntas.ShowDialog();
            formPreguntas.Dispose();   
        }

        private void gestiónDeCategoríasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FAñadirCategoria formCategorias = new FAñadirCategoria();
            formCategorias.Visible = false;
            formCategorias.ShowDialog();
            formCategorias.Dispose(); 
        }

        private void gestiónDeParentescosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FAñadirParentesco formParentesco = new FAñadirParentesco();
            formParentesco.Visible = false;
            formParentesco.ShowDialog();
            formParentesco.Dispose();
        }

        private void gestiónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FGestionarUsuarios formUsuarios = new FGestionarUsuarios();
            formUsuarios.ShowDialog();
            formUsuarios.Dispose();
        }

        private void cambiarContraseñaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FCambiarContraseña formCambiarContrasenia = new FCambiarContraseña(CodigoUsuario, NombreUsuario);
            formCambiarContrasenia.ShowDialog();
            formCambiarContrasenia.Dispose();
        }

        private void copiaDeSeguridadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show("Se encuentra seguro de realizar una Copia de Seguridad de la Base de Datos?", "Copia de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                try
                {

                    SaveFileDialog ofdArchivo = new SaveFileDialog();
                    if (ofdArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //string archivo = ofdArchivo.FileName;

                        DSTrabajo_SocialTableAdapters.QTAFuncionesSistema TAFunciones = new DSTrabajo_SocialTableAdapters.QTAFuncionesSistema();
                        //TAFunciones.CrearBackup(Application.StartupPath + "\\Backup");
                        TAFunciones.CrearBackup(ofdArchivo.FileName);


                        MessageBox.Show("Se Realizo Correctamente la copia de seguridad en el directorio " + Application.StartupPath + "\\Backup", "Copia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio la siguiente Excepcion " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void restaurarCopiaDeSeguridadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog openFileBackup = new OpenFileDialog();
                openFileBackup.Title = "Seleccione el Archivo de Respaldo(Backup Base de Datos)";
                openFileBackup.FileName = "Backup Archivo de Respaldo";

                if (openFileBackup.ShowDialog(this) == DialogResult.OK)
                {

                    if (!System.IO.File.Exists(openFileBackup.FileName))
                    {
                        MessageBox.Show(this, "El Archivo que desea restaurar no existe", "Restauración de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    try
                    {
                        DSTrabajo_SocialTableAdapters.UsuariosTableAdapter TAUsuarios = new DSTrabajo_SocialTableAdapters.UsuariosTableAdapter();
                        System.Data.SqlClient.SqlConnection sqlConnection = TAUsuarios.Connection;
                        string consultaSQL = @"RESTORE DATABASE [TRABAJO_SOCIAL] FROM  DISK = '" + openFileBackup.FileName + @"' WITH  FILE = 1, NOUNLOAD, REPLACE, STATS = 10";

                        System.Data.SqlClient.SqlCommand comand = new System.Data.SqlClient.SqlCommand(consultaSQL, sqlConnection);
                        comand.ExecuteNonQuery();
                        MessageBox.Show("Restauración Correcta");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se Pudo Restaurar Correctamente, seguramente no tiene los permisos suficientes. Ocurrió la siguiente excepción " + ex.Message);
                    }
                }
            }
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registrarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FRegistroPacientesExternos formValoracionSocioeconomica = new FRegistroPacientesExternos();
            formValoracionSocioeconomica.Visible = false;
            formValoracionSocioeconomica.ShowDialog();
            formValoracionSocioeconomica.Dispose();
        }

        private void registroDeFichaSocialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FFichaSocial formFichaSocial = new FFichaSocial(CodigoUsuario);
            formFichaSocial.Visible = false;
            formFichaSocial.ShowDialog();
            formFichaSocial.Dispose();
        }

        private void registroDeReingresoToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FReingreso formReingreso = new FReingreso(CodigoUsuario);
            formReingreso.Visible = false;
            formReingreso.ShowDialog();
            formReingreso.Dispose();
        }

        private void registroDeReferenciaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FReferencia formReferencia = new FReferencia(1);
            formReferencia.Visible = false;
            formReferencia.ShowDialog();
            formReferencia.Dispose();
        }

        private void registroDiarioDeActividadesPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRegistroActividadesDiariasPacientes formRegistroActPacientes = new FRegistroActividadesDiariasPacientes();
            formRegistroActPacientes.Visible = false;
            formRegistroActPacientes.ShowDialog();
            formRegistroActPacientes.Dispose();
        }

        private void registroDiarioDeActividadesAdministrativasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRegistroActividadeDiariasAdministrativas formRegistroActAdministrativas = new FRegistroActividadeDiariasAdministrativas();
            formRegistroActAdministrativas.Visible = false;
            formRegistroActAdministrativas.ShowDialog();
            formRegistroActAdministrativas.Dispose();
        }

        private void informeSocialToolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            FInformeSocial formInformeSocial = new FInformeSocial();
            formInformeSocial.Visible = false;
            formInformeSocial.ShowDialog();
            formInformeSocial.Dispose();
        }

        private void seguimientoDeServicioSocialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FSeguimientoServicioSocial formSeguimientoAnual = new FSeguimientoServicioSocial();
            formSeguimientoAnual.Visible = false;
            formSeguimientoAnual.ShowDialog();
            formSeguimientoAnual.Dispose(); 
        }

        private void registroDeServiciosYSubvenciónDeCostosAdmToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FPagoServicio formPapeletaPago = new FPagoServicio();
            formPapeletaPago.Visible = false;
            formPapeletaPago.ShowDialog();
            formPapeletaPago.Dispose(); 
        }

        private void kardexToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FKardex formKardex = new FKardex();
            formKardex.Visible = false;
            formKardex.ShowDialog();
            formKardex.Dispose(); 

        }

        private void ingresosAltasYReingresosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form formReportes = new FRepIngresosAltasReingresos();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void informeDetalladoDePacientesAdmitidosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRepAdmisionPacientes formReportes = new FRepAdmisionPacientes();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void ubicaciónDePacientesHospializadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRepUbicacionPacHospitalizados formReportes = new FRepUbicacionPacHospitalizados();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void interconsultasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRepInterconsultaRealizada formReportes = new FRepInterconsultaRealizada();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void pacientesInstitucionalizadosToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FRepPacientesInstitucionalizados formReportes = new FRepPacientesInstitucionalizados();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void encomiendasRecibidasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRepPacientesRecibieronEncomienda formReportes = new FRepPacientesRecibieronEncomienda();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void pacientesFallecidosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRepListadoPacientesFallecidos formReportes = new FRepListadoPacientesFallecidos();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void evasionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRepFugasEvasiones formReportes = new FRepFugasEvasiones();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void informesSocialesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRepInformeSocial formReportes = new FRepInformeSocial();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void actividadesDiariasRealizadasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRepActividadesDiarias formReportes = new FRepActividadesDiarias();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void valoraciónSocioeconómicaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FRepServiciosBrindados formReportes = new FRepServiciosBrindados();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void pacientesExternosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRepPacientesExternos formReportes = new FRepPacientesExternos();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void pacientesConDiscapacidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRepPacientesTipoDiscapacidad formReportes = new FRepPacientesTipoDiscapacidad();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void documentosDePacientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRepDocumentoPaciente formReportes = new FRepDocumentoPaciente();
            formReportes.ShowDialog();
            formReportes.Dispose();
        }

        private void gestiónDeOcupacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAñadirOcupaciones formOcupaciones = new FAñadirOcupaciones();
            formOcupaciones.ShowDialog();
            formOcupaciones.Dispose();
        }
    }
}
