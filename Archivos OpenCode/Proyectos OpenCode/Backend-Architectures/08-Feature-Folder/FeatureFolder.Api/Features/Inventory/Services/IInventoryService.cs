using FeatureFolder.Api.Features.Inventory.Models;

namespace FeatureFolder.Api.Features.Inventory.Services;

public interface IInventoryService
{
    IEnumerable<InventoryItem> GetAll();
    InventoryItem? GetByProductId(int productId);
    bool DeductStock(int productId, int quantity);
    bool AddStock(int productId, int quantity);
}
