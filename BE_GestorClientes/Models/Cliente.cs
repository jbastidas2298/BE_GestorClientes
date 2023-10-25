using System.ComponentModel.DataAnnotations;

namespace BE_GestorClientes.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
