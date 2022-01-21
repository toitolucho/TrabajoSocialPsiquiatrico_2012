USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarReferenciasMensuales
GO

CREATE PROCEDURE ListarReferenciasMensuales
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
			ISNULL(RV.AltasVarones, 0) AS ReferenciaVarones,
			ISNULL(RM.AltasMujeres, 0) AS ReferenciaMujeres
		FROM @TListaMeses LM		
		LEFT JOIN
		(	
			SELECT MONTH(R.FechaReferencia) AS MesReIngreso, COUNT(*) as AltasVarones
			FROM Referencias R
			inner join Pacientes P
			ON P.NumeroPaciente= R.NumeroPaciente
			WHERE YEAR(R.FechaReferencia) =  @AnoGestion
			AND P.Sexo = 'M'
			GROUP BY MONTH(R.FechaReferencia)
		) RV
		ON LM.NumeroMes = RV.MesReIngreso
		LEFT JOIN
		(	
			SELECT MONTH(R.FechaReferencia) AS MesReIngreso, COUNT(*) as AltasMujeres
			FROM Referencias R
			inner join Pacientes P
			ON P.NumeroPaciente= R.NumeroPaciente
			WHERE YEAR(R.FechaReferencia) =  @AnoGestion
			AND P.Sexo = 'F'
			GROUP BY MONTH(R.FechaReferencia)
		) RM
		ON LM.NumeroMes = RM.MesReIngreso
		
						
	END
END

--EXEC DBO.ListarReferenciasMensuales 1, 12, 1999