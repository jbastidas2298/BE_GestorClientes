namespace BE_GestorClientes.Models.Repository
{
    public interface IOrdenRepository
    {
        Task<List<Orden>> GetAllOrden();
        Task<Orden> GetOrdenById(int id);
        Task<Orden> AddOrden(Orden orden);
        Task<Orden> ObtenerUltimaOrden();
    }
}
