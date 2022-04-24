using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TentamenProjeketet.Models.Entities
{
    public class UserName
    {

        public UserName()
        {
            ProductEntities = new HashSet<ProductEntity>();
        }

            [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(50)]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        //public int artikelnummer { get; set; }
        //[ForeignKey("artikelnummer")]
        public virtual Address Address { get; set; } = null!;
        public virtual ICollection<ProductEntity> ProductEntities { get; set; }

    }
}
