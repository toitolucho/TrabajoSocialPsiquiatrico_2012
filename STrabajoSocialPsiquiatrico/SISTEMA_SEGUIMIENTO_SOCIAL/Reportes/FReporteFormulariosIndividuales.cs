using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.ReportesCR;

namespace SISTEMA_SEGUIMIENTO_SOCIAL.Reportes
{
    public partial class FReporteFormulariosIndividuales : FReporteGeneral
    {
        public FReporteFormulariosIndividuales()
        {
            InitializeComponent();
            this.DSReporteGeneral.Clear();
        }

        public void ListarDatosPacienteReporte(DataTable DTListarDatosPacienteReporte, DataTable DTDocumentos,
            DataTable DTFamiliares, DataTable DTResponsables, DataTable DTPagosServiciosDetalle)
        {
            DTDocumentos.TableName = "Documentos";
            DTFamiliares.TableName = "ObtenerFamiliares";
            DTResponsables.TableName = "ObtenerResponsables";
            this.DSReporteGeneral.Tables.AddRange(new DataTable[]{ DTListarDatosPacienteReporte, DTDocumentos, DTFamiliares, DTResponsables, DTPagosServiciosDetalle });
            fuenteReporteGeneral = new  CRListarDatosPacienteReporte();
            fuenteReporteGeneral.SetDataSource(DSReporteGeneral);
            //this.CRVReporteGeneralAcceso.ReportSource = fuenteReporteGeneral;

            
        }

        public void ListarReingresosReporte(DataTable DTListarDatosPacienteReporte, DataTable DTReingresos,
            DataTable DTResponsables, DataTable DTPagosServiciosDetalle)
        {
            DTResponsables.TableName = "ObtenerResponsables";
            this.DSReporteGeneral.Tables.AddRange(new DataTable[] { DTListarDatosPacienteReporte, DTReingresos, DTResponsables, DTPagosServiciosDetalle });
            fuenteReporteGeneral = new CRListarReingresos();
            fuenteReporteGeneral.SetDataSource(DSReporteGeneral);
            //this.CRVReporteGeneralAcceso.ReportSource = fuenteReporteGeneral;


        }
        public void ListarReferenciaReporte(DataTable DTListarReferenciaReporte, String TipoReferencia)
        {
            this.DSReporteGeneral.Tables.AddRange(new DataTable[] { DTListarReferenciaReporte });
            if(TipoReferencia == "E")
                fuenteReporteGeneral = new CRListarReferencias2 ();
            else
                fuenteReporteGeneral = new CRListarReferenciasContraReferencia();
            fuenteReporteGeneral.SetDataSource(DSReporteGeneral);
        }

        public void ListarPagosServiciosReporte(DataTable DTListarPagosServicios, DataTable DTListarPagosServiciosDetalle, DataTable DTListarValoracionSocioEconomica)
        {
            DTListarValoracionSocioEconomica.TableName = "ListarValoracionSocioEconomicasNombresRespuestas";
            this.DSReporteGeneral.Tables.AddRange(new DataTable[] { DTListarPagosServicios, DTListarPagosServiciosDetalle, DTListarValoracionSocioEconomica });
            fuenteReporteGeneral = new CRListarPagosServicios();
            fuenteReporteGeneral.SetDataSource(DSReporteGeneral);
        }

        public void ListarActividadesReporte(DataTable DTListarActividadesReporte, DataTable DTListarDatosPacienteReporte, 
            DataTable DTResponsables, String TipoActividad,
            String TrabajadoraSocial, DateTime FechaHoraInicio, DateTime FechaHoraFin)
        {
            if(DTResponsables != null)
                DTResponsables.TableName = "ObtenerResponsables";
            this.DSReporteGeneral.Tables.AddRange(new DataTable[] { DTListarActividadesReporte, DTListarDatosPacienteReporte, DTResponsables });
            CargarParametrosRangoFecha(FechaHoraInicio, FechaHoraFin);
            if (TipoActividad == "P")
            {
                fuenteReporteGeneral = new CRListarSeguimientoSocialPaciente();
                AgregarParametro(TrabajadoraSocial, "TrabajadoraSocial");
            }
            else
                fuenteReporteGeneral = new CRListarActividadesAdministrativas();
            fuenteReporteGeneral.SetDataSource(DSReporteGeneral);
            
            
        }


        public void ListarInformeSocialReporte(DataTable DTListarDatosPacienteReporte,
            DataTable DTFamiliares, DataTable DTInformeSocial)
        {
            //DTInformeSocial.TableName = "ObtenerInformeSocial";
            //DTFamiliares.TableName = "ObtenerFamiliares";            
            this.DSReporteGeneral.Tables.AddRange(new DataTable[] { DTListarDatosPacienteReporte, DTFamiliares, DTInformeSocial });
            fuenteReporteGeneral = new CRListarInformeSocialReporte();
            fuenteReporteGeneral.SetDataSource(DSReporteGeneral);
        }

        public void ListarSeguimientoAnualReporte(DataTable DTListarDatosPacienteReporte,
            DataTable DTResponsables, DataTable DTSeguimientoAnual)
        {            
            //DTResponsables.TableName = "ObtenerResponsables";
            //DTSeguimientoAnual.TableName = "SeguimientoAnual";
            this.DSReporteGeneral.Tables.AddRange(new DataTable[] { DTListarDatosPacienteReporte, DTResponsables, DTSeguimientoAnual });
            fuenteReporteGeneral = new CRListarSeguimientoAnualReporte();
            fuenteReporteGeneral.SetDataSource(DSReporteGeneral);
        }
    }
}
