USE TRABAJO_SOCIAL
GO

DROP PROCEDURE InsertarPersonaEncargada
GO

CREATE PROCEDURE InsertarPersonaEncargada
	@NumeroPaciente	INT,
	@Padres			BIT,
	@Madres			BIT,
	@Hijos			BIT,
	@Hermanos		BIT,
	@EsposoA		BIT,
	@Otros			VARCHAR(50)
AS
BEGIN
	INSERT INTO dbo.PersonasEncargadas (NumeroPaciente, Padres, Madres, Hijos, Hermanos, EsposoA, Otros)
	VALUES (@NumeroPaciente, @Padres, @Madres, @Hijos, @Hermanos, @EsposoA, @Otros)
END
GO

DROP PROCEDURE ActualizarPersonaEncargada
GO

CREATE PROCEDURE ActualizarPersonaEncargada
	@NumeroPaciente	INT,
	@Padres			BIT,
	@Madres			BIT,
	@Hijos			BIT,
	@Hermanos		BIT,
	@EsposoA		BIT,
	@Otros			VARCHAR(50)
AS 
BEGIN
	
	UPDATE 	dbo.PersonasEncargadas
		SET	
			Padres		= @Padres,
			Madres		= @Madres,
			Hijos		= @Hijos,
			Hermanos	= @Hermanos,
			EsposoA		= @EsposoA,
			Otros		= @Otros
	WHERE NumeroPaciente = @NumeroPaciente
END
GO


DROP PROCEDURE EliminarPersonaEncargada
GO

CREATE PROCEDURE EliminarPersonaEncargada
	@NumeroPaciente	INT
AS
BEGIN
	
	DELETE FROM dbo.PersonasEncargadas
	WHERE NumeroPaciente = @NumeroPaciente
END
GO

DROP PROCEDURE ListarPersonasEncargadas
GO

CREATE PROCEDURE ListarPersonasEncargadas
AS
BEGIN
	SELECT NumeroPaciente, Padres, Madres, Hijos, Hermanos, EsposoA, Otros
	FROM dbo.PersonasEncargadas
	ORDER BY NumeroPaciente
END
GO


DROP PROCEDURE ObtenerPersonaEncargada
GO

CREATE PROCEDURE ObtenerPersonaEncargada
	@NumeroPaciente	INT
AS
BEGIN
	SELECT NumeroPaciente, Padres, Madres, Hijos, Hermanos, EsposoA, Otros
	FROM  dbo.PersonasEncargadas
	WHERE NumeroPaciente = @NumeroPaciente
END
GO
