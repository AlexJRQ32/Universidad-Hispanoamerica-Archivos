# Vertical Slice Architecture

## ¿Qué es?

**Vertical Slice** (Rebanada Vertical) organiza el código por **funcionalidades completas** en lugar de por capas técnicas. Cada "slice" o rebanada contiene todo lo necesario para una funcionalidad: desde el endpoint hasta la lógica.

En lugar de tener `Controllers/`, `Services/`, `Models/` separados, cada feature tiene:

```
Features/
  Products/
    CreateProduct/
      CreateProductCommand.cs  ← query/command, handler, endpoint, todo junto
    GetProduct/
      GetProductQuery.cs
    ListProducts/
      ListProductsQuery.cs
```

## ¿Cuándo usarla?

- Proyectos con muchas funcionalidades independientes
- Equipos grandes donde cada equipo es dueño de features completas
- Aplicaciones que crecen orgánicamente
- Cuando quieres evitar los "archivos gigantes" de servicios

## Pros y Contras

| Pros | Contras |
|------|---------|
| ✅ Alta cohesión por feature | ❌ Puede duplicar código entre slices |
| ✅ Fácil de añadir nuevas funcionalidades | ❌ El "shared kernel" debe ser cuidadoso |
| ✅ Cada slice es independiente | ❌ No es adecuada para lógica muy transversal |
| ✅ Fácil de eliminar features | ❌ Requiere buen criterio para dividir slices |
| ✅ Escala con el equipo | ❌ MediatR añade indirección |

## Estructura de Carpetas

```
04-Vertical-Slice/
└── VerticalSlice.Api/
    ├── Features/
    │   ├── Products/
    │   │   ├── CreateProduct/
    │   │   │   └── CreateProductCommand.cs    # Command, Handler, Endpoint
    │   │   ├── GetProduct/
    │   │   │   └── GetProductQuery.cs         # Query, Handler, Endpoint
    │   │   ├── ListProducts/
    │   │   │   └── ListProductsQuery.cs        # Query, Handler, Endpoint
    │   │   ├── UpdateProduct/
    │   │   │   └── UpdateProductCommand.cs    # Command, Handler, Endpoint
    │   │   └── DeleteProduct/
    │   │       └── DeleteProductCommand.cs    # Command, Handler, Endpoint
    │   └── Orders/
    │       ├── CreateOrder/
    │       │   └── CreateOrderCommand.cs
    │       └── GetOrder/
    │           └── GetOrderQuery.cs
    └── Program.cs                             # Registro de MediatR y endpoints
```

## Cada Slice Contiene

Cada archivo de slice contiene en un solo lugar:

1. **Endpoint** (método estático `MapEndpoint`) - define la ruta HTTP
2. **Request** (`Command` o `Query`) - implementa `IRequest<>`
3. **Response** (record) - datos de respuesta
4. **Handler** - implementa `IRequestHandler<>` con la lógica

Esto NO rompe SRP porque cada slice es UNA funcionalidad completa.

## Cómo Ejecutar

```bash
cd Backend-Architectures/04-Vertical-Slice
dotnet build
dotnet run --project VerticalSlice.Api
```

## Endpoints

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/products | Lista productos |
| GET | /api/products/{id} | Obtiene producto |
| POST | /api/products | Crea producto |
| PUT | /api/products/{id} | Actualiza producto |
| DELETE | /api/products/{id} | Elimina producto |
| POST | /api/orders | Crea orden |
| GET | /api/orders/{id} | Obtiene orden |
