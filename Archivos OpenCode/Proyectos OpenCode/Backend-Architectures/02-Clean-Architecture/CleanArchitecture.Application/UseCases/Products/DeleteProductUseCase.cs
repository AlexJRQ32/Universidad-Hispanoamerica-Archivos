using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.UseCases.Products;

public class DeleteProductUseCase
{
    private readonly IProductRepository _repository;

    public DeleteProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExecuteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
