USE TRABAJO_SOCIAL
GO

DROP PROCEDURE BuscarPaciente
GO

CREATE PROCEDURE BuscarPaciente
	@BuscarEn		CHAR(1),--'H'->PACIENTES HOSPITALIZADOS, 'E'->PACIENTES CONSULTA EXTERNA
	@TextoBusqueda	VARCHAR(100)
AS
BEGIN
	IF(@BuscarEn IS NULL OR @BuscarEn ='' )
	BEGIN
		SELECT *, DBO.ObtenerEdad(FechaNacimiento, GETDATE()) AS Edad, 
		CASE WHEN CodigoEstadoPaciente = 'A' THEN 'ACTIVO' ELSE 'PASIVO' END AS EstadoPaciente
		FROM Pacientes
		WHERE Nombre LIKE '%' + @TextoBusqueda + '%'	
		OR ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
		OR ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
		OR Unidad LIKE '%' + @TextoBusqueda + '%'	
		OR CAST(NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
		OR Seccion LIKE '%' + @TextoBusqueda + '%'	
		OR CAST(HClinico AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
	END
	ELSE
	BEGIN
		--SELECT *, DBO.ObtenerEdad(FechaNacimiento, GETDATE()) AS Edad
		--FROM Pacientes
		--WHERE
		--CAST((CASE WHEN HClinico IS NULL THEN '-1' ELSE HClinico END) AS VARCHAR(100)) LIKE CASE WHEN @BuscarEn = 'H' THEN '[1-9]%' ELSE '-1' END 
		--AND (
		--Nombre LIKE '%' + @TextoBusqueda + '%'	
		--OR ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
		--OR ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
		--OR Unidad LIKE '%' + @TextoBusqueda + '%'	
		--OR CAST(NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
		--OR Seccion LIKE '%' + @TextoBusqueda + '%'	
		--OR CAST(HClinico AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%') order by HClinico
		IF(@BuscarEn = 'H')
		BEGIN
			SELECT *, DBO.ObtenerEdad(FechaNacimiento, GETDATE()) AS Edad,
			CASE WHEN CodigoEstadoPaciente = 'A' THEN 'ACTIVO' ELSE 'PASIVO' END AS EstadoPaciente
			FROM Pacientes
			WHERE DBO.EstaPacienteHospitalizado(NumeroPaciente) = 1
			AND HClinico IS NOT NULL
			AND (Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR Seccion LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(HClinico AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%')
			
		END
		ELSE
		BEGIN
			SELECT *, DBO.ObtenerEdad(FechaNacimiento, GETDATE()) AS Edad,
			CASE WHEN CodigoEstadoPaciente = 'A' THEN 'ACTIVO' ELSE 'PASIVO' END AS EstadoPaciente
			FROM Pacientes
			WHERE HClinico IS NULL
			AND (Nombre LIKE '%' + @TextoBusqueda + '%'	
			OR ApellidoMaterno LIKE '%' + @TextoBusqueda + '%'	
			OR ApellidoPaterno LIKE '%' + @TextoBusqueda + '%'	
			OR Unidad LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(NumeroPaciente AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%'	
			OR Seccion LIKE '%' + @TextoBusqueda + '%'	
			OR CAST(HClinico AS CHAR(100)) LIKE '%' + @TextoBusqueda + '%')
		END
	END
END
GO

--exec dbo.BuscarPaciente '', ''
select * from pacientes where HClinico = '5842'
select * from responsables where numeropaciente = 1441