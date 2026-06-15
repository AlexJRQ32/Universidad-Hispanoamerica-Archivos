using FeatureFolder.Api.Features.Orders.Models;

namespace FeatureFolder.Api.Features.Orders.Services;

public interface IOrderService
{
    IEnumerable<OrderResponse> GetAll();
    OrderResponse? GetById(int id);
    OrderResponse Create(CreateOrderRequest request);
}
