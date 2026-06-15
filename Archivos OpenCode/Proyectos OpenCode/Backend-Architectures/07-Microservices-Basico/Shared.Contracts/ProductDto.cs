namespace Shared.Contracts;

public record ProductDto(int Id, string Name, string Description, decimal Price, int Stock);

public record CreateProductRequest(string Name, string Description, decimal Price, int Stock);
