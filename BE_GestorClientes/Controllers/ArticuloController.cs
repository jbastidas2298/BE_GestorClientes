using BE_GestorClientes.Models.DTO;
using BE_GestorClientes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BE_GestorClientes.Models.Repository;

namespace BE_GestorClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IArticuloRepository _articuloRepository;

        public ArticuloController(
            IMapper mapper,
            IArticuloRepository articuloRepository
            )
        {
            _mapper = mapper;
            _articuloRepository = articuloRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listArticulos = await _articuloRepository.GetAllArticulo();
                var articulosDTO = _mapper.Map<IEnumerable<ArticuloDTO>>(listArticulos);
                return Ok(articulosDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(ArticuloDTO articuloDTO)
        {
            try
            {
                var articulo = _mapper.Map<Articulo>(articuloDTO);
                articulo = await _articuloRepository.AddArticulo(articulo);
                var articulosDTO = _mapper.Map<ArticuloDTO>(articulo);
                return Ok(articulo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
