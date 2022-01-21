USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarReferencia
GO

CREATE PROCEDURE InsertarReferencia
	@NumeroPaciente				INT,
	@FechaReferencia			DATETIME,
	@DiagnosticoPsiquiatrico	VARCHAR(150),
	@CodigoMedicoResponsable	INT,
	@CodigoTrabajadorSocial		INT,
	@CodigoUsuario				INT,
	@CodigoTipoReferencia		CHAR(1),
	@CodigoEspecialidad			INT,
	@FechaContraReferencia		DATETIME,
	@ObservacionesContra		TEXT,
	@Observaciones				TEXT
AS
BEGIN
	INSERT INTO dbo.Referencias (NumeroPaciente, NumeroReferencia, FechaReferencia, DiagnosticoPsiquiatrico,  CodigoMedicoResponsable, CodigoTrabajadorSocial, CodigoUsuario, CodigoTipoReferencia, CodigoEspecialidad, Observaciones, FechaContraReferencia, ObservacionesContra)
	VALUES (@NumeroPaciente, dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'E'), @FechaReferencia, @DiagnosticoPsiquiatrico,  @CodigoMedicoResponsable, @CodigoTrabajadorSocial, @CodigoUsuario, @CodigoTipoReferencia, @CodigoEspecialidad, @Observaciones, @FechaContraReferencia, @ObservacionesContra)
END
GO

DROP PROCEDURE ActualizarReferencia
GO

CREATE PROCEDURE ActualizarReferencia
	@NumeroReferencia			INT,
	@NumeroPaciente				INT,
	@FechaReferencia			DATETIME,
	@DiagnosticoPsiquiatrico	VARCHAR(150),
	@CodigoMedicoResponsable	INT,
	@CodigoTrabajadorSocial		INT,
	@CodigoUsuario				INT,
	@CodigoTipoReferencia		CHAR(1),
	@CodigoEspecialidad			INT,
	@FechaContraReferencia		DATETIME,
	@ObservacionesContra		TEXT,
	@Observaciones				TEXT
AS 
BEGIN
	
	UPDATE 	dbo.Referencias	
		SET	
			FechaReferencia			= @FechaReferencia,
			DiagnosticoPsiquiatrico	= @DiagnosticoPsiquiatrico,
			CodigoMedicoResponsable = @CodigoMedicoResponsable,
			CodigoTrabajadorSocial	= @CodigoTrabajadorSocial,
			CodigoUsuario			= @CodigoUsuario,
			CodigoTipoReferencia	= @CodigoTipoReferencia,
			CodigoEspecialidad		= @CodigoEspecialidad,
			Observaciones			= @Observaciones,
			FechaContraReferencia	= @FechaContraReferencia,
			ObservacionesContra		= @ObservacionesContra
	WHERE NumeroReferencia = @NumeroReferencia
	AND NumeroPaciente = @NumeroPaciente
END
GO


DROP PROCEDURE EliminarReferencia
GO

CREATE PROCEDURE EliminarReferencia
	@NumeroReferencia			INT,
	@NumeroPaciente				INT
AS
BEGIN
	DELETE FROM Contrarreferencias
	WHERE NumeroReferencia = @NumeroReferencia
	AND NumeroPaciente = @NumeroPaciente
	
	DELETE FROM dbo.Referencias
	WHERE NumeroReferencia = @NumeroReferencia
	AND NumeroPaciente = @NumeroPaciente
END
GO

DROP PROCEDURE ListarReferencias
GO

CREATE PROCEDURE ListarReferencias
AS
BEGIN
	SELECT NumeroReferencia, NumeroPaciente, FechaReferencia, DiagnosticoPsiquiatrico,  CodigoMedicoResponsable, CodigoTrabajadorSocial, CodigoUsuario, CodigoTipoReferencia, CodigoEspecialidad, Observaciones, FechaContraReferencia, ObservacionesContra
	FROM dbo.Referencias
	ORDER BY FechaReferencia
END
GO


DROP PROCEDURE ObtenerReferencia
GO

CREATE PROCEDURE ObtenerReferencia
	@NumeroReferencia			INT,
	@NumeroPaciente				INT
AS
BEGIN
	SELECT NumeroReferencia, NumeroPaciente, FechaReferencia, DiagnosticoPsiquiatrico,  CodigoMedicoResponsable, CodigoTrabajadorSocial, CodigoUsuario, CodigoTipoReferencia, CodigoEspecialidad, Observaciones, FechaContraReferencia, ObservacionesContra
	FROM  dbo.Referencias
	WHERE NumeroReferencia = @NumeroReferencia
	AND NumeroPaciente = @NumeroPaciente
END
GO
