using System.ComponentModel.DataAnnotations;

namespace APIMotos.Models
{
    public class Motos
    {
        [Key]
        public string Placa { get; set; }

        public string Modelo { get; set; }

        public int Año { get; set; }

        public decimal Precio { get; set; }

        public DateTime FechaCreacion { get; set; }

        public char Estado { get; set; }

        public string Propietario { get; set; }
    }
}
