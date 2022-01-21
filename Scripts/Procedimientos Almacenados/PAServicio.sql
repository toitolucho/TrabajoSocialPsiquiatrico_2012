USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarServicio
GO

CREATE PROCEDURE InsertarServicio
	@NombreServicio	 VARCHAR(80),
    @Precio          FLOAT,
    @Descripcion	 VARCHAR(300)
    
AS
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS(SELECT * FROM Servicios WHERE NombreServicio = @NombreServicio))
	BEGIN
		RAISERROR('EL NOMBRE DEL SERVICIO YA SE ENCUENTRA REGISTRADO',16,2)
	END
	ELSE
		INSERT INTO Servicios(NombreServicio,Precio,Descripcion)
		VALUES (@NombreServicio, @Precio, @Descripcion)
	
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO

DROP PROCEDURE ActualizarServicio
GO

CREATE PROCEDURE ActualizarServicio
	@CodigoServicio	INT,
	@NombreServicio	VARCHAR(80),
    @Precio         FLOAT,
    @Descripcion    VARCHAR(300)
AS 
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS (SELECT * FROM Servicios WHERE NombreServicio = @NombreServicio AND CodigoServicio <> @CodigoServicio))
	BEGIN
		RAISERROR ('EL CODIGO DEL SERVICIO NO SE ENCUENTRA REGISTRADO',16, 2)
	END
	ELSE
		UPDATE Servicios
			SET	 NombreServicio = @NombreServicio,
                 Precio = @Precio,
                 Descripcion = @Descripcion
		WHERE CodigoServicio = @CodigoServicio
		
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO ACTUALIZAR CORRECTAMENTE LOS DATOS DEL SERVICIO',16,2)
	END
	ELSE
		COMMIT TRANSACTION	
END
GO


DROP PROCEDURE EliminarServicio
GO

CREATE PROCEDURE EliminarServicio
	@CodigoServicio	INT
AS
BEGIN
	DELETE FROM Servicios
	WHERE CodigoServicio = @CodigoServicio
END
GO

DROP PROCEDURE ListarServicios
GO

CREATE PROCEDURE ListarServicios
AS
BEGIN
	SELECT CodigoServicio,NombreServicio,Precio,Descripcion
	FROM Servicios
	ORDER BY NombreServicio
END
GO


DROP PROCEDURE ObtenerServicio
GO

CREATE PROCEDURE ObtenerServicio
	@CodigoServicio	INT
AS
BEGIN
	SELECT CodigoServicio,NombreServicio, Precio,Descripcion
	FROM  Servicios
	WHERE CodigoServicio = @CodigoServicio
END
GO
