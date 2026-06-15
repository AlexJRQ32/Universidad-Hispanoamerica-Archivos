using MonoliticoNLayer.Business.DTOs;

namespace MonoliticoNLayer.Business.Interfaces;

public interface IProductService
{
    IEnumerable<ProductResponseDto> GetAll();
    ProductResponseDto? GetById(int id);
    ProductResponseDto Create(CreateProductDto dto);
    ProductResponseDto? Update(int id, UpdateProductDto dto);
    bool Delete(int id);
}
