USE TRABAJO_SOCIAL
GO

DROP VIEW PacientesDatos
GO

CREATE VIEW PacientesDatos
AS

SELECT		P.NumeroPaciente, P.NumeroFolio, p.FechaConsulta, P.GrupoFamiliar,  p.Unidad, p.Seccion,
			P.FechaIngreso, CASE P.Religion
				WHEN 'C' THEN 'CATOLICO'
				WHEN 'E' THEN 'EVANGELICO'
				WHEN 'R' THEN 'CRISTIANO'
				WHEN 'A' THEN 'ADVENTISTA'
				WHEN 'T' THEN 'ATEO'
				WHEN 'M' THEN 'MORMON'
				WHEN 'J' THEN 'TESTIGO DE JEHOVA'
				WHEN 'P' THEN 'PROTESTANTE'
				WHEN 'D' THEN 'DESCONOCIDO'
				WHEN 'N' THEN 'NINGUNO'
			WHEN 'O' THEN 'OTROS' END AS Religion, p.Religion as CodigoReligion,
			CASE P.Idioma 			
				WHEN 'E' THEN 'ESPAÑOL'
				WHEN 'Q' THEN 'QUECHUA'
				WHEN 'Y' THEN 'AYMARA'
				WHEN 'G' THEN 'GUARANI'
				WHEN 'I' THEN 'INGLES'
				WHEN 'A' THEN 'ALEMAN'
				WHEN 'M' THEN 'MUDO'
				WHEN 'O' THEN 'OTROS' END AS Idioma, P.Idioma AS CodigoIdioma,
			P.NombreRemitidor, P.LugarTrabajo, P.CIPaciente, P.sexo as CodigoSexo,
			CASE P.Sexo WHEN 'M' THEN 'MASCULINO' ELSE 'FEMENINO' END AS Sexo, 			
			CASE P.PacienteDependiente WHEN 'S' THEN 'SI' ELSE 'NO' END AS PacienteDependiente,
			P.TipoDiscapacidad, P.IngresoMensual, P.IngresoEventual, P.Ninguno,
			CASE P.RelacionesFamiliares WHEN 'B' THEN 'BUENA'
			WHEN 'R' THEN 'REGULAR' WHEN 'M' THEN 'MALA' END AS RelacionesFamiliares,
			P.ObservacionRelFamiliares, P.PredisposicionTratamiento AS CodigoPredisposicionTratamiento,
			CASE P.PredisposicionTratamiento WHEN 'B' THEN 'BUENA'
			WHEN 'R' THEN 'REGULAR' WHEN 'M' THEN 'MALA' END AS PredisposicionTratamiento,
			p.Antecedentes, p.CodigoDiagnostico, p.Diagnostico,
			P.HClinico, P.Denominacion, UPPER(P.Nombre + ' '+ P.ApellidoPaterno + ' ' +P.ApellidoMaterno) AS NombreCompletoPaciente,
			PA.NombrePais AS PaisNacimiento, DEP.NombreDepartamento as DepartamentoNacimiento, 
			PRO.NombreProvincia as ProvinciaNacimiento, LOC.NombreLocalidad as LocalidadNacimiento, P.FechaNacimiento, 
			DBO.ObtenerEdad( P.FechaNacimiento, P.FechaIngreso) AS EdadIngreso,
			DBO.ObtenerEdad( P.FechaNacimiento, GETDATE()) AS EdadActual,
			CASE P.EstadoCivil WHEN 'SO' THEN 'SOLTERO(A)' WHEN 'CA' THEN 'CASADO(A)' WHEN 'DI' THEN 'DIVORCIADO(A)'
			WHEN 'VI' THEN 'VIUDO(A)' WHEN 'CO' THEN 'CONCUBINADO(A)' ELSE 'DESCONOCIDO' END AS EstadoCivil, 
			P.EstadoCivil as CodigoEstadoCivil, P.Ocupacion, 
			CASE P.GradoInstruccion WHEN 'A' THEN 'ANALFABETO'
				WHEN 'P' THEN 'PRIMARIA'
				WHEN 'S' THEN 'SECUNDARIA'
				WHEN 'U' THEN 'UNIVERSITARIA'
				WHEN 'T' THEN 'TECNICO SUPERIOR'
				WHEN 'R' THEN 'SUPERIOR' END AS GradoInstruccion, P.GradoInstruccion AS CodigoGradoInstruccion,
			DEP2.CodigoDepartamento, 
			PA2.NombrePais as PaisProcedencia, DEP2.NombreDepartamento as DepartamentoProcedencia, 
			PRO2.NombreProvincia ProvinciaProcedencia, LOC2.NombreLocalidad as LocalidadProcedencia,
			DIR.ZonaBarrio, DIR.CalleAvenida, DIR.Numero, DIR.Telefono,
			DBO.ObtenerCategoriaValoracionSocioEconomicaPaciente(p.NumeroPaciente, 1) AS CodigoCategoria,		
			DBO.ObtenerCategoriaValoracionSocioEconomicaPaciente(p.NumeroPaciente, 0) AS Categoria,
			CASE V.Vivienda WHEN 'C' THEN 'CASA' WHEN 'D' THEN 'DEPARTAMENTO' 
			WHEN 'H' THEN 'HABITACION' WHEN 'O' THEN 'OTROS' END as Vivienda,  V.Vivienda as CodigoClaseVivienda,
			CASE V.TipoVivienda WHEN 'P' THEN 'PROPIA' WHEN 'A' THEN 'ALQUILADA' 
			WHEN 'N' THEN 'ANTICRETICO' WHEN'O' THEN 'OTROS' END AS TipoVivienda, v.TipoVivienda as CodigoTipoVivienda,
			CASE V.CondicionVivienda WHEN  'M' THEN 'MUY BUENA' WHEN 'B' THEN 'BUENA' 
			WHEN 'R' THEN 'REGULAR' WHEN 'L' THEN 'MALA' END AS CondicionVivienda, V.CondicionVivienda AS CodigoCondicionVivienda,
			V.Observaciones AS ObservacionesVivienda, v.Luz, V.Agua, V.Alcantarillado, V.Telefono as TelefonoV, V.Gas,
			DBO.OtenerParentescoResponsableEconomico(p.NumeroPaciente) as ParentescoResponsable, P.PacienteInstitucionalizado,
			P.CodigoEstadoPaciente, CASE WHEN P.CodigoEstadoPaciente = 'A' THEN 'ACTIVO' ELSE  'PASIVO' END AS EstadoPaciente
	FROM Pacientes P
	LEFT JOIN Paises PA
	ON P.CodigoPais = PA.CodigoPais
	LEFT JOIN Departamentos DEP
	ON P.CodigoDepartamento = DEP.CodigoDepartamento
	AND P.CodigoPais = DEP.CodigoPais
	LEFT JOIN Provincias PRO
	ON P.CodigoProvincia = PRO.CodigoProvincia
	AND P.CodigoPais = PRO.CodigoPais
	AND P.CodigoDepartamento = PRO.CodigoDepartamento
	LEFT JOIN Localidades LOC
	ON P.CodigoLocalidad = LOC.CodigoLocalidad
	AND P.CodigoPais = LOC.CodigoPais
	AND P.CodigoDepartamento = LOC.CodigoDepartamento
	AND P.CodigoProvincia = LOC.CodigoProvincia
	LEFT JOIN Paises PA2
	ON P.CodigoPais = PA2.CodigoPais
	LEFT JOIN Departamentos DEP2
	ON P.CodigoDepartamento = DEP2.CodigoDepartamento
	AND P.CodigoPais = DEP2.CodigoPais
	LEFT JOIN Provincias PRO2
	ON P.CodigoProvincia = PRO2.CodigoProvincia
	AND P.CodigoPais = PRO2.CodigoPais
	AND P.CodigoDepartamento = PRO2.CodigoDepartamento
	LEFT JOIN Localidades LOC2
	ON P.CodigoLocalidad = LOC2.CodigoLocalidad
	AND P.CodigoPais = LOC2.CodigoPais
	AND P.CodigoDepartamento = LOC2.CodigoDepartamento
	AND P.CodigoProvincia = LOC2.CodigoProvincia
	LEFT JOIN Direcciones DIR
	ON P.NumeroPaciente = DIR.NumeroPaciente
	LEFT JOIN Viviendas V
	ON P.NumeroPaciente = V.NumeroPaciente
GO