USE PSIQUIATRICO
GO

DROP TRIGGER PacientesIA
GO

CREATE TRIGGER PacientesIA
ON PSIQUIATRICO.dbo.Nuevo_P
AFTER INSERT
AS 
BEGIN
	INSERT INTO TRABAJO_SOCIAL.dbo.Pacientes (
		HClinico,NumeroFolio,FechaConsulta, 
		Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento,
		Sexo, GrupoFamiliar, EstadoCivil, GradoInstruccion, 
		Unidad, Seccion, Denominacion, FechaIngreso, Religion, 
		Idioma, Ocupacion, NombreRemitidor, LugarTrabajo, CIPaciente,
		PacienteDependiente, TipoDiscapacidad, IngresoMensual,
		IngresoEventual, Ninguno, RelacionesFamiliares,
		ObservacionRelFamiliares, PredisposicionTratamiento, Antecedentes, 
		CodigoDiagnostico, Diagnostico, 
		CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLocalidad)
	SELECT DISTINCT P.Hc, NULL, Ingreso, RTRIM(UPPER(Nombre)), RTRIM(UPPER(Paterno)), RTRIM(UPPER(Materno)),
		Nacimiento, 
		CASE Sexo WHEN 'VARONES' THEN 'M' ELSE 'F' END AS Sexo, NULL,
		CASE 
		WHEN Estado_Civil IN ('Soltero','Soltera') THEN 'SO'
		WHEN Estado_Civil IN ('Casada','Casado') THEN 'CA'
		WHEN Estado_Civil IN ('Concubina','Concubinada','Concubinado','Concubino') THEN 'CO'
		WHEN Estado_Civil IN ('Desconocido','Desconocido','NN','No se sabe') OR  Estado_Civil IS NULL THEN 'DE'
		WHEN Estado_Civil IN ('Divorciada','Divorciado','Separada','Separado') THEN 'DI'
		WHEN Estado_Civil IN ('Viuda','Viudo') THEN 'VI' END AS Estado_Civil,
		NULL, null, null, NULL, /*Unidad,Seccion,Denominacion,*/Ingreso,
		CASE
		WHEN substring(Religion,0,4)  = 'Cat' then 'C'
		WHEN substring(Religion,0,4)  = 'Eva' then 'E'
		WHEN substring(Religion,0,4)  = 'Desc' then 'D'
		WHEN substring(Religion,0,4)  = 'Cri' then 'R'
		WHEN substring(Religion,0,4)  = 'Nin' then 'N'
		WHEN substring(Religion,0,4)  = 'Adv' then 'A'
		WHEN substring(Religion,0,4)  = 'Ate' then 'T'
		WHEN substring(Religion,0,4)  = 'Mor' then 'M'
		WHEN substring(Religion,0,4)  = 'Tes' then 'J'
		WHEN substring(Religion,0,4)  = 'Pro' then 'P'
		ELSE 'O' END As Religion,  
		CASE WHEN Idioma IN ('Muda','Mudo','Sordo-mudo','No habla') THEN 'Mudo(a)'
		WHEN Idioma IS NULL THEN 'Otros'
		WHEN Idioma IN('Aleman','Alemán','ALEMANA') THEN 'Alemán'
		WHEN Idioma IN('Español-Qu','Español') THEN 'Español'
		ELSE Idioma END AS Idioma, UPPER(Profesion),NULL, NULL, NULL, 'S', NULL, 0, 0, NULL, NULL,
		NULL,'B', 'Ninguno', null, null, null, null, null, null --NULL,NULL	
	FROM INSERTED P 
	
	DECLARE @HClinico INT
	
	SET @HClinico = (SELECT Hc FROM inserted)
	
	UPDATE TRABAJO_SOCIAL.dbo.Pacientes 
		SET Idioma = CASE WHEN SUBSTRING(Idioma, 2,1) IN ('Y','y') THEN 'Y' ELSE UPPER(SUBSTRING(Idioma, 1,1)) END
	WHERE HClinico = @HClinico

END
GO


