using FeatureFolder.Api.Features.Orders.Models;
using FeatureFolder.Api.Features.Orders.Services;
using FeatureFolder.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFolder.Api.Features.Orders.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<ApiResponse<IEnumerable<OrderResponse>>> GetAll()
    {
        return Ok(ApiResponse<IEnumerable<OrderResponse>>.Ok(_orderService.GetAll()));
    }

    [HttpGet("{id}")]
    public ActionResult<ApiResponse<OrderResponse>> GetById(int id)
    {
        var order = _orderService.GetById(id);
        if (order is null)
            return NotFound(ApiResponse<OrderResponse>.Fail("Orden no encontrada"));
        return Ok(ApiResponse<OrderResponse>.Ok(order));
    }

    [HttpPost]
    public ActionResult<ApiResponse<OrderResponse>> Create([FromBody] CreateOrderRequest request)
    {
        var created = _orderService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id },
            ApiResponse<OrderResponse>.Ok(created));
    }
}
