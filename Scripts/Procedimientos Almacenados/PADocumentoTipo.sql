USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarDocumentoTipo
GO

CREATE PROCEDURE InsertarDocumentoTipo
	@NombreDocumento	VARCHAR(150),
    @Descripcion        VARCHAR(300)
AS
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS(SELECT * FROM DocumentosTipo WHERE NombreDocumento = @NombreDocumento))
	BEGIN
		RAISERROR('EL NOMBRE DEL DOCUMENTO YA SE ENCUENTRA REGISTRADO',16,2)
	END
	ELSE
		INSERT INTO DocumentosTipo(NombreDocumento, Descripcion)
		VALUES (@NombreDocumento,@Descripcion)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO



DROP PROCEDURE ActualizarDocumentoTipo
GO

CREATE PROCEDURE ActualizarDocumentoTipo
	@CodigoDocumentoTipo  INT,
	@NombreDocumento	  VARCHAR(150),
    @Descripcion          VARCHAR(300)
AS 
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS (SELECT * FROM DocumentosTipo WHERE NombreDocumento = @NombreDocumento AND CodigoDocumentoTipo <> @CodigoDocumentoTipo))
	BEGIN
		RAISERROR ('EL CODIGO DEL TIPO DE DOCUMENTO NO SE ENCUENTRA REGISTRADO',16, 2)
	END
	ELSE
		UPDATE DocumentosTipo
		SET	 NombreDocumento = @NombreDocumento,
             Descripcion = @Descripcion
		WHERE CodigoDocumentoTipo = @CodigoDocumentoTipo
		
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO ACTUALIZAR CORRECTAMENTE EL NOMBRE DEL DOCUMENTO',16,2)
	END
	ELSE
		COMMIT TRANSACTION	
END
GO


DROP PROCEDURE EliminarDocumentoTipo
GO

CREATE PROCEDURE EliminarDocumentoTipo
	@CodigoDocumentoTipo	INT
AS
BEGIN
	DELETE FROM DocumentosTipo
	WHERE CodigoDocumentoTipo = @CodigoDocumentoTipo
END
GO



DROP PROCEDURE ListarDocumentosTipo
GO

CREATE PROCEDURE ListarDocumentosTipo
AS
BEGIN
	SELECT CodigoDocumentoTipo, NombreDocumento,Descripcion
	FROM DocumentosTipo
	ORDER BY CodigoDocumentoTipo
END
GO



DROP PROCEDURE ObtenerDocumentoTipo
GO

CREATE PROCEDURE ObtenerDocumentoTipo
	@CodigoDocumentoTipo	INT
AS
BEGIN
	SELECT CodigoDocumentoTipo,NombreDocumento,Descripcion 
	FROM   DocumentosTipo
    WHERE CodigoDocumentoTipo = @CodigoDocumentoTipo
END
GO


