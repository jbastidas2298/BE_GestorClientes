using Microsoft.EntityFrameworkCore;

namespace BE_GestorClientes.Models.Repository
{
    public class ClienteRepository: IClienteRepository
    {
        private readonly DataAccessContext _dataAccessContext;
        public ClienteRepository(DataAccessContext dataAccessContext)
        {
            _dataAccessContext = dataAccessContext; 
        }

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            _dataAccessContext.Add(cliente);
            await _dataAccessContext.SaveChangesAsync();
            return cliente;
        }

        public async Task DeleteCliente(Cliente cliente)
        {
            _dataAccessContext.Cliente.Remove(cliente);
            await _dataAccessContext.SaveChangesAsync();
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            return await _dataAccessContext.Cliente.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            return await _dataAccessContext.Cliente.FindAsync(id);
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            var clienteItem = await _dataAccessContext.Cliente.FirstOrDefaultAsync(x => x.Id == cliente.Id);
            if (clienteItem != null)
            {
                clienteItem.Nombre = cliente.Nombre;
                clienteItem.Apellido = cliente.Apellido;
                await _dataAccessContext.SaveChangesAsync();
            }

           
        }
    }
}
