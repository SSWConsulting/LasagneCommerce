using Application.Orders.DTOs;

namespace Application.Customers.Abstractions;

public interface ICustomersService
{
    Task<List<OrderDto>> GetCustomerOrders(int customerId);
}
