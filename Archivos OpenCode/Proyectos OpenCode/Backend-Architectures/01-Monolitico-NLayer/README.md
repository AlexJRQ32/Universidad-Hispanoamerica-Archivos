# Arquitectura Monolítica por Capas (N-Layer)

## ¿Qué es?

La arquitectura N-Layer (o en capas) organiza el código en **capas horizontales** donde cada una tiene una responsabilidad específica. Las capas se comunican de forma jerárquica: la capa superior solo conoce a la inferior inmediata.

```
Presentación (WebApi) → Lógica de Negocio (Business) → Acceso a Datos (Data)
```

Cada capa solo depende de la capa inmediatamente inferior, lo que permite cambios aislados.

## ¿Cuándo usarla?

- Proyectos pequeños a medianos con dominio simple
- Equipos que recién se inician en arquitectura de software
- Aplicaciones CRUD sin lógica de negocio compleja
- Cuando necesitas separar responsabilidades sin sobrediseñar

## Pros y Contras

| Pros | Contras |
|------|---------|
| ✅ Simple y fácil de entender | ❌ Puede volverse "lasaña" con muchas capas |
| ✅ Separación clara de responsabilidades | ❌ Acoplamiento a la base de datos |
| ✅ Fácil de testear cada capa | ❌ Las capas inferiores rara vez son reutilizables |
| ✅ Curva de aprendizaje baja | ❌ Tiende a crecer desordenadamente sin disciplina |
| ✅ Buena para dominios anémicos | ❌ No escala bien a largo plazo |

## Estructura de Carpetas

```
01-Monolitico-NLayer/
├── MonoliticoNLayer.WebApi/          # Capa de Presentación
│   ├── Controllers/
│   │   └── ProductsController.cs     # Endpoints REST
│   └── Program.cs                    # Configuración DI y middleware
│
├── MonoliticoNLayer.Business/        # Capa de Lógica de Negocio
│   ├── DTOs/
│   │   └── ProductDto.cs             # Objetos de transferencia
│   ├── Interfaces/
│   │   └── IProductService.cs        # Contrato del servicio
│   └── Services/
│       └── ProductService.cs         # Implementación de negocio
│
├── MonoliticoNLayer.Data/            # Capa de Acceso a Datos
│   ├── Models/
│   │   └── Product.cs                # Entidad de dominio
│   └── Repositories/
│       ├── IProductRepository.cs     # Contrato del repositorio
│       └── ProductRepository.cs      # Implementación (en memoria)
│
└── README.md
```

## Inversión de Dependencias

Aunque es una arquitectura tradicional, aplicamos **inversión de dependencias** mediante interfaces:

- `IProductRepository` en Data → `ProductRepository` implementa
- `IProductService` en Business → `ProductService` implementa
- WebApi conoce interfaces de Business, no implementaciones
- Business conoce interfaces de Data, no implementaciones

El registro en `Program.cs`:

```csharp
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
```

## Cómo Ejecutar

```bash
cd Backend-Architectures/01-Monolitico-NLayer
dotnet build
dotnet run --project MonoliticoNLayer.WebApi
```

La API estará disponible en `https://localhost:5001/swagger` con los endpoints:

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/products | Lista todos los productos |
| GET | /api/products/{id} | Obtiene un producto por ID |
| POST | /api/products | Crea un nuevo producto |
| PUT | /api/products/{id} | Actualiza un producto existente |
| DELETE | /api/products/{id} | Elimina un producto |

## Endpoints de Ejemplo

```json
POST /api/products
{
  "name": "Laptop Gamer",
  "description": "RTX 4060, 16GB RAM",
  "price": 25000.00,
  "stock": 10
}
```
