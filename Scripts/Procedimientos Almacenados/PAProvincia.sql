USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarProvincia
GO

CREATE PROCEDURE InsertarProvincia
	  @CodigoPais          CHAR(2),
      @CodigoDepartamento  CHAR(2),    
      @CodigoProvincia     CHAR(2),
      @NombreProvincia     VARCHAR(150)
    
AS
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS(SELECT * FROM dbo.Provincias WHERE NombreProvincia = @NombreProvincia))
	BEGIN
		RAISERROR('EL NOMBRE DE LA PROVINCIA YA SE ENCUENTRA REGISTRADO',16,2)
	END
	ELSE
		INSERT INTO dbo.Provincias(CodigoPais, CodigoDepartamento,CodigoProvincia,NombreProvincia)
		VALUES (@CodigoPais,@CodigoDepartamento,@CodigoProvincia,@NombreProvincia)
	
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO

DROP PROCEDURE ActualizarProvincia
GO

CREATE PROCEDURE ActualizarProvincia
	@CodigoPais 	        CHAR (2),
	@CodigoDepartamento	    CHAR (2),
    @CodigoProvincia        CHAR (2),
    @NombreProvincia        VARCHAR(150)

AS 
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS (SELECT * FROM dbo.Provincias WHERE NombreProvincia = @NombreProvincia AND CodigoProvincia <> @CodigoProvincia))
	BEGIN
		RAISERROR ('EL CODIGO DE PROVINCIA NO SE ENCUENTRA REGISTRADO',16,2)
	END
	ELSE
		UPDATE   dbo.Provincias
			SET	 NombreProvincia = @NombreProvincia
          
		WHERE (CodigoPais = @CodigoPais) AND (CodigoDepartamento = @CodigoDepartamento)
              AND(CodigoProvincia = @CodigoProvincia)
		
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO ACTUALIZAR EL NOMBRE DE PROVINCIA',16,2)
	END
	ELSE
		COMMIT TRANSACTION	
END
GO


DROP PROCEDURE EliminarProvincia
GO

CREATE PROCEDURE EliminarProvincia
	@CodigoPais	         CHAR(2),
    @CodigoDepartamento  CHAR(2),
    @CodigoProvincia     CHAR(2)
AS
BEGIN
	
	DELETE FROM dbo.Provincias
	WHERE (CodigoPais = @CodigoPais)AND (CodigoDepartamento = @CodigoDepartamento)AND
     (CodigoProvincia=@CodigoProvincia)
END
GO

DROP PROCEDURE ListarProvincias
GO

CREATE PROCEDURE ListarProvincias
AS
BEGIN
	SELECT CodigoPais, CodigoDepartamento, CodigoProvincia,NombreProvincia   
	FROM   dbo.Provincias
    ORDER BY CodigoPais, CodigoDepartamento, CodigoProvincia
END
GO


DROP PROCEDURE ObtenerProvincia
GO

CREATE PROCEDURE  ObtenerProvincia
	@CodigoPais	           CHAR(2),
    @CodigoDepartamento    CHAR(2),
    @CodigoProvincia       CHAR(2)

AS
BEGIN
	SELECT CodigoPais,CodigoDepartamento,CodigoProvincia,NombreProvincia   
	FROM  dbo.Provincias
	WHERE (CodigoPais = @CodigoPais)AND (CodigoDepartamento = @CodigoDepartamento)
           AND (CodigoProvincia=@CodigoProvincia)
END
GO



DROP PROCEDURE ObtenerProvinciasPorDepartamento
GO

CREATE PROCEDURE ObtenerProvinciasPorDepartamento
        @CodigoPais				CHAR(2),
        @CodigoDepartamento     CHAR(2)
AS
    SELECT CodigoPais, CodigoDepartamento,CodigoProvincia,NombreProvincia
    FROM dbo.Provincias
WHERE (CodigoPais = @CodigoPais) AND (CodigoDepartamento = @CodigoDepartamento)
GO