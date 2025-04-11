namespace eCommerce.Products.Application.Services.Authentication
{
    public interface IAuthService
    {
        Task<string> GetTokenAsync(string username, string password, CancellationToken cancellationToken);
    }
}
