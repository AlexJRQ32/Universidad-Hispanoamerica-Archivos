using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APIMotos.Models
{
    public class DbContextMoto : DbContext
    {
        public DbContextMoto(DbContextOptions<DbContextMoto> options) : base(options) { }

        public DbSet<Motos> Motos { get; set; }
    }
}
