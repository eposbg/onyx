using eCommerce.Products.Application.Services.Authentication;
using eCommerce.Products.Domain.Entries;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Products.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController( IAuthService authService)
        {
            _authService=authService;
        }

        [HttpPost]
        [Route("GetToken")]
        public async Task<IActionResult> GetToken([FromBody] User user)
        {
            var token = await _authService.GetTokenAsync(
                user.Username,
                user.Password,
                Request.HttpContext.RequestAborted);

            return Ok(new { token });

        }
    }
}
