using Application.Orders.Abstractions;
using Microsoft.EntityFrameworkCore;
using SpaghettiCommerce.Domain.Models;
using SpaghettiCommerce.Infrastructure.Data;

namespace Infrastructure.Services;

public class OrderRepository : IOrderRepository
{
    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public AppDbContext _context { get; }

    public async Task<List<Order>> GetCustomerOrders(int customerId)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .Include(o => o.Customer)
            .Where(o => o.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<Order?> GetOrder(int id)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .Include(o => o.Customer)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task SaveOrder(Order order)
    {
        var dbOrder = await _context.Orders.FindAsync(order.Id);

        if (dbOrder is null)
        {
            await _context.Orders.AddAsync(order);
        }
        else
        {
            dbOrder.Customer = order.Customer;
            dbOrder.CustomerId = order.CustomerId;
            dbOrder.Items = order.Items;
            dbOrder.OrderTotal = order.OrderTotal;
            dbOrder.CustomerOrderRef = order.CustomerOrderRef;
        }

        await _context.SaveChangesAsync();
    }
}
