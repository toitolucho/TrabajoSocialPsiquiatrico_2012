USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarResponsable
GO

CREATE PROCEDURE InsertarResponsable
	@NumeroPaciente		INT,
	@CodigoParentesco	INT,
	@NombreApellidos	VARCHAR(100),
	@Direccion			VARCHAR(100),
	@Telefono			VARCHAR(12),
	@Celular			VARCHAR(12),
	@CodigoPais			CHAR(2),
	@CodigoDepartamento	CHAR(2),
	@CodigoProvincia	CHAR(2),
	@CodigoLocalidad	CHAR(2),
	@CodigoEstadoResponsable CHAR(1), 
	@CodigoTipoResponsable	CHAR(1)
AS
BEGIN
	IF(NOT EXISTS(SELECT * FROM Responsables WHERE NombreApellidos = @NombreApellidos AND NumeroPaciente = @NumeroPaciente))
	BEGIN
		INSERT INTO dbo.Responsables ( NumeroPaciente, CodigoResponsable, CodigoParentesco, NombreApellidos, Direccion, Telefono, Celular,
					CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLocalidad, CodigoEstadoResponsable, CodigoTipoResponsable)
		VALUES (@NumeroPaciente, dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'R'),  @CodigoParentesco, @NombreApellidos, @Direccion, @Telefono, @Celular,
					@CodigoPais, @CodigoDepartamento, @CodigoProvincia, @CodigoLocalidad, @CodigoEstadoResponsable, @CodigoTipoResponsable)
	END
	ELSE
		RAISERROR('El responsable ya se encuentra registrado', 17,2)
END
GO

DROP PROCEDURE ActualizarResponsable
GO

CREATE PROCEDURE ActualizarResponsable
	@NumeroPaciente		INT,
	@CodigoResponsable	INT,
	@CodigoParentesco	INT,
	@NombreApellidos	VARCHAR(100),
	@Direccion			VARCHAR(100),
	@Telefono			VARCHAR(12),
	@Celular			VARCHAR(12),
	@CodigoPais			CHAR(2),
	@CodigoDepartamento	CHAR(2),
	@CodigoProvincia	CHAR(2),
	@CodigoLocalidad	CHAR(2),
	@CodigoEstadoResponsable CHAR(1), 
	@CodigoTipoResponsable	CHAR(1)
AS 
BEGIN
	
	UPDATE 	dbo.Responsables	
		SET	
			CodigoParentesco	= @CodigoParentesco,
			NombreApellidos		= @NombreApellidos,
			Direccion			= @Direccion,
			Telefono			= @Telefono,
			Celular				= @Celular,
			CodigoPais			= @CodigoPais,
			CodigoDepartamento	= @CodigoDepartamento,
			CodigoProvincia		= @CodigoProvincia,
			CodigoLocalidad		= @CodigoLocalidad,
			CodigoEstadoResponsable = @CodigoEstadoResponsable,
			CodigoTipoResponsable = @CodigoTipoResponsable
			
	WHERE NumeroPaciente = @NumeroPaciente
	AND CodigoResponsable = @CodigoResponsable
END
GO


DROP PROCEDURE EliminarResponsable
GO

CREATE PROCEDURE EliminarResponsable
	@NumeroPaciente		INT,
	@CodigoResponsable	INT
AS
BEGIN
	
	DELETE FROM dbo.Responsables
	WHERE NumeroPaciente = @NumeroPaciente
	AND CodigoResponsable = @CodigoResponsable
END
GO

DROP PROCEDURE ListarResponsables
GO

CREATE PROCEDURE ListarResponsables
AS
BEGIN
	SELECT NumeroPaciente, CodigoResponsable, CodigoParentesco, NombreApellidos, Direccion, Telefono, Celular,
			CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLocalidad, CodigoEstadoResponsable, CodigoTipoResponsable
	FROM dbo.Responsables
	ORDER BY NombreApellidos
END
GO


DROP PROCEDURE ObtenerResponsable
GO

CREATE PROCEDURE ObtenerResponsable
	@NumeroPaciente		INT,
	@CodigoResponsable	INT
AS
BEGIN
	SELECT NumeroPaciente, CodigoResponsable, CodigoParentesco, NombreApellidos, Direccion, Telefono, Celular,
			CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLocalidad, CodigoEstadoResponsable, CodigoTipoResponsable
	FROM  dbo.Responsables
	WHERE NumeroPaciente = @NumeroPaciente
	AND CodigoResponsable = @CodigoResponsable
END
GO

DROP PROCEDURE ObtenerResponsableUltimo
GO

CREATE PROCEDURE ObtenerResponsableUltimo
	@NumeroPaciente		INT
AS
BEGIN
	SELECT TOP(1) NumeroPaciente, CodigoResponsable, CodigoParentesco, NombreApellidos, Direccion, Telefono, Celular,
			CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLocalidad, CodigoEstadoResponsable, CodigoTipoResponsable
	FROM  dbo.Responsables
	WHERE NumeroPaciente = @NumeroPaciente
	order by NumeroPaciente, CodigoResponsable desc
END
GO


DROP PROCEDURE ObtenerResponsables
GO

CREATE PROCEDURE ObtenerResponsables
	@NumeroPaciente		INT,
	@CodigoEstadoResponsable	CHAR(1)
	
AS
BEGIN
	SELECT NumeroPaciente, CodigoResponsable, R.CodigoParentesco, NombreApellidos, Direccion, Telefono, Celular,
			R.CodigoPais, R.CodigoDepartamento, R.CodigoProvincia, R.CodigoLocalidad, CodigoEstadoResponsable, CodigoTipoResponsable,
			P.NombreParentesco, PA.NombrePais AS PaisNacimiento, DEP.NombreDepartamento as DepartamentoNacimiento, 
			PRO.NombreProvincia as ProvinciaNacimiento, LOC.NombreLocalidad as LocalidadNacimiento
	FROM  dbo.Responsables R
	INNER JOIN Parentescos P 
	ON R.CodigoParentesco = P.CodigoParentesco
	LEFT JOIN Paises PA
	ON R.CodigoPais = PA.CodigoPais
	LEFT JOIN Departamentos DEP
	ON R.CodigoDepartamento = DEP.CodigoDepartamento
	AND R.CodigoPais = DEP.CodigoPais
	LEFT JOIN Provincias PRO
	ON R.CodigoProvincia = PRO.CodigoProvincia
	AND R.CodigoPais = PRO.CodigoPais
	AND R.CodigoDepartamento = PRO.CodigoDepartamento
	LEFT JOIN Localidades LOC
	ON R.CodigoLocalidad = LOC.CodigoLocalidad
	AND R.CodigoPais = LOC.CodigoPais
	AND R.CodigoDepartamento = LOC.CodigoDepartamento
	AND R.CodigoProvincia = LOC.CodigoProvincia
	WHERE NumeroPaciente = @NumeroPaciente
	AND R.CodigoEstadoResponsable LIKE 
	CASE WHEN @CodigoEstadoResponsable IS NULL THEN '%%'
	ELSE @CodigoEstadoResponsable END
	order by NombreApellidos
END
GO