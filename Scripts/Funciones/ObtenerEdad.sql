USE TRABAJO_SOCIAL
GO

DROP FUNCTION ObtenerEdad
GO

CREATE FUNCTION ObtenerEdad(@FecNac DATETIME, @FecHoy DATETIME)
RETURNS INT
AS
BEGIN

DECLARE @ANO VARCHAR(3)
DECLARE @MES VARCHAR(3)

SET @ANO = YEAR(@FecHoy) - YEAR(@FecNac)

IF MONTH(@FecNac) > MONTH(@FecHoy)
BEGIN
	SET @ANO = @ANO - 1
	SET @MES = 12 - (month(@FecNac) - month(@FecHoy))
END

IF MONTH(@FecNac) < MONTH(@FecHoy)
	BEGIN
	SET @MES = (MONTH(@FecHoy) - MONTH(@FecNac))
END

IF MONTH(@FecNac) = MONTH(@FecHoy)
BEGIN
	IF DAY(@FecNac) <= DAY(@FecHoy)
	BEGIN
		SET @MES = 0
	END	
	IF DAY(@FecNac) > DAY(@FecHoy)
	BEGIN
		SET @ANO = @ANO - 1
		SET @MES = 11
	END
END

--RETURN RIGHT('  ' + @ANO,2) + 'a ' + RIGHT('  ' + @MES,2) + 'm'
RETURN CAST(@ANO AS INT)

END
GO

DROP FUNCTION ObtenerEdadPaciente
GO
CREATE FUNCTION ObtenerEdadPaciente(@NumeroPaciente INT)
	RETURNS INT
AS
BEGIN
	DECLARE  @Edad INT
	SELECT @Edad = DBO.ObtenerEdad(FechaNacimiento, GETDATE())
	FROM Pacientes
	WHERE NumeroPaciente = @NumeroPaciente
	RETURN @Edad
END
GO
