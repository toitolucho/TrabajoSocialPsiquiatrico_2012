using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SISTEMA_SEGUIMIENTO_SOCIAL.Reportes
{
    public partial class FReporteGeneral : Form
    {
        protected Button btnCerrar;
        protected ReportClass fuenteReporteGeneral{get;set;}
        protected DataSet DSReporteGeneral { get; set; }
        protected CrystalDecisions.Windows.Forms.CrystalReportViewer CRVReporteGeneralAcceso {
            get { return CRVReporteGeneral; }
        }
        public FReporteGeneral()
        {
            InitializeComponent();
            btnCerrar = new Button();
            btnCerrar.Click += new EventHandler(btnCerrar_Click);
            this.CancelButton = btnCerrar;
            DSReporteGeneral = new DataSet();
        }

        void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void configurarReporteSencillo()
        {
            CRVReporteGeneral.ShowGroupTreeButton = CRVReporteGeneral.ShowParameterPanelButton = CRVReporteGeneral.ShowRefreshButton = false;
            CRVReporteGeneral.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
        }

        public void configurarReporteAgrupacion(bool mostrarPanelAgrupacion)
        {
            CRVReporteGeneral.ShowGroupTreeButton = true;
            CRVReporteGeneral.ShowParameterPanelButton = CRVReporteGeneral.ShowRefreshButton = false;
            CRVReporteGeneral.ToolPanelView = mostrarPanelAgrupacion ? CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree :
                CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
        }

        private void FReporteGeneral_Load(object sender, EventArgs e)
        {
            CRVReporteGeneral.ReportSource = fuenteReporteGeneral;
        }

        public void CargarParametrosRangoFecha(DateTime FechaHoraInicio, DateTime FechaHoraFin)
        {
            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            //------------------Fecha Inicio
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();
            crtParamDiscreteValue.Value = FechaHoraInicio;
            crtParamField.ParameterFieldName = "FechaHoraInicio";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            //------------------Fecha Fin
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = FechaHoraFin;
            crtParamField.ParameterFieldName = "FechaHoraFin";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            this.CRVReporteGeneralAcceso.ParameterFieldInfo = crtParamFields;
        }

        public void AgregarParametro(object ValorParametro, string NombreParametro)
        {
            ParameterField crtParamField;
            ParameterDiscreteValue crtParamDiscreteValue;

            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = ValorParametro;
            crtParamField.ParameterFieldName = NombreParametro;
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            if (this.CRVReporteGeneralAcceso.ParameterFieldInfo == null)
                this.CRVReporteGeneralAcceso.ParameterFieldInfo = new ParameterFields();
            this.CRVReporteGeneralAcceso.ParameterFieldInfo.Add(crtParamField);

        }
    }
}
