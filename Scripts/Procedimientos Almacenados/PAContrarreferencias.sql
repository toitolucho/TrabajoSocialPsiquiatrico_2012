USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarContrarreferencia
GO

CREATE PROCEDURE InsertarContrarreferencia
	@NumeroPaciente			INT,
	@NumeroReferencia		INT,
	@FechaContrarreferencia DATETIME,
	@NombreMedicoAtendio	VARCHAR(150),
	@Observaciones			TEXT
AS
BEGIN
	INSERT INTO dbo.Contrarreferencias (NumeroPaciente, NumeroReferencia, NumeroContrarreferencia, FechaContrarreferencia, NombreMedicoAtendio, Observaciones)
	VALUES (@NumeroPaciente, @NumeroReferencia, dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'C'), @FechaContrarreferencia, @NombreMedicoAtendio, @Observaciones)
END
GO

DROP PROCEDURE ActualizarContrarreferencia
GO

CREATE PROCEDURE ActualizarContrarreferencia
	@NumeroPaciente			INT,
	@NumeroReferencia		INT,
	@NumeroContrarreferencia INT,
	@FechaContrarreferencia DATETIME,
	@NombreMedicoAtendio	VARCHAR(150),
	@Observaciones			TEXT
AS 
BEGIN
	
	IF( EXISTS(SELECT * FROM Contrarreferencias WHERE NumeroContrarreferencia = @NumeroContrarreferencia
	AND NumeroReferencia = @NumeroReferencia))
	BEGIN
		UPDATE 	dbo.Contrarreferencias	
			SET	
				FechaContrarreferencia = @FechaContrarreferencia,
				NombreMedicoAtendio	   = @NombreMedicoAtendio,
				Observaciones		   = @Observaciones
				
		WHERE NumeroPaciente = @NumeroPaciente
		AND NumeroReferencia = @NumeroReferencia
		AND NumeroContrarreferencia = @NumeroContrarreferencia
	END
	ELSE
	BEGIN
		EXEC DBO.InsertarContrarreferencia @NumeroPaciente, @NumeroReferencia, @FechaContrarreferencia, @NombreMedicoAtendio, @Observaciones
	END
	
END
GO


DROP PROCEDURE EliminarContrarreferencia
GO

CREATE PROCEDURE EliminarContrarreferencia
	@NumeroPaciente			INT,
	@NumeroReferencia		INT,
	@NumeroContrarreferencia INT
AS
BEGIN
	
	DELETE FROM dbo.Contrarreferencias
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroReferencia = @NumeroReferencia
	AND NumeroContrarreferencia = @NumeroContrarreferencia
END
GO

DROP PROCEDURE ListarContrarreferencias
GO

CREATE PROCEDURE ListarContrarreferencias
AS
BEGIN
	SELECT NumeroPaciente, NumeroReferencia, NumeroContrarreferencia, FechaContrarreferencia, NombreMedicoAtendio, Observaciones
	FROM dbo.Contrarreferencias
	ORDER BY FechaContrarreferencia
END
GO


DROP PROCEDURE ObtenerContrarreferencia
GO

CREATE PROCEDURE ObtenerContrarreferencia
	@NumeroPaciente			INT,
	@NumeroReferencia		INT,
	@NumeroContrarreferencia INT
AS
BEGIN
	SELECT NumeroPaciente, NumeroReferencia, NumeroContrarreferencia, FechaContrarreferencia, NombreMedicoAtendio, Observaciones
	FROM  dbo.Contrarreferencias
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroReferencia = @NumeroReferencia
	AND NumeroContrarreferencia = @NumeroContrarreferencia
END
GO
