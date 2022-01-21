USE TRABAJO_SOCIAL
GO

DROP FUNCTION ObtenerSiguienteIdPacienteRelaciones
GO

CREATE FUNCTION ObtenerSiguienteIdPacienteRelaciones
(
	@NumeroPaciente		INT,
	@TipoRelacionTabla	CHAR(1)-- 'A'->Actividades, 'D'->Documentos, 'F'->Familiares, 
	-- 'R'->Responsables, 'I'->Informe Sociales, 'E'-> Referemcias, 'C'->ContraReferencias, -> 'G' ->Reingresos, 
	--'N'-> Seguimiento Anual, 'S'->Seguimiento Social, 'P' 'Pagos Servicios'
)
RETURNS INT
AS
BEGIN
	DECLARE @Cantidad	INT
			
	IF(@TipoRelacionTabla = 'A')--ACTIVIDADES
	BEGIN
		IF(EXISTS (SELECT * FROM Pacientes WHERE NumeroPaciente = @NumeroPaciente))
			SELECT @Cantidad = COUNT(*)
			FROM Actividades
			WHERE NumeroPaciente = @NumeroPaciente
		ELSE
			SELECT @Cantidad = COUNT(*)
			FROM Actividades
			WHERE NumeroPaciente IS NULL
	END	
	
	IF(@TipoRelacionTabla = 'D')--DOCUMENTOS
	BEGIN
		SELECT @Cantidad = COUNT(*)
		FROM Documentos
		WHERE NumeroPaciente = @NumeroPaciente
		IF(EXISTS(SELECT * FROM Documentos 
			WHERE NumeroDocumento = @Cantidad AND NumeroPaciente = @NumeroPaciente ))
		BEGIN
			SET @Cantidad = @Cantidad + 1
		END
	END	
	
	IF(@TipoRelacionTabla = 'F')--FAMILIARES
	BEGIN
		SELECT @Cantidad = COUNT(*)
		FROM Familiares
		WHERE NumeroPaciente = @NumeroPaciente
	END	
	
	IF(@TipoRelacionTabla = 'R')--RESPONSABLES
	BEGIN
		SELECT @Cantidad = COUNT(*)
		FROM Responsables
		WHERE NumeroPaciente = @NumeroPaciente
	END	
	
	IF(@TipoRelacionTabla = 'I')--INFORME SOCIAL
	BEGIN
		SELECT @Cantidad = COUNT(*)
		FROM InformesSociales
		WHERE NumeroPaciente = @NumeroPaciente
	END	
	
	IF(@TipoRelacionTabla = 'E')--REFERENCIAS
	BEGIN
		SELECT @Cantidad = COUNT(*)
		FROM Referencias
		WHERE NumeroPaciente = @NumeroPaciente
	END	
	
	IF(@TipoRelacionTabla = 'C')--Contrarreferencias
	BEGIN
		SELECT @Cantidad = COUNT(*)
		FROM Contrarreferencias
		WHERE NumeroPaciente = @NumeroPaciente
	END	
	
	IF(@TipoRelacionTabla = 'G')--Reingresos
	BEGIN
		SELECT @Cantidad = COUNT(*)
		FROM Reingresos
		WHERE NumeroPaciente = @NumeroPaciente
	END	
	
	IF(@TipoRelacionTabla = 'N')--SeguimientoAnual
	BEGIN
		SELECT @Cantidad = COUNT(*)
		FROM SeguimientoAnual
		WHERE NumeroPaciente = @NumeroPaciente
	END	
	
	IF(@TipoRelacionTabla = 'S')--SeguimientosSociales
	BEGIN
		SELECT @Cantidad = COUNT(*)
		FROM SeguimientosSociales
		WHERE NumeroPaciente = @NumeroPaciente
	END		
	
	IF(@TipoRelacionTabla = 'P')--PagoServicios
	BEGIN
		SELECT @Cantidad = COUNT(*)
		FROM PagoServicios
		WHERE NumeroPaciente = @NumeroPaciente
	END		
	
	
	SET @Cantidad = @Cantidad + 1	
	RETURN @Cantidad
END
GO

--SELECT *, DBO.ObtenerSiguienteIdPacienteRelaciones(726,'C') FROM Contrarreferencias
