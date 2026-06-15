using Shared.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5000");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var products = new List<ProductDto>
{
    new(1, "Laptop Gamer", "RTX 4060, 16GB RAM", 25000, 10),
    new(2, "Mouse", "Logitech G Pro", 1500, 50),
    new(3, "Teclado Mecánico", "Redragon Kumara", 1200, 30)
};
var nextId = 4;

app.MapGet("/api/products", () => Results.Ok(products));

app.MapGet("/api/products/{id:int}", (int id) =>
{
    var product = products.FirstOrDefault(p => p.Id == id);
    return product is null ? Results.NotFound() : Results.Ok(product);
});

app.MapPost("/api/products", (CreateProductRequest request) =>
{
    var product = new ProductDto(nextId++, request.Name, request.Description, request.Price, request.Stock);
    products.Add(product);
    return Results.Created($"/api/products/{product.Id}", product);
});

app.MapGet("/health", () => Results.Ok(new { Status = "Healthy", Service = "ProductsService" }));

app.Run();
