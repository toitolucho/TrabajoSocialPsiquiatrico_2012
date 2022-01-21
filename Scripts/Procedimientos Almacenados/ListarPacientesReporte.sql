USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarPacientesReporte
GO

CREATE PROCEDURE ListarPacientesReporte
	@FechaInicio	DATETIME,
	@FechaFin		DATETIME,
	@NumeroPaciente	INT,
	@Sexo			CHAR(1),
	@TipoConsulta	CHAR(1)--'I'-> INGRESOS, 'R'->REINGRESOS, 'A'->ALTAS
AS
BEGIN
	
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

	IF(@TipoConsulta = 'I')
	BEGIN
		SELECT PD.*
		FROM PacientesDatos PD
		WHERE PD.FechaIngreso 
		BETWEEN @FechaInicio AND @FechaFin
		AND PD.CodigoSexo LIKE CASE WHEN @Sexo IS NOT NULL THEN @Sexo ELSE '%' END
		AND CAST(PD.NumeroPaciente AS VARCHAR(100))
		LIKE CASE WHEN @NumeroPaciente IS NOT NULL THEN CAST(@NumeroPaciente AS VARCHAR(100))
		ELSE '%' END
	END
	
	IF(@TipoConsulta = 'R')
	BEGIN
		SELECT PD.*
		FROM PacientesDatos PD
		INNER JOIN Reingresos R
		ON PD.NumeroPaciente = R.NumeroPaciente
		WHERE R.FechaReingreso
		BETWEEN @FechaInicio AND @FechaFin
		AND PD.CodigoSexo LIKE CASE WHEN @Sexo IS NOT NULL THEN @Sexo ELSE '%' END
		AND CAST(PD.NumeroPaciente AS VARCHAR(100))
		LIKE CASE WHEN @NumeroPaciente IS NOT NULL THEN CAST(@NumeroPaciente AS VARCHAR(100))
		ELSE '%' END
	END
	ELSE
	IF(@TipoConsulta = 'R')
	BEGIN
		SELECT PD.*
		FROM PacientesDatos PD
		INNER JOIN PSIQUIATRICO.DBO.altas A
		ON PD.HClinico = A.hc
		WHERE A.fecha_alta
		BETWEEN @FechaInicio AND @FechaFin
		AND PD.CodigoSexo LIKE CASE WHEN @Sexo IS NOT NULL THEN @Sexo ELSE '%' END
		AND CAST(PD.NumeroPaciente AS VARCHAR(100))
		LIKE CASE WHEN @NumeroPaciente IS NOT NULL THEN CAST(@NumeroPaciente AS VARCHAR(100))
		ELSE '%' END
	END
END
GO
