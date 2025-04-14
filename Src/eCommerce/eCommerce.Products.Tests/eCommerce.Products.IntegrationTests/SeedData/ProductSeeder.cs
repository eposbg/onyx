using eCommerce.Products.Domain.Entries;
using eCommerce.Products.Infrastructure.Persistence;

namespace eCommerce.Products.Application.Tests.SeedData;

public static class ProductSeeder
{
    public static void Seed(ProductsContext context)
    {
        if (context.Products.Any())
            return; // Prevent duplicate seeding

        var products = new List<Product>
        {
            new() { Id = 1, Name = "Shirt", Color = "Red" },
            new() { Id = 2, Name = "Shoes", Color = "Blue" },
            new() { Id = 3, Name = "Hat", Color = "Red" }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}