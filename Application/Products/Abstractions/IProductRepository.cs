using SpaghettiCommerce.Domain.Models;

namespace Application.Products.Abstractions;

public interface IProductRepository
{
    Task<Product?> GetProduct(int id);

    Task<List<Product>> SearchProducts(string searchTerm);
}
