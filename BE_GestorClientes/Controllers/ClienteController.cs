using AutoMapper;
using BE_GestorClientes.Models;
using BE_GestorClientes.Models.DTO;
using BE_GestorClientes.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_GestorClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(
            IMapper mapper,
            IClienteRepository clienteRepository
            )
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listClientes = await _clienteRepository.GetAllClientes();
                var clientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(listClientes);
                return Ok(clientesDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetClienteById(id);

                if (cliente == null)
                {
                    return NotFound();
                }
                var clienteDTO = _mapper.Map<ClienteDTO>(cliente);
                return Ok(clienteDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetClienteById(id);

                if (cliente == null)
                {
                    return NotFound();
                }
                await _clienteRepository.DeleteCliente(cliente);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(ClienteDTO clienteDTO)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDTO);

                 cliente = await _clienteRepository.AddCliente(cliente);

                var clientesDTO = _mapper.Map<ClienteDTO>(cliente);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ClienteDTO clienteDTO)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDTO);
                if (id != cliente.Id)
                {
                    return BadRequest();
                }
                var clientes = await _clienteRepository.GetClienteById(id);
                if (clientes == null)
                {
                    return NotFound();
                }
                await _clienteRepository.UpdateCliente(cliente);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
} 
