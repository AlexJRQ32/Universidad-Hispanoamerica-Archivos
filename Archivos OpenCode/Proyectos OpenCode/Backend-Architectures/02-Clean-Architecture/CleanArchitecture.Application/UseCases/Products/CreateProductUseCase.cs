using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Application.UseCases.Products;

public class CreateProductUseCase
{
    private readonly IProductRepository _repository;

    public CreateProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductResponse> ExecuteAsync(CreateProductRequest request)
    {
        var price = new Price(request.Price);
        var product = new Product(request.Name, request.Description, price, request.Stock);

        var created = await _repository.AddAsync(product);

        return new ProductResponse(
            created.Id, created.Name, created.Description,
            created.Price.Amount, created.Price.Currency,
            created.Stock, created.CreatedAt);
    }
}
