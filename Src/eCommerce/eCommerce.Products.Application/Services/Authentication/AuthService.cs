using eCommerce.Products.Application.Settings.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eCommerce.Products.Application.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthService(JwtSettings jwtSettings)
        {
            _jwtSettings=jwtSettings;
        }

        public async Task<string> GetTokenAsync(string username, string password, CancellationToken cancellationToken)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, "testuser") };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
