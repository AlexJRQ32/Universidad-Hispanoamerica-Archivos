using FeatureFolder.Api.Features.Inventory.Models;

namespace FeatureFolder.Api.Features.Inventory.Services;

public class InventoryService : IInventoryService
{
    private readonly List<InventoryItem> _items = new()
    {
        new InventoryItem { ProductId = 1, ProductName = "Laptop Gamer", Stock = 10 },
        new InventoryItem { ProductId = 2, ProductName = "Mouse", Stock = 50 },
        new InventoryItem { ProductId = 3, ProductName = "Teclado Mecánico", Stock = 30 }
    };

    public IEnumerable<InventoryItem> GetAll() => _items;

    public InventoryItem? GetByProductId(int productId) =>
        _items.FirstOrDefault(i => i.ProductId == productId);

    public bool DeductStock(int productId, int quantity)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId);
        if (item is null || item.Stock < quantity) return false;
        item.Stock -= quantity;
        return true;
    }

    public bool AddStock(int productId, int quantity)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId);
        if (item is null) return false;
        item.Stock += quantity;
        return true;
    }
}
