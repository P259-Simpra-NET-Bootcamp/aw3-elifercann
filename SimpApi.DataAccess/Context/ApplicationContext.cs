using Microsoft.EntityFrameworkCore;
using SimpApi.Entities.Model;

namespace SimpApi.DataAccess.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

       
    }
}
