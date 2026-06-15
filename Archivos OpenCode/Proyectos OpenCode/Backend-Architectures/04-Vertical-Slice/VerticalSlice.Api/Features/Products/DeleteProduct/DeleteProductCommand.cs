using MediatR;

namespace VerticalSlice.Api.Features.Products.DeleteProduct;

public static class DeleteProductEndpoint
{
    public static void MapEndpoint(WebApplication app)
    {
        app.MapDelete("/api/products/{id:int}", async (int id, ISender mediator) =>
        {
            var command = new Command(id);
            var result = await mediator.Send(command);
            return result ? Results.NoContent() : Results.NotFound();
        });
    }

    public record Command(int Id) : IRequest<bool>;

    public class Handler : IRequestHandler<Command, bool>
    {
        public Task<bool> Handle(Command request, CancellationToken ct)
        {
            return Task.FromResult(true);
        }
    }
}
