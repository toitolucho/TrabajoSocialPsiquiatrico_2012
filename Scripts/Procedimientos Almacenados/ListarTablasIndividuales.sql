USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarTablasIndividuales
GO

CREATE PROCEDURE ListarTablasIndividuales
	@NombreTabla	VARCHAR(100),
	@NombreColumna	VARCHAR(100),
	@TipoFiltroVista	CHAR(5)	  --'SX','GI'-> sacar el parametro 'TipoAtributo' de la vista dbo.VListaFiltros
AS
BEGIN
	DECLARE @Sql	VARCHAR(MAX)
	
	SET @Sql = '	
	SELECT F.NombreAtributo, COUNT(*) AS Cantidad
	FROM ' + @NombreTabla + ' P
	INNER JOIN VListaFiltros F
	ON P.'+ @NombreColumna +' = F.CodigoAtributo
	WHERE F.TipoAtributo = ''' + @TipoFiltroVista +'''
	GROUP BY F.NombreAtributo'
	
	print @sql
	
	EXEC (@SQL)
END
GO

EXEC DBO.ListarTablasIndividuales 'Pacientes', 'Idioma', 'ID'