USE PSIQUIATRICO
GO

DROP TRIGGER AltasIA
GO

CREATE TRIGGER AltasIA
ON PSIQUIATRICO.dbo.altas
AFTER INSERT
AS 
BEGIN
	
	DECLARE @NumeroPaciente INT
	
	SELECT @NumeroPaciente = P1.NumeroPaciente
	FROM TRABAJO_SOCIAL.DBO.Pacientes P1
	INNER JOIN INSERTED P2
	ON P1.HClinico = P2.hc
	

	INSERT INTO TRABAJO_SOCIAL.dbo.Actividades (
			CodigoActividad, NumeroPaciente, FechaActividad, 
			CodigoActividadTipo, CodigoUsuario, TipoActividad, Observaciones
			)
	SELECT dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'A')
	FROM INSERTED A
			
	

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
