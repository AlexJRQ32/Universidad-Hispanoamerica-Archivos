using Microsoft.AspNetCore.Mvc;
using APIMotos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMotos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly DbContextMoto _context;

        public MotosController(DbContextMoto context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public List<Motos> Listar()
        {
            return [.. _context.Motos];
        }

        [HttpPut("Crear")]
        public string Crear(Motos moto)
        {
            try
            {
                _context.Motos.Add(moto);
                _context.SaveChanges();
                return $"Moto {moto.Placa} registrada correctamente";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.InnerException?.Message}";
            }
        }

        [HttpPost("Actualizar")]
        public async Task<string> Actualizar(Motos moto)
        {
            try
            {
                var temp = await _context.Motos.FirstOrDefaultAsync(m => m.Placa == moto.Placa);
                if (temp != null)
                {
                    temp.Modelo = moto.Modelo;
                    temp.Año = moto.Año;
                    temp.Precio = moto.Precio;
                    temp.FechaCreacion = moto.FechaCreacion;
                    temp.Estado = moto.Estado;
                    temp.Propietario = moto.Propietario;

                    _context.Motos.Update(temp);
                    await _context.SaveChangesAsync();

                    return $"Moto {temp.Placa} actualizada correctamente";
                }
                return $"No se encontró la moto con placa {moto.Placa}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.InnerException?.Message}";
            }
        }

        [HttpGet("Buscar")]
        public Motos Buscar(string placa)
        {
            return _context.Motos.FirstOrDefault(m => m.Placa == placa);
        }

        [HttpDelete("Eliminar")]
        public async Task<string> Eliminar(string placa)
        {
            try
            {
                var moto = await _context.Motos.FirstOrDefaultAsync(m => m.Placa == placa);
                if (moto != null)
                {
                    _context.Motos.Remove(moto);
                    await _context.SaveChangesAsync();
                    return $"Moto {placa} eliminada correctamente";
                }
                return $"No existe una moto con placa {placa}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.InnerException?.Message}";
            }
        }

        [HttpGet("BuscarPorPropietario")]
        public List<Motos> BuscarPorPropietario(string propietario)
        {
            return _context.Motos.Where(m => m.Propietario.StartsWith(propietario)).ToList();
        }
    }
}
