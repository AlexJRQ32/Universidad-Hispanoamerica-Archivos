using MediatR;

namespace VerticalSlice.Api.Features.Products.UpdateProduct;

public static class UpdateProductEndpoint
{
    public static void MapEndpoint(WebApplication app)
    {
        app.MapPut("/api/products/{id:int}", async (int id, UpdateProductRequest request, ISender mediator) =>
        {
            var command = new Command(id, request.Name, request.Description, request.Price, request.Stock);
            var result = await mediator.Send(command);
            return result ? Results.NoContent() : Results.NotFound();
        });
    }

    public record Command(int Id, string Name, string Description, decimal Price, int Stock) : IRequest<bool>;
    public record UpdateProductRequest(string Name, string Description, decimal Price, int Stock);

    public class Handler : IRequestHandler<Command, bool>
    {
        public Task<bool> Handle(Command request, CancellationToken ct)
        {
            return Task.FromResult(true);
        }
    }
}
