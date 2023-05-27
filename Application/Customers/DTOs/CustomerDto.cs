using Application.Orders.DTOs;

namespace Application.Customers.DTOs;

public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string DeliveryAddress { get; set; } = string.Empty;
    public List<OrderDto> Orders { get; set; } = new();
}
