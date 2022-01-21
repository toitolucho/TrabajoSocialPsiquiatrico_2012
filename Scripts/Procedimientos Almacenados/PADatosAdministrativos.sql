USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarDatosAdministrativos
GO

CREATE PROCEDURE InsertarDatosAdministrativos
	@NumeroPaciente				INT,
	@AsignacionMensual			FLOAT,
	@Gratuito					BIT,
	@Medicacion					VARCHAR(60),
	@PasajeRetorno				FLOAT,
	@DerechoInternacion			FLOAT,
	@Laboratorio				FLOAT,
	@Otros						VARCHAR(100),
	@Cancela					CHAR(1),
	@PacienteInstitucionalizado CHAR(1)
AS
BEGIN
	INSERT INTO dbo.DatosAdministrativos (NumeroPaciente, AsignacionMensual, Gratuito, Medicacion, PasajeRetorno, DerechoInternacion, Laboratorio, Otros, Cancela, PacienteInstitucionalizado)
	VALUES (@NumeroPaciente, @AsignacionMensual, @Gratuito, @Medicacion, @PasajeRetorno, @DerechoInternacion, @Laboratorio, @Otros, @Cancela, @PacienteInstitucionalizado)
END
GO

DROP PROCEDURE ActualizarDatosAdministrativos
GO

CREATE PROCEDURE ActualizarDatosAdministrativos
	@NumeroPaciente				INT,
	@AsignacionMensual			FLOAT,
	@Gratuito					BIT,
	@Medicacion					VARCHAR(60),
	@PasajeRetorno				FLOAT,
	@DerechoInternacion			FLOAT,
	@Laboratorio				FLOAT,
	@Otros						VARCHAR(100),
	@Cancela					CHAR(1),
	@PacienteInstitucionalizado CHAR(1)
AS 
BEGIN
	
	UPDATE 	dbo.DatosAdministrativos	
		SET	
			AsignacionMensual			= @AsignacionMensual,
			Gratuito					= @Gratuito,
			Medicacion					= @Medicacion,
			PasajeRetorno				= @PasajeRetorno,
			DerechoInternacion			= @DerechoInternacion,
			Laboratorio					= @Laboratorio,
			Otros						= @Otros,
			Cancela						= @Cancela,
			PacienteInstitucionalizado	= @PacienteInstitucionalizado
			
	WHERE NumeroPaciente = @NumeroPaciente
END
GO


DROP PROCEDURE EliminarDatosAdministrativos
GO

CREATE PROCEDURE EliminarDatosAdministrativos
	@NumeroPaciente	INT
AS
BEGIN
	
	DELETE FROM dbo.DatosAdministrativos
	WHERE NumeroPaciente = @NumeroPaciente
END
GO

DROP PROCEDURE ListarDatosAdministrativos
GO

CREATE PROCEDURE ListarDatosAdministrativos
AS
BEGIN
	SELECT NumeroPaciente, AsignacionMensual, Gratuito, Medicacion, PasajeRetorno, DerechoInternacion, Laboratorio, Otros, Cancela, PacienteInstitucionalizado
	FROM dbo.DatosAdministrativos
	ORDER BY NumeroPaciente
END
GO


DROP PROCEDURE ObtenerDatosAdministrativos
GO

CREATE PROCEDURE ObtenerDatosAdministrativos
	@NumeroPaciente	INT
AS
BEGIN
	SELECT NumeroPaciente, AsignacionMensual, Gratuito, Medicacion, PasajeRetorno, DerechoInternacion, Laboratorio, Otros, Cancela, PacienteInstitucionalizado
	FROM  dbo.DatosAdministrativos
	WHERE NumeroPaciente = @NumeroPaciente
END
GO
