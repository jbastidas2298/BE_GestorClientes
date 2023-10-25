using System.ComponentModel.DataAnnotations;

namespace BE_GestorClientes.Models.DTO
{
    public class ClienteDTO
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
