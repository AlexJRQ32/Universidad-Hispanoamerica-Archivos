using System.ComponentModel.DataAnnotations;

namespace APIConcesionarioDB.Models
{
    public class Moto
    {
        [Key]
        public int IdMoto { get; set; }
        public int Placa { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public Decimal Precio { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Estado { get; set; }
        public string Propietario { get; set; }
    }
}
