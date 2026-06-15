using FeatureFolder.Api.Features.Products.Models;
using FeatureFolder.Api.Features.Products.Services;
using FeatureFolder.Api.Features.Products.Validators;
using FeatureFolder.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFolder.Api.Features.Products.Controllers;

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
    public ActionResult<ApiResponse<IEnumerable<ProductResponse>>> GetAll()
    {
        return Ok(ApiResponse<IEnumerable<ProductResponse>>.Ok(_productService.GetAll()));
    }

    [HttpGet("{id}")]
    public ActionResult<ApiResponse<ProductResponse>> GetById(int id)
    {
        var product = _productService.GetById(id);
        if (product is null)
            return NotFound(ApiResponse<ProductResponse>.Fail("Producto no encontrado"));
        return Ok(ApiResponse<ProductResponse>.Ok(product));
    }

    [HttpPost]
    public ActionResult<ApiResponse<ProductResponse>> Create([FromBody] CreateProductRequest request)
    {
        var (isValid, error) = ProductValidator.Validate(request);
        if (!isValid)
            return BadRequest(ApiResponse<ProductResponse>.Fail(error!));

        var created = _productService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id },
            ApiResponse<ProductResponse>.Ok(created));
    }

    [HttpPut("{id}")]
    public ActionResult<ApiResponse<ProductResponse>> Update(int id, [FromBody] UpdateProductRequest request)
    {
        var (isValid, error) = ProductValidator.Validate(request);
        if (!isValid)
            return BadRequest(ApiResponse<ProductResponse>.Fail(error!));

        var updated = _productService.Update(id, request);
        if (updated is null)
            return NotFound(ApiResponse<ProductResponse>.Fail("Producto no encontrado"));
        return Ok(ApiResponse<ProductResponse>.Ok(updated));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _productService.Delete(id)
            ? NoContent()
            : NotFound(ApiResponse<object>.Fail("Producto no encontrado"));
    }
}
