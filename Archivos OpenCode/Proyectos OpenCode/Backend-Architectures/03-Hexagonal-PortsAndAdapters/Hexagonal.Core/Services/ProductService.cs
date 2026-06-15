using Hexagonal.Core.Entities;
using Hexagonal.Core.Ports.In;
using Hexagonal.Core.Ports.Out;

namespace Hexagonal.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Product> GetAllProducts() => _repository.GetAll();

    public Product? GetProductById(int id) => _repository.GetById(id);

    public Product CreateProduct(string name, string description, decimal price, int stock)
    {
        var product = new Product
        {
            Name = name,
            Description = description,
            Price = price,
            Stock = stock
        };
        return _repository.Add(product);
    }

    public Product? UpdateProduct(int id, string name, string description, decimal price, int stock)
    {
        var product = new Product
        {
            Name = name,
            Description = description,
            Price = price,
            Stock = stock
        };
        return _repository.Update(id, product);
    }

    public bool DeleteProduct(int id) => _repository.Delete(id);
}
