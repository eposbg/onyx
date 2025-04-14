using eCommerce.Products.Application.DTOs;
using eCommerce.Products.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Products.Application.Services.Product;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var allProducts = await _productRepository.GetAll().ToListAsync(cancellationToken);
        return allProducts.Select(x=>new ProductDto
        {
            Name = x.Name,
            Color = x.Color
        });
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByColor(string color, CancellationToken cancellationToken)
    {
        var allProducts = await _productRepository
            .GetAll()
            .Where(p=>p.Color == color)
            .ToListAsync(cancellationToken);
        
        return allProducts.Where(x=>x.Color == color).Select(x=>new ProductDto
        {
            Name = x.Name,
            Color = x.Color
        });
    }
}