using Shared.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5001");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("Inventory", c => c.BaseAddress = new Uri("http://localhost:5002"));
builder.Services.AddHttpClient("Products", c => c.BaseAddress = new Uri("http://localhost:5000"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var orders = new List<OrderDto>();
var nextId = 1;

app.MapGet("/api/orders", () => Results.Ok(orders));

app.MapGet("/api/orders/{id:int}", (int id) =>
{
    var order = orders.FirstOrDefault(o => o.Id == id);
    return order is null ? Results.NotFound() : Results.Ok(order);
});

app.MapPost("/api/orders", async (CreateOrderRequest request, IHttpClientFactory httpFactory) =>
{
    var inventoryClient = httpFactory.CreateClient("Inventory");
    var inventoryResponse = await inventoryClient.PostAsJsonAsync("/api/inventory/deduct",
        new { ProductId = request.ProductId, Quantity = request.Quantity });

    if (!inventoryResponse.IsSuccessStatusCode)
        return Results.BadRequest(new { Error = "No hay suficiente inventario" });

    var order = new OrderDto(nextId++, request.ProductId, request.Quantity,
        request.Quantity * 1500, DateTime.UtcNow);
    orders.Add(order);

    return Results.Created($"/api/orders/{order.Id}", order);
});

app.MapGet("/health", () => Results.Ok(new { Status = "Healthy", Service = "OrdersService" }));

app.Run();
