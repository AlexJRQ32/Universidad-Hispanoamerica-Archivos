using APIMotos.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Se configura el servicio del DbContext que utiliza el ORM, se envia el string de conexion
//Para lograr conectar con el servidor de bade de datos
builder.Services.AddDbContext<DbContextMoto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StringConexion")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();