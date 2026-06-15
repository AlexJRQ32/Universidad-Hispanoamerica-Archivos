# Feature-Folder / Feature-Sliced

## ¿Qué es?

La arquitectura **Feature-Folder** (o Feature-Sliced) organiza el código en **carpetas por funcionalidad (feature)**. Cada feature contiene todo lo que necesita: su **controlador**, **servicio**, **modelos**, **validadores**, etc.

En lugar de tener:

```
Controllers/
    ProductController.cs
    OrderController.cs
Services/
    ProductService.cs
    OrderService.cs
```

Se tiene:

```
Features/
    Products/
        Controllers/
        Services/
        Models/
        Validators/
    Orders/
        Controllers/
        Services/
        Models/
```

## ¿Cuándo usarla?

- Proyectos con features muy diferenciadas
- Equipos donde cada desarrollador se enfoca en una feature
- Cuando quieres que cada feature sea "autocontenida"
- Aplicaciones que crecen añadiendo nuevas funcionalidades

## Pros y Contras

| Pros | Contras |
|------|---------|
| ✅ Alta cohesión: todo lo de una feature está junto | ❌ Puede duplicar lógica compartida |
| ✅ Fácil de navegar: sabes dónde está cada cosa | ❌ El "shared kernel" debe mantenerse limpio |
| ✅ Escalable: solo agregas carpetas | ❌ Sin disciplina, el shared crece sin control |
| ✅ Cada feature es desplegable independientemente | ❌ Puede haber inconsistencias entre features |
| ✅ Baja fricción para nuevos desarrolladores | ❌ No es adecuada para lógica muy transversal |

## Estructura de Carpetas

```
08-Feature-Folder/
├── FeatureFolder.Api/
│   ├── Features/
│   │   ├── Products/                          # Feature: Productos
│   │   │   ├── Controllers/
│   │   │   │   └── ProductsController.cs      # Endpoints REST
│   │   │   ├── Models/
│   │   │   │   ├── Product.cs                 # Entidad
│   │   │   │   └── ProductDto.cs              # DTOs
│   │   │   ├── Services/
│   │   │   │   ├── IProductService.cs         # Contrato
│   │   │   │   └── ProductService.cs          # Implementación
│   │   │   └── Validators/
│   │   │       └── ProductValidator.cs        # Validaciones
│   │   │
│   │   ├── Orders/                            # Feature: Órdenes
│   │   │   ├── Controllers/
│   │   │   │   └── OrdersController.cs
│   │   │   ├── Models/
│   │   │   │   ├── Order.cs
│   │   │   │   └── OrderDto.cs
│   │   │   └── Services/
│   │   │       ├── IOrderService.cs
│   │   │       └── OrderService.cs
│   │   │
│   │   └── Inventory/                         # Feature: Inventario
│   │       ├── Controllers/
│   │       │   └── InventoryController.cs
│   │       ├── Models/
│   │       │   └── InventoryItem.cs
│   │       └── Services/
│   │           ├── IInventoryService.cs
│   │           └── InventoryService.cs
│   │
│   └── Program.cs
│
├── FeatureFolder.Shared/                      # Shared Kernel
│   └── Models/
│       ├── BaseEntity.cs                     # Clase base para entidades
│       └── ApiResponse.cs                    # Response wrapper genérico
│
└── README.md
```

## Diferencia con Vertical Slice

| Feature Folder | Vertical Slice |
|---------------|----------------|
| Separa por capas dentro de cada feature | Todo el código de la feature en un archivo |
| Controller/Services/Models separados | Command/Handler juntos |
| Más estructura interna | Menos archivos totales |
| Mejor para features grandes | Mejor para features pequeñas |

## Cómo Ejecutar

```bash
cd Backend-Architectures/08-Feature-Folder
dotnet build
dotnet run --project FeatureFolder.Api
```

## Endpoints

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/products | Lista productos |
| GET | /api/products/{id} | Obtiene producto |
| POST | /api/products | Crea producto |
| PUT | /api/products/{id} | Actualiza producto |
| DELETE | /api/products/{id} | Elimina producto |
| GET | /api/orders | Lista órdenes |
| GET | /api/orders/{id} | Obtiene orden |
| POST | /api/orders | Crea orden |
| GET | /api/inventory | Lista inventario |
| GET | /api/inventory/{productId} | Stock por producto |
| POST | /api/inventory/deduct | Deduce stock |
