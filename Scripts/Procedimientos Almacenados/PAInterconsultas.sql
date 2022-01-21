USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarInterconsulta
GO

CREATE PROCEDURE InsertarInterconsulta
	@NumeroReferencia	INT,
	@NumeroPaciente		INT,
	@FechaInterconsulta DATETIME,	
	@Tramite			VARCHAR(50),
	@MedicoSolicitante	VARCHAR(80)
AS
BEGIN
	INSERT INTO dbo.Interconsultas (NumeroPaciente, NumeroReferencia, FechaInterconsulta, Tramite, MedicoSolicitante)
	VALUES (@NumeroPaciente, @NumeroReferencia, @FechaInterconsulta, @Tramite, @MedicoSolicitante)
END
GO

DROP PROCEDURE ActualizarInterconsulta
GO

CREATE PROCEDURE ActualizarInterconsulta
	@NumeroReferencia	INT,
	@NumeroPaciente		INT,
	@FechaInterconsulta DATETIME,	
	@Tramite			VARCHAR(50),
	@MedicoSolicitante	VARCHAR(80)
AS 
BEGIN
	
	UPDATE 	dbo.Interconsultas	
		SET	
			FechaInterconsulta = @FechaInterconsulta ,
			Tramite			   = @Tramite,
			MedicoSolicitante  = @MedicoSolicitante		
			
	WHERE NumeroReferencia = @NumeroReferencia
	AND NumeroPaciente = @NumeroPaciente
END
GO


DROP PROCEDURE EliminarInterconsulta
GO

CREATE PROCEDURE EliminarInterconsulta
	@NumeroReferencia	INT,
	@NumeroPaciente		INT
AS
BEGIN
	
	DELETE FROM dbo.Interconsultas
	WHERE NumeroReferencia = @NumeroReferencia
	AND NumeroPaciente = @NumeroPaciente
END
GO

DROP PROCEDURE ListarInterconsultas
GO

CREATE PROCEDURE ListarInterconsultas
AS
BEGIN
	SELECT NumeroReferencia, NumeroPaciente, FechaInterconsulta, Tramite, MedicoSolicitante
	FROM dbo.Interconsultas
	ORDER BY FechaInterconsulta
END
GO


DROP PROCEDURE ObtenerInterconsulta
GO

CREATE PROCEDURE ObtenerInterconsulta
	@NumeroReferencia	INT,
	@NumeroPaciente		INT
AS
BEGIN
	SELECT NumeroReferencia, NumeroPaciente, FechaInterconsulta, Tramite, MedicoSolicitante
	FROM  dbo.Interconsultas
	WHERE NumeroReferencia = @NumeroReferencia
	AND NumeroPaciente = @NumeroPaciente
END
GO
