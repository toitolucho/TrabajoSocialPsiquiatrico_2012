USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarKardexPersonalPaciente
GO

CREATE PROCEDURE ListarKardexPersonalPaciente
	@NumeroPaciente	INT
AS
BEGIN

	DECLARE @TResponsables TABLE
	(
		NumeroPaciente      INT          NOT NULL,
		CodigoResponsable   INT          NOT NULL,
		CodigoParentesco    INT          NULL,        
		NombreApellidos     VARCHAR(100) NULL,
		Direccion           VARCHAR(100) NULL,
		Telefono            VARCHAR(12)  NULL,
		Celular             VARCHAR(12)  NULL,
		CodigoPais          CHAR(2)      NULL,
		CodigoDepartamento	CHAR(2)		 NULL,
		CodigoProvincia		CHAR(2)		 NULL,
		CodigoLocalidad 	CHAR(2)		 NULL

	)

	INSERT INTO @TResponsables (NumeroPaciente, CodigoResponsable, CodigoParentesco, NombreApellidos, Direccion, Telefono, Celular,
					CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLocalidad)
	EXEC DBO.ObtenerResponsableUltimo @NumeroPaciente

	SELECT	P.NumeroPaciente, RESP.CodigoResponsable,
			P.HClinico, P.Denominacion, UPPER(P.Nombre + ' '+ P.ApellidoPaterno + ' ' +P.ApellidoMaterno) AS NombreCompletoPaciente,
			PA.NombrePais AS PaisNacimiento, DEP.NombreDepartamento as DepartamentoNacimiento, 
			PRO.NombreProvincia as ProvinciaNacimiento, LOC.NombreLocalidad as LocalidadNacimiento, P.FechaNacimiento, 
			DBO.ObtenerEdad( P.FechaNacimiento, P.FechaIngreso) AS EdadIngreso,
			CASE P.EstadoCivil WHEN 'SO' THEN 'SOLTERO(A)' WHEN 'CA' THEN 'CASADO(A)' WHEN 'DI' THEN 'DIVORCIADO(A)'
			WHEN 'VI' THEN 'VIUDO(A)' WHEN 'CO' THEN 'CONCUBINADO(A)' ELSE 'INDETERMINADO' END AS EstadoCivil, 
			P.EstadoCivil as CodigoEstadoCivil, P.Ocupacion, 
			CASE P.GradoInstruccion WHEN 'A' THEN 'ANALFABETO'
			WHEN 'P' THEN 'PRIMARIA'
			WHEN 'S' THEN 'SECUNDARIA'
			WHEN 'U' THEN 'UNIVERSITARIA'
			WHEN 'T' THEN 'TECNICO SUPERIOR'
			WHEN 'R' THEN 'SUPERIOR' END AS GradoInstruccion, P.GradoInstruccion AS CodigoGradoInstruccion,
			PA2.NombrePais as PaisProcedencia, DEP2.NombreDepartamento as DepartamentoProcedencia, 
			PRO2.NombreProvincia ProvinciaProcedencia, LOC2.NombreLocalidad as LocalidadProcedencia,
			DIR.ZonaBarrio, DIR.CalleAvenida, DIR.Numero, DIR.Telefono,
			RESP.NombreApellidos, PAR.NombreParentesco,
			RESP.Direccion, RESP.Telefono,RESP.Celular,
			PA3.NombrePais as PaisResponsable, DEP3.NombreDepartamento as DepartamentoResponsable, 
			PRO3.NombreProvincia ProvinciaResponsable, LOC3.NombreLocalidad as LocalidadResponsable
			
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
	LEFT JOIN @TResponsables RESP
	ON P.NumeroPaciente = RESP.NumeroPaciente
	LEFT JOIN Parentescos PAR
	ON RESP.CodigoParentesco = PAR.CodigoParentesco 
	LEFT JOIN Paises PA3
	ON P.CodigoPais = PA3.CodigoPais
	LEFT JOIN Departamentos DEP3
	ON P.CodigoDepartamento = DEP3.CodigoDepartamento
	AND P.CodigoPais = DEP3.CodigoPais
	LEFT JOIN Provincias PRO3
	ON P.CodigoProvincia = PRO3.CodigoProvincia
	AND P.CodigoPais = PRO3.CodigoPais
	AND P.CodigoDepartamento = PRO3.CodigoDepartamento
	LEFT JOIN Localidades LOC3
	ON P.CodigoLocalidad = LOC3.CodigoLocalidad
	AND P.CodigoPais = LOC3.CodigoPais
	AND P.CodigoDepartamento = LOC3.CodigoDepartamento
	AND P.CodigoProvincia = LOC3.CodigoProvincia
	WHERE P.NumeroPaciente = @NumeroPaciente
	ORDER BY P.NumeroPaciente ASC, RESP.CodigoResponsable DESC

END
GO
