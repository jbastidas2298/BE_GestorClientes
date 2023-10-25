using AutoMapper;
using BE_GestorClientes.Models.DTO;
using BE_GestorClientes.Models.Repository;
using BE_GestorClientes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_GestorClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrdenRepository _ordenRepository; 
        private readonly IArticulosOrdenRepository _articulosOrdenRepository;

        public OrdenController(
            IMapper mapper,
            IOrdenRepository ordenRepository,
            IArticulosOrdenRepository articulosOrdenRepository
            )
        {
            _mapper = mapper;
            _ordenRepository = ordenRepository;
            _articulosOrdenRepository = articulosOrdenRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listOrdenes = await _ordenRepository.GetAllOrden();
                var ordenesDTO = _mapper.Map<IEnumerable<OrdenDTO>>(listOrdenes);
                return Ok(ordenesDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(OrdenDTO ordenDTO)
        {
            try
            {
                var orden = _mapper.Map<Orden>(ordenDTO);
                orden.Fecha = DateTime.Now;
                orden.CodigoUnico = await GenerarCodigoUnico(); 
                orden = await _ordenRepository.AddOrden(orden); 
                var ordenesDTO = _mapper.Map<OrdenDTO>(orden);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private async Task<string> GenerarCodigoUnico()
        {
            var ultimaOrdenTask = _ordenRepository.ObtenerUltimaOrden();
            var ultimaOrden = await ultimaOrdenTask;
            if (ultimaOrden != null)
            {
                string codigoUltimaOrden = ultimaOrden.CodigoUnico;
                string[] partes = codigoUltimaOrden.Split('-');
                if (partes.Length == 2 && int.TryParse(partes[1], out int numeroOrden))
                {
                    numeroOrden++;
                    return "OC-" + numeroOrden.ToString("D6");
                }
            }
            return "OC-000001";
        }


    }
}
