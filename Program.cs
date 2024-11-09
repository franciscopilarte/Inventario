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


        }

    }
}