USE TRABAJO_SOCIAL
GO

DROP FUNCTION TienePacienteDatosCompleto
GO

CREATE	FUNCTION TienePacienteDatosCompleto(@NumeroPaciente	INT)
RETURNS BIT
AS
BEGIN
	DECLARE @TieneDatosCompletos	BIT
	IF(EXISTS (SELECT * FROM dbo.Viviendas WHERE NumeroPaciente = @NumeroPaciente))
		SET @TieneDatosCompletos = 1
	ELSE
		SET @TieneDatosCompletos = 0
	
	RETURN @TieneDatosCompletos
END
GO



--select * from DatosAdministrativos
--where NumeroPaciente = 1

--select * from PreguntasValoracion

--SELECT * FROM Pacientes
--WHERE NumeroPaciente = 1564

--SELECT * 
--FROM ValoracionSocioEconomica
--WHERE NumeroPaciente = 1562
