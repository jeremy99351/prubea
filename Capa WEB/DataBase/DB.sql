--Cliente

Create table [dbo].[TBL_Cliente]
(
[cedula] nvarchar(15) not null primary key ,
[nombre] nvarchar(15) not null,
[apellido] nvarchar(15) not null,
[fechaNacimiento] nvarchar(10) not null,
[edad] int not null,
[estadoCivil] nvarchar(10) not null,
[genero] nvarchar(10) not null
);


--Insert en cliente
go
CREATE PROCEDURE [dbo].[CRE_CLIENTE_PR]
@p_cedula nvarchar(15),
@p_nombre nvarchar(15),
@p_apellido nvarchar(15),
@p_fechaNacimiento nvarchar(15),
@p_edad int , 
@p_estadoCivil nvarchar(10),
@p_genero nvarchar(10)

AS insert into [dbo].[TBL_Cliente] values(@p_cedula,@p_nombre,@p_apellido,@p_fechaNacimiento,@p_edad,@p_estadoCivil,@p_genero);
go





--Retrieve all cliente
go
CREATE PROCEDURE [dbo].[RET_ALL_cliente_PR]
AS SELECT cedula,nombre,apellido,fechaNacimiento,edad,estadoCivil,genero from TBL_Cliente;
go


--UPDATE CLIENTE

go 
CREATE PROCEDURE [dbo].[UPD_Cliente_PR] 
@p_cedula nvarchar(15),
@p_nombre nvarchar(15),
@p_apellido nvarchar(15),
@p_fechaNacimiento nvarchar(15),
@p_edad int , 
@p_estadoCivil nvarchar(10)

as update [dbo].[TBL_Cliente] set nombre=@p_nombre,apellido=@p_apellido,fechaNacimiento=@p_fechaNacimiento,edad=@p_edad,estadoCivil=@p_estadoCivil where cedula=@p_cedula;
go



--Buscar cliente por cedula 
go
CREATE PROCEDURE [dbo].[RET_CLIENTE_PR] 
@p_cedula nvarchar(15)
AS
SELECT cedula,nombre,apellido,fechaNacimiento,edad,estadoCivil,genero from TBL_Cliente where cedula = @p_cedula;
go

drop procedure RET_CLIENTE_PR
--Delete Cliente 
go 
CREATE PROCEDURE [dbo].[DEL_Cliente_PR]
@p_cedula nvarchar(15)
as delete from TBL_Cliente where cedula = @p_cedula;
go 


-- Cuenta

Create table [dbo].[TBL_Cuenta]
(
[id_cuenta] nvarchar(15) not null primary key ,
[nombre] nvarchar(15) not null , 
[moneda] nvarchar(15) not null,
[saldo] int not null
);

alter table [dbo].[TBL_Cuenta] add foreign key(nombre) references [dbo].[TBL_Cliente](cedula);


--Insert cuenta
go 
CREATE PROCEDURE [dbo].[CRE_CUENTA_PR]
@p_id_cuenta nvarchar(15),
@p_nombre nvarchar(15),
@p_moneda nvarchar(15),
@p_saldo int
as insert into [dbo].[TBL_Cuenta] values(@p_id_cuenta,@p_nombre,@p_moneda,@p_saldo);
go



--Retreive all cuenta
go 
CREATE PROCEDURE [dbo].[RET_ALL_CUENTA_PR]
As select id_cuenta,nombre,moneda,saldo from TBL_Cuenta;
go


--update cliente
go 
CREATE PROCEDURE [dbo].[UPD_CUENTA_PR]
@p_id_cuenta nvarchar(15),
@p_nombre nvarchar(15),
@p_moneda nvarchar(15),
@p_saldo int

as update [dbo].[TBL_Cuenta] set nombre = @p_nombre, moneda = @p_moneda , saldo = @p_saldo where id_Cuenta = @p_id_cuenta;
go 

--Buscar cuenta 

go 
CREATE PROCEDURE [dbo].[RET_CUENTA_PR]
@p_id_cuenta nvarchar(15) 
as SELECT id_cuenta,nombre,moneda,saldo from TBL_Cuenta where id_cuenta = @p_id_cuenta;
go


--Delete cuenta 
go 
CREATE PROCEDURE [dbo].[DEL_CUENTA_PR]
@p_id_cuenta nvarchar(15)
as delete from TBL_Cuenta where id_cuenta = @p_id_cuenta;
go 



--Credito

create table [dbo].[TBL_CREDITO]
(
[idCredito] nvarchar(15) not null primary key,
[monto] int not null,
[taza] int not null,
[nombre] nvarchar(15) not null,
[cuota] int not null,
[fechaInicio] nvarchar(15) not null,
[estado] nvarchar(15) not null,
[saldo] int not null

);

alter table [dbo].[TBL_CREDITO] add foreign key(nombre) references [dbo].[TBL_Cliente](cedula);



--Insert Credito

go
create procedure[dbo].[CRE_CREDITO_PR]
@p_idCredito nvarchar(15),
@p_monto int ,
@p_taza int ,
@p_nombre nvarchar(15), 
@p_cuota int, 
@p_fechaInicio nvarchar(15) ,
@p_estado nvarchar(15) ,
@p_saldo int 
as insert into [dbo].[TBL_CREDITO] values(@p_idCredito,@p_monto,@p_taza,@p_nombre,@p_cuota,@p_fechaInicio,@p_estado,@p_saldo);
go



--Retrieve All credito
go
CREATE PROCEDURE [dbo].[RET_ALL_CREDITO_PR]
AS select idCredito,monto,taza,nombre,cuota,fechaInicio,estado,saldo from TBL_CREDITO;
go



--UPDATE CREDITO
go
 CREATE PROCEDURE[dbo].[UPD_CREDITO_PR]
@p_idCredito nvarchar(15),
@p_monto int ,
@p_taza int ,
@p_cuota int, 
@p_fechaInicio nvarchar(15) ,
@p_estado nvarchar(15) ,
@p_saldo int 
AS update [dbo].[TBL_CREDITO] set monto = @p_monto,taza = @p_taza, 
 cuota = @p_cuota, fechaInicio = @p_fechaInicio,estado = @p_estado,saldo = @p_saldo 
where idCredito = @p_idCredito ;
go



--DELETE CREDITO 
go
CREATE PROCEDURE[dbo].[DEL_CREDITO_PR]
@p_idCredito nvarchar(15)
as delete from TBL_CREDITO where idCredito = @p_idCredito;
go



--BUSCAR CREDITO 
go
CREATE PROCEDURE[dbo].[RET_CREDITO_PR]
@p_idCredito nvarchar(15)
AS select idCredito,monto,taza,nombre,cuota,fechaInicio,estado,saldo from TBL_CREDITO where idCredito = @p_idCredito;
go

drop procedure RET_CREDITO_PR;

--Direccion
create table [dbo].[TBL_Direccion]
(
[PROVINCIA] nvarchar(15) not null primary key,
[CANTON] nvarchar(15) not null,
[DISTRITO] nvarchar(15) not null,
[NOMBRE] nvarchar(15) not null
);

alter table [dbo].[TBL_Direccion] add foreign key(NOMBRE) references [dbo].[TBL_Cliente](cedula);

--insert direccion
go
create procedure[dbo].[CRE_DIRECCIONES_PR]
@p_PROVINCIA nvarchar(15),
@p_CANTON nvarchar(15),
@p_DISTRITO nvarchar(15),
@p_NOMBRE nvarchar(15)

as insert into [dbo].[TBL_Direccion] values(@p_PROVINCIA,@p_CANTON ,@p_DISTRITO,@p_NOMBRE);
go

--Retrieve all Direccion
go
CREATE PROCEDURE[dbo].[RET_ALL_DIRECCIONES_PR]
as select PROVINCIA,CANTON,DISTRITO,NOMBRE from TBL_Direccion;
go

--Update direccion
go 
CREATE PROCEDURE[dbo].[UPD_DIRECCIONES_PR]
@p_PROVINCIA nvarchar(15),
@p_CANTON nvarchar(15),
@p_DISTRITO nvarchar(15)
as update [dbo].[TBL_Direccion] set CANTON = @p_CANTON, DISTRITO = @p_DISTRITO where PROVINCIA = @p_PROVINCIA;
go

--DELETE Direccion 
go
CREATE PROCEDURE[dbo].[DEL_DIRECCIONES_PR]
@p_PROVINCIA nvarchar(15)
as delete from TBL_Direccion where PROVINCIA = @p_PROVINCIA;
go

--BUSCAR DIRECCION 
go
CREATE PROCEDURE [dbo].[RET_DIRECCIONES_PR]
@p_PROVINCIA nvarchar(15)
as select PROVINCIA,CANTON,DISTRITO,NOMBRE from TBL_Direccion where PROVINCIA = @p_PROVINCIA;
go



--Localizaciones 

Create table [dbo].[TBL_LOCALIZACION] 
(
[idLocalizacion] nvarchar(10) primary key not null,
[cedula] nvarchar(15)not null,
[tipoL] nvarchar(10) not null,
[valor] nvarchar(30) not null 
)
alter table [dbo].[TBL_LOCALIZACION] add foreign key (cedula) references [dbo].[TBL_Cliente](cedula);

--Insert Localizacion

go 
create procedure [dbo].[CRE_LOCALIZACION_PR]
@P_idLocalizacion nvarchar(10) ,
@P_cedula nvarchar(15),
@P_tipoL nvarchar(10) ,
@P_valor nvarchar(30) 
as insert into [dbo].[TBL_LOCALIZACION] values (@P_idLocalizacion,@P_cedula,@P_tipoL,@P_valor);
go
 
--Retrieve all Localizacíón 
go 
create procedure [dbo].[RET_ALL_LOCALIZACION_PR]
as select idLocalizacion,cedula,tipoL,valor from TBL_LOCALIZACION ;
go


--Update Localizacion
go 
create procedure [dbo].[UPD_LOCALIZACION_PR]
@P_cedula nvarchar(15),
@P_tipoL nvarchar(10) ,
@P_valor nvarchar(30) 
as update [dbo].[TBL_LOCALIZACION] set tipoL = @P_tipoL, valor = @P_valor where cedula = @P_cedula;
go

--DELETE LOCALIZACION 
go 
create procedure[dbo.[DEL_LOCALIZACION_PR]
@P_cedula nvarchar(15)
as delete from TBL_LOCALIZACION where cedula = @P_cedula;
go 

--Retrieve by id 
go 
create procedure [dbo].[RET_LOCALIZACION_PR]
@P_cedula nvarchar(15)
as select idLocalizacion,cedula,tipoL,valor from TBL_LOCALIZACION where cedula = @P_cedula;
go

