using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.UseCases.Products;

public class GetProductByIdUseCase
{
    private readonly IProductRepository _repository;

    public GetProductByIdUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductResponse?> ExecuteAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product is null) return null;

        return new ProductResponse(
            product.Id, product.Name, product.Description,
            product.Price.Amount, product.Price.Currency,
            product.Stock, product.CreatedAt);
    }
}
