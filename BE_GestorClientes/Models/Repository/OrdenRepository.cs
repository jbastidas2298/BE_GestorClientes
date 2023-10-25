using Microsoft.EntityFrameworkCore;

namespace BE_GestorClientes.Models.Repository
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly DataAccessContext _dataAccessContext;
        public OrdenRepository(DataAccessContext dataAccessContext)
        {
            _dataAccessContext = dataAccessContext;
        }

        public async Task<Orden> AddOrden(Orden orden)
        {
            _dataAccessContext.Add(orden);
            await _dataAccessContext.SaveChangesAsync();
            return orden;
        }

        public async Task<List<Orden>> GetAllOrden()
        {
            return await _dataAccessContext.Orden.ToListAsync();
        }

        public async Task<Orden> GetOrdenById(int id)
        {
            return await _dataAccessContext.Orden.FindAsync(id);
        }
        public async Task<Orden> ObtenerUltimaOrden()
        {
            return await _dataAccessContext.Orden.OrderByDescending(o => o.Id).FirstOrDefaultAsync();
        }
    }
}
