# GymTDS - Sistema de gimnasio en consola

Proyecto grupal de la Evaluación 06 de Fundamentos de Programación (TDS-002) en el ITLA, con el profesor Cristian E. Sánchez Ramírez.

## Integrantes

| Integrante | Matrícula | GitHub | Parte que hizo |
|---|---|---|---|
| Cristian Alberto De Luna Santana | 2026-0704 | @cdelunasec | Menú principal (`Program.cs`), validación de entradas (`Entrada.cs`), datos (`Datos.cs`), reporte del gimnasio (`Reportes.cs`) y este README |
| Justin Mercedes | 2026-0701 | @JMercedes00 | Registro, lista y búsqueda de miembros (`Miembros.cs`) |
| Wilfre _(apellido)_ | 2026-0718 | @sl4zyy | Precios, descuentos y pagos (`Pagos.cs`) |

## Descripción

GymTDS es un sistema de consola para llevar el control de un gimnasio pequeño, donde se pueden registrar miembros con su edad y su plan, ver la lista completa, buscar a alguien por su nombre, cobrar los meses de membresía con descuento si paga varios meses de una vez y sacar un reporte con las estadísticas del día.

Los planes que maneja son estos:

| Plan | Precio mensual |
|---|---|
| Básico | RD$ 1,200.00 |
| Premium | RD$ 1,800.00 |
| VIP | RD$ 2,500.00 |

Si el miembro paga 3 meses o más se le hace un 5% de descuento, desde 6 meses es un 10% y si paga el año completo es un 15%.

Al abrir el programa ya vienen cargados tres miembros de ejemplo para que se pueda probar sin tener que registrar a nadie primero. Los datos se guardan en memoria, así que al cerrar el programa se pierden.

## Menú

```
1. Registrar miembro
2. Ver lista de miembros
3. Buscar miembro
4. Registrar pago de membresía
5. Reporte del gimnasio
0. Salir
```

## Cómo ejecutarlo

Hace falta tener instalado el .NET SDK (8, 9 o 10). Desde una terminal:

```bash
git clone <enlace-del-repositorio>
cd sistema-gimnasio-tds002
dotnet run
```

## Dónde está cada requisito

| Requisito | Dónde se cumple |
|---|---|
| Menú con `do-while` + `switch` (5 opciones y Salir) | `Program.cs` |
| Métodos con parámetros | `LeerEntero(mensaje, min, max)`, `LeerTexto(mensaje)`, `PrecioPlan(plan)`, `CalcularDescuento(meses)`, `NombrePlan(plan)`, `BuscarIndice(nombre)`, `ContarPorPlan(plan)` |
| Métodos con `return` | `LeerEntero`, `PrecioPlan`, `CalcularDescuento`, `CalcularTotal`, `NombrePlan`, `BuscarIndice`, `CalcularEdadPromedio`, `MiembroMasMeses` |
| Decisiones `if` / `switch` | `NombrePlan` y `PrecioPlan` con `switch`, `CalcularDescuento` con `if / else if`, validaciones en `RegistrarMiembro` y `RegistrarPago` |
| Ciclos `for` / `while` | `for` en la lista, la búsqueda y el reporte, `while` en `LeerTexto` y `CalcularEdadPromedio`, `do-while` en `LeerEntero` y en el menú |
| Validación con `TryParse` | `Entrada.LeerEntero`, que se usa para toda entrada numérica |
| Salida con formato | Tablas alineadas con `{valor,-22}`, montos con `:N2`, porcentajes con `:P0`, promedio con `:F1` y colores en mensajes |

## Estructura

```
sistema-gimnasio-tds002/
├── Program.cs        menú principal
├── Entrada.cs        lectura validada y formato de pantalla
├── Datos.cs          arreglos con los datos de los miembros
├── Miembros.cs       registrar, listar y buscar
├── Pagos.cs          precios, descuentos y recibo
├── Reportes.cs       estadísticas del gimnasio
└── SistemaGimnasio.csproj
```
