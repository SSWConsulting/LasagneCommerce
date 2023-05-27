using Application.Customers.Abstractions;
using Application.Orders.Abstractions;
using Application.Orders.DTOs;
using Application.Orders.Mappings;

namespace Application.Customers.Services;

public class CustomerService : ICustomersService
{
    public CustomerService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public IOrderRepository _orderRepository { get; }

    public async Task<List<OrderDto>> GetCustomerOrders(int customerId)
    {
        var orders = await _orderRepository.GetCustomerOrders(customerId);

        return orders.Select(o => o.ToOrderDto()).ToList();
    }
}
