using System;
using System.Collections.Generic;

namespace SistemaTienda
{
    class Producto
    {
        public string codigo;
        public string nombre;
        public double precio;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Producto> inventario = new Dictionary<string, Producto>();
            int opcion = 0;
            bool correcto;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Agregar producto\n2. Modificar producto\n3. Eliminar producto\n4. Buscar producto\n5. Mostrar todos los productos\n6. Salir");
                Console.Write("\nSeleccione una opción: ");

                correcto = int.TryParse(Console.ReadLine(), out opcion);

                if (correcto)
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Código: ");
                            string cod = Console.ReadLine();
                            if (!inventario.ContainsKey(cod))
                            {
                                Console.Write("Nombre: ");
                                string nom = Console.ReadLine();
                                Console.Write("Precio: ");
                                bool pCorrecto = double.TryParse(Console.ReadLine(), out double pre);
                                if (pCorrecto)
                                {
                                    inventario.Add(cod, new Producto { codigo = cod, nombre = nom, precio = pre });
                                }
                            }
                            else
                            {
                                Console.WriteLine("El código ya existe.");
                            }
                            break;

                        case 2:
                            Console.Write("Código a modificar: ");
                            string modCod = Console.ReadLine();
                            if (inventario.ContainsKey(modCod))
                            {
                                Console.Write("Nuevo nombre: ");
                                inventario[modCod].nombre = Console.ReadLine();
                                Console.Write("Nuevo precio: ");
                                bool nCorrecto = double.TryParse(Console.ReadLine(), out double nPre);
                                if (nCorrecto)
                                {
                                    inventario[modCod].precio = nPre;
                                }
                            }
                            break;

                        case 3:
                            Console.Write("Código a eliminar: ");
                            string eliCod = Console.ReadLine();
                            if (inventario.Remove(eliCod))
                            {
                                Console.WriteLine("Eliminado.");
                            }
                            break;

                        case 4:
                            Console.Write("Código a buscar: ");
                            string busCod = Console.ReadLine();
                            if (inventario.TryGetValue(busCod, out Producto p))
                            {
                                Console.WriteLine($"Nombre: {p.nombre} | Precio: Q{p.precio}");
                            }
                            break;

                        case 5:
                            foreach (var item in inventario.Values)
                            {
                                Console.WriteLine($"{item.codigo} - {item.nombre} - Q{item.precio}");
                            }
                            break;
                    }
                }

                if (opcion != 6)
                {
                    Console.WriteLine("\nPresione una tecla...");
                    Console.ReadKey();
                }

            } while (opcion != 6);
        }
    }
}
