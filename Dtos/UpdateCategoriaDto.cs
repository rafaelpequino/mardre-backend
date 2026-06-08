using System.ComponentModel.DataAnnotations;

namespace Echeinbetter.Dtos
{
    public class UpdateCategoriaDto
    {
        [Required]
        public int CodCategoria { get; set; }

        [MaxLength(255)]
        public string? Descricao { get; set; }
    }
}
