using MediatR;

namespace VerticalSlice.Api.Features.Products.CreateProduct;

public static class CreateProductEndpoint
{
    public static void MapEndpoint(WebApplication app)
    {
        app.MapPost("/api/products", async (CreateProductRequest request, ISender mediator) =>
        {
            var command = new Command(request.Name, request.Description, request.Price, request.Stock);
            var created = await mediator.Send(command);
            return Results.Created($"/api/products/{created.Id}", created);
        });
    }

    public record Command(string Name, string Description, decimal Price, int Stock) : IRequest<ProductResponse>;
    public record ProductResponse(int Id, string Name, string Description, decimal Price, int Stock, DateTime CreatedAt);
    public record CreateProductRequest(string Name, string Description, decimal Price, int Stock);

    public class Handler : IRequestHandler<Command, ProductResponse>
    {
        public Task<ProductResponse> Handle(Command request, CancellationToken ct)
        {
            var response = new ProductResponse(
                new Random().Next(100, 999),
                request.Name,
                request.Description,
                request.Price,
                request.Stock,
                DateTime.UtcNow
            );
            return Task.FromResult(response);
        }
    }
}
