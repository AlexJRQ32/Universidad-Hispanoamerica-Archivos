using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Price Price { get; private set; }
    public int Stock { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private Product() { }

    public Product(string name, string description, Price price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del producto es requerido");
        if (stock < 0)
            throw new ArgumentException("El stock no puede ser negativo");

        Name = name;
        Description = description ?? string.Empty;
        Price = price;
        Stock = stock;
    }

    public void Update(string name, string description, Price price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del producto es requerido");
        if (stock < 0)
            throw new ArgumentException("El stock no puede ser negativo");

        Name = name;
        Description = description ?? string.Empty;
        Price = price;
        Stock = stock;
    }
}
