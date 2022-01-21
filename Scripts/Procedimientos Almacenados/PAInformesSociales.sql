USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarInformeSocial
GO

CREATE PROCEDURE InsertarInformeSocial
	@NumeroPaciente			INT,
	@DirigidoA				VARCHAR(80),
	@OcupacionDirigidoA		VARCHAR(80),
	@Referencia				VARCHAR(80),
	@FechaISocial			DATETIME,
	@ReferenciaCaso			TEXT,
	@AntecedentesPersonales	TEXT,
	@SituacionInstitucional	TEXT,
	@SituacionActual		TEXT,
	@DiagnosticoSocial		TEXT,
	@CodigoUsuario			INT,
	@Observaciones			TEXT
AS
BEGIN
	INSERT INTO dbo.InformesSociales (NumeroPaciente, NumeroInformeSocial, DirigidoA, OcupacionDirigidoA, Referencia, FechaISocial, 
			ReferenciaCaso, AntecedentesPersonales, SituacionInstitucional, SituacionActual, DiagnosticoSocial, CodigoUsuario, Observaciones)
	VALUES (@NumeroPaciente, dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'I'), @DirigidoA, @OcupacionDirigidoA, @Referencia, @FechaISocial, 
			@ReferenciaCaso, @AntecedentesPersonales, @SituacionInstitucional, @SituacionActual, @DiagnosticoSocial, @CodigoUsuario, @Observaciones)
END
GO

DROP PROCEDURE ActualizarInformeSocial
GO

CREATE PROCEDURE ActualizarInformeSocial
	@NumeroPaciente			INT,
	@NumeroInformeSocial	INT,
	@DirigidoA				VARCHAR(80),
	@OcupacionDirigidoA		VARCHAR(80),
	@Referencia				VARCHAR(80),
	@FechaISocial			DATETIME,
	@ReferenciaCaso			TEXT,
	@AntecedentesPersonales	TEXT,
	@SituacionInstitucional	TEXT,
	@SituacionActual		TEXT,
	@DiagnosticoSocial		TEXT,
	@CodigoUsuario			INT,
	@Observaciones			TEXT
AS 
BEGIN
	
	UPDATE 	dbo.InformesSociales	
		SET	
			DirigidoA				= @DirigidoA,		
			OcupacionDirigidoA		= @OcupacionDirigidoA,
			Referencia				= @Referencia,		
			FechaISocial			= @FechaISocial,			
			ReferenciaCaso			= @ReferenciaCaso,			
			AntecedentesPersonales	= @AntecedentesPersonales,
			SituacionInstitucional	= @SituacionInstitucional,	
			SituacionActual			= @SituacionActual,
			DiagnosticoSocial		= @DiagnosticoSocial,
			CodigoUsuario			= @CodigoUsuario,			
			Observaciones			= @Observaciones
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroInformeSocial = @NumeroInformeSocial
END
GO


DROP PROCEDURE EliminarInformeSocial
GO

CREATE PROCEDURE EliminarInformeSocial
	@NumeroPaciente			INT,
	@NumeroInformeSocial	INT
AS
BEGIN
	
	DELETE FROM dbo.InformesSociales
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroInformeSocial = @NumeroInformeSocial
END
GO

DROP PROCEDURE ListarInformesSociales
GO

CREATE PROCEDURE ListarInformesSociales
AS
BEGIN
	SELECT NumeroPaciente, NumeroInformeSocial, DirigidoA, OcupacionDirigidoA, Referencia, FechaISocial, 
			ReferenciaCaso, AntecedentesPersonales, SituacionInstitucional, SituacionActual, DiagnosticoSocial, CodigoUsuario, Observaciones
	FROM dbo.InformesSociales
	ORDER BY FechaISocial
END
GO


DROP PROCEDURE ObtenerInformeSocial
GO

CREATE PROCEDURE ObtenerInformeSocial
	@NumeroPaciente			INT,
	@NumeroInformeSocial	INT
AS
BEGIN
	SELECT NumeroPaciente, NumeroInformeSocial, DirigidoA, OcupacionDirigidoA, Referencia, FechaISocial, 
			ReferenciaCaso, AntecedentesPersonales, SituacionInstitucional, 
			SituacionActual, DiagnosticoSocial,  IS2.CodigoUsuario, Observaciones,
			U.Nombre + ' ' + U.ApellidoPaterno + ' ' + U.ApellidoMaterno AS NombreTrabajadoraSocial,
			DBO.ObtenerNombreCompleto(IS2.NumeroPaciente) AS NombreCompletoPaciente
	FROM  InformesSociales IS2
	LEFT JOIN Usuarios U
	ON IS2.CodigoUsuario = U.CodigoUsuario 
	WHERE NumeroPaciente = @NumeroPaciente
	AND NumeroInformeSocial = @NumeroInformeSocial
END
GO
