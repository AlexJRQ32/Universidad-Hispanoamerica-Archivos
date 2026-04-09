namespace WebAppProducts.Models
{
    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public char Status { get; set; }
    }
}
