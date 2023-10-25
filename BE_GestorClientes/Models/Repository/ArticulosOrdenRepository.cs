namespace BE_GestorClientes.Models.Repository
{
    public class ArticulosOrdenRepository : IArticulosOrdenRepository
    {
        private readonly DataAccessContext _dataAccessContext;
        public ArticulosOrdenRepository(DataAccessContext dataAccessContext)
        {
            _dataAccessContext = dataAccessContext;
        }

        public async Task<ArticulosOrden> AddArticuloOrden(ArticulosOrden articulosOrden)
        {
            _dataAccessContext.Add(articulosOrden);
            await _dataAccessContext.SaveChangesAsync();
            return articulosOrden;
        }
    }
}
