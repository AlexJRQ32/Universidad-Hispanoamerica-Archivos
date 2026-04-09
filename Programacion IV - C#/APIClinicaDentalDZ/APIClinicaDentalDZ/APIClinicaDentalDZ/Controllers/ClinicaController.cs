using System.Globalization;
using APIClinicaDentalDZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;


[Route("[controller]")]
[ApiController]
public class ClinicaController : ControllerBase
{
    private readonly DbContextClinica _context = null;

    public ClinicaController(DbContextClinica context)
    {
        _context = context;
    }

    // GET api/clinica/procedimientos
    [HttpGet("ListaProcedimientos")]
    public List<Procedimiento> ListaProcedimientos()
    {
        return _context.Procedimientos.ToList();
    }

    // Get Para la lista de Citas Registradas
    [HttpGet("ListaCitas")]
    public List<Cita> ListaCitas()
    {
        return _context.Citas.ToList();
    }

    [HttpPut("ReservarCita")]
    public async Task<string> ReservarCita(Cita cita)
    {
        string msj = "";

        try
        {
            var procedimiento = _context.Procedimientos.FirstOrDefault(p => p.ID == cita.IDProcedimiento);
            if (procedimiento == null)
            {
                return msj = "El procedimiento no existe";
            }

            decimal tipoCambio = await ObtenerTipoCambioVenta();
            cita.MontoTotal = procedimiento.PrecioActual * tipoCambio ;



            _context.Citas.Add(cita);

            _context.SaveChanges();

            msj = $"La cita de la fecha {cita.FechaHora} ha sido reservada...";

            return msj;
        }
        catch (Exception ex)
        {           
            return msj = $"Error {ex.InnerException.ToString()}";
        }
    }

    [HttpDelete("CancelarCita")]
    public async Task<string> CancelarCita(int id)
    {
        string msj = "";
        try
        {
            Cita temp = await _context.Citas.FirstOrDefaultAsync(c => c.ID.Equals(id));

            if (temp != null)
            {
                _context.Citas.Remove(temp);
                await _context.SaveChangesAsync();
                msj = $"La cita de la fecha {temp.FechaHora} ha sido cancelada..";
            }
            else
            {
                return msj = $"No existe la cita con codigo {id}";
            }
            return msj;
        }
        catch (Exception ex)
        {
            return msj = $"Error {ex.InnerException.ToString()}";
        }
    }

    [HttpGet("ConsultarCita")]
    public Cita ConsultarCita(int id)
    {
        Cita cita = null;
        try
        {
            cita = _context.Citas.FirstOrDefault(c => c.ID.Equals(id));
            return cita;
        }
        catch (Exception ex)
        {
            return cita;
        }
    }

    [HttpPost("EditarCita")]
    public async Task<string> EditarCita(Cita cita)
    {
        string msj = "";
        try
        {
            if(cita != null)
            {
                var procedimiento = _context.Procedimientos.FirstOrDefault(p => p.ID == cita.IDProcedimiento);
                if (procedimiento == null)
                {
                    return msj = "El procedimiento no existe";
                }

                Cita temp = await _context.Citas.FirstOrDefaultAsync(c => c.ID.Equals(cita.ID));
                if (temp != null)
                {
                    temp.ID = cita.ID;
                    temp.IDProcedimiento = cita.IDProcedimiento;
                    temp.Email = cita.Email;
                    temp.FechaHora = cita.FechaHora;
                    temp.MontoTotal = procedimiento.PrecioActual;
                    _context.Citas.Update(temp);

                    await _context.SaveChangesAsync();
                    return msj = $"Cambios en la cita de la fecha {cita.FechaHora} aplicados correctamente..";
                }
                else
                {
                    msj = $"Error la cita numero {cita.ID} no existe..";
                }
            }
            else
            {
                msj = "No hay datos..";
            }
            return msj;
        }
        catch(Exception ex)
        {
            return msj = $"Error {ex.InnerException.ToString()}";
        }
    }

    private async Task<decimal> ObtenerTipoCambioVenta()
    {
        try
        {
            using var http = new HttpClient();
            var response = await http.GetFromJsonAsync<TipoCambioGometa>("http://apis.gometa.org/tdc/tdc.json");
            return decimal.Parse(response?.monedas?.usd?.venta ?? "540.00", CultureInfo.InvariantCulture);
        }
        catch
        {
            return 540.00M;
        }
    }

    [HttpPut("RegistrarUsuario")]
    public string RegistrarUsuario(Usuario usuario)
    {
        string msj = "";
        try
        {
            _context.Usuarios.Add(usuario);

            _context.SaveChanges();

            return msj = $"El Usuario {usuario.NombreCompleto} ha sido registrado existosamente..";
        }
        catch (Exception ex)
        {
            return msj = $"Error {ex.InnerException.ToString()}";
        }
    }

    [HttpGet("ValidarUsuario")]
    public List<Usuario> ValidarUsuario(string email, string pw)
    {
        return _context.Usuarios.Where(x => x.Email == email && x.Password == pw).ToList();
    }

}

public class TipoCambioGometa
{
    public Monedas monedas { get; set; }
}

public class Monedas
{
    public USD usd { get; set; }
}

public class USD
{
    public string compra { get; set; }
    public string venta { get; set; }
}

