using Application.Products.DTOs;
using SpaghettiCommerce.Domain.Models;

namespace Application.Products.Mappings;

public static class ProductMappings
{
    public static ProductDto ToProductDto(this Product product)
    {
        return new ProductDto
        {
            CategoryName = product.Category.Name,
            Description = product.Description,
            Id = product.Id,
            ManufacturerName = product.Manufacturer.Name,
            Name = product.Name,
            Price = product.Price
        };
    }
}
