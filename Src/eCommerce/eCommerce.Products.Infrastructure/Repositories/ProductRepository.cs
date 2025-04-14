using eCommerce.Products.Domain.Entries;
using eCommerce.Products.Domain.Repositories;
using eCommerce.Products.Infrastructure.Persistence;

namespace eCommerce.Products.Infrastructure.Repositories;

public class ProductRepository(ProductsContext context) : IProductRepository
{
    public IQueryable<Product> GetAll()
    {
        return context.Products.AsQueryable<Product>();
    }

  
}