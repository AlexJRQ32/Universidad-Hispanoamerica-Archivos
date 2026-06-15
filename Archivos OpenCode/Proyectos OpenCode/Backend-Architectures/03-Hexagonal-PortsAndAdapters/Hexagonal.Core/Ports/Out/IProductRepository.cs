using Hexagonal.Core.Entities;

namespace Hexagonal.Core.Ports.Out;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(int id);
    Product Add(Product product);
    Product? Update(int id, Product product);
    bool Delete(int id);
}
