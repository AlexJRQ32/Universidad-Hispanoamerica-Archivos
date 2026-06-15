using CQRS.Application.Interfaces;
using MediatR;

namespace CQRS.Application.Queries.ListProducts;

public class ListProductsHandler : IRequestHandler<ListProductsQuery, IEnumerable<ProductListItem>>
{
    private readonly IProductRepository _repository;

    public ListProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductListItem>> Handle(ListProductsQuery request, CancellationToken ct)
    {
        var products = await _repository.GetAllAsync();
        return products.Select(p => new ProductListItem(p.Id, p.Name, p.Price, p.Stock));
    }
}
