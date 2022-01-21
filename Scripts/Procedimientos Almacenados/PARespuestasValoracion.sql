USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarRespuestaValoracion
GO

CREATE PROCEDURE InsertarRespuestaValoracion
	@CodigoPreguntaValoracion	INT,
	@NombreRespuestaValoracion	VARCHAR(150),
	@Puntaje					INT,
	@Descripcion				VARCHAR(300)
AS
BEGIN
	INSERT INTO dbo.RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
	VALUES (@CodigoPreguntaValoracion, @NombreRespuestaValoracion, @Puntaje, @Descripcion)
END
GO

DROP PROCEDURE ActualizarRespuestaValoracion
GO

CREATE PROCEDURE ActualizarRespuestaValoracion
	@CodigoRespuestaValoracion	INT,
	@CodigoPreguntaValoracion	INT,
	@NombreRespuestaValoracion	VARCHAR(150),
	@Puntaje					INT,
	@Descripcion				VARCHAR(300)
AS 
BEGIN
	
	UPDATE 	dbo.RespuestasValoracion	
		SET	
			NombreRespuestaValoracion = @NombreRespuestaValoracion,
			Puntaje					  = @Puntaje,
			Descripcion				  = @Descripcion			
	WHERE CodigoRespuestaValoracion = @CodigoRespuestaValoracion
	AND CodigoPreguntaValoracion = @CodigoPreguntaValoracion
END
GO


DROP PROCEDURE EliminarRespuestaValoracion
GO

CREATE PROCEDURE EliminarRespuestaValoracion
	@CodigoRespuestaValoracion	INT,
	@CodigoPreguntaValoracion	INT
AS
BEGIN
	
	DELETE FROM dbo.RespuestasValoracion
	WHERE CodigoRespuestaValoracion = @CodigoRespuestaValoracion
	AND CodigoPreguntaValoracion = @CodigoPreguntaValoracion
END
GO

DROP PROCEDURE ListarRespuestaValoraciones
GO

CREATE PROCEDURE ListarRespuestaValoraciones
AS
BEGIN
	SELECT CodigoRespuestaValoracion, CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion
	FROM dbo.RespuestasValoracion
	ORDER BY CodigoRespuestaValoracion ASC, Puntaje DESC
END
GO


DROP PROCEDURE ObtenerRespuestaValoracion
GO

CREATE PROCEDURE ObtenerRespuestaValoracion
	@CodigoRespuestaValoracion	INT,
	@CodigoPreguntaValoracion	INT
AS
BEGIN
	SELECT CodigoRespuestaValoracion, CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion
	FROM  dbo.RespuestasValoracion
	WHERE CodigoRespuestaValoracion = @CodigoRespuestaValoracion
	AND CodigoPreguntaValoracion = @CodigoPreguntaValoracion
END
GO


SELECT * FROM PreguntasValoracion
DELETE  RespuestasValoracion WHERE CodigoPreguntaValoracion > 10
DELETE  PreguntasValoracion WHERE CodigoPreguntaValoracion > 10

SELECT * FROM ValoracionSocioEconomica WHERE CodigoPreguntaValoracion > 10
DELETE ValoracionSocioEconomica WHERE CodigoPreguntaValoracion > 10