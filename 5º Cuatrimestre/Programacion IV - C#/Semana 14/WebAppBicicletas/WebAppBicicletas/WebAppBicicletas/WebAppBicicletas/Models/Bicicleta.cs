namespace WebAppBicicletas.Models
{
    public class Bicicleta
    {
        public int id { get; }
        public string Modelo { get; set; }
        public int Annio { get; set; }
        public decimal PrecioVenta { get; set; }
        public char Categoria { get; set; }
        public DateTime FechaCompra {  get; set; }
        public DateTime FechaRegistro { get; set; }
        public char Estado { get; set; }
        public string Foto { get; set; }
        public string EmailMiembro { get; set; }
    }
}
