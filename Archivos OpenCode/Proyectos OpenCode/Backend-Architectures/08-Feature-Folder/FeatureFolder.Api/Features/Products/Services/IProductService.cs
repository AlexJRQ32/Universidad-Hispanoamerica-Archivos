using FeatureFolder.Api.Features.Products.Models;

namespace FeatureFolder.Api.Features.Products.Services;

public interface IProductService
{
    IEnumerable<ProductResponse> GetAll();
    ProductResponse? GetById(int id);
    ProductResponse Create(CreateProductRequest request);
    ProductResponse? Update(int id, UpdateProductRequest request);
    bool Delete(int id);
}
