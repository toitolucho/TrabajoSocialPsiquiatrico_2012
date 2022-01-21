USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarMedico
GO

CREATE PROCEDURE InsertarMedico
	@Nombres				VARCHAR(200),
	@ApellidoPaterno		VARCHAR(100),
	@ApellidoMaterno		VARCHAR(100),
	@Dirección				VARCHAR(70),
	@Telefono				VARCHAR(12),
	@Celular				VARCHAR(12)
AS
BEGIN
	INSERT INTO dbo.Medicos (Nombres, ApellidoPaterno, ApellidoMaterno, Dirección, Telefono, Celular)
	VALUES (@Nombres, @ApellidoPaterno, @ApellidoMaterno, @Dirección, @Telefono, @Celular)
END
GO

DROP PROCEDURE ActualizarMedico
GO

CREATE PROCEDURE ActualizarMedico
	@CodigoMedico	INT,
	@Nombres				VARCHAR(100),
	@ApellidoPaterno		VARCHAR(60),
	@ApellidoMaterno		VARCHAR(60),
	@Dirección				VARCHAR(70),
	@Telefono				VARCHAR(12),
	@Celular				VARCHAR(12)
AS 
BEGIN
	
	UPDATE 	dbo.Medicos	
		SET	
			Nombres			= @Nombres,
			ApellidoPaterno	= @ApellidoPaterno,
			ApellidoMaterno	= @ApellidoMaterno,
			Dirección			= @Dirección,
			Telefono			= @Telefono,
			Celular				= @Celular
	WHERE CodigoMedico = @CodigoMedico
END
GO


DROP PROCEDURE EliminarMedico
GO

CREATE PROCEDURE EliminarMedico
	@CodigoMedico	INT
AS
BEGIN
	
	DELETE FROM dbo.Medicos
	WHERE CodigoMedico = @CodigoMedico
END
GO

DROP PROCEDURE ListarMedicos
GO

CREATE PROCEDURE ListarMedicos
AS
BEGIN
	SELECT CodigoMedico, Nombres, ApellidoPaterno, ApellidoMaterno, Dirección, Telefono, Celular, 
	ApellidoPaterno + ' '+ ApellidoMaterno + ' ' + Nombres as NombreCompleto
	FROM dbo.Medicos
	ORDER BY Nombres
END
GO


DROP PROCEDURE ObtenerMedico
GO

CREATE PROCEDURE ObtenerMedico
	@CodigoMedico	INT
AS
BEGIN
	SELECT CodigoMedico, Nombres, ApellidoPaterno, ApellidoMaterno, Dirección, Telefono, Celular,
	ApellidoPaterno + ' '+ ApellidoMaterno + ' ' + Nombres as NombreCompleto
	FROM  dbo.Medicos
	WHERE CodigoMedico = @CodigoMedico
END
GO
