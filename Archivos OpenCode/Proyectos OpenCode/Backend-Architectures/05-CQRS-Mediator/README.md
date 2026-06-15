# CQRS con Mediator

## ¿Qué es?

**CQRS (Command Query Responsibility Segregation)** separa las operaciones de **escritura (Commands)** de las operaciones de **lectura (Queries)**.

- **Commands:** Cambian el estado (Create, Update, Delete). No retornan datos de dominio.
- **Queries:** Leen el estado. No modifican datos.

El **Mediator** desacopla el emisor del receptor. Los controladores envían commands/queries y los handlers los procesan.

```
Cliente → Controller → MediatR → Handler (Command/Query)
                                      ↓
                               Repository → Datos
```

## ¿Cuándo usarla?

- Cuando las operaciones de lectura y escritura tienen requisitos diferentes
- Modelos de lectura (read models) simplificados vs modelos de escritura (write models) complejos
- Aplicaciones donde el volumen de lecturas es muy superior al de escrituras
- Cuando necesitas escalar lecturas y escrituras por separado

## Pros y Contras

| Pros | Contras |
|------|---------|
| ✅ Separación total de concerns | ❌ Complejidad adicional |
| ✅ Escalabilidad independiente | ❌ No apta para CRUD simples |
| ✅ Modelos optimizados por operación | ❌ Puede haber duplicación |
| ✅ Compatible con Event Sourcing | ❌ Mayor número de archivos |
| ✅ MediatR simplifica la implementación | ❌ Curva de aprendizaje |

## Estructura de Carpetas

```
05-CQRS-Mediator/
├── CQRS.Application/                        # Capa de aplicación
│   ├── Commands/                             # Operaciones de escritura
│   │   ├── CreateProduct/
│   │   │   ├── CreateProductCommand.cs       # Lo que se envía
│   │   │   └── CreateProductHandler.cs       # Lo que procesa
│   │   ├── UpdateProduct/
│   │   │   ├── UpdateProductCommand.cs
│   │   │   └── UpdateProductHandler.cs
│   │   └── DeleteProduct/
│   │       ├── DeleteProductCommand.cs
│   │       └── DeleteProductHandler.cs
│   ├── Queries/                              # Operaciones de lectura
│   │   ├── ListProducts/
│   │   │   ├── ListProductsQuery.cs
│   │   │   └── ListProductsHandler.cs
│   │   └── GetProduct/
│   │       ├── GetProductQuery.cs
│   │       └── GetProductHandler.cs
│   ├── Interfaces/
│   │   ├── IProductRepository.cs             # Puerto de repositorio
│   │   └── ProductRepository.cs              # Implementación en memoria
│   ├── Models/
│   │   └── Product.cs                        # Modelo de escritura
│   └── DependencyInjection.cs
│
├── CQRS.Api/                                 # Capa de presentación
│   └── Program.cs                            # Endpoints + DI
│
└── README.md
```

## Diferencia Clave: Commands vs Queries

| Commands | Queries |
|----------|---------|
| Cambian el estado | Solo leen datos |
| No retornan datos de negocio | Retornan DTOs/ViewModels |
| Usan verbos: Create, Update, Delete | Usan sustantivos: Get, List |
| Pueden disparar eventos | Nunca disparan eventos |
| Validan reglas de negocio | Optimizan para lectura |

## Cómo Ejecutar

```bash
cd Backend-Architectures/05-CQRS-Mediator
dotnet build
dotnet run --project CQRS.Api
```

## Endpoints

| Método | Ruta | Descripción | Tipo |
|--------|------|-------------|------|
| GET | /api/products | Lista productos | Query |
| GET | /api/products/{id} | Obtiene producto | Query |
| POST | /api/products | Crea producto | Command |
| PUT | /api/products/{id} | Actualiza producto | Command |
| DELETE | /api/products/{id} | Elimina producto | Command |
