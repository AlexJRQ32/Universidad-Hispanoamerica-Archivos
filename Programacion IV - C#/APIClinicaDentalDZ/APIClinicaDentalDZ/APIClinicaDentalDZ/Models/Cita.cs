using System.ComponentModel.DataAnnotations;

namespace APIClinicaDentalDZ.Models
{
    public class Cita
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public DateTime FechaHora { get; set; }
        public int IDProcedimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal MontoTotal { get; set; }
        public char Estado { get; } = 'A';

    }
}
