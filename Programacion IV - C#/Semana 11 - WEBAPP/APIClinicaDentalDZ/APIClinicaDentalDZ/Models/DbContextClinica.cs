using Microsoft.EntityFrameworkCore;

namespace APIClinicaDentalDZ.Models
{
    public class DbContextClinica : DbContext
    {
        public DbContextClinica(DbContextOptions<DbContextClinica> options) : base(options)
        {
        }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Procedimiento> Procedimientos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
