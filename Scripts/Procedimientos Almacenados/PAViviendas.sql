USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarVivienda
GO

CREATE PROCEDURE InsertarVivienda
	@NumeroPaciente		INT,
	@Vivienda			CHAR(1),
	@TipoVivienda		CHAR(1),
	@NumeroHabitaciones	INT,
	@CondicionVivienda	CHAR(1),
	@Observaciones		TEXT,
	@Luz				CHAR(1),
	@Agua				CHAR(1),
	@Alcantarillado		CHAR(1),
	@Telefono			CHAR(1),
	@Gas				CHAR(1)
AS
BEGIN
	INSERT INTO dbo.Viviendas (NumeroPaciente, Vivienda, TipoVivienda, NumeroHabitaciones, CondicionVivienda, Observaciones,
			Luz, Agua, Alcantarillado, Telefono, Gas)
	VALUES (@NumeroPaciente, @Vivienda, @TipoVivienda, @NumeroHabitaciones, @CondicionVivienda, @Observaciones,
			@Luz, @Agua, @Alcantarillado, @Telefono, @Gas)
END
GO

DROP PROCEDURE ActualizarVivienda
GO

CREATE PROCEDURE ActualizarVivienda
	@NumeroPaciente		INT,
	@Vivienda			CHAR(1),
	@TipoVivienda		CHAR(1),
	@NumeroHabitaciones	INT,
	@CondicionVivienda	CHAR(1),
	@Observaciones		TEXT,
	@Luz				CHAR(1),
	@Agua				CHAR(1),
	@Alcantarillado		CHAR(1),
	@Telefono			CHAR(1),
	@Gas				CHAR(1)
AS 
BEGIN
	
	UPDATE 	dbo.Viviendas	
		SET	
			Vivienda			= @Vivienda,
			TipoVivienda		= @TipoVivienda,
			NumeroHabitaciones	= @NumeroHabitaciones,
			CondicionVivienda	= @CondicionVivienda,
			Observaciones		= @Observaciones,
			Luz					= @Luz,
			Agua				= @Agua,
			Alcantarillado		= @Alcantarillado,
			Telefono			= @Telefono,
			Gas					= @Gas
	WHERE NumeroPaciente = @NumeroPaciente
END
GO


DROP PROCEDURE EliminarVivienda
GO

CREATE PROCEDURE EliminarVivienda
	@NumeroPaciente		INT
AS
BEGIN
	
	DELETE FROM dbo.Viviendas
	WHERE NumeroPaciente = @NumeroPaciente
END
GO

DROP PROCEDURE ListarViviendas
GO

CREATE PROCEDURE ListarViviendas
AS
BEGIN
	SELECT NumeroPaciente, Vivienda, TipoVivienda, NumeroHabitaciones, CondicionVivienda, Observaciones,
			Luz, Agua, Alcantarillado, Telefono, Gas
	FROM dbo.Viviendas
	ORDER BY NumeroPaciente
END
GO


DROP PROCEDURE ObtenerVivienda
GO

CREATE PROCEDURE ObtenerVivienda
	@NumeroPaciente		INT
AS
BEGIN
	SELECT NumeroPaciente, Vivienda, TipoVivienda, NumeroHabitaciones, CondicionVivienda, Observaciones,
			Luz, Agua, Alcantarillado, Telefono, Gas
	FROM  dbo.Viviendas
	WHERE NumeroPaciente = @NumeroPaciente
END
GO
