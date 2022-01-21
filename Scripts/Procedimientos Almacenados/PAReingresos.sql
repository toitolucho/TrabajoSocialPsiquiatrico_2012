USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarReingreso
GO

CREATE PROCEDURE InsertarReingreso
	@NumeroPaciente			INT,
	@HClinico				INT,
	@FechaReingreso			DATETIME,
	@Unidad					INT,
	@Seccion				VARCHAR(12),
	@Codigo					VARCHAR(10),
	@TipoDiscapacidad		VARCHAR(150),
	@Antecedentes			TEXT,
	@RelacionesFamiliares	CHAR(1),
	@PredisTratamiento		CHAR(1),
	@AsignacionMensual		FLOAT,
	@Denominacion			VARCHAR(150),
	@NumeroFolio			INT,
	@IngresoMensual			FLOAT,
	@IngresoEventual		FLOAT,
	@Observaciones			TEXT
AS
BEGIN
	INSERT INTO dbo.Reingresos (NumeroPaciente, NumeroReingreso, HClinico, FechaReingreso, Unidad, Seccion, Codigo, TipoDiscapacidad, Antecedentes,
			RelacionesFamiliares, PredisTratamiento, AsignacionMensual, Denominacion, NumeroFolio, IngresoMensual, IngresoEventual,  Observaciones)
	VALUES (@NumeroPaciente,dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'G'), @HClinico, @FechaReingreso, @Unidad, @Seccion, @Codigo, @TipoDiscapacidad, @Antecedentes,
			@RelacionesFamiliares, @PredisTratamiento, @AsignacionMensual, @Denominacion, @NumeroFolio, @IngresoMensual, @IngresoEventual, @Observaciones)
END
GO

DROP PROCEDURE ActualizarReingreso
GO

CREATE PROCEDURE ActualizarReingreso
	@NumeroPaciente			INT,
	@NumeroReingreso		INT,
	@HClinico				INT,
	@FechaReingreso			DATETIME,
	@Unidad					INT,
	@Seccion				VARCHAR(12),
	@Codigo					VARCHAR(10),
	@TipoDiscapacidad		VARCHAR(150),
	@Antecedentes			TEXT,
	@RelacionesFamiliares	CHAR(1),
	@PredisTratamiento		CHAR(1),
	@AsignacionMensual		FLOAT,	
	@NumeroFolio			INT,
	@IngresoMensual			FLOAT,
	@IngresoEventual		FLOAT,
	@Denominacion			VARCHAR(150),
	@Observaciones			TEXT
AS 
BEGIN
	
	UPDATE 	dbo.Reingresos	
		SET	
			HClinico			= @HClinico,
			--FechaReingreso		= @FechaReingreso,
			Unidad				= @Unidad,
			Seccion				= @Seccion,
			Codigo				= @Codigo,
			TipoDiscapacidad	= @TipoDiscapacidad,
			Antecedentes		= @Antecedentes,
			RelacionesFamiliares= @RelacionesFamiliares,
			PredisTratamiento	= @PredisTratamiento,
			AsignacionMensual	= @AsignacionMensual,
			IngresoEventual		= @IngresoEventual,
			IngresoMensual		= @IngresoMensual,
			NumeroFolio			= @NumeroFolio,
			Denominacion		= @Denominacion,
			Observaciones		= @Observaciones
			
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroReingreso =@NumeroReingreso
END
GO


DROP PROCEDURE EliminarReingreso
GO

CREATE PROCEDURE EliminarReingreso
	@NumeroPaciente			INT,
	@NumeroReingreso		INT
AS
BEGIN
	
	DELETE FROM dbo.Reingresos
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroReingreso =@NumeroReingreso
END
GO

DROP PROCEDURE ListarReingresos
GO

CREATE PROCEDURE ListarReingresos
AS
BEGIN
	SELECT NumeroPaciente, NumeroReingreso, HClinico, FechaReingreso, Unidad, Seccion, Codigo, TipoDiscapacidad, Antecedentes,
			RelacionesFamiliares, PredisTratamiento, AsignacionMensual, NumeroFolio, IngresoEventual, IngresoMensual, Denominacion, Observaciones
	FROM dbo.Reingresos
	ORDER BY FechaReingreso
END
GO


DROP PROCEDURE ObtenerReingreso
GO

CREATE PROCEDURE ObtenerReingreso
	@NumeroPaciente			INT,
	@NumeroReingreso		INT
AS
BEGIN
	SELECT NumeroPaciente, NumeroReingreso, HClinico, FechaReingreso, Unidad, Seccion, Codigo, TipoDiscapacidad, Antecedentes,
			RelacionesFamiliares, PredisTratamiento, AsignacionMensual, NumeroFolio, IngresoEventual, IngresoMensual, Denominacion, Observaciones
	FROM  dbo.Reingresos
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroReingreso =@NumeroReingreso
END
GO
