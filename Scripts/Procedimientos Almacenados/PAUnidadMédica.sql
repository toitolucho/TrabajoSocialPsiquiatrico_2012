USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarUnidadMedica
GO

CREATE PROCEDURE InsertarUnidadMedica
	@NombreUnidadMedica        VARCHAR(150),
    @DireccionUnidadMedica     VARCHAR(100),
    @TelefonoUnidadMedica	   VARCHAR(12),
    @CodigoTipoUnidadMedica		CHAR(1),
    @Descripcion               VARCHAR(300)
    
AS
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS(SELECT * FROM UnidadesMedicas WHERE NombreUnidadMedica = @NombreUnidadMedica))
	BEGIN
		RAISERROR('EL NOMBRE DE LA UNIDAD MÉDICA YA SE ENCUENTRA REGISTRADO',16,2)
	END
	ELSE
		INSERT INTO UnidadesMedicas(NombreUnidadMedica,DireccionUnidadMedica,TelefonoUnidadMedica, CodigoTipoUnidadMedica, Descripcion)
		VALUES (@NombreUnidadMedica,@DireccionUnidadMedica,@TelefonoUnidadMedica, @CodigoTipoUnidadMedica, @Descripcion)
	
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO

DROP PROCEDURE ActualizarUnidadMedica
GO

CREATE PROCEDURE ActualizarUnidadMedica
	@CodigoUnidadMedica	     INT,
	@NombreUnidadMedica	     VARCHAR(150),
    @DireccionUnidadMedica   VARCHAR(100),
    @TelefonoUnidadMedica    VARCHAR(12),
    @CodigoTipoUnidadMedica	 CHAR(1),
    @Descripcion             VARCHAR(300)
AS 
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS (SELECT * FROM UnidadesMedicas WHERE NombreUnidadMedica = @NombreUnidadMedica AND CodigoUnidadMedica <> @CodigoUnidadMedica))
	BEGIN
		RAISERROR ('EL NOMBRE DE LA UNIDAD MÉDICA NO SE ENCUENTRA REGISTRADO',16, 2)
	END
	ELSE
		UPDATE UnidadesMedicas
			SET	 NombreUnidadMedica = @NombreUnidadMedica,
                 DireccionUnidadMedica = @DireccionUnidadMedica,
                 TelefonoUnidadMedica = @TelefonoUnidadMedica,
                 CodigoTipoUnidadMedica = @CodigoTipoUnidadMedica,
                 Descripcion = @Descripcion
		WHERE CodigoUnidadMedica = @CodigoUnidadMedica
		
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO ACTUALIZAR CORRECTAMENTE LOS DATOS DE LA UNIDAD MÉDICA',16,2)
	END
	ELSE
		COMMIT TRANSACTION	
END
GO


DROP PROCEDURE EliminarUnidadMedica
GO

CREATE PROCEDURE EliminarUnidadMedica
	@CodigoUnidadMedica	INT
AS
BEGIN
	
	DELETE FROM UnidadesMedicas
	WHERE CodigoUnidadMedica = @CodigoUnidadMedica
END
GO

DROP PROCEDURE ListarUnidadesMedicas
GO

CREATE PROCEDURE ListarUnidadesMedicas
AS
BEGIN
	SELECT CodigoUnidadMedica,NombreUnidadMedica,DireccionUnidadMedica,TelefonoUnidadMedica,CodigoTipoUnidadMedica,Descripcion  
	FROM UnidadesMedicas
	ORDER BY CodigoUnidadMedica
END
GO


DROP PROCEDURE ObtenerUnidadMedica
GO

CREATE PROCEDURE ObtenerUnidadMedica
	@CodigoUnidadMedica	INT
AS
BEGIN
	SELECT CodigoUnidadMedica,NombreUnidadMedica,DireccionUnidadMedica,TelefonoUnidadMedica, CodigoTipoUnidadMedica, Descripcion
	FROM  UnidadesMedicas
	WHERE CodigoUnidadMedica = @CodigoUnidadMedica
END
GO

--update UnidadesMedicas set CodigoTipoUnidadMedica ='I'
