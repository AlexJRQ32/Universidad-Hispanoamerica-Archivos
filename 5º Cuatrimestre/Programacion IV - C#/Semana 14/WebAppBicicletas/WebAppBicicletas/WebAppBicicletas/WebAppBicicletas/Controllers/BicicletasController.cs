using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using WebAppBicicletas.Models;

namespace WebAppBicicletas.Controllers
{
    public class BicicletasController : Controller
    {
        private ApiBicicletas _api = null;
        private HttpClient _httpClient = null;

        public BicicletasController()
        {
            _api = new ApiBicicletas();
            _httpClient = _api.Iniciar();

        }

        //Listado de las bicicletas
        public async Task<IActionResult> Index()
        {
            List<Bicicleta> listado = new List<Bicicleta>();

            HttpResponseMessage respuesta = await _httpClient.GetAsync("Bicicletas/List");

            if (respuesta.IsSuccessStatusCode)
            {
                var json = await respuesta.Content.ReadAsStringAsync();
                listado = JsonConvert.DeserializeObject<List<Bicicleta>>(json);

            }

            return View(listado);
        }

        [HttpGet]
        public IActionResult CrearBici()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearBici(Bicicleta bicicleta)
        {
            var agregar = _httpClient.PutAsJsonAsync<Bicicleta>("Bicicletas/CrearBici", bicicleta);

            await agregar;

            var resultado = agregar.Result;

            if (resultado.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(bicicleta);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ModificarBici(int id)

        {
            Bicicleta temp = new Bicicleta();
            HttpResponseMessage search = await _httpClient.GetAsync($"Bicicletas/BuscarBici?id={id}");
            if (search.IsSuccessStatusCode)
            {
                var result = search.Content.ReadAsStringAsync().Result;

                temp = JsonConvert.DeserializeObject<Bicicleta>(result);
            }
            return View(temp);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarBici([Bind]Bicicleta temp)
        {
            HttpResponseMessage http = await _httpClient.PostAsJsonAsync<Bicicleta>("Bicicletas/ModificarBici", temp);
            if (http.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(temp);
            }

            
        }

        [HttpGet]
        public async Task<IActionResult> EliminarBici(string id)
        {
            Bicicleta temp = new Bicicleta();

            HttpResponseMessage search = await _httpClient.GetAsync($"Bicicletas/BuscarBici?id={id}");

            if (search.IsSuccessStatusCode)
            {
                var resultado = search.Content.ReadAsStringAsync().Result;


                temp = JsonConvert.DeserializeObject<Bicicleta>(resultado);
            }

            return View(temp);
        }

        [HttpPost(Name = "EliminarBici")]
        public async Task<IActionResult> EliminadaBici(string id)
        {
            HttpResponseMessage delete = await _httpClient.DeleteAsync($"Bicicletas/EliminarBici?id={id}");
            if (delete.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarBici(string id)
        {
            Bicicleta temp = new Bicicleta();

            HttpResponseMessage search = await _httpClient.GetAsync($"Bicicletas/BuscarBici?id={id}");

            if (search.IsSuccessStatusCode)
            {
                var result = search.Content.ReadAsStringAsync().Result;

                temp = JsonConvert.DeserializeObject<Bicicleta>(result);
            }
            return View(temp) ;
        }
    }
}
