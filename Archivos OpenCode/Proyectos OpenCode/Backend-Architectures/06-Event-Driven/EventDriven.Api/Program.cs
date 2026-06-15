using EventDriven.Core.Bus;
using EventDriven.Core.Events;
using EventDriven.Core.Handlers;
using EventDriven.Core.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEventBus, InMemoryEventBus>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var eventBus = app.Services.GetRequiredService<IEventBus>();

eventBus.Subscribe<OrderCreatedEvent>(e =>
{
    SendEmailHandler.Handle(e.CustomerEmail, e.OrderId, e.Total);
});

eventBus.Subscribe<OrderCreatedEvent>(e =>
{
    UpdateInventoryHandler.Handle(e.ProductId, e.Quantity);
});

var orders = new List<Order>();
var nextId = 1;

app.MapPost("/api/orders", (CreateOrderRequest request) =>
{
    var order = new Order
    {
        Id = nextId++,
        ProductId = request.ProductId,
        Quantity = request.Quantity,
        Total = request.Quantity * 1500,
        CustomerEmail = request.CustomerEmail
    };
    orders.Add(order);

    var orderEvent = new OrderCreatedEvent(order.Id, order.ProductId, order.Quantity, order.Total, order.CustomerEmail);
    eventBus.Publish(orderEvent);

    return Results.Created($"/api/orders/{order.Id}", order);
});

app.MapGet("/api/orders", () =>
{
    return Results.Ok(orders);
});

app.MapGet("/api/events/log", () =>
{
    return Results.Ok(new
    {
        Message = "Los eventos se ejecutan de forma asíncrona y sus efectos (email, inventario) se ven en la consola del servidor."
    });
});

app.Run();

public record CreateOrderRequest(int ProductId, int Quantity, string CustomerEmail);
