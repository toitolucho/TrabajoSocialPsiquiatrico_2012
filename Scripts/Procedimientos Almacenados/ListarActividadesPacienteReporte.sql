USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarActividadesPacienteReporte
GO

CREATE PROCEDURE ListarActividadesPacienteReporte
	@NumeroPaciente		INT,
	@CodigoActividadTipo	INT,
	@CodigoUsuario		INT,
	@FechaHoraInicio	DATETIME,
	@FechaHoraFin		DATETIME
AS
BEGIN
	
	SET @FechaHoraInicio = CASE WHEN @FechaHoraInicio IS NULL THEN '01/01/1900' ELSE DBO.FormatearFechaInicioFin(@FechaHoraInicio, 1) END
	SET @FechaHoraFin = CASE WHEN @FechaHoraFin IS NULL THEN GETDATE() ELSE DBO.FormatearFechaInicioFin(@FechaHoraFin, 0) END
	

	SELECT PD.NumeroPaciente, PD.HClinico, PD.NombreCompletoPaciente, PD.FechaIngreso, 
			PD.Sexo, PD.EdadActual, PD.DepartamentoProcedencia, PD.DepartamentoProcedencia, PD.LocalidadProcedencia,
			A.FechaActividad, A.Observaciones, AT.NombreActividad,
			U.Nombre + ' ' + U.ApellidoPaterno + ' ' + U.ApellidoMaterno AS NombreUsuario, pd.CodigoEstadoPaciente
	FROM dbo.Actividades A
	INNER JOIN dbo.ActividadesTipo AT
	ON A.CodigoActividadTipo = AT.CodigoActividadTipo
	INNER JOIN PacientesDatos PD
	ON A.NumeroPaciente = PD.NumeroPaciente
	LEFT JOIN Usuarios U
	ON A.CodigoUsuario = U.CodigoUsuario
	WHERE CAST(PD.NumeroPaciente AS VARCHAR(100)) LIKE CASE WHEN @NumeroPaciente IS NULL THEN '%%' ELSE CAST(@NumeroPaciente AS VARCHAR(100)) END
	AND CAST(A.CodigoActividadTipo AS VARCHAR(100)) LIKE CASE WHEN @CodigoActividadTipo IS NULL THEN '%%' ELSE CAST(@CodigoActividadTipo AS VARCHAR(100)) END
	AND CAST(A.CodigoUsuario AS VARCHAR(100)) LIKE CASE WHEN @CodigoUsuario IS NULL THEN '%%' ELSE CAST(@CodigoUsuario AS VARCHAR(100)) END
	AND A.FechaActividad BETWEEN @FechaHoraInicio AND @FechaHoraFin
	ORDER BY CASE WHEN @NumeroPaciente IS NOT NULL THEN 3 ELSE 13 END, 
	CASE WHEN @CodigoUsuario IS NOT NULL THEN 13 ELSE 3 END, 12, 10
END
GO
