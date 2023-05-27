using Application.Carts.DTOs;

namespace Application.Carts.Abstractions;

public interface ICartService
{
    Task<CartDto?> GetCart(int id);

    Task AddItem(int cartId, int productId, int count);

    Task RemoveItem(int cartId, int productId);
}
