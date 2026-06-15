using Hexagonal.Core.Entities;
using Hexagonal.Core.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace Hexagonal.Adapters.Inbound.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(_productService.GetAllProducts());
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _productService.GetProductById(id);
        if (product is null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Create([FromBody] CreateProductRequest request)
    {
        var created = _productService.CreateProduct(
            request.Name, request.Description, request.Price, request.Stock);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Update(int id, [FromBody] UpdateProductRequest request)
    {
        var updated = _productService.UpdateProduct(
            id, request.Name, request.Description, request.Price, request.Stock);
        if (updated is null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _productService.DeleteProduct(id) ? NoContent() : NotFound();
    }
}

public record CreateProductRequest(string Name, string Description, decimal Price, int Stock);
public record UpdateProductRequest(string Name, string Description, decimal Price, int Stock);
