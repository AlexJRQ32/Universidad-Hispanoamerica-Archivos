using CQRS.Application.Interfaces;
using MediatR;

namespace CQRS.Application.Commands.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken ct)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}
