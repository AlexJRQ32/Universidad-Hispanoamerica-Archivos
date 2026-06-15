using MediatR;

namespace CQRS.Application.Queries.ListProducts;

public record ListProductsQuery : IRequest<IEnumerable<ProductListItem>>;

public record ProductListItem(int Id, string Name, decimal Price, int Stock);
