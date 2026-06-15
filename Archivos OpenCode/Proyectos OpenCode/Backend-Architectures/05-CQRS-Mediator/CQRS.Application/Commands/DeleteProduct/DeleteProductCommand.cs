using MediatR;

namespace CQRS.Application.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest<bool>;
