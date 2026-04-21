using System.Diagnostics;
using CalculadoraBasica.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraBasica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var estudiante = new Estudiante(1, "Juan Perez", 95);
            return View(estudiante);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        #region Suma2
        public IActionResult Suma2()
        {
            return View();
        }
        public IActionResult add2()
        {
            int num1 = Convert.ToInt32(HttpContext.Request.Form["tx1"].ToString());
            int num2 = Convert.ToInt32(HttpContext.Request.Form["tx2"].ToString());
            int result = num1 + num2;
            ViewBag.num1 = result;
            return View("Suma2");
        }

        #endregion suma 2

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
