USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarHistorialPacientesReportes
GO

--TABLAS:
--	INGRESOS
--	REINGRESOS
--	ALTAS
--	REFERENCIAS
--	INFORMES SOCIALES
--	PAGOS SERVICIOS
--FILTROS:
--	SEXO
--	EDAD ->oPERADO < <= >= > ==
--	ESTADO CIVIL
--	GRADO INSTRUCCION
--	PROCEDENCIA (DEPARTAMENTO)
--	RANGO DE FECHAS
--	TIPO PACIENTE : Externo, Interno
--	Ubicacion : Actualmente Hostializados, Altas
--	Unidad
--	Seccion
--	Categoria ->pago servicio
--	Servicio  ->pago servicio
--	Especialidad ->pago servicio
--  MedicoSolita


CREATE PROCEDURE ListarHistorialPacientesReportes
		@TipoConsulta				CHAR(1),--'I'-> INGRESOS, 'R'->REINGRESOS, 'A'->ALTAS, 'F'->REFERENCIAS, 'S'->'INFORMES SOCIALES', 'P'->PAGOS SERVICIOS, 'D'->CON DOCUMENTOS
		@OperadorComparacion		CHAR(4),-- >, >= , <, <= , =
		@CI							CHAR(10),
		@NombreApellido				VARCHAR(150),
		@Sexo						CHAR(1),--'M'->MASCULINO, 'F'->FEMENINO
		@Edad1						INT,
		@Edad2						INT,
		@CodigoEstadoCivil			CHAR(2),
		@CodigoDepartamentoProce	CHAR(2),
		@CodigoTipoPaciente			CHAR(1), --'E'->EXTERNO, 'I'->INTERNO
		@CodigoTipoUbicacion		CHAR(1), -->'A' -> ACTIVO, 'P'->PASIVO
		@Unidad						INT,
		@Seccion					VARCHAR(12),
		@CodigoCategoria			INT,
		@CodigoServicio				INT,
		@CodigoEspecialidad			INT,
		@CodigoGradoInstruccion		CHAR(1),
		@CodigoReligion				CHAR(1),
		@CodigoIdioma				CHAR(1),
		@FechaInicio				DATETIME,
		@FechaFin					DATETIME		
AS
BEGIN
	DECLARE @Consulta				VARCHAR(2000),
			@Filtro					VARCHAR(1000),
			@Where					VARCHAR(1000),
			@PosicionInicial		TINYINT,
			@PosicionActual			TINYINT,
			@PosicionFinal			TINYINT,			
			@TextoABuscarOptimizado VARCHAR(170),
			@AUX					NVARCHAR(2000)
	SET @Filtro = ''
	
	IF(@FechaInicio IS NOT NULL AND @FechaFin IS NOT NULL)
	BEGIN
		SET @FechaInicio = CONVERT(DATETIME, CONVERT(CHAR(10), @FechaInicio ,120),120)
		SET @FechaFin = DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
	END
	ELSE
	BEGIN
		SET @FechaInicio = CONVERT(DATETIME, '01/01/1900',120)
		SET @FechaFin = DATEADD(YEAR, 1, GETDATE())
	END
	
	--SELECT DBO.ObtenerCategoriaValoracionSocioEconomicaPaciente(1, 0)
	
	SET @AUX = ' '
	SET @Consulta= 'SELECT PD.* '+ 
		(CASE @TipoConsulta 
			WHEN 'R' THEN ', R.FechaReingreso AS FechaOperacion ' 
			WHEN 'A' THEN ', A.fecha_alta AS FechaOperacion ' 
			WHEN 'F' THEN ', F.FechaReferencia AS FechaOperacion,  F.MedicoSolicitante, UM.NombreUnidadMedica, UM2.NombreUnidadMedica AS NombreUnidadMedica2, E.NombreEspecialidad ' 
			WHEN 'S' THEN ', S.FechaISocial AS FechaOperacion, S.CodigoUsuario ' 
			WHEN 'P' THEN ', PS.FechaSubvencion AS FechaOperacion, S.NombreServicio, PSD.CodigoServicio, 
				--PS.MontoPagado, PS.Costo, PS.Subvencion,
				CostoServicio, MontoCancelado, CostoServicio - MontoCancelado AS Diferencia,
				CASE WHEN PS.TipoServicio = ''E'' THEN ''EXTERNO'' ELSE ''INTERNO'' END AS TipoServicio, 
				CASE PS.CodigoClaseServicio WHEN ''I'' THEN ''INGRESO'' WHEN ''R'' THEN ''REINGRESO'' ELSE ''SERVICIO'' END AS CodigoClaseServicio' 
			WHEN 'D' THEN ', DBO.ObtenerTuplaDocumentosPaciente(PD.NumeroPaciente) AS LiteralCodigoDocumentos' 
			ELSE ', PD.FechaIngreso as FechaOperacion'
		 END)
		+ ' FROM PacientesDatos  PD ' 
	IF(@TipoConsulta IS NOT NULL)
	BEGIN
	--'I'-> INGRESOS, 'R'->REINGRESOS, 'A'->ALTAS, 'F'->REFERENCIAS, 'S'->'INFORMES SOCIALES', 'P'->PAGOS SERVICIOS
		IF(@TipoConsulta = 'R')
			SET @Consulta = @Consulta + 'INNER JOIN dbo.Reingresos R ON R.NumeroPaciente = PD.NumeroPaciente '		
		ELSE IF(@TipoConsulta = 'A')
			SET @Consulta = @Consulta + 'LEFT JOIN PSIQUIATRICO.DBO.altas A ON PD.HClinico = A.hc '		
		ELSE IF(@TipoConsulta = 'F')
			SET @Consulta = @Consulta + 'INNER JOIN dbo.Referencias F ON F.NumeroPaciente = PD.NumeroPaciente 
			INNER JOIN Usuarios U ON U.CodigoUsuario = F.CodigoUsuario 
			INNER JOIN UnidadesMedicas UM ON UM.CodigoUnidadMedica = U.CodigoUnidadMedica
			INNER JOIN TrabajadoresSociales TS ON TS.CodigoTrabajadorSocial = F.CodigoTrabajadorSocial 
			INNER JOIN UnidadesMedicas UM2 ON UM2.CodigoUnidadMedica = TS.CodigoUnidadMedica 
			INNER JOIN Especialidades E ON E.CodigoEspecialidad = F.CodigoEspecialidad '
		ELSE IF(@TipoConsulta = 'S')
			SET @Consulta = @Consulta + 'INNER JOIN dbo.InformesSociales S ON S.NumeroPaciente = PD.NumeroPaciente '		
		ELSE IF(@TipoConsulta = 'P')
			SET @Consulta = @Consulta + 'INNER JOIN dbo.PagoServicios PS ON PS.NumeroPaciente = PD.NumeroPaciente 
			INNER JOIN dbo.PagoServiciosDetalle PSD 
			ON PS.NumeroPaciente = PSD.NumeroPaciente
			AND PS.NumeroPagoServicio = PSD.NumeroPagoServicio
			LEFT JOIN Servicios S ON S.CodigoServicio = PSD.CodigoServicio '
	END
	
	--SELECT * FROM PacientesDatos  PD
	SET @Filtro = ''
	
	IF(@CI IS NOT NULL)
		SET @Filtro = @Filtro + '(PD.CIPaciente LIKE ''%' + RTRIM(@CI) + '%'') AND '
	IF(@NombreApellido IS NOT NULL)
	BEGIN
		SET @PosicionInicial = 0
		SET @PosicionActual = 0
		SET @PosicionFinal = 0

		WHILE LEN(@NombreApellido) >= @PosicionActual
		BEGIN
			SET @PosicionActual = @PosicionActual + 1
			IF (SUBSTRING(@NombreApellido, @PosicionActual, 1) = ' ')
			BEGIN
				IF LEN(@AUX) > 1
					SET @AUX = @AUX + ' AND '
				SET @AUX = @AUX + ' PD.NombreCompletoPaciente LIKE' + '''%' + SUBSTRING(@NombreApellido, @PosicionInicial, (@PosicionActual - @PosicionInicial)) + '%'''			
				SET @PosicionInicial = @PosicionActual + 1
			END
		
		END
		SET @Filtro = @Filtro + '(' +LTRIM(RTRIM(@AUX)) +') AND ' 
	END
	IF(@Sexo IS NOT NULL)
		SET @Filtro = @Filtro + '(PD.CodigoSexo = ''' + @Sexo + ''') AND '
	IF(@CodigoEstadoCivil IS NOT NULL)
		SET @Filtro = @Filtro + '(PD.CodigoEstadoCivil = ''' + @CodigoEstadoCivil + ''') AND '
	IF(@CodigoDepartamentoProce IS NOT NULL)
		SET @Filtro = @Filtro + '(PD.CodigoDepartamento = ''' + @CodigoDepartamentoProce + ''') AND '
	IF(@CodigoTipoPaciente IS NOT NULL)
		SET @Filtro = @Filtro + (CASE WHEN @CodigoTipoPaciente = 'E' THEN  '(PD.HClinico IS NULL ) AND ' ELSE ' PD.HClinico IS NOT NULL  AND ' END)
	IF(@CodigoGradoInstruccion IS NOT NULL)
		SET @Filtro = @Filtro + '(PD.CodigoGradoInstruccion = ''' + @CodigoGradoInstruccion + ''') AND '
	IF(@CodigoReligion IS NOT NULL)
		SET @Filtro = @Filtro + '(PD.CodigoReligion = ''' + @CodigoReligion + ''') AND '
	IF(@CodigoIdioma IS NOT NULL)
		SET @Filtro = @Filtro + '(PD.CodigoIdioma = ''' + @CodigoIdioma + ''') AND '
	--********************FALTA**************************
	IF(@CodigoTipoUbicacion IS NOT NULL)--FALTA
		SET @Filtro = @Filtro + '(PD.CodigoEstadoPaciente = ''' + @CodigoTipoUbicacion + ''') AND '		
	--********************COMPLETAR**************************
	
	
	IF(@Edad1 IS NOT NULL AND @Edad2 IS NOT NULL)
	BEGIN
		SET @Filtro = @Filtro + '(PD.EdadActual BETWEEN ' + CAST(@Edad1 AS CHAR(10))+ ' AND ' + CAST(@Edad2 AS CHAR(10))+ ' ) AND '
	END
	IF(@Edad1 IS NOT NULL AND @Edad2 IS NULL)
	BEGIN
		SET @Filtro = @Filtro + '(PD.EdadActual ' + @OperadorComparacion + CAST(@Edad1 AS CHAR(10))+ ' ) AND '
	END
	IF(@Unidad IS NOT NULL)
		SET @Filtro = @Filtro + '(PD.Unidad = ' + CAST(@Unidad AS CHAR(100))+ ') AND '
	IF(@Seccion IS NOT NULL)
		SET @Filtro = @Filtro + '(PD.Seccion = ''' + @Seccion + ''') AND '
	IF(@CodigoCategoria IS NOT NULL)
		SET @Filtro = @Filtro + '(PD.CodigoCategoria = '  + CAST(@CodigoCategoria AS CHAR(100))+ ') AND '	
	IF(@CodigoServicio IS NOT NULL)
		SET @Filtro = @Filtro + '(PSD.CodigoServicio = '  + CAST(@CodigoServicio AS CHAR(100))+ ') AND '
	IF(@CodigoEspecialidad IS NOT NULL)
		SET @Filtro = @Filtro + '(PS.CodigoEspecialidad = '  + CAST(@CodigoEspecialidad AS CHAR(100))+ ') AND '
	
	IF(@FechaFin IS NOT NULL AND @FechaFin IS NOT NULL)
	BEGIN
	--'I'-> INGRESOS, 'R'->REINGRESOS, 'A'->ALTAS, 'F'->REFERENCIAS, 'S'->'INFORMES SOCIALES', 'P'->PAGOS SERVICIOS
		IF(@TipoConsulta = 'R')
			SET @Filtro = @Filtro + '(R.FechaReingreso BETWEEN ''' + CAST(@FechaInicio AS CHAR(12)) + ''' AND '''+ CAST(@FechaFin AS CHAR(12))+''') AND '
		ELSE IF(@TipoConsulta = 'I')
			SET @Filtro = @Filtro + '(PD.FechaIngreso BETWEEN ''' + CAST(@FechaInicio AS CHAR(12)) + ''' AND '''+ CAST(@FechaFin AS CHAR(12))+''') AND '
		ELSE IF(@TipoConsulta = 'A')
			SET @Filtro = @Filtro + '(A.fecha_alta BETWEEN ''' + CAST(@FechaInicio AS CHAR(12)) + ''' AND '''+ CAST(@FechaFin AS CHAR(12))+''') AND '
		ELSE IF(@TipoConsulta = 'F')
			SET @Filtro = @Filtro + '(F.FechaReferencia BETWEEN ''' + CAST(@FechaInicio AS CHAR(12)) + ''' AND '''+ CAST(@FechaFin AS CHAR(12))+''') AND '
		ELSE IF(@TipoConsulta = 'S')
			SET @Filtro = @Filtro + '(S.FechaISocial BETWEEN ''' + CAST(@FechaInicio AS CHAR(12)) + ''' AND '''+ CAST(@FechaFin AS CHAR(12))+''') AND '
		ELSE IF(@TipoConsulta = 'P')
			SET @Filtro = @Filtro + '(PS.FechaSubvencion BETWEEN ''' + CAST(@FechaInicio AS CHAR(12)) + ''' AND '''+ CAST(@FechaFin AS CHAR(12))+''') AND '
	END
	IF(LEN(@Filtro) > 1)
	BEGIN
		PRINT SUBSTRING(@Filtro, LEN(@Filtro) - 3 , LEN(@Filtro))
		IF( SUBSTRING(@Filtro, LEN(@Filtro) - 3 , LEN(@Filtro)) = ' AND ')			
			SET @Where = 'WHERE ' + SUBSTRING(@Filtro,0, LEN(@Filtro) - 2)
		ELSE
			SET @Where = 'WHERE ' + @Filtro
	END
	
	IF(LEN (@Where) > 1)
		SET @Consulta = @Consulta + RTRIM(LTRIM(@Where))
		
	PRINT @Consulta
	EXEC (@Consulta)
END
GO

--exec ListarHistorialPacientesReportes NULL,'LUIS MOLINA',NULL,'V',1,3,1,null,null, 0,  '20100101 09:15:20.203', '20101230 09:15:20.203'
--exec ListarHistorialPacientesReportes NULL,'LUIS MOLINA',NULL,null,NULL,NULL,NULL,null,null, NULL, NULL,NULL
--exec ListarHistorialPacientesReportes NULL,NULL,NULL,null,NULL,NULL,NULL,null,null, NULL, NULL,NULL


--SELECT P.DIPersona, dbo.ObtenerNombreCompleto(P.CodigoPersona) AS NombreCompleto, 
--P.FechaNacimiento, 
--CASE P.Escolaridad WHEN 'P' THEN 'PRIMARIA' WHEN 'S' THEN 'SECUNDARIA' WHEN 'U' THEN 'UNIVERSITARIA' WHEN 'F' THEN 'PROFESIONAL' WHEN 'O' THEN 'OTROS' END AS Escolaridad, 
--CASE P.CodigoEstadoCivil WHEN 'S' THEN 'SOLTERO(A)' WHEN 'D' THEN 'DIVORCIADO(A)' WHEN 'C' THEN 'CASADO(A)' WHEN 'V' THEN 'VIUDO(A)' ELSE 'INDETERMINADO' END AS CodigoEstadoCivil,
--PH.FechaRegistroHistorial, RA.NombreRazonAtencion, 
--CASE PH.CasoConConciliacion WHEN 1 THEN 'CON CONCILIACION' ELSE 'SIN CONCILIACION' END AS CasoConConciliacion,
--CASE PH.CasoConJuicio WHEN 1 THEN 'CON JUICIO' ELSE  'SIN JUICIO' END AS CasoConJuicio,
--CASE PH.CasoConMinisterioTrabajo WHEN 1 THEN 'MINISTERIO DE TRABAJO' ELSE ' ' END AS CasoConMinisterioTrabajo,
--CASE PH.CasoSolucionado WHEN 1 THEN 'SOLUCIONADO' ELSE ' ' END AS CasoSolucionado
--FROM Personas P
--INNER JOIN PersonasHistorial PH
--ON P.CodigoPersona = PH.CodigoPersona
--INNER JOIN RazonAtencion RA
--ON PH.CodigoRazonAtencion = RA.CodigoRazonAtencion



--EXEC ListarHistorialPacientesReportes null, '=', NULL, NULL, NULL, 50, null, NULL, NULL, 'I', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL
EXEC ListarHistorialPacientesReportes  'P', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, null, NULL, NULL, NULL,NULL,NULL, NULL

