using System.Net.Http;

namespace WebAppBicicletas.Models
{
    public class ApiBicicletas
    {
        public HttpClient Iniciar()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://APIBici-Proyect-uh2025.somee.com/");
            return httpClient;
        }
    }
}
