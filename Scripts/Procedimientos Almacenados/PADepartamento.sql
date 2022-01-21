USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarDepartamento
GO

CREATE PROCEDURE InsertarDepartamento
	  @CodigoPais          CHAR(2),
      @CodigoDepartamento  CHAR(2),    
      @NombreDepartamento  VARCHAR(150)
    
AS
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS(SELECT * FROM Departamentos WHERE NombreDepartamento = @NombreDepartamento))
	BEGIN
		RAISERROR('EL NOMBRE DEL DEPARTAMENTO YA SE ENCUENTRA REGISTRADO',16,2)
	END
	ELSE
		INSERT INTO Departamentos(CodigoPais, CodigoDepartamento, NombreDepartamento)
		VALUES (@CodigoPais, @CodigoDepartamento, @NombreDepartamento)
	
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO

DROP PROCEDURE ActualizarDepartamento
GO

CREATE PROCEDURE ActualizarDepartamento
	@CodigoPais 	        CHAR (2),
	@CodigoDepartamento	    CHAR (2),
    @NombreDepartamento     VARCHAR(150)

AS 
BEGIN
	BEGIN TRANSACTION
	IF(EXISTS (SELECT * FROM dbo.Departamentos WHERE NombreDepartamento = @NombreDepartamento AND CodigoDepartamento <> @CodigoDepartamento))
	BEGIN
		RAISERROR ('EL CODIGO DEL DEPARTAMENTO NO SE ENCUENTRA REGISTRADO',16, 2)
	END
	ELSE
		UPDATE   dbo.Departamentos
			SET	 NombreDepartamento = @NombreDepartamento
        WHERE (CodigoPais = @CodigoPais) AND (CodigoDepartamento = @CodigoDepartamento)
		
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO ACTUALIZAR EL NOMBRE DE DEPARTAMENTO',16,2)
	END
	ELSE
		COMMIT TRANSACTION	
END
GO


DROP PROCEDURE EliminarDepartamento
GO

CREATE PROCEDURE EliminarDepartamento
	@CodigoPais	         CHAR(2),
    @CodigoDepartamento  CHAR(2)
AS
BEGIN
	
	DELETE FROM dbo.Departamentos
	WHERE (CodigoPais = @CodigoPais)AND (CodigoDepartamento = @CodigoDepartamento)
END
GO

DROP PROCEDURE ListarDepartamentos
GO

CREATE PROCEDURE ListarDepartamentos
AS
BEGIN
	SELECT CodigoPais, CodigoDepartamento, NombreDepartamento   
	FROM dbo.Departamentos
    ORDER BY CodigoPais, CodigoDepartamento
END
GO


DROP PROCEDURE ObtenerDepartamento
GO

CREATE PROCEDURE ObtenerDepartamento
	@CodigoPais	           CHAR(2),
    @CodigoDepartamento    CHAR(2)
AS
BEGIN
	SELECT CodigoPais,CodigoDepartamento,NombreDepartamento  
	FROM  dbo.Departamentos
	WHERE (CodigoPais = @CodigoPais)AND (CodigoDepartamento = @CodigoDepartamento)
END
GO



DROP PROCEDURE ObtenerDepartamentosPorPais
GO

CREATE PROCEDURE ObtenerDepartamentosPorPais
        @CodigoPais				CHAR(2)
AS
    SELECT CodigoPais, CodigoDepartamento, NombreDepartamento
    FROM Departamentos
	WHERE CodigoPais = @CodigoPais	
	ORDER BY NombreDepartamento
GO