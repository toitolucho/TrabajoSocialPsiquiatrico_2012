USE TRABAJO_SOCIAL
GO

DROP FUNCTION ObtenerCodigoPagoServicioGenerado
GO

CREATE FUNCTION ObtenerCodigoPagoServicioGenerado()
RETURNS CHAR(10)
 
AS
BEGIN
	DECLARE @CodigoPagoGenerado	CHAR(10),
			@CantidadPagos		INTEGER
			
	SELECT top(1) @CantidadPagos = CAST(CodigoPagoServicio AS INT)
	FROM dbo.PagoServicios
	order by CodigoPagoServicio DESC
	
	SET @CantidadPagos = @CantidadPagos + 1
	
	SET @CodigoPagoGenerado = RIGHT('000000000' + RTRIM(CAST(ISNULL(@CantidadPagos,0) AS CHAR(10))),10)
	
	--SET @CantidadPagos = ISNULL(@CantidadPagos,0)
	--SELECT CAST(@CantidadPagos AS CHAR(6))
	RETURN ISNULL(@CodigoPagoGenerado,'0000000001')
END
GO
