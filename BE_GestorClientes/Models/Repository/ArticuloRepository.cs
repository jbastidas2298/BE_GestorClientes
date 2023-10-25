using Microsoft.EntityFrameworkCore;

namespace BE_GestorClientes.Models.Repository
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly DataAccessContext _dataAccessContext;
        public ArticuloRepository(DataAccessContext dataAccessContext)
        {
            _dataAccessContext = dataAccessContext;
        }

        public async Task<Articulo> AddArticulo(Articulo articulo)
        {
            _dataAccessContext.Add(articulo);
            await _dataAccessContext.SaveChangesAsync();
            return articulo;
        }

        public async Task<List<Articulo>> GetAllArticulo()
        {
            return await _dataAccessContext.Articulo.ToListAsync();
        }

        public async Task<Articulo> GetArticuloById(int id)
        {
            return await _dataAccessContext.Articulo.FindAsync(id);
        }
    }
}
