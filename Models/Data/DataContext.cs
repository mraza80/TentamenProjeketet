
using Microsoft.EntityFrameworkCore;
using TentamenProjeketet.Models.Entities;

namespace TentamenProjeketet.Models.Data


{
    public class DataContext:DbContext

    {
        protected DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<UserName> UserNames { get; set; } = null;
        public virtual DbSet<Address> Addresses { get; set; } = null;
        public virtual DbSet<ProductEntity> Products { get; set; } = null;
        public virtual DbSet<CategoryEntity> Category { get; set; } = null;

    }
}
