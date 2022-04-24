using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TentamenProjeketet.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        [Required]
        public int artikelnummer { get; set; }
        [Required]
        public string ProduktNamn { get; set; } = null!;
        // [Column(TypeName = "varchar(250)")]
        public string beskrivning { get; set; } = string.Empty;
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public virtual UserName  UserNames { get; set; } = null!;
        public virtual CategoryEntity Category { get; set; } = null!;
    }
}
