using Application.Carts.Abstractions;
using Application.Common.Abstractions;
using Application.Orders.Abstractions;
using Application.Orders.DTOs;
using Application.Orders.Mappings;
using LasagneCommerce.Domain.Models;

namespace Application.Orders.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IPaymentService _paymentService;
    private readonly INotificationService _notificationService;

    public OrderService(
        IOrderRepository orderRepository,
        ICartRepository cartRepository,
        IPaymentService paymentService,
        INotificationService notificationService)
    {
        _orderRepository = orderRepository;
        _cartRepository = cartRepository;
        _paymentService = paymentService;
        _notificationService = notificationService;
    }

    public async Task<string> Checkout(int cartId, string cardNumber, string cardExpiry, string cvv)
    {
        var paymentResult = await _paymentService.MakePayment(cardNumber, cardExpiry, cvv);

        if (paymentResult.IsSuccessful)
        {
            var cart = await _cartRepository.GetCartById(cartId);

            if (cart is null)
            {
                throw new Exception("Cart not found");
            }

            var orderItems = new List<OrderItem>();

            foreach (var item in cart.Items)
            {
                orderItems.Add(new OrderItem
                {
                    Product = item.Product,
                    Count = item.Count
                });
            }

            var order = new Order
            {
                Customer = cart.Customer,
                CustomerId = cart.Customer.Id,
                Items = orderItems,
                OrderTotal = cart.Total,
                CustomerOrderRef = Guid.NewGuid().ToString()
            };

            await _orderRepository.SaveOrder(order);

            await _notificationService.SendEmailNotification(cart.Customer.Email, order.CustomerOrderRef);

            return order.CustomerOrderRef;
        }
        else
        {
            throw new Exception("Payment failed");
        }
    }

    public async Task<OrderDto> GetOrder(int id)
    {
        var order = await _orderRepository.GetOrder(id);

        if (order is null)
        {
            throw new Exception("Order not found");
        }

        return order.ToOrderDto();
    }
}
