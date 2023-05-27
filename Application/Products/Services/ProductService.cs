using Application.Products.Abstractions;
using Application.Products.DTOs;
using Application.Products.Mappings;

namespace Application.Products.Services;

public class ProductService : IProductService
{
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IProductRepository _productRepository { get; }

    public async Task<ProductDto?> GetProduct(int id)
    {
        var product = await _productRepository.GetProduct(id);
        
        if (product is null)
        {
            return null;
        }

        return product.ToProductDto();
    }

    public async Task<List<ProductDto>> SearchProducts(string searchTerm)
    {
        var products = await _productRepository.SearchProducts(searchTerm);

        return products.Select(p => p.ToProductDto()).ToList();
    }
}
