USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarReferenciasEnviadasMensualesPorInstitucion
GO

CREATE PROCEDURE ListarReferenciasEnviadasMensualesPorInstitucion
	@MesInicio		INT,
	@MesFin			INT,
	@AnoGestion		INT,
	@CodigoUsuario	INT
AS
BEGIN
	
	IF(@MesInicio > @MesFin)
		RAISERROR ('Rango de Meses INVALIDO', 17, 2)
	ELSE
	BEGIN
		DECLARE @TListaMeses TABLE
		(
			NumeroMes	INT
		)
		DECLARE	@ContadorMeses INT
		SET @ContadorMeses = @MesInicio
		WHILE @ContadorMeses <= @MesFin
		BEGIN
			INSERT INTO @TListaMeses(NumeroMes) VALUES (@ContadorMeses)
			SET @ContadorMeses = @ContadorMeses + 1
		END
		
		SELECT LM.NumeroMes, UPPER(DATENAME(MONTH, '01/' + CAST(LM.NumeroMes AS CHAR(2)) + '/ 1900')) AS Mes,
			ISNULL(RV.CantidadCentroMedicos, 0) AS CantidadCentroMedicos,
			ISNULL(RM.CantidadOtrasInstituciones, 0) AS CantidadOtrasInstituciones
		FROM @TListaMeses LM		
		LEFT JOIN
		(	
			SELECT MONTH(R.FechaReferencia) AS MesReIngreso, COUNT(*) as CantidadCentroMedicos
			FROM Referencias R
			LEFT JOIN TrabajadoresSociales TS
			ON R.CodigoTrabajadorSocial = TS.CodigoTrabajadorSocial
			INNER JOIN UnidadesMedicas UM
			ON TS.CodigoOcupacion = UM.CodigoUnidadMedica
			WHERE YEAR(R.FechaReferencia) =  @AnoGestion
			AND UM.CodigoTipoUnidadMedica = 'I'
			AND CAST(CodigoUsuario AS VARCHAR(100)) LIKE CASE WHEN @CodigoUsuario IS NULL THEN '%%'
			ELSE CAST(@CodigoUsuario AS VARCHAR(100)) END
			GROUP BY MONTH(R.FechaReferencia)
		) RV
		ON LM.NumeroMes = RV.MesReIngreso
		LEFT JOIN
		(	
			SELECT MONTH(R.FechaReferencia) AS MesReIngreso, COUNT(*) as CantidadOtrasInstituciones
			FROM Referencias R
			LEFT JOIN TrabajadoresSociales TS
			ON R.CodigoTrabajadorSocial = TS.CodigoTrabajadorSocial
			INNER JOIN UnidadesMedicas UM
			ON TS.CodigoOcupacion = UM.CodigoUnidadMedica
			WHERE YEAR(R.FechaReferencia) =  @AnoGestion
			AND UM.CodigoTipoUnidadMedica = 'O'
			AND CAST(CodigoUsuario AS VARCHAR(100)) LIKE CASE WHEN @CodigoUsuario IS NULL THEN '%%'
			ELSE CAST(@CodigoUsuario AS VARCHAR(100)) END
			GROUP BY MONTH(R.FechaReferencia)
		) RM
		ON LM.NumeroMes = RM.MesReIngreso
		
						
	END
END
GO
