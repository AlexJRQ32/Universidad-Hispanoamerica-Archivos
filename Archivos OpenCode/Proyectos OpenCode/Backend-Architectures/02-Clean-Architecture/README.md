# Arquitectura Limpia (Clean Architecture)

## ¿Qué es?

La Clean Architecture (Arquitectura Limpia) de Robert C. Martin organiza el código en **capas concéntricas** donde las dependencias apuntan hacia adentro: el **Dominio** está en el centro y nunca depende de nada externo.

```
WebApi → Application → Domain
     ↘         ↓
      Infrastructure (implementa interfaces del Domain/Application)
```

**Regla de Dependencia:** Las dependencias solo pueden apuntar hacia adentro. El círculo interior no sabe nada del exterior.

## ¿Cuándo usarla?

- Proyectos con lógica de negocio compleja
- Aplicaciones que necesitan mantenerse a largo plazo
- Cuando quieres proteger la lógica de negocio de cambios tecnológicos
- Equipos que practican Domain-Driven Design (DDD)
- Proyectos que pueden cambiar de base de datos, UI o framework

## Pros y Contras

| Pros | Contras |
|------|---------|
| ✅ Independencia total del framework | ❌ Curva de aprendizaje alta |
| ✅ Testeable (cada capa por separado) | ❌ Overhead inicial de estructura |
| ✅ Independencia de UI, DB, servicios externos | ❌ Muchas interfaces y abstracciones |
| ✅ El dominio es el centro de todo | ❌ Puede ser sobrediseño para proyectos simples |
| ✅ Alta mantenibilidad a largo plazo | ❌ Mayor cantidad de código boilerplate |

## Estructura de Carpetas

```
02-Clean-Architecture/
├── CleanArchitecture.Domain/                  # Capa más interna (Core)
│   ├── Entities/
│   │   └── Product.cs                          # Entidad con reglas de negocio
│   ├── ValueObjects/
│   │   └── Price.cs                            # Value Object (inmutable)
│   └── Interfaces/
│       └── IProductRepository.cs               # Puerto (Port) de salida
│
├── CleanArchitecture.Application/              # Casos de uso
│   ├── DTOs/
│   │   └── ProductDto.cs                        # Objetos de transferencia
│   ├── UseCases/
│   │   └── Products/
│   │       ├── CreateProductUseCase.cs          # Caso de uso: crear
│   │       ├── GetAllProductsUseCase.cs         # Caso de uso: listar
│   │       ├── GetProductByIdUseCase.cs         # Caso de uso: obtener
│   │       ├── UpdateProductUseCase.cs          # Caso de uso: actualizar
│   │       └── DeleteProductUseCase.cs          # Caso de uso: eliminar
│   └── DependencyInjection.cs
│
├── CleanArchitecture.Infrastructure/           # Adaptadores externos
│   ├── Repositories/
│   │   └── ProductRepository.cs                # Implementación del puerto
│   └── DependencyInjection.cs
│
├── CleanArchitecture.WebApi/                   # Capa de presentación (API)
│   ├── Controllers/
│   │   └── ProductsController.cs
│   └── Program.cs
│
└── README.md
```

## Flujo de Datos

```
Request → Controller → UseCase → Domain Entity → Repository (Interface)
                                          ↓
                               Infrastructure.Repository (implementación)
```

## Value Objects

El **Value Object** `Price` encapsula el precio y la moneda como un objeto inmutable:

```csharp
public record Price
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Price(decimal amount, string currency = "MXN")
    {
        if (amount < 0)
            throw new ArgumentException("El precio no puede ser negativo");
        Amount = amount;
        Currency = currency.ToUpperInvariant();
    }
}
```

## Cómo Ejecutar

```bash
cd Backend-Architectures/02-Clean-Architecture
dotnet build
dotnet run --project CleanArchitecture.WebApi
```

## Endpoints

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/products | Lista todos los productos |
| GET | /api/products/{id} | Obtiene un producto |
| POST | /api/products | Crea un producto |
| PUT | /api/products/{id} | Actualiza un producto |
| DELETE | /api/products/{id} | Elimina un producto |
