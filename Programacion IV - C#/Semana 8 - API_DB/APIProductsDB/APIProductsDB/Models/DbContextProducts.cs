//Referencia la libreria del ORM
using Microsoft.EntityFrameworkCore;

namespace APIProductsDB.Models
{
    //Heredar del ORM
    public class DbContextProducts : DbContext
    {
        //Constructor con parametros
        //Usa el constructor de la clase padre y recibe una instancia de la clase
        public DbContextProducts(DbContextOptions<DbContextProducts> options) : base(options) 
        {
            
        }
        //Propiedad para usar el table Products, hace referencia exclusiva con la tabla
        public DbSet<Product> Products { get; set; }




    }//Cierre clase
}//Cierre namespace
