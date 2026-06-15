var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5003");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapReverseProxy();

app.MapGet("/health", () => Results.Ok(new
{
    Status = "Healthy",
    Service = "ApiGateway",
    Routes = new[]
    {
        "/products -> ProductsService (puerto 5000)",
        "/orders -> OrdersService (puerto 5001)",
        "/inventory -> InventoryService (puerto 5002)"
    }
}));

app.Run();
