USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarReferenciasEnviadasRecibidasPorInstitucion
GO

CREATE PROCEDURE ListarReferenciasEnviadasRecibidasPorInstitucion
	@FechaHoraInicio	DATETIME,
	@FechaHoraFin		DATETIME,
	@CodigoUsuario	INT
AS
BEGIN

	SET @FechaHoraInicio = CASE WHEN @FechaHoraInicio IS NULL THEN '01/01/1900' ELSE DBO.FormatearFechaInicioFin(@FechaHoraInicio, 1) END
	SET @FechaHoraFin = CASE WHEN @FechaHoraFin IS NULL THEN GETDATE() ELSE DBO.FormatearFechaInicioFin(@FechaHoraFin, 0) END
	
	SELECT UM.CodigoUnidadMedica, UM.NombreUnidadMedica, 
			ISNULL(TAREnviadas.CantidadReferenciasEnviadas,0) AS CantidadReferenciasEnviadas,
			ISNULL(TARRecibidas.CantidadReferenciasRecibidas,0) AS CantidadReferenciasRecibidas
	FROM UnidadesMedicas UM
	LEFT JOIN
	(
		SELECT TS.CodigoUnidadMedica, COUNT(*) AS CantidadReferenciasEnviadas
		FROM Referencias R
		LEFT JOIN TrabajadoresSociales TS
		ON R.CodigoTrabajadorSocial = TS.CodigoTrabajadorSocial
		WHERE R.CodigoTipoReferencia = 'E'
		AND CAST(CodigoUsuario AS VARCHAR(100)) LIKE CASE WHEN @CodigoUsuario IS NULL THEN '%%'
		ELSE CAST(@CodigoUsuario AS VARCHAR(100)) END
		AND R.FechaReferencia BETWEEN
		@FechaHoraInicio AND @FechaHoraFin		
		GROUP BY TS.CodigoUnidadMedica 
	)TAREnviadas
	ON TAREnviadas.CodigoUnidadMedica = UM.CodigoUnidadMedica
	LEFT JOIN
	(
		SELECT TS.CodigoUnidadMedica, COUNT(*) AS CantidadReferenciasRecibidas
		FROM Referencias R
		LEFT JOIN TrabajadoresSociales TS
		ON R.CodigoTrabajadorSocial = TS.CodigoTrabajadorSocial
		WHERE R.CodigoTipoReferencia = 'R'
		AND CAST(CodigoUsuario AS VARCHAR(100)) LIKE CASE WHEN @CodigoUsuario IS NULL THEN '%%'
		ELSE CAST(@CodigoUsuario AS VARCHAR(100)) END
		AND R.FechaReferencia BETWEEN
		@FechaHoraInicio AND @FechaHoraFin	
		GROUP BY TS.CodigoUnidadMedica 	
	)TARRecibidas
	ON TARRecibidas.CodigoUnidadMedica = UM.CodigoUnidadMedica
	ORDER BY 2
END
GO


--EXEC ListarReferenciasEnviadasRecibidasPorInstitucion NULL, NULL, NULL