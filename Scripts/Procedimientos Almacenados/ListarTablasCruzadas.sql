USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarTablasCruzadas
GO

CREATE PROCEDURE ListarTablasCruzadas
	@NombreTabla		VARCHAR(100), --Personas
	@NombreColumna		VARCHAR(100), -- Sexo
	@ColumnaOrdenacion	VARCHAR(100), -- 'Grado Instruccion'
	--@ValoresJoins		VARCHAR(MAX), -- 'F','M'
	--@NombresJoins		VARCHAR(MAX), -- 'Cantidad Femeninos','Cantidad Varones'
	@XMLValoresNombresJoins	TEXT,
	@TipoFiltroVista	CHAR(5),	  --'SX','GI'-> sacar el parametro 'TipoAtributo' de la vista dbo.VListaFiltros
	@Operador			VARCHAR(10)	  -- 'IN' ,'=', 'BETWEEN'	
AS
BEGIN
	DECLARE @Sql	VARCHAR(MAX),
			@Select	VARCHAR(MAX),
			@Joins	VARCHAR(MAX),
			@Where	VARCHAR(400),
			@PunteroXMLValoresNombresJoins	INT
	
	DECLARE @TJoins TABLE
	(		
		CodigoAtributo	VARCHAR(5),
		NombreAtributo	VARCHAR(100)
	)
	
	EXEC sp_xml_preparedocument @PunteroXMLValoresNombresJoins OUTPUT, @XMLValoresNombresJoins
	
	INSERT INTO @TJoins (CodigoAtributo, NombreAtributo)
	SELECT  Codigo, Descripcion
	FROM OPENXML (@PunteroXMLValoresNombresJoins, '/Listado/ObjetosCodigoDescricion',2)
	WITH(	
		codigo		VARCHAR(5),
		descripcion	VARCHAR(200)
	)
	EXEC sp_xml_removedocument @PunteroXMLValoresNombresJoins
	
				
	SET @Select = 'SELECT NombreAtributo, CodigoAtributo, TipoAtributo'
	SET @Sql = 
	'
	FROM dbo.VListaFiltros VLF'
	
	DECLARE @CodigoAtributo	VARCHAR(5),
			@NombreAtributo	VARCHAR(100)
	
	SET ROWCOUNT 1
	SELECT @CodigoAtributo = CodigoAtributo, @NombreAtributo = NombreAtributo
	FROM @TJoins				
	WHILE @@rowcount <> 0
	BEGIN
		
		--CREAMOS EL SCRIPT PARA EL JOIN
		SET @Joins = '
		LEFT JOIN
			(
				SELECT '+ @ColumnaOrdenacion + ', COUNT(*) AS ' + @NombreAtributo +'
				FROM '+ @NombreTabla +'
				WHERE '+ @NombreColumna + ' = ''' + @CodigoAtributo + '''
				GROUP BY ' + @ColumnaOrdenacion + '
			)TA' + @NombreAtributo + '
		ON TA' + @NombreAtributo + '.' + @ColumnaOrdenacion + ' = VLF.CodigoAtributo
		'
		SET @Sql = @Sql + @Joins
		SET @Select = @Select + ', ISNULL('+ @NombreAtributo +', 0) AS ' + @NombreAtributo
		
		DELETE @TJoins WHERE @CodigoAtributo = CodigoAtributo
		SET ROWCOUNT 1
		SELECT @CodigoAtributo = CodigoAtributo, @NombreAtributo = NombreAtributo
		FROM @TJoins
	END
	SET ROWCOUNT 0	
	
	SET @Sql = @Select + @Sql
	+ ' WHERE TipoAtributo = ''' + @TipoFiltroVista +  ''''
	
	PRINT @Sql
	
	EXEC (@Sql)
END
GO

EXEC DBO.ListarTablasCruzadas 'Pacientes', 'Religion', 'EstadoCivil', 
'
<Listado>
	<ObjetosCodigoDescricion>
	  <descripcion>CATOLICO</descripcion>
	  <codigo>C</codigo>
	</ObjetosCodigoDescricion>
	<ObjetosCodigoDescricion>
	  <descripcion>EVANGELICO</descripcion>
	  <codigo>E</codigo>
	</ObjetosCodigoDescricion>
	<ObjetosCodigoDescricion>
	  <descripcion>CRISTIANO</descripcion>
	  <codigo>R</codigo>
	</ObjetosCodigoDescricion>
	<ObjetosCodigoDescricion>
	  <descripcion>ADVENTISTA</descripcion>
	  <codigo>A</codigo>
	</ObjetosCodigoDescricion>
	<ObjetosCodigoDescricion>
	  <descripcion>ATEO</descripcion>
	  <codigo>T</codigo>
	</ObjetosCodigoDescricion>
	<ObjetosCodigoDescricion>
	  <descripcion>MORMON</descripcion>
	  <codigo>M</codigo>
	</ObjetosCodigoDescricion>
	<ObjetosCodigoDescricion>
	  <descripcion>TESTIGO_DE_JHEOVA</descripcion>
	  <codigo>J</codigo>
	</ObjetosCodigoDescricion>
	<ObjetosCodigoDescricion>
	  <descripcion>PROTESTANTE</descripcion>
	  <codigo>P</codigo>
	</ObjetosCodigoDescricion>
	<ObjetosCodigoDescricion>
	  <descripcion>DESCONOCIDO</descripcion>
	  <codigo>D</codigo>
	</ObjetosCodigoDescricion>
	<ObjetosCodigoDescricion>
	  <descripcion>NINGUNO</descripcion>
	  <codigo>N</codigo>
	</ObjetosCodigoDescricion>
	<ObjetosCodigoDescricion>
	  <descripcion>OTROS</descripcion>
	  <codigo>O</codigo>
	</ObjetosCodigoDescricion>
</Listado>
', 
'ES', '=' 


select NombreAtributo AS descripcion, CodigoAtributo AS codigo, TipoAtributo
from VListaFiltros Listado
where TipoAtributo = 're'
FOR XML RAW('ObjetosCodigoDescricion'), ELEMENTS, ROOT('Listado')
 

 
