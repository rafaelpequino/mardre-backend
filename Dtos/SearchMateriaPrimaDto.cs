using System.ComponentModel.DataAnnotations;

namespace Echeinbetter.Dtos
{
    public class SearchMateriaPrimaDto
    {
        [MaxLength(255)]
        public string? CodigoBarras { get; set; }
    }
}
