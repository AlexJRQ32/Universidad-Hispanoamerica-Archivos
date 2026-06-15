namespace FeatureFolder.Api.Features.Orders.Models;

public record CreateOrderRequest(int ProductId, int Quantity, string CustomerName);
public record OrderResponse(int Id, int ProductId, int Quantity, decimal Total, string CustomerName, DateTime CreatedAt);
