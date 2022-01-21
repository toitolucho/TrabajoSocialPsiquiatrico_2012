USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarValoracionSocioEconomica
GO

CREATE PROCEDURE InsertarValoracionSocioEconomica
	@NumeroPaciente					INT,
	@FechaHoraValoracionSocioEcon	DATETIME,
	@CodigoRespuestaValoracion		INT,
	@CodigoPreguntaValoracion		INT,		
	@PuntajeActual					INT
AS
BEGIN
	INSERT INTO dbo.ValoracionSocioeconomica (CodigoRespuestaValoracion, CodigoPreguntaValoracion, PuntajeActual, NumeroPaciente, FechaHoraValoracionSocioEcon)
	VALUES (@CodigoRespuestaValoracion, @CodigoPreguntaValoracion, @PuntajeActual, @NumeroPaciente, @FechaHoraValoracionSocioEcon)
END
GO

DROP PROCEDURE ActualizarValoracionSocioEconomica
GO

CREATE PROCEDURE ActualizarValoracionSocioEconomica
	@NumeroPaciente					INT,
	@FechaHoraValoracionSocioEcon	DATETIME,
	@CodigoRespuestaValoracion		INT,
	@CodigoPreguntaValoracion		INT,		
	@PuntajeActual					INT
AS 
BEGIN
	
	UPDATE 	dbo.ValoracionSocioeconomica	
		SET	
			PuntajeActual		= @PuntajeActual
	WHERE CodigoRespuestaValoracion = @CodigoRespuestaValoracion
	AND CodigoPreguntaValoracion = @CodigoPreguntaValoracion
	AND NumeroPaciente = @NumeroPaciente
	AND FechaHoraValoracionSocioEcon = @FechaHoraValoracionSocioEcon
END
GO


DROP PROCEDURE EliminarValoracionSocioEconomica
GO

CREATE PROCEDURE EliminarValoracionSocioEconomica
	@NumeroPaciente					INT,
	@FechaHoraValoracionSocioEcon	DATETIME,
	@CodigoRespuestaValoracion		INT,
	@CodigoPreguntaValoracion		INT		
AS
BEGIN
	
	DELETE FROM dbo.ValoracionSocioeconomica
	WHERE CodigoRespuestaValoracion = @CodigoRespuestaValoracion
	AND CodigoPreguntaValoracion = @CodigoPreguntaValoracion
	AND NumeroPaciente = @NumeroPaciente
	AND FechaHoraValoracionSocioEcon = @FechaHoraValoracionSocioEcon
END
GO

DROP PROCEDURE ListarValoracionSocioEconomicas
GO

CREATE PROCEDURE ListarValoracionSocioEconomicas
AS
BEGIN
	SELECT NumeroPaciente, FechaHoraValoracionSocioEcon, CodigoRespuestaValoracion, CodigoPreguntaValoracion, PuntajeActual
	FROM dbo.ValoracionSocioeconomica
END
GO


DROP PROCEDURE ObtenerValoracionSocioEconomica
GO

CREATE PROCEDURE ObtenerValoracionSocioEconomica
	@NumeroPaciente					INT,
	@FechaHoraValoracionSocioEcon	DATETIME,
	@CodigoRespuestaValoracion		INT,
	@CodigoPreguntaValoracion		INT		
AS
BEGIN
	SELECT NumeroPaciente, FechaHoraValoracionSocioEcon, CodigoRespuestaValoracion, CodigoPreguntaValoracion, PuntajeActual
	FROM  dbo.ValoracionSocioeconomica
	WHERE CodigoRespuestaValoracion = @CodigoRespuestaValoracion
	AND CodigoPreguntaValoracion = @CodigoPreguntaValoracion
	AND NumeroPaciente = @NumeroPaciente
	AND FechaHoraValoracionSocioEcon = @FechaHoraValoracionSocioEcon
END
GO

DROP PROCEDURE InsertarActualizarValoracionSocioEconomicaXML
GO

CREATE PROCEDURE InsertarActualizarValoracionSocioEconomicaXML
	@NumeroPaciente					INT,
	@FechaHoraValoracionSocioEcon	DATETIME,
	@ValoracionDetalleXML			TEXT
AS
BEGIN
	BEGIN TRANSACTION 
		
		SET @FechaHoraValoracionSocioEcon = ISNULL(@FechaHoraValoracionSocioEcon, GETDATE())
		
		DECLARE @punteroXMLRespuestasDetalle INT
				
					
		EXEC sp_xml_preparedocument @punteroXMLRespuestasDetalle OUTPUT, @ValoracionDetalleXML
		
		--ACTUALIZAR LOS REGISTROS
		------------------------------------------------------------------------------------
		UPDATE ValoracionSocioEconomica
			SET ValoracionSocioEconomica.PuntajeActual = VSDXML.Puntaje				
		FROM OPENXML (@punteroXMLRespuestasDetalle, '/ValoracionSocioEconomica/RespuestasValoracion',2)		
		WITH(	
				CodigoRespuestaValoracion INT,
				CodigoPreguntaValoracion  INT,
				Puntaje					  INT
			) VSDXML
		WHERE ValoracionSocioEconomica.NumeroPaciente = @NumeroPaciente
		AND ValoracionSocioEconomica.CodigoRespuestaValoracion = VSDXML.CodigoRespuestaValoracion
		AND ValoracionSocioEconomica.CodigoPreguntaValoracion = VSDXML.CodigoPreguntaValoracion
		AND ValoracionSocioEconomica.FechaHoraValoracionSocioEcon = @FechaHoraValoracionSocioEcon
		
		--QUITAR LOS REGISTROS QUE FUERON ELIMINADOS
		--------------------------------------------------------------------------
		DELETE
		FROM ValoracionSocioEconomica
		WHERE CodigoRespuestaValoracion NOT IN
		(
			SELECT  CodigoRespuestaValoracion				
			FROM OPENXML (@punteroXMLRespuestasDetalle, '/ValoracionSocioEconomica/RespuestasValoracion',2)		
			WITH(
				CodigoRespuestaValoracion INT
			)
		) 
		--AND CodigoPreguntaValoracion NOT IN
		--(
		--	SELECT  CodigoPreguntaValoracion				
		--	FROM OPENXML (@punteroXMLRespuestasDetalle, '/ValoracionSocioEconomica/RespuestasValoracion',2)		
		--	WITH(
		--		CodigoPreguntaValoracion INT
		--	)
		--)
		AND ValoracionSocioEconomica.NumeroPaciente = @NumeroPaciente
		AND ValoracionSocioEconomica.FechaHoraValoracionSocioEcon = @FechaHoraValoracionSocioEcon
		
		--PARA INSERTAR LOS NUEVOS REGISTROS EN LA EDICIÓN 
		------------------------------------------------------------------------------------
		
		INSERT INTO dbo.ValoracionSocioEconomica(
				NumeroPaciente,
				FechaHoraValoracionSocioEcon,
				CodigoRespuestaValoracion,
				CodigoPreguntaValoracion,
				PuntajeActual				
				)
		SELECT  @NumeroPaciente,
				@FechaHoraValoracionSocioEcon,
				CodigoRespuestaValoracion,
				CodigoPreguntaValoracion,
				Puntaje				
		FROM OPENXML (@punteroXMLRespuestasDetalle, '/ValoracionSocioEconomica/RespuestasValoracion',2)		
		WITH(	
				CodigoRespuestaValoracion INT,
				CodigoPreguntaValoracion  INT,
				Puntaje					  INT
				)
		WHERE CodigoRespuestaValoracion NOT IN(
			SELECT CodigoRespuestaValoracion
			FROM ValoracionSocioEconomica IAD
			WHERE IAD.NumeroPaciente = @NumeroPaciente
			AND IAD.FechaHoraValoracionSocioEcon = @FechaHoraValoracionSocioEcon			
		)
		AND CodigoPreguntaValoracion NOT IN(
			SELECT CodigoPreguntaValoracion
			FROM ValoracionSocioEconomica IAD
			WHERE IAD.NumeroPaciente = @NumeroPaciente
			AND IAD.FechaHoraValoracionSocioEcon = @FechaHoraValoracionSocioEcon
		)
		
		
		EXEC sp_xml_removedocument @punteroXMLRespuestasDetalle
		IF(@@ERROR <> 0)
		BEGIN
			RAISERROR('No se Pudo Actualizar el Ingreso de La Valoración Socio-Económica',1,16)	
			ROLLBACK TRAN
		END
		ELSE
			COMMIT TRANSACTION
END
GO

DROP PROCEDURE ListarValoracionSocioEconomicasNombresRespuestas
GO

CREATE PROCEDURE ListarValoracionSocioEconomicasNombresRespuestas
	@NumeroPaciente					INT,
	@FechaHoraValoracionSocioEcon	DATETIME
AS
BEGIN
	
	IF(@FechaHoraValoracionSocioEcon IS NULL)
	BEGIN
		SELECT DISTINCT @FechaHoraValoracionSocioEcon = FechaHoraValoracionSocioEcon
		FROM ValoracionSocioEconomica
		WHERE NumeroPaciente = @NumeroPaciente
		ORDER BY FechaHoraValoracionSocioEcon ASC
	END

	SELECT TOP(1) 0 as CodigoRespuestaValoracion,0 as CodigoPreguntaValoracion, 0 as PuntajeActual,
		NumeroPaciente, ISNULL(d.NombreDepartamento, 'No Registrada') as NombreRespuestaValoracion, 'PROCEDENCIA' as NombrePreguntaValoracion,
		p.FechaIngreso as FechaHoraValoracionSocioEcon
	FROM Pacientes P
	LEFT JOIN Departamentos D	
	ON P.CodigoDepartamentoResidencia = D.CodigoDepartamento
	and P.CodigoPaisResidencia = D.CodigoPais
	WHERE P.NumeroPaciente = @NumeroPaciente
	
	UNION ALL
	SELECT	VS.CodigoRespuestaValoracion, VS.CodigoPreguntaValoracion, PuntajeActual,
			NumeroPaciente,
			RV.NombreRespuestaValoracion , PV.NombrePreguntaValoracion, FechaHoraValoracionSocioEcon
	FROM ValoracionSocioEconomica VS
	INNER JOIN RespuestasValoracion RV
	ON VS.CodigoRespuestaValoracion = RV.CodigoRespuestaValoracion
	AND VS.CodigoPreguntaValoracion = RV.CodigoPreguntaValoracion
	INNER JOIN PreguntasValoracion PV
	ON VS.CodigoPreguntaValoracion = PV.CodigoPreguntaValoracion
	--ORDER BY NumeroPaciente
	WHERE VS.NumeroPaciente = @NumeroPaciente
	AND VS.FechaHoraValoracionSocioEcon = @FechaHoraValoracionSocioEcon
	
END
GO

--DELETE FROM ValoracionSocioEconomica
--SELECT * FROM ValoracionSocioEconomica
--exec ListarValoracionSocioEconomicasNombresRespuestas 1, null
--EXEC DBO.ListarValoracionSocioEconomicasNombresRespuestas  667
--exec ListarValoracionSocioEconomicasNombresRespuestas 1, null