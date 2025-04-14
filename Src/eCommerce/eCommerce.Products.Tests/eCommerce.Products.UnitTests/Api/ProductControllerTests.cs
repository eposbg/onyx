using eCommerce.Products.Application.DTOs;
using eCommerce.Products.Application.Services.Product;
using eCommerce.Products.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace eCommerce.Products.UnitTests.Api;

public class ProductControllerTests
{
    [Fact]
    public async Task Get_ShouldReturnAllProducts()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { Name = "Shirt", Color = "Red" },
            new() { Name = "Shoes", Color = "Blue" }
        };
        var productServiceMock = new Mock<IProductService>();
        productServiceMock
            .Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(products);
        
        var sut = new ProductsController(productServiceMock.Object);
        var context = new DefaultHttpContext();
        sut.ControllerContext = new ControllerContext { HttpContext = context };
       
        // Act
        var result = await sut.Get();
        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult!.Value.Should().BeEquivalentTo(products);
    }
    
    [Fact]
    public async Task Get_WhenServiceThrows_ShouldPropagateException()
    {
        // Arrange
        var mockService = new Mock<IProductService>();

        mockService
            .Setup(s => s.GetAllAsync(It.IsAny<CancellationToken>()))
            .ThrowsAsync(new InvalidOperationException("Service failed"));

        var sut = new ProductsController(mockService.Object);
        sut.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };

        // Act
        var result = async () => await sut.Get();

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Service failed");
    }
    
    [Fact]
    public async Task GetByColor_ShouldReturnAllProducts()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { Name = "Shirt", Color = "Red" },
            new() { Name = "Shoes", Color = "Red" }
        };
        var productServiceMock = new Mock<IProductService>();
        productServiceMock
            .Setup(x => x.GetByColorAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(products);
        
        var sut = new ProductsController(productServiceMock.Object);
        var context = new DefaultHttpContext();
        sut.ControllerContext = new ControllerContext { HttpContext = context };
       
        // Act
        var result = await sut.GetByColor("Red");
        
        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult!.Value.Should().BeEquivalentTo(products);
    }


    [Fact]
    public async Task GetByColor_WhenServiceThrows_ShouldPropagateException()
    {
        // Arrange
        var mockService = new Mock<IProductService>();
        var expectedColor = "Blue";

        mockService
            .Setup(s => s.GetByColorAsync(expectedColor, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new InvalidOperationException("Service failed"));

        var sut = new ProductsController(mockService.Object);
        sut.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };

        // Act
        var result = async () => await sut.GetByColor(expectedColor);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Service failed");
    }
}