using System;

namespace Tarea
{
    class Program
    {

        public static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("\nBIENVENIDO AL SISTEMA DE GESTION DE INVENTARIO");
            Console.WriteLine();

            int cantidad;
            do
            {
                Console.WriteLine("¿Cuántos productos desea ingresar?");
                if (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 0)
                {
                    Console.WriteLine("Ingrese un número positivo.");
                }
            } while (cantidad < 0);

            // Ciclo para ingresar productos
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nProducto {i + 1}");
                Console.WriteLine("Nombre:");
                string nombre = Console.ReadLine();

                decimal precio;
                do
                {
                    Console.WriteLine("Precio:");
                    if (!decimal.TryParse(Console.ReadLine(), out precio) || precio < 0)
                    {
                        Console.WriteLine("Ingrese un número positivo.");
                    }
                } while (precio < 0);

                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProducto(producto);
            }

            int opciones;
            do
            {
                // Menú de opciones
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1 - Actualizar precio de un producto");
                Console.WriteLine("2 - Eliminar un producto");
                Console.WriteLine("3 - Filtrar y mostrar productos");
                Console.WriteLine("4 - Agrupar productos por precio");
                Console.WriteLine("5 - Salir");
                opciones = int.Parse(Console.ReadLine());

                switch (opciones)
                {
                    case 1:
                        Console.WriteLine("Ingrese el nombre del producto cuyo precio desea actualizar:");
                        string nombreProducto = Console.ReadLine();

                        decimal nuevoPrecio;
                        do
                        {
                            Console.WriteLine("Ingrese el nuevo precio:");
                            if (!decimal.TryParse(Console.ReadLine(), out nuevoPrecio) || nuevoPrecio <= 0)
                            {
                                Console.WriteLine("Ingrese un número positivo.");
                            }
                        } while (nuevoPrecio <= 0);

                        inventario.ActualizarPrecioProducto(nombreProducto, nuevoPrecio);
                        break;

                    case 2:
                        Console.WriteLine("Ingrese el nombre del producto que desea eliminar:");
                        string nombreProducto1 = Console.ReadLine();
                        inventario.EliminarProducto(nombreProducto1);
                        break;

                    case 3:
                        Console.WriteLine("Ingrese el precio mínimo para filtrar los productos:");
                        decimal precioMinimo;
                        if (decimal.TryParse(Console.ReadLine(), out precioMinimo))
                        {
                            var productoFiltrados = inventario.FiltrarYOrdenarProducto(precioMinimo);
                            Console.WriteLine("\nProductos filtrados y ordenados:");
                            foreach (var producto in productoFiltrados)
                            {
                                Console.WriteLine($"- {producto.Nombre}: {producto.Precio:C}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido.");
                        }
                        break;

                    case 4:
                        decimal precioAgrupar;
                        do
                        {
                            Console.WriteLine("Ingrese el precio que desea agrupar los productos:");
                            if (!decimal.TryParse(Console.ReadLine(), out precioAgrupar) || precioAgrupar < 0)
                            {
                                Console.WriteLine("Ingrese un número positivo.");
                            }
                        } while (precioAgrupar < 0);

                        inventario.AgruparProducto(precioAgrupar);
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("La opción ingresada es incorrecta.");
                        break;
                }

            } while (opciones != 5);

        }

    }
}