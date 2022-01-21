USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarAltasMensuales
GO

CREATE PROCEDURE ListarAltasMensuales
	@MesInicio	INT,
	@MesFin		INT,
	@AnoGestion	INT
AS
BEGIN
	
	IF(@MesInicio > @MesFin)
		RAISERROR ('Rango de Meses INVALIDO', 17, 2)
	ELSE
	BEGIN
		DECLARE @TListaMeses TABLE
		(
			NumeroMes	INT
		)
		DECLARE	@ContadorMeses INT
		SET @ContadorMeses = @MesInicio
		WHILE @ContadorMeses <= @MesFin
		BEGIN
			INSERT INTO @TListaMeses(NumeroMes) VALUES (@ContadorMeses)
			SET @ContadorMeses = @ContadorMeses + 1
		END
		
		SELECT LM.NumeroMes, UPPER(DATENAME(MONTH, '01/' + CAST(LM.NumeroMes AS CHAR(2)) + '/ 1900')) AS Mes,
			ISNULL(RV.AltasVarones, 0) AS AltasVarones,
			ISNULL(RM.AltasMujeres, 0) AS AltasMujeres
		FROM @TListaMeses LM		
		LEFT JOIN
		(	
			SELECT MONTH(R.fecha_alta) AS MesReIngreso, COUNT(*) as AltasVarones
			FROM PSIQUIATRICO.dbo.altas R
			inner join Pacientes P
			ON P.HClinico= R.hc
			WHERE YEAR(R.fecha_alta) =  @AnoGestion
			AND P.Sexo = 'M'
			GROUP BY MONTH(R.fecha_alta)
		) RV
		ON LM.NumeroMes = RV.MesReIngreso
		LEFT JOIN
		(	
			SELECT MONTH(R.fecha_alta) AS MesReIngreso, COUNT(*) as AltasMujeres
			FROM PSIQUIATRICO.dbo.altas R
			inner join Pacientes P
			ON P.HClinico= R.hc
			WHERE YEAR(R.fecha_alta) =  @AnoGestion
			AND P.Sexo = 'F'
			GROUP BY MONTH(R.fecha_alta)
		) RM
		ON LM.NumeroMes = RM.MesReIngreso
		
						
	END
END

--EXEC DBO.ListarAltasMensuales 1, 12, 1999