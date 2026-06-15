using MonoliticoNLayer.Data.Models;

namespace MonoliticoNLayer.Data.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(int id);
    Product Add(Product product);
    Product? Update(int id, Product product);
    bool Delete(int id);
}
