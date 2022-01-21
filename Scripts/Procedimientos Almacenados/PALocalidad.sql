USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarLocalidad
GO

CREATE PROCEDURE InsertarLocalidad
	  @CodigoPais          CHAR(2),
      @CodigoDepartamento  CHAR(2),    
      @CodigoProvincia     CHAR(2),
      @CodigoLocalidad     CHAR(2),
      @NombreLocalidad     VARCHAR(150)
    
AS
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS(SELECT * FROM dbo.Localidades WHERE NombreLocalidad = @NombreLocalidad))
	BEGIN
		RAISERROR('EL NOMBRE DE LA LOCALIDAD YA SE ENCUENTRA REGISTRADO',16,2)
	END
	ELSE
		INSERT INTO dbo.Localidades(CodigoPais, CodigoDepartamento,CodigoProvincia,CodigoLocalidad,NombreLocalidad)
		VALUES (@CodigoPais, @CodigoDepartamento,@CodigoProvincia,@CodigoLocalidad,@NombreLocalidad)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO

DROP PROCEDURE ActualizarLocalidad
GO

CREATE PROCEDURE ActualizarLocalidad
	@CodigoPais 	        CHAR (2),
	@CodigoDepartamento	    CHAR (2),
    @CodigoProvincia        CHAR (2),
    @CodigoLocalidad        CHAR (2),
    @NombreLocalidad        VARCHAR(150)

AS 
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS (SELECT * FROM dbo.Localidades WHERE NombreLocalidad = @NombreLocalidad AND CodigoLocalidad <> @CodigoLocalidad))
	BEGIN
		RAISERROR ('EL CODIGO DE LOCALIDAD NO SE ENCUENTRA REGISTRADO',16, 2)
	END
	ELSE
		 UPDATE  dbo.Localidades
			SET	 NombreLocalidad = @NombreLocalidad
          
		WHERE (CodigoPais = @CodigoPais) AND (CodigoDepartamento = @CodigoDepartamento)
              AND(CodigoProvincia = @CodigoProvincia)AND(CodigoLocalidad = @CodigoLocalidad)
		
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO ACTUALIZAR EL NOMBRE DE LA LOCALIDAD',16,2)
	END
	ELSE
		COMMIT TRANSACTION	
END
GO


DROP PROCEDURE EliminarLocalidad
GO

CREATE PROCEDURE EliminarLocalidad
	@CodigoPais	         CHAR(2),
    @CodigoDepartamento  CHAR(2),
    @CodigoProvincia     CHAR(2),
    @CodigoLocalidad     CHAR(2)
AS
BEGIN
	
	DELETE FROM dbo.Localidades
	WHERE (CodigoPais = @CodigoPais)AND 
          (CodigoDepartamento = @CodigoDepartamento)AND
          (CodigoProvincia = @CodigoProvincia)AND 
          (CodigoLocalidad = @CodigoLocalidad)
END
GO

DROP PROCEDURE ListarLocalidades
GO

CREATE PROCEDURE ListarLocalidades
AS
BEGIN
	SELECT CodigoPais, CodigoDepartamento, CodigoProvincia,CodigoLocalidad,NombreLocalidad   
	FROM   dbo.Localidades
    ORDER BY CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLocalidad 
END
GO


DROP PROCEDURE ObtenerLocalidad
GO

CREATE PROCEDURE  ObtenerLocalidad
	@CodigoPais	           CHAR(2),
    @CodigoDepartamento    CHAR(2),
    @CodigoProvincia       CHAR(2),
    @CodigoLocalidad       CHAR(2)

AS
BEGIN
	SELECT CodigoPais,CodigoDepartamento,CodigoProvincia,CodigoLocalidad,NombreLocalidad    
	FROM  dbo.Localidades
	WHERE (CodigoPais = @CodigoPais)AND 
          (CodigoDepartamento = @CodigoDepartamento)AND
          (CodigoProvincia=@CodigoProvincia)AND
          (CodigoLocalidad = @CodigoLocalidad)
END
GO



DROP PROCEDURE ObtenerLocalidadPorProvincia
GO

CREATE PROCEDURE ObtenerLocalidadPorProvincia
        @CodigoPais				CHAR(2),
        @CodigoDepartamento     CHAR(2),
        @CodigoProvincia        CHAR(2)
AS
    SELECT CodigoPais, CodigoDepartamento,CodigoProvincia,CodigoLocalidad,NombreLocalidad
    FROM dbo.Localidades    
	WHERE CodigoPais = @CodigoPais AND 
	CodigoDepartamento = @CodigoDepartamento AND 
	CodigoProvincia = @CodigoProvincia
	ORDER BY NombreLocalidad
GO