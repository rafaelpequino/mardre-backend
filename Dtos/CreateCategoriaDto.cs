using System.ComponentModel.DataAnnotations;

namespace Echeinbetter.Dtos
{
    public class CreateCategoriaDto
    {
        [MaxLength(255)]
        public string? Descricao { get; set; }
    }
}
