USE [TRABAJO_SOCIAL]
GO
/****** Object:  UserDefinedFunction [dbo].[ObtenerNombreCompleto]    Script Date: 08/27/2011 09:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP FUNCTION [dbo].[ObtenerNombreCompleto]
GO

CREATE FUNCTION [dbo].[ObtenerNombreCompleto] (@NumeroPaciente INT)
RETURNS VARCHAR(160)
AS
BEGIN
	DECLARE @NombreCompleto VARCHAR(160)
	
	SELECT @NombreCompleto = RTRIM(PE.Nombre) + ' ' + LTRIM(RTRIM(ISNULL(PE.ApellidoPaterno,'')) + ' ' + RTRIM(ISNULL(PE.ApellidoMaterno,'')) )
	FROM dbo.Pacientes PE
	WHERE PE.NumeroPaciente = @NumeroPaciente

   	RETURN(@NombreCompleto)
END

