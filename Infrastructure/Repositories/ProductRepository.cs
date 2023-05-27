using Application.Products.Abstractions;
using Microsoft.EntityFrameworkCore;
using SpaghettiCommerce.Domain.Models;
using SpaghettiCommerce.Infrastructure.Data;

namespace Infrastructure.Services;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProduct(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<List<Product>> SearchProducts(string searchTerm)
    {
        return await _context.Products
            .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
            .ToListAsync();
    }
}
