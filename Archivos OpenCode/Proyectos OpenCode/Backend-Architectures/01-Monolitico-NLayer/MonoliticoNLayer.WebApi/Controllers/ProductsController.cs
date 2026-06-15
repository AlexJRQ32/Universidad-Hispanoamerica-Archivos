using Microsoft.AspNetCore.Mvc;
using MonoliticoNLayer.Business.DTOs;
using MonoliticoNLayer.Business.Interfaces;

namespace MonoliticoNLayer.WebApi.Controllers;

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
    public ActionResult<IEnumerable<ProductResponseDto>> GetAll()
    {
        return Ok(_productService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<ProductResponseDto> GetById(int id)
    {
        var product = _productService.GetById(id);
        if (product is null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<ProductResponseDto> Create([FromBody] CreateProductDto dto)
    {
        var created = _productService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public ActionResult<ProductResponseDto> Update(int id, [FromBody] UpdateProductDto dto)
    {
        var updated = _productService.Update(id, dto);
        if (updated is null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _productService.Delete(id) ? NoContent() : NotFound();
    }
}
