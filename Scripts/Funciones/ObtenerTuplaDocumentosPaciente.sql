USE TRABAJO_SOCIAL
GO

DROP FUNCTION ObtenerTuplaDocumentosPaciente
GO

CREATE FUNCTION ObtenerTuplaDocumentosPaciente(@NumeroPaciente	INT)
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @TuplaDocumentos	VARCHAR(6)
	SELECT  @TuplaDocumentos = COALESCE(@TuplaDocumentos + '', '') + CASE WHEN D.CodigoDocumentoTipo IS NOT NULL THEN '1' ELSE '0' END
	FROM Documentos D
	RIGHT JOIN  DocumentosTipo DT ON
	DT.CodigoDocumentoTipo = D.CodigoDocumentoTipo
	AND D.NumeroPaciente = @NumeroPaciente
	
	
	RETURN ISNULL(@TuplaDocumentos,'000000')
	
	
END
GO

--SELECT  *
--FROM Documentos D
--RIGHT JOIN  DocumentosTipo DT ON
--DT.CodigoDocumentoTipo = D.CodigoDocumentoTipo
--AND D.NumeroPaciente = 56
	
--SELECT DBO.ObtenerTuplaDocumentosPaciente(56)
--SELECT * FROM Documentos
