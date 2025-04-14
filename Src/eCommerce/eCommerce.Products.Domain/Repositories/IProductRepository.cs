using eCommerce.Products.Domain.Entries;

namespace eCommerce.Products.Domain.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    IEnumerable<Product> GetByColor(string color);
}