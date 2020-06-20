using Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace Framework.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {                
        }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<TipoIdentificacion> TiposIdentificacion { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<SubArea> SubAreas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
