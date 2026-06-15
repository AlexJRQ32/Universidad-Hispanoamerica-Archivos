using FeatureFolder.Api.Features.Products.Models;

namespace FeatureFolder.Api.Features.Products.Validators;

public static class ProductValidator
{
    public static (bool IsValid, string? Error) Validate(CreateProductRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return (false, "El nombre del producto es requerido");
        if (request.Price <= 0)
            return (false, "El precio debe ser mayor a cero");
        if (request.Stock < 0)
            return (false, "El stock no puede ser negativo");
        return (true, null);
    }

    public static (bool IsValid, string? Error) Validate(UpdateProductRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return (false, "El nombre del producto es requerido");
        if (request.Price <= 0)
            return (false, "El precio debe ser mayor a cero");
        if (request.Stock < 0)
            return (false, "El stock no puede ser negativo");
        return (true, null);
    }
}
