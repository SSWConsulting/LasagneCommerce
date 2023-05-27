using Application.Products.Abstractions;
using Application.Products.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SpaghettiCommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await _productService.GetProduct(id);

        return Ok(product);
    }

    [HttpGet("search/{searchTerm}")]
    public async Task<ActionResult<List<ProductDto>>> SearchProducts(string searchTerm)
    {
        var products = await _productService.SearchProducts(searchTerm);

        return Ok(products);
    }
}
