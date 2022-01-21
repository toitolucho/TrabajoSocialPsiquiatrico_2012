USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarPagosServiciosReporte
GO

CREATE PROCEDURE ListarPagosServiciosReporte
	@NumeroPaciente		INT,
	@NumeroPagoServicio	INT
AS
BEGIN
	SELECT	PS.NombreSubvencionA, PS.NumeroPagoServicio, PS.NumeroPapeleta, PS.CodigoPagoServicio,
			DBO.ObtenerNombreCompleto(PS.NumeroPaciente) AS NombreCompletoPaciente,
			dbo.ObtenerEdadPaciente(PS.NumeroPaciente) AS EdadPaciente,
			PS.FechaSubvencion, C.NombreCategoria, PS.PorcentajeSubvencion,
			CASE PS.TipoServicio WHEN 'E' THEN 'SERVICIO EXTERNO' WHEN 'I' THEN 'SERVICIO EXTERNO' ELSE 'DESCONOCIDO' END AS TipoServicio,
			CASE PS.CodigoClaseServicio WHEN 'I' THEN 'POR INGRESO DEL PACIENTE'
			WHEN 'R' THEN 'POR REINGRESO DEL PACIENTE' WHEN 'S' THEN 'POR ATENCION MEDICA, SUBVENSION ECONOMICA NORMAL' END AS ClaseServicio,
			PS.TipoServicio AS CodigoTipoServicio, PS.CodigoClaseServicio,
			PS.MontoPagado, PS.Subvencion, PS.TotalCancelar, PS.Observaciones
	FROM PagoServicios PS
	LEFT JOIN Categorias C
	ON PS.CodigoCategoria = C.CodigoCategoria
	WHERE PS.NumeroPaciente = @NumeroPaciente
	AND PS.NumeroPagoServicio = @NumeroPagoServicio
END
GO

