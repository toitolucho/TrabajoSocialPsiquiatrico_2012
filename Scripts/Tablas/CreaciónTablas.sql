USE  TRABAJO_SOCIAL
GO

DROP TABLE Contrarreferencias
GO
DROP TABLE Referencias
GO
DROP TABLE Actividades
GO
DROP TABLE ActividadesTipo
GO
DROP TABLE SeguimientoAnual
GO
DROP TABLE SeguimientosSociales
GO
DROP TABLE ValoracionSocioeconomica
GO
DROP TABLE PagoServiciosDetalle
GO
DROP TABLE PagoServicios
GO
DROP TABLE Servicios
GO
DROP TABLE Especialidades
GO
DROP TABLE RespuestasValoracion
GO
DROP TABLE PreguntasValoracion
GO
DROP TABLE Categorias
GO
DROP TABLE InformesSociales
GO
DROP TABLE TrabajadoresSociales
GO
DROP TABLE Medicos
GO
DROP TABLE Reingresos
GO
DROP TABLE DatosAdministrativos
GO
DROP TABLE Viviendas
GO
DROP TABLE PersonasEncargadas
GO
DROP TABLE Direcciones
GO
DROP TABLE Familiares
GO
DROP TABLE Documentos
GO
DROP TABLE DocumentosTipo
GO
DROP TABLE Responsables
GO
DROP TABLE Parentescos
GO
DROP TABLE Pacientes
GO
DROP TABLE Localidades
GO
DROP TABLE Provincias
GO
DROP TABLE Departamentos
GO
DROP TABLE Paises
GO
DROP TABLE Usuarios
GO
DROP TABLE UnidadesMedicas
GO
DROP TABLE Ocupaciones


CREATE TABLE Ocupaciones
(
CodigoOcupacion		TINYINT	NOT NULL IDENTITY(1,1),
NombreOcupacion		VARCHAR(100) NOT NULL UNIQUE,
Descripcion			TEXT	NULL,
CONSTRAINT PK_Ocupacion PRIMARY KEY(CodigoOcupacion)
)


CREATE TABLE UnidadesMedicas
(
CodigoUnidadMedica             INT              IDENTITY (1,1)NOT NULL PRIMARY KEY,
NombreUnidadMedica             VARCHAR(150)     NOT NULL,
DireccionUnidadMedica          VARCHAR(100)     NOT NULL,
TelefonoUnidadMedica           VARCHAR(60)      NULL,  
CodigoTipoUnidadMedica		   CHAR(1)			NULL CHECK(CodigoTipoUnidadMedica IN('I','O')), --'I'->CENTRO MEDICO, 'O'->'OTRA INSTITUCION'
Descripcion                    VARCHAR(300)     NULL,
)
GO


CREATE TABLE Usuarios
(
CodigoUsuario                  INT             NOT NULL IDENTITY (1,1) PRIMARY KEY,  
Usuario                        VARCHAR(50)     NOT NULL,
Contraseña                     VARCHAR(30)     NOT NULL,
Nombre                         VARCHAR(60)     NOT NULL,
ApellidoPaterno                VARCHAR(50)     NOT NULL,            
ApellidoMaterno                VARCHAR(50)     NULL,
CIUsuario                      VARCHAR(20)     NULL, 
Direccion                      VARCHAR(70)     NULL,
Telefono                       VARCHAR(12)     NULL,
Celular                        VARCHAR(12)     NULL,
TipoUsuario                    CHAR(1)         NOT NULL CHECK(TipoUsuario IN ('A','T')), -- 'A'->Administrador ,'T'->Trabajador Social         
CodigoUnidadMedica             INT             NULL,
FOREIGN KEY  (CodigoUnidadMedica)REFERENCES UnidadesMedicas (CodigoUnidadMedica)
)
GO


CREATE TABLE Paises
(
CodigoPais                   CHAR(2)           NOT NULL PRIMARY KEY,
NombrePais                   VARCHAR(150)      NOT NULL,
)
GO


CREATE TABLE Departamentos
(
CodigoPais                   CHAR(2)            NOT NULL, 
CodigoDepartamento		     CHAR(2)			NOT NULL,
NombreDepartamento		     VARCHAR(150)		NOT NULL,
PRIMARY KEY (CodigoPais,CodigoDepartamento),
FOREIGN KEY (CodigoPais)REFERENCES Paises (CodigoPais)
)
GO


CREATE TABLE Provincias
(
CodigoPais                  CHAR(2)             NOT NULL,
CodigoDepartamento		    CHAR(2)				NOT NULL,
CodigoProvincia			    CHAR(2)				NOT NULL,
NombreProvincia			    VARCHAR(150)		NOT NULL,
PRIMARY KEY (CodigoPais,CodigoDepartamento, CodigoProvincia),
FOREIGN KEY (CodigoPais, CodigoDepartamento) 
REFERENCES Departamentos(CodigoPais, CodigoDepartamento)
)
GO


CREATE TABLE Localidades
(
CodigoPais                 CHAR(2)              NOT NULL,
CodigoDepartamento		   CHAR(2)				NOT NULL,
CodigoProvincia			   CHAR(2)				NOT NULL,
CodigoLocalidad 		   CHAR(2)				NOT NULL,
NombreLocalidad			   VARCHAR(150)		NOT NULL,
PRIMARY KEY(CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLocalidad),
FOREIGN KEY (CodigoPais,CodigoDepartamento, CodigoProvincia) 
REFERENCES Provincias(CodigoPais,CodigoDepartamento, CodigoProvincia)
)
GO


CREATE TABLE Pacientes
(
NumeroPaciente             INT                 IDENTITY (1,1)NOT NULL PRIMARY KEY,
HClinico                   INT                 NULL,--LLAVE PARA REFERENCIAR A LA OTRA BD DE ESTADÍSTICA
NumeroFolio                INT                 NULL,
FechaConsulta              SMALLDATETIME       NULL DEFAULT GETDATE(),
Nombre                     VARCHAR(50)         NULL, --DE LA OTRA BD             
ApellidoPaterno            VARCHAR(30)         NULL, --DE LA OTRA BD
ApellidoMaterno            VARCHAR(30)         NULL, --DE LA OTRA BD
FechaNacimiento            SMALLDATETIME       NULL, --DE LA OTRA BD
Sexo                       CHAR(1)			  NULL CHECK(Sexo IN ('F', 'M')) DEFAULT 'M',--DE LA OTRA BD
GrupoFamiliar              INT                 NULL,--EN LA TABLA DE VALORACIÓN SE SELECCIONARÁ AUTOMATICAMENTE EL RANGO
EstadoCivil      		   CHAR(2)			  NULL	CHECK (EstadoCivil IN  ('DE','SO','CA','VI','DI','CO')),
 --'DE'->DESCONOCIDO,'SO'->SOLTERO,'CA'->CASADO,'VI'->VIUDO,'DI'->DIVORCIADO,'CO'->CONCUBINO     --DE LA OTRA BD
GradoInstruccion           CHAR(1)             NULL CHECK (GradoInstruccion IN ('A','P','S','U','T','R')),
-->'A'->ANALFABETO,'P'->PRIMARIA,'S'->SECUNDARIA,'U'->UNIVERSITARIA,'T'->TECNICO SUPERIOR,'R'->SUPERIOR
Unidad                     INT                 NULL,
Seccion                    VARCHAR(12)         NULL,
Denominacion               VARCHAR(50)         NULL,
FechaIngreso               SMALLDATETIME       NULL,
Religion                   CHAR(1)             NULL CHECK (Religion IN ('C','E','R',
'A','T','M','J','P','D','N','O')),--'C'->Catolico,'E'->Evangelico,'R'->Cristiano, --DE LA OTRA BD
--A->Adventista,'T'->Ateo,'M'->Mormon,'J'->TestigoJeova,'P'->Protestante,'D'->Desconocido,
--'N'->Ninguno,'O'->Otros)
Idioma                     VARCHAR(20)         NULL,--DE LA OTRA BD
Ocupacion                  VARCHAR(50)         NULL,--DE LA OTRA BD
NombreRemitidor            VARCHAR(100)        NULL,
LugarTrabajo               VARCHAR(50)         NULL,
CIPaciente                 VARCHAR(30)         NULL,
PacienteDependiente        CHAR(1)			   NULL CHECK(PacienteDependiente IN ('S', 'N')), --'S'->SI, 'N'->NO
TipoDiscapacidad           VARCHAR(50)         NULL,  
IngresoMensual             FLOAT               NULL CHECK (IngresoMensual>=0),
IngresoEventual            FLOAT               NULL CHECK (IngresoEventual>=0),
Ninguno                    BIT                 NULL DEFAULT 0,
RelacionesFamiliares       CHAR(1)             NULL CHECK (RelacionesFamiliares IN ('B','R','M')),--'B'->BUENO,'R'->REGULAR,'M'->MALO
ObservacionRelFamiliares   TEXT                NULL,
PredisposicionTratamiento  CHAR(1)             NULL CHECK (PredisposicionTratamiento IN ('B','R','M')),--'B'->BUENO,'R'->REGULAR,'M'->MALO
Antecedentes               TEXT                NULL,
CodigoDiagnostico          VARCHAR(10)         NULL,
Diagnostico                VARCHAR(150)        NULL,
PacienteInstitucionalizado BIT				   NULL DEFAULT 0, 
CodigoPais                 CHAR(2)             NULL,
CodigoDepartamento         CHAR(2)             NULL,	
CodigoProvincia            CHAR(2)             NULL,
CodigoLocalidad            CHAR(2)             NULL,
CodigoPaisResidencia       CHAR(2)             NULL,
CodigoDepartamentoResidencia CHAR(2)             NULL,	
CodigoProvinciaResidencia  CHAR(2)             NULL,
CodigoLocalidadResidencia  CHAR(2)             NULL,
CodigoEstadoPaciente		CHAR(1)			   NULL DEFAULT 'A' CHECK (CodigoEstadoPaciente IN('A','P')),--ACTIVO, PASIVO
FOREIGN KEY (CodigoPais,CodigoDepartamento,CodigoProvincia, CodigoLocalidad)
REFERENCES Localidades (CodigoPais,CodigoDepartamento,CodigoProvincia, CodigoLocalidad),
FOREIGN KEY (CodigoPaisResidencia,CodigoDepartamentoResidencia,CodigoProvinciaResidencia, CodigoLocalidadResidencia)
REFERENCES Localidades (CodigoPais,CodigoDepartamento,CodigoProvincia, CodigoLocalidad)
)
GO
 

CREATE TABLE Parentescos
(
CodigoParentesco           INT                  IDENTITY (1,1) NOT NULL PRIMARY KEY,
NombreParentesco           VARCHAR(100)         NOT NULL,
Descripcion                VARCHAR(300)         NULL,
)
GO


CREATE TABLE Responsables
(
NumeroPaciente             INT                 NOT NULL,
CodigoResponsable          INT                 NOT NULL,
CodigoParentesco           INT                 NULL,        
NombreApellidos            VARCHAR(100)         NULL,
Direccion                  VARCHAR(100)        NULL,
Telefono                   VARCHAR(30)         NULL,
Celular                    VARCHAR(30)          NULL,
CodigoPais                 CHAR(2)             NULL,
CodigoDepartamento		   CHAR(2)			   NULL,
CodigoProvincia			   CHAR(2)			   NULL,
CodigoLocalidad 		   CHAR(2)			   NULL,
CodigoEstadoResponsable	   CHAR(1)			   NULL CHECK(CodigoEstadoResponsable IN ('V','B')),--'V'VIGENTE, 'B'BAJA
CodigoTipoResponsable	   CHAR(1)			   NULL CHECK(CodigoTipoResponsable IN ('E','F','R','A')),--'E'->'RESPONSABLE ECONOMICO', 'F'->FAMILIAR, 'R'->SOLO RESPONSABLE, 'A'->Ambos(Familiar y Economico)
PRIMARY KEY (NumeroPaciente,CodigoResponsable),
FOREIGN KEY (NumeroPaciente) REFERENCES Pacientes (NumeroPaciente),
FOREIGN KEY (CodigoParentesco) REFERENCES Parentescos (CodigoParentesco),
FOREIGN KEY (CodigoPais,CodigoDepartamento, CodigoProvincia, CodigoLocalidad)
REFERENCES Localidades (CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLocalidad)
)
GO


CREATE TABLE DocumentosTipo
(
CodigoDocumentoTipo        INT                 IDENTITY (1,1) NOT NULL PRIMARY KEY,
NombreDocumento            VARCHAR(150)        NOT NULL,
Descripcion                VARCHAR(300)       NULL,
)


CREATE TABLE Documentos
(
NumeroPaciente             INT                NOT NULL,
NumeroDocumento            INT                NOT NULL IDENTITY(1,1),
NumeroRegistro			   INT				  NULL,
FechaRegistro              DATETIME           NOT NULL,
TramitoTrabSocial          CHAR(1)            NOT NULL CHECK(TramitoTrabSocial IN ('S','N')),-->'S'->SI,'N'->NO
CodigoDocumentoTipo        INT                NULL,
PRIMARY KEY (NumeroPaciente, NumeroDocumento),
FOREIGN KEY (NumeroPaciente) REFERENCES Pacientes (NumeroPaciente),
FOREIGN KEY (CodigoDocumentoTipo) REFERENCES DocumentosTipo (CodigoDocumentoTipo)
)
GO


CREATE TABLE Familiares
(
NumeroPaciente             INT                NOT NULL, 
NumeroFamiliar             INT                NOT NULL,
CodigoParentesco           INT                NULL,     
NombreApellidos            VARCHAR(100)       NULL,
Edad                       INT                NULL,         
GradoInstruccion           CHAR(1)            NULL	CHECK (GradoInstruccion IN ('A','P','S','U','T','R')), 
--'A'->ANALFABETO, 'P'->PRIMARIO, 'S'->SECUNDARIO, 'U'->UNIVERSITARIO, 'T'->TECNICO SUPERIOR, 'R'->SUPERIOR      
EstadoCivil      		   CHAR(2)			  NULL	CHECK (EstadoCivil IN  ('DE','SO','CA','VI','DI','CO')),
 --'DE'->DESCONOCIDO,'SO'->SOLTERO,'CA'->CASADO,'VI'->VIUDO,'DI'->DIVORCIADO,'CO'->CONCUBINO
Ocupacion                  VARCHAR(50)        NULL,
IngresoEconomico           FLOAT              NULL CHECK (IngresoEconomico>=0),
Observacion                VARCHAR(200)       NULL,
PRIMARY KEY (NumeroPaciente, NumeroFamiliar),
FOREIGN KEY (NumeroPaciente)  REFERENCES Pacientes(NumeroPaciente),
FOREIGN KEY (CodigoParentesco)  REFERENCES Parentescos(CodigoParentesco)
)
GO


CREATE TABLE Direcciones
(
NumeroPaciente             INT                NOT NULL PRIMARY KEY,
ZonaBarrio                 VARCHAR(60)        NULL,
CalleAvenida               VARCHAR(60)        NULL,
Numero                     INT                NULL,
Telefono                   VARCHAR(12)        NULL,
FOREIGN KEY (NumeroPaciente)  REFERENCES Pacientes (NumeroPaciente)
)
GO


CREATE TABLE PersonasEncargadas
(
NumeroPaciente              INT                NOT NULL PRIMARY KEY,
Padres                      BIT                NULL DEFAULT 0,
Madres                      BIT                NULL DEFAULT 0,
Hijos                       BIT                NULL DEFAULT 0,
Hermanos                    BIT                NULL DEFAULT 0,
EsposoA                     BIT                NULL DEFAULT 0,
Otros                       VARCHAR(50)        NULL,
FOREIGN KEY (NumeroPaciente)  REFERENCES Pacientes (NumeroPaciente)
)
GO


CREATE TABLE Viviendas
(
NumeroPaciente              INT                NOT NULL PRIMARY KEY,
Vivienda                    CHAR(1)			   NULL CHECK(Vivienda IN ('C','D','H','O')), --'C'->CASA,'D'->DEPARTAMENTO,'H'->HABITACION,'O'->OTROS
TipoVivienda                CHAR(1)            NULL CHECK(TipoVivienda IN ('P','A','N','C')), --'P'->PROPIA,'A'->ALQUILADA,'N'->ANTICRETICO,'O'->OTROS
NumeroHabitaciones          INT                NULL,
CondicionVivienda           CHAR(1)            NOT NULL CHECK(CondicionVivienda IN ('M','B','R','L')),--'M'->MUY BUENA,'B'->BUENA,'R'->REGULAR,'L'->MALA
Observaciones               TEXT               NULL,
Luz                         CHAR(1)            NOT NULL CHECK(Luz IN ('S','N')), -- 'S'->SI,'N'->NO
Agua                        CHAR(1)            NOT NULL CHECK(Agua IN ('S','N')),-- 'S'->SI,'N'->NO
Alcantarillado              CHAR(1)			   NOT NULL CHECK(Alcantarillado IN ('S', 'N')),-- 'S'->SI,'N'->NO
Telefono                    CHAR(1)            NOT NULL CHECK (Telefono IN ('S','N')),--'S'->SI,'N'->NO
Gas                         CHAR(1)            NOT NULL CHECK(Gas IN ('S','N')),-- 'S'->SI,'N'->NO
FOREIGN KEY (NumeroPaciente)  REFERENCES Pacientes (NumeroPaciente)
)
GO


CREATE TABLE DatosAdministrativos
(
NumeroPaciente              INT                NOT NULL PRIMARY KEY,
AsignacionMensual           FLOAT              NULL,
Gratuito                    BIT                NULL DEFAULT 0,
Medicacion                  VARCHAR(60)        NULL,
PasajeRetorno               FLOAT              NULL CHECK (PasajeRetorno>=0),  
DerechoInternacion          FLOAT              NULL CHECK (DerechoInternacion>=0),
Laboratorio                 FLOAT              NULL CHECK (Laboratorio>=0),
Otros                       VARCHAR(100)        NULL,
Cancela                     CHAR(1)            NULL CHECK(Cancela IN ('S','N')), -- 'S'->SI,'N'->NO               
PacienteInstitucionalizado  CHAR(1)            NULL CHECK(PacienteInstitucionalizado IN ('S','N')), -- 'S'->SI,'N'->NO
FOREIGN KEY (NumeroPaciente)  REFERENCES Pacientes (NumeroPaciente)
)
GO


CREATE TABLE Reingresos
(
NumeroPaciente              INT               NOT NULL,
NumeroReingreso             INT               NOT NULL, --de la otra BD   (OJOOOO)
HClinico                    INT               NULL, -- de la otra BD   SON LLAVES DE LA TABLA Reingreso
FechaReingreso              DATETIME		  NOT NULL DEFAULT GETDATE(),
Unidad                      INT               NULL, --DE LA OTRA BD
Seccion                     VARCHAR(12)       NULL, --DE LA OTRA BD
Codigo                      VARCHAR(10)       NULL, --DE LA OTRA BD            
TipoDiscapacidad            VARCHAR(150)      NULL, --DE LA OTRA BD
Antecedentes                TEXT              NULL,
RelacionesFamiliares        CHAR(1)           NULL CHECK (RelacionesFamiliares IN ('B','R','M')),
--'B'->BUENO,'R'->REGULAR,'M'->MALO
PredisTratamiento            CHAR(1)          NULL CHECK (PredisTratamiento IN ('B','R','M')),
--'B'->BUENO,'R'->REGULAR,'M'->MALO
AsignacionMensual           FLOAT             NULL CHECK (AsignacionMensual>=0),
--Medicacion                  VARCHAR(50)       NULL,
--PasajeRetorno               FLOAT             NULL CHECK (PasajeRetorno>=0),
Observaciones               TEXT              NULL,
Denominacion				VARCHAR(150)	  NULL,
NumeroFolio				    INT				  NULL,
IngresoMensual             FLOAT               NULL CHECK (IngresoMensual >=0),
IngresoEventual            FLOAT               NULL CHECK (IngresoEventual >=0),
PRIMARY KEY (NumeroPaciente,NumeroReingreso),
FOREIGN KEY (NumeroPaciente) REFERENCES Pacientes(NumeroPaciente)
)
GO


CREATE TABLE TrabajadoresSociales
(
CodigoTrabajadorSocial        INT              NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombreTS                      VARCHAR (100)    NOT NULL, 
ApellidoPaternoTS             VARCHAR(60)      NOT NULL,
ApellidoMaternoTS             VARCHAR(60)      NOT NULL,
Dirección                     VARCHAR(70)      NULL,
Telefono                      VARCHAR(30)      NULL,
Celular                       VARCHAR(30)      NULL,
CodigoOcupacion				  TINYINT		   NULL,
CodigoUnidadMedica            INT              NOT NULL,
FOREIGN KEY (CodigoUnidadMedica) REFERENCES UnidadesMedicas (CodigoUnidadMedica),
CONSTRAINT FK_TrabajadoresSociales_Ocupaciones FOREIGN KEY (CodigoOcupacion)
REFERENCES Ocupaciones(CodigoOcupacion)
)
GO

CREATE TABLE Medicos
(
CodigoMedico        INT              NOT NULL IDENTITY (1,1) PRIMARY KEY,
Nombres             VARCHAR (200)    NOT NULL, 
ApellidoPaterno     VARCHAR(100)     NOT NULL,
ApellidoMaterno     VARCHAR(100)     NOT NULL,
Dirección           VARCHAR(70)      NULL,
Telefono            VARCHAR(12)      NULL,
Celular             VARCHAR(12)      NULL
)
GO


CREATE TABLE Especialidades
(
CodigoEspecialidad          INT              NOT NULL IDENTITY(1,1) PRIMARY KEY,
NombreEspecialidad          VARCHAR(150)     NOT NULL,
Descripcion                 VARCHAR(300)     NULL,
)
GO

CREATE TABLE Referencias 
(
NumeroReferencia				INT               NOT NULL,      
NumeroPaciente					INT               NOT NULL,
FechaReferencia					DATETIME          NOT NULL DEFAULT GETDATE(),
DiagnosticoPsiquiatrico     	VARCHAR(150)      NOT NULL,
CodigoMedicoResponsable			INT				  NULL,-- Medico que solicita la Referencia
CodigoTrabajadorSocial      	INT               NULL, -- Persona Referenciada
CodigoUsuario               	INT               NULL,-- Trabajadora Social de la Institucion
CodigoTipoReferencia			CHAR(1)		      NULL CHECK(CodigoTipoReferencia IN ('E','R')), -- 'S' -> SIMPLE, ENVIADA; 'R'->REFERENCIA RECIBIDA CON CONTRAREFERENCIA,
CodigoEspecialidad          	INT               NOT NULL, -- Servicios a los que se solicita
FechaContraReferencia			DATETIME		  NULL,
ObservacionesContra			    TEXT			  NULL,
Observaciones					TEXT			  NULL,
PRIMARY KEY (NumeroReferencia, NumeroPaciente),
FOREIGN KEY (NumeroPaciente)    REFERENCES Pacientes (NumeroPaciente),
FOREIGN KEY (CodigoTrabajadorSocial)REFERENCES TrabajadoresSociales (CodigoTrabajadorSocial),
FOREIGN KEY (CodigoUsuario) REFERENCES Usuarios(CodigoUsuario),
FOREIGN KEY (CodigoMedicoResponsable)REFERENCES TrabajadoresSociales (CodigoTrabajadorSocial),
FOREIGN KEY (CodigoEspecialidad) REFERENCES Especialidades (CodigoEspecialidad)
)
GO


CREATE TABLE Contrarreferencias
(
NumeroPaciente                INT              NOT NULL,
NumeroReferencia              INT              NOT NULL,
NumeroContrarreferencia       INT              NOT NULL,
FechaContrarreferencia        DATETIME         NOT NULL DEFAULT GETDATE(),
NombreMedicoAtendio           VARCHAR (150)    NULL,
Observaciones                 TEXT             NULL,
PRIMARY KEY (NumeroReferencia, NumeroPaciente, NumeroContrarreferencia ),
FOREIGN KEY (NumeroReferencia,NumeroPaciente)REFERENCES Referencias (NumeroReferencia,NumeroPaciente)
)
GO


CREATE TABLE InformesSociales
(
NumeroPaciente                 INT              NOT NULL,
NumeroInformeSocial            INT              NOT NULL,
DirigidoA                      VARCHAR(80)      NULL,
OcupacionDirigidoA             VARCHAR(80)      NULL,                                
Referencia                     VARCHAR(80)      NULL,
FechaISocial                   DATETIME		    NOT NULL DEFAULT GETDATE(),   
ReferenciaCaso                 TEXT             NULL,
AntecedentesPersonales         TEXT             NULL,
SituacionInstitucional         TEXT             NULL,
SituacionActual                TEXT             NULL,
DiagnosticoSocial              TEXT             NOT NULL,   
CodigoUsuario                  INT              NULL, 
Observaciones				   TEXT				NULL,
PRIMARY KEY (NumeroInformeSocial,NumeroPaciente),
FOREIGN KEY (NumeroPaciente) REFERENCES Pacientes (NumeroPaciente),
FOREIGN KEY (CodigoUsuario)  REFERENCES Usuarios (CodigoUsuario)
)
GO


CREATE TABLE Categorias
(
CodigoCategoria                INT            IDENTITY (1,1) NOT NULL PRIMARY KEY,              
NombreCategoria                CHAR(1)        NOT NULL,
AporteUsuario                  INT            NOT NULL,
SubvencionInstitucional        INT            NOT NULL,
PuntajeMinimo                  INT            NOT NULL,
PuntajeMaximo                  INT            NOT NULL,
)
GO


CREATE TABLE PreguntasValoracion
(
CodigoPreguntaValoracion       INT               NOT NULL IDENTITY (1,1) PRIMARY KEY, 
NombrePreguntaValoracion       VARCHAR(150)      NOT NULL,
Descripcion                    VARCHAR(300)      NULL,
)
GO


CREATE TABLE RespuestasValoracion
(
CodigoRespuestaValoracion      INT              NOT NULL IDENTITY (1,1),
CodigoPreguntaValoracion       INT              NOT NULL,
NombreRespuestaValoracion      VARCHAR(150)     NOT NULL,
Puntaje                        INT              NOT NULL,
Descripcion                    VARCHAR(300)     NULL,
PRIMARY KEY (CodigoRespuestaValoracion, CodigoPreguntaValoracion),
FOREIGN KEY (CodigoPreguntaValoracion) REFERENCES PreguntasValoracion(CodigoPreguntaValoracion)
)
GO



CREATE TABLE Servicios
(
CodigoServicio                 INT               IDENTITY (1,1) NOT NULL PRIMARY KEY,
NombreServicio                 VARCHAR(80)       NOT NULL,                      
Precio                         FLOAT             NULL CHECK (Precio>=0),
Descripcion                    VARCHAR(300)      NULL,
)
GO


CREATE TABLE PagoServicios 
(
NumeroPaciente                 INT              NOT NULL,
NumeroPagoServicio			   INT				IDENTITY(1,1)	NOT NULL,
NumeroPagoServicioManual	   INT				NOT NULL,
CodigoPagoServicio             CHAR(10)         NOT NULL,
CodigoCategoria                INT				NULL,
PorcentajeSubvencion		   FLOAT			NULL,
TipoServicio                   CHAR(1)          NOT NULL CHECK(TipoServicio IN ('I','E')),  --'I'->INTERNO, 'E'->EXTERNO
CodigoClaseServicio			   CHAR(1)			NOT NULL CHECK(CodigoClaseServicio IN ('I','R','S')),-- 'I'->INGRESO, 'R'->REINGRESO, 'S'->SERVICIO NORMAL
FechaSubvencion                DATETIME         NOT NULL DEFAULT GETDATE(),
NumeroPapeleta                 INT              NOT NULL,
NombreSubvencionA              VARCHAR(100)     NOT NULL,
Costo                          FLOAT            NULL,
Subvencion                     FLOAT            NULL,
MontoPagado					   FLOAT			NULL,--Monto pagado dentro de la categoria Z
TotalCancelar                  FLOAT            NULL,
CategoriaZ					   BIT				NULL DEFAULT 0,	
TotalPuntaje                   INT              NULL,
PacienteInstitucionalizado	   BIT				NULL DEFAULT 0,
IngresoPacienteMensual		   FLOAT			NULL DEFAULT 0,
IngresoPacienteEventual		   FLOAT			NULL DEFAULT 0,
NumeroReingreso				   INT				NULL,
Observaciones                  VARCHAR(300)     NULL,
PRIMARY KEY (NumeroPaciente, NumeroPagoServicio),
FOREIGN KEY (NumeroPaciente) REFERENCES Pacientes(NumeroPaciente),
FOREIGN KEY (CodigoCategoria) REFERENCES Categorias(CodigoCategoria),
CONSTRAINT FK_PagoServiciosReingresos FOREIGN KEY (NumeroPaciente, NumeroReingreso) REFERENCES Reingresos(NumeroPaciente, NumeroReingreso)
)
GO

CREATE TABLE PagoServiciosDetalle
(
NumeroPaciente                 INT              NOT NULL,

NumeroPagoServicio             INT              NOT NULL,
CodigoServicio				   INT				NOT NULL,
Cantidad					   INT				NOT NULL DEFAULT 1 CHECK (Cantidad > 0),
CostoServicio                  FLOAT            NOT NULL,
MontoCancelado				   FLOAT			NULL DEFAULT 0,
CodigoCategoria				   INT				NULL,
PRIMARY KEY (NumeroPaciente, NumeroPagoServicio, CodigoServicio),
FOREIGN KEY (NumeroPaciente, NumeroPagoServicio) REFERENCES PagoServicios(NumeroPaciente, NumeroPagoServicio)

)
GO

--FOREIGN KEY (CodigoServicio)REFERENCES Servicios(CodigoServicio),


CREATE TABLE ValoracionSocioEconomica
(
NumeroPaciente                 INT               NOT NULL,
FechaHoraValoracionSocioEcon   DATETIME			 NOT NULL,
CodigoRespuestaValoracion      INT               NOT NULL,
CodigoPreguntaValoracion       INT               NOT NULL,
PuntajeActual                  INT               NOT NULL,

PRIMARY KEY (CodigoRespuestaValoracion,CodigoPreguntaValoracion, NumeroPaciente, FechaHoraValoracionSocioEcon),
FOREIGN KEY  (CodigoRespuestaValoracion,CodigoPreguntaValoracion)
REFERENCES RespuestasValoracion(CodigoRespuestaValoracion,CodigoPreguntaValoracion),
CONSTRAINT FK_ValoracionSocioEconomicaPacientes FOREIGN KEY (NumeroPaciente) REFERENCES Pacientes(NumeroPaciente)
)
GO


CREATE TABLE SeguimientosSociales
(
NumeroPaciente                INT            NOT NULL,
NumeroSeguimientoSocial       INT            NOT NULL,
FechaSSocial                  DATETIME       NOT NULL,               
Observaciones                 TEXT           NOT NULL,
RecibioEncomienda             BIT			NULL,-- CHECK(RecibioEncomienda IN ('S','N')),--'S'->SI,'N'->NO
RealizoTramite                BIT			NULL,  --CHECK(RealizoTramite IN ('S','N')),--'S'->SI,'N'->NO 'SI ES SI Q MUESTRE EL FORMULARIO DE DOCUMENTOS'
PacienteDefuncion			  BIT			NULL,
PacienteDadoAlta			  BIT			NULL,
PacienteInstitucionalizo	  BIT			NULL,
PRIMARY KEY (NumeroSeguimientoSocial, NumeroPaciente),
FOREIGN KEY (NumeroPaciente)REFERENCES Pacientes (NumeroPaciente)                
)
GO


CREATE TABLE SeguimientoAnual
(
NumeroPaciente                INT             NOT NULL,
CodigoSeguimientoAnual        INT             NOT NULL,
FechaHoraRegistro			  DATE			  DEFAULT GETDATE(),
SituacionInstitucional        TEXT            NULL,
RelacionesFamiliares          TEXT            NULL,
EncomiendasRecibidas          TEXT            NULL,
InterconsultasRelalizadas     TEXT			  NULL,
GastosAdministrativos         TEXT			  NULL,
TramitesRealizados            TEXT            NULL,
PRIMARY KEY (NumeroPaciente, CodigoSeguimientoAnual),
FOREIGN KEY (NumeroPaciente) REFERENCES Pacientes(NumeroPaciente),
)
GO


CREATE TABLE ActividadesTipo
(
CodigoActividadTipo        INT              NOT NULL IDENTITY (1,1)PRIMARY KEY,
NombreActividad            VARCHAR(150)     NOT NULL,
Descripcion                VARCHAR(300)     NULL,
CodigoClaseActividad		CHAR(1)			NULL CHECK(CodigoClaseActividad IN('G','P'))--'G'->GENERICA, 'P'PACIENTES
)


CREATE TABLE Actividades
(
CodigoActividad            INT              NOT NULL,
FechaActividad             DATETIME         NOT NULL,
CodigoActividadTipo        INT              NULL,
CodigoUsuario              INT              NULL,
NumeroPaciente             INT              NULL,
TipoActividad			   CHAR(1)			NULL CHECK (TipoActividad IN ('G','P')) DEFAULT 'G',--'G'->generica, 'P'-> para pacientes
Observaciones			   TEXT				NULL,
PRIMARY KEY (CodigoActividad, FechaActividad),
FOREIGN KEY (NumeroPaciente)REFERENCES Pacientes (NumeroPaciente),
FOREIGN KEY (CodigoActividadTipo) REFERENCES ActividadesTipo (CodigoActividadTipo),
FOREIGN KEY (CodigoUsuario) REFERENCES Usuarios (CodigoUsuario)
)
GO

