using eCommerce.Products.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Products.Application.Tests.Infrastructure;

public static class DbContextFactory
{
    public static ProductsContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<ProductsContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Ensures a fresh DB per test
            .Options;

        var context = new ProductsContext(options);
        context.Database.EnsureCreated();

        return context;
    }
}