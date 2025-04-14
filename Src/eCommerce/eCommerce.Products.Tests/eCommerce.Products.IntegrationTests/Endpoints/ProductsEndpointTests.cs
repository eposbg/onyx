using System.Net;
using eCommerce.Products.Application.Tests.Infrastructure;
using FluentAssertions;

namespace eCommerce.Products.Application.Tests.Endpoints;

public class ProductsEndpointTests : IClassFixture<CustomWebApiFactory>
{
    private readonly HttpClient _client;

    public ProductsEndpointTests(CustomWebApiFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetProducts_ShouldReturnOk()
    {
        // Act
        var response = await _client.GetAsync("/products");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public async Task GetProductsByColor_ShouldReturnOk()
    {
        // Act
        var response = await _client.GetAsync("/products/color/red");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }
}