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
FROM PSIQUIATRICO.dbo.Nuevo_P P 
GO
--select * from TRABAJO_SOCIAL.dbo.Pacientes

update TRABAJO_SOCIAL.dbo.Pacientes 
	SET Idioma = CASE WHEN SUBSTRING(Idioma, 2,1) IN ('Y','y') THEN 'Y' ELSE UPPER(SUBSTRING(Idioma, 1,1)) END
GO

--UPDATE TRABAJO_SOCIAL.DBO.Pacientes
--	SET Unidad = TA.Unidad,
--		Seccion = TA.Seccion,
--		Denominacion = TA.Denominacion
--FROM
--(
--	SELECT DISTINCT NP.Hc, UPPER(RTRIM(U.Seccion)) AS Seccion, U.Unidad, U.Denominacion
--	FROM PSIQUIATRICO.DBO.Nuevo_P NP
--	INNER JOIN PSIQUIATRICO.DBO.Paciente P
--	ON NP.Hc = P.Hc
--	INNER JOIN PSIQUIATRICO.DBO.Unidad U
--	ON P.Unidad = U.Unidad
--	AND P.Seccion = U.Seccion
--)TA
--WHERE TRABAJO_SOCIAL.DBO.Pacientes.HClinico = TA.Hc
--GO

--UPDATE TRABAJO_SOCIAL.DBO.Pacientes
--	SET Diagnostico = RTRIM(UPPER(TA.diagnostico))
--FROM
--(
--	SELECT DISTINCT NP.Hc, D.diagnostico
--	FROM PSIQUIATRICO.DBO.Nuevo_P NP
--	INNER JOIN PSIQUIATRICO.DBO.Movimientos P
--	ON NP.Hc = P.Hc
--	INNER JOIN PSIQUIATRICO.DBO.Diagnosticos D
--	ON P.codigo = D.codigo
--)TA
--WHERE TRABAJO_SOCIAL.DBO.Pacientes.HClinico = TA.Hc
--GO



--update TRABAJO_SOCIAL.dbo.Reingresos
--	set TipoDiscapacidad = null


DROP FUNCTION ObtenerTablaMovimiento
GO

--use TRABAJO_SOCIAL
CREATE FUNCTION ObtenerTablaMovimiento(@Hc INT)
RETURNS TABLE
AS
	RETURN(	
	SELECT TOP(1) M2.Hc, M2.Fecha_mov, M2.Unidad, M2.Seccion, U.Denominacion, UPPER(D.diagnostico) AS Diagnostico, M2.Estado, D.codigo
	FROM PSIQUIATRICO.dbo.Movimientos M2	
	INNER JOIN PSIQUIATRICO.DBO.Diagnosticos D
	ON D.codigo = M2.Codigo
	INNER JOIN PSIQUIATRICO.DBO.Unidad U
	ON U.Unidad = M2.Unidad
	AND U.Seccion = M2.Seccion
	WHERE M2.Hc= @Hc
	ORDER BY M2.Fecha_mov DESC
	)

GO
--select * from PSIQUIATRICO.dbo.Unidad

DECLARE @TPacientes TABLE
(
	Hc	INT
)
INSERT INTO @TPacientes
SELECT Hc
FROM PSIQUIATRICO.DBO.Nuevo_P

DECLARE @Hc	INT
SET ROWCOUNT 1
SELECT @Hc = Hc FROM @TPacientes
WHILE @@rowcount <> 0
BEGIN		
	
	
	UPDATE TRABAJO_SOCIAL.DBO.Pacientes
		SET Seccion = TA.Seccion,
			Unidad = TA.Unidad,
			Denominacion = TA.Denominacion,
			Diagnostico = TA.Diagnostico,
			CodigoDiagnostico = ta.codigo,
			CodigoEstadoPaciente = SUBSTRING(TA.Estado,1,1)
	FROM DBO.ObtenerTablaMovimiento(@Hc) AS TA
	WHERE TRABAJO_SOCIAL.DBO.Pacientes.HClinico = TA.Hc
	
	DELETE @TPacientes WHERE Hc = @Hc
	SET ROWCOUNT 1
	SELECT @Hc = Hc FROM @TPacientes
END
SET ROWCOUNT 0	
GO



INSERT INTO TRABAJO_SOCIAL.dbo.Reingresos (NumeroPaciente, NumeroReingreso, HClinico, 
			 FechaReingreso, Unidad, Seccion, Codigo, Antecedentes,


			RelacionesFamiliares, PredisTratamiento, AsignacionMensual, 
			Denominacion, Observaciones)
SELECT P.NumeroPaciente, RI.Nro_ReIngreso, RI.Hc,  RI.Fecha_ReIngreso,  RI.Unidad, RTRIM(UPPER(RI.seccion)) AS seccion, RI.codigo, 
			NULL, NULL, NULL, 0,  d.Denominacion, NULL
FROM PSIQUIATRICO.DBO.ReIngresos RI
INNER JOIN PSIQUIATRICO.DBO.Unidad D
ON RI.Unidad = D.Unidad
and ri.seccion = d.Seccion
INNER JOIN TRABAJO_SOCIAL.dbo.Pacientes P
ON RI.Hc = P.HClinico
GO





--CURSOR ACTUALIZADOR PARA SEGUIMIENTOS SOCIALES
USE PSIQUIATRICO;
GO
SET NOCOUNT ON;

DECLARE @Hc		INT, 
		@Fecha	DATETIME,
		@Tipo	CHAR(1),
		@NumeroPaciente	int


DECLARE SeguimientoSocialCursor CURSOR FOR 
SELECT Hc, Fecha, tipo, P.NumeroPaciente
FROM
(
	SELECT HC, Fecha_Evasion as Fecha, 'E' AS Tipo 
	FROM psiquiatrico.dbo.evasiones
	UNION all
	SELECT hc, fecha_alta, 'A' 
	FROM psiquiatrico.dbo.altas
	UNION all
	SELECT Hc, Fecha, 'D' 
	FROM psiquiatrico.dbo.Defuncion
) TA
INNER JOIN TRABAJO_SOCIAL.DBO.Pacientes P
ON P.HClinico = TA.Hc
ORDER BY Hc, Fecha, Tipo



OPEN SeguimientoSocialCursor;

FETCH NEXT FROM SeguimientoSocialCursor 
INTO @Hc, @Fecha, @Tipo, @NumeroPaciente;

WHILE @@FETCH_STATUS = 0
BEGIN
	--PRINT 'INSERTAMOS ' +  CAST(@Hc AS CHAR(10)) + ' ' + CAST(@Fecha AS CHAR(12)) + ' ' +  @Tipo + ' Nro paciente ' + cast(@NumeroPaciente as char(100))
	--PRINT 'LLAVE ' + RTRIM(CAST(@NumeroPaciente as char(100))) + ', generado  ' + RTRIM(cast(TRABAJO_SOCIAL.dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'S') as char(100)))
    INSERT INTO TRABAJO_SOCIAL.dbo.SeguimientosSociales (NumeroPaciente, NumeroSeguimientoSocial, FechaSSocial, Observaciones, RecibioEncomienda, RealizoTramite, PacienteInstitucionalizo, PacienteDefuncion, PacienteDadoAlta)
	VALUES(@NumeroPaciente, TRABAJO_SOCIAL.dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'S'), @Fecha, ' ', 0, 0, 0,
		CASE WHEN @Tipo = 'D' THEN 1 ELSE 0 END,
		CASE WHEN @Tipo = 'A' THEN 1 ELSE 0 END)
		--CASE WHEN @Tipo = 'E' THEN 1 ELSE 0 END)
        -- Get the next vendor.
        
    PRINT  CAST(TRABAJO_SOCIAL.dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'A') AS VARCHAR(10)) + ' Fecha' + CAST(@Fecha AS VARCHAR(20))
	
	INSERT INTO TRABAJO_SOCIAL.DBO.Actividades (CodigoActividad, FechaActividad, CodigoActividadTipo, CodigoUsuario, NumeroPaciente, TipoActividad, Observaciones)	
	VALUES (TRABAJO_SOCIAL.dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'A'),  @Fecha, CASE @Tipo WHEN 'E' THEN 19
		WHEN 'A' THEN 20 WHEN 'D' THEN 21 END, NULL, @NumeroPaciente, 'P', 'Actividad Migrada del Sistema de Estadistica')
		        
 --   IF(@Tipo = 'E')
 --   BEGIN
	--	INSERT INTO TRABAJO_SOCIAL.DBO.Actividades (FechaActividad, CodigoActividadTipo, CodigoUsuario, NumeroPaciente, TipoActividad, Observaciones)
	--	VALUES (TRABAJO_SOCIAL.dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'A'),  @Fecha, 19, NULL, @NumeroPaciente, 'P', 'Actividad Migrada del Sistema de Estadistica')
	--END
	
	--IF(@Tipo = 'A')
 --   BEGIN
	--	INSERT INTO TRABAJO_SOCIAL.DBO.Actividades (FechaActividad, CodigoActividadTipo, CodigoUsuario, NumeroPaciente, TipoActividad, Observaciones)
	--	VALUES (TRABAJO_SOCIAL.dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'A'),  @Fecha, 20, NULL, @NumeroPaciente, 'P', 'Actividad Migrada del Sistema de Estadistica')
	--END
	
	--IF(@Tipo = 'B')
 --   BEGIN
	--	INSERT INTO TRABAJO_SOCIAL.DBO.Actividades (FechaActividad, CodigoActividadTipo, CodigoUsuario, NumeroPaciente, TipoActividad, Observaciones)
	--	VALUES (TRABAJO_SOCIAL.dbo.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'A'),  @Fecha, 21, NULL, @NumeroPaciente, 'P', 'Actividad Migrada del Sistema de Estadistica')
	--END
        
    FETCH NEXT FROM SeguimientoSocialCursor 
    INTO @Hc, @Fecha, @Tipo,@NumeroPaciente;
END
CLOSE SeguimientoSocialCursor;
DEALLOCATE SeguimientoSocialCursor;



SELECT * FROM  TRABAJO_SOCIAL.dbo.SeguimientosSociales
SELECT * FROM  TRABAJO_SOCIAL.dbo.Actividades

DELETE FROM  TRABAJO_SOCIAL.dbo.SeguimientosSociales
DELETE FROM  TRABAJO_SOCIAL.dbo.Actividades



SELECT HC, Fecha_Evasion as Fecha, 'E' AS Tipo 
FROM psiquiatrico.dbo.evasiones
UNION all
SELECT hc, fecha_alta, 'A' 
FROM psiquiatrico.dbo.altas
UNION all
SELECT Hc, Fecha, 'D' 
FROM psiquiatrico.dbo.Defuncion


SELECT * FROM TRABAJO_SOCIAL.DBO.ActividadesTipo


SELECT HC, COUNT(*)
FROM
(
	SELECT HC, Fecha_Evasion as Fecha, 'E' AS Tipo 
	FROM psiquiatrico.dbo.evasiones
	UNION all
	SELECT hc, fecha_alta, 'A' 
	FROM psiquiatrico.dbo.altas
	UNION all
	SELECT Hc, Fecha, 'D' 
	FROM psiquiatrico.dbo.Defuncion
) TA
INNER JOIN TRABAJO_SOCIAL.DBO.Pacientes P
ON P.HClinico = TA.Hc
--ORDER BY Hc, Fecha
GROUP BY HC
order by 2 desc
