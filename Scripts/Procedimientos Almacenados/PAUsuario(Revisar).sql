USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarUsuario
GO

CREATE PROCEDURE InsertarUsuario	
	
     @Usuario              VARCHAR(30),
     @Contraseña           VARCHAR(30),
     @Nombre               VARCHAR(60),
     @ApellidoPaterno      VARCHAR(50),
     @ApellidoMaterno      VARCHAR(50),
     @CIUsuario            VARCHAR(12),
     @Direccion            VARCHAR(70),
     @Telefono             VARCHAR(12),
     @Celular              VARCHAR(9),
     @TipoUsuario          CHAR(1),
     @CodigoUnidadMedica   INT

AS
BEGIN
	DECLARE @NombreCompleto VARCHAR(300)
	SET @NombreCompleto  = LTRIM(RTRIM(ISNULL(@ApellidoPaterno,'')) + ' ' + RTRIM(ISNULL(@ApellidoMaterno,'')) + ' ' + RTRIM(@Nombre))
	BEGIN TRANSACTION
	IF (NOT EXISTS (SELECT * FROM dbo.Usuarios WHERE @NombreCompleto =  LTRIM(RTRIM(ISNULL(ApellidoPaterno,'')) + ' ' + RTRIM(ISNULL(ApellidoMaterno,'')) + ' ' + RTRIM(Nombre))) )
	BEGIN
		IF (NOT EXISTS (SELECT * FROM dbo.Usuarios WHERE Usuario = RTRIM(LTRIM(@Usuario))))
		BEGIN
	
			IF (NOT EXISTS (SELECT * FROM dbo.Usuarios WHERE CIUsuario = RTRIM(LTRIM(@CIUsuario))))
			BEGIN
				INSERT INTO dbo.Usuarios (Usuario,Contraseña,Nombre,ApellidoPaterno,ApellidoMaterno, CIUsuario,Direccion, Telefono, Celular,TipoUsuario, CodigoUnidadMedica)
				VALUES (@Usuario,@Contraseña,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@CIUsuario,@Direccion, @Telefono, @Celular,@TipoUsuario, @CodigoUnidadMedica)		
			END
			ELSE
			BEGIN			
				RAISERROR ('EL NUMERO DE CI YA SE ENCUENTRA REGISTRADO',16,2)
			END
		END
		ELSE
		BEGIN			
			RAISERROR ('LA CUENTA CON EL LOGIN INGRESADO YA SE ENCUENTRA REGISTRADO',16,2)
		END
	END
	ELSE
	BEGIN		
		RAISERROR ('LOS DATOS PERSONALES: NOMBRES Y APELLIDOS YA SE ENCUENTRAN REGISTRADOS',16,2)
	END
	
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END	
GO

DROP PROCEDURE ActualizarUsuario
GO

CREATE PROCEDURE ActualizarUsuario
	@CodigoUsuario        INT,
    @Usuario              VARCHAR(30),
    @Contraseña           VARCHAR(30),
    @Nombre               VARCHAR(60),
    @ApellidoPaterno      VARCHAR(50),  
    @ApellidoMaterno      VARCHAR(50),
    @CIUsuario            VARCHAR(12),
    @Direccion            VARCHAR(70),
    @Telefono             VARCHAR(12),
    @Celular              VARCHAR(12),
    @TipoUsuario          CHAR(1),
    @CodigoUnidadMedica   INT
AS
BEGIN
	UPDATE 	dbo.Usuarios
	SET		
		
     Usuario              = @Usuario,
     Contraseña           = @Contraseña,
     Nombre               = @Nombre,
     ApellidoPaterno      = @ApellidoPaterno,  
     ApellidoMaterno      = @ApellidoMaterno,
     CIUsuario            = @CIUsuario,
     Direccion            = @Direccion,
     Telefono             = @Telefono,
     Celular              = @Celular,
     TipoUsuario          = @TipoUsuario,
     CodigoUnidadMedica   = @CodigoUnidadMedica

	WHERE (CodigoUsuario = @CodigoUsuario)
END
GO

DROP PROCEDURE EliminarUsuario
GO

CREATE PROCEDURE EliminarUsuario
	@CodigoUsuario	INT
AS
BEGIN
	BEGIN TRANSACTION	
	DELETE 
	FROM dbo.Usuarios
	WHERE (CodigoUsuario = @CodigoUsuario)
	
	IF(@@ERROR<> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUEDE ELIMINAR A ESTA PERSONA, YA QUE HA REALIZADO VARIAS ACCIONES EN EL SISTEMA',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO

DROP PROCEDURE ListarUsuario
GO

CREATE PROCEDURE ListarUsuario
AS
BEGIN
	SELECT CodigoUsuario,Usuario,Contraseña,Nombre,ApellidoPaterno,ApellidoMaterno, CIUsuario,Direccion, Telefono, Celular,TipoUsuario, CodigoUnidadMedica
	FROM dbo.Usuarios
	ORDER BY CodigoUsuario
END
GO


DROP PROCEDURE ListarUsuarioTrabajadorSocial
GO

CREATE PROCEDURE ListarUsuarioTrabajadorSocial
AS
BEGIN
	SELECT CodigoUsuario,Usuario,Contraseña,Nombre,ApellidoPaterno,ApellidoMaterno, CIUsuario,Direccion, Telefono, Celular,TipoUsuario, CodigoUnidadMedica,
		Nombre +' '+ApellidoPaterno + ' ' +ApellidoMaterno as NombreCompleto
	FROM dbo.Usuarios
	where TipoUsuario = 'T'
	ORDER BY CodigoUsuario
END
GO


DROP PROCEDURE ObtenerUsuario
GO

CREATE PROCEDURE  ObtenerUsuario
	@CodigoUsuario	INT
AS
BEGIN
	SELECT CodigoUsuario,Usuario,Contraseña,Nombre,ApellidoPaterno,ApellidoMaterno, CIUsuario,Direccion, Telefono, Celular,TipoUsuario, CodigoUnidadMedica
	FROM dbo.Usuarios
	WHERE (CodigoUsuario = @CodigoUsuario)
END
GO

DROP PROCEDURE VerificarContrasena
GO

CREATE PROCEDURE VerificarContrasena
@NombreUsuario 		VARCHAR(30),
@Contraseña			VARCHAR(30),
@CodigoUsuario		INT OUTPUT
AS

SELECT @CodigoUsuario = CodigoUsuario
FROM Usuarios
WHERE Usuario = @NombreUsuario 
AND Contraseña = @Contraseña

GO


DROP PROCEDURE ActualizarContrasenaUsuario
GO

CREATE PROCEDURE ActualizarContrasenaUsuario
	@CodigoUsuario	INT,
	@Contrasena		VARCHAR(30)
AS
BEGIN
	UPDATE Usuarios
		SET Contraseña = @Contrasena
	WHERE @CodigoUsuario = CodigoUsuario
END
GO