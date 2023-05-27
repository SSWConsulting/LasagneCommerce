using Application.Customer.Abstractions;
using Microsoft.AspNetCore.Mvc;
using SpaghettiCommerce.Domain.Models;

namespace SpaghettiCommerce.Controllers;

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
    public async Task<ActionResult<List<Order>>> GetOrders(int id)
    {
        var orders = await _customersService.GetCustomerOrders(id);

        return orders;
    }
}
