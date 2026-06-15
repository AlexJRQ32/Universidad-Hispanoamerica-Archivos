using Hexagonal.Core.Entities;

namespace Hexagonal.Core.Ports.In;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    Product? GetProductById(int id);
    Product CreateProduct(string name, string description, decimal price, int stock);
    Product? UpdateProduct(int id, string name, string description, decimal price, int stock);
    bool DeleteProduct(int id);
}
