// ============================================
// SimpleInventoryApp — Fase 1
// Sistema de inventario simple en consola
// Datos almacenados en memoria (listas y diccionarios)
// ============================================

// Colecciones para almacenar los datos de los productos en memoria
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, decimal> prices = new Dictionary<int, decimal>();
Dictionary<int, int> stocks = new Dictionary<int, int>();

// Contador para generar IDs únicos de forma incremental
int nextId = 1;

// Variable de control del bucle principal
bool running = true;

Console.WriteLine("============================================");
Console.WriteLine("   Bienvenido a SimpleInventoryApp");
Console.WriteLine("   Sistema de Inventario de Productos");
Console.WriteLine("============================================");
Console.WriteLine();

// Bucle principal del programa — solo termina cuando el usuario elige Salir
while (running)
{
    Console.WriteLine("------------- Menú Principal -------------");
    Console.WriteLine("1. Agregar producto");
    Console.WriteLine("2. Listar todos los productos");
    Console.WriteLine("3. Buscar producto");
    Console.WriteLine("4. Modificar producto");
    Console.WriteLine("5. Eliminar producto");
    Console.WriteLine("6. Salir");
    Console.WriteLine("------------------------------------------");
    Console.Write("Seleccione una opción: ");

    string input = Console.ReadLine();
    int option;

    // Validar que el usuario ingresó un número válido
    if (!int.TryParse(input, out option))
    {
        Console.WriteLine();
        Console.WriteLine(">>> Error: Debe ingresar un número válido. Intente de nuevo.");
        Console.WriteLine();
        continue;
    }

    Console.WriteLine();

    switch (option)
    {
        // =============================================
        // CASO 1: Agregar un nuevo producto al inventario
        // =============================================
        case 1:
            try
            {
                Console.WriteLine("--- Agregar Nuevo Producto ---");

                // Solicitar el nombre del producto
                Console.Write("Ingrese el nombre del producto: ");
                string productName = Console.ReadLine();

                // Validar que el nombre no esté vacío
                if (string.IsNullOrWhiteSpace(productName))
                {
                    Console.WriteLine(">>> Error: El nombre del producto no puede estar vacío.");
                    Console.WriteLine();
                    break;
                }

                // Solicitar el precio del producto
                Console.Write("Ingrese el precio del producto: ");
                string priceInput = Console.ReadLine();
                decimal productPrice;

                if (!decimal.TryParse(priceInput, out productPrice))
                {
                    Console.WriteLine(">>> Error: El precio debe ser un número válido.");
                    Console.WriteLine();
                    break;
                }

                // Validar que el precio no sea negativo
                if (productPrice < 0)
                {
                    Console.WriteLine(">>> Error: El precio no puede ser negativo.");
                    Console.WriteLine();
                    break;
                }

                // Solicitar la cantidad en stock
                Console.Write("Ingrese la cantidad en stock: ");
                string stockInput = Console.ReadLine();
                int productStock;

                if (!int.TryParse(stockInput, out productStock))
                {
                    Console.WriteLine(">>> Error: La cantidad debe ser un número entero válido.");
                    Console.WriteLine();
                    break;
                }

                // Validar que el stock no sea negativo
                if (productStock < 0)
                {
                    Console.WriteLine(">>> Error: La cantidad en stock no puede ser negativa.");
                    Console.WriteLine();
                    break;
                }

                // Guardar el producto en todas las colecciones
                int currentId = nextId;
                ids.Add(currentId);
                names.Add(currentId, productName);
                prices.Add(currentId, productPrice);
                stocks.Add(currentId, productStock);
                nextId++;

                Console.WriteLine();
                Console.WriteLine($">>> Producto agregado exitosamente con ID: {currentId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($">>> Error inesperado al agregar el producto: {ex.Message}");
            }
            Console.WriteLine();
            break;

        // =============================================
        // CASO 2: Listar todos los productos del inventario
        // =============================================
        case 2:
            try
            {
                Console.WriteLine("--- Lista de Productos ---");

                // Verificar si hay productos registrados
                if (ids.Count == 0)
                {
                    Console.WriteLine(">>> No hay productos registrados en el inventario.");
                    Console.WriteLine();
                    break;
                }

                // Encabezado de la tabla
                Console.WriteLine(String.Format("{0,-6} {1,-25} {2,-15} {3,-10}", "ID", "Nombre", "Precio", "Stock"));
                Console.WriteLine(new string('-', 60));

                // Recorrer todos los IDs y mostrar la información de cada producto
                foreach (int id in ids)
                {
                    string name = names[id];
                    decimal price = prices[id];
                    int stock = stocks[id];

                    Console.WriteLine(String.Format("{0,-6} {1,-25} {2,-15:C2} {3,-10}", id, name, price, stock));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($">>> Error inesperado al listar los productos: {ex.Message}");
            }
            Console.WriteLine();
            break;

        // =============================================
        // CASO 3: Buscar producto por ID o por nombre
        // =============================================
        case 3:
            try
            {
                Console.WriteLine("--- Buscar Producto ---");
                Console.WriteLine("1. Buscar por ID");
                Console.WriteLine("2. Buscar por nombre");
                Console.Write("Seleccione el tipo de búsqueda: ");

                string searchTypeInput = Console.ReadLine();
                int searchType;

                if (!int.TryParse(searchTypeInput, out searchType))
                {
                    Console.WriteLine(">>> Error: Debe ingresar 1 o 2.");
                    Console.WriteLine();
                    break;
                }

                if (searchType == 1)
                {
                    // Búsqueda por ID exacto
                    Console.Write("Ingrese el ID del producto: ");
                    string searchIdInput = Console.ReadLine();
                    int searchId;

                    if (!int.TryParse(searchIdInput, out searchId))
                    {
                        Console.WriteLine(">>> Error: Debe ingresar un número válido para el ID.");
                        Console.WriteLine();
                        break;
                    }

                    // Verificar si el ID existe en el diccionario
                    if (names.ContainsKey(searchId))
                    {
                        Console.WriteLine();
                        Console.WriteLine(">>> Producto encontrado:");
                        Console.WriteLine($"    ID:     {searchId}");
                        Console.WriteLine($"    Nombre: {names[searchId]}");
                        Console.WriteLine($"    Precio: {prices[searchId]:C2}");
                        Console.WriteLine($"    Stock:  {stocks[searchId]}");
                    }
                    else
                    {
                        Console.WriteLine($">>> No se encontró ningún producto con el ID: {searchId}");
                    }
                }
                else if (searchType == 2)
                {
                    // Búsqueda por coincidencia de nombre
                    Console.Write("Ingrese el nombre (o parte del nombre) del producto: ");
                    string searchName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(searchName))
                    {
                        Console.WriteLine(">>> Error: Debe ingresar un texto para buscar.");
                        Console.WriteLine();
                        break;
                    }

                    // Recorrer todos los IDs buscando coincidencias en el nombre
                    bool found = false;
                    Console.WriteLine();
                    Console.WriteLine(String.Format("{0,-6} {1,-25} {2,-15} {3,-10}", "ID", "Nombre", "Precio", "Stock"));
                    Console.WriteLine(new string('-', 60));

                    foreach (int id in ids)
                    {
                        // Comparar ignorando mayúsculas y minúsculas
                        if (names[id].ToLower().Contains(searchName.ToLower()))
                        {
                            Console.WriteLine(String.Format("{0,-6} {1,-25} {2,-15:C2} {3,-10}", id, names[id], prices[id], stocks[id]));
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($">>> No se encontraron productos que coincidan con: \"{searchName}\"");
                    }
                }
                else
                {
                    Console.WriteLine(">>> Error: Opción de búsqueda no válida. Elija 1 o 2.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($">>> Error inesperado al buscar el producto: {ex.Message}");
            }
            Console.WriteLine();
            break;

        // =============================================
        // CASO 4: Modificar un producto existente
        // =============================================
        case 4:
            try
            {
                Console.WriteLine("--- Modificar Producto ---");

                // Verificar si hay productos para modificar
                if (ids.Count == 0)
                {
                    Console.WriteLine(">>> No hay productos registrados para modificar.");
                    Console.WriteLine();
                    break;
                }

                // Mostrar la lista de productos antes de modificar
                Console.WriteLine(String.Format("{0,-6} {1,-25} {2,-15} {3,-10}", "ID", "Nombre", "Precio", "Stock"));
                Console.WriteLine(new string('-', 60));
                foreach (int id in ids)
                {
                    Console.WriteLine(String.Format("{0,-6} {1,-25} {2,-15:C2} {3,-10}", id, names[id], prices[id], stocks[id]));
                }
                Console.WriteLine();

                // Solicitar el ID del producto a modificar
                Console.Write("Ingrese el ID del producto a modificar: ");
                string editIdInput = Console.ReadLine();
                int editId;

                if (!int.TryParse(editIdInput, out editId))
                {
                    Console.WriteLine(">>> Error: Debe ingresar un número válido para el ID.");
                    Console.WriteLine();
                    break;
                }

                // Verificar que el ID exista
                if (!names.ContainsKey(editId))
                {
                    Console.WriteLine($">>> Error: No se encontró ningún producto con el ID: {editId}");
                    Console.WriteLine();
                    break;
                }

                // Mostrar los datos actuales del producto seleccionado
                Console.WriteLine();
                Console.WriteLine(">>> Datos actuales del producto:");
                Console.WriteLine($"    Nombre: {names[editId]}");
                Console.WriteLine($"    Precio: {prices[editId]:C2}");
                Console.WriteLine($"    Stock:  {stocks[editId]}");
                Console.WriteLine();

                // Solicitar el nuevo nombre (Enter para mantener el actual)
                Console.Write($"Nuevo nombre (Enter para mantener \"{names[editId]}\"): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    names[editId] = newName;
                }

                // Solicitar el nuevo precio (Enter para mantener el actual)
                Console.Write($"Nuevo precio (Enter para mantener {prices[editId]:C2}): ");
                string newPriceInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPriceInput))
                {
                    decimal newPrice;
                    if (decimal.TryParse(newPriceInput, out newPrice) && newPrice >= 0)
                    {
                        prices[editId] = newPrice;
                    }
                    else
                    {
                        Console.WriteLine(">>> Precio no válido. Se mantiene el precio anterior.");
                    }
                }

                // Solicitar el nuevo stock (Enter para mantener el actual)
                Console.Write($"Nuevo stock (Enter para mantener {stocks[editId]}): ");
                string newStockInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newStockInput))
                {
                    int newStock;
                    if (int.TryParse(newStockInput, out newStock) && newStock >= 0)
                    {
                        stocks[editId] = newStock;
                    }
                    else
                    {
                        Console.WriteLine(">>> Stock no válido. Se mantiene el stock anterior.");
                    }
                }

                Console.WriteLine();
                Console.WriteLine(">>> Producto modificado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($">>> Error inesperado al modificar el producto: {ex.Message}");
            }
            Console.WriteLine();
            break;

        // =============================================
        // CASO 5: Eliminar un producto del inventario
        // =============================================
        case 5:
            try
            {
                Console.WriteLine("--- Eliminar Producto ---");

                // Verificar si hay productos para eliminar
                if (ids.Count == 0)
                {
                    Console.WriteLine(">>> No hay productos registrados para eliminar.");
                    Console.WriteLine();
                    break;
                }

                // Mostrar la lista de productos antes de eliminar
                Console.WriteLine(String.Format("{0,-6} {1,-25} {2,-15} {3,-10}", "ID", "Nombre", "Precio", "Stock"));
                Console.WriteLine(new string('-', 60));
                foreach (int id in ids)
                {
                    Console.WriteLine(String.Format("{0,-6} {1,-25} {2,-15:C2} {3,-10}", id, names[id], prices[id], stocks[id]));
                }
                Console.WriteLine();

                // Solicitar el ID del producto a eliminar
                Console.Write("Ingrese el ID del producto a eliminar: ");
                string deleteIdInput = Console.ReadLine();
                int deleteId;

                if (!int.TryParse(deleteIdInput, out deleteId))
                {
                    Console.WriteLine(">>> Error: Debe ingresar un número válido para el ID.");
                    Console.WriteLine();
                    break;
                }

                // Verificar que el ID exista
                if (!names.ContainsKey(deleteId))
                {
                    Console.WriteLine($">>> Error: No se encontró ningún producto con el ID: {deleteId}");
                    Console.WriteLine();
                    break;
                }

                // Mostrar el producto que se va a eliminar
                Console.WriteLine();
                Console.WriteLine(">>> Producto seleccionado para eliminar:");
                Console.WriteLine($"    ID:     {deleteId}");
                Console.WriteLine($"    Nombre: {names[deleteId]}");
                Console.WriteLine($"    Precio: {prices[deleteId]:C2}");
                Console.WriteLine($"    Stock:  {stocks[deleteId]}");
                Console.WriteLine();

                // Pedir confirmación antes de eliminar
                Console.WriteLine("¿Está seguro que desea eliminar este producto?");
                Console.WriteLine("1. Sí");
                Console.WriteLine("2. No");
                Console.Write("Seleccione una opción: ");

                string confirmInput = Console.ReadLine();
                int confirm;

                if (!int.TryParse(confirmInput, out confirm))
                {
                    Console.WriteLine(">>> Operación cancelada. Entrada no válida.");
                    Console.WriteLine();
                    break;
                }

                if (confirm == 1)
                {
                    // Eliminar el producto de todas las colecciones
                    names.Remove(deleteId);
                    prices.Remove(deleteId);
                    stocks.Remove(deleteId);
                    ids.Remove(deleteId);

                    Console.WriteLine(">>> Producto eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine(">>> Operación cancelada. El producto no fue eliminado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($">>> Error inesperado al eliminar el producto: {ex.Message}");
            }
            Console.WriteLine();
            break;

        // =============================================
        // CASO 6: Salir del programa
        // =============================================
        case 6:
            Console.WriteLine(">>> Gracias por usar SimpleInventoryApp. ¡Hasta luego!");
            running = false;
            break;

        // =============================================
        // OPCIÓN NO VÁLIDA
        // =============================================
        default:
            Console.WriteLine(">>> Error: Opción no válida. Por favor seleccione una opción del 1 al 6.");
            Console.WriteLine();
            break;
    }
}
