using Application.Orders.DTOs;

namespace Application.Orders.Abstractions;

public interface IOrderService
{
    Task<OrderDto> GetOrder(int id);
    
    Task<string> Checkout(int cartId, string cardNumber, string cardExpiry, string cvv);
}
