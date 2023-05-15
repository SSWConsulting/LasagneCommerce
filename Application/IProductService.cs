using SpaghettiCommerce.Domain.Models;

namespace SpaghettiCommerce.Application;

public interface IProductService
{
    Task<Product?> GetProduct(int id);

    Task<List<Product>> SearchProducts(string searchTerm);
}


