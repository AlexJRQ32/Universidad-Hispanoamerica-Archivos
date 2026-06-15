using MediatR;

namespace CQRS.Application.Queries.GetProduct;

public record GetProductQuery(int Id) : IRequest<ProductDetail?>;

public record ProductDetail(int Id, string Name, string Description, decimal Price, int Stock, DateTime CreatedAt);
