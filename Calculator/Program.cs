using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaDoble<int> lista = new ListaDoble<int>();
            int opcion = -1;

            do
            {
                Console.WriteLine("\n===== TALLER 5: LISTAS DOBLEMENTE LIGADAS =====");
                Console.WriteLine("1. Adicionar");
                Console.WriteLine("2. Mostrar hacia adelante");
                Console.WriteLine("3. Mostrar hacia atras");
                Console.WriteLine("4. Ordenar descendentemente");
                Console.WriteLine("5. Mostrar la(s) moda(s)");
                Console.WriteLine("6. Mostrar grafico");
                Console.WriteLine("7. Existe");
                Console.WriteLine("8. Eliminar una ocurrencia");
                Console.WriteLine("9. Eliminar todas las ocurrencias");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opcion: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Ingrese una opcion valida.");
                    opcion = -1;
                    continue;
                }

                int valor;

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese un numero: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                        {
                            lista.Adicionar(valor);
                            Console.WriteLine("Numero agregado.");
                        }
                        else Console.WriteLine("Numero invalido.");
                        break;

                    case 2:
                        lista.MostrarAdelante();
                        break;

                    case 3:
                        lista.MostrarAtras();
                        break;

                    case 4:
                        lista.OrdenarDescendentemente();
                        Console.WriteLine("Lista invertida:");
                        lista.MostrarAdelante();
                        break;

                    case 5:
                        lista.MostrarModa();
                        break;

                    case 6:
                        lista.MostrarGrafico();
                        break;

                    case 7:
                        Console.Write("Numero que desea buscar: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                            Console.WriteLine(lista.Existe(valor)
                                ? "El numero SI existe."
                                : "El numero NO existe.");
                        else Console.WriteLine("Numero invalido.");
                        break;

                    case 8:
                        Console.Write("Numero que desea eliminar una vez: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                            Console.WriteLine(
                                lista.EliminarUnaOcurrencia(valor)
                                ? "Una ocurrencia eliminada."
                                : "El numero no existe.");
                        else Console.WriteLine("Numero invalido.");
                        break;

                    case 9:
                        Console.Write("Numero que desea eliminar completamente: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                        {
                            int cantidad =
                                lista.EliminarTodasLasOcurrencias(valor);
                            Console.WriteLine(
                                "Ocurrencias eliminadas: " + cantidad);
                        }
                        else Console.WriteLine("Numero invalido.");
                        break;

                    case 0:
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }

            } while (opcion != 0);
        }
    }
}
