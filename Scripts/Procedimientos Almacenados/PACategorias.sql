USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarCategoria
GO

CREATE PROCEDURE InsertarCategoria
	@NombreCategoria			CHAR(1),
	@AporteUsuario				INT,
	@SubvencionInstitucional	INT,
	@PuntajeMinimo				INT,
	@PuntajeMaximo				INT
AS
BEGIN
	INSERT INTO dbo.Categorias (NombreCategoria, AporteUsuario, SubvencionInstitucional, PuntajeMinimo, PuntajeMaximo)
	VALUES (@NombreCategoria, @AporteUsuario, @SubvencionInstitucional, @PuntajeMinimo, @PuntajeMaximo)
END
GO

DROP PROCEDURE ActualizarCategoria
GO

CREATE PROCEDURE ActualizarCategoria
	@CodigoCategoria			INT,
	@NombreCategoria			CHAR(1),
	@AporteUsuario				INT,
	@SubvencionInstitucional	INT,
	@PuntajeMinimo				INT,
	@PuntajeMaximo				INT
AS 
BEGIN
	
	UPDATE 	dbo.Categorias	
		SET	
			NombreCategoria			= @NombreCategoria,
			AporteUsuario			= @AporteUsuario,
			SubvencionInstitucional	= @SubvencionInstitucional,
			PuntajeMinimo			= @PuntajeMinimo,
			PuntajeMaximo			= @PuntajeMaximo
	WHERE CodigoCategoria = @CodigoCategoria
END
GO


DROP PROCEDURE EliminarCategoria
GO

CREATE PROCEDURE EliminarCategoria
	@CodigoCategoria	INT
AS
BEGIN
	
	DELETE FROM dbo.Categorias
	WHERE CodigoCategoria = @CodigoCategoria
END
GO

DROP PROCEDURE ListarCategorias
GO

CREATE PROCEDURE ListarCategorias
AS
BEGIN
	SELECT CodigoCategoria, NombreCategoria, AporteUsuario, SubvencionInstitucional, PuntajeMinimo, PuntajeMaximo
	FROM dbo.Categorias
	ORDER BY NombreCategoria
END
GO


DROP PROCEDURE ObtenerCategoria
GO

CREATE PROCEDURE ObtenerCategoria
	@CodigoCategoria	INT
AS
BEGIN
	SELECT CodigoCategoria, NombreCategoria, AporteUsuario, SubvencionInstitucional, PuntajeMinimo, PuntajeMaximo
	FROM  dbo.Categorias
	WHERE CodigoCategoria = @CodigoCategoria
END
GO
