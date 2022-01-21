USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarDireccion
GO

CREATE PROCEDURE InsertarDireccion
	@NumeroPaciente	INT,
	@ZonaBarrio		VARCHAR(60),
	@CalleAvenida	VARCHAR(60),
	@Numero			INT,
	@Telefono		VARCHAR(12)
AS
BEGIN
	INSERT INTO dbo.Direcciones (NumeroPaciente, ZonaBarrio, CalleAvenida, Numero, Telefono)
	VALUES (@NumeroPaciente, @ZonaBarrio, @CalleAvenida, @Numero, @Telefono)
END
GO

DROP PROCEDURE ActualizarDireccion
GO

CREATE PROCEDURE ActualizarDireccion
	@NumeroPaciente	INT,
	@ZonaBarrio		VARCHAR(60),
	@CalleAvenida	VARCHAR(60),
	@Numero			INT,
	@Telefono		VARCHAR(12)
AS 
BEGIN
	
	UPDATE 	dbo.Direcciones	
		SET	
			ZonaBarrio	 = @ZonaBarrio,
			CalleAvenida = @CalleAvenida,
			Numero		 = @Numero,
			Telefono	 = @Telefono			
	WHERE NumeroPaciente = @NumeroPaciente
END
GO


DROP PROCEDURE EliminarDireccion
GO

CREATE PROCEDURE EliminarDireccion
	@NumeroPaciente	INT
AS
BEGIN
	
	DELETE FROM dbo.Direcciones
	WHERE NumeroPaciente = @NumeroPaciente
END
GO

DROP PROCEDURE ListarDirecciones
GO

CREATE PROCEDURE ListarDirecciones
AS
BEGIN
	SELECT NumeroPaciente, ZonaBarrio, CalleAvenida, Numero, Telefono
	FROM dbo.Direcciones
	ORDER BY ZonaBarrio
END
GO


DROP PROCEDURE ObtenerDireccion
GO

CREATE PROCEDURE ObtenerDireccion
	@NumeroPaciente	INT
AS
BEGIN
	SELECT NumeroPaciente, ZonaBarrio, CalleAvenida, Numero, Telefono
	FROM  dbo.Direcciones
	WHERE NumeroPaciente = @NumeroPaciente
END
GO
