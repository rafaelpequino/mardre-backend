using System.ComponentModel.DataAnnotations;

namespace Echeinbetter.Dtos
{
    public class UpdateProcessamentoDto
    {
        [Required]
        public int CodProcessamento { get; set; }

        public DateTime? DataEntrada { get; set; }

        public DateTime? DataSaida { get; set; }

        public int? CodMateria { get; set; }

        public decimal? Peso { get; set; }

        public int? TempoLeitura { get; set; }

        public int? TempoPesagem { get; set; }

        public int? TempoClassificacao { get; set; }

        public int? TempoRedirecionamento { get; set; }

        public int? TempoTotalProcessamento { get; set; }

        [MaxLength(255)]
        public string? RegistroFotografico { get; set; }
    }
}
