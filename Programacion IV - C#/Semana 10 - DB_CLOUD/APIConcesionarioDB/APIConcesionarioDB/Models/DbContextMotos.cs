using Microsoft.EntityFrameworkCore;

namespace APIConcesionarioDB.Models
{
    public class DbContextMotos : DbContext
    {
        public DbContextMotos(DbContextOptions<DbContextMotos> options) : base(options) {
        
        }

        public DbSet<Moto> Motos { get; set; }
    }
}
