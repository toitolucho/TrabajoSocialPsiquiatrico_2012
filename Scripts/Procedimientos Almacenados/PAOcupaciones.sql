USE TRABAJO_SOCIAL
GO

DROP PROC InsertarOcupacion
GO
CREATE PROC InsertarOcupacion
@NombreOcupacion	VARCHAR(100),
@Descripcion		TEXT
AS
BEGIN
	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM Ocupaciones WHERE UPPER(RTRIM(LTRIM(NombreOcupacion))) = UPPER(RTRIM(LTRIM(@NombreOcupacion)))))
		INSERT INTO dbo.Ocupaciones (NombreOcupacion, Descripcion)
		VALUES (@NombreOcupacion, @Descripcion)		
	ELSE
		RAISERROR ('EL NOMBRE DEL Ocupacion YA SE ENCUENTRA REGISTRADO',16, 2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16, 2)
	END
	ELSE
		COMMIT TRANSACTION

	
END
GO


DROP PROC EliminarOcupacion
GO
CREATE PROC EliminarOcupacion
@CodigoOcupacion		INT
AS
BEGIN
	DELETE FROM dbo.Ocupaciones
	WHERE CodigoOcupacion= @CodigoOcupacion
END
GO

DROP PROC ActualizarOcupacion
GO
CREATE PROC ActualizarOcupacion
@CodigoOcupacion	INT,
@NombreOcupacion	VARCHAR(100),
@Descripcion		TEXT
AS
BEGIN
	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM dbo.Ocupaciones WHERE UPPER(RTRIM(LTRIM(NombreOcupacion))) = UPPER(RTRIM(LTRIM(@NombreOcupacion))) AND CodigoOcupacion <> @CodigoOcupacion))
		UPDATE dbo.Ocupaciones
			SET NombreOcupacion = @NombreOcupacion,
				Descripcion = @Descripcion
		WHERE CodigoOcupacion = @CodigoOcupacion

	ELSE
		RAISERROR ('EL NOMBRE DEL Ocupacion YA SE ENCUENTRA REGISTRADO',16,2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO

DROP PROC ListarOcupaciones
GO
CREATE PROC ListarOcupaciones
AS
BEGIN
	SELECT CodigoOcupacion, NombreOcupacion, Descripcion
	FROM dbo.Ocupaciones
END
GO

DROP PROC ObtenerOcupacion
GO
CREATE PROC ObtenerOcupacion
@CodigoOcupacion	INT
AS
BEGIN
	SELECT CodigoOcupacion, NombreOcupacion, Descripcion
	FROM dbo.Ocupaciones
	WHERE CodigoOcupacion = @CodigoOcupacion
END
GO