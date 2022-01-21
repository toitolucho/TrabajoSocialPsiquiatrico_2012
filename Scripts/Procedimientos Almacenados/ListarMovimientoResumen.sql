USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarMovimientoResumen
GO

CREATE PROCEDURE ListarMovimientoResumen
	@FechaInicio	DATETIME,
	@FechaFin		DATETIME
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
	
	DECLARE @TMovimientosResumen TABLE(
		Unidad		INT,
		Seccion		varchar(12),
		Cantidad	INT
	)
	
	INSERT INTO @TMovimientosResumen (Unidad, Seccion, Cantidad)
	SELECT Unidad, Seccion, COUNT(*)
	FROM PSIQUIATRICO.DBO.Movimientos
	WHERE Fecha_mov
	BETWEEN @FechaInicio AND @FechaFin
	GROUP BY Unidad, Seccion
	
	SELECT  TUnidadesSecciones.Unidad, UPPER(TUnidadesSecciones.Seccion) AS Seccion, ISNULL(TMR.Cantidad, 0) AS Cantidad
	FROM
	(
		SELECT DISTINCT Unidad, Seccion
		FROM PSIQUIATRICO.dbo.Movimientos
	)TUnidadesSecciones
	LEFT JOIN @TMovimientosResumen TMR
	ON TMR.Unidad = TUnidadesSecciones.Unidad
	AND TMR.Seccion = TUnidadesSecciones.Seccion
	ORDER BY 1, 2
END
GO

--EXEC DBO.ListarMovimientoResumen '10/7/2010', '31/12/2011'