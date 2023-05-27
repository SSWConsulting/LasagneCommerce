using SpaghettiCommerce.Domain.Models;

namespace Application.Customer.Abstractions;

public interface ICustomersService
{
    Task<List<Order>> GetCustomerOrders(int customerId);
}
