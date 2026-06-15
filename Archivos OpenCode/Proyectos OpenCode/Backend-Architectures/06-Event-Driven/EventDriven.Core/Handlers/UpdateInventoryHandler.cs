namespace EventDriven.Core.Handlers;

public static class UpdateInventoryHandler
{
    public static void Handle(int productId, int quantity)
    {
        Console.WriteLine($"[INVENTORY] Actualizando inventario del producto #{productId}...");
        Console.WriteLine($"[INVENTORY] Reduciendo stock en {quantity} unidades");
        Console.WriteLine($"[INVENTORY] Inventario actualizado correctamente.");
    }
}
