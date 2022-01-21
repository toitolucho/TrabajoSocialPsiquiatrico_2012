USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarPaciente
GO

CREATE PROCEDURE InsertarPaciente
	
    @HClinico                      INT,   
    @NumeroFolio                   INT,
    @FechaConsulta                 SMALLDATETIME,
    @Nombre                        VARCHAR(50),
    @ApellidoPaterno               VARCHAR(30),
    @ApellidoMaterno               VARCHAR(30),
    @FechaNacimiento               SMALLDATETIME,
    @Sexo                          CHAR(1),
    @GrupoFamiliar                 INT,
    @EstadoCivil                   CHAR(2),
    @GradoInstruccion              CHAR(1),
    @Unidad                        INT,
    @Seccion                       VARCHAR(10),
    @Denominacion                  VARCHAR(50),
    @FechaIngreso                  SMALLDATETIME,
    @Religion                      CHAR(1),
    @Idioma                        VARCHAR(20),
    @Ocupacion                     VARCHAR(20),
    @NombreRemitidor               VARCHAR(100),
    @LugarTrabajo                  VARCHAR(30),
    @CIPaciente                    VARCHAR(10),
    @PacienteDependiente           CHAR(1),
    @TipoDiscapacidad              VARCHAR(50),
    @IngresoMensual                FLOAT,
    @IngresoEventual               FLOAT,
    @Ninguno                       BIT,
    @RelacionesFamiliares          CHAR(1),
    @ObservacionRelFamiliares      TEXT,
    @PredisposicionTratamiento     CHAR(1),
    @Antecedentes                  TEXT,
    @CodigoDiagnostico             VARCHAR(10),
    @Diagnostico                   VARCHAR(150),
    @PacienteInstitucionalizado	   BIT,
    @CodigoPais                    CHAR(2),
    @CodigoDepartamento            CHAR(2),
    @CodigoProvincia               CHAR(2),
    @CodigoLocalidad               CHAR(2),
	@CodigoPaisResidencia          CHAR(2),
    @CodigoDepartamentoResidencia  CHAR(2),
    @CodigoProvinciaResidencia     CHAR(2),
    @CodigoLocalidadResidencia     CHAR(2)


AS
BEGIN
	DECLARE @NombreCompleto VARCHAR(300)
	SET @NombreCompleto  = LTRIM(RTRIM(ISNULL(@ApellidoPaterno,'')) + ' ' + RTRIM(ISNULL(@ApellidoMaterno,'')) + ' ' + RTRIM(@Nombre))
	BEGIN TRANSACTION
	IF (NOT EXISTS (SELECT * FROM dbo.Pacientes WHERE dbo.ObtenerNombreCompleto(NumeroPaciente) =  @NombreCompleto) )
	BEGIN
		IF (NOT EXISTS (SELECT * FROM dbo.Pacientes WHERE CIPaciente = RTRIM(LTRIM(@CIPaciente))))
		BEGIN
			INSERT INTO dbo.Pacientes (HClinico,NumeroFolio,FechaConsulta,Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Sexo,GrupoFamiliar,EstadoCivil,GradoInstruccion,Unidad,Seccion,Denominacion,FechaIngreso,Religion,Idioma,Ocupacion,NombreRemitidor,LugarTrabajo,CIPaciente,PacienteDependiente,TipoDiscapacidad,IngresoMensual,IngresoEventual,Ninguno,RelacionesFamiliares,ObservacionRelFamiliares,PredisposicionTratamiento,Antecedentes,CodigoDiagnostico,Diagnostico,CodigoPais,CodigoDepartamento,CodigoProvincia, CodigoLocalidad, CodigoPaisResidencia, CodigoDepartamentoResidencia, CodigoProvinciaResidencia, CodigoLocalidadResidencia, PacienteInstitucionalizado)                     
			VALUES (@HClinico,@NumeroFolio,@FechaConsulta,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento,@Sexo,@GrupoFamiliar,@EstadoCivil,@GradoInstruccion,@Unidad,@Seccion,@Denominacion,@FechaIngreso,@Religion,@Idioma,@Ocupacion,@NombreRemitidor,@LugarTrabajo,@CIPaciente,@PacienteDependiente,@TipoDiscapacidad,@IngresoMensual,@IngresoEventual,@Ninguno,@RelacionesFamiliares,@ObservacionRelFamiliares,@PredisposicionTratamiento,@Antecedentes,@CodigoDiagnostico,@Diagnostico,@CodigoPais,@CodigoDepartamento,@CodigoProvincia, @CodigoLocalidad, @CodigoPaisResidencia, @CodigoDepartamentoResidencia, @CodigoProvinciaResidencia, @CodigoLocalidadResidencia, @PacienteInstitucionalizado) 		
		END
		ELSE
		BEGIN			
			RAISERROR ('EL NUMERO DE CI DEL PACIENTE YA SE ENCUENTRA REGISTRADO',16,2)
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


DROP PROCEDURE ActualizarPaciente
GO

CREATE PROCEDURE ActualizarPaciente
	@NumeroPaciente                INT,
    @HClinico                      INT,   
    @NumeroFolio                   INT,
    @FechaConsulta                 SMALLDATETIME,
    @Nombre                        VARCHAR(50),
    @ApellidoPaterno               VARCHAR(30),
    @ApellidoMaterno               VARCHAR(30),
    @FechaNacimiento               SMALLDATETIME,
    @Sexo                          CHAR(1),
    @GrupoFamiliar                 INT,
    @EstadoCivil                   CHAR(2),
    @GradoInstruccion              CHAR(1),
    @Unidad                        INT,
    @Seccion                       VARCHAR(10),
    @Denominacion                  VARCHAR(50),
    @FechaIngreso                  SMALLDATETIME,
    @Religion                      CHAR(1),
    @Idioma                        VARCHAR(20),
    @Ocupacion                     VARCHAR(20),
    @NombreRemitidor               VARCHAR(100),
    @LugarTrabajo                  VARCHAR(30),
    @CIPaciente                    VARCHAR(10),
    @PacienteDependiente           CHAR(1),
    @TipoDiscapacidad              VARCHAR(50),
    @IngresoMensual                FLOAT,
    @IngresoEventual               FLOAT,
    @Ninguno                       BIT,
    @RelacionesFamiliares          CHAR(1),
    @ObservacionRelFamiliares      TEXT,
    @PredisposicionTratamiento     CHAR(1),
    @Antecedentes                  TEXT,
    @CodigoDiagnostico             VARCHAR(10),
    @Diagnostico                   VARCHAR(150),
    @PacienteInstitucionalizado	   BIT,
    @CodigoPais                    CHAR(2),
    @CodigoDepartamento            CHAR(2),
    @CodigoProvincia               CHAR(2),
    @CodigoLocalidad               CHAR(2),
	@CodigoPaisResidencia          CHAR(2),
    @CodigoDepartamentoResidencia  CHAR(2),
    @CodigoProvinciaResidencia     CHAR(2),
    @CodigoLocalidadResidencia     CHAR(2)
AS 
BEGIN
	DECLARE @NombreCompleto VARCHAR(300)
	SET @NombreCompleto  = LTRIM(RTRIM(ISNULL(@ApellidoPaterno,'')) + ' ' + RTRIM(ISNULL(@ApellidoMaterno,'')) + ' ' + RTRIM(@Nombre))
	BEGIN TRANSACTION
    IF(EXISTS (SELECT * FROM dbo.Pacientes WHERE dbo.ObtenerNombreCompleto(NumeroPaciente) = @NombreCompleto AND NumeroPaciente <> @NumeroPaciente))
	BEGIN
		RAISERROR ('EL CODIGO DEL PACIENTE NO SE ENCUENTRA REGISTRADO',16, 2)
	END
	ELSE
		UPDATE Pacientes
			SET	 
    HClinico                 = @HClinico,
    NumeroFolio              = @NumeroFolio,
    FechaConsulta            = @FechaConsulta,
    Nombre                   = @Nombre,
    ApellidoPaterno          = @ApellidoPaterno,
    ApellidoMaterno          = @ApellidoMaterno,
    FechaNacimiento          = @FechaNacimiento,              
    Sexo                     = @Sexo,
    GrupoFamiliar            = @GrupoFamiliar,
    EstadoCivil              = @EstadoCivil,
    GradoInstruccion         = @GradoInstruccion,
    Unidad                   = @Unidad,
    Seccion                  = @Seccion,
    Denominacion             = @Denominacion,
    FechaIngreso             = @FechaIngreso,
    Religion                 = @Religion,
    Idioma                   = @Idioma,
    Ocupacion                = @Ocupacion,
    NombreRemitidor          = @NombreRemitidor,
    LugarTrabajo             = @LugarTrabajo,
    CIPaciente               = @CIPaciente,
    PacienteDependiente      = @PacienteDependiente,
    TipoDiscapacidad         = @TipoDiscapacidad,
    IngresoMensual           = @IngresoMensual,
    IngresoEventual          = @IngresoEventual,
    Ninguno                  = @Ninguno,
    RelacionesFamiliares     = @RelacionesFamiliares,
    ObservacionRelFamiliares = @ObservacionRelFamiliares,
    PredisposicionTratamiento = @PredisposicionTratamiento,
    Antecedentes              = @Antecedentes,
    CodigoDiagnostico         = @CodigoDiagnostico,
    Diagnostico               = @Diagnostico,
    CodigoPais                = @CodigoPais,
    CodigoDepartamento        = @CodigoDepartamento,
    CodigoProvincia           = @CodigoProvincia,
    CodigoLocalidad           = @CodigoLocalidad, 
	CodigoPaisResidencia			= @CodigoPaisResidencia,
	CodigoDepartamentoResidencia	= @CodigoDepartamentoResidencia,
	CodigoProvinciaResidencia		= @CodigoProvinciaResidencia,
	CodigoLocalidadResidencia		= @CodigoLocalidadResidencia ,
	PacienteInstitucionalizado	= @PacienteInstitucionalizado  
    

	WHERE NumeroPaciente = @NumeroPaciente
		
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO ACTUALIZAR CORRECTAMENTE LOS DATOS DEL SERVICIO',16,2)
	END
	ELSE
		COMMIT TRANSACTION	
END
GO


DROP PROCEDURE ActualizarPacienteIncompleto
GO

CREATE PROCEDURE ActualizarPacienteIncompleto
	@NumeroPaciente                INT,
    @FechaConsulta                 SMALLDATETIME,
    @Nombre                        VARCHAR(50),
    @ApellidoPaterno               VARCHAR(30),
    @ApellidoMaterno               VARCHAR(30),
    @FechaNacimiento               SMALLDATETIME,
    @Sexo                          CHAR(1),
    @GrupoFamiliar                 INT,
    @EstadoCivil                   CHAR(2),
    @GradoInstruccion              CHAR(1),
    @IngresoMensual                FLOAT,
    @Ocupacion                     VARCHAR(20),
	@CodigoPaisResidencia          CHAR(2),
    @CodigoDepartamentoResidencia  CHAR(2),
    @CodigoProvinciaResidencia     CHAR(2),
    @CodigoLocalidadResidencia     CHAR(2)
AS 
BEGIN
	DECLARE @NombreCompleto VARCHAR(300)
	SET @NombreCompleto  = LTRIM(RTRIM(ISNULL(@ApellidoPaterno,'')) + ' ' + RTRIM(ISNULL(@ApellidoMaterno,'')) + ' ' + RTRIM(@Nombre))
	BEGIN TRANSACTION
    IF(EXISTS (SELECT * FROM dbo.Pacientes WHERE dbo.ObtenerNombreCompleto(NumeroPaciente) = @NombreCompleto AND NumeroPaciente <> @NumeroPaciente))
	BEGIN
		RAISERROR ('EL CODIGO DEL PACIENTE NO SE ENCUENTRA REGISTRADO',16, 2)
	END
	ELSE
		UPDATE Pacientes
			SET	 
    FechaConsulta            = @FechaConsulta,
    Nombre                   = @Nombre,
    ApellidoPaterno          = @ApellidoPaterno,
    ApellidoMaterno          = @ApellidoMaterno,
    FechaNacimiento          = @FechaNacimiento,              
    Sexo                     = @Sexo,
    GrupoFamiliar            = @GrupoFamiliar,
    EstadoCivil              = @EstadoCivil,
    GradoInstruccion         = @GradoInstruccion,
    Ocupacion                = @Ocupacion,
    IngresoMensual           = @IngresoMensual,
	CodigoPaisResidencia			= @CodigoPaisResidencia,
	CodigoDepartamentoResidencia	= @CodigoDepartamentoResidencia,
	CodigoProvinciaResidencia		= @CodigoProvinciaResidencia,
	CodigoLocalidadResidencia		= @CodigoLocalidadResidencia   
    

	WHERE NumeroPaciente = @NumeroPaciente
		
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK 
		RAISERROR('NO SE PUDO ACTUALIZAR CORRECTAMENTE LOS DATOS DEL SERVICIO',16,2)
	END
	ELSE
		COMMIT TRANSACTION	
END
GO




DROP PROCEDURE EliminarPaciente
GO

CREATE PROCEDURE EliminarPaciente
	@NumeroPaciente	INT
AS
BEGIN
	
	DELETE FROM dbo.Pacientes
	WHERE NumeroPaciente = @NumeroPaciente
END
GO

DROP PROCEDURE ListarPacientes
GO

CREATE PROCEDURE ListarPacientes
AS
BEGIN
	SELECT NumeroPaciente, HClinico,NumeroFolio,FechaConsulta,Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Sexo,GrupoFamiliar,EstadoCivil,GradoInstruccion,Unidad,Seccion,Denominacion,FechaIngreso,Religion,Idioma,Ocupacion,NombreRemitidor,LugarTrabajo,CIPaciente,PacienteDependiente,TipoDiscapacidad,IngresoMensual,IngresoEventual,Ninguno,RelacionesFamiliares,ObservacionRelFamiliares,PredisposicionTratamiento,Antecedentes,CodigoDiagnostico,Diagnostico,CodigoPais,CodigoDepartamento,CodigoProvincia, CodigoLocalidad, CodigoPaisResidencia, CodigoDepartamentoResidencia,CodigoProvinciaResidencia, CodigoLocalidadResidencia, PacienteInstitucionalizado
	FROM dbo.Pacientes
END
GO


DROP PROCEDURE ObtenerPaciente
GO

CREATE PROCEDURE ObtenerPaciente
	@NumeroPaciente	INT
AS
BEGIN
	SELECT NumeroPaciente, HClinico,NumeroFolio,FechaConsulta,Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Sexo,GrupoFamiliar,EstadoCivil,GradoInstruccion,Unidad,Seccion,Denominacion,FechaIngreso,Religion,Idioma,Ocupacion,NombreRemitidor,LugarTrabajo,CIPaciente,PacienteDependiente,TipoDiscapacidad,IngresoMensual,IngresoEventual,Ninguno,RelacionesFamiliares,ObservacionRelFamiliares,PredisposicionTratamiento,Antecedentes,CodigoDiagnostico,Diagnostico,CodigoPais,CodigoDepartamento,CodigoProvincia, CodigoLocalidad, CodigoPaisResidencia, CodigoDepartamentoResidencia,CodigoProvinciaResidencia, CodigoLocalidadResidencia, PacienteInstitucionalizado
	FROM  Pacientes
	WHERE NumeroPaciente = @NumeroPaciente
END
GO

DROP PROCEDURE ActualizarPacienteInstitucionalizacion
GO

CREATE PROCEDURE ActualizarPacienteInstitucionalizacion
	@NumeroPaciente				INT,
	@FechaReingreso				DATETIME,
	@CodigoUsuario				INT,
	@PacienteInstitucionalizado	BIT	
AS
BEGIN
	UPDATE Pacientes
		SET PacienteInstitucionalizado = @PacienteInstitucionalizado
	WHERE NumeroPaciente = @NumeroPaciente
	
	
	DECLARE @CodigoActividadPacInst		INT,
			@CodigoActividadPacNoInst	INT
	
	SELECT @CodigoActividadPacInst = CodigoActividadTipo
	FROM dbo.ActividadesTipo
	WHERE NombreActividad = 'PACIENTE SE INSTITUCIONALIZA'
	
	SELECT @CodigoActividadPacNoInst = CodigoActividadTipo
	FROM dbo.ActividadesTipo
	WHERE NombreActividad = 'PACIENTE SE DES-INSTITUCIONALIZA'
	
	DECLARE @Actividad INT = (CASE WHEN @PacienteInstitucionalizado = 1 THEN @CodigoActividadPacInst ELSE @CodigoActividadPacNoInst END)
	
	EXEC InsertarActividad @NumeroPaciente, @FechaReingreso, 
		@Actividad,
		@CodigoUsuario, 'P', 	
		'Registro Automatico de Actividad por Actualización del Estado de Institucionalizacion del Paciente'
END
GO

DROP PROCEDURE ListarDatosPacienteReporte
GO

CREATE PROCEDURE ListarDatosPacienteReporte
	@NumeroPaciente				INT
AS
BEGIN
	SELECT * FROM PacientesDatos
	WHERE NumeroPaciente = @NumeroPaciente
END
GO