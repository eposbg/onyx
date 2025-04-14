using eCommerce.Products.Domain.Entries;

namespace eCommerce.Products.Domain.Repositories;

public interface IProductRepository
{
    IQueryable<Product> GetAll();
}