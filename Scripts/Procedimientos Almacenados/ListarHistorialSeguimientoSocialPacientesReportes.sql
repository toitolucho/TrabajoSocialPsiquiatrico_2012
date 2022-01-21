USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarHistorialSeguimientoSocialPacientesReportes
GO



CREATE PROCEDURE ListarHistorialSeguimientoSocialPacientesReportes
		@RecibioEncomienda			BIT,
		@RealizoTramite				BIT,
		@PacienteDefuncion			BIT,
		@PacienteDadoAlta			BIT,
		@PacienteInstitucionalizo	BIT,
		@Evacion					BIT,
		@FechaInicio				DATETIME,
		@FechaFin					DATETIME,
		@TipoOrden					CHAR(1)		
AS
BEGIN
	DECLARE @Consulta				VARCHAR(2000),
			@Filtro					VARCHAR(1000),
			@Where					VARCHAR(1000),			
			@AUX					NVARCHAR(2000)
	SET @Filtro = ''
	
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
	
	--SELECT DBO.ObtenerCategoriaValoracionSocioEconomicaPaciente(1, 0)
	
	SET @AUX = ' '
	SET @Consulta= 'SELECT PD.*, SS.* FROM PacientesDatos  PD INNER JOIN dbo.SeguimientosSociales SS  ON SS.NumeroPaciente = PD.NumeroPaciente ' 
	
	
	--SELECT * FROM PacientesDatos  PD
	SET @Filtro = ''
	
	IF(@RecibioEncomienda IS NOT NULL)
		SET @Filtro = @Filtro + '(SS.RecibioEncomienda = 1) AND'
	IF(@RealizoTramite IS NOT NULL)
		SET @Filtro = @Filtro + '(SS.RealizoTramite = 1) AND '
	IF(@PacienteDefuncion IS NOT NULL)
		SET @Filtro = @Filtro + '(SS.PacienteDefuncion = 1) AND '
	IF(@PacienteDadoAlta IS NOT NULL)
		SET @Filtro = @Filtro + '(SS.PacienteDadoAlta = 1) AND ' 
	IF(@PacienteInstitucionalizo IS NOT NULL)
		SET @Filtro = @Filtro + '(SS.PacienteInstitucionalizo = 1) AND ' 
	IF(@Evacion IS NOT NULL)
		SET @Filtro = @Filtro + '(SS.Evacion = 1) AND ' 
	
	IF(@FechaFin IS NOT NULL AND @FechaFin IS NOT NULL)
	BEGIN
		SET @Filtro = @Filtro + '(SS.FechaSSocial BETWEEN ''' + CAST(@FechaInicio AS CHAR(12)) + ''' AND '''+ CAST(@FechaFin AS CHAR(12))+''') AND '		
	END
	IF(LEN(@Filtro) > 1)
	BEGIN
		PRINT SUBSTRING(@Filtro, LEN(@Filtro) - 3 , LEN(@Filtro))
		IF( SUBSTRING(@Filtro, LEN(@Filtro) - 3 , LEN(@Filtro)) = ' AND ')			
			SET @Where = 'WHERE ' + SUBSTRING(@Filtro,0, LEN(@Filtro) - 2)
		ELSE
			SET @Where = 'WHERE ' + @Filtro
	END
	
	IF(LEN (@Where) > 1)
		SET @Consulta = @Consulta + RTRIM(LTRIM(@Where))
		
	SET @Consulta = @Consulta + ' ORDER BY ' + CASE @TipoOrden WHEN 'F' THEN 'SS.FechaSSocial ' WHEN 'H' THEN 'PD.HClinico ' ELSE 'NombreCompletoPaciente ' END
	
	PRINT @Consulta
	EXEC (@Consulta)
	
	--SELECT PD.*, SS.* 
	--FROM PacientesDatos  PD 
	--INNER JOIN dbo.SeguimientosSociales SS  
	--ON SS.NumeroPaciente = PD.NumeroPaciente
END
GO

--EXEC ListarHistorialSeguimientoSocialPacientesReportes 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL