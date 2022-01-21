USE TRABAJO_SOCIAL
GO

DROP FUNCTION EstaPacienteHospitalizado
GO

CREATE FUNCTION EstaPacienteHospitalizado
(
	@NumeroPaciente INTEGER 
)
RETURNS BIT
AS
BEGIN
	DECLARE @EstaHospitalizado		BIT,
			@UltimaFechaReingreso	DATETIME,
			@UltimaFechaAlta		DATETIME
	
	SET @EstaHospitalizado = 0
	
	SELECT @EstaHospitalizado = CASE WHEN P.CodigoEstadoPaciente = 'P' THEN 0 ELSE 1 END  
	FROM TRABAJO_SOCIAL.DBO.Pacientes P
	WHERE NumeroPaciente = @NumeroPaciente
	--SELECT CASE WHEN P.CodigoEstadoPaciente = 'P' THEN 0 ELSE 1 END  
	--FROM TRABAJO_SOCIAL.DBO.Pacientes P
	--IF(EXISTS (SELECT * FROM Pacientes WHERE NumeroPaciente = @NumeroPaciente AND HClinico IS NOT NULL))
	--BEGIN
	--	--SELECT TOP(1) @UltimaFechaAlta = fecha_alta
	--	--FROM PSIQUIATRICO.DBO.altas
	--	--WHERE hc = DBO.ObtenerNumeroHistorialClinicoPaciente(@NumeroPaciente)
	--	--ORDER BY fecha_alta
		
	--	SELECT TOP(1) @UltimaFechaAlta = Fecha_mov
	--	FROM PSIQUIATRICO.dbo.Movimientos
	--	WHERE Hc = DBO.ObtenerNumeroHistorialClinicoPaciente(@NumeroPaciente)
	--	AND estado = 'ACTIVO'
	--	ORDER BY Hc, Fecha_mov DESC, Hora DESC
		
	--	--SELECT TOP(1) @UltimaFechaAlta = FechaSSocial 
	--	--FROM SeguimientosSociales
	--	--WHERE NumeroPaciente = @NumeroPaciente
	--	--ORDER BY FechaSSocial DESC
		
	--	IF(@UltimaFechaAlta IS NOT NULL)
	--	BEGIN
		
	--		IF(NOT EXISTS (SELECT * FROM Reingresos R WHERE R.NumeroPaciente = @NumeroPaciente ))
	--			SELECT @UltimaFechaReingreso = FechaIngreso
	--			FROM Pacientes
	--			WHERE NumeroPaciente = @NumeroPaciente
	--		ELSE
	--			SELECT TOP(1) @UltimaFechaReingreso = FechaReingreso
	--			FROM Reingresos
	--			WHERE NumeroPaciente = @NumeroPaciente
	--			ORDER BY FechaReingreso DESC
			
	--		IF(@UltimaFechaReingreso > @UltimaFechaAlta)
	--			SET @EstaHospitalizado = 1
	--	END
		
	--END
	
	RETURN @EstaHospitalizado
END
GO



--SELECT *
--		FROM PSIQUIATRICO.dbo.Movimientos
--		WHERE estado = 'ACTIVO'
--		ORDER BY Hc, Fecha_mov DESC, Hora DESC
 