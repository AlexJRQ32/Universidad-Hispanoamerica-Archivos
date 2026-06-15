using MediatR;

namespace VerticalSlice.Api.Features.Products.ListProducts;

public static class ListProductsEndpoint
{
    public static void MapEndpoint(WebApplication app)
    {
        app.MapGet("/api/products", async (ISender mediator) =>
        {
            var query = new Query();
            var products = await mediator.Send(query);
            return Results.Ok(products);
        });
    }

    public record Query : IRequest<IEnumerable<ProductResponse>>;

    public record ProductResponse(int Id, string Name, string Description, decimal Price, int Stock);

    public class Handler : IRequestHandler<Query, IEnumerable<ProductResponse>>
    {
        private readonly List<ProductDto> _products = new()
        {
            new ProductDto { Id = 1, Name = "Laptop Gamer", Description = "RTX 4060, 16GB RAM", Price = 25000, Stock = 10 },
            new ProductDto { Id = 2, Name = "Mouse", Description = "Logitech G Pro", Price = 1500, Stock = 50 }
        };

        public Task<IEnumerable<ProductResponse>> Handle(Query request, CancellationToken ct)
        {
            var result = _products.Select(p => new ProductResponse(p.Id, p.Name, p.Description, p.Price, p.Stock));
            return Task.FromResult(result);
        }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
