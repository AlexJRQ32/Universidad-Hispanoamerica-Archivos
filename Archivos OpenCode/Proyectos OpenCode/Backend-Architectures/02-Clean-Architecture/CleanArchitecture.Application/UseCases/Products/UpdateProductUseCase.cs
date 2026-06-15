using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Application.UseCases.Products;

public class UpdateProductUseCase
{
    private readonly IProductRepository _repository;

    public UpdateProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductResponse?> ExecuteAsync(int id, UpdateProductRequest request)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return null;

        var price = new Price(request.Price);
        existing.Update(request.Name, request.Description, price, request.Stock);

        var updated = await _repository.UpdateAsync(id, existing);
        if (updated is null) return null;

        return new ProductResponse(
            updated.Id, updated.Name, updated.Description,
            updated.Price.Amount, updated.Price.Currency,
            updated.Stock, updated.CreatedAt);
    }
}
