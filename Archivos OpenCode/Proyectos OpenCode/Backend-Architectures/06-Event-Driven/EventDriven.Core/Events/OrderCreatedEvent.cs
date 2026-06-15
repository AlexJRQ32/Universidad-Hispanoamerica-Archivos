namespace EventDriven.Core.Events;

public class OrderCreatedEvent
{
    public int OrderId { get; }
    public int ProductId { get; }
    public int Quantity { get; }
    public decimal Total { get; }
    public string CustomerEmail { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public OrderCreatedEvent(int orderId, int productId, int quantity, decimal total, string customerEmail)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Total = total;
        CustomerEmail = customerEmail;
    }
}
