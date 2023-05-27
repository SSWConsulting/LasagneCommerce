using Application.Customers.DTOs;
using Application.Orders.Mappings;
using SpaghettiCommerce.Domain.Models;

namespace Application.Customers.Mappings;

public static class CustomerMappings
{
    public static CustomerDto ToCustomerDto(this Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            DeliveryAddress = customer.DeliveryAddress,
            Email = customer.Email,
            Name = customer.Name,
            Orders = customer.Orders.Select(o => o.ToOrderDto()).ToList()
        };
    }
}
