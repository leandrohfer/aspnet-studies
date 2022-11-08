using InventoryControlSystemTest.Models;
using Microsoft.EntityFrameworkCore;


namespace InventoryControlSystemTest.Data
{
    public class InventoryControlSystemTestContext : DbContext
    {
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }

        public InventoryControlSystemTestContext(DbContextOptions<InventoryControlSystemTestContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().ToTable("Category");
            modelBuilder.Entity<ProductModel>().ToTable("Product");
        }
    }
}
