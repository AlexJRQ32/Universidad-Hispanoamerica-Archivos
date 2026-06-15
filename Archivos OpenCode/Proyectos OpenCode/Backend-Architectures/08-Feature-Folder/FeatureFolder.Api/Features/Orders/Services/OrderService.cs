using FeatureFolder.Api.Features.Orders.Models;

namespace FeatureFolder.Api.Features.Orders.Services;

public class OrderService : IOrderService
{
    private readonly List<Order> _orders = new();
    private int _nextId = 1;

    public IEnumerable<OrderResponse> GetAll()
    {
        return _orders.Select(o => new OrderResponse(
            o.Id, o.ProductId, o.Quantity, o.Total, o.CustomerName, o.CreatedAt));
    }

    public OrderResponse? GetById(int id)
    {
        var order = _orders.FirstOrDefault(o => o.Id == id);
        if (order is null) return null;
        return new OrderResponse(order.Id, order.ProductId, order.Quantity,
            order.Total, order.CustomerName, order.CreatedAt);
    }

    public OrderResponse Create(CreateOrderRequest request)
    {
        var order = new Order
        {
            Id = _nextId++,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            Total = request.Quantity * 1500,
            CustomerName = request.CustomerName
        };
        _orders.Add(order);
        return new OrderResponse(order.Id, order.ProductId, order.Quantity,
            order.Total, order.CustomerName, order.CreatedAt);
    }
}
