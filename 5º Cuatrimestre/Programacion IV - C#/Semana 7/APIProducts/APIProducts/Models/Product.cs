namespace APIProducts.Models
{
    public class Product
    {
        public int Code { get; set; }

        public string Descrip { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal Quantity { get; set; }

        public decimal Tax { get; set; }

        public DateTime CreateDate { get; set; }

        public char Status { get; set; }

        //Método encargado de calcular el precio de venta
        public decimal SalePrice
        {
            get
            {
                decimal price = 0;
                price = PurchasePrice +  ( PurchasePrice * (Tax / 100) );
                return price;
            }
        }

    } //cierre class
} //cierre namespaces
