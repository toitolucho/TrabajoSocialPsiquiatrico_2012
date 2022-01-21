USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarActividadeTipo
GO

CREATE PROCEDURE InsertarActividadeTipo
	
       @NombreActividad VARCHAR(150),
       @Descripcion VARCHAR(300),
       @CodigoClaseActividad	CHAR(1)
AS
BEGIN
    BEGIN TRANSACTION
    IF (EXISTS(SELECT * FROM ActividadesTipo WHERE NombreActividad = @NombreActividad))
    BEGIN
        RAISERROR('EL NOMBRE DE LA ACTIVIDAD YA SE ENCUENTRA REGISTRADO',16,2)
    END
    ELSE
        INSERT INTO dbo.ActividadesTipo (NombreActividad,Descripcion, CodigoClaseActividad)
        VALUES (@NombreActividad,@Descripcion, @CodigoClaseActividad)
    IF (@@ERROR <> 0)
    BEGIN
        ROLLBACK TRANSACTION
        RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
    END
    ELSE
        COMMIT TRANSACTION
END
GO

--EXEC InsertarActividadeTipo 'ACTIVI','DES'

DROP PROCEDURE ActualizarActividadeTipo
GO

CREATE PROCEDURE ActualizarActividadeTipo
      
	@CodigoActividadTipo  INT,
    @NombreActividad      VARCHAR(150),
    @Descripcion          VARCHAR(300),
    @CodigoClaseActividad	CHAR(1)
AS
BEGIN
	BEGIN TRANSACTION
    IF (EXISTS (SELECT * FROM ActividadesTipo WHERE NombreActividad = @NombreActividad AND CodigoActividadTipo <> @CodigoActividadTipo))
    BEGIN
       RAISERROR ('EL CODIGO DEL TIPO DE ACTIVIDAD NO SE ENCUENTRA REGISTRADO',16,2)
    END
    ELSE
       UPDATE dbo.ActividadesTipo
          SET NombreActividad = @NombreActividad,
              Descripcion = @Descripcion,
              CodigoClaseActividad = @CodigoClaseActividad
          WHERE (CodigoActividadTipo = @CodigoActividadTipo)
    IF (@@ERROR <> 0)
    BEGIN
       ROLLBACK
       RAISERROR ('NO SE PUDO ACTUALIZAR CORRECTAMENTE EL TIPO DE ACTIVIDAD',16,2)
    END
    ELSE
		COMMIT TRANSACTION	
END
GO



DROP PROCEDURE EliminarActividadeTipo
GO

CREATE PROCEDURE EliminarActividadeTipo 
    @CodigoActividadTipo    INT
AS
BEGIN
    DELETE FROM dbo.ActividadesTipo
    WHERE CodigoActividadTipo = @CodigoActividadTipo
END
GO



DROP PROCEDURE ListarActividadesTipo
GO

CREATE PROCEDURE ListarActividadesTipo
AS
BEGIN
     SELECT CodigoActividadTipo,NombreActividad,Descripcion, CodigoClaseActividad
     FROM dbo.ActividadesTipo
     ORDER BY NombreActividad
END
GO


DROP PROCEDURE ListarActividadesTipoPorClase
GO

CREATE PROCEDURE ListarActividadesTipoPorClase
	@CodigoClaseActividad	CHAR(1)
AS
BEGIN
     SELECT CodigoActividadTipo,NombreActividad,Descripcion, CodigoClaseActividad
     FROM dbo.ActividadesTipo
     WHERE CodigoClaseActividad = @CodigoClaseActividad
     ORDER BY NombreActividad
END
GO


DROP PROCEDURE ObtenerActividadeTipo
GO

CREATE PROCEDURE ObtenerActividadeTipo
	@CodigoActividadTipo	INT
AS
BEGIN
	SELECT CodigoActividadTipo, NombreActividad,Descripcion, CodigoClaseActividad
	FROM ActividadesTipo
	WHERE CodigoActividadTipo = @CodigoActividadTipo
END
GO

