using System.ComponentModel.DataAnnotations;

namespace BE_GestorClientes.Models.DTO
{
    public class ArticulosOrdenDTO
    {
        [Key]
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ArticuloId { get; set; }
    }
}
