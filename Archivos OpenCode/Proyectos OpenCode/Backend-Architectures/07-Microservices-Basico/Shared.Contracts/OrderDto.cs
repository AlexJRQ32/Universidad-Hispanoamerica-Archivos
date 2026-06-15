namespace Shared.Contracts;

public record OrderDto(int Id, int ProductId, int Quantity, decimal Total, DateTime CreatedAt);

public record CreateOrderRequest(int ProductId, int Quantity, string CustomerEmail);
