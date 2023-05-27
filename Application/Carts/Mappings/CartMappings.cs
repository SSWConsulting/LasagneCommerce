using Application.Carts.DTOs;
using SpaghettiCommerce.Domain.Models;

namespace Application.Carts.Mappings;

public static class CartMappings
{
    public static CartDto ToCartDto(this Cart cart)
    {
        return new CartDto
        {
            Id = cart.Id,
            Customer = cart.Customer.Name,
            Items = cart.Items.Select(i => i.ToCartItemDto()).ToList(),
            Total = cart.Total
        };
    }

    public static CartItemDto ToCartItemDto(this CartItem cartItem)
    {
        return new CartItemDto
        {
            Id = cartItem.Id,
            ProductId = cartItem.ProductId,
            ProductName = cartItem.Product.Name,
            Count = cartItem.Count
        };
    }
}
