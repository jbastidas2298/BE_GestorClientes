using Microsoft.EntityFrameworkCore;

namespace BE_GestorClientes.Models
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext(DbContextOptions<DataAccessContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<ArticulosOrden> ArticulosOrden { get; set; }
    }
}
