using CQRS.Application;
using CQRS.Application.Commands.CreateProduct;
using CQRS.Application.Commands.DeleteProduct;
using CQRS.Application.Commands.UpdateProduct;
using CQRS.Application.Queries.GetProduct;
using CQRS.Application.Queries.ListProducts;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var products = app.MapGroup("/api/products");

products.MapGet("/", async (ISender sender) =>
{
    var products = await sender.Send(new ListProductsQuery());
    return Results.Ok(products);
});

products.MapGet("/{id:int}", async (int id, ISender sender) =>
{
    var product = await sender.Send(new GetProductQuery(id));
    return product is null ? Results.NotFound() : Results.Ok(product);
});

products.MapPost("/", async (CreateProductCommand command, ISender sender) =>
{
    var created = await sender.Send(command);
    return Results.Created($"/api/products/{created.Id}", created);
});

products.MapPut("/{id:int}", async (int id, UpdateProductCommand command, ISender sender) =>
{
    var updated = await sender.Send(command with { Id = id });
    return updated ? Results.NoContent() : Results.NotFound();
});

products.MapDelete("/{id:int}", async (int id, ISender sender) =>
{
    var deleted = await sender.Send(new DeleteProductCommand(id));
    return deleted ? Results.NoContent() : Results.NotFound();
});

app.Run();
