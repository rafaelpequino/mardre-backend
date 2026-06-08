using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Echeinbetter.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CodCategoria { get; set; }

        [MaxLength(255)]
        public string? Descricao { get; set; }
    }
}
