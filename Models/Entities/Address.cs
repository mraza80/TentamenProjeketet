using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TentamenProjeketet.Models.Entities
{
    public class Address
    {
        public Address()
        {
            UserNames = new HashSet<UserName>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(50)]
        public string StreetName { get; set; } = null!;
        [StringLength(50)]
        public string PostalCode { get; set; } = null!;
        [StringLength(50)]
        public string City { get; set; } = null!;

        [InverseProperty("Address")]
        public virtual ICollection<UserName> UserNames { get; set; }
    }
}

