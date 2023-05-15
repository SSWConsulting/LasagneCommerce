using SpaghettiCommerce.Domain.Models;

namespace SpaghettiCommerce.Application;

public interface ICartService
{
    Task<Cart?> GetCart(int id);

    Task AddItem(int cartId, int productId, int count);

    Task RemoveItem(int cartId, int productId);
}
