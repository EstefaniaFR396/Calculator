using System;
using System.Collections.Generic;

namespace Calculator
{
    public class ListaDoble<T> where T : notnull, IComparable<T>
    {
        private Nodo<T>? cabeza;
        private Nodo<T>? cola;

        public bool EstaVacia => cabeza == null;

        // 1. Adicionar en orden ascendente
        public void Adicionar(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);

            if (cabeza == null)
            {
                cabeza = cola = nuevo;
                return;
            }

            if (dato.CompareTo(cabeza.Dato) < 0)
            {
                nuevo.Siguiente = cabeza;
                cabeza.Anterior = nuevo;
                cabeza = nuevo;
                return;
            }

            Nodo<T> actual = cabeza;

            while (actual.Siguiente != null &&
                   actual.Siguiente.Dato.CompareTo(dato) <= 0)
            {
                actual = actual.Siguiente;
            }

            nuevo.Siguiente = actual.Siguiente;
            nuevo.Anterior = actual;

            if (actual.Siguiente != null)
                actual.Siguiente.Anterior = nuevo;
            else
                cola = nuevo;

            actual.Siguiente = nuevo;
        }

        // 2. Mostrar hacia adelante
        public void MostrarAdelante()
        {
            if (EstaVacia)
            {
                Console.WriteLine("La lista esta vacia.");
                return;
            }

            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                Console.Write(actual.Dato + " ");
                actual = actual.Siguiente;
            }

            Console.WriteLine();
        }

        // 3. Mostrar hacia atras
        public void MostrarAtras()
        {
            if (EstaVacia)
            {
                Console.WriteLine("La lista esta vacia.");
                return;
            }

            Nodo<T>? actual = cola;

            while (actual != null)
            {
                Console.Write(actual.Dato + " ");
                actual = actual.Anterior;
            }

            Console.WriteLine();
        }

        // 4. Ordenar descendentemente
        public void OrdenarDescendentemente()
        {
            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                Nodo<T>? temporal = actual.Siguiente;
                actual.Siguiente = actual.Anterior;
                actual.Anterior = temporal;
                actual = temporal;
            }

            Nodo<T>? auxiliar = cabeza;
            cabeza = cola;
            cola = auxiliar;
        }

        // Obtener frecuencias
        private Dictionary<T, int> ObtenerFrecuencias()
        {
            Dictionary<T, int> frecuencias = new();
            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                if (frecuencias.ContainsKey(actual.Dato))
                    frecuencias[actual.Dato]++;
                else
                    frecuencias[actual.Dato] = 1;

                actual = actual.Siguiente;
            }

            return frecuencias;
        }

        // 5. Mostrar las modas
        public void MostrarModa()
        {
            if (EstaVacia)
            {
                Console.WriteLine("La lista esta vacia.");
                return;
            }

            Dictionary<T, int> frecuencias = ObtenerFrecuencias();
            int maximo = 0;

            foreach (int cantidad in frecuencias.Values)
            {
                if (cantidad > maximo)
                    maximo = cantidad;
            }

            Console.WriteLine("Moda(s):");

            foreach (var elemento in frecuencias)
            {
                if (elemento.Value == maximo)
                {
                    Console.WriteLine(
                        elemento.Key + " (" + elemento.Value +
                        " ocurrencias)");
                }
            }
        }

        // 6. Grafico de ocurrencias
        public void MostrarGrafico()
        {
            if (EstaVacia)
            {
                Console.WriteLine("La lista esta vacia.");
                return;
            }

            Dictionary<T, int> frecuencias = ObtenerFrecuencias();

            foreach (var elemento in frecuencias)
            {
                Console.WriteLine(
                    elemento.Key + ": " +
                    new string('*', elemento.Value));
            }
        }

        // 7. Existe
        public bool Existe(T dato)
        {
            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                if (EqualityComparer<T>.Default.Equals(
                    actual.Dato, dato))
                    return true;

                actual = actual.Siguiente;
            }

            return false;
        }

        // 8. Eliminar una ocurrencia
        public bool EliminarUnaOcurrencia(T dato)
        {
            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                if (EqualityComparer<T>.Default.Equals(
                    actual.Dato, dato))
                {
                    if (actual.Anterior != null)
                        actual.Anterior.Siguiente = actual.Siguiente;
                    else
                        cabeza = actual.Siguiente;

                    if (actual.Siguiente != null)
                        actual.Siguiente.Anterior = actual.Anterior;
                    else
                        cola = actual.Anterior;

                    return true;
                }

                actual = actual.Siguiente;
            }

            return false;
        }

        // 9. Eliminar todas las ocurrencias
        public int EliminarTodasLasOcurrencias(T dato)
        {
            int eliminados = 0;

            while (EliminarUnaOcurrencia(dato))
                eliminados++;

            return eliminados;
        }
    }
}
