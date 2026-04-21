using Microsoft.AspNetCore.Mvc;

using APIParqueo.Models;
using System.Security.AccessControl;

namespace APIParqueo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParqueoController : Controller
    {
        private static List<Parqueo> lista = null;

        public ParqueoController()
        {
            if (lista == null)
            {
                lista = new List<Parqueo>();
                LlenarLista();
            }
        }
        private void LlenarLista()
        {
            lista.Add(new Parqueo
            {
                NumEspacio = 1,
                TipoVehiculo = "Automovil",
                Placa = "BCM-582",
                NombreCompleto = "Alex Joan Roblero Quiros",
                Email = "example@gmail.com",
                FechaHora = DateTime.Now,
                CantidadHoras = 4
            });

            lista.Add(new Parqueo
            {
                NumEspacio = 2,
                TipoVehiculo = "Motocicleta",
                Placa = "783523",
                NombreCompleto = "Nexis Garcia Huete",
                Email = "example@gmail.com",
                FechaHora = DateTime.Now,
                CantidadHoras = 7
            });
        }

        [HttpGet]
        [Route("Lista")]
        public List<Parqueo> List()
        {
            return lista;
        }

        [HttpPut]
        [Route("ReservaEspacio")]
        public string ReservaEspacio(Parqueo p)
        {
            string msj = "Reserva realizada con exito";

            if(p ==  null)
            {
                msj = "Proporcione la informacion pedida";
            }
            else
            {

                lista.Add(p);

                msj += $". Total a pagar: {p.PagoFinal}";
            }
            return msj;
        }

        [HttpDelete]
        [Route("EliminarReserva")]
        public string EliminarReserva(int num)
        {
            string msj = "Reserva eliminada con exito";

            Parqueo temp = lista.FirstOrDefault(x => x.NumEspacio == num);

            if (temp == null)
            {
                msj = "Este numero de espacio no esta registrado";
            }
            else
            {
                lista.Remove(temp);
            }
            return msj;
        }

        [HttpGet]
        [Route("BuscarReserva")]
        public Parqueo BuscarReserva(int num)
        {
            return lista.FirstOrDefault(x => x.NumEspacio == num);
        }


        [HttpPost]
        [Route("EditarReserva")]
        public string EditarReserva(Parqueo p)
        {
            string msj = "Reserva editada con exito";

            Parqueo temp = lista.FirstOrDefault(x => x.NumEspacio == p.NumEspacio);
            if (temp == null)
            {
                msj = "Este numero de espacio no esta registrado";
            }
            else
            {
                lista.Remove(temp);
                lista.Add(p);
            }
            return msj;
        }
    }
}
