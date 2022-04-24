namespace TentamenProjeketet.Models.Entities
{
    public class CategoryEntity
    {
        public CategoryEntity()
        {
            ProductEntities = new HashSet<ProductEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductEntity> ProductEntities { get; set; }
    }
}
