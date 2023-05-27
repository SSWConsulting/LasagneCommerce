using SpaghettiCommerce.Domain.Models;

namespace Application.Order.Abstractions;

public interface IOrderService
{
    Task<Order> GetOrder(int id);

    Task<List<Order>> GetCustomerOrders(int customerId);

    Task<string> Checkout(int cartId, string cardNumber, string cardExpiry, string cvv);
}
