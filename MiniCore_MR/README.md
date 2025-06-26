# Sistema de C�lculo de Comisiones - MinCore Ventas

**Aplicaci�n ASP.NET Core MVC** para el c�lculo automatizado de comisiones de ventas basado en reglas configurables.

## Caracter�sticas principales

- C�lculo autom�tico de comisiones por rangos de fechas
- Configuraci�n flexible de reglas de comisi�n
- Visualizaci�n detallada por vendedor
- Integraci�n con SQL Server
- Despliegue listo para Render/Docker

## Tecnolog�as utilizadas

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



