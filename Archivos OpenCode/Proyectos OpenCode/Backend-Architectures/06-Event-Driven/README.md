# Arquitectura Orientada a Eventos (Event-Driven)

## ¿Qué es?

La **Arquitectura Orientada a Eventos** se basa en la producción, detección, consumo y reacción a **eventos**. Un evento es un cambio de estado significativo en el sistema.

Cuando un evento ocurre (ej: `OrderCreated`), se publica en un **bus de eventos** y múltiples **handlers** reaccionan de forma desacoplada.

```
OrderCreated → EventBus → SendEmail (handler 1)
                        → UpdateInventory (handler 2)
                        → NotifyShipping (handler 3)
```

## ¿Cuándo usarla?

- Cuando múltiples componentes deben reaccionar a una misma acción
- Para desacoplar productores de consumidores
- Sistemas que requieren escalabilidad y resiliencia
- Flujos de trabajo largos o con múltiples pasos (sagas)
- Integración con sistemas externos

## Pros y Contras

| Pros | Contras |
|------|---------|
| ✅ Alto desacoplamiento entre componentes | ❌ Complejidad en el manejo de errores |
| ✅ Escalabilidad natural | ❌ Dificultad para rastrear el flujo completo |
| ✅ Extensible (agregar handlers sin modificar) | ❌ Consistencia eventual (no inmediata) |
| ✅ Resiliencia (un handler falla, otros funcionan) | ❌ Puede haber duplicación de eventos |
| ✅ Ideal para sistemas distribuidos | ❌ Depuración más compleja |

## Estructura de Carpetas

```
06-Event-Driven/
├── EventDriven.Core/                        # Núcleo de eventos
│   ├── Events/
│   │   └── OrderCreatedEvent.cs             # Definición del evento
│   ├── Bus/
│   │   ├── IEventBus.cs                     # Interfaz del bus (pub/sub)
│   │   └── InMemoryEventBus.cs             # Implementación en memoria
│   ├── Handlers/
│   │   ├── SendEmailHandler.cs              # Handler: envía correo
│   │   └── UpdateInventoryHandler.cs        # Handler: actualiza inventario
│   └── Models/
│       └── Order.cs                         # Modelo de orden
│
├── EventDriven.Api/                         # API REST
│   └── Program.cs                           # Endpoints + suscripción eventos
│
└── README.md
```

## Flujo del Ejemplo

```
POST /api/orders → OrderCreatedEvent → InMemoryEventBus
                                           ↓
                              ┌────────────────────┐
                              ↓                    ↓
                    SendEmailHandler      UpdateInventoryHandler
                    "Correo enviado"      "Inventario actualizado"
```

## Cómo Ejecutar

```bash
cd Backend-Architectures/06-Event-Driven
dotnet build
dotnet run --project EventDriven.Api
```

Al crear una orden, verás en la consola:

```
[EMAIL] Enviando correo a usuario@email.com...
[EMAIL] Confirmación de orden #1 por $3000.00
[EMAIL] Correo enviado correctamente.
[INVENTORY] Actualizando inventario del producto #1...
[INVENTORY] Reduciendo stock en 2 unidades
[INVENTORY] Inventario actualizado correctamente.
```

## Endpoints

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/orders | Lista órdenes creadas |
| POST | /api/orders | Crea orden y dispara eventos |
| GET | /api/events/log | Información del sistema de eventos |
