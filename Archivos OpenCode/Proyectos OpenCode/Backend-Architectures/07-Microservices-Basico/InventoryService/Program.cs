var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5002");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var inventory = new Dictionary<int, int>
{
    { 1, 10 },  // Producto 1: 10 unidades
    { 2, 50 },  // Producto 2: 50 unidades
    { 3, 30 }   // Producto 3: 30 unidades
};

app.MapGet("/api/inventory", () => Results.Ok(inventory.Select(kv => new { ProductId = kv.Key, Stock = kv.Value })));

app.MapGet("/api/inventory/{productId:int}", (int productId) =>
{
    var stock = inventory.GetValueOrDefault(productId);
    return Results.Ok(new { ProductId = productId, Stock = stock });
});

app.MapPost("/api/inventory/deduct", (DeductRequest request) =>
{
    if (!inventory.ContainsKey(request.ProductId))
        return Results.NotFound(new { Error = "Producto no encontrado" });

    if (inventory[request.ProductId] < request.Quantity)
        return Results.BadRequest(new { Error = "Stock insuficiente" });

    inventory[request.ProductId] -= request.Quantity;
    return Results.Ok(new { ProductId = request.ProductId, RemainingStock = inventory[request.ProductId] });
});

app.MapGet("/health", () => Results.Ok(new { Status = "Healthy", Service = "InventoryService" }));

app.Run();

public record DeductRequest(int ProductId, int Quantity);
