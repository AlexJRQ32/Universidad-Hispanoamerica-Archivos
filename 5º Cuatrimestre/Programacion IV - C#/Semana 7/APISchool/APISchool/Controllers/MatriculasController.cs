using Microsoft.AspNetCore.Mvc;
using APISchool.Models;

namespace APISchool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatriculasController : ControllerBase
    {
        private static List<Matricula> lista = null;
        public MatriculasController()
        {
            if(lista == null)
            {
                lista = new List<Matricula>();
                LlenarLista();
            }
        }

        private void LlenarLista()
        {
            lista.Add(new Matricula
            {
                NumMatricula = 1,
                Carnet = "22480",
                NombreEstudiante = "Alex Roblero",
                Curso = "Programacion IV",
                FechaPago = DateTime.Now,
                MontoPago = 129000,
                PorDescuento = 40
            });
        }

        [HttpGet]
        [Route("List")]
        public List<Matricula> List()
        {
            return lista;
        }

        [HttpPut]
        [Route("Save")]
        public string Save(Matricula m)
        {
            string msj = "Matricula Guardada..";

            if(m == null)
            {
                msj = "No se ingreso nada para ingresar";
            }
            else
            {
                lista.Add(m);
            }
            return msj;
        }

        [HttpDelete]
        [Route("Delete")]
        public string Delete(int num)
        {
            string msj = "Matricula eliminada..";

            Matricula temp = lista.FirstOrDefault(x => x.NumMatricula == num);

            if(temp == null)
            {
                msj = "Este numero de matricula no existe";
            }
            else
            {
                lista.Remove(temp);
            }
            return msj;
        }

        [HttpPost]
        [Route("Update")]
        public string Update(Matricula m)
        {
            string msj = "Matricula Actualizada Correctamente..";

            Matricula temp = lista.FirstOrDefault(x => x.NumMatricula == m.NumMatricula);

            if(temp == null)
            {
                msj = "Este numero de matricula no existe";
            }
            else
            {
                lista.Remove(temp);
                lista.Add(m);
            }
            return msj;
        }

        [HttpGet]
        [Route("Search")]
        public Matricula Search(int num)
        {
            return lista.FirstOrDefault(x => x.NumMatricula == num);
        }
    }
}
