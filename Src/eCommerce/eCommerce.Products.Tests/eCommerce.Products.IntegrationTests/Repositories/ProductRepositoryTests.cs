using eCommerce.Products.Application.Tests.Infrastructure;
using eCommerce.Products.Domain.Entries;
using eCommerce.Products.Infrastructure.Repositories;
using FluentAssertions;

namespace eCommerce.Products.Application.Tests.Repositories;

public class ProductRepositoryTests
{
    [Fact]
    public void GetAll_ShouldReturnQueryableProducts()
    {
        // Arrange
        var context = DbContextFactory.CreateInMemoryContext();

        context.Products.AddRange(
            new Product { Id = 1, Name = "Shirt", Color = "Red" },
            new Product { Id = 2, Name = "Shoes", Color = "Blue" }
        );
        context.SaveChanges();

        var repository = new ProductRepository(context);

        // Act
        var result = repository.GetAll().ToList();

        // Assert
        result.Should().HaveCount(2);
        result.Should().Contain(p => p.Name == "Shirt");
    }
}