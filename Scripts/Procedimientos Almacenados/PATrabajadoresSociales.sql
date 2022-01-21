USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarTrabajadorSocial
GO

CREATE PROCEDURE InsertarTrabajadorSocial
	@NombreTS				VARCHAR(100),
	@ApellidoPaternoTS		VARCHAR(60),
	@ApellidoMaternoTS		VARCHAR(60),
	@Dirección				VARCHAR(70),
	@Telefono				VARCHAR(12),
	@Celular				VARCHAR(12),
	@CodigoUnidadMedica		INT,
	@CodigoOcupacion		TINYINT
AS
BEGIN
	INSERT INTO dbo.TrabajadoresSociales (NombreTS, ApellidoPaternoTS, ApellidoMaternoTS, Dirección, Telefono, Celular, CodigoUnidadMedica, CodigoOcupacion)
	VALUES (@NombreTS, @ApellidoPaternoTS, @ApellidoMaternoTS, @Dirección, @Telefono, @Celular, @CodigoUnidadMedica, @CodigoOcupacion)
END
GO

DROP PROCEDURE ActualizarTrabajadorSocial
GO

CREATE PROCEDURE ActualizarTrabajadorSocial
	@CodigoTrabajadorSocial	INT,
	@NombreTS				VARCHAR(100),
	@ApellidoPaternoTS		VARCHAR(60),
	@ApellidoMaternoTS		VARCHAR(60),
	@Dirección				VARCHAR(70),
	@Telefono				VARCHAR(12),
	@Celular				VARCHAR(12),
	@CodigoUnidadMedica		INT,
	@CodigoOcupacion		TINYINT
AS 
BEGIN
	
	UPDATE 	dbo.TrabajadoresSociales	
		SET	
			NombreTS			= @NombreTS,
			ApellidoPaternoTS	= @ApellidoPaternoTS,
			ApellidoMaternoTS	= @ApellidoMaternoTS,
			Dirección			= @Dirección,
			Telefono			= @Telefono,
			Celular				= @Celular,
			CodigoUnidadMedica	= @CodigoUnidadMedica,
			CodigoOcupacion	= @CodigoOcupacion
	WHERE CodigoTrabajadorSocial = @CodigoTrabajadorSocial
END
GO


DROP PROCEDURE EliminarTrabajadorSocial
GO

CREATE PROCEDURE EliminarTrabajadorSocial
	@CodigoTrabajadorSocial	INT
AS
BEGIN
	
	DELETE FROM dbo.TrabajadoresSociales
	WHERE CodigoTrabajadorSocial = @CodigoTrabajadorSocial
END
GO

DROP PROCEDURE ListarTrabajadoresSociales
GO

CREATE PROCEDURE ListarTrabajadoresSociales
AS
BEGIN
	SELECT CodigoTrabajadorSocial, NombreTS, ApellidoPaternoTS, ApellidoMaternoTS, Dirección, Telefono, Celular, CodigoUnidadMedica, CodigoOcupacion
	FROM dbo.TrabajadoresSociales
	ORDER BY NombreTS
END
GO


DROP PROCEDURE ObtenerTrabajadorSocial
GO

CREATE PROCEDURE ObtenerTrabajadorSocial
	@CodigoTrabajadorSocial	INT
AS
BEGIN
	SELECT CodigoTrabajadorSocial, NombreTS, ApellidoPaternoTS, ApellidoMaternoTS, Dirección, Telefono, Celular, CodigoUnidadMedica, CodigoOcupacion
	FROM  dbo.TrabajadoresSociales
	WHERE CodigoTrabajadorSocial = @CodigoTrabajadorSocial
END
GO
