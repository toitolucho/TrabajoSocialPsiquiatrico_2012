USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarHistorialPacienteActividades
GO

CREATE PROCEDURE ListarHistorialPacienteActividades
	@NumeroPaciente		INT,
	@FechaInicio		DATETIME,
	@FechaFin			DATETIME
AS
BEGIN
	DECLARE @ListaDocumentos	VARCHAR(4000)
	SET @ListaDocumentos = ''
	IF(@FechaInicio IS NOT NULL AND @FechaFin IS NOT NULL)
	BEGIN
		SET @FechaInicio = CONVERT(DATETIME, CONVERT(CHAR(10), @FechaInicio ,120),120)
		SET @FechaFin = DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
	END
	ELSE
	BEGIN
		SET @FechaInicio = CONVERT(DATETIME, '01/01/1900',120)
		SET @FechaFin = DATEADD(YEAR, 1, GETDATE())
	END
	
	
	SELECT P.FechaIngreso AS FechaOperacion, P.NumeroPaciente, 'INGRESO' AS TipoHistorial, 
		--CASE WHEN P.PacienteInstitucionalizado = 1 THEN 'PACIENTE INSTITUCIONALIZADO' ELSE '' END AS Observaciones
		'' as Observaciones
	FROM Pacientes P
	WHERE P.FechaIngreso
	BETWEEN @FechaInicio AND @FechaFin
	AND P.NumeroPaciente = @NumeroPaciente
	UNION ALL
	SELECT R.FechaReingreso, R.NumeroPaciente, 'REINGRESO', ''
	FROM Reingresos R
	WHERE R.FechaReingreso
	BETWEEN @FechaInicio AND @FechaFin
	AND R.NumeroPaciente = @NumeroPaciente
	UNION ALL 
	SELECT F.FechaReferencia,  F.NumeroPaciente, 'REFERENCIA', UM.NombreUnidadMedica
	FROM Referencias F
	INNER JOIN dbo.TrabajadoresSociales TS
	ON F.CodigoTrabajadorSocial = TS.CodigoTrabajadorSocial
	INNER JOIN dbo.UnidadesMedicas UM
	ON TS.CodigoUnidadMedica = UM.CodigoUnidadMedica
	WHERE F.FechaReferencia
	BETWEEN @FechaInicio AND @FechaFin
	AND F.NumeroPaciente = @NumeroPaciente
	AND F.NumeroReferencia NOT IN ( SELECT NumeroReferencia FROM dbo.Contrarreferencias) 
	UNION ALL 
	SELECT SS.FechaActividad, SS.NumeroPaciente, 'SEGUIMIENTO SOCIAL', NombreActividad
	FROM dbo.Actividades SS
	INNER JOIN dbo.ActividadesTipo AT
	ON SS.CodigoActividadTipo = AT.CodigoActividadTipo
	WHERE SS.FechaActividad
	BETWEEN @FechaInicio AND @FechaFin
	AND SS.NumeroPaciente = @NumeroPaciente
	UNION ALL 
	SELECT D.FechaRegistro, D.NumeroPaciente, 'DOCUMENTOS', NombreDocumento
	FROM Documentos D
	INNER JOIN dbo.DocumentosTipo DT
	ON D.CodigoDocumentoTipo = DT.CodigoDocumentoTipo
	WHERE D.FechaRegistro
	BETWEEN @FechaInicio AND @FechaFin
	AND D.NumeroPaciente = @NumeroPaciente
	AND D.TramitoTrabSocial = 'S'
	ORDER BY 1
	
	--DECLARE @TDocumentosConcatenados TABLE(
	--		NumeroPaciente	INT,
	--		FechaRegistro	DATETIME,
	--		NombreDocumento VARCHAR(400)
	--	)
	--INSERT INTO @TDocumentosConcatenados
	--EXEC DBO.ObtenerTablaDocumentosHistorialFecha 726, NULL, NULL
	


	--SELECT  TAFechas.FechaOperacion, CASE WHEN TPacientes.FechaIngreso IS NOT NULL THEN 1 ELSE 0 END AS 'Ingreso', 
	--		CASE WHEN TReingresos.FechaReingreso IS NOT NULL THEN 1 ELSE 0 END AS 'Reingreso',
	--		CASE WHEN TPacientes.FechaIngreso IS NOT NULL THEN TPacientes.RelacionesFamiliares WHEN TReingresos.FechaReingreso IS NOT NULL THEN TReingresos.RelacionesFamiliares ELSE '' END AS RelacionesFamiliares, 
	--		CASE WHEN TSSOCIAL.FechaSSocial IS NOT NULL THEN  TSSOCIAL.RecibioEncomienda ELSE 0 END AS RecibioEncomienda, 
	--		CASE WHEN TReferencias.FechaReferencia IS NOT NULL THEN 1 ELSE 0 END AS Interconsultas,
	--		CASE WHEN TPacientes.FechaIngreso IS NOT NULL THEN TPacientes.AsignacionMensual WHEN TReingresos.FechaReingreso IS NOT NULL THEN TReingresos.AsignacionMensual END AS AsignacionMensual, 
	--		CASE WHEN TPacientes.FechaIngreso IS NOT NULL THEN TPacientes.Medicacion WHEN TReingresos.FechaReingreso IS NOT NULL THEN TReingresos.Medicacion END AS Medicacion, 
	--		CASE WHEN TPacientes.FechaIngreso IS NOT NULL THEN TPacientes.PasajeRetorno WHEN TReingresos.FechaReingreso IS NOT NULL THEN TReingresos.PasajeRetorno END AS PasajeRetorno, 
	--		CASE WHEN TPacientes.FechaIngreso IS NOT NULL THEN TPacientes.PacienteInstitucionalizado WHEN TSSOCIAL.FechaSSocial IS NOT NULL THEN TSSOCIAL.PacienteInstitucionalizo END AS PacienteInstitucionalizado,
	--		TDoc.NombreDocumento
	--FROM
	--(
	--	SELECT DISTINCT * 
	--	FROM
	--	(
	--		SELECT CONVERT(DATETIME, CONVERT(CHAR(10),P.FechaIngreso ,120),120)   AS FechaOperacion, P.NumeroPaciente
	--		FROM Pacientes P
	--		WHERE P.FechaIngreso
	--		BETWEEN @FechaInicio AND @FechaFin
	--		AND P.NumeroPaciente = @NumeroPaciente
	--		UNION ALL
	--		SELECT CONVERT(DATETIME, CONVERT(CHAR(10),R.FechaReingreso ,120),120) , R.NumeroPaciente
	--		FROM Reingresos R
	--		WHERE R.FechaReingreso
	--		BETWEEN @FechaInicio AND @FechaFin
	--		AND R.NumeroPaciente = @NumeroPaciente
	--		UNION ALL
	--		SELECT CONVERT(DATETIME, CONVERT(CHAR(10),F.FechaReferencia ,120),120), F.NumeroPaciente
	--		FROM Referencias F
	--		WHERE F.FechaReferencia
	--		BETWEEN @FechaInicio AND @FechaFin
	--		AND F.NumeroPaciente = @NumeroPaciente
	--		UNION ALL
	--		SELECT CONVERT(DATETIME, CONVERT(CHAR(10),SS.FechaSSocial ,120),120), SS.NumeroPaciente
	--		FROM SeguimientosSociales SS
	--		WHERE SS.FechaSSocial
	--		BETWEEN @FechaInicio AND @FechaFin
	--		AND SS.NumeroPaciente = @NumeroPaciente
	--		UNION ALL
	--		SELECT CONVERT(DATETIME, CONVERT(CHAR(10),D.FechaRegistro ,120),120), D.NumeroPaciente
	--		FROM Documentos D
	--		WHERE D.FechaRegistro
	--		BETWEEN @FechaInicio AND @FechaFin
	--		AND D.NumeroPaciente = @NumeroPaciente
	--		and D.TramitoTrabSocial = 'S'
	--	)TA
	--)
	--TAFechas
	--LEFT JOIN 
	--(
	--	SELECT  P.NumeroPaciente, CONVERT(DATETIME, CONVERT(CHAR(10),P.FechaIngreso ,120),120) AS FechaIngreso, 
	--			CASE P.RelacionesFamiliares WHEN 'B' THEN 'BUENA' WHEN 'R'  THEN 'REGULAR' WHEN 'M' THEN 'MALA' END AS RelacionesFamiliares, 
	--			DA.AsignacionMensual, DA.Medicacion, DA.PasajeRetorno, 
	--			CASE WHEN DA.PacienteInstitucionalizado = 'S' THEN 1 ELSE 0 END AS PacienteInstitucionalizado
	--	FROM Pacientes P
	--	LEFT JOIN DatosAdministrativos DA
	--	ON P.NumeroPaciente = DA.NumeroPaciente
	--	WHERE P.FechaIngreso
	--	BETWEEN @FechaInicio AND @FechaFin
	--	AND P.NumeroPaciente = @NumeroPaciente
	--)TPacientes
	--ON TAFechas.FechaOperacion = TPacientes.FechaIngreso
	--AND TAFechas.NumeroPaciente = TPacientes.NumeroPaciente
	--LEFT JOIN
	--(
	--	SELECT	R.NumeroPaciente, CONVERT(DATETIME, CONVERT(CHAR(10),R.FechaReingreso, 120), 120) AS FechaReingreso, 
	--			CASE R.RelacionesFamiliares WHEN 'B' THEN 'BUENA' WHEN 'R'  THEN 'REGULAR' WHEN 'M' THEN 'MALA' END AS RelacionesFamiliares,			
	--			R.AsignacionMensual, R.Medicacion, R.PasajeRetorno
	--	FROM Reingresos R
	--	WHERE R.FechaReingreso
	--	BETWEEN @FechaInicio AND @FechaFin
	--	AND R.NumeroPaciente = @NumeroPaciente
	--) TReingresos
	--ON TAFechas.FechaOperacion = TReingresos.FechaReingreso
	--AND TAFechas.NumeroPaciente = TReingresos.NumeroPaciente
	--LEFT JOIN
	--(
	--	SELECT F.NumeroPaciente, CONVERT(DATETIME, CONVERT(CHAR(10),F.FechaReferencia, 120), 120) AS FechaReferencia 
	--	FROM Referencias F
	--	WHERE F.FechaReferencia
	--	BETWEEN @FechaInicio AND @FechaFin
	--	AND F.NumeroPaciente = @NumeroPaciente
	--) TReferencias
	--ON TAFechas.FechaOperacion = TReferencias.FechaReferencia
	--AND TAFechas.NumeroPaciente = TReferencias.NumeroPaciente
	--LEFT JOIN
	--(
	--	SELECT	SS.NumeroPaciente, CONVERT(DATETIME, CONVERT(CHAR(10),SS.FechaSSocial, 120), 120) AS FechaSSocial, 
	--			SS.RecibioEncomienda, SS.PacienteInstitucionalizo
	--	FROM SeguimientosSociales SS
	--	WHERE SS.FechaSSocial
	--	BETWEEN @FechaInicio AND @FechaFin
	--	AND SS.NumeroPaciente = @NumeroPaciente
	--)TSSOCIAL
	--ON TAFechas.FechaOperacion = TSSOCIAL.FechaSSocial
	--AND TAFechas.NumeroPaciente = TSSOCIAL.NumeroPaciente
	--LEFT JOIN
	--(
	--	SELECT * FROM @TDocumentosConcatenados
	--)TDoc
	--ON TAFechas.FechaOperacion = TDoc.FechaRegistro
	--AND TAFechas.NumeroPaciente = TDoc.NumeroPaciente

END
GO

--EXEC DBO.ListarHistorialPacienteActividades 556, NULL, NULL


----SELECT * FROM Documentos WHERE NumeroPaciente = 726 AND TramitoTrabSocial = 'S'
--SELECT * FROM SeguimientosSociales WHERE NumeroPaciente = 726 


--DECLARE @NumeroPaciente		INT = 726,
--	@FechaInicio		DATETIME,
--	@FechaFin			DATETIME
--SET @FechaInicio = CONVERT(DATETIME, '01/01/1900',120)
--SET @FechaFin = DATEADD(YEAR, 1, GETDATE())



----SELECT DISTINCT * 
----		FROM
----		(
--			SELECT CONVERT(DATETIME, CONVERT(CHAR(10),P.FechaIngreso ,120),120)   AS FechaOperacion, P.NumeroPaciente, 'INGRESO'
--			FROM Pacientes P
--			WHERE P.FechaIngreso
--			BETWEEN @FechaInicio AND @FechaFin
--			AND P.NumeroPaciente = @NumeroPaciente
--			UNION 
--			SELECT CONVERT(DATETIME, CONVERT(CHAR(10),R.FechaReingreso ,120),120) , R.NumeroPaciente, 'REINGRESO'
--			FROM Reingresos R
--			WHERE R.FechaReingreso
--			BETWEEN @FechaInicio AND @FechaFin
--			AND R.NumeroPaciente = @NumeroPaciente
--			UNION 
--			SELECT CONVERT(DATETIME, CONVERT(CHAR(10),F.FechaReferencia ,120),120), F.NumeroPaciente, 'REFERENCIA'
--			FROM Referencias F
--			WHERE F.FechaReferencia
--			BETWEEN @FechaInicio AND @FechaFin
--			AND F.NumeroPaciente = @NumeroPaciente
--			UNION 
--			SELECT CONVERT(DATETIME, CONVERT(CHAR(10),SS.FechaSSocial ,120),120), SS.NumeroPaciente, 'SEGUIMIENTO SOCIAL'
--			FROM SeguimientosSociales SS
--			WHERE SS.FechaSSocial
--			BETWEEN @FechaInicio AND @FechaFin
--			AND SS.NumeroPaciente = @NumeroPaciente
--			UNION 
--			SELECT CONVERT(DATETIME, CONVERT(CHAR(10),D.FechaRegistro ,120),120), D.NumeroPaciente, 'DOCUMENTOS'
--			FROM Documentos D
--			WHERE D.FechaRegistro
--			BETWEEN @FechaInicio AND @FechaFin
--			AND D.NumeroPaciente = @NumeroPaciente
--			AND D.TramitoTrabSocial = 'S'
--		--)TA
		

--SELECT * FROM DBO.SeguimientosSociales


--SELECT CONVERT(DATETIME, CONVERT(CHAR(10),P.FechaIngreso ,120),120)   AS FechaOperacion, P.NumeroPaciente, 'INGRESO' AS TipoHistorial, '' AS Observaciones
--FROM Pacientes P
----WHERE P.FechaIngreso
----BETWEEN @FechaInicio AND @FechaFin
----AND P.NumeroPaciente = @NumeroPaciente
--UNION ALL
--SELECT CONVERT(DATETIME, CONVERT(CHAR(10),R.FechaReingreso ,120),120) , R.NumeroPaciente, 'REINGRESO', Observaciones
--FROM Reingresos R
----WHERE R.FechaReingreso
----BETWEEN @FechaInicio AND @FechaFin
----AND R.NumeroPaciente = @NumeroPaciente
--UNION ALL
--SELECT CONVERT(DATETIME, CONVERT(CHAR(10),F.FechaReferencia ,120),120), F.NumeroPaciente, 'REFERENCIA', Observaciones
--FROM Referencias F
----WHERE F.FechaReferencia
----BETWEEN @FechaInicio AND @FechaFin
----AND F.NumeroPaciente = @NumeroPaciente
----AND F.NumeroReferencia NOT IN ( SELECT NumeroReferencia FROM dbo.Contrarreferencias) 
--UNION ALL
--SELECT CONVERT(DATETIME, CONVERT(CHAR(10),SS.FechaActividad ,120),120), SS.NumeroPaciente, 'SEGUIMIENTO SOCIAL', NombreActividad
--FROM dbo.Actividades SS
--INNER JOIN dbo.ActividadesTipo AT
--ON SS.CodigoActividadTipo = AT.CodigoActividadTipo
----WHERE SS.FechaActividad
----BETWEEN @FechaInicio AND @FechaFin
----AND SS.NumeroPaciente = @NumeroPaciente
--UNION ALL
--SELECT CONVERT(DATETIME, CONVERT(CHAR(10),D.FechaRegistro ,120),120), D.NumeroPaciente, 'DOCUMENTOS', NombreDocumento
--FROM Documentos D
--INNER JOIN dbo.DocumentosTipo DT
--ON D.CodigoDocumentoTipo = DT.CodigoDocumentoTipo
----WHERE D.FechaRegistro
----BETWEEN @FechaInicio AND @FechaFin
----AND D.NumeroPaciente = @NumeroPaciente
----AND D.TramitoTrabSocial = 'S'

