using eCommerce.Products.Application.Tests.SeedData;
using eCommerce.Products.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace eCommerce.Products.Application.Tests.Infrastructure;

public class CustomWebApiFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddAuthentication("Test")
                .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                    "Test", options => { });
            
            // Replace the real DB context with an in-memory one
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<ProductsContext>));

            services.Remove(descriptor);

            services.AddDbContext<ProductsContext>(options =>
            {
                options.UseInMemoryDatabase("TestDb");
            });
            
             var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ProductsContext>();
            db.Database.EnsureCreated();
            ProductSeeder.Seed(db);
        });
    }
}