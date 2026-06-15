using FeatureFolder.Api.Features.Products.Models;
using FeatureFolder.Shared.Models;

namespace FeatureFolder.Api.Features.Orders.Models;

public class Order : BaseEntity
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    public string CustomerName { get; set; } = string.Empty;
}
