using APIConcesionarioDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIConcesionarioDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly DbContextMotos _context = null;

        public MotosController(DbContextMotos context)
        {
            _context = context;
        }

        [HttpGet("List")]
        public List<Moto> List()
        {
            return _context.Motos.ToList();
        }

        [HttpPut("Create")]
        public string Create(Moto temp)
        {
            string msj = "";
            try
            {
                //Se almacena la moto
                _context.Motos.Add(temp);

                //Aplicar los cambios en la DB
                _context.SaveChanges();

                msj = $"Moto {temp.Modelo} almacenada correctamente";

                return msj;
            }//En caso de error se captura
            catch (Exception ex)
            {   //Se personaliza el error
                msj = $"Error {ex.InnerException.ToString()}";
                return msj;
                //Y se retorna
            }
        }

        //Metodo de modificar los datos
        [HttpPost("Update")]
        public async Task<string> Update(Moto temp)
        {
            string msj = "";
            try
            {
                if (temp != null)
                {
                    Moto moto = await _context.Motos.FirstOrDefaultAsync(x => x.Placa.Equals(temp.Placa));
                    if (moto != null)
                    {
                        moto.Placa = temp.Placa;
                        moto.Modelo = temp.Modelo;
                        moto.Anio = temp.Anio;
                        moto.Precio = temp.Precio;
                        moto.Fecha_Creacion = temp.Fecha_Creacion;
                        moto.Estado = temp.Estado;
                        moto.Propietario = temp.Propietario;
                        _context.Motos.Update(moto);

                        await _context.SaveChangesAsync();
                        return msj = $"Cambios aplicados correctamente a la moto codigo {moto.Placa}";
                    }
                    else
                    {
                        msj = $"Error la moto {temp.Modelo} no está registrada";
                    }

                }
                else
                {
                    msj = "No hay datos";
                }

                return msj;
            }
            catch (Exception ex)
            {
                return msj = $"Error {ex.InnerException.ToString()}";
            }
        }

        [HttpGet("Search")]
        public Moto Search(string placa)
        {
            Moto temp = null;
            try
            {
                temp = _context.Motos.FirstOrDefault(y => y.Placa.Equals(placa));
                return temp;
            }
            catch (Exception ex)
            {
                return temp;
            }
        }

        [HttpDelete("Delete")]
        public async Task<string> Delete(string placa)
        {
            string msj = "";
            try
            {
                Moto temp = await _context.Motos.FirstOrDefaultAsync(j => j.Placa.Equals(placa));

                if (temp != null)
                {
                    _context.Motos.Remove(temp);
                    await _context.SaveChangesAsync();
                    msj = $"Eliminada moto {temp.Modelo} correctamente..";
                }
                else
                {
                    return msj = $"No existe la moto con el código {placa}";
                }
                return msj;
            }
            catch (Exception ex)
            {
                return msj = $"Error {ex.InnerException.ToString()}";
            }
        }

        [HttpGet("SearchName")]
        public List<Moto> SearchName(string modelo)
        {
            return _context.Motos.Where(x => x.Modelo.StartsWith(modelo)).ToList();
        }
    }
}
