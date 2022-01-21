using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.ReportesCR;
using CrystalDecisions.Shared;

namespace SISTEMA_SEGUIMIENTO_SOCIAL.Reportes
{
    public partial class FReportePacientesDiscapacitados : FReporteGeneral
    {
        public FReportePacientesDiscapacitados()
        {
            InitializeComponent();
        }

        public void mostrarDatos(DataTable DTPacientes, DateTime FechaInicio, DateTime FechaFin)
        {
            this.fuenteReporteGeneral = new CRPacientesDiscapacitados();
            fuenteReporteGeneral.SetDataSource(DTPacientes);

            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();
            crtParamDiscreteValue.Value = FechaInicio;
            crtParamField.ParameterFieldName = "FechaInicio";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = FechaFin;
            crtParamField.ParameterFieldName = "FechaFin";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            this.CRVReporteGeneralAcceso.ParameterFieldInfo = crtParamFields;
        }
    }
}
