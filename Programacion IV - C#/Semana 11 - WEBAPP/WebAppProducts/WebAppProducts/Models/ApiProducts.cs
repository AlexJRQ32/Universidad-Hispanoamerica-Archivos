namespace WebAppProducts.Models
{
    public class ApiProducts
    {
        public HttpClient Iniciar()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://WebAPIProductProf512.somee.com/");
            return httpClient;
        }

    }
}
