using System;
using System.ComponentModel.DataAnnotations;

namespace APIClinicaDentalDZ.Models
{
    public class Procedimiento
    {
        [Key]
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioActual { get; set; }
        public char PagoDolares { get; set; }
        public decimal PorImp { get; set; }
        public DateTime FechaRegistro { get; set; }
        public char Estado { get; set; }
    }
}
