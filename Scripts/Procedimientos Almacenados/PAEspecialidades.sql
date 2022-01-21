USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarEspecialidad
GO

CREATE PROCEDURE InsertarEspecialidad
	@NombreEspecialidad	VARCHAR(150),
	@Descripcion		VARCHAR(300)
AS
BEGIN
	INSERT INTO dbo.Especialidades (NombreEspecialidad, Descripcion)
	VALUES (@NombreEspecialidad, @Descripcion)
END
GO

DROP PROCEDURE ActualizarEspecialidad
GO

CREATE PROCEDURE ActualizarEspecialidad
	@CodigoEspecialidad	INT,
	@NombreEspecialidad	VARCHAR(150),
	@Descripcion			VARCHAR(300)
AS 
BEGIN
	
	UPDATE 	dbo.Especialidades	
		SET	
			NombreEspecialidad	= @NombreEspecialidad,
			Descripcion			= @Descripcion
END
GO


DROP PROCEDURE EliminarEspecialidad
GO

CREATE PROCEDURE EliminarEspecialidad
	@CodigoEspecialidad	INT
AS
BEGIN
	
	DELETE FROM dbo.Especialidades
	WHERE CodigoEspecialidad = @CodigoEspecialidad
END
GO

DROP PROCEDURE ListarEspecialidades
GO

CREATE PROCEDURE ListarEspecialidades
AS
BEGIN
	SELECT CodigoEspecialidad, NombreEspecialidad, Descripcion
	FROM dbo.Especialidades
	ORDER BY NombreEspecialidad
END
GO


DROP PROCEDURE ObtenerEspecialidad
GO

CREATE PROCEDURE ObtenerEspecialidad
	@CodigoEspecialidad	INT
AS
BEGIN
	SELECT CodigoEspecialidad, NombreEspecialidad, Descripcion
	FROM  dbo.Especialidades
	WHERE CodigoEspecialidad = @CodigoEspecialidad
END
GO
