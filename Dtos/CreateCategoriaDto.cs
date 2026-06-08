using System.ComponentModel.DataAnnotations;

namespace Mardre.Dtos
{
    public class CreateCategoriaDto
    {
        [MaxLength(255)]
        public string? Descricao { get; set; }
    }
}
