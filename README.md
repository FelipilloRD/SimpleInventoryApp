# SimpleInventoryApp — Sistema de Inventario Simple

## Descripción

**SimpleInventoryApp** es una aplicación de consola desarrollada en **C# con .NET** que permite gestionar un inventario de productos de forma sencilla. Los datos se almacenan en memoria utilizando listas y diccionarios.

## Funcionalidades

El sistema cuenta con las siguientes opciones disponibles desde un menú interactivo:

| Opción | Función | Descripción |
|--------|---------|-------------|
| 1 | **Agregar producto** | Registra un nuevo producto con nombre, precio y cantidad en stock |
| 2 | **Listar productos** | Muestra todos los productos registrados en formato de tabla |
| 3 | **Buscar producto** | Busca por ID exacto o por coincidencia parcial de nombre |
| 4 | **Modificar producto** | Permite editar el nombre, precio y stock de un producto existente |
| 5 | **Eliminar producto** | Elimina un producto con confirmación previa (Sí/No) |
| 6 | **Salir** | Cierra la aplicación |

## Características Técnicas

- **C# moderno** con top-level statements (sin `class Program` ni `static void Main`)
- **Estructura de control**: bucle `while (running)` con `switch` para el menú
- **Almacenamiento en memoria**: `List<int>`, `Dictionary<int, string>`, `Dictionary<int, decimal>`, `Dictionary<int, int>`
- **Manejo de errores**: validación con `TryParse` y bloques `try-catch` para evitar cierres inesperados
- El programa **no se cierra** hasta que el usuario seleccione explícitamente la opción "Salir"

## Requisitos Previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download) o superior instalado en el sistema

## Cómo Ejecutar

1. Abra una terminal o línea de comandos
2. Navegue hasta la carpeta del proyecto:
   ```bash
   cd SimpleInventoryApp
   ```
3. Ejecute la aplicación con el siguiente comando:
   ```bash
   dotnet run
   ```

## Ejemplo de Uso

```
============================================
   Bienvenido a SimpleInventoryApp
   Sistema de Inventario de Productos
============================================

------------- Menú Principal -------------
1. Agregar producto
2. Listar todos los productos
3. Buscar producto
4. Modificar producto
5. Eliminar producto
6. Salir
------------------------------------------
Seleccione una opción: 1

--- Agregar Nuevo Producto ---
Ingrese el nombre del producto: Laptop HP
Ingrese el precio del producto: 45000
Ingrese la cantidad en stock: 10

>>> Producto agregado exitosamente con ID: 1
```

## Autor

Felipillo LF - Proyecto Programacion
