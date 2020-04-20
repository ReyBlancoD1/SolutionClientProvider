using Microsoft.EntityFrameworkCore;
using Provider.Domain;
using Provider.Persistence.Database.Configuration;

namespace Provider.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInStock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Database schema
            builder.HasDefaultSchema("Provider");

            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
           new ProductConfiguration(modelBuilder.Entity<Product>());
           new ProductInStockConfiguration(modelBuilder.Entity<ProductInStock>());

        }

    }
}
