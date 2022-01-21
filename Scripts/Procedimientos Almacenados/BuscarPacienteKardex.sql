USE TRABAJO_SOCIAL
GO

DROP PROCEDURE BuscarPacienteKardex
GO

-- @TipoBusqueda
--0 Historial Clinico
--1	Nombre/s
--2	Apellido Paterno
--3	Apellido Materno
--4 Unidad
--5 Seccion
CREATE PROCEDURE BuscarPacienteKardex
	@TipoBusqueda	CHAR(1),
	@TextoBusqueda	VARCHAR(250)
AS
BEGIN
	DECLARE @SQLScript VARCHAR(100)
	SET @SQLScript = 'SELECT * FROM PACIENTES'
	IF(@TipoBusqueda IS NOT NULL)
	BEGIN
		SET @SQLScript = @SQLScript + ' WHERE '
		SET @SQLScript = @SQLScript +  CASE WHEN @TipoBusqueda = 1 THEN ' Nombre LIKE ''%'+  @TextoBusqueda  +'%'' ' 
									   WHEN @TipoBusqueda = 2 THEN ' ApellidoPaterno LIKE ''%'+  @TextoBusqueda  +'%'' '
									   WHEN @TipoBusqueda = 3 THEN ' ApellidoMaterno LIKE ''%'+  @TextoBusqueda  +'%'' '
									   WHEN @TipoBusqueda = 4 THEN ' Unidad = ' + @TextoBusqueda
									   WHEN @TipoBusqueda = 5 THEN ' Seccion LIKE ''%'+  @TextoBusqueda  +'%'' '
									   WHEN @TipoBusqueda = 0 THEN ' HClinico = ' + @TextoBusqueda END
		
	END
	
	--PRINT @SQLScript
	EXEC (@SQLScript)
	
END
GO

--EXEC DBO.BuscarPacienteKardex 4, '1941' 
