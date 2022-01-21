USE TRABAJO_SOCIAL
GO

DROP FUNCTION ObtenerCategoriaValoracionSocioEconomicaPaciente
GO

CREATE FUNCTION ObtenerCategoriaValoracionSocioEconomicaPaciente(@NumeroPaciente INT, @DevolverCodigo BIT)
RETURNS CHAR(2)
AS
BEGIN
	
	DECLARE @Codigo CHAR(2),
			@PuntajeTotal	INT,
			@FechaHoraValoracionSocioEcon	DATETIME
			
	SELECT DISTINCT @FechaHoraValoracionSocioEcon = FechaHoraValoracionSocioEcon
	FROM ValoracionSocioEconomica
	WHERE NumeroPaciente = @NumeroPaciente
	ORDER BY FechaHoraValoracionSocioEcon DESC
			
	SELECT @PuntajeTotal = SUM(PuntajeActual)
	FROM ValoracionSocioEconomica
	WHERE NumeroPaciente = @NumeroPaciente
	AND FechaHoraValoracionSocioEcon = @FechaHoraValoracionSocioEcon
	
	IF(@DevolverCodigo = 1)
	BEGIN
		SELECT @Codigo = CAST(CodigoCategoria AS CHAR(2))
		FROM Categorias
		WHERE @PuntajeTotal >= PuntajeMinimo AND @PuntajeTotal <= PuntajeMaximo		
	END
	ELSE
	BEGIN
		SELECT @Codigo = NombreCategoria
		FROM Categorias
		WHERE @PuntajeTotal >= PuntajeMinimo AND @PuntajeTotal <= PuntajeMaximo		
	END
	
	RETURN @Codigo
END
GO

