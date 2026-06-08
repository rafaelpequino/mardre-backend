using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Echeinbetter.Models
{
    [Table("Materia_Prima")]
    public class MateriaPrima
    {
        [Key]
        public int CodMateria { get; set; }

        [MaxLength(255)]
        public string? Descricao { get; set; }

        [MaxLength(255)]
        public string? CodigoBarras { get; set; }

        public int? CodCategoria { get; set; }

        [ForeignKey(nameof(CodCategoria))]
        public Categoria? Categoria { get; set; }

        public int? EstoqueMin { get; set; }

        public int? EstoqueMax { get; set; }

        [MaxLength(255)]
        public string? Tipo { get; set; }

        [MaxLength(255)]
        public string? Descarte { get; set; }

        [Column(TypeName = "decimal(10,6)")]
        public decimal? FatorCo2 { get; set; }

        [Column(TypeName = "decimal(12,6)")]
        public decimal? EmissaoCo2 { get; set; }
    }
}
