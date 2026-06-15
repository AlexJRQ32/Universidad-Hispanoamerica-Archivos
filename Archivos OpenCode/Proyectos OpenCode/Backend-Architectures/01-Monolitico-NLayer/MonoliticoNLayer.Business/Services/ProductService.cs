using MonoliticoNLayer.Business.DTOs;
using MonoliticoNLayer.Business.Interfaces;
using MonoliticoNLayer.Data.Models;
using MonoliticoNLayer.Data.Repositories;

namespace MonoliticoNLayer.Business.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<ProductResponseDto> GetAll()
    {
        return _repository.GetAll().Select(p => MapToDto(p));
    }

    public ProductResponseDto? GetById(int id)
    {
        var product = _repository.GetById(id);
        return product is null ? null : MapToDto(product);
    }

    public ProductResponseDto Create(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock
        };

        var created = _repository.Add(product);
        return MapToDto(created);
    }

    public ProductResponseDto? Update(int id, UpdateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock
        };

        var updated = _repository.Update(id, product);
        return updated is null ? null : MapToDto(updated);
    }

    public bool Delete(int id) => _repository.Delete(id);

    private static ProductResponseDto MapToDto(Product p) =>
        new(p.Id, p.Name, p.Description, p.Price, p.Stock, p.CreatedAt);
}
