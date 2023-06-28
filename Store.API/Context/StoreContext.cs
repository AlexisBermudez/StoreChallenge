using Microsoft.EntityFrameworkCore;
using Store.API.Entities;

namespace Store.API.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {   Id = 1,
                        Description = "Terrain in Medellín",
                        Type = ProductType.Terrains,
                        Value = 60000000,
                        PurchaseDate = DateTime.Now,
                        Status = false
                    },
                    new Product
                    {
                        Id = 2,
                        Description = "Libero 125cc",
                        Type = ProductType.Vehicles,
                        Value = 4000000,
                        PurchaseDate = DateTime.Now,
                        Status = false
                    },
                    new Product
                    {
                        Id = 3,
                        Description = "Aparment in Itagüí",
                        Type = ProductType.Apartments,
                        Value = 59000000,
                        PurchaseDate = DateTime.Now,
                        Status = false
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
