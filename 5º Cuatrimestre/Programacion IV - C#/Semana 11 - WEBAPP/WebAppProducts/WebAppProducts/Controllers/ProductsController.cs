using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WebAppProducts.Models;

namespace WebAppProducts.Controllers
{
    public class ProductsController : Controller
    {
        private ApiProducts _api = null;
        private HttpClient _httpClient = null;

        /// <summary>
        /// Constructor por omision
        /// </summary>
        public ProductsController()
        {
            //Se instancia la API
            _api = new ApiProducts();

            //Se inicia el consumo
            _httpClient = _api.Iniciar();
        }

        /// <summary>
        /// Metodo encargado de mostrar el listado de productos
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            //Variable tipo lista productos
            List<Product> listado = new List<Product>();

            //Consumo del API Web se usa el metodo list
            HttpResponseMessage respuesta = await _httpClient.GetAsync("Products/List");

            //Se valida si el consumo fue correcto
            if (respuesta.IsSuccessStatusCode)
            {
                //Se realiza la lectura de la informacion en formato JSON
                var resultado = respuesta.Content.ReadAsStringAsync().Result;

                //Se convierte la informacion JSON en una lista de objetos tipo products
                listado = JsonConvert.DeserializeObject<List<Product>>(resultado);
            }
            return View(listado);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            //Se consume el metodo agregar sdemas se envia como parametro el objeto producto
            //para su almacenamiento
            var agregar = _httpClient.PutAsJsonAsync<Product>("Products/Save", product);

            //Se espera a que finalice
            await agregar;

            //Se almacena el resultado de a API
            var resultado= agregar.Result;

            //Se valida si la transaccion fue exitosa
            if (resultado.IsSuccessStatusCode)
            {
                //Se ubica el usuario dentro del listado productos
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            //Variable objeto para almacenar los datos del producto a eliminar
            Product temp = new Product();

            //Consultar producto usando la API Web
            HttpResponseMessage search = await _httpClient.GetAsync($"Products/Search?Code={id}");

            //Se pregunta si la respuesta es correcta
            if (search.IsSuccessStatusCode)
            {
                //Se realiza la lectura en formato JSON
                var resultado = search.Content.ReadAsStringAsync().Result;

                //Los datos se convierte en un objeto producto
                temp = JsonConvert.DeserializeObject<Product>(resultado);
            }

            //Se envian los datos del producto al Front-end
            return View(temp);
        }

        [HttpPost(Name = "Delete")]
        public async Task<IActionResult> Deleted(string id)
        {
            // Se usa el metodo eliminar se envia el ID como parametro
            HttpResponseMessage delete = await _httpClient.DeleteAsync($"Products/Delete?Code={id}");

            if (delete.IsSuccessStatusCode)
            {
                //Se ubica el usuario dentro del listado de productos
                return RedirectToAction("Index");
            }
            else
            {
                //Se muestra un mensaje de error
                return NoContent();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            //Variable para almacenar la informacion del producto
            Product temp = new Product();

            //Se busca el producto por medio de la API
            HttpResponseMessage search = await _httpClient.GetAsync($"Products/Search?Code={id}");

            
            if (search.IsSuccessStatusCode)
            {
                //Se realiza la lectura de la informacion en formato JSON
                var result = search.Content.ReadAsStringAsync().Result;

                //Se convierte el JSON en un objeto producto
                temp = JsonConvert.DeserializeObject<Product>(result);
            }
            return View(temp);
        }

        //Metodo Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            //Variable para almacenar la informacion del producto
            Product temp = new Product();

            //Se busca el producto por medio de la API
            HttpResponseMessage http = await _httpClient.GetAsync($"Products/Search?Code={id}");


            if (http.IsSuccessStatusCode)
            {
                //Se realiza la lectura de la informacion en formato JSON
                var result = http.Content.ReadAsStringAsync().Result;

                //Se convierte el JSON en un objeto producto
                temp = JsonConvert.DeserializeObject<Product>(result);
            }
            return View(temp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind]Product temp)
        {
            //Se consume la API utilizando el metodo Update
            HttpResponseMessage http = await _httpClient.PostAsJsonAsync<Product>("Products/Update", temp);
            if (http.IsSuccessStatusCode)
            {
                //Se muestra el listado de products
                return RedirectToAction("Index");
            }
            //En caso de error se muestra la informacion del producto
            return View(temp);
        }


    }//Cierre contrller
}//Cierre Namespace
