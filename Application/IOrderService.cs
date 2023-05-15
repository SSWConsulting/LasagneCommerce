using SpaghettiCommerce.Domain.Models;

namespace SpaghettiCommerce.Application;

public interface IOrderService
{
    Task<Order> GetOrder(int id);

    Task<List<Order>> GetCustomerOrders(int customerId);

    Task<string> Checkout(int cartId, string cardNumber, string cardExpiry, string cvv);
}
