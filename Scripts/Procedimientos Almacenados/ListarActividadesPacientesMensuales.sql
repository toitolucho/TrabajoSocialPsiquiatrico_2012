USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarActividadesPacientesMensuales
GO

CREATE PROCEDURE ListarActividadesPacientesMensuales
	@MesInicio	INT,
	@MesFin		INT,
	@AnoGestion	INT,
	@CodigoActividadTipo	INT
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
			ISNULL(RV.CantidadVarones, 0) AS CantidadVarones,
			ISNULL(RM.CantidadMujeres, 0) AS CantidadMujeres
		FROM @TListaMeses LM		
		LEFT JOIN
		(	
			SELECT MONTH(A.FechaActividad) AS MesReIngreso, COUNT(*) as CantidadVarones
			FROM dbo.Actividades A
			inner join Pacientes P
			ON P.NumeroPaciente= A.NumeroPaciente
			WHERE YEAR(A.FechaActividad) =  @AnoGestion
			AND P.Sexo = 'M'
			AND A.CodigoActividadTipo = @CodigoActividadTipo
			GROUP BY MONTH(A.FechaActividad)
		) RV
		ON LM.NumeroMes = RV.MesReIngreso
		LEFT JOIN
		(	
			SELECT MONTH(A.FechaActividad) AS MesReIngreso, COUNT(*) as CantidadMujeres
			FROM dbo.Actividades A
			inner join Pacientes P
			ON P.NumeroPaciente= A.NumeroPaciente
			WHERE YEAR(A.FechaActividad) =  @AnoGestion
			AND P.Sexo = 'F'
			AND A.CodigoActividadTipo = @CodigoActividadTipo
			GROUP BY MONTH(A.FechaActividad)
		) RM
		ON LM.NumeroMes = RM.MesReIngreso
		
						
	END
END
