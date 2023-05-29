using Microsoft.EntityFrameworkCore;
using muitospramuitos.Models;

namespace muitospramuitos.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        
        public DbSet <Pais> Pais { get; set; }

        public DbSet <Filhos> Filhos { get; set; }
    }
}
