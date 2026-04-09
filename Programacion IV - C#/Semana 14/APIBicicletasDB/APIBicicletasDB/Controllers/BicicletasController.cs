using Microsoft.AspNetCore.Mvc;
using APIBicicletasDB.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBicicletasDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BicicletasController : ControllerBase
    {
        private readonly DbContextBicicletas _context = null;

        public BicicletasController(DbContextBicicletas context)
        {
            _context = context;
        }

        [HttpGet("List")]
        public List<Bicicleta> List()
        {
            return _context.Bicicletas.ToList();
        }

        
        [HttpPut("CrearBici")]
        public string CrearBici(Bicicleta temp)
        {
            string msj = "";
            try
            {

                _context.Bicicletas.Add(temp);

                
                _context.SaveChanges();

                msj = $"Bicicleta {temp.Modelo} creada correctamente...";
                return msj;
            }
            catch (Exception ex)
            {
                msj = $"Error {ex.InnerException?.ToString() ?? ex.Message}";
                return msj;
            }
        }

        [HttpPost("ModificarBici")]
        public async Task<string> ModificarBici(Bicicleta temp)
        {
            string msj = "";
            try
            {
                if (temp != null)
                {
                    Bicicleta bicicleta = await _context.Bicicletas.FirstOrDefaultAsync(x => x.ID.Equals(temp.ID));

                    if (bicicleta != null)
                    {
                        bicicleta.Modelo = temp.Modelo;
                        bicicleta.Annio = temp.Annio;
                        bicicleta.PrecioVenta = temp.PrecioVenta;
                        bicicleta.Categoria = temp.Categoria;
                        bicicleta.FechaCompra = temp.FechaCompra;
                        bicicleta.FechaRegistro = temp.FechaRegistro;
                        bicicleta.Estado = temp.Estado;
                        bicicleta.EmailMiembro = temp.EmailMiembro;
                       
                        await _context.SaveChangesAsync();

                        return msj = $"Cambios aplicados coreectamente a la bicicleta con id {bicicleta.ID}";
                    }
                    else
                    {
                        msj = $"Error, la bicicleta con {temp.ID} no está registrada";
                    }
                    
                }
                else
                {
                    msj = "No hay datos de la bicicleta..";
                }

                return msj;
            }
            catch (Exception ex)
            {

                return msj =$"Error {ex.InnerException.ToString()}" ;
            }
        }

        [HttpGet("BuscarBici")]
        public Bicicleta BuscarBici(int id)
        {
            Bicicleta temp = null;
            try
            {
                temp = _context.Bicicletas.FirstOrDefault(y => y.ID.Equals(id));
                return temp;
            }
            catch (Exception ex)
            {
                return temp;
            }
        }

        [HttpDelete("EliminarBici")]
        public async Task<string> Delete(int id)
        {
            string msj = "";
            try
            {
                Bicicleta temp = await _context.Bicicletas.FirstOrDefaultAsync(j => j.ID == id);

                if (temp != null)
                {
                    _context.Bicicletas.Remove(temp);
                    await _context.SaveChangesAsync();

                    msj = $"Eliminada, la Bicicleta {temp.ID} correctamente...";

                    return msj;
                }
                else
                {
                    return msj = $"No existe la Bicicleta con el ID {id}";
                }
                
            }
            catch (Exception ex)
            {
                return $"Error: {ex.InnerException.ToString()}";
            }
        }
    }    
}
