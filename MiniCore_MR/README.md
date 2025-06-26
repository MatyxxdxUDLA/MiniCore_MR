# Sistema de Cálculo de Comisiones - MinCore Ventas

**Aplicación ASP.NET Core MVC** para el cálculo automatizado de comisiones de ventas basado en reglas configurables.

## Características principales

- Cálculo automático de comisiones por rangos de fechas
- Configuración flexible de reglas de comisión
- Visualización detallada por vendedor
- Integración con SQL Server
- Despliegue listo para Render/Docker

## Tecnologías utilizadas

- ASP.NET Core 7.0 MVC
- Entity Framework Core
- SQL Server
- Docker (para despliegue)
- Bootstrap 5 (interfaz)

## Estructura de la base de datos

```mermaid
erDiagram
    VENDEDOR ||--o{ VENTA : "1-N"
    VENDEDOR {
        int id PK
        nvarchar(100) usuario
    }
    VENTA {
        int id PK
        date fecha_venta
        int vendedor_id FK
        decimal(10,2) monto
    }
    REGLAS {
        int id PK
        decimal(5,2) regla
        decimal(10,2) valor
    }

Requisitos:

.NET 7.0 SDK

SQL Server



