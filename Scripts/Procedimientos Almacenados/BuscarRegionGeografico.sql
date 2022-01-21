USE TRABAJO_SOCIAL
GO

DROP PROCEDURE BuscarRegionGeografico
GO

CREATE PROCEDURE BuscarRegionGeografico
	@TipoBusquedaRegion	CHAR(1),
	@TextoBusqueda		VARCHAR(200)
AS
BEGIN
	IF(@TipoBusquedaRegion = 'P')
	BEGIN
		SELECT P.CodigoPais, '00' AS CodigoDepartamento, '00' AS CodigoProvincia, '00' AS CodigoLocalidad, P.NombrePais AS NombreRegion
		FROM Paises P
		WHERE NombrePais LIKE '%' + RTRIM(LTRIM(@TextoBusqueda)) + '%'
	END
	ELSE IF(@TipoBusquedaRegion = 'D')
	BEGIN
		SELECT P.CodigoPais, P.CodigoDepartamento, '00' AS CodigoProvincia, '00' AS CodigoLocalidad, p.NombreDepartamento as NombreRegion
		FROM dbo.Departamentos P
		WHERE NombreDepartamento LIKE '%' + RTRIM(LTRIM(@TextoBusqueda)) + '%'
	END
	ELSE IF(@TipoBusquedaRegion = 'R')
	BEGIN
		SELECT P.CodigoPais, P.CodigoDepartamento, P.CodigoProvincia, '00' AS CodigoLocalidad, p.NombreProvincia as NombreRegion
		FROM dbo.Provincias P
		WHERE NombreProvincia LIKE '%' + RTRIM(LTRIM(@TextoBusqueda)) + '%'
	END
	ELSE IF(@TipoBusquedaRegion = 'L')
	BEGIN
		SELECT P.CodigoPais, P.CodigoDepartamento, P.CodigoProvincia, P.CodigoLocalidad, p.NombreLocalidad as NombreRegion
		FROM dbo.Localidades P
		WHERE NombreLocalidad LIKE '%' + RTRIM(LTRIM(@TextoBusqueda)) + '%'
	END
END
GO

EXEC DBO.BuscarRegionGeografico 'P', ' '