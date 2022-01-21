USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarPagoServicio
GO

CREATE PROCEDURE InsertarPagoServicio
	@NumeroPaciente				INT,
	@NumeroPagoServicioManual	INT,
	@CodigoPagoServicio			CHAR(10),
	@CodigoCategoria			INT,
	@TipoServicio				CHAR(1),
	@CodigoClaseServicio		CHAR(1),
	@FechaSubvencion			DATETIME,
	@NumeroPapeleta				INT,
	@NombreSubvencionA			VARCHAR(100),
	@Costo						FLOAT,
	@Subvencion					FLOAT,
	@MontoPagado				FLOAT,
	@TotalCancelar				FLOAT,
	@CategoriaZ					BIT,
	@TotalPuntaje				INT,
	@PacienteInstitucionalizado	BIT,
	@IngresoPacienteMensual		FLOAT,
	@IngresoPacienteEventual	FLOAT,
	@NumeroReingreso			INT,
	@Observaciones				VARCHAR(300)
AS
BEGIN

	DECLARE @PorcentajeSubvencion	FLOAT
	SET @PorcentajeSubvencion = (SELECT TOP(1) SubvencionInstitucional FROM Categorias WHERE CodigoCategoria = @CodigoCategoria)

	IF(@TotalPuntaje IS NULL)
		SET @TotalPuntaje = (select top(1) PuntajeActual from ValoracionSocioEconomica where NumeroPaciente = @NumeroPaciente)
	
	SET @NumeroPagoServicioManual = DBO.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'P')
	
	INSERT INTO dbo.PagoServicios (NumeroPaciente, NumeroPagoServicioManual, CodigoPagoServicio, CodigoCategoria, PorcentajeSubvencion, TipoServicio, CodigoClaseServicio, FechaSubvencion, 
		NumeroPapeleta, NombreSubvencionA, Costo, Subvencion, MontoPagado, TotalCancelar, CategoriaZ, TotalPuntaje, 
		PacienteInstitucionalizado, IngresoPacienteMensual, IngresoPacienteEventual, NumeroReingreso, Observaciones)
	VALUES (@NumeroPaciente, @NumeroPagoServicioManual, @CodigoPagoServicio, @CodigoCategoria, @PorcentajeSubvencion, @TipoServicio, @CodigoClaseServicio, @FechaSubvencion, 
		@NumeroPapeleta, @NombreSubvencionA, @Costo, @Subvencion, @MontoPagado, @TotalCancelar, @CategoriaZ, @TotalPuntaje, 
		@PacienteInstitucionalizado, @IngresoPacienteMensual, @IngresoPacienteEventual, @NumeroReingreso, @Observaciones)
END
GO

DROP PROCEDURE ActualizarPagoServicio
GO

CREATE PROCEDURE ActualizarPagoServicio
	@NumeroPaciente				INT,
	@NumeroPagoServicio			INT,
	@NumeroPagoServicioManual	INT,
	@CodigoPagoServicio			CHAR(10),
	@CodigoCategoria			INT,
	@TipoServicio				CHAR(1),
	@CodigoClaseServicio		CHAR(1),
	@FechaSubvencion			DATETIME,
	@NumeroPapeleta				INT,
	@NombreSubvencionA			VARCHAR(100),
	@Costo						FLOAT,
	@Subvencion					FLOAT,
	@MontoPagado				FLOAT,
	@TotalCancelar				FLOAT,
	@CategoriaZ					BIT,
	@TotalPuntaje				INT,
	@PacienteInstitucionalizado	BIT,
	@IngresoPacienteMensual		FLOAT,
	@IngresoPacienteEventual	FLOAT,
	@NumeroReingreso			INT,
	@Observaciones				VARCHAR(300)
AS 
BEGIN
	
	UPDATE 	dbo.PagoServicios	
		SET	
			NumeroPagoServicioManual	= @NumeroPagoServicioManual,
			--CodigoPagoServicio			= @CodigoPagoServicio,
			CodigoCategoria				= @CodigoCategoria,
			TipoServicio				= @TipoServicio,			
			--CodigoClaseServicio			= @CodigoClaseServicio,
			--FechaSubvencion				= @FechaSubvencion,		
			NumeroPapeleta				= @NumeroPapeleta,				
			NombreSubvencionA			= @NombreSubvencionA,
			Costo						= @Costo,			
			Subvencion					= @Subvencion,
			MontoPagado					= @MontoPagado,				
			TotalCancelar				= @TotalCancelar,				
			CategoriaZ					= @CategoriaZ,				
			TotalPuntaje				= @TotalPuntaje,				
			PacienteInstitucionalizado	= @PacienteInstitucionalizado,
			IngresoPacienteMensual		= @IngresoPacienteMensual,	
			IngresoPacienteEventual		= @IngresoPacienteEventual,	
			--NumeroReingreso				= @NumeroReingreso,	
			Observaciones				= @Observaciones						
	WHERE NumeroPagoServicio = @NumeroPagoServicio
	AND NumeroPaciente = @NumeroPaciente
END
GO


DROP PROCEDURE EliminarPagoServicio
GO

CREATE PROCEDURE EliminarPagoServicio
	@NumeroPaciente			INT,
	@NumeroPagoServicio		INT
AS
BEGIN
	
	DELETE FROM dbo.PagoServiciosDetalle
	WHERE NumeroPagoServicio = @NumeroPagoServicio
	AND NumeroPaciente = @NumeroPaciente
	
	DELETE FROM dbo.PagoServicios
	WHERE NumeroPagoServicio = @NumeroPagoServicio
	AND NumeroPaciente = @NumeroPaciente
END
GO

DROP PROCEDURE ListarPagoServicios
GO

CREATE PROCEDURE ListarPagoServicios
AS
BEGIN
	SELECT	NumeroPaciente, NumeroPagoServicio, NumeroPagoServicioManual, CodigoPagoServicio, CodigoCategoria, TipoServicio, CodigoClaseServicio, FechaSubvencion, 
			NumeroPapeleta, NombreSubvencionA, Costo, Subvencion, MontoPagado, TotalCancelar, CategoriaZ, TotalPuntaje, 
			PacienteInstitucionalizado, IngresoPacienteMensual, IngresoPacienteEventual, NumeroReingreso, Observaciones, PorcentajeSubvencion
	FROM dbo.PagoServicios
	ORDER BY FechaSubvencion
END
GO


DROP PROCEDURE ObtenerPagoServicio
GO

CREATE PROCEDURE ObtenerPagoServicio
	@NumeroPaciente			INT,
	@NumeroPagoServicio		INT
AS
BEGIN
	SELECT	NumeroPaciente, NumeroPagoServicio, NumeroPagoServicioManual, CodigoPagoServicio, CodigoCategoria, TipoServicio, CodigoClaseServicio, FechaSubvencion, 
			NumeroPapeleta, NombreSubvencionA, Costo, Subvencion, MontoPagado, TotalCancelar, CategoriaZ, TotalPuntaje, 
			PacienteInstitucionalizado, IngresoPacienteMensual, IngresoPacienteEventual, NumeroReingreso, Observaciones, PorcentajeSubvencion
	FROM dbo.PagoServicios
	WHERE NumeroPagoServicio = @NumeroPagoServicio
	AND NumeroPaciente = @NumeroPaciente
END
GO





DROP PROCEDURE InsertarPagoServicioXMLDetalle
GO
CREATE PROCEDURE InsertarPagoServicioXMLDetalle
	@NumeroPaciente				INT,
	@NumeroPagoServicioManual	INT,	
	@CodigoPagoServicio			CHAR(10),
	@CodigoCategoria			INT,
	@TipoServicio				CHAR(1),
	@CodigoClaseServicio		CHAR(1),
	@FechaSubvencion			DATETIME,
	@NumeroPapeleta				INT,
	@NombreSubvencionA			VARCHAR(100),
	@Costo						FLOAT,
	@Subvencion					FLOAT,
	@MontoPagado				FLOAT,
	@TotalCancelar				FLOAT,
	@CategoriaZ					BIT,
	@TotalPuntaje				INT,
	@PacienteInstitucionalizado	BIT,
	@IngresoPacienteMensual		FLOAT,
	@IngresoPacienteEventual	FLOAT,
	@NumeroReingreso			INT,
	@Observaciones				VARCHAR(300),
	@ServiciosDetalle			TEXT
AS
BEGIN
	BEGIN TRANSACTION 
		SET @NumeroPagoServicioManual = DBO.ObtenerSiguienteIdPacienteRelaciones(@NumeroPaciente, 'P')
	
		DECLARE @PorcentajeSubvencion	FLOAT
		SET @PorcentajeSubvencion = (SELECT TOP(1) SubvencionInstitucional FROM Categorias WHERE CodigoCategoria = @CodigoCategoria)

		IF(@TotalPuntaje IS NULL)
		
		DECLARE @punteroXMLServiciosDetalle INT,
				@NumeroPagoServicio		INT
				
		SET @TotalPuntaje = (select top(1) PuntajeActual from ValoracionSocioEconomica where NumeroPaciente = @NumeroPaciente)
		
		INSERT INTO dbo.PagoServicios (NumeroPaciente, NumeroPagoServicioManual,  CodigoPagoServicio, CodigoCategoria, PorcentajeSubvencion, TipoServicio, CodigoClaseServicio, FechaSubvencion, 
			NumeroPapeleta, NombreSubvencionA, Costo, Subvencion, MontoPagado, TotalCancelar, CategoriaZ, TotalPuntaje, 
			PacienteInstitucionalizado, IngresoPacienteMensual, IngresoPacienteEventual, NumeroReingreso, Observaciones)
		VALUES (@NumeroPaciente, @NumeroPagoServicioManual, @CodigoPagoServicio, @CodigoCategoria, @PorcentajeSubvencion, @TipoServicio, @CodigoClaseServicio, @FechaSubvencion, 
			@NumeroPapeleta, @NombreSubvencionA, @Costo, @Subvencion, @MontoPagado, @TotalCancelar, @CategoriaZ, @TotalPuntaje, 
			@PacienteInstitucionalizado, @IngresoPacienteMensual, @IngresoPacienteEventual, @NumeroReingreso, @Observaciones)
		
		SET @NumeroPagoServicio = SCOPE_IDENTITY()
		
		IF(@CodigoClaseServicio = 'R')
		BEGIN
			UPDATE Reingresos
				SET IngresoEventual = @IngresoPacienteEventual,
					IngresoMensual = @IngresoPacienteMensual
			WHERE NumeroPaciente = @NumeroPaciente
		END
		
					
		EXEC sp_xml_preparedocument @punteroXMLServiciosDetalle OUTPUT, @ServiciosDetalle
		
		INSERT INTO dbo.PagoServiciosDetalle(
				NumeroPaciente, NumeroPagoServicio, CodigoServicio, Cantidad, CostoServicio, MontoCancelado, CodigoCategoria)
		SELECT  @NumeroPaciente, @NumeroPagoServicio, CodigoServicio, Cantidad, CostoServicio, MontoCancelado, CodigoCategoria
		FROM OPENXML (@punteroXMLServiciosDetalle, '/PagoServicios/PagoServiciosDetalle',2)
		WITH(	
				CodigoServicio	INT,
				CostoServicio	FLOAT,
				Cantidad		INT,
				MontoCancelado	FLOAT,
				CodigoCategoria INT
				
				)
		EXEC sp_xml_removedocument @punteroXMLServiciosDetalle
		IF(@@ERROR <> 0)
		BEGIN
			RAISERROR('No se Pudo ingresar la Venta de Servicios',1,16)	
			ROLLBACK TRAN
		END
	COMMIT TRANSACTION
END
GO



DROP PROCEDURE ActualizarPagoServicioXMLDetalle
GO
CREATE PROCEDURE ActualizarPagoServicioXMLDetalle
	@NumeroPaciente				INT,
	@NumeroPagoServicio			INT,
	@NumeroPagoServicioManual	INT,
	@CodigoPagoServicio			CHAR(10),
	@CodigoCategoria			INT,
	@TipoServicio				CHAR(1),
	@CodigoClaseServicio		CHAR(1),
	@FechaSubvencion			DATETIME,
	@NumeroPapeleta				INT,
	@NombreSubvencionA			VARCHAR(100),
	@Costo						FLOAT,
	@Subvencion					FLOAT,
	@MontoPagado				FLOAT,
	@TotalCancelar				FLOAT,
	@CategoriaZ					BIT,
	@TotalPuntaje				INT,
	@PacienteInstitucionalizado	BIT,
	@IngresoPacienteMensual		FLOAT,
	@IngresoPacienteEventual	FLOAT,
	@NumeroReingreso			INT,
	@Observaciones				VARCHAR(300),
	@ServiciosDetalle			TEXT
AS
BEGIN
	BEGIN TRANSACTION 
		--INSERT INTO dbo.VentasServicios(NumeroAgencia, CodigoUsuario, DIPersonaResponsable1, DIPersonaResponsable2, DIPersonaResponsable3, CodigoCliente,  FechaHoraEntregaServicio, CodigoEstadoServicio, CodigoTipoServicio, MontoTotal, NumeroFactura, NumeroCredito, CodigoMoneda, Observaciones)
		--VALUES (@NumeroAgencia, @CodigoUsuario, @DIPersonaResponsable1, @DIPersonaResponsable2, @DIPersonaResponsable3, @CodigoCliente, @FechaHoraPagoServicio, @CodigoEstadoServicio, @CodigoTipoServicio, @MontoTotal, @NumeroFactura, @NumeroCredito, @CodigoMoneda, @Observaciones)
		--DECLARE @PorcentajeSubvencion	FLOAT
		--SET @PorcentajeSubvencion = (SELECT TOP(1) SubvencionInstitucional FROM Categorias WHERE CodigoCategoria = @CodigoCategoria)

		IF(@TotalPuntaje IS NULL)
			SET @TotalPuntaje = (select top(1) PuntajeActual from ValoracionSocioEconomica where NumeroPaciente = @NumeroPaciente)
		
		
		EXEC ActualizarPagoServicio @NumeroPaciente, @NumeroPagoServicio, @NumeroPagoServicioManual, @CodigoPagoServicio, @CodigoCategoria, @TipoServicio, @CodigoClaseServicio, @FechaSubvencion, 
				@NumeroPapeleta, @NombreSubvencionA, @Costo, @Subvencion, @MontoPagado, @TotalCancelar, @CategoriaZ, @TotalPuntaje, 
				@PacienteInstitucionalizado, @IngresoPacienteMensual, @IngresoPacienteEventual, @NumeroReingreso, @Observaciones
		
		DECLARE @punteroXMLServiciosDetalle INT
				
		
		--SET @NumeroVentaServicio = @@IDENTITY
		--SET @NumeroPagoServicio = SCOPE_IDENTITY()--Devuelve el ultimo id Ingresado en una Tabla con una columna Identidad dentro del Ambito,
		--es Decir en este caso, devolverá el ultimo IDENTITY generado dentro de la Tabla VentasServicios para esta transacción
					
		EXEC sp_xml_preparedocument @punteroXMLServiciosDetalle OUTPUT, @ServiciosDetalle
		--PARA INSERTAR LOS NUEVOS REGISTROS EN LA EDICIÓN 
		------------------------------------------------------------------------------------
		
		INSERT INTO dbo.PagoServiciosDetalle(
				NumeroPaciente, NumeroPagoServicio, CodigoServicio, Cantidad, CostoServicio, MontoCancelado, CodigoCategoria)
		SELECT  @NumeroPaciente, @NumeroPagoServicio, CodigoServicio, Cantidad, CostoServicio, MontoCancelado, CodigoCategoria
		FROM OPENXML (@punteroXMLServiciosDetalle, '/PagoServicios/PagoServiciosDetalle',2)
		WITH(	
				CodigoServicio	INT,
				CostoServicio	FLOAT,
				Cantidad		INT,
				MontoCancelado	FLOAT,
				CodigoCategoria INT
			)
		WHERE CodigoServicio NOT IN(
			SELECT VSD.CodigoServicio 
			FROM PagoServiciosDetalle VSD
			WHERE VSD.NumeroPaciente = @NumeroPaciente
			AND VSD.NumeroPagoServicio = @NumeroPagoServicio
		)
		
		--ACTUALIZAR LOS REGISTROS
		------------------------------------------------------------------------------------
		UPDATE PagoServiciosDetalle
			SET PagoServiciosDetalle.Cantidad = VSDXML.Cantidad,
				PagoServiciosDetalle.CostoServicio = VSDXML.CostoServicio,
				PagoServiciosDetalle.CodigoCategoria = VSDXML.CodigoCategoria,
				PagoServiciosDetalle.MontoCancelado = VSDXML.MontoCancelado
		FROM OPENXML (@punteroXMLServiciosDetalle, '/PagoServicios/PagoServiciosDetalle',2)
		WITH(	
				CodigoServicio	INT,
				CostoServicio	FLOAT,
				Cantidad		INT,
				MontoCancelado	FLOAT,
				CodigoCategoria INT
			)VSDXML
		WHERE PagoServiciosDetalle.NumeroPaciente = @NumeroPaciente
		AND PagoServiciosDetalle.NumeroPagoServicio = @NumeroPagoServicio
		AND PagoServiciosDetalle.CodigoServicio = VSDXML.CodigoServicio
		
		--QUITAR LOS REGISTROS QUE FUERON ELIMINADOS
		--------------------------------------------------------------------------
		DELETE
		FROM PagoServiciosDetalle
		WHERE CodigoServicio NOT IN
		(
			SELECT  CodigoServicio				
			FROM OPENXML (@punteroXMLServiciosDetalle, '/PagoServicios/PagoServiciosDetalle',2)
			WITH(
					CodigoServicio			INT
				)
		)
		AND PagoServiciosDetalle.NumeroPaciente = @NumeroPaciente
		AND PagoServiciosDetalle.NumeroPagoServicio = @NumeroPagoServicio
		
		EXEC sp_xml_removedocument @punteroXMLServiciosDetalle
		IF(@@ERROR <> 0)
		BEGIN
			RAISERROR('No se Pudo Actualizar la Venta de Servicios',1,16)	
			ROLLBACK TRAN
		END
		ELSE
			COMMIT TRANSACTION
END
GO

DROP PROCEDURE ListarPagosServiciosDetalleReporte
GO

CREATE PROCEDURE ListarPagosServiciosDetalleReporte
	@NumeroPaciente				INT,
	@NumeroPagoServicio			INT,
	@ClaseServicio				CHAR(1) -- 'S'->SERIVICIO NORMAL, 'I'-->INGRESO, 'R'->REINGRESOS
AS
BEGIN
	--DECLARE @PorcentajeSubvencion FLOAT
	--SELECT @PorcentajeSubvencion = ISNULL(PorcentajeSubvencion,0)
	--FROM PagoServicios 
	--WHERE NumeroPaciente = @NumeroPaciente
	--AND CodigoPagoServicio = @CodigoPagoServicio

	
	--SELECT	PSD.CodigoServicio, PSD.Cantidad, PSD.CostoServicio, S.NombreServicio, PSD.MontoCancelado, 
	--		PSD.CodigoCategoria, A.NombreCategoria,
	--		PSD.CostoServicio * @PorcentajeSubvencion / 100 AS MontoSubvencion,
	--		(PSD.CostoServicio * @PorcentajeSubvencion / 100) * psd.Cantidad AS MontoPagado, 
	--		psd.Cantidad * psd.CostoServicio as PrecioTotalReal,
	--		@PorcentajeSubvencion as PorcentajeSubvencion
	--FROM PagoServiciosDetalle PSD
	--INNER JOIN Servicios S
	--ON PSD.CodigoServicio = S.CodigoServicio
	--INNER JOIN Categorias C
	--ON C.CodigoCategoria = PSD.CodigoCategoria
	--WHERE PSD.NumeroPaciente = @NumeroPaciente
	--AND PSD.CodigoPagoServicio = @CodigoPagoServicio
	
	IF(@ClaseServicio = 'I')
		SELECT	PSD.CodigoServicio, PSD.Cantidad, PSD.CostoServicio, 
				S.NombreServicio, PSD.MontoCancelado, 
				PSD.CodigoCategoria, C.NombreCategoria,
				CostoServicio -  MontoCancelado AS MontoSubvencion,
				--MontoCancelado AS MontoPagado, 
				psd.Cantidad * psd.CostoServicio as PrecioTotalReal,
				MontoCancelado * 100 / CASE WHEN CostoServicio = 0 THEN 1 ELSE CostoServicio END as PorcentajeSubvencion
		FROM PagoServiciosDetalle PSD
		INNER JOIN dbo.PagoServicios PS
		ON PSD.NumeroPaciente = PS.NumeroPaciente
		AND PSD.NumeroPagoServicio = PS.NumeroPagoServicio
		INNER JOIN Servicios S
		ON PSD.CodigoServicio = S.CodigoServicio
		LEFT JOIN Categorias C
		ON C.CodigoCategoria = PSD.CodigoCategoria
		WHERE PSD.NumeroPaciente = @NumeroPaciente
		and PS.NumeroPagoServicioManual = 1
		ORDER BY FechaSubvencion
	IF(@ClaseServicio ='R')
		SELECT PSD.CodigoServicio, PSD.Cantidad, PSD.CostoServicio, 
				S.NombreServicio, PSD.MontoCancelado, 
				PSD.CodigoCategoria, C.NombreCategoria,
				CostoServicio -  MontoCancelado AS MontoSubvencion,
				--MontoCancelado AS MontoPagado, 
				psd.Cantidad * psd.CostoServicio as PrecioTotalReal,
				MontoCancelado * 100 / CASE WHEN CostoServicio = 0 THEN 1 ELSE CostoServicio END as PorcentajeSubvencion
		FROM PagoServiciosDetalle PSD
		INNER JOIN dbo.PagoServicios PS
		ON PSD.NumeroPaciente = PS.NumeroPaciente
		AND PSD.NumeroPagoServicio = PS.NumeroPagoServicio
		INNER JOIN Servicios S
		ON PSD.CodigoServicio = S.CodigoServicio
		LEFT JOIN Categorias C
		ON C.CodigoCategoria = PSD.CodigoCategoria
		WHERE PSD.NumeroPaciente = @NumeroPaciente
		AND PS.NumeroReingreso = @NumeroPagoServicio
	IF(@ClaseServicio ='S')
		SELECT	PSD.CodigoServicio, PSD.Cantidad, PSD.CostoServicio, 
				S.NombreServicio, PSD.MontoCancelado, 
				PSD.CodigoCategoria, C.NombreCategoria,
				CostoServicio -  MontoCancelado AS MontoSubvencion,
				--MontoCancelado AS MontoPagado, 
				psd.Cantidad * psd.CostoServicio as PrecioTotalReal,
				MontoCancelado * 100 / CASE WHEN CostoServicio = 0 THEN 1 ELSE CostoServicio END as PorcentajeSubvencion
		FROM PagoServiciosDetalle PSD
		INNER JOIN Servicios S
		ON PSD.CodigoServicio = S.CodigoServicio
		LEFT JOIN Categorias C
		ON C.CodigoCategoria = PSD.CodigoCategoria
		WHERE PSD.NumeroPaciente = @NumeroPaciente
		AND PSD.NumeroPagoServicio = @NumeroPagoServicio
	
END
GO
