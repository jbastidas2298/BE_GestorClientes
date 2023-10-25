namespace BE_GestorClientes.Models.Repository
{
    public interface IArticulosOrdenRepository
    {
        Task<ArticulosOrden> AddArticuloOrden(ArticulosOrden articulosOrden);
    }
}
