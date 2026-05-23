using System.ComponentModel.DataAnnotations;

namespace Echeinbetter.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public required string Category { get; set; }

        [MaxLength(200)]
        public required string Product { get; set; }

        [MaxLength(100)]
        public required string Batch { get; set; }

        [MaxLength(50)]
        public required string Quad { get; set; }

        [MaxLength(100)]
        public required string BarCode { get; set; }

        [MaxLength(500)]
        public string? Note { get; set; }
    }
}

