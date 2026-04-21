namespace APISchool.Models
{
    public class Matricula
    {
        public int NumMatricula {  get; set; }
        public string Carnet { get; set; }
        public string NombreEstudiante { get; set; }
        public string Curso { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoPago { get; set; }
        public decimal PorDescuento { get; set; }
        public decimal PrecioFinal 
        {
            get 
            {
                decimal precio = 0;
                precio = MontoPago - (MontoPago*(PorDescuento/100));
                return precio;
            }
        }
    }
}
