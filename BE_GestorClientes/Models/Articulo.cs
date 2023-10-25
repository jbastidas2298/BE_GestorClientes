using System.ComponentModel.DataAnnotations;

namespace BE_GestorClientes.Models
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Codigo { get; set; }
    }
}
