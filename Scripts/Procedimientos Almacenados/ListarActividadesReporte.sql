USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarActividadesReporte
GO

CREATE PROCEDURE ListarActividadesReporte
	@NumeroPersona		INT,
	@TipoPersona		CHAR(1) , --'T'-> TRABAJADORA SOCIAL, 'P'->PACIENTE
	@FechaHoraInicio	DATETIME,
	@FechaHoraFin		DATETIME
AS
BEGIN

	SET @FechaHoraInicio = CASE WHEN @FechaHoraInicio IS NULL THEN '01/01/1900' ELSE DBO.FormatearFechaInicioFin(@FechaHoraInicio, 1) END
	SET @FechaHoraFin = CASE WHEN @FechaHoraFin IS NULL THEN GETDATE() ELSE DBO.FormatearFechaInicioFin(@FechaHoraFin, 0) END
	
	IF(@TipoPersona = 'P')
	BEGIN
		SELECT A.CodigoActividad, A.FechaActividad, AT.NombreActividad, A.Observaciones,
				U.Nombre + ' ' + U.ApellidoPaterno + ' ' + U.ApellidoMaterno AS NombreUsuario,
				dbo.ObtenerNombreCompleto(A.NumeroPaciente) AS NombreCompletoPaciente, U.CodigoUsuario
		FROM Actividades A
		INNER JOIN ActividadesTipo AT
		ON A.CodigoActividadTipo = AT.CodigoActividadTipo
		LEFT JOIN Usuarios U
		ON A.CodigoUsuario = U.CodigoUsuario
		WHERE NumeroPaciente = @NumeroPersona 
		AND FechaActividad 
		BETWEEN @FechaHoraInicio AND @FechaHoraFin	
		and TipoActividad = 'P'
	END
	ELSE
	BEGIN
		SELECT	A.CodigoActividad, A.FechaActividad, AT.NombreActividad, A.Observaciones,
				U.Nombre + ' ' + U.ApellidoPaterno + ' ' + U.ApellidoMaterno AS NombreUsuario, U.CodigoUsuario
		FROM Actividades A
		INNER JOIN ActividadesTipo AT
		ON A.CodigoActividadTipo = AT.CodigoActividadTipo
		LEFT JOIN Usuarios U
		ON A.CodigoUsuario = U.CodigoUsuario
		WHERE CAST(A.CodigoUsuario AS VARCHAR(10))  LIKE CASE WHEN @NumeroPersona IS NULL THEN '%%' ELSE CAST(@NumeroPersona AS VARCHAR(10)) END
		AND FechaActividad 
		BETWEEN @FechaHoraInicio AND @FechaHoraFin	
		and TipoActividad = 'G'
	END
	
	
END
GO