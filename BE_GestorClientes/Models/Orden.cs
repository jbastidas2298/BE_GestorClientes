using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BE_GestorClientes.Models
{
    public class Orden
    {
        [Key]
        public int Id { get; set; }
        public string CodigoUnico { get; set; }
        public DateTime? Fecha { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [JsonIgnore] 
        public ICollection<ArticulosOrden> ArticulosOrden { get; set; }
    }
}
