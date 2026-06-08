using System.ComponentModel.DataAnnotations;

namespace Echeinbetter.Dtos
{
    public class CreateMateriaPrimaDto
    {
        [MaxLength(255)]
        public string? Descricao { get; set; }

        [MaxLength(255)]
        public string? CodigoBarras { get; set; }

        public int? CodCategoria { get; set; }

        public int? EstoqueMin { get; set; }

        public int? EstoqueMax { get; set; }

        [MaxLength(255)]
        public string? Tipo { get; set; }

        [MaxLength(255)]
        public string? Descarte { get; set; }

        public decimal? FatorCo2 { get; set; }

        public decimal? EmissaoCo2 { get; set; }
    }
}
