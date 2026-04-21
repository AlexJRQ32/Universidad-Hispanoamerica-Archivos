using Microsoft.AspNetCore.Mvc;
using APIProductsDB.Models;

namespace APIProductsDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DbContextProducts _context = null;

        //Constructor
        public ProductsController(DbContextProducts context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();//Se envia la lista
        }
    }
}
