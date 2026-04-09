--Script para construir base de datos
--1. Seleccionar la base de datos master
use[master]
go

--2. Revisar si existe base de datos
if exists(select name from dbo.sysdatabases where name= 'DbProducts')
drop database [DbProducts] --Borrar base de datos
go

--3. Crear base de datos
Create database DbProducts
go

--4. Seleccionar base de datos
use [DbProducts]
go

--Sintaxis para crear un table
-- 1. Verificar si existe la tabla
if exists(select name from dbo.sysobjects where name = 'Products')
drop table [Products]
go

--2. Crear la tabla de la base de datos
create table [Products](
	Code varchar(30) primary key not null,
	Name varchar(150) not null,
	Price decimal(12,2) not null,
	amount decimal(12,2) not null,
	tax decimal(12,2) not null,
	CreateDate datetime not null default getdate(),
	Status char not null default 'A'
)
go

--Sintaxis para almacenar datos DML
insert into [Products] (Code,Name,Price,amount,tax)
values('4453', 'Arroz', 3500, 42, 13)
go

insert into [Products] (Code,Name,Price,amount,tax)
values('4454', 'Atun', 1500, 8, 13)
go

--Sintaxis para consultar los datos
select * from [Products]
go

--Sintaxis para consultar un dato especifico
--utilizando un where
select Code, Name, Price 
from [Products]
where Code = '4453'
go