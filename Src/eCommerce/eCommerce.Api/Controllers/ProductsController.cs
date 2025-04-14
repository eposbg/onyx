using eCommerce.Products.Application.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Products.Controllers;

[ApiController, Authorize]
[Route("[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    // GET
    
    [Route("")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await productService.GetAllAsync(HttpContext.RequestAborted);
        return Ok(products);
    }
}