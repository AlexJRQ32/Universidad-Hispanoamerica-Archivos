using System.ComponentModel.DataAnnotations;

namespace APIProductsDB.Models
{
    public class Product
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public Decimal amount { get; set; }
        public Decimal Tax { get; set; }
        public DateTime CreateDate { get; set; }
        public char Status { get; set; }
    }
}
