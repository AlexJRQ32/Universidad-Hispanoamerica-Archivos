using Hexagonal.Core.Entities;
using Hexagonal.Core.Ports.Out;

namespace Hexagonal.Adapters.Outbound.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public IEnumerable<Product> GetAll() => _products.ToList();

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public Product Add(Product product)
    {
        product.Id = _nextId++;
        product.CreatedAt = DateTime.UtcNow;
        _products.Add(product);
        return product;
    }

    public Product? Update(int id, Product product)
    {
        var existing = GetById(id);
        if (existing is null) return null;

        existing.Name = product.Name;
        existing.Description = product.Description;
        existing.Price = product.Price;
        existing.Stock = product.Stock;
        return existing;
    }

    public bool Delete(int id)
    {
        var product = GetById(id);
        if (product is null) return false;
        return _products.Remove(product);
    }
}
