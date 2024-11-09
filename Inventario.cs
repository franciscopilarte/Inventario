using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>(); 
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public IEnumerable<Producto> FiltrarYOrdenarProducto(decimal precioMinimo)
        {
            return productos
                .Where(p => p.Precio > precioMinimo)
                .OrderBy(p => p.Precio);
        }

        public void ActualizarPrecioProducto(string nombre, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine($"El precio del producto '{nombre}' ha sido actualizado a {nuevoPrecio:C}.");
            }
            else
            {
                Console.WriteLine($"No se encontró un producto con el nombre '{nombre}'.");
            }
        }

        public void EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));


            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"El Producto {nombre} ha sido Eliminado del Inventario");

            }
            else
            {
                Console.WriteLine($"Nose encuentra un producto con el nombre: {nombre}");
            }

        }

        public void AgruparProducto(decimal precio)
        {
            var grupos = productos
                .Where(p => p.Precio > precio)
                .GroupBy(p => p.Precio);

            foreach (var grupo in grupos)
            {
                Console.WriteLine($"Productos con precio: {grupo.Key:C}");

                foreach (var producto in grupo)
                {
                    Console.WriteLine($"  - {producto.Nombre}: {producto.Precio:C}");
                }

                Console.WriteLine();
            }
        }

        public void Resumen()
        {
            var productoConPrecioAlto = productos
                .OrderByDescending(p => p.Precio)
                .FirstOrDefault();
            if (productoConPrecioAlto != null)
            {
                Console.WriteLine($"\nProducto con el precio más alto: {productoConPrecioAlto.Nombre} - {productoConPrecioAlto.Precio:C}");
            }

            // Producto con el precio más bajo
            var productoConPrecioBajo = productos
                .OrderBy(p => p.Precio)
                .FirstOrDefault();
            if (productoConPrecioBajo != null)
            {
                Console.WriteLine($"Producto con el precio más bajo: {productoConPrecioBajo.Nombre} - {productoConPrecioBajo.Precio:C}");
            }

            // Precio promedio de todos los productos
            var precioPromedio = productos.Average(p => p.Precio);
            Console.WriteLine($"Precio promedio de los productos: {precioPromedio:C}");
        }



        public void ProductoMostrar()
        {
            foreach (var producto in productos)
            {
                Console.WriteLine($"- {producto.Nombre}: {producto.Precio:C}");
            }
        }


    }
}
