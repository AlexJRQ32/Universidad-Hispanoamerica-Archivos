using MediatR;

namespace CQRS.Application.Commands.UpdateProduct;

public record UpdateProductCommand(int Id, string Name, string Description, decimal Price, int Stock)
    : IRequest<bool>;
