USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarPais
GO

CREATE PROCEDURE InsertarPais
	
       @CodigoPais CHAR(2),
       @NombrePais VARCHAR(150)
AS
BEGIN
    BEGIN TRANSACTION
    IF (EXISTS(SELECT * FROM dbo.Paises WHERE NombrePais = @NombrePais))
    BEGIN
        RAISERROR('EL NOMBRE DEL PAIS YA SE ENCUENTRA REGISTRADO',17,2)
    END
    ELSE
        INSERT INTO dbo.Paises(CodigoPais, NombrePais)
        VALUES (@CodigoPais,@NombrePais)
    IF (@@ERROR <> 0)
    BEGIN
        ROLLBACK
        RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',17,2)
    END
    ELSE
        COMMIT TRANSACTION
END
GO

DROP PROCEDURE ActualizarPais
GO

CREATE PROCEDURE ActualizarPais
    @CodigoPais      CHAR(2),
    @NombrePais      VARCHAR(150)
AS
BEGIN
	BEGIN TRANSACTION
    IF (EXISTS (SELECT * FROM dbo.Paises WHERE NombrePais = @NombrePais AND CodigoPais <> @CodigoPais))
    BEGIN
       RAISERROR ('EL CODIGO DE PAIS NO SE ENCUENTRA REGISTRADO',17,2)
    END
    ELSE
       UPDATE dbo.Paises
          SET NombrePais = @NombrePais
          WHERE (CodigoPais = @CodigoPais)
    IF (@@ERROR <> 0)
    BEGIN
       ROLLBACK
       RAISERROR ('NO SE PUDO ACTUALIZAR CORRECTAMENTE EL NOMBRE DEL PAIS',17,2)
    END
    ELSE
		COMMIT TRANSACTION	
END
GO



DROP PROCEDURE EliminarPais
GO

CREATE PROCEDURE EliminarPais
    @CodigoPais  CHAR(2)
AS
BEGIN
    DELETE FROM dbo.Paises
    WHERE CodigoPais = @CodigoPais
END
GO



DROP PROCEDURE ListarPaises
GO

CREATE PROCEDURE ListarPaises
AS
BEGIN
     SELECT CodigoPais, NombrePais
     FROM Paises
     ORDER BY NombrePais
END
GO



DROP PROCEDURE ObtenerPais
GO

CREATE PROCEDURE ObtenerPais
	@CodigoPais	 CHAR(2)
AS
BEGIN
	SELECT CodigoPais, NombrePais
	FROM Paises
	WHERE CodigoPais = @CodigoPais
END
GO
