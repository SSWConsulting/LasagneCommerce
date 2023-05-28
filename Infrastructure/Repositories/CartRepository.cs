using Application.Carts.Abstractions;
using Microsoft.EntityFrameworkCore;
using LasagneCommerce.Domain.Models;
using LasagneCommerce.Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CartRepository : ICartRepository
{
    private readonly AppDbContext _context;

    public CartRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateCart()
    {
        var cart = new Cart();
        _context.Carts.Add(cart);
        await _context.SaveChangesAsync();
        return cart.Id;
    }

    public async Task<Cart?> GetCartById(int id)
    {
        return await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task RemoveItemFromCart(int cartId, int productId)
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

    public async Task SaveCart(Cart cart)
    {
        _context.Carts.Update(cart);
        await _context.SaveChangesAsync();
    }
}
