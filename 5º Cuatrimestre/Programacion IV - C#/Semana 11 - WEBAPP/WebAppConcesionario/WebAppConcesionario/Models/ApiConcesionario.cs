namespace WebAppConcesionario.Models
{
    public class ApiConcesionario
    {
        
        public HttpClient Iniciar()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://APIConcesionarioDBAlexRUH.somee.com");
            return httpClient;
        }
    }
}
