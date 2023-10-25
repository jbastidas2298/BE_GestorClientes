using System.ComponentModel.DataAnnotations;

namespace BE_GestorClientes.Models
{
    public class ArticulosOrden
    {
        [Key]
        public int Id { get; set; }

        public int OrdenId { get; set; }
        public Orden Orden { get; set; }
        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
    }
}
