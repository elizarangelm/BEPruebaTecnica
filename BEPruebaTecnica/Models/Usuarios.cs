using System.ComponentModel.DataAnnotations;

namespace BEPruebaTecnica.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
