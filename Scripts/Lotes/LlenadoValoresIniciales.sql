USE TRABAJO_SOCIAL
GO

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
 VALUES (3,'11 y más', 6, '')
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
 
 
 --OCUPACIÓN
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
 VALUES (5,'Más de 2001', 1, '')


 --TENENCIA DE VIVIENDA
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (6,'Ninguna', 6, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (6,'Alquilada', 5, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (6,'Anticrético', 4, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (6,'Cuidador o Portero', 3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (6,'Cedida', 2, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (6,'Propia', 1, '')


 --SERVICIOS BÁSICOS
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
 VALUES (8,'Unión Libre o Estable', 3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (8,'Casado(a)', 2, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (8,'Soltero(a)', 1, '')


 --GRADO DE INSTRUCCIÓN
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (9,'Analfabeto', 6, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (9,'Primario', 5, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (9,'Secundario', 4, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (9,'Universitario', 3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (9,'Técnico Superior', 2, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (9,'Superior', 1, '')


 --CONDICION MEDICA
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (10,'Tratamiento Prolongado', 6, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (10,'Cirugía Mayor', 5, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (10,'Cirugía Mediana', 4, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (10,'Tratamiento Mediano', 3, '')
  INSERT INTO RespuestasValoracion (CodigoPreguntaValoracion, NombreRespuestaValoracion, Puntaje, Descripcion)
 VALUES (10,'Cirugía Menor', 2, '')
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
 
 
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AD', 'ANDORRA')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AE', 'UNITED ARAB EM')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AF', 'AFGHANISTAN')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AG', 'ANTIGUA AND BA')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AI', 'ANGUILLA')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AL', 'ALBANIA')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AM', 'ARMENIA')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AN', 'NETHERLANDS AN')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AO', 'ANGOLA')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AQ', 'ANTARCTICA')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AR', 'ARGENTINA')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AS', 'AMERICAN SAMOA')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AT', 'AUSTRIA')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AU', 'AUSTRALIA')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AW', 'ARUBA')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('AZ', 'AZERBAIJAN')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('BA', 'BOSNIA AND HER')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('BO', 'BOLIVIA')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('BR', 'BRASIL')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('CL', 'CHILE')
--INSERT INTO Paises(CodigoPais, NombrePais) VALUES('EC', 'ECUADOR')

--INSERT INTO Departamentos VALUES('BO','01','CHUQUISACA')
--INSERT INTO Departamentos VALUES('BO','02','LA PAZ')
--INSERT INTO Departamentos VALUES('BO','03','COCHABAMBA')
--INSERT INTO Departamentos VALUES('BO','04','ORURO')
--INSERT INTO Departamentos VALUES('BO','05','POTOSÍ')
--INSERT INTO Departamentos VALUES('BO','06','TARIJA')
--INSERT INTO Departamentos VALUES('BO','07','SANTA CRUZ')
--INSERT INTO Departamentos VALUES('BO','08','BENI')
--INSERT INTO Departamentos VALUES('BO','09','PANDO')

--INSERT INTO Provincias VALUES('BO','01','01','OROPEZA')
--INSERT INTO Provincias VALUES('BO','01','02','AZURDUY')
--INSERT INTO Provincias VALUES('BO','01','03','ZUDAÑEZ')
--INSERT INTO Provincias VALUES('BO','01','04','TOMINA')
--INSERT INTO Provincias VALUES('BO','01','05','HERNANDO SILES')

insert into UnidadesMedicas (NombreUnidadMedica, DireccionUnidadMedica, TelefonoUnidadMedica, Descripcion)
values ('INSTITUTO NACIONAL DE PSIQUIATRÍA “GREGORIO PACHECO”', 'DIRECCION','64-123456','INSTITUTO')


insert into Usuarios (Usuario, Contraseña, Nombre, ApellidoPaterno, ApellidoMaterno, CIUsuario, Direccion, Telefono, Celular, TipoUsuario, CodigoUnidadMedica)
values ('administrador', 'administrador','Luis Antonio', 'Molina', 'Yampa', '54654646', 'Oscar Alfaro # 301', '6431295', '72854863','A', 1)

INSERT INTO Servicios (NombreServicio, Precio, Descripcion)
SELECT 'CONSULTA EXTERNA',1,'PARA LAS ESPECIALIDADES'
UNION
SELECT 'INTERNACIÓN',1,''
UNION
SELECT 'MEDICACIÓN',1,''
UNION
SELECT 'FARMACIA',1,''
UNION
SELECT 'MENSUALIDAD',1,''
UNION
SELECT 'CERTIFICADO',1,''
UNION
SELECT 'LABORATORIO',1,''
UNION
SELECT 'FOTOGRAFIA',1,''

--SELECT * FROM Servicios

INSERT INTO Especialidades (NombreEspecialidad, Descripcion)
SELECT 'PSICOLOGÍA', ''
UNION 
SELECT 'NEUROLOGÍA', ''
UNION
SELECT 'ODONTOLOGÍA', ''
UNION
SELECT 'MEDICINA INTERNA', ''
UNION
SELECT 'FISIOTERAPIA', ''
UNION
SELECT 'PSIQUIATRIA', ''

--select * from Especialidades