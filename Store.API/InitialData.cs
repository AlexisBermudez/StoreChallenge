using Store.API.Context;
using Store.API.Models;

namespace Store.API
{
    public static class InitialData
    {
        public static void Seed(this StoreContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.Add(new Product
                {
                    Description = "",
                    Type = ProductType.Terrains,
                    Value = 0,
                    PurchaseDate = DateTime.Now,
                    Status = false
                });

                context.SaveChanges();
            }
        }
    }
}
