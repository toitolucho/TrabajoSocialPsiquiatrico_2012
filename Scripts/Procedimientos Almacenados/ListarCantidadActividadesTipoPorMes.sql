USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarCantidadActividadesTipoPorMes
GO

CREATE PROCEDURE ListarCantidadActividadesTipoPorMes
	@MesInicio	INT,
	@MesFin		INT,
	@AnoGestion	INT
AS
BEGIN
	
	IF(@MesInicio > @MesFin)
		RAISERROR ('Rango de Meses INVALIDO', 17, 2)
	IF(@MesInicio NOT BETWEEN 1 AND 12)
		RAISERROR ('El Mes de Inicio no se encuentra en el Rango de Meses', 17, 2)
	IF(@MesFin NOT BETWEEN 1 AND 12)
		RAISERROR ('El Mes Fin no se encuentra en el Rango de Meses', 17, 2)
	ELSE
	BEGIN
	
		--DECLARE @TListaMeses TABLE
		--(
		--	NumeroMes			INT			
		--)
		
		DECLARE	@ContadorMeses INT				
		--SET @ContadorMeses = @MesInicio
		--WHILE @ContadorMeses <= @MesFin
		--BEGIN
		--	INSERT INTO @TListaMeses(NumeroMes) VALUES (@ContadorMeses)
		--	SET @ContadorMeses = @ContadorMeses + 1
		--END
		
		
		DECLARE @Consulta		VARCHAR(4000),
				@ConsultaGral	VARCHAR(4000),
				@MesCadena		CHAR(2),
				@anioCadena		CHAR(4),				
				@Abreviacion	CHAR(3),
				@CamposMostrar	VARCHAR(4000),
				@NombreMes		VARCHAR(15)
				
		--SET @Consulta = 'SELECT * FROM ActividadesTipo AT '
		SET @Consulta = ''
		SET @CamposMostrar = ''
	 	SET @anioCadena = CAST(@AnoGestion as CHAR(4))
		SET @ContadorMeses = @MesInicio
		WHILE @ContadorMeses <= @MesFin
		BEGIN
			SET @Abreviacion = 'A' + CAST(@ContadorMeses AS CHAR(2))
			SET @MesCadena = CAST(@ContadorMeses AS CHAR(2))
			SET @NombreMes = UPPER(DATENAME(MONTH, '01/' + @MesCadena + '/ 1900')) 
			SET @Consulta = @Consulta + '
				LEFT JOIN 
				(
					SELECT A.CodigoActividadTipo, COUNT(*) AS CantidadMes' + @NombreMes +'
					FROM Actividades A
					WHERE YEAR(FechaActividad) = ' + @anioCadena +
					' AND MONTH(FechaActividad) = ' + @MesCadena +'
					GROUP BY A.CodigoActividadTipo
				) ' + @Abreviacion +
				' ON AT.CodigoActividadTipo = ' +@Abreviacion +'.CodigoActividadTipo'
			SET @CamposMostrar = @CamposMostrar + ' ISNULL('+@Abreviacion+ '.CantidadMes' + @NombreMes +',0) AS ' + @NombreMes +','
			SET @ContadorMeses = @ContadorMeses + 1
		END
		
		SET @ConsultaGral = 'SELECT AT.NombreActividad, ' + @CamposMostrar --+ SUBSTRING(@CamposMostrar, 1, LEN(@CamposMostrar)-2)
			+ 'ActividadesTipo AT ' + @Consulta
		
		--PRINT 'HOLA '	
		--PRINT (@CamposMostrar)
		--PRINT (@ConsultaGral)
		PRINT('SELECT AT.NombreActividad, ' + SUBSTRING(@CamposMostrar, 1, LEN(@CamposMostrar)-1)
			+ ' 
			FROM ActividadesTipo AT 
			' + @Consulta)
		SET @CamposMostrar = SUBSTRING(@CamposMostrar, 1, LEN(@CamposMostrar)-1)
		EXEC('SELECT AT.NombreActividad, ' + @CamposMostrar
			+ ' 
			FROM ActividadesTipo AT 
			' + @Consulta + ' ORDER BY 1')
	END
	
END
GO

--EXEC ListarCantidadActividadesTipoPorMes 1, 12, 2011
