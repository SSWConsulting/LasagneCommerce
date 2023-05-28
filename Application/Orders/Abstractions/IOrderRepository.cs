using LasagneCommerce.Domain.Models;

namespace Application.Orders.Abstractions;

public interface IOrderRepository
{
    Task<Order?> GetOrder(int id);

    Task<List<Order>> GetCustomerOrders(int customerId);

    Task SaveOrder(Order order);
}
