Create database DbConcesionario
go

Create table Motos(
	IdMoto int primary key not null,
	Placa int not null,
	Modelo varchar(50) not null,
	Anio int not null,
	Precio decimal(10,2) not null,
	Fecha_Creacion datetime not null,
	Estado varchar(10) not null,
	Propietario varchar(50) not null
)
go