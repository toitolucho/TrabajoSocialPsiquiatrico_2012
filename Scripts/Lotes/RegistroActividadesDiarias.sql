--NOMBRES DE TIPOS DE ACTIVIDADES EN FUNCION A UN PACIENTE

INSERT INTO dbo.ActividadesTipo VALUES('PACIENTE SE INSTITUCIONALIZA','', 'P')--SE DEBE ACTUALIZA TANTO EN LA FICHA SOCIAL COMO EN EL REGISTRO DE REINGRESO
INSERT INTO dbo.ActividadesTipo VALUES('PACIENTE SE DES-INSTITUCIONALIZA','', 'P')--SE DEBE ACTUALIZA TANTO EN LA FICHA SOCIAL COMO EN EL REGISTRO DE REINGRESO
INSERT INTO dbo.ActividadesTipo VALUES('REGISTRO DE FICHA SOCIAL O REINGRESO','') 
INSERT INTO dbo.ActividadesTipo VALUES('INFORMACI?N Y ORIENTACI?N A PACIENTES Y/O FAMILIARES','')
INSERT INTO dbo.ActividadesTipo VALUES('PACIENTE RECIBE VISITA','')
INSERT INTO dbo.ActividadesTipo VALUES('ENTREVISTA CON PACIENTES','')
INSERT INTO dbo.ActividadesTipo VALUES('ENTREVISTA CON FAMILIARES Y/O RESPONSABLES','')
INSERT INTO dbo.ActividadesTipo VALUES('VISITA DOMICILIARIA E INSTITUCIONAL','')
INSERT INTO dbo.ActividadesTipo VALUES('TRAMITE DE DOCUMENTOS PERSONALES DEL PACIENTE','','P')--SE ABRIRA EL FORMULARIO DE DOC
INSERT INTO dbo.ActividadesTipo VALUES('OTRO TIPO DE TR?MITES','')
INSERT INTO dbo.ActividadesTipo VALUES('RECEPCI?N DE ENCOMIENDA','')
INSERT INTO dbo.ActividadesTipo VALUES('COMUNICACI?N VIA TELEF?NICA','')
INSERT INTO dbo.ActividadesTipo VALUES('GESTI?N DE RECETAS, LABORATORIOS U OTROS ESTUDIOS','')
INSERT INTO dbo.ActividadesTipo VALUES('GESTI?N PARA ATENCI?N DE PACIENTES EN OTROS CENTROS HOSPITALARIOS','')
INSERT INTO dbo.ActividadesTipo VALUES('COORDINACI?N INTERINSTITUCIONAL','')
INSERT INTO dbo.ActividadesTipo VALUES('COORDINACI?N INTRAINSTITUCIONAL','') 
INSERT INTO dbo.ActividadesTipo VALUES('PERMISO O VACACI?N DEL PACIENTE','')
INSERT INTO dbo.ActividadesTipo VALUES('REINCORPORACI?N DEL PACIENTE','')
INSERT INTO dbo.ActividadesTipo VALUES('EVACI?N O FUGA','')
INSERT INTO dbo.ActividadesTipo VALUES('ALTA','')--SE CONSIDERA DES-INSTITUCIONALIZADO
INSERT INTO dbo.ActividadesTipo VALUES('DEFUNCI?N','')--SE CONSIDERA DES-INSTITUCIONALIZADO
INSERT INTO dbo.ActividadesTipo VALUES('REUNI?N CON EQUIPO DE UNIDADES','')
INSERT INTO dbo.ActividadesTipo VALUES('REUNI?N CON JEFE DE SALA, DIRECTOR M?DICO, ADMINISTRATIVO U OTROS SERVICIOS','')
INSERT INTO dbo.ActividadesTipo VALUES('OTRAS ACTIVIDADES','')


--NOMBRES DE TIPOS DE ACTIVIDADES SOBRE ACTIVIDADES ADMINISTRATIVAS

INSERT INTO dbo.ActividadesTipo VALUES('INFORMACI?N Y ORIENTACI?N A PACIENTES Y/O FAMILIARES','')
INSERT INTO dbo.ActividadesTipo VALUES('ASISTENCIA A CONFERENCIAS DE CAPACITACI?N','')
INSERT INTO dbo.ActividadesTipo VALUES('SESI?N CL?NICA','')
INSERT INTO dbo.ActividadesTipo VALUES('DOCENCIA ASISTENCIAL','')
INSERT INTO dbo.ActividadesTipo VALUES('OTRAS ACTIVIDADES','')
SELECT * FROM ActividadesTipo