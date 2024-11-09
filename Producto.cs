﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea
{
    public class Producto
    {
        public Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Producto: {Nombre}, Precio: {Precio}");
        }



    }
}
