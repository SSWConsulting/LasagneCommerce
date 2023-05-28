using Application.Customers.Abstractions;
using Application.Orders.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LasagneCommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomersService _customersService;

    public CustomerController(ICustomersService customersService)
    {
        _customersService = customersService;
    }

    [HttpGet("{id}/orders")]
    public async Task<ActionResult<List<OrderDto>>> GetOrders(int id)
    {
        var orders = await _customersService.GetCustomerOrders(id);

        return orders;
    }
}
