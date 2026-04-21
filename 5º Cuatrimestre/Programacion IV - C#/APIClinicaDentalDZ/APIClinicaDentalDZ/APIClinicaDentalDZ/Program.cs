using APIClinicaDentalDZ.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar el servicio de DbContext usando la cadena de conexión
builder.Services.AddDbContext<DbContextClinica>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StringCloud"))
);

// Agregar controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
