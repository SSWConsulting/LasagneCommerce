namespace Application.Orders.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public string CustomerOrderRef { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerDeliveryAddress { get; set; } = string.Empty;
    public List<OrderItemDto> Items { get; set; } = new();
    public decimal TotalPrice { get; set; }
}
