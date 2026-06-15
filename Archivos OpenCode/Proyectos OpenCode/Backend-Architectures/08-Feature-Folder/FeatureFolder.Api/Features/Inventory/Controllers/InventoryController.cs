using FeatureFolder.Api.Features.Inventory.Models;
using FeatureFolder.Api.Features.Inventory.Services;
using FeatureFolder.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFolder.Api.Features.Inventory.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpGet]
    public ActionResult<ApiResponse<IEnumerable<InventoryItem>>> GetAll()
    {
        return Ok(ApiResponse<IEnumerable<InventoryItem>>.Ok(_inventoryService.GetAll()));
    }

    [HttpGet("{productId}")]
    public ActionResult<ApiResponse<InventoryItem>> GetByProductId(int productId)
    {
        var item = _inventoryService.GetByProductId(productId);
        if (item is null)
            return NotFound(ApiResponse<InventoryItem>.Fail("Producto no encontrado en inventario"));
        return Ok(ApiResponse<InventoryItem>.Ok(item));
    }

    [HttpPost("deduct")]
    public ActionResult<ApiResponse<object>> DeductStock([FromBody] DeductRequest request)
    {
        var result = _inventoryService.DeductStock(request.ProductId, request.Quantity);
        if (!result)
            return BadRequest(ApiResponse<object>.Fail("Stock insuficiente o producto no encontrado"));
        return Ok(ApiResponse<object>.Ok(new { Message = "Stock deducido correctamente" }));
    }
}

public record DeductRequest(int ProductId, int Quantity);
