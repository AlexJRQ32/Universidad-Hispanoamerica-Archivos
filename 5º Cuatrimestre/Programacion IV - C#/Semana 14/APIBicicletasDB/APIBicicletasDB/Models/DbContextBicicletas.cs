using Microsoft.EntityFrameworkCore;

namespace APIBicicletasDB.Models
{
    public class DbContextBicicletas : DbContext
    {
        public DbContextBicicletas(DbContextOptions<DbContextBicicletas> options) : base(options)
        {
            
        }

        public DbSet<Bicicleta> Bicicletas { get; set; }
    }
}
