USE TRABAJO_SOCIAL
GO

DROP PROCEDURE BuscarPacienteOperaciones
GO


CREATE PROCEDURE BuscarPacienteOperaciones
	@TextoBusqueda		VARCHAR(200),
	@FechaHoraInicio	DATETIME,
	@FechaHOraFin		DATETIME,
	@TipoOperacion		CHAR(1)
AS
BEGIN
	DECLARE @Filtro CHAR(1) 			
	IF (@FechaHoraInicio IS NULL AND @FechaHOraFin IS NULL)
	BEGIN
		IF(@TipoOperacion = 'I')--Informes Sociales
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.NumeroInformeSocial as NumeroOperacion, R.FechaISocial as FechaOperacion,
					R.*
			FROM Pacientes P
			INNER JOIN InformesSociales R
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	
		END
		IF(@TipoOperacion = 'V') --ACTIVIDADES
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, A.CodigoActividad as NumeroOperacion, 
					A.FechaActividad as FechaOperacion, DBO.ObtenerNombreCompleto(A.CodigoUsuario) AS NombreTrabajadoraSocial,
					AT.NombreActividad, A.*
			FROM Pacientes P
			INNER JOIN dbo.Actividades A
			ON P.NumeroPaciente = A.NumeroPaciente
			INNER JOIN dbo.ActividadesTipo AT
			ON A.CodigoActividadTipo = AT.CodigoActividadTipo
			WHERE P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	
			OR AT.NombreActividad LIKE '%' + @TextoBusqueda + '%'	
		END
		
		
		IF(@TipoOperacion = 'F')
		BEGIN			
			IF(CHARINDEX('|',@TextoBusqueda) > 0)
			BEGIN
				SET @Filtro = LTRIM(RTRIM(SUBSTRING(@TextoBusqueda, CHARINDEX('|',@TextoBusqueda) + 1, LEN(@TextoBusqueda))))
				SET @TextoBusqueda = SUBSTRING(@TextoBusqueda,0,  CHARINDEX('|',@TextoBusqueda))
				
			END
			
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.NumeroReferencia as NumeroOperacion, R.FechaReferencia as FechaOperacion,
					MED.NombreTS + ' ' + MED.ApellidoPaternoTS + ' ' + MED.ApellidoMaternoTS AS MedicoResponsable,
					UM.NombreUnidadMedica, E.NombreEspecialidad, CR.NumeroContrarreferencia, CR.FechaContrarreferencia, CR.Observaciones AS ObservacionesCR,
					R.*
			FROM Pacientes P
			INNER JOIN Referencias R			
			ON P.NumeroPaciente = R.NumeroPaciente
			INNER JOIN dbo.Especialidades E
			ON E.CodigoEspecialidad = R.CodigoEspecialidad
			LEFT JOIN dbo.TrabajadoresSociales MED
			ON R.CodigoMedicoResponsable = MED.CodigoTrabajadorSocial
			LEFT JOIN dbo.TrabajadoresSociales TS
			ON R.CodigoTrabajadorSocial = TS.CodigoTrabajadorSocial
			LEFT JOIN dbo.UnidadesMedicas UM
			ON TS.CodigoUnidadMedica = UM.CodigoUnidadMedica
			LEFT JOIN Contrarreferencias CR
			ON R.NumeroReferencia = CR.NumeroReferencia
			WHERE CodigoTipoReferencia LIKE CASE WHEN @Filtro IS NOT NULL THEN @Filtro ELSE '%%' END
			AND(
			P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	)
			ORDER BY p.HClinico
		END
		IF(@TipoOperacion = 'N') -- LISTAR REFERENCIAS QUE NO SE HAYAN RELACIONADO CON CONTRARREFERENCIAS
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.NumeroReferencia as NumeroOperacion, R.FechaReferencia as FechaOperacion,
					R.*
			FROM Pacientes P
			INNER JOIN Referencias R
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE R.NumeroReferencia NOT IN
			(
				SELECT NumeroReferencia
				FROM Contrarreferencias
			)
			OR
			(
			P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	)
		END
		IF(@TipoOperacion = 'R')
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.NumeroReingreso as NumeroOperacion, R.FechaReingreso as FechaOperacion,
					R.*
			FROM Pacientes P
			INNER JOIN Reingresos R
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	
		END
		IF(@TipoOperacion = 'C')
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.NumeroContrarreferencia as NumeroOperacion, R.FechaContrarreferencia as FechaOperacion,
					R.*
			FROM Pacientes P
			INNER JOIN Contrarreferencias R
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	
		END
		IF(@TipoOperacion = 'P')
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.NumeroPagoServicio as NumeroOperacion, R.FechaSubvencion as FechaOperacion,
					CASE R.CodigoClaseServicio WHEN 'I' THEN 'INGRESOS' WHEN 'R' THEN 'REINGRESO' ELSE 'ATENCION MEDICA' END AS ClaseServicio,
					R.*
			FROM Pacientes P
			INNER JOIN PagoServicios R
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	
		END
		IF(@TipoOperacion = 'S')--SEGUIMIENTO SOCIAL.
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.NumeroSeguimientoSocial as NumeroOperacion, R.FechaSSocial as FechaOperacion,
					R.*
			FROM Pacientes P
			INNER JOIN SeguimientosSociales R
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	
		END
		IF(@TipoOperacion = 'A')--SEGUIMIENTO ANUAL.
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.CodigoSeguimientoAnual as NumeroOperacion, R.FechaHoraRegistro as FechaOperacion,
					R.*
			FROM Pacientes P
			INNER JOIN SeguimientoAnual R
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	
		END
	END
	ELSE
	BEGIN
		IF(@TipoOperacion = 'I')--Informes Sociales
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.NumeroInformeSocial as NumeroOperacion, R.FechaISocial as FechaOperacion,
					R.*
			FROM Pacientes P
			INNER JOIN InformesSociales R
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE 
			R.FechaISocial BETWEEN @FechaHoraInicio AND @FechaHOraFin			
			AND( P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	
			 )
		END
		
		IF(@TipoOperacion = 'V') --ACTIVIDADES
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, A.CodigoActividad as NumeroOperacion, 
					A.FechaActividad as FechaOperacion, DBO.ObtenerNombreCompleto(A.CodigoUsuario) AS NombreTrabajadoraSocial,
					AT.NombreActividad, A.*
			FROM Pacientes P
			INNER JOIN dbo.Actividades A
			ON P.NumeroPaciente = A.NumeroPaciente
			INNER JOIN dbo.ActividadesTipo AT
			ON A.CodigoActividadTipo = AT.CodigoActividadTipo
			WHERE A.FechaActividad BETWEEN @FechaHoraInicio AND @FechaHOraFin			
			AND (P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	
			OR AT.NombreActividad LIKE '%' + @TextoBusqueda + '%')
		END
		
		IF(@TipoOperacion = 'F')
		BEGIN
			
			
			IF(CHARINDEX('|',@TextoBusqueda) > 0)
			BEGIN
				SET @Filtro = LTRIM(RTRIM(SUBSTRING(@TextoBusqueda, CHARINDEX('|',@TextoBusqueda) + 1, LEN(@TextoBusqueda))))
				SET @TextoBusqueda = SUBSTRING(@TextoBusqueda,0,  CHARINDEX('|',@TextoBusqueda))
				
			END
		
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.NumeroReferencia as NumeroOperacion, R.FechaReferencia as FechaOperacion,
					MED.NombreTS + ' ' + MED.ApellidoPaternoTS + ' ' + MED.ApellidoMaternoTS AS MedicoResponsable,
					UM.NombreUnidadMedica, E.NombreEspecialidad, CR.NumeroContrarreferencia, CR.FechaContrarreferencia, CR.Observaciones AS ObservacionesCR,
					R.*
			FROM Pacientes P
			INNER JOIN Referencias R			
			ON P.NumeroPaciente = R.NumeroPaciente
			INNER JOIN dbo.Especialidades E
			ON E.CodigoEspecialidad = R.CodigoEspecialidad
			LEFT JOIN dbo.TrabajadoresSociales MED
			ON R.CodigoMedicoResponsable = MED.CodigoTrabajadorSocial
			LEFT JOIN dbo.TrabajadoresSociales TS
			ON R.CodigoTrabajadorSocial = TS.CodigoTrabajadorSocial
			LEFT JOIN dbo.UnidadesMedicas UM
			ON TS.CodigoUnidadMedica = UM.CodigoUnidadMedica
			LEFT JOIN Contrarreferencias CR
			ON R.NumeroReferencia = CR.NumeroReferencia
			WHERE R.FechaReferencia BETWEEN @FechaHoraInicio AND @FechaHOraFin			
			AND CodigoTipoReferencia LIKE CASE WHEN @Filtro IS NOT NULL THEN @Filtro ELSE '%%' END
			AND
			(P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	
			) 
			ORDER BY p.HClinico
		END
		IF(@TipoOperacion = 'N') -- LISTAR REFERENCIAS QUE NO SE HAYAN RELACIONADO CON CONTRARREFERENCIAS
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.NumeroReferencia as NumeroOperacion, R.FechaReferencia as FechaOperacion,
					R.*
			FROM Pacientes P
			INNER JOIN Referencias R
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE R.FechaReferencia BETWEEN @FechaHoraInicio AND @FechaHOraFin			
			AND
			R.NumeroReferencia NOT IN
			(
				SELECT NumeroReferencia
				FROM Contrarreferencias
			)
			OR
			(
			P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	)
		END
		IF(@TipoOperacion = 'R')
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.NumeroReingreso as NumeroOperacion, R.FechaReingreso as FechaOperacion,
					R.*
			FROM Pacientes P
			INNER JOIN Reingresos R
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE R.FechaReingreso BETWEEN @FechaHoraInicio AND @FechaHOraFin
			AND( P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	
			)
		END
		IF(@TipoOperacion = 'C')
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.NumeroContrarreferencia as NumeroOperacion, R.FechaContrarreferencia as FechaOperacion,
					R.*
			FROM Pacientes P
			INNER JOIN Contrarreferencias R
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE R.FechaContrarreferencia BETWEEN @FechaHoraInicio AND @FechaHOraFin
			AND( P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	
			)
		END
		IF(@TipoOperacion = 'P')
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.NumeroPagoServicio as NumeroOperacion, R.FechaSubvencion as FechaOperacion,
					CASE R.CodigoClaseServicio WHEN 'I' THEN 'INGRESOS' WHEN 'R' THEN 'REINGRESO' ELSE 'ATENCION MEDICA' END AS ClaseServicio,
					R.*
			FROM Pacientes P
			INNER JOIN PagoServicios R
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE FechaSubvencion BETWEEN @FechaHoraInicio AND @FechaHOraFin	
			AND( P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'
			)
		END
		IF(@TipoOperacion = 'S')--SEGUIMIENTO SOCIAL.
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion, 
					p.Ocupacion, p.Religion, R.NumeroSeguimientoSocial as NumeroOperacion, R.FechaSSocial as FechaOperacion,
					R.*
			FROM Pacientes P
			INNER JOIN SeguimientosSociales R 
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE FechaSSocial BETWEEN @FechaHoraInicio AND @FechaHOraFin	
			AND( P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'	
			)
		END
		IF(@TipoOperacion = 'A')--SEGUIMIENTO ANUAL.
		BEGIN
			SELECT  p.HClinico, p.NumeroPaciente, DBO.ObtenerNombreCompleto(P.NumeroPaciente) AS NombreCompleto,
					P.CIPaciente, p.Denominacion, p.EstadoCivil, p.FechaNacimiento, p.GradoInstruccion,
					p.Ocupacion, p.Religion, R.CodigoSeguimientoAnual as NumeroOperacion, R.FechaHoraRegistro as FechaOperacion,
					R.*
			FROM Pacientes P
			INNER JOIN SeguimientoAnual R
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE FechaHoraRegistro BETWEEN @FechaHoraInicio AND @FechaHOraFin		
			AND( P.Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.HClinico AS VARCHAR(20)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR P.Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(P.NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR P.Seccion LIKE '%' + @TextoBusqueda + '%'
			 )
		END
	END	
END
GO

