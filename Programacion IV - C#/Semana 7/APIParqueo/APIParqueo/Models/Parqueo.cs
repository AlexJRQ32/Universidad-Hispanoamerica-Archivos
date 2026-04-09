namespace APIParqueo.Models
{
    public class Parqueo
    {
        public int NumEspacio { get; set; }
        private string _tipoVehiculo;
        public string TipoVehiculo 
        { 
            get => _tipoVehiculo;
            set
            {
                _tipoVehiculo = value;
                _montoPago = value.ToLower() == "automovil" ? 5000 : 3000;
            }
        }
        public string Placa { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal CantidadHoras { get; set; }
        private decimal _montoPago;
        public decimal MontoPagoHora 
        { 
            get => _montoPago;
        }
        public decimal PagoFinal 
        {
            get
            {
                decimal precio = 0;
                precio = MontoPagoHora * CantidadHoras;
                return precio;
            }
        }
    }
}
