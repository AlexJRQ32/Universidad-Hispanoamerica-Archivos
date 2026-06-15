namespace CleanArchitecture.Application.DTOs;

public record CreateProductRequest(string Name, string Description, decimal Price, int Stock);

public record UpdateProductRequest(string Name, string Description, decimal Price, int Stock);

public record ProductResponse(
    int Id,
    string Name,
    string Description,
    decimal Price,
    string Currency,
    int Stock,
    DateTime CreatedAt);
