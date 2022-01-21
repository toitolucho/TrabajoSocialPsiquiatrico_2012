USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarPacientesDocumentos
GO

CREATE PROCEDURE ListarPacientesDocumentos
	@FechaInicio	DATETIME,
	@FechaFin		DATETIME,
	@TramitoTS		CHAR(1),
	@TipoConsulta	CHAR(1),
	@TipoOrden		CHAR(1)
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
	
	
	SET @AUX = ' '
	SET @Consulta= CASE WHEN @TipoConsulta = 'D' THEN 'SELECT PD.*, DT.CodigoDocumentoTipo, DT.NombreDocumento, SS.FechaRegistro, CASE WHEN SS.TramitoTrabSocial = ''S'' THEN ''SI''  ELSE ''NO'' END as TramitoTrabSocial' ELSE 'SELECT DISTINCT PD.* '  END
		+ ' FROM PacientesDatos PD
			INNER JOIN Documentos SS
			ON PD.NumeroPaciente = SS.NumeroPaciente
			INNER JOIN DocumentosTipo DT
			ON SS.CodigoDocumentoTipo = DT.CodigoDocumentoTipo ' 
	
	IF(@TramitoTS IS NOT NULL)
		SET @Filtro = @Filtro + '(SS.TramitoTrabSocial = ''' + @TramitoTS + ''') AND '
	
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
	
	
	SET @Consulta = @Consulta + ' ORDER BY ' + CASE @TipoOrden WHEN 'F' THEN 'SS.FechaRegistro ' WHEN 'H' THEN 'PD.HClinico ' ELSE 'NombreCompletoPaciente ' END
	
		
	PRINT @Consulta
	EXEC (@Consulta)
	
	--SELECT PD.*, DT.NombreDocumento, SS.FechaRegistro,CASE WHEN TramitoTrabSocial = 'S' THEN 'SI'  ELSE 'NO' END as TramitoTrabSocial
	--FROM PacientesDatos PD
	--INNER JOIN Documentos SS
	--ON PD.NumeroPaciente = SS.NumeroPaciente
	--INNER JOIN DocumentosTipo DT
	--ON SS.CodigoDocumentoTipo = DT.CodigoDocumentoTipo
	
	
END
GO

select * 
from PacientesDatos pd
inner join Documentos d
on pd.NumeroPaciente = d.NumeroPaciente
EXEC DBO.ListarPacientesDocumentos '01/01/1980', '31/12/2012', 'S', 'D', 'H'