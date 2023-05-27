using Application.Carts.Abstractions;
using Application.Carts.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SpaghettiCommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CartDto>> GetCart(int id)
    {
        var cart = await _cartService.GetCart(id);

        if (cart is not null)
        {
            return Ok(cart);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("{cartId}/{productId}/{count}")]
    public async Task<ActionResult> Put(int cartId, int productId, int count)
    {
        await _cartService.AddItem(cartId, productId, count);
        
        return Ok();
    }

    [HttpDelete("{cartId}/{productId}")]
    public async Task<ActionResult> Delete(int cartId, int productId)
    {
        await _cartService.RemoveItem(cartId, productId);

        return Ok();
    }
}
