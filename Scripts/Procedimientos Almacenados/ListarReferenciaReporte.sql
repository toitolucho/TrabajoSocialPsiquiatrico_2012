USE TRABAJO_SOCIAL
GO

DROP PROCEDURE ListarReferenciaReporte
GO

CREATE PROCEDURE ListarReferenciaReporte
	@NumeroReferencia	INT,
	@NumeroPaciente		INT
AS
BEGIN
	DECLARE @CodigoParentesco	INT
	SET @CodigoParentesco = 4

	SELECT R.NumeroReferencia, DBO.ObtenerNumeroHistorialClinicoPaciente(R.NumeroPaciente) AS HClinico,
			R.NumeroPaciente, R.FechaReferencia, R.DiagnosticoPsiquiatrico,
			p.NombreCompletoPaciente, p.EdadActual,			
			dbo.ObtenerNumeroFamiliaresParentescoAsociadosPaciente(@NumeroPaciente, @CodigoParentesco) AS NroHijos,
			p.DepartamentoProcedencia AS NombreDepartamentoProcedencia,
			p.EstadoCivil, p.GradoInstruccion, p.Ocupacion, p.Diagnostico,
			TS.NombreTS + ' ' + TS.ApellidoPaternoTS +' ' + TS.ApellidoMaternoTS AS NombreTrabajadoraSocial,
			O.NombreOcupacion AS NombreOcupacionTS, UM.NombreUnidadMedica AS NombreUnidadMedicaTS,
			E.NombreEspecialidad, u.Nombre + ' ' +u.ApellidoPaterno + ' ' + u.ApellidoMaterno as NombreCompletoUsuario,
			UM2.NombreUnidadMedica as NombreUnidadMedicaUsuario, R.Observaciones,
			CASE R.CodigoTipoReferencia WHEN 'A' THEN 'ENVIADAS' ELSE 'RECIBIDAS' END AS TipoReferencia,
			CR.NumeroContrarreferencia, CR.FechaContrarreferencia, CR.NombreMedicoAtendio, 
			CR.Observaciones AS ObservacionesContraReferencia
	FROM Referencias R
	INNER JOIN dbo.PacientesDatos P
	ON R.NumeroPaciente = P.NumeroPaciente	
	INNER JOIN TrabajadoresSociales TS
	ON R.CodigoTrabajadorSocial = TS.CodigoTrabajadorSocial
	LEFT JOIN Ocupaciones O
	ON TS.CodigoOcupacion = O.CodigoOcupacion
	LEFT JOIN UnidadesMedicas UM
	ON TS.CodigoUnidadMedica = UM.CodigoUnidadMedica
	LEFT JOIN Especialidades E
	ON R.CodigoEspecialidad = E.CodigoEspecialidad
	LEFT JOIN Usuarios U
	ON R.CodigoUsuario = U.CodigoUsuario
	LEFT JOIN UnidadesMedicas UM2	
	ON U.CodigoUnidadMedica = UM2.CodigoUnidadMedica
	LEFT JOIN Contrarreferencias CR
	ON R.NumeroReferencia = CR.NumeroContrarreferencia
	AND R.NumeroPaciente = CR.NumeroPaciente
	WHERE R.NumeroReferencia = @NumeroReferencia
	AND R.NumeroPaciente = @NumeroPaciente
END
GO

