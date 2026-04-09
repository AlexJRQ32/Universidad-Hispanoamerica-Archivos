using System.ComponentModel.DataAnnotations;

namespace APIClinicaDentalDZ.Models
{
    public class Usuario
    {
        [Key]
        public string Email { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Password { get; set; }
        public char Estado {  get; }= 'A';
    }
}
