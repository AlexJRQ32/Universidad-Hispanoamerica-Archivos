namespace FeatureFolder.Api.Features.Inventory.Models;

public class InventoryItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Stock { get; set; }
}
