using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIBicicletasDB.Models
{
    public class Bicicleta
    {
        [Key]
        public int ID { get; set; }
        public string Modelo { get; set; }
        public int Annio { get; set; }
        public decimal PrecioVenta { get; set; }
        public char Categoria  { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaRegistro { get; set; }
        public char Estado { get; set; }
        public string? Foto { get; set; }
        public string EmailMiembro { get; set; }
    }
}
