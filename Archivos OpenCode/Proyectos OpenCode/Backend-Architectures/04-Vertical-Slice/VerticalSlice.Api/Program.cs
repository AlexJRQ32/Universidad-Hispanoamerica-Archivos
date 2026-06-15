using VerticalSlice.Api.Features.Products.CreateProduct;
using VerticalSlice.Api.Features.Products.DeleteProduct;
using VerticalSlice.Api.Features.Products.GetProduct;
using VerticalSlice.Api.Features.Products.ListProducts;
using VerticalSlice.Api.Features.Products.UpdateProduct;
using VerticalSlice.Api.Features.Orders.CreateOrder;
using VerticalSlice.Api.Features.Orders.GetOrder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

ListProductsEndpoint.MapEndpoint(app);
GetProductEndpoint.MapEndpoint(app);
CreateProductEndpoint.MapEndpoint(app);
UpdateProductEndpoint.MapEndpoint(app);
DeleteProductEndpoint.MapEndpoint(app);
CreateOrderEndpoint.MapEndpoint(app);
GetOrderEndpoint.MapEndpoint(app);

app.Run();
