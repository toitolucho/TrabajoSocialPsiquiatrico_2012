INSERT INTO [PSIQUIATRICO].[dbo].[Nuevo_P]
           ([Hc]
           ,[Nombre]
           ,[Paterno]
           ,[Materno]
           ,[Ingreso]
           ,[Nacimiento]
           ,[Lugar]
           ,[Idioma]
           ,[Sexo]
           ,[Estado_Civil]
           ,[Nivel_Est]
           ,[Profesion]
           ,[Raza]
           ,[Religion]
           ,[Departamento]
           ,[Area])
     VALUES(
           1556
           ,'LUIS ANTONIO'
           ,'MOLINA'
           ,'YAMPA'
           ,GETDATE()
           ,'21/10/2010'
           ,'CHUQUISACA'
           ,'Español'
           ,'VARONES'
           ,'Soltero'
           ,'ESTUDIANTE'
           ,'ESTUDIANTE'
           ,'Nego'
           ,'catolico'
           ,'Chuquisaca'
           ,'HOLA')
GO

INSERT INTO [PSIQUIATRICO].[dbo].[ReIngresos]
           ([Nro_ReIngreso]
           ,[Hc]
           ,[Fecha_ReIngreso]
           ,[Unidad]
           ,[seccion]
           ,[codigo]
           ,[Otros]
           ,[Hora])
     VALUES
           (1
           ,1556
           ,GETDATE()
           ,4
           ,'Varones'
           ,'F20.5'
           ,null
           ,GETDATE())
GO



INSERT INTO [PSIQUIATRICO].[dbo].[Movimientos]
           ([Hc]
           ,[Fecha_mov]
           ,[Hora]
           ,[Estado]
           ,[Codigo]
           ,[Unidad]
           ,[Seccion]
           ,[Nros]
           ,[Tipo_Movimiento]
           ,[Denominacion])
     VALUES
           (1556
           ,GETDATE()
           ,GETDATE()
           ,'ACTIVO'
           ,'F73'
           ,4
           ,'Varones'
           ,1
           ,'Ingreso'
           ,'SAN RICARDO PAMPURI')
GO





SELECT * FROM TRABAJO_SOCIAL.DBO.Pacientes
WHERE Nombre LIKE 'LUIS ANTONIO'

SELECT * FROM ReIngresos where Hc = 1556
SELECT * FROM TRABAJO_SOCIAL.DBO.Reingresos where HClinico = 1556

select * from Movimientos

