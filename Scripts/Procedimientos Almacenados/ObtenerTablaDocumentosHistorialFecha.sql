
USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ObtenerTablaDocumentosHistorialFecha
GO

CREATE PROCEDURE ObtenerTablaDocumentosHistorialFecha
	@NumeroPaciente		INT,
	@FechaInicio		DATETIME,
	@FechaFin			DATETIME
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
	
	

	DECLARE @TDocumentosFechas TABLE(		
		FechaRegistro	DATETIME		
	)
	
	DECLARE @TDocumentosConcatenados TABLE(
		NumeroPaciente	INT,
		FechaRegistro	DATETIME,
		NombreDocumento VARCHAR(400)
	)
	
	DECLARE @FechaDocumento	DATETIME,
			@ConcatenacionDocumentos	VARCHAR(4000)
	
	INSERT INTO @TDocumentosFechas(FechaRegistro)
	SELECT DISTINCT CONVERT(DATETIME, CONVERT(CHAR(10),D.FechaRegistro ,120),120)
	FROM Documentos D
	WHERE D.FechaRegistro
	BETWEEN @FechaInicio AND @FechaFin
	AND D.NumeroPaciente = @NumeroPaciente
	AND D.TramitoTrabSocial = 'S'
	
	
	
	SET ROWCOUNT 1
	SELECT @FechaDocumento = FechaRegistro
	FROM @TDocumentosFechas
	WHILE @@rowcount <> 0
	BEGIN
		SET @ConcatenacionDocumentos = ''
		
		SET ROWCOUNT 0
		SELECT @ConcatenacionDocumentos = COALESCE(@ConcatenacionDocumentos + RTRIM(DT.NombreDocumento)  +', ', NULL)
		FROM Documentos D
		INNER JOIN DocumentosTipo DT
		ON D.CodigoDocumentoTipo = DT.CodigoDocumentoTipo
		WHERE CONVERT(DATETIME, CONVERT(CHAR(10),D.FechaRegistro ,120),120) = @FechaDocumento
		AND D.NumeroPaciente = @NumeroPaciente
		AND D.TramitoTrabSocial = 'S'
		
			
		PRINT @ConcatenacionDocumentos
		
		PRINT @FechaDocumento
		
		SET @ConcatenacionDocumentos  = SUBSTRING(@ConcatenacionDocumentos, 1, LEN(@ConcatenacionDocumentos)-1)
		
		INSERT INTO @TDocumentosConcatenados (NumeroPaciente, FechaRegistro, NombreDocumento)
		VALUES (@NumeroPaciente, @FechaDocumento, @ConcatenacionDocumentos)
		
		DELETE @TDocumentosFechas WHERE FechaRegistro = @FechaDocumento
		SET ROWCOUNT 1
		SELECT @FechaDocumento = FechaRegistro
		FROM @TDocumentosFechas
	END
	SET ROWCOUNT 0
	
	SELECT * FROM @TDocumentosConcatenados
	
END
GO





