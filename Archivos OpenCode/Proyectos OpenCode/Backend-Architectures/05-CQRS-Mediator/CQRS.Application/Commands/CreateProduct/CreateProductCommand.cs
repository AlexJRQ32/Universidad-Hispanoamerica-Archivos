using MediatR;

namespace CQRS.Application.Commands.CreateProduct;

public record CreateProductCommand(string Name, string Description, decimal Price, int Stock)
    : IRequest<CreateProductResponse>;

public record CreateProductResponse(int Id, string Name, string Description, decimal Price, int Stock, DateTime CreatedAt);
