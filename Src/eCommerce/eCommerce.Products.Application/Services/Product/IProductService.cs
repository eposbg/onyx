﻿using eCommerce.Products.Application.DTOs;

namespace eCommerce.Products.Application.Services.Product;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductDto>> GetByColorAsync(string color, CancellationToken httpContextRequestAborted);
}