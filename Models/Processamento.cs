using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mardre.Models
{
    [Table("Processamento")]
    public class Processamento
    {
        [Key]
        public int CodProcessamento { get; set; }

        public DateTime? DataEntrada { get; set; }

        public DateTime? DataSaida { get; set; }

        public int? CodMateria { get; set; }

        [ForeignKey(nameof(CodMateria))]
        public MateriaPrima? MateriaPrima { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal? Peso { get; set; }

        /// <summary>Tempo em milissegundos</summary>
        public int? TempoLeitura { get; set; }

        /// <summary>Tempo em milissegundos</summary>
        public int? TempoPesagem { get; set; }

        /// <summary>Tempo em milissegundos</summary>
        public int? TempoClassificacao { get; set; }

        /// <summary>Tempo em milissegundos</summary>
        public int? TempoRedirecionamento { get; set; }

        /// <summary>Tempo em milissegundos</summary>
        public int? TempoTotalProcessamento { get; set; }

        [MaxLength(255)]
        public string? RegistroFotografico { get; set; }
    }
}
