using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Products.Controllers;

[ApiController, Authorize]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }
}