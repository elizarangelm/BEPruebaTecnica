using BEPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace BEPruebaTecnica
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Usuarios> Usuarios
        {
            get; set; 
        }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}
