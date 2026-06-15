using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.UseCases.Products;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly GetAllProductsUseCase _getAll;
    private readonly GetProductByIdUseCase _getById;
    private readonly CreateProductUseCase _create;
    private readonly UpdateProductUseCase _update;
    private readonly DeleteProductUseCase _delete;

    public ProductsController(
        GetAllProductsUseCase getAll,
        GetProductByIdUseCase getById,
        CreateProductUseCase create,
        UpdateProductUseCase update,
        DeleteProductUseCase delete)
    {
        _getAll = getAll;
        _getById = getById;
        _create = create;
        _update = update;
        _delete = delete;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAll()
    {
        var products = await _getAll.ExecuteAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> GetById(int id)
    {
        var product = await _getById.ExecuteAsync(id);
        if (product is null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductResponse>> Create([FromBody] CreateProductRequest request)
    {
        var created = await _create.ExecuteAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductResponse>> Update(int id, [FromBody] UpdateProductRequest request)
    {
        var updated = await _update.ExecuteAsync(id, request);
        if (updated is null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _delete.ExecuteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
