USE  TRABAJO_SOCIAL
GO

DELETE FROM Contrarreferencias
GO
DELETE FROM Referencias
GO
DELETE FROM Actividades
GO
DELETE FROM ActividadesTipo
DBCC checkident ('TRABAJO_SOCIAL.dbo.ActividadesTipo', reseed, 0) 
GO
DELETE FROM SeguimientoAnual
GO
DELETE FROM SeguimientosSociales
GO
DELETE FROM ValoracionSocioeconomica
GO
DELETE FROM PagoServiciosDetalle
GO
DELETE FROM PagoServicios
DBCC checkident ('TRABAJO_SOCIAL.dbo.PagoServicios', reseed, 0) 
GO
DELETE FROM Servicios
DBCC checkident ('TRABAJO_SOCIAL.dbo.Servicios', reseed, 0) 
GO
DELETE FROM Especialidades
DBCC checkident ('TRABAJO_SOCIAL.dbo.Especialidades', reseed, 0) 
GO
DELETE FROM RespuestasValoracion
DBCC checkident ('TRABAJO_SOCIAL.dbo.RespuestasValoracion', reseed, 0) 
GO
DELETE FROM PreguntasValoracion
DBCC checkident ('TRABAJO_SOCIAL.dbo.PreguntasValoracion', reseed, 0) 
GO
DELETE FROM Categorias
DBCC checkident ('TRABAJO_SOCIAL.dbo.Categorias', reseed, 0) 
GO
DELETE FROM InformesSociales
GO
DELETE FROM TrabajadoresSociales
DBCC checkident ('TRABAJO_SOCIAL.dbo.TrabajadoresSociales', reseed, 0) 
GO
DELETE FROM Medicos
DBCC checkident ('TRABAJO_SOCIAL.dbo.Medicos', reseed, 0) 
GO
DELETE FROM Documentos
GO
DELETE FROM DocumentosTipo
DBCC checkident ('TRABAJO_SOCIAL.dbo.DocumentosTipo', reseed, 0) 
GO
DELETE FROM Responsables
GO
DELETE FROM Familiares
GO
DELETE FROM Parentescos
DBCC checkident ('TRABAJO_SOCIAL.dbo.Parentescos', reseed, 0) 
GO
DELETE FROM Usuarios
DBCC checkident ('TRABAJO_SOCIAL.dbo.Usuarios', reseed, 0) 
GO
DELETE FROM UnidadesMedicas
DBCC checkident ('TRABAJO_SOCIAL.dbo.UnidadesMedicas', reseed, 0) 
GO
DELETE FROM Ocupaciones
DBCC checkident ('TRABAJO_SOCIAL.dbo.Ocupaciones', reseed, 0) 
GO



--NOMBRES DE UNIDADES MEDICAS --> EL NOMBRE DE ESTA TABLA CAMBIARA A INSTITUCIONES
INSERT INTO dbo.UnidadesMedicas VALUES('INSTITUTO NACIONAL DE PSIQUIATR�A GREGORIO PACHECO','Plaza Presidente Aniceto Arce S/N','6455897','I','')
INSERT INTO dbo.UnidadesMedicas VALUES('HOSPITAL SANTA B�RBARA','Ayacucho S/N','64-60133','I','')
INSERT INTO dbo.UnidadesMedicas VALUES('INSTITUTO DE GASTROENTEROLOG�A BOLIVIANO JAPON�S','','6454700','I','')
INSERT INTO dbo.UnidadesMedicas VALUES('INSTITUTO PSICOPEDAG�GICO SAN JUAN DE DIOS','','','I','')
INSERT INTO dbo.UnidadesMedicas VALUES('HOSPITAL CRISTO DE LAS AM�RICAS','Av. Japon S/N','6437804-6443269-6439651','I','')
INSERT INTO dbo.UnidadesMedicas VALUES('HOSPITAL GINECO-OBST�TRICO','','64-44644','I','')
INSERT INTO dbo.UnidadesMedicas VALUES('CAJA NACIONAL DE SALUD','','','I','')
INSERT INTO dbo.UnidadesMedicas VALUES('FONDO DE PENSIONES BASICAS','Pasaje Rouma 25','6443840-6453070','I','')
INSERT INTO dbo.UnidadesMedicas VALUES('BANCO LOS ANDES','','','I','')
INSERT INTO dbo.UnidadesMedicas VALUES('HONORABLE ALCALDIA MUNICIPAL','','','I','')
INSERT INTO dbo.UnidadesMedicas VALUES('DEFENSORIA DE LA NI�EZ Y ADOLESCENCIA','','','I','')
INSERT INTO dbo.UnidadesMedicas VALUES('SERVICIO LEGAL INTEGRAL','','','I','')



--FUNCIONARIAS DEL DEPARTAMENTO DE TRABAJO SOCIAL EN LA TABLA DE USUARIO
INSERT INTO dbo.Usuarios VALUES('administrador','administrador','EDITH','VILLCA','TICONA','5655076','Raul Romero Linares Nro. D-2','64-28517','76127784','A','1')
INSERT INTO dbo.Usuarios VALUES('silvia','trabajosocial','LIC. SILVIA','ZAMORA','ROMERO','1099141','Serrano Nro. 268','64-41067','79301345','T','1')
INSERT INTO dbo.Usuarios VALUES('elizabeth','trabajosocial','LIC. ELIZABETH ','VILLAGOMEZ','PANIAGUA','1093814','Lima Pampa Nro. 32','64-44489','','T','1')


--NOMBRES DE DOCUMENTOS
INSERT INTO dbo.DocumentosTipo VALUES('CARNET DE IDENTIDAD','')
INSERT INTO dbo.DocumentosTipo VALUES('CERTIFICADO DE NACIMIENTO','')
INSERT INTO dbo.DocumentosTipo VALUES('CERTIFICADO DE BAUTIZO','')
INSERT INTO dbo.DocumentosTipo VALUES('CARNET DE SALUD DEL SEGURO SOCIAL','')
INSERT INTO dbo.DocumentosTipo VALUES('CARNET DE DISCAPACITADO','')
INSERT INTO dbo.DocumentosTipo VALUES('SEGURO DE SALUD PARA EL ADULTO MAYOR "SSPAM"','')


--NOMBRES DE PARENTESCO
INSERT INTO dbo.Parentescos VALUES('PADRE','')
INSERT INTO dbo.Parentescos VALUES('MADRE','')
INSERT INTO dbo.Parentescos VALUES('SUEGRO(A)','')
INSERT INTO dbo.Parentescos VALUES('HIJO(A)','')
INSERT INTO dbo.Parentescos VALUES('YERNO','')
INSERT INTO dbo.Parentescos VALUES('NUERA','')
INSERT INTO dbo.Parentescos VALUES('ABUELO(A)','')
INSERT INTO dbo.Parentescos VALUES('HERMANO(A)','')
INSERT INTO dbo.Parentescos VALUES('CU�ADO(A)','')
INSERT INTO dbo.Parentescos VALUES('NIETO(A)','')
INSERT INTO dbo.Parentescos VALUES('BISABUELO(A)','')
INSERT INTO dbo.Parentescos VALUES('T�O(A)','')
INSERT INTO dbo.Parentescos VALUES('SOBRINO(A)','')
INSERT INTO dbo.Parentescos VALUES('BIZNIETO(A)','')
INSERT INTO dbo.Parentescos VALUES('PRIMO(A)','')
INSERT INTO dbo.Parentescos VALUES('AMIGO(A)','')
INSERT INTO dbo.Parentescos VALUES('NINGUNO','')


--NOMBRES DE SERVICIOS QUE BRINDA LA INSTITUCION --> 
--EL NOMBRE DE ESTA TABLA SE CAMBIARA A SERVICIOS_BRINDADOS

INSERT INTO dbo.Servicios VALUES ('INTERNACI�N',80,'')
INSERT INTO dbo.Servicios VALUES ('MEDICACI�N','','')--el precio de este serivico varia de acuedo al tratamiento
INSERT INTO dbo.Servicios VALUES ('FARMACIA','','')--el precio de este serivico varia de acuedo al tratamiento
INSERT INTO dbo.Servicios VALUES ('MENSUALIDAD',600,'')
INSERT INTO dbo.Servicios VALUES ('CERTIFICADO',50,'')
INSERT INTO dbo.Servicios VALUES ('LABORATORIO',150,'')
INSERT INTO dbo.Servicios VALUES ('FOTOGRAF�A',15,'')
INSERT INTO dbo.Servicios VALUES ('PSICOLOG�A',10,'')
INSERT INTO dbo.Servicios VALUES ('NEUROLOG�A',10,'')
INSERT INTO dbo.Servicios VALUES ('ODONTOLOG�A',10,'')
INSERT INTO dbo.Servicios VALUES ('MEDICINA INTERNA',10,'')
INSERT INTO dbo.Servicios VALUES ('FISIOTERAPIA',10,'')
INSERT INTO dbo.Servicios VALUES ('PSIQUIATRIA',10,'')


--NOMBRES DE SERVICIOS REFERIDOS A OTRA INSTITUCION --> 
--EL NOMBRE DE ESTA TABLA SE CAMBIARA A SERVICIOS_REFERENCIADOS

INSERT INTO Especialidades VALUES ('Servicio de Atenci�n Ginecolog�a','')
INSERT INTO Especialidades VALUES ('Servicio de Atenci�n Rayos X','')
INSERT INTO Especialidades VALUES ('Servicio de Atenci�n Ecograf�a','')
INSERT INTO Especialidades VALUES ('Servicio de Atenci�n Hematolog�a','')
INSERT INTO Especialidades VALUES ('Servicio de Atenci�n Ecograf�a','')
INSERT INTO Especialidades VALUES ('Servicio de Atenci�n Cardiolog�a','')
INSERT INTO Especialidades VALUES ('Servicio de Atenci�n Gastroenterolog�a','')
INSERT INTO Especialidades VALUES ('Servicio de Atenci�n Endocrinolog�a','')
INSERT INTO Especialidades VALUES ('Servicio de Atenci�n Dermatolog�a','')
INSERT INTO Especialidades VALUES ('Servicio de Atenci�n Cirug�a Pl�stica','')
INSERT INTO Especialidades VALUES ('Servicio de Atenci�n Cirug�a Cardiovascular','')
UPDATE Especialidades
	SET NombreEspecialidad = UPPER(NombreEspecialidad)

--NOMBRES DE TIPOS DE ACTIVIDADES EN FUNCION A UN PACIENTE

INSERT INTO dbo.ActividadesTipo VALUES('PACIENTE SE INSTITUCIONALIZA','','P')--SE DEBE ACTUALIZA TANTO EN LA FICHA SOCIAL COMO EN EL REGISTRO DE REINGRESO
INSERT INTO dbo.ActividadesTipo VALUES('PACIENTE SE DES-INSTITUCIONALIZA','','P')--SE DEBE ACTUALIZA TANTO EN LA FICHA SOCIAL COMO EN EL REGISTRO DE REINGRESO
INSERT INTO dbo.ActividadesTipo VALUES('REGISTRO DE FICHA SOCIAL O REINGRESO','','P') 
INSERT INTO dbo.ActividadesTipo VALUES('INFORMACI�N Y ORIENTACI�N A PACIENTES Y/O FAMILIARES','','P')
INSERT INTO dbo.ActividadesTipo VALUES('PACIENTE RECIBE VISITA','','P')
INSERT INTO dbo.ActividadesTipo VALUES('ENTREVISTA CON PACIENTES','','P')
INSERT INTO dbo.ActividadesTipo VALUES('ENTREVISTA CON FAMILIARES Y/O RESPONSABLES','','P')
INSERT INTO dbo.ActividadesTipo VALUES('VISITA DOMICILIARIA E INSTITUCIONAL','','P')
INSERT INTO dbo.ActividadesTipo VALUES('TR�MITE DE DOCUMENTOS PERSONALES DEL PACIENTE','','P')--SE ABRIRA EL FORMULARIO DE DOC
INSERT INTO dbo.ActividadesTipo VALUES('OTRO TIPO DE TR�MITES','','P')
INSERT INTO dbo.ActividadesTipo VALUES('RECEPCI�N DE ENCOMIENDA','','P')
INSERT INTO dbo.ActividadesTipo VALUES('COMUNICACI�N VIA TELEF�NICA','','P')
INSERT INTO dbo.ActividadesTipo VALUES('GESTI�N DE RECETAS, LABORATORIOS U OTROS ESTUDIOS','','P')
INSERT INTO dbo.ActividadesTipo VALUES('GESTI�N PARA ATENCI�N DE PACIENTES EN OTROS CENTROS HOSPITALARIOS','','P')
INSERT INTO dbo.ActividadesTipo VALUES('COORDINACI�N INTERINSTITUCIONAL','','P')
INSERT INTO dbo.ActividadesTipo VALUES('COORDINACI�N INTRAINSTITUCIONAL','','P') 
INSERT INTO dbo.ActividadesTipo VALUES('PERMISO O VACACI�N DEL PACIENTE','','P')
INSERT INTO dbo.ActividadesTipo VALUES('REINCORPORACI�N DEL PACIENTE','','P')
INSERT INTO dbo.ActividadesTipo VALUES('EVACI�N O FUGA','','P')
INSERT INTO dbo.ActividadesTipo VALUES('ALTA','','P')--SE CONSIDERA DES-INSTITUCIONALIZADO
INSERT INTO dbo.ActividadesTipo VALUES('DEFUNCI�N','','P')--SE CONSIDERA DES-INSTITUCIONALIZADO
INSERT INTO dbo.ActividadesTipo VALUES('REUNI�N CON EQUIPO DE UNIDADES','','P')
INSERT INTO dbo.ActividadesTipo VALUES('REUNI�N CON JEFE DE SALA, DIRECTOR M�DICO, ADMINISTRATIVO U OTROS SERVICIOS','','P')
INSERT INTO dbo.ActividadesTipo VALUES('SESI�N CL�NICA','','P')
INSERT INTO dbo.ActividadesTipo VALUES('OTRAS ACTIVIDADES','','P')

--NOMBRES DE TIPOS DE ACTIVIDADES SOBRE ACTIVIDADES ADMINISTRATIVAS

INSERT INTO dbo.ActividadesTipo VALUES('INFORMACI�N Y ORIENTACI�N A PACIENTES Y/O FAMILIARES','','G')
INSERT INTO dbo.ActividadesTipo VALUES('ASISTENCIA A CONFERENCIAS DE CAPACITACI�N','','G')
INSERT INTO dbo.ActividadesTipo VALUES('DOCENCIA ASISTENCIAL','','G')
INSERT INTO dbo.ActividadesTipo VALUES('OTRAS ACTIVIDADES','','G')



--PREGUNTAS Y RESPUESTAS DE VALORACION SOCIOECONOMICA

INSERT INTO dbo.PreguntasValoracion(NombrePreguntaValoracion, Descripcion)
 VALUES ('RESIDENCIA URBANA','')
 INSERT INTO dbo.PreguntasValoracion(NombrePreguntaValoracion, Descripcion)
 VALUES ('RESIDENCIA RURAL','')
 INSERT INTO dbo.PreguntasValoracion(NombrePreguntaValoracion, Descripcion)
 VALUES ('GRUPO FAMILIAR','')
 INSERT INTO dbo.PreguntasValoracion(NombrePreguntaValoracion, Descripcion)
 VALUES ('OCUPACION','')
 INSERT INTO dbo.PreguntasValoracion(NombrePreguntaValoracion, Descripcion)
 VALUES ('INGRESOS FAMILIARES','')
 INSERT INTO dbo.PreguntasValoracion(NombrePreguntaValoracion, Descripcion)
 VALUES ('TENENCIA DE VIVIENDA','')
 INSERT INTO dbo.PreguntasValoracion(NombrePreguntaValoracion, Descripcion)
 VALUES ('SERVICIOS BASICOS','')
 INSERT INTO dbo.PreguntasValoracion(NombrePreguntaValoracion, Descripcion)
 VALUES ('ESTADO CIVIL','')
 INSERT INTO dbo.PreguntasValoracion(NombrePreguntaValoracion, Descripcion)
 VALUES ('GRADO DE INSTRUCCION','')
 INSERT INTO dbo.PreguntasValoracion(NombrePreguntaValoracion, Descripcion)
 VALUES ('CONDICION MEDICA','') 
 GO
 
 --RESIDENCIA URBANA
 INSERT INTO dbo.RespuestasValoracion(CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (1,'Periurbano',6, '')
  INSERT INTO dbo.RespuestasValoracion(CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (1,'Urbano Popular',5, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (1,'Ciudad Intermedia',4, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (1,'Capital de Departamento',3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (1,'Central',2, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (1,'Residencial',1, '')
 
 --RESIDENCIA RURAL
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (2,'Grupo 6', 6, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (2,'Grupo 5', 5, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (2,'Grupo 4', 4, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (2,'Grupo 3', 3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (2,'Grupo 2', 2, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (2,'Grupo 1', 1, '')
 

 --GRUPO FAMILIAR
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (3,'11 y m�s', 6, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (3,'9 a 10', 5, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (3,'7 a 8', 4, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (3,'5 a 6', 3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (3,'3 a 4', 2, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (3,'1 a 2', 1, '')
 
 
 --OCUPACI�N
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (4,'Cesante o Desocupado', 6, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (4,'Trabajador a destajo o Eventual', 5, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (4,'Cuenta Propia o Asalariado sin Seguro', 4, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (4,'Estudiantes o ama de casa', 3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (4,'Micro Empresario', 2, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (4,'Profesional o Empresario', 1, '')

 --INGRESOS FAMILIARES EN Bs
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (5,'Sin Ingreso o Dependiente', 6, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (5,'Menos de 500', 5, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (5,'501 a 1000', 4, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (5,'1001 a 1500', 3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (5,'1501 a 2000', 2, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (5,'M�s de 2001', 1, '')


 --TENENCIA DE VIVIENDA
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (6,'Ninguna', 6, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (6,'Alquilada', 5, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (6,'Anticr�tico', 4, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (6,'Cuidador o Portero', 3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (6,'Cedida', 2, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (6,'Propia', 1, '')


 --SERVICIOS B�SICOS
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (7,'Ninguno', 6, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (7,'1 Servicio', 5, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (7,'2 Servicios', 4, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (7,'3 Servicios', 3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (7,'4 Servicios', 2, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (7,'Otros Servicios Adicionales', 1, '')


 --ESTADO CIVIL
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (8,'Viudo(a)', 6, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (8,'Divorciado(a) o Separado(a)', 5, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (8,'Soltero(a) con dependiente', 4, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (8,'Uni�n Libre o Estable', 3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (8,'Casado(a)', 2, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (8,'Soltero(a)', 1, '')


 --GRADO DE INSTRUCCI�N
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (9,'Analfabeto', 6, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (9,'Primario', 5, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (9,'Secundario', 4, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (9,'Universitario', 3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (9,'T�cnico Superior', 2, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (9,'Superior', 1, '')


 --CONDICION MEDICA
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (10,'Cirug�a Mayor', 6, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (10,'Cirug�a Mediana', 5, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (10,'Cirug�a Menor', 4, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (10,'Tratamiento Prolongado', 3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (10,'Tratamiento Mediano', 2, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (10,'Tratamiento Corto', 1, '')

 
 --INSERT INTO Categoria (NombreCategoria, AporteUsuario, SubvencionInstitucional, PuntajeMinimo, PuntajeMaximo)
 --VALUES ('A', 0, 100, 47, 54)
 INSERT INTO Categorias (NombreCategoria, AporteUsuario, SubvencionInstitucional, PuntajeMinimo, PuntajeMaximo)
 VALUES ('A', 0, 100, 47, 54)
 INSERT INTO Categorias (NombreCategoria, AporteUsuario, SubvencionInstitucional, PuntajeMinimo, PuntajeMaximo)
 VALUES ('B', 20, 80, 39, 46)
 INSERT INTO Categorias (NombreCategoria, AporteUsuario, SubvencionInstitucional, PuntajeMinimo, PuntajeMaximo)
 VALUES ('C', 40, 60, 31, 38)
 INSERT INTO Categorias (NombreCategoria, AporteUsuario, SubvencionInstitucional, PuntajeMinimo, PuntajeMaximo)
 VALUES ('D', 60, 40, 23, 30)
 INSERT INTO Categorias (NombreCategoria, AporteUsuario, SubvencionInstitucional, PuntajeMinimo, PuntajeMaximo)
 VALUES ('E', 80, 20, 15, 22)
 INSERT INTO Categorias (NombreCategoria, AporteUsuario, SubvencionInstitucional, PuntajeMinimo, PuntajeMaximo)
 VALUES ('F', 100, 0, 7, 14)
 INSERT INTO Categorias (NombreCategoria, AporteUsuario, SubvencionInstitucional, PuntajeMinimo, PuntajeMaximo)
 VALUES ('Z', 0, 0, 0, 0)
 

INSERT INTO dbo.Ocupaciones (NombreOcupacion, Descripcion) 
VALUES ('MEDICO DOCTOR(A)', '')
INSERT INTO dbo.Ocupaciones (NombreOcupacion, Descripcion) 
VALUES ('TRABAJADOR(A) SOCIAL', '')

