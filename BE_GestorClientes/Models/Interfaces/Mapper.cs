using AutoMapper;
using BE_GestorClientes.Models.DTO;

namespace BE_GestorClientes.Models.Interfaces
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<Articulo, ArticuloDTO>();
            CreateMap<ArticuloDTO, Articulo>();
            CreateMap<Orden, OrdenDTO>();
            CreateMap<OrdenDTO, Orden>();
            CreateMap<ArticulosOrden, ArticulosOrdenDTO>();
            CreateMap<ArticulosOrdenDTO, ArticulosOrden>();
        }
    }
}
