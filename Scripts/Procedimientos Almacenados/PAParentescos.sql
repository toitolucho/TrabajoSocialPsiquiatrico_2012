USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarParentesco
GO

CREATE PROCEDURE InsertarParentesco
	@NombreParentesco			VARCHAR(100),
	@Descripcion				VARCHAR(300)
AS
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS(SELECT * FROM Parentescos WHERE NombreParentesco = @NombreParentesco))
	BEGIN
		RAISERROR('EL NOMBRE DEL PARENTESCO YA SE ENCUENTRA REGISTRADO',16,2)
	END
	ELSE
		INSERT INTO Parentescos(NombreParentesco,Descripcion)
		VALUES (@NombreParentesco,@Descripcion)
	
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO

DROP PROCEDURE ActualizarParentesco
GO

CREATE PROCEDURE ActualizarParentesco
	@CodigoParentesco			INT,
	@NombreParentesco			VARCHAR(100),
	@Descripcion				VARCHAR(300)
AS 
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS (SELECT * FROM Parentescos WHERE NombreParentesco = @NombreParentesco AND CodigoParentesco <> @CodigoParentesco))
	BEGIN
		RAISERROR ('EL CODIGO DE PARENTESCO NO SE ENCUENTRA REGISTRADO',16, 2)
	END
	ELSE
		UPDATE   Parentescos
			SET	 NombreParentesco = @NombreParentesco,
                 Descripcion = @Descripcion
		WHERE CodigoParentesco = @CodigoParentesco
		
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO ACTUALIZAR CORRECTAMENTE LOS DATOS DE PARENTESCO',16,2)
	END
	ELSE
		COMMIT TRANSACTION	
END
GO


DROP PROCEDURE EliminarParentesco
GO

CREATE PROCEDURE EliminarParentesco
	@CodigoParentesco	INT
AS
BEGIN
	
	DELETE FROM dbo.Parentescos
	WHERE CodigoParentesco = @CodigoParentesco
END
GO

DROP PROCEDURE ListarParentescos
GO

CREATE PROCEDURE ListarParentescos
AS
BEGIN
	SELECT CodigoParentesco, NombreParentesco, Descripcion
	FROM dbo.Parentescos
	ORDER BY NombreParentesco
END
GO


DROP PROCEDURE ObtenerParentesco
GO

CREATE PROCEDURE ObtenerParentesco
	@CodigoParentesco	INT
AS
BEGIN
	SELECT CodigoParentesco, NombreParentesco, Descripcion
	FROM  dbo.Parentescos
	WHERE CodigoParentesco = @CodigoParentesco
END
GO
