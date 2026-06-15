# Arquitectura Hexagonal (Ports & Adapters)

## ¿Qué es?

La **Arquitectura Hexagonal** (también conocida como **Puertos y Adaptadores**) fue creada por Alistair Cockburn. Organiza la aplicación en un **núcleo (Core)** que contiene la lógica de negocio pura, y **adaptadores** que se conectan al núcleo a través de **puertos (interfaces)**.

```
[Adaptador Inbound] → [Puerto In] → [Core/Negocio] → [Puerto Out] → [Adaptador Outbound]
  (Controller)        (Interface)     (Servicios)     (Interface)      (Repository)
```

## ¿Cuándo usarla?

- Aplicaciones donde la lógica de negocio debe ser independiente de la tecnología
- Cuando necesitas cambiar fácilmente de base de datos, API, o UI
- Sistemas con múltiples formas de entrada (API REST, gRPC, CLI, colas)
- Proyectos que se conectan a múltiples fuentes de datos externas

## Pros y Contras

| Pros | Contras |
|------|---------|
| ✅ Core completamente aislado de frameworks | ❌ Mayor número de interfaces |
| ✅ Fácil de probar (mocks en los puertos) | ❌ Puede ser abstracto al principio |
| ✅ Cambiar DB o UI sin tocar el core | ❌ Más boilerplate que N-Layer |
| ✅ Múltiples adaptadores para un mismo puerto | ❌ Requiere disciplina arquitectónica |
| ✅ Clara separación entre "inside" y "outside" | ❌ El wiring de DI puede ser complejo |

## Estructura de Carpetas

```
03-Hexagonal-PortsAndAdapters/
├── Hexagonal.Core/                         # Núcleo (sin dependencias externas)
│   ├── Entities/
│   │   └── Product.cs                      # Entidad de dominio
│   ├── Ports/
│   │   ├── In/
│   │   │   └── IProductService.cs          # Puerto de entrada (driving port)
│   │   └── Out/
│   │       └── IProductRepository.cs       # Puerto de salida (driven port)
│   └── Services/
│       └── ProductService.cs              # Lógica de negocio pura
│
├── Hexagonal.Adapters.Inbound/             # Adaptadores de entrada (driving)
│   ├── Controllers/
│   │   └── ProductsController.cs          # API REST → Puerto IProductService
│   └── Program.cs                         # Composition root
│
├── Hexagonal.Adapters.Outbound/            # Adaptadores de salida (driven)
│   └── Repositories/
│       └── ProductRepository.cs           # Implementa IProductRepository
│
└── README.md
```

## Flujo de Datos

```
Cliente HTTP → [Controller] → [IProductService] → [ProductService] → [IProductRepository] → [ProductRepository] → Memoria
               (Adapter In)    (Port In)           (Core)             (Port Out)             (Adapter Out)
```

## Cómo Ejecutar

```bash
cd Backend-Architectures/03-Hexagonal-PortsAndAdapters
dotnet build
dotnet run --project Hexagonal.Adapters.Inbound
```

## Endpoints

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/products | Lista todos los productos |
| GET | /api/products/{id} | Obtiene un producto |
| POST | /api/products | Crea un producto |
| PUT | /api/products/{id} | Actualiza un producto |
| DELETE | /api/products/{id} | Elimina un producto |
