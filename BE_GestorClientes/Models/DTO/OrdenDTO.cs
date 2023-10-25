using System.ComponentModel.DataAnnotations;

namespace BE_GestorClientes.Models.DTO
{
    public class OrdenDTO
    {
        [Key]
        public int Id { get; set; }
        public string? CodigoUnico { get; set; }
        public DateTime? Fecha { get; set; }
        public int ClienteId { get; set; }
        public List<ArticulosOrdenDTO> ArticulosOrden { get; set; }
    }
}
