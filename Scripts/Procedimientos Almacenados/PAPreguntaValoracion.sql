USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarPreguntaValoracion
GO

CREATE PROCEDURE InsertarPreguntaValoracion
	
       @NombrePreguntaValoracion VARCHAR(150),
       @Descripcion VARCHAR(300)
AS
BEGIN
    BEGIN TRANSACTION
    IF (EXISTS(SELECT * FROM dbo.PreguntasValoracion WHERE  NombrePreguntaValoracion = @NombrePreguntaValoracion))
    BEGIN
        RAISERROR('EL NOMBRE DE LA PREGUNTA DE VALORACIÓN SOCIOECONÓMICA YA SE ENCUENTRA REGISTRADO',16,2)
    END
    ELSE
        INSERT INTO dbo.PreguntasValoracion(NombrePreguntaValoracion, Descripcion)
        VALUES (@NombrePreguntaValoracion,@Descripcion)
    IF (@@ERROR <> 0)
    BEGIN
        ROLLBACK
        RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
    END
    ELSE
        COMMIT TRANSACTION
END
GO



DROP PROCEDURE ActualizarPreguntaValoracion
GO

CREATE PROCEDURE ActualizarPreguntaValoracion
    @CodigoPreguntaValoracion     INT,
    @NombrePreguntaValoracion     VARCHAR(150),
    @Descripcion                  VARCHAR(300)
AS
BEGIN
	BEGIN TRANSACTION
    IF (EXISTS (SELECT * FROM dbo.PreguntasValoracion WHERE NombrePreguntaValoracion = @NombrePreguntaValoracion AND CodigoPreguntaValoracion <> @CodigoPreguntaValoracion))
    BEGIN
       RAISERROR ('EL CODIGO DE LA PREGUNTA NO SE ENCUENTRA REGISTRADO',16,2)
    END
    ELSE
       UPDATE dbo.PreguntasValoracion
          SET NombrePreguntaValoracion = @NombrePreguntaValoracion,
              Descripcion = @Descripcion
          WHERE (CodigoPreguntaValoracion = @CodigoPreguntaValoracion)
    IF (@@ERROR <> 0)
    BEGIN
       ROLLBACK
       RAISERROR ('NO SE PUDO ACTUALIZAR CORRECTAMENTE EL NOMBRE DE LA PREGUNTA DE VALORACIÓN
 SOCIOECONÓMICA',16,2)
    END
    ELSE
		COMMIT TRANSACTION	
END
GO



DROP PROCEDURE EliminarPreguntaValoracion
GO

CREATE PROCEDURE EliminarPreguntaValoracion
    @CodigoPreguntaValoracion INT
AS
BEGIN
	DELETE FROM RespuestasValoracion
	WHERE CodigoPreguntaValoracion = @CodigoPreguntaValoracion
    DELETE FROM dbo.PreguntasValoracion
    WHERE CodigoPreguntaValoracion = @CodigoPreguntaValoracion
END
GO



DROP PROCEDURE ListarPreguntasValoracion
GO

CREATE PROCEDURE ListarPreguntasValoracion
AS
BEGIN
     SELECT CodigoPreguntaValoracion, NombrePreguntaValoracion,Descripcion 
     FROM dbo.PreguntasValoracion
     ORDER BY CodigoPreguntaValoracion
END
GO



DROP PROCEDURE ObtenerPeguntaValoracion
GO

CREATE PROCEDURE ObtenerPeguntaValoracion
	@CodigoPreguntaValoracion	 INT 
AS
BEGIN
	SELECT CodigoPreguntaValoracion,NombrePreguntaValoracion,Descripcion
	FROM dbo.PreguntasValoracion
	WHERE CodigoPreguntaValoracion = @CodigoPreguntaValoracion
END
GO




DROP PROCEDURE ActualizarPreguntaRespuestaValoracionXML
GO
CREATE PROCEDURE ActualizarPreguntaRespuestaValoracionXML
    @CodigoPreguntaValoracion     INT,
    @NombrePreguntaValoracion     VARCHAR(150),
    @Descripcion                  VARCHAR(300),
	@RespuestasXML	TEXT
AS
BEGIN
	BEGIN TRANSACTION 
		
		
		EXEC dbo.ActualizarPreguntaValoracion @CodigoPreguntaValoracion, @NombrePreguntaValoracion, @Descripcion
		
		DECLARE @punteroXMLRespuestas INT
				
					
		EXEC sp_xml_preparedocument @punteroXMLRespuestas OUTPUT, @RespuestasXML
		
		--PARA INSERTAR LOS NUEVOS REGISTROS EN LA EDICIÓN 
		------------------------------------------------------------------------------------
		
		INSERT INTO dbo.RespuestasValoracion(
				CodigoPreguntaValoracion,
				NombreRespuestaValoracion,
				Puntaje,
				Descripcion
				)
		SELECT  @CodigoPreguntaValoracion, 
				NombreRespuestaValoracion,				
				Puntaje, 
				Descripcion
		FROM OPENXML (@punteroXMLRespuestas, '/PreguntasValoracion/RespuestasValoracion',2)		
		WITH(
				CodigoRespuestaValoracion	INT,	
				NombreRespuestaValoracion	VARCHAR(150),
				Puntaje						INT,
				Descripcion					VARCHAR(300)
				)
		WHERE CodigoRespuestaValoracion NOT IN(
			SELECT IAD.CodigoRespuestaValoracion
			FROM RespuestasValoracion IAD
			WHERE IAD.CodigoPreguntaValoracion = @CodigoPreguntaValoracion
			
		)
		
		--SELECT * FROM RespuestasValoracion
		--where CodigoPreguntaValoracion = @CodigoPreguntaValoracion
		
		--ACTUALIZAR LOS REGISTROS
		------------------------------------------------------------------------------------
		UPDATE RespuestasValoracion
			SET RespuestasValoracion.NombreRespuestaValoracion = VSDXML.NombreRespuestaValoracion,
				RespuestasValoracion.Puntaje = VSDXML.Puntaje,
				RespuestasValoracion.Descripcion = VSDXML.Descripcion
		FROM OPENXML (@punteroXMLRespuestas, '/PreguntasValoracion/RespuestasValoracion',2)		
		WITH(	
				CodigoRespuestaValoracion	INT,	
				NombreRespuestaValoracion	VARCHAR(150),
				Puntaje						INT,
				Descripcion					VARCHAR(300)				
			) VSDXML
		WHERE RespuestasValoracion.CodigoPreguntaValoracion = @CodigoPreguntaValoracion		
		AND RespuestasValoracion.CodigoRespuestaValoracion = VSDXML.CodigoRespuestaValoracion
		
		--SELECT * FROM RespuestasValoracion
		--where CodigoPreguntaValoracion = @CodigoPreguntaValoracion
		
		--QUITAR LOS REGISTROS QUE FUERON ELIMINADOS
		--------------------------------------------------------------------------
		DELETE
		FROM RespuestasValoracion
		WHERE CodigoRespuestaValoracion NOT IN
		(
			SELECT  CodigoRespuestaValoracion				
			FROM OPENXML (@punteroXMLRespuestas, '/PreguntasValoracion/RespuestasValoracion',2)
			WITH(
					CodigoRespuestaValoracion	INT
				)
		)
		AND RespuestasValoracion.CodigoPreguntaValoracion = @CodigoPreguntaValoracion
		
		
		--SELECT * FROM RespuestasValoracion
		--where CodigoPreguntaValoracion = @CodigoPreguntaValoracion
		
		EXEC sp_xml_removedocument @punteroXMLRespuestas
		IF(@@ERROR <> 0)
		BEGIN
			RAISERROR('No se Pudo Actualizar eL Conjunto de Respuestas y Preguntas',1,17)	
			ROLLBACK TRAN
		END
		ELSE
			COMMIT TRANSACTION
END
GO

--SELECT * FROM ValoracionSocioEconomica