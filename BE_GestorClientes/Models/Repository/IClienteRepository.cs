namespace BE_GestorClientes.Models.Repository
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task DeleteCliente(Cliente cliente);
        Task<Cliente> AddCliente(Cliente cliente);  
        Task UpdateCliente(Cliente cliente);
    }
}
