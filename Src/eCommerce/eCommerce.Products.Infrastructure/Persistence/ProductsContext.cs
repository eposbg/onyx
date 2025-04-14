using eCommerce.Products.Domain.Entries;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Products.Infrastructure.Persistence;

public class ProductsContext: DbContext
{
    public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options) { }

    public DbSet<Product> Products { get; set; }

}