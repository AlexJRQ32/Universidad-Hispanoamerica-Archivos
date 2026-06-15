namespace Shared.Contracts;

public record InventoryItemDto(int ProductId, int Stock);

public record InventoryUpdateRequest(int ProductId, int QuantityChange);
