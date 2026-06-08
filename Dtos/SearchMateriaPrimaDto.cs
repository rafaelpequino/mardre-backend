using System.ComponentModel.DataAnnotations;

namespace Mardre.Dtos
{
    public class SearchMateriaPrimaDto
    {
        [MaxLength(255)]
        public string? CodigoBarras { get; set; }
    }
}
