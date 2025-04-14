using eCommerce.Products.Application.DTOs;
using eCommerce.Products.Domain.Repositories;

namespace eCommerce.Products.Application.Services.Product;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<ProductDto> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProductDto> GetProductsByColor(string color)
    {
        throw new NotImplementedException();
    }
}