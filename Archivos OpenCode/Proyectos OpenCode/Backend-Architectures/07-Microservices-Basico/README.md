# Microservicios (Básico)

## ¿Qué es?

La **Arquitectura de Microservicios** divide una aplicación en **servicios pequeños e independientes**, cada uno con su propia base de datos y lógica de negocio. Se comunican entre sí a través de HTTP (REST) o mensajería asíncrona.

Este proyecto simula 3 microservicios con un **API Gateway** usando **YARP Reverse Proxy**:

```
                    ┌─────────────────┐
                    │   ApiGateway    │  (puerto 5003)
                    │   YARP Proxy    │
                    └────────┬────────┘
                             │
              ┌──────────────┼──────────────┐
              ↓              ↓              ↓
     ┌────────────┐ ┌────────────┐ ┌────────────┐
     │  Products  │ │   Orders  │ │ Inventory  │
     │  Service   │ │  Service  │ │  Service   │
     │ :5000      │ │ :5001     │ │ :5002      │
     └────────────┘ └────────────┘ └────────────┘
```

## ¿Cuándo usarla?

- Aplicaciones grandes con dominios claramente separados
- Equipos independientes por cada servicio
- Necesidad de escalar componentes individualmente
- Diferentes requisitos tecnológicos por módulo
- Despliegue independiente y frecuente

## Pros y Contras

| Pros | Contras |
|------|---------|
| ✅ Despliegue independiente | ❌ Complejidad de red y comunicación |
| ✅ Escalabilidad granular | ❌ Consistencia eventual entre servicios |
| ✅ Aislamiento de fallos | ❌ Mayor uso de recursos |
| ✅ Equipos autónomos | ❌ Debugging distribuido complejo |
| ✅ Tecnologías heterogéneas | ❌ Gestión de datos distribuida |

## Estructura de Carpetas

```
07-Microservices-Basico/
├── Shared.Contracts/                          # Contratos compartidos
│   ├── ProductDto.cs
│   ├── OrderDto.cs
│   └── InventoryDto.cs
│
├── ProductsService/                           # Microservicio 1: Productos
│   └── Program.cs                             # CRUD de productos (puerto 5000)
│
├── OrdersService/                             # Microservicio 2: Órdenes
│   └── Program.cs                             # CRUD de órdenes (puerto 5001)
│                                              # Se comunica con Inventory
├── InventoryService/                          # Microservicio 3: Inventario
│   └── Program.cs                             # Control de stock (puerto 5002)
│
├── ApiGateway/                                # API Gateway con YARP
│   ├── Program.cs                             # Enrutamiento (puerto 5003)
│   └── appsettings.json                       # Configuración de rutas
│
└── README.md
```

## Cómo Ejecutar

Cada microservicio se ejecuta en una terminal separada:

**Terminal 1 - Products:**
```bash
cd Backend-Architectures/07-Microservices-Basico/ProductsService
dotnet run
```

**Terminal 2 - Inventory:**
```bash
cd Backend-Architectures/07-Microservices-Basico/InventoryService
dotnet run
```

**Terminal 3 - Orders:**
```bash
cd Backend-Architectures/07-Microservices-Basico/OrdersService
dotnet run
```

**Terminal 4 - API Gateway:**
```bash
cd Backend-Architectures/07-Microservices-Basico/ApiGateway
dotnet run
```

O ejecuta todos desde la solución (cada uno en su propia terminal):

```bash
dotnet run --project ProductsService
dotnet run --project InventoryService
dotnet run --project OrdersService
dotnet run --project ApiGateway
```

## Endpoints a través del Gateway

| Gateway | Servicio Interno |
|---------|-----------------|
| GET /products | GET /api/products |
| GET /products/1 | GET /api/products/1 |
| POST /products | POST /api/products |
| GET /orders | GET /api/orders |
| POST /orders | POST /api/orders |
| GET /inventory | GET /api/inventory |
| POST /inventory/deduct | POST /api/inventory/deduct |
