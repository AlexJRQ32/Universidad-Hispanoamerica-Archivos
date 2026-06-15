using FeatureFolder.Api.Features.Products.Models;

namespace FeatureFolder.Api.Features.Products.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public IEnumerable<ProductResponse> GetAll()
    {
        return _products.Select(p => MapDto(p));
    }

    public ProductResponse? GetById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return product is null ? null : MapDto(product);
    }

    public ProductResponse Create(CreateProductRequest request)
    {
        var product = new Product
        {
            Id = _nextId++,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock
        };
        _products.Add(product);
        return MapDto(product);
    }

    public ProductResponse? Update(int id, UpdateProductRequest request)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null) return null;

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Stock = request.Stock;
        return MapDto(product);
    }

    public bool Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null) return false;
        return _products.Remove(product);
    }

    private static ProductResponse MapDto(Product p) =>
        new(p.Id, p.Name, p.Description, p.Price, p.Stock, p.CreatedAt);
}
