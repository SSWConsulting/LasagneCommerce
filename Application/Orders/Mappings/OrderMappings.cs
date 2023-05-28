using Application.Orders.DTOs;
using LasagneCommerce.Domain.Models;

namespace Application.Orders.Mappings;

public static class OrderMappings
{
    public static OrderDto ToOrderDto(this Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            CustomerName = order.Customer.Name,
            CustomerEmail = order.Customer.Email,
            CustomerOrderRef = order.CustomerOrderRef,
            CustomerDeliveryAddress = order.Customer.DeliveryAddress,
            Items = order.Items.Select(i => i.ToOrderItemDto()).ToList(),
            TotalPrice = order.OrderTotal
        };
    }

    public static OrderItemDto ToOrderItemDto(this OrderItem orderItem)
    {
        return new OrderItemDto
        {
            Id = orderItem.Id,
            ProductId = orderItem.ProdutId, // Note: Typo in Entity, so we have to map it here
            ProductName = orderItem.Product.Name,
            Count = orderItem.Count
        };
    }
}
