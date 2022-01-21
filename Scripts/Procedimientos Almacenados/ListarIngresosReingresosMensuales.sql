USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarIngresosReingresosMensuales
GO

CREATE PROCEDURE ListarIngresosReingresosMensuales
	@MesInicio	INT,
	@MesFin		INT,
	@AnoGestion	INT
AS
BEGIN
	
	IF(@MesInicio > @MesFin)
		RAISERROR ('Rango de Meses INVALIDO', 16, 2)
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
			ISNULL(IV.IngresoVarones, 0) AS IngresoVarones, ISNULL(RV.REIngresoVarones, 0) AS ReIngresoVarones,
			ISNULL(IM.IngresoMujeres, 0) AS IngresoMujeres, ISNULL(RM.ReIngresoMujeres, 0) AS ReIngresoMujeres,
			ISNULL(AV.AltasVarones, 0) AS AltasVarones, ISNULL(AM.AltasMujeres, 0) AS AltasMujeres
		FROM @TListaMeses LM
		LEFT JOIN
		(
			SELECT MONTH(P.FechaIngreso) AS MesIngreso, COUNT(*) as IngresoVarones
			FROM Pacientes P
			WHERE YEAR(P.FechaIngreso) =  @AnoGestion
			AND p.Sexo = 'M'
			GROUP BY MONTH(P.FechaIngreso)
		) IV
		ON LM.NumeroMes = 	IV.MesIngreso
		LEFT JOIN
		(
			SELECT MONTH(P.FechaIngreso) AS MesIngreso, COUNT(*) as IngresoMujeres
			FROM Pacientes P
			WHERE YEAR(P.FechaIngreso) =  @AnoGestion
			AND p.Sexo = 'F'
			GROUP BY MONTH(P.FechaIngreso)
		) IM
		ON LM.NumeroMes = IM.MesIngreso
		LEFT JOIN
		(	
			SELECT MONTH(R.FechaReingreso) AS MesReIngreso, COUNT(*) as ReIngresoVarones
			FROM Reingresos R
			inner join Pacientes P
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE YEAR(R.FechaReingreso) =  @AnoGestion
			AND P.Sexo = 'M'
			GROUP BY MONTH(R.FechaReingreso)
		) RV
		ON LM.NumeroMes = RV.MesReIngreso
		LEFT JOIN
		(	
			SELECT MONTH(R.FechaReingreso) AS MesReIngreso, COUNT(*) as ReIngresoMujeres
			FROM Reingresos R
			inner join Pacientes P
			ON P.NumeroPaciente = R.NumeroPaciente
			WHERE YEAR(R.FechaReingreso) =  @AnoGestion
			AND P.Sexo = 'F'
			GROUP BY MONTH(R.FechaReingreso)
		) RM
		ON LM.NumeroMes = RM.MesReIngreso		
		LEFT JOIN
		(	
			SELECT MONTH(R.fecha_alta) AS MesReIngreso, COUNT(*) as AltasVarones
			FROM PSIQUIATRICO.dbo.altas R
			inner join Pacientes P
			ON P.HClinico= R.hc
			WHERE YEAR(R.fecha_alta) =  @AnoGestion
			AND P.Sexo = 'M'
			GROUP BY MONTH(R.fecha_alta)
		) AV
		ON LM.NumeroMes = AV.MesReIngreso
		LEFT JOIN
		(	
			SELECT MONTH(R.fecha_alta) AS MesReIngreso, COUNT(*) as AltasMujeres
			FROM PSIQUIATRICO.dbo.altas R
			inner join Pacientes P
			ON P.HClinico= R.hc
			WHERE YEAR(R.fecha_alta) =  @AnoGestion
			AND P.Sexo = 'F'
			GROUP BY MONTH(R.fecha_alta)
		) AM
		ON LM.NumeroMes = AM.MesReIngreso
						
	END
END
GO
--EXEC DBO.ListarIngresosReingresosMensuales 1, 12, 1999