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
        var products = await productService.GetAllAsync(Request.HttpContext.RequestAborted);
        return Ok(products);
    }
    
    [Route("color/{color}")]
    [HttpGet]
    public async Task<IActionResult> GetByColor(string color)
    {
        var products = await productService.GetByColorAsync(color, Request.HttpContext.RequestAborted);
        return Ok(products);
    }
}