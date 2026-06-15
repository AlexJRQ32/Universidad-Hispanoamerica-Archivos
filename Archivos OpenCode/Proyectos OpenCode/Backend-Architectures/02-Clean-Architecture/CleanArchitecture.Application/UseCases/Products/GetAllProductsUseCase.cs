using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.UseCases.Products;

public class GetAllProductsUseCase
{
    private readonly IProductRepository _repository;

    public GetAllProductsUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductResponse>> ExecuteAsync()
    {
        var products = await _repository.GetAllAsync();
        return products.Select(p => new ProductResponse(
            p.Id, p.Name, p.Description,
            p.Price.Amount, p.Price.Currency,
            p.Stock, p.CreatedAt));
    }
}
