using Application.Products.DTOs;

namespace Application.Products.Abstractions;

public interface IProductService
{
    Task<ProductDto?> GetProduct(int id);

    Task<List<ProductDto>> SearchProducts(string searchTerm);
}


