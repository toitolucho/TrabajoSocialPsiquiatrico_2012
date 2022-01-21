USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarCantidadSubvencionSocialPorServicio
GO

CREATE PROCEDURE ListarCantidadSubvencionSocialPorServicio
	@FechaInicio	DATE,
	@FechaFin		DATE,
	@BuscarEn		CHAR(1)--'H'->PACIENTES HOSPITALIZADOS, 'E'->PACIENTES CONSULTA EXTERNA
AS
BEGIN
	
	IF(@FechaInicio > @FechaFin)
		RAISERROR ('Rango de Meses INVALIDO', 17, 2)
	ELSE
	BEGIN
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
	
		DECLARE @TListaCategorias TABLE
		(
			CodigoCategoria			INT,
			NombreCategoria			CHAR(1),
			SubvencionInstitucional	INT
		)
		INSERT INTO @TListaCategorias (CodigoCategoria, NombreCategoria, SubvencionInstitucional)
		SELECT CodigoCategoria, NombreCategoria, SubvencionInstitucional FROM Categorias
		
		
		DECLARE	@CodigoCategoria	INT,
				@NombreCategoria	VARCHAR(150)

		
		DECLARE @Consulta		VARCHAR(4000),
				@ConsultaGral	VARCHAR(4000),				
				@CamposMostrar	VARCHAR(4000),
				@EntreFechas	VARCHAR(110),
				@Consulta2		VARCHAR(4000),
				@CamposMostrar2	VARCHAR(4000),
				@ConsultaGral2	VARCHAR(4000)
		
		SET @Consulta = ''
		SET @CamposMostrar = ''
		SET @Consulta2 = ''
		SET @CamposMostrar2 = ''
	 	SET @EntreFechas = 'AND PS.FechaSubvencion BETWEEN  '''+ RTRIM(CAST(DATEPART(DAY,@FechaInicio) AS CHAR(2)))+'/'
												  +	RTRIM(CAST(DATEPART(MONTH,@FechaInicio) AS CHAR(2)))+'/'
												  +	RTRIM(CAST(DATEPART(YEAR,@FechaInicio) AS CHAR(4)))+
												  ''' AND '''+RTRIM(CAST(DATEPART(DAY,@FechaFin) AS CHAR(2)))+'/'
												  +	RTRIM(CAST(DATEPART(MONTH,@FechaFin) AS CHAR(2)))+'/'
												  +	RTRIM(CAST(DATEPART(YEAR,@FechaFin) AS CHAR(4)))+''''
		PRINT @EntreFechas
		--PARA LOS SERVICIOS A EXCEPCIÓN DE 'CONSULTA EXTERNA'
		SET ROWCOUNT 1
		SELECT @CodigoCategoria = CodigoCategoria, @NombreCategoria = NombreCategoria
		FROM @TListaCategorias
		WHILE @@ROWCOUNT <> 0
		BEGIN
			--Colocar aqui la concatenaación de consultas
			SET @Consulta = @Consulta + '
				LEFT JOIN
				(
					SELECT PS.CodigoServicio, COUNT(*) AS CantidadPacientes'+ @NombreCategoria +
					'
					FROM PagoServicios PS
					INNER JOIN Pacientes P
					ON PS.NumeroPaciente = P.NumeroPaciente
					WHERE PS.CodigoCategoria = ' + CAST(@CodigoCategoria AS CHAR(3)) 
					+ CASE WHEN @BuscarEn IS NOT NULL THEN '
					AND CAST((CASE WHEN P.HClinico IS NULL THEN ''-1'' ELSE HClinico END) AS VARCHAR(5)) LIKE CASE WHEN '''+ @BuscarEn + '''= ''H''	THEN ''%%'' ELSE ''-1'' END '
					ELSE '' END +					
					@EntreFechas +'
					GROUP BY PS.CodigoServicio
				)' + ' T' +@NombreCategoria +
				' ON S.CodigoServicio = '+ ' T' +@NombreCategoria + '.CodigoServicio'
			SET @CamposMostrar = @CamposMostrar + ' ISNULL(T'+@NombreCategoria+ '.CantidadPacientes' + @NombreCategoria +',0) AS ' + @NombreCategoria +','
			
			DELETE @TListaCategorias WHERE CodigoCategoria = @CodigoCategoria
			SET ROWCOUNT 1
				
			SELECT @CodigoCategoria = CodigoCategoria, @NombreCategoria = NombreCategoria
			FROM @TListaCategorias
		END
		SET ROWCOUNT 0	
		
		--PARA LAS ESPECIALIDADES
		INSERT INTO @TListaCategorias (CodigoCategoria, NombreCategoria, SubvencionInstitucional)
		SELECT CodigoCategoria, NombreCategoria, SubvencionInstitucional FROM Categorias
		
		SET ROWCOUNT 1
		SELECT @CodigoCategoria = CodigoCategoria, @NombreCategoria = NombreCategoria
		FROM @TListaCategorias
		WHILE @@ROWCOUNT <> 0
		BEGIN
			--Colocar aqui la concatenaación de consultas
			SET @Consulta2 = @Consulta2 + '
				LEFT JOIN
				(
					SELECT PS.CodigoEspecialidad, COUNT(*) AS CantidadPacientes'+ @NombreCategoria +
					'
					FROM PagoServicios PS
					INNER JOIN Pacientes P
					ON PS.NumeroPaciente = P.NumeroPaciente
					WHERE PS.CodigoCategoria = ' + CAST(@CodigoCategoria AS CHAR(3)) 
					+ CASE WHEN @BuscarEn IS NOT NULL THEN '
					AND CAST((CASE WHEN P.HClinico IS NULL THEN ''-1'' ELSE HClinico END) AS VARCHAR(5)) LIKE CASE WHEN '''+ @BuscarEn + '''= ''H''	THEN ''%%'' ELSE ''-1'' END '
					ELSE '' END +					
					@EntreFechas +'
					GROUP BY PS.CodigoEspecialidad
				)' + ' T' +@NombreCategoria +
				' ON E.CodigoEspecialidad = '+ ' T' +@NombreCategoria + '.CodigoEspecialidad'
			SET @CamposMostrar2 = @CamposMostrar2 + ' ISNULL(T'+@NombreCategoria+ '.CantidadPacientes' + @NombreCategoria +',0) AS ' + @NombreCategoria +','
			
			DELETE @TListaCategorias WHERE CodigoCategoria = @CodigoCategoria
			SET ROWCOUNT 1
				
			SELECT @CodigoCategoria = CodigoCategoria, @NombreCategoria = NombreCategoria
			FROM @TListaCategorias
		END
		SET ROWCOUNT 0	
		
				

		SET @ConsultaGral = 'SELECT S.NombreServicio, ' + SUBSTRING(@CamposMostrar, 1, LEN(@CamposMostrar)-1)
			+ '
			FROM Servicios S ' + @Consulta + '
			WHERE S.NombreServicio <>''CONSULTA EXTERNA'' '
		
		SET @ConsultaGral2 = 'SELECT E.NombreEspecialidad, ' + SUBSTRING(@CamposMostrar2, 1, LEN(@CamposMostrar2)-1)
			+ '
			FROM Especialidades E ' + @Consulta2
		
		
		PRINT (@ConsultaGral)
		PRINT (@ConsultaGral2)
		
		EXEC (@ConsultaGral + '
		UNION ALL
		' + @ConsultaGral2)
	END
	
END
GO

--EXEC ListarCantidadSubvencionSocialPorServicio NULL, NULL,'I'
