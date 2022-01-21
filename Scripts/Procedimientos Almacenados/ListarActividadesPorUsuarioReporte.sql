USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarActividadesPorUsuarioReporte
GO

CREATE PROCEDURE ListarActividadesPorUsuarioReporte
	@CodigoUsuario	INT,
	@FechaInicio	DATETIME,
	@FechaFin		DATETIME	
AS
BEGIN
	
	DECLARE @TActividadesUsuario TABLE(
		CodigoUsuario		INT,
		CodigoActividadTipo	INT,
		Cantidad			INT
	)
	
	INSERT INTO @TActividadesUsuario (CodigoUsuario, CodigoActividadTipo, Cantidad)	
	SELECT AT.CodigoUsuario, AT.CodigoActividadTipo, COUNT(*) AS Cantidad
	FROM DBO.Actividades AT	
	WHERE CAST(AT.CodigoUsuario AS CHAR(10)) LIKE 
	CASE WHEN @CodigoUsuario IS NOT NULL THEN CAST(@CodigoUsuario AS CHAR(10)) ELSE '%' END
	AND AT.FechaActividad 
	BETWEEN @FechaInicio and @FechaFin
	GROUP BY AT.CodigoUsuario, AT.CodigoActividadTipo
	
	DECLARE @NombreCompletoUsuario	VARCHAR(150)
	IF(@CodigoUsuario IS NOT NULL)
		SELECT @NombreCompletoUsuario = Nombre + ' ' + ApellidoPaterno + ' ' + ApellidoMaterno
		FROM Usuarios
		
	SELECT @NombreCompletoUsuario AS NombreCompletoUsuario, AT.NombreActividad, ISNULL(AU.Cantidad, 0) AS Cantidad
	FROM ActividadesTipo AT
	LEFT JOIN @TActividadesUsuario AU
	ON AT.CodigoActividadTipo = AU.CodigoActividadTipo
END
GO

--exec dbo.ListarActividadesPorUsuarioReporte 2, '01/01/2011', '31/12/2011'