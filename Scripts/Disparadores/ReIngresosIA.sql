USE PSIQUIATRICO
GO

DROP TRIGGER ReIngresosIA
GO

CREATE TRIGGER ReIngresosIA
ON PSIQUIATRICO.dbo.ReIngresos
AFTER INSERT
AS 
BEGIN
	INSERT INTO  TRABAJO_SOCIAL.dbo.Reingresos (NumeroPaciente, NumeroReingreso,
				 HClinico, FechaReingreso, Unidad, Seccion, Codigo, 
				 Antecedentes, RelacionesFamiliares, PredisTratamiento, 
				 AsignacionMensual, Medicacion, PasajeRetorno, Denominacion, Observaciones)
	SELECT P.NumeroPaciente, RI.Nro_ReIngreso, RI.Hc,  RI.Fecha_ReIngreso,  RI.Unidad, RTRIM(UPPER(RI.seccion)) AS seccion, RI.codigo, 
				NULL, NULL, NULL, 0, NULL, 0, P.Denominacion, NULL
	FROM INSERTED RI
	INNER JOIN PSIQUIATRICO.DBO.Diagnosticos D
	ON RI.codigo = D.codigo
	INNER JOIN TRABAJO_SOCIAL.dbo.Pacientes P
	ON RI.Hc = P.HClinico


END
GO
