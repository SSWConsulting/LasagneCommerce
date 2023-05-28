using Application.Carts.Abstractions;
using Application.Carts.DTOs;
using Application.Carts.Mappings;
using Application.Products.Abstractions;
using LasagneCommerce.Domain.Models;

namespace Application.Carts.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;

    public CartService(ICartRepository cartRepository, IProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
    }

    public async Task AddItem(int cartId, int productId, int count)
    {
        var product = await _productRepository.GetProduct(productId);

        if (product is null)
        {
            throw new Exception("Product not found");
        }

        var cart = await _cartRepository.GetCartById(cartId);

        if (cart is null)
        {
            throw new Exception("Cart not found");
        }

        var item = new CartItem
        {
            Product = product,
            Count = count
        };

        // Logic for cart total is an application concern so is calculated here
        cart.Total += product.Price * count;

        cart.Items.Add(item);
        await _cartRepository.SaveCart(cart);
    }

    public async Task<CartDto?> GetCart(int id)
    {
        var cart = await _cartRepository.GetCartById(id);

        if (cart is null)
        {
            return null;
        }

        return cart.ToCartDto();
    }

    public async Task RemoveItem(int cartId, int productId)
    {
        var cart = await _cartRepository.GetCartById(cartId);

        if (cart is null)
        {
            throw new Exception("Cart not found");
        }

        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

        if (item is not null)
        {
            cart.Items.Remove(item);

            // Logic for cart total is an application concern so is calculated here
            cart.Total -= item.Product.Price * item.Count;

            await _cartRepository.SaveCart(cart);
        }
    }
}
