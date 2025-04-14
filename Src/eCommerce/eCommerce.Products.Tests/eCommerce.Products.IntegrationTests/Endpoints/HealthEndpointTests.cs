using System.Net;
using eCommerce.Products.Application.Tests.Infrastructure;
using FluentAssertions;

namespace eCommerce.Products.Application.Tests.Endpoints;

public class HealthEndpointTests: IClassFixture<CustomWebApiFactory>
{
    private readonly HttpClient _client;

    public HealthEndpointTests(CustomWebApiFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetHealth_ShouldReturnOk()
    {
        // Act
        var response = await _client.GetAsync("/health");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }
}