using Microsoft.EntityFrameworkCore;
using SpaghettiCommerce.Domain.Models;


namespace SpaghettiCommerce.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    
    public DbSet<Cart> Carts { get; set; }

    public DbSet<CartItem> CartITems { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Manufacturer> Manufacturers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }
    
    public DbSet<Product> Products { get; set; }
}
