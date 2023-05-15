using SpaghettiCommerce.Domain.Models;

namespace SpaghettiCommerce.Application;

public interface ICustomersService
{
    Task<List<Order>> GetCustomerOrders(int customerId);
}
