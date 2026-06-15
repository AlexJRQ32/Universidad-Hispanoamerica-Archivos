namespace MonoliticoNLayer.Business.DTOs;

public record CreateProductDto(string Name, string Description, decimal Price, int Stock);

public record UpdateProductDto(string Name, string Description, decimal Price, int Stock);

public record ProductResponseDto(int Id, string Name, string Description, decimal Price, int Stock, DateTime CreatedAt);
