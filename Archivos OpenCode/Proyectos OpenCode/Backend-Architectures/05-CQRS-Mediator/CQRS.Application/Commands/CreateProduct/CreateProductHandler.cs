using CQRS.Application.Interfaces;
using CQRS.Application.Models;
using MediatR;

namespace CQRS.Application.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken ct)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock
        };

        var created = await _repository.AddAsync(product);

        return new CreateProductResponse(
            created.Id, created.Name, created.Description,
            created.Price, created.Stock, created.CreatedAt);
    }
}
