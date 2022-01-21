USE TRABAJO_SOCIAL
GO


DROP VIEW VListaFiltros
GO

CREATE VIEW VListaFiltros
AS

	--DECLARE @TListaMeses TABLE
	--(
	--	NumeroMes	INT
	--)
	
	
	SELECT *
	FROM
	(
		SELECT 'MASCULINO' AS NombreAtributo, 'M' as CodigoAtributo, 'SX' as TipoAtributo
		UNION ALL
		SELECT 'FEMENINO', 'F', 'SX'
		
		UNION ALL
		SELECT 'DESCONOCIDO', 'DE', 'ES'
		UNION ALL
		SELECT 'SOLTERO(A)', 'SO', 'ES'
		UNION ALL
		SELECT 'CASADO(A)', 'CA', 'ES'
		UNION ALL
		SELECT 'VIUDO(A)', 'VI', 'ES'
		UNION ALL
		SELECT 'DIVORCIADO(A)', 'DI', 'ES'
		UNION ALL
		SELECT 'CONCUBINO(A)', 'CO', 'ES'
		
		UNION ALL
		SELECT 'ANALFABETO','A','GI'
		UNION ALL
		SELECT 'PRIAMRIA','P','GI'
		UNION ALL
		SELECT 'SECUNDARIA','S','GI'
		UNION ALL
		SELECT 'UNIVERSITARIA','U','GI'
		UNION ALL
		SELECT 'TECNICO SUPERIOR','T','GI'
		UNION ALL
		SELECT 'SUPERIOR','R','GI'	
		
		UNION ALL 
		SELECT NombreDepartamento, CodigoDepartamento, 'DT'
		FROM Departamentos
		WHERE CodigoPais = 'BO'
		
		UNION ALL
		SELECT 'CATOLICO','C','RE'
		UNION ALL
		SELECT 'EVANGELICO','E','RE'
		UNION ALL
		SELECT 'CRISTIANO','R','RE'
		UNION ALL
		SELECT 'ADVENTISTA','A','RE'
		UNION ALL
		SELECT 'ATEO','T','RE'
		UNION ALL
		SELECT 'MORMON','M','RE'
		UNION ALL
		SELECT 'TESTIGO DE JHEOVA','J','RE'
		UNION ALL
		SELECT 'PROTESTANTE','P','RE'
		UNION ALL
		SELECT 'DESCONOCIDO','D','RE'
		UNION ALL
		SELECT 'NINGUNO','N','RE'
		UNION ALL
		SELECT 'OTROS','O','RE'
		
		
		UNION ALL
		SELECT 'ESPAÑOL', 'E', 'ID'
		UNION ALL
		SELECT 'QUECHUA', 'Q', 'ID'
		UNION ALL
		SELECT 'AYMARA', 'Y', 'ID'
		UNION ALL
		SELECT 'GUARANI', 'G', 'ID'
		UNION ALL
		SELECT 'INGLES',  'I', 'ID'
		UNION ALL
		SELECT 'ALEMAN',  'A', 'ID'
		UNION ALL
		SELECT 'MUDO',    'M', 'ID'
		UNION ALL
		SELECT 'OTROS',   'O', 'ID'
		--UNION ALL
		--(EXEC DBO.GenerarTablaEdades)

	)TA
GO


DROP PROCEDURE GenerarTablaEdades
GO

CREATE PROCEDURE GenerarTablaEdades
AS
BEGIN

	declare @EdadMinima INT,
			@EdadMaxima	INT,
			@EdadIncremento	INT
			
	SET @EdadMaxima = 110
	SET @EdadMinima = 18
	SET @EdadIncremento = 5
	
	DECLARE @TListaMeses TABLE
	(
		RangoEdades		varchar(10),
		CodigoAtributo	VARCHAR(5),
		TipoAtributo	VARCHAR(2)
		
	)
	DECLARE	@ContadorMeses INT
	SET @ContadorMeses = @EdadMinima
	WHILE @ContadorMeses <= @EdadMaxima
	BEGIN
		INSERT INTO @TListaMeses(RangoEdades, CodigoAtributo, TipoAtributo) 
		VALUES ( CAST(@ContadorMeses AS VARCHAR(5)) + '-' + CAST((@ContadorMeses + @EdadIncremento) AS VARCHAR(5)), @ContadorMeses, 'ED')
		SET @ContadorMeses = @ContadorMeses + @EdadIncremento
	END
	
	SELECT * FROM @TListaMeses
END
GO

DROP FUNCTION ObtenerTablaEdades
GO

CREATE FUNCTION ObtenerTablaEdades()
RETURNS TABLE
AS	
	RETURN( SELECT * FROM PersonasEncargadas )
GO

EXEC DBO.GenerarTablaEdades

select * from VListaFiltros

SELECT * FROM PreguntasValoracion
SELECT * FROM RespuestasValoracion