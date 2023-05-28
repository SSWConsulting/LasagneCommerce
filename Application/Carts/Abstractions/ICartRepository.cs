using LasagneCommerce.Domain.Models;

namespace Application.Carts.Abstractions;

public interface ICartRepository
{
    Task<Cart?> GetCartById(int id);
    Task<int> CreateCart();
    Task SaveCart(Cart cart);
}
