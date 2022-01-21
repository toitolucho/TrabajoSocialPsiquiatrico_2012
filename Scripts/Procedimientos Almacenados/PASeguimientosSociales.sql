USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarSeguimientoSocial
GO

CREATE PROCEDURE InsertarSeguimientoSocial
	@NumeroPaciente				INT,
	@FechaSSocial				DATETIME,
	@Observaciones				TEXT,
	@RecibioEncomienda			BIT,
	@RealizoTramite				BIT,
	@PacienteDefuncion			BIT,
	@PacienteDadoAlta			BIT,
	@PacienteInstitucionalizo	BIT
AS
BEGIN
	INSERT INTO dbo.SeguimientosSociales (NumeroPaciente, NumeroSeguimientoSocial, FechaSSocial, Observaciones, RecibioEncomienda, RealizoTramite, PacienteDefuncion, PacienteDadoAlta, PacienteInstitucionalizo)
	VALUES (@NumeroPaciente, dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'S'), @FechaSSocial, @Observaciones, @RecibioEncomienda, @RealizoTramite, @PacienteDefuncion, @PacienteDadoAlta, @PacienteInstitucionalizo)
END
GO

DROP PROCEDURE ActualizarSeguimientoSocial
GO

CREATE PROCEDURE ActualizarSeguimientoSocial
	@NumeroPaciente				INT,
	@NumeroSeguimientoSocial	INT,	
	@FechaSSocial				DATETIME,
	@Observaciones				TEXT,
	@RecibioEncomienda			BIT,
	@RealizoTramite				BIT,
	@PacienteDefuncion			BIT,
	@PacienteDadoAlta			BIT,
	@PacienteInstitucionalizo	BIT
AS 
BEGIN
	
	UPDATE 	dbo.SeguimientosSociales	
		SET	
			FechaSSocial		= @FechaSSocial,
			Observaciones		= @Observaciones,	
			RecibioEncomienda	= @RecibioEncomienda,
			RealizoTramite		= @RealizoTramite,
			PacienteDefuncion	         = @PacienteDefuncion,
			PacienteDadoAlta			 = @PacienteDadoAlta,
			PacienteInstitucionalizo	 = @PacienteInstitucionalizo
						
	WHERE NumeroPaciente = @NumeroPaciente
	and NumeroSeguimientoSocial = @NumeroSeguimientoSocial
END
GO


DROP PROCEDURE EliminarSeguimientoSocial
GO

CREATE PROCEDURE EliminarSeguimientoSocial
	@NumeroPaciente				INT,
	@NumeroSeguimientoSocial	INT
AS
BEGIN
	
	DELETE FROM dbo.SeguimientosSociales
	WHERE NumeroPaciente = @NumeroPaciente
	and NumeroSeguimientoSocial = @NumeroSeguimientoSocial
END
GO

DROP PROCEDURE ListarSeguimientosSociales
GO

CREATE PROCEDURE ListarSeguimientosSociales
AS
BEGIN
	SELECT NumeroPaciente, NumeroSeguimientoSocial, FechaSSocial, Observaciones, RecibioEncomienda, RealizoTramite, PacienteDefuncion, PacienteDadoAlta, PacienteInstitucionalizo
	FROM dbo.SeguimientosSociales
	ORDER BY FechaSSocial
END
GO


DROP PROCEDURE ObtenerSeguimientoSocial
GO

CREATE PROCEDURE ObtenerSeguimientoSocial
	@NumeroPaciente				INT,
	@NumeroSeguimientoSocial	INT	
AS
BEGIN
	SELECT NumeroPaciente, NumeroSeguimientoSocial, FechaSSocial, Observaciones, RecibioEncomienda, RealizoTramite, PacienteDefuncion, PacienteDadoAlta, PacienteInstitucionalizo
	FROM  dbo.SeguimientosSociales
	WHERE NumeroPaciente = @NumeroPaciente
	and NumeroSeguimientoSocial = @NumeroSeguimientoSocial
END
GO

