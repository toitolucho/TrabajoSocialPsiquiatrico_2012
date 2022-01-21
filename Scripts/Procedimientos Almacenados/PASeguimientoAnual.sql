USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarSeguimientoAnual
GO

CREATE PROCEDURE InsertarSeguimientoAnual
	@NumeroPaciente				INT,
	@SituacionInstitucional		TEXT,
	@RelacionesFamiliares		TEXT,
	@EncomiendasRecibidas		TEXT,
	@InterconsultasRelalizadas	TEXT,
	@GastosAdministrativos		TEXT,
	@TramitesRealizados			TEXT
AS
BEGIN
	INSERT INTO dbo.SeguimientoAnual (NumeroPaciente, SituacionInstitucional, CodigoSeguimientoAnual, 
			RelacionesFamiliares, EncomiendasRecibidas, InterconsultasRelalizadas, GastosAdministrativos, TramitesRealizados)
	VALUES (@NumeroPaciente, @SituacionInstitucional, dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'N'), 
			@RelacionesFamiliares, @EncomiendasRecibidas, @InterconsultasRelalizadas, @GastosAdministrativos, @TramitesRealizados)
END
GO

DROP PROCEDURE ActualizarSeguimientoAnual
GO

CREATE PROCEDURE ActualizarSeguimientoAnual
	@NumeroPaciente				INT,
	@CodigoSeguimientoAnual		INT,
	@SituacionInstitucional		TEXT,
	@RelacionesFamiliares		TEXT,
	@EncomiendasRecibidas		TEXT,
	@InterconsultasRelalizadas	TEXT,
	@GastosAdministrativos		TEXT,
	@TramitesRealizados			TEXT
AS 
BEGIN
	
	UPDATE 	dbo.SeguimientoAnual	
		SET	
			SituacionInstitucional		= @SituacionInstitucional,
			RelacionesFamiliares		= @RelacionesFamiliares,
			EncomiendasRecibidas		= @EncomiendasRecibidas,
			InterconsultasRelalizadas	= @InterconsultasRelalizadas,
			GastosAdministrativos		= @GastosAdministrativos,
			TramitesRealizados			= @TramitesRealizados
			
	WHERE CodigoSeguimientoAnual = @CodigoSeguimientoAnual
	AND NumeroPaciente  = @NumeroPaciente
END
GO


DROP PROCEDURE EliminarSeguimientoAnual
GO

CREATE PROCEDURE EliminarSeguimientoAnual
	@NumeroPaciente				INT,
	@CodigoSeguimientoAnual		INT
AS
BEGIN
	
	DELETE FROM dbo.SeguimientoAnual
	WHERE CodigoSeguimientoAnual = @CodigoSeguimientoAnual
	AND NumeroPaciente  = @NumeroPaciente
END
GO

DROP PROCEDURE ListarSeguimientoAnuales
GO

CREATE PROCEDURE ListarSeguimientoAnuales
AS
BEGIN
	SELECT NumeroPaciente, CodigoSeguimientoAnual, SituacionInstitucional, FechaHoraRegistro,
			RelacionesFamiliares, EncomiendasRecibidas, InterconsultasRelalizadas, GastosAdministrativos, TramitesRealizados
	FROM dbo.SeguimientoAnual
	ORDER BY CodigoSeguimientoAnual
END
GO


DROP PROCEDURE ObtenerSeguimientoAnual
GO

CREATE PROCEDURE ObtenerSeguimientoAnual
	@NumeroPaciente				INT,
	@CodigoSeguimientoAnual		INT
AS
BEGIN
	SELECT NumeroPaciente, CodigoSeguimientoAnual, SituacionInstitucional, FechaHoraRegistro,
			RelacionesFamiliares, EncomiendasRecibidas, InterconsultasRelalizadas, GastosAdministrativos, TramitesRealizados			
	FROM  dbo.SeguimientoAnual
	WHERE CodigoSeguimientoAnual = @CodigoSeguimientoAnual
	AND NumeroPaciente  = @NumeroPaciente
END
GO


