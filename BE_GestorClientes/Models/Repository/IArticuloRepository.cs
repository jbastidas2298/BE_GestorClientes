namespace BE_GestorClientes.Models.Repository
{
    public interface IArticuloRepository
    {
        Task<List<Articulo>> GetAllArticulo();
        Task<Articulo> GetArticuloById(int id);
        Task<Articulo> AddArticulo(Articulo articulo);

    }
}
