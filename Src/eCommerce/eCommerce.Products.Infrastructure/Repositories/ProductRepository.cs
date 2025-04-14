using eCommerce.Products.Domain.Entries;
using eCommerce.Products.Domain.Repositories;

namespace eCommerce.Products.Infrastructure.Repositories;

public class ProductRepository: IProductRepository
{
    public IEnumerable<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetByColor(string color)
    {
        throw new NotImplementedException();
    }
}