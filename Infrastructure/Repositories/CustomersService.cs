using Application.Customer.Abstractions;
using Microsoft.EntityFrameworkCore;
using SpaghettiCommerce.Domain.Models;
using SpaghettiCommerce.Infrastructure.Data;

namespace Infrastructure.Services;

public class CustomersService : ICustomersService
{
    private readonly AppDbContext _context;

    public CustomersService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Order>> GetCustomerOrders(int customerId)
    {
        var orders = new List<Order>();
            
        var dbOrders = await _context.Customers
            .Where(c => c.Id == customerId)
            .Select(c => c.Orders)
            .FirstOrDefaultAsync();

        if (dbOrders?.Any()??false)
            return dbOrders;
        
        return orders;
    }
}
