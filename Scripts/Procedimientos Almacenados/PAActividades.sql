USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarActividad
GO

CREATE PROCEDURE InsertarActividad
	@NumeroPaciente			INT,
	@FechaActividad			DATETIME,
	@CodigoActividadTipo	INT,
	@CodigoUsuario			INT,
	@TipoActividad			CHAR(1),
	@Observaciones			TEXT
AS
BEGIN
	
	IF(@FechaActividad IS NULL)
		SET @FechaActividad = GETDATE()
	
	DECLARE @CodigoActividadPacInst		INT,
			@CodigoActividadPacNoInst	INT
	
	SELECT @CodigoActividadPacInst = CodigoActividadTipo
	FROM dbo.ActividadesTipo
	WHERE NombreActividad = 'PACIENTE SE INSTITUCIONALIZA'
	
	SELECT @CodigoActividadPacNoInst = CodigoActividadTipo
	FROM dbo.ActividadesTipo
	WHERE NombreActividad = 'PACIENTE SE DES-INSTITUCIONALIZA'
	
	IF(@CodigoActividadTipo IN (SELECT CodigoActividadTipo FROM dbo.ActividadesTipo 
	WHERE NombreActividad IN ('PACIENTE SE INSTITUCIONALIZA','PACIENTE SE DES-INSTITUCIONALIZA','EVASION O FUGA','ALTA','DEFUNCIÓN')))
	BEGIN
		UPDATE dbo.Pacientes
			SET PacienteInstitucionalizado = CASE WHEN @CodigoActividadTipo IN (SELECT CodigoActividadTipo FROM dbo.ActividadesTipo 
													WHERE NombreActividad IN 
													('PACIENTE SE DES-INSTITUCIONALIZA',
													'EVASION O FUGA','ALTA','DEFUNCIÓN'))
											THEN 0
											ELSE 1 END
		WHERE NumeroPaciente = @NumeroPaciente
	END
	
	--PACIENTE INSTITUCIONALIZADO
	IF(EXISTS (SELECT * FROM dbo.ActividadesTipo WHERE CodigoActividadTipo = @CodigoActividadTipo))
	BEGIN
		INSERT INTO dbo.Actividades (CodigoActividad, NumeroPaciente, FechaActividad, CodigoActividadTipo, CodigoUsuario, TipoActividad, Observaciones)
		VALUES (dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'A'), @NumeroPaciente, @FechaActividad, @CodigoActividadTipo, @CodigoUsuario, @TipoActividad, @Observaciones)
	END
	ELSE
		RAISERROR('LA ACTIVIDAD QUE DESEA REGISTRAR, NO SE ENCUENTRA DENTRO DE LOS TIPOS DE ACTIIVDADES DISPONIBLES', 17,2)
END
GO

--select * from dbo.Pacientes  where hclinico = 5842
--update pacientes set PacienteInstitucionalizado = 1 where hclinico = 5842

DROP PROCEDURE ActualizarActividad
GO

CREATE PROCEDURE ActualizarActividad
	@NumeroPaciente			INT,
	@CodigoActividad		INT,
	@FechaActividad			DATETIME,
	@CodigoActividadTipo	INT,
	@CodigoUsuario			INT,
	@TipoActividad			CHAR(1),
	@Observaciones			TEXT

AS 
BEGIN
	
	UPDATE 	dbo.Actividades	
		SET	
			--FechaActividad		= @FechaActividad,
			CodigoActividadTipo	= @CodigoActividadTipo,
			CodigoUsuario		= @CodigoUsuario,
			TipoActividad		= @TipoActividad,
			Observaciones		= @Observaciones
		
	WHERE CodigoActividad = @CodigoActividad
	AND FechaActividad = @FechaActividad
END
GO


DROP PROCEDURE EliminarActividad
GO

CREATE PROCEDURE EliminarActividad
	@CodigoActividad	INT,
	@FechaActividad		DATETIME
AS
BEGIN
	
	DELETE FROM dbo.Actividades
	WHERE CodigoActividad = @CodigoActividad
	AND FechaActividad = @FechaActividad
END
GO

DROP PROCEDURE ListarActividades
GO

CREATE PROCEDURE ListarActividades
	@TipoActividad	CHAR(1)	
AS
BEGIN
	SELECT	NumeroPaciente, CodigoActividad, FechaActividad, CodigoActividadTipo, 
			CodigoUsuario, TipoActividad, Observaciones, dbo.ObtenerNumeroHistorialClinicoPaciente(NumeroPaciente) as HClinico
	FROM dbo.Actividades
	WHERE TipoActividad LIKE CASE WHEN @TipoActividad IS NULL THEN '%%' ELSE @TipoActividad END
	ORDER BY CodigoActividad 
END
GO

DROP PROCEDURE ListarActividadesPacientes
GO

CREATE PROCEDURE ListarActividadesPacientes
	@TipoActividad		CHAR(1),
	@NumeroPaciente		INT,
	@FechaHoraInicio	DATETIME,
	@FechaHoraFin		DATETIME
AS
BEGIN

	SET @FechaHoraInicio = ISNULL(@FechaHoraInicio,'01/01/1980')
	SET @FechaHoraFin = ISNULL(@FechaHoraFin,GETDATE())
	
	SELECT	A.NumeroPaciente, A.CodigoActividad, A.FechaActividad, A.CodigoActividadTipo, 
			A.CodigoUsuario, A.TipoActividad, A.Observaciones, dbo.ObtenerNumeroHistorialClinicoPaciente(NumeroPaciente) as HClinico,
			AT.NombreActividad
	FROM dbo.Actividades A
	INNER JOIN ActividadesTipo AT
	ON A.CodigoActividadTipo = AT.CodigoActividadTipo
	WHERE TipoActividad LIKE CASE WHEN @TipoActividad IS NULL THEN '%%' ELSE @TipoActividad END
	AND CAST(ISNULL(NumeroPaciente,'') AS VARCHAR(100)) 
	LIKE (CASE WHEN @NumeroPaciente IS NULL THEN '%%' ELSE CAST(@NumeroPaciente AS VARCHAR(100)) END) 
	AND FechaActividad 
	BETWEEN @FechaHoraInicio AND @FechaHoraFin
	ORDER BY CodigoActividad
END
GO
--exec dbo.ListarActividadesPacientes 'G', NULL, NULL, NULL


DROP PROCEDURE ObtenerActividad
GO

CREATE PROCEDURE ObtenerActividad
	@CodigoActividad	INT,
	@FechaActividad		DATETIME
AS
BEGIN
	SELECT	NumeroPaciente, CodigoActividad, FechaActividad, CodigoActividadTipo, 
			CodigoUsuario, TipoActividad, Observaciones, dbo.ObtenerNumeroHistorialClinicoPaciente(NumeroPaciente) as HClinico
	FROM  dbo.Actividades
	WHERE CodigoActividad = @CodigoActividad
	AND FechaActividad = @FechaActividad
END
GO
