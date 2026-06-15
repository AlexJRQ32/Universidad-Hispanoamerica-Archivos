namespace CleanArchitecture.Domain.ValueObjects;

public record Price
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Price(decimal amount, string currency = "MXN")
    {
        if (amount < 0)
            throw new ArgumentException("El precio no puede ser negativo");
        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("La moneda es requerida");

        Amount = amount;
        Currency = currency.ToUpperInvariant();
    }

    public override string ToString() => $"{Amount:F2} {Currency}";
}
