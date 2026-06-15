using MediatR;

namespace VerticalSlice.Api.Features.Orders.GetOrder;

public static class GetOrderEndpoint
{
    public static void MapEndpoint(WebApplication app)
    {
        app.MapGet("/api/orders/{id:int}", async (int id, ISender mediator) =>
        {
            var query = new Query(id);
            var order = await mediator.Send(query);
            return order is null ? Results.NotFound() : Results.Ok(order);
        });
    }

    public record Query(int Id) : IRequest<OrderResponse?>;
    public record OrderResponse(int Id, int ProductId, int Quantity, decimal Total, DateTime CreatedAt);

    public class Handler : IRequestHandler<Query, OrderResponse?>
    {
        public Task<OrderResponse?> Handle(Query request, CancellationToken ct)
        {
            var response = new OrderResponse(
                request.Id, 1, 2, 2000, DateTime.UtcNow
            );
            return Task.FromResult<OrderResponse?>(response);
        }
    }
}
