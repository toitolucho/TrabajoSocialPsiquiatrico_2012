USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarFamiliar
GO

CREATE PROCEDURE InsertarFamiliar
	@NumeroPaciente		INT,
	@CodigoParentesco	INT,
	@NombreApellidos	VARCHAR(100),
	@Edad				INT,
	@GradoInstruccion	CHAR(1),
	@EstadoCivil		CHAR(2),
	@Ocupacion			VARCHAR(50),
	@IngresoEconomico	FLOAT,
	@Observacion		VARCHAR(200)
AS
BEGIN
	INSERT INTO dbo.Familiares (NumeroPaciente, NumeroFamiliar, CodigoParentesco, NombreApellidos, Edad, GradoInstruccion, EstadoCivil, Ocupacion, IngresoEconomico, Observacion)
	VALUES (@NumeroPaciente, DBO.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'F'), @CodigoParentesco, @NombreApellidos, @Edad, @GradoInstruccion, @EstadoCivil, @Ocupacion, @IngresoEconomico, @Observacion)
END
GO

DROP PROCEDURE ActualizarFamiliar
GO

CREATE PROCEDURE ActualizarFamiliar
	@NumeroPaciente		INT,
	@NumeroFamiliar		INT,
	@CodigoParentesco	INT,
	@NombreApellidos	VARCHAR(100),
	@Edad				INT,
	@GradoInstruccion	CHAR(1),
	@EstadoCivil		CHAR(2),
	@Ocupacion			VARCHAR(50),
	@IngresoEconomico	FLOAT,
	@Observacion		VARCHAR(200)
AS 
BEGIN
	
	UPDATE 	dbo.Familiares	
		SET	
			CodigoParentesco	= @CodigoParentesco,
			NombreApellidos		= @NombreApellidos,
			Edad				= @Edad,
			GradoInstruccion	= @GradoInstruccion,
			EstadoCivil			= @EstadoCivil,
			Ocupacion			= @Ocupacion,
			IngresoEconomico	= @IngresoEconomico,
			Observacion			= @Observacion
			
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroFamiliar = @NumeroFamiliar
END
GO


DROP PROCEDURE EliminarFamiliar
GO

CREATE PROCEDURE EliminarFamiliar
	@NumeroPaciente		INT,
	@NumeroFamiliar		INT
AS
BEGIN
	
	DELETE FROM dbo.Familiares
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroFamiliar = @NumeroFamiliar
END
GO

DROP PROCEDURE ListarFamiliares
GO

CREATE PROCEDURE ListarFamiliares
AS
BEGIN
	SELECT NumeroPaciente, NumeroFamiliar, CodigoParentesco, NombreApellidos, Edad, GradoInstruccion, EstadoCivil, Ocupacion, IngresoEconomico, Observacion
	FROM dbo.Familiares
	ORDER BY NombreApellidos
END
GO


DROP PROCEDURE ObtenerFamiliar
GO

CREATE PROCEDURE ObtenerFamiliar
	@NumeroPaciente		INT,
	@NumeroFamiliar		INT
AS
BEGIN
	SELECT NumeroPaciente, NumeroFamiliar, CodigoParentesco, NombreApellidos, Edad, GradoInstruccion, EstadoCivil, Ocupacion, IngresoEconomico, Observacion
	FROM  dbo.Familiares
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroFamiliar = @NumeroFamiliar
END
GO


DROP PROCEDURE ObtenerFamiliares
GO

CREATE PROCEDURE ObtenerFamiliares
	@NumeroPaciente		INT
AS
BEGIN
	SELECT NumeroPaciente, NumeroFamiliar, F.CodigoParentesco, NombreApellidos, Edad, GradoInstruccion, EstadoCivil, Ocupacion, IngresoEconomico, Observacion,
			ROW_NUMBER() OVER(ORDER BY NumeroFamiliar DESC) AS NumeroFila, 
			CASE GradoInstruccion WHEN 'A' THEN 'ANALFABETO' WHEN 'P' THEN 'PRIMARIO' WHEN 'S' THEN 'SECUNDARIO' 
				WHEN 'U' THEN 'UNIVERSITARIO' WHEN 'T' THEN 'TECNICO SUPERIOR' WHEN 'S' THEN 'SUPERIOR' END AS Intruccion,
			CASE EstadoCivil WHEN 'DE' THEN 'DESCONOCIDO' WHEN 'SO' THEN 'SOLTERO' 
			WHEN 'CA' THEN 'CASADO' WHEN 'VI' THEN 'VIUDO' WHEN 'DI' THEN 'DIVORCIADO' WHEN 'CO' THEN 'CONCUBINO' END AS Civil,
			P.NombreParentesco
	FROM  dbo.Familiares F
	INNER JOIN Parentescos P
	ON P.CodigoParentesco = F.CodigoParentesco
	WHERE NumeroPaciente = @NumeroPaciente
END
GO
