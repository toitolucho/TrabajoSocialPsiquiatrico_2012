using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SISTEMA_SEGUIMIENTO_SOCIAL.ReportesCR;
using CrystalDecisions.Shared;

namespace SISTEMA_SEGUIMIENTO_SOCIAL.Reportes
{
    public partial class FReporteDocumentosPacientes : SISTEMA_SEGUIMIENTO_SOCIAL.Reportes.FReporteGeneral
    {
        public FReporteDocumentosPacientes()
        {
            InitializeComponent();
        }

        public void cargarDatos(DataTable DTListarCantidadActividadesTipoPorMes, DateTime FechaInicio, DateTime FechaFin)
        {
            this.fuenteReporteGeneral = new CRPacientesDocumentos();
            fuenteReporteGeneral.SetDataSource(DTListarCantidadActividadesTipoPorMes);

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
