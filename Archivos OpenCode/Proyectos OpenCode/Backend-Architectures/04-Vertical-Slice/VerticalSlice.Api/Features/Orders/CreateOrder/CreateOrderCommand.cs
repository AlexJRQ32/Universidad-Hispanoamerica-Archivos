using MediatR;

namespace VerticalSlice.Api.Features.Orders.CreateOrder;

public static class CreateOrderEndpoint
{
    public static void MapEndpoint(WebApplication app)
    {
        app.MapPost("/api/orders", async (CreateOrderRequest request, ISender mediator) =>
        {
            var command = new Command(request.ProductId, request.Quantity);
            var created = await mediator.Send(command);
            return Results.Created($"/api/orders/{created.Id}", created);
        });
    }

    public record Command(int ProductId, int Quantity) : IRequest<OrderResponse>;
    public record OrderResponse(int Id, int ProductId, int Quantity, decimal Total, DateTime CreatedAt);
    public record CreateOrderRequest(int ProductId, int Quantity);

    public class Handler : IRequestHandler<Command, OrderResponse>
    {
        public Task<OrderResponse> Handle(Command request, CancellationToken ct)
        {
            var response = new OrderResponse(
                new Random().Next(1000, 9999),
                request.ProductId,
                request.Quantity,
                request.Quantity * 1000,
                DateTime.UtcNow
            );
            return Task.FromResult(response);
        }
    }
}
