using MediatR;

namespace VerticalSlice.Api.Features.Products.GetProduct;

public static class GetProductEndpoint
{
    public static void MapEndpoint(WebApplication app)
    {
        app.MapGet("/api/products/{id:int}", async (int id, ISender mediator) =>
        {
            var query = new Query(id);
            var product = await mediator.Send(query);
            return product is null ? Results.NotFound() : Results.Ok(product);
        });
    }

    public record Query(int Id) : IRequest<ProductResponse?>;

    public record ProductResponse(int Id, string Name, string Description, decimal Price, int Stock);

    public class Handler : IRequestHandler<Query, ProductResponse?>
    {
        private static readonly List<ProductDto> _products = new()
        {
            new ProductDto { Id = 1, Name = "Laptop Gamer", Description = "RTX 4060, 16GB RAM", Price = 25000, Stock = 10 },
            new ProductDto { Id = 2, Name = "Mouse", Description = "Logitech G Pro", Price = 1500, Stock = 50 }
        };

        public Task<ProductResponse?> Handle(Query request, CancellationToken ct)
        {
            var product = _products.FirstOrDefault(p => p.Id == request.Id);
            if (product is null) return Task.FromResult<ProductResponse?>(null);

            return Task.FromResult<ProductResponse?>(
                new ProductResponse(product.Id, product.Name, product.Description, product.Price, product.Stock));
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
