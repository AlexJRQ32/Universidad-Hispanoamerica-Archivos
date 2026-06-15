using CQRS.Application.Interfaces;
using MediatR;

namespace CQRS.Application.Queries.GetProduct;

public class GetProductHandler : IRequestHandler<GetProductQuery, ProductDetail?>
{
    private readonly IProductRepository _repository;

    public GetProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductDetail?> Handle(GetProductQuery request, CancellationToken ct)
    {
        var product = await _repository.GetByIdAsync(request.Id);
        if (product is null) return null;

        return new ProductDetail(
            product.Id, product.Name, product.Description,
            product.Price, product.Stock, product.CreatedAt);
    }
}
