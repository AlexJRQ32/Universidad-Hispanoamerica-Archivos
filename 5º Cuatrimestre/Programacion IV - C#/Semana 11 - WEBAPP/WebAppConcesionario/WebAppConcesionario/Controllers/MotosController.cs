using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WebAppConcesionario.Models;

namespace WebAppConcesionario.Controllers
{
    public class MotosController : Controller
    {
        private ApiConcesionario _api = null;
        private HttpClient _httpClient = null;

        public MotosController()
        {
            _api = new ApiConcesionario();
            _httpClient = _api.Iniciar();
        }
        
        public async Task<IActionResult> Index()
        {
            List<Moto> listado = new List<Moto>();

            HttpResponseMessage respuesta = await _httpClient.GetAsync("Motos/List");

            if (respuesta.IsSuccessStatusCode)
            {
                var resultado = respuesta.Content.ReadAsStringAsync().Result;

                listado = JsonConvert.DeserializeObject<List<Moto>>(resultado);
            }


            return View(listado);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Moto moto)
        {
            var agregar = _httpClient.PutAsJsonAsync<Moto>("Motos/Create", moto);

            await agregar;

            var resultado = agregar.Result;

            if (resultado.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(moto);
        }
    }
}
