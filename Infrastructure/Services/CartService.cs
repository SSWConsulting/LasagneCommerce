using Microsoft.EntityFrameworkCore;
using SpaghettiCommerce.Application;
using SpaghettiCommerce.Domain.Models;
using SpaghettiCommerce.Infrastructure.Data;

namespace Infrastructure.Services;

public class CartService : ICartService
{
    private readonly AppDbContext _context;

    public CartService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task AddItem(int cartId, int productId, int count)
    {
        var cart = await _context.Carts.FindAsync(cartId);

        if (cart is null)
        {
            cart = new Cart
            {
                Items = new List<CartItem>
                {
                    new CartItem
                    {
                        ProductId = productId,
                        Count = count
                    }
                }
            };
        }
        else
        {
            cart.Items.Add(new CartItem
            {
                ProductId = productId,
                Count = count
            });
        }

        await _context.SaveChangesAsync();
    }

    public async Task<Cart?> GetCart(int id)
    {
        return await _context.Carts.FindAsync(id);
    }

    public async Task RemoveItem(int cartId, int productId)
    {
        var cart = await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.Id == cartId);

        var item = cart?.Items.FirstOrDefault(i => i.ProductId == productId);

        if (item is not null)
        {
            cart?.Items.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
