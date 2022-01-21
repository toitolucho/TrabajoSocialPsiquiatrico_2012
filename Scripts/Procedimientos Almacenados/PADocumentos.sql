USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarDocumento
GO

CREATE PROCEDURE InsertarDocumento
	@NumeroPaciente			INT,
	@FechaRegistro			DATETIME,
	@TramitoTrabSocial		CHAR(1),
	@CodigoDocumentoTipo	INT
AS
BEGIN
	IF (NOT EXISTS( SELECT * FROM Documentos WHERE NumeroPaciente = @NumeroPaciente AND CodigoDocumentoTipo = @CodigoDocumentoTipo))
	BEGIN
		INSERT INTO dbo.Documentos (NumeroPaciente, NumeroRegistro, FechaRegistro, TramitoTrabSocial, CodigoDocumentoTipo)
		VALUES (@NumeroPaciente, dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'D'), @FechaRegistro, @TramitoTrabSocial, @CodigoDocumentoTipo)	
		
		IF((SELECT TOP(1) NumeroRegistro FROM Documentos WHERE NumeroPaciente = @NumeroPaciente )
		<> (SELECT COUNT(*) FROM Documentos WHERE NumeroPaciente = @NumeroPaciente)
		)
		BEGIN
			UPDATE Documentos
				SET NumeroRegistro = TA.NumeroRegistro
			FROM
			(
				SELECT NumeroPaciente, NumeroDocumento,
						ROW_NUMBER() OVER(ORDER BY NumeroDocumento ASC) AS NumeroRegistro
				FROM  dbo.Documentos F
				WHERE NumeroPaciente = @NumeroPaciente
			)TA
			WHERE Documentos.NumeroPaciente = TA.NumeroPaciente
			AND Documentos.NumeroDocumento = TA.NumeroDocumento
			AND Documentos.NumeroPaciente = @NumeroPaciente
		END
		
	END
	ELSE
	BEGIN
		RAISERROR('NO PUEDE INGRESAR UN DOCUMENTO YA REGISTRADO PARA EL PACIENTE ACTUAL', 17,2)
	END
	
END
GO

DROP PROCEDURE ActualizarDocumento
GO

CREATE PROCEDURE ActualizarDocumento
	@NumeroPaciente			INT,
	@NumeroDocumento		INT,
	@NumeroRegistro			INT,
	@FechaRegistro			DATETIME,
	@TramitoTrabSocial		CHAR(1),
	@CodigoDocumentoTipo	INT
AS 
BEGIN
	
	UPDATE 	dbo.Documentos	
		SET	
			NumeroRegistro		= @NumeroRegistro,
			NumeroPaciente		= @NumeroPaciente,
			FechaRegistro		= @FechaRegistro,
			TramitoTrabSocial	= @TramitoTrabSocial,
			CodigoDocumentoTipo	= @CodigoDocumentoTipo
			
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroDocumento = @NumeroDocumento
END
GO


DROP PROCEDURE EliminarDocumento
GO

CREATE PROCEDURE EliminarDocumento
	@NumeroPaciente			INT,
	@NumeroDocumento		INT
AS
BEGIN
	
	DELETE FROM dbo.Documentos
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroDocumento = @NumeroDocumento
	
	
	
	UPDATE Documentos
		SET NumeroRegistro = TA.NumeroRegistro
	FROM
	(
		SELECT NumeroPaciente, NumeroDocumento,
				ROW_NUMBER() OVER(ORDER BY NumeroDocumento ASC) AS NumeroRegistro
		FROM  dbo.Documentos F
		WHERE NumeroPaciente = @NumeroPaciente
	)TA
	WHERE Documentos.NumeroPaciente = TA.NumeroPaciente
	AND Documentos.NumeroDocumento = TA.NumeroDocumento
	AND Documentos.NumeroPaciente = @NumeroPaciente
	
END
GO

DROP PROCEDURE ListarDocumentos
GO

CREATE PROCEDURE ListarDocumentos
AS
BEGIN
	SELECT	NumeroPaciente, NumeroDocumento, NumeroRegistro, FechaRegistro, TramitoTrabSocial, 
			D.CodigoDocumentoTipo, dbo.ObtenerNumeroHistorialClinicoPaciente(NumeroPaciente) as HClinico,
			DT.NombreDocumento
	FROM dbo.Documentos D
	INNER JOIN dbo.DocumentosTipo DT
	ON D.CodigoDocumentoTipo = DT.CodigoDocumentoTipo
	ORDER BY FechaRegistro
	
END
GO

DROP PROCEDURE ListarDocumentosPaciente
GO

CREATE PROCEDURE ListarDocumentosPaciente
	@NumeroPaciente			INT
AS
BEGIN
	SELECT	NumeroPaciente, NumeroDocumento, NumeroRegistro, FechaRegistro, TramitoTrabSocial, 
			D.CodigoDocumentoTipo, dbo.ObtenerNumeroHistorialClinicoPaciente(NumeroPaciente) as HClinico,
			DT.NombreDocumento
	FROM dbo.Documentos D
	INNER JOIN dbo.DocumentosTipo DT
	ON D.CodigoDocumentoTipo = DT.CodigoDocumentoTipo
	WHERE NumeroPaciente = @NumeroPaciente
	ORDER BY FechaRegistro
END
GO


DROP PROCEDURE ObtenerDocumento
GO

CREATE PROCEDURE ObtenerDocumento
	@NumeroPaciente			INT,
	@NumeroDocumento		INT
AS
BEGIN
	SELECT	NumeroPaciente, NumeroDocumento, NumeroRegistro, FechaRegistro, TramitoTrabSocial, 
			CodigoDocumentoTipo, dbo.ObtenerNumeroHistorialClinicoPaciente(NumeroPaciente) as HClinico
	FROM  dbo.Documentos
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroDocumento = @NumeroDocumento
END
GO