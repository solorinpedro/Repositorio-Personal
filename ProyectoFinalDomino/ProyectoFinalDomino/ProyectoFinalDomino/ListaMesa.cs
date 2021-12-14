using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDomino
{
    /*
      Esta clase se utiliza para crear la lista donde se almacenan las fichas que los jugadores van usando.
    Se utiliza para que el usuario puede ver las fichas que estan en las mesas.
    Es una lista circular doble.
     */

    class ListaMesa
    {
        NodoMesa primero = new NodoMesa();
        NodoMesa ultimo = new NodoMesa();

        public ListaMesa()
        {
            primero = null;
            ultimo = null;
        }
        //Se reciben como parametros la ficha que se va a jugar y el extremo del lado donde se pondrá
        public void insertarNodoPrimero(string fichaJugar, string extremo)//Esta funcion sirve para jugar una ficha que vaya por la derecha
        {
            string ficha = string.Empty;
            NodoMesa nuevo = new NodoMesa();
            if (Convert.ToString(fichaJugar[1]) == extremo)
                nuevo.dato = fichaJugar;
            else
            {
                string temp = ($"[{Convert.ToString(fichaJugar[3])}|{Convert.ToString(fichaJugar[1])}]");
                nuevo.dato = temp;
            }
            if (primero == null)
            {
                primero = nuevo;
                ultimo = nuevo;
                primero.siguiente = primero;
                primero.atras = ultimo;
            }
            else
            {
                ultimo.siguiente = nuevo;
                nuevo.atras = ultimo;
                nuevo.siguiente = primero;
                ultimo = nuevo;
                primero.atras = ultimo;
            }
        }

        //Se reciben como parametros la ficha que se va a jugar y el extremo del lado donde se pondrá
        public void insertarNodoUltimo(string fichaJugar, string extremo)//Esta funcion sirve para jugar una ficha que vaya por la izquierda
        {
            NodoMesa nuevo = new NodoMesa();
            if (Convert.ToString(fichaJugar[3]) == extremo)
                nuevo.dato = fichaJugar;
            else
            {
                string temp = ($"[{Convert.ToString(fichaJugar[3])}|{Convert.ToString(fichaJugar[1])}]");
                nuevo.dato = temp;
            }

            if (primero == null)
            {
                primero = nuevo;
                ultimo = nuevo;
                primero.siguiente = primero;
                primero.atras = ultimo;
            }
            else
            {
                primero.atras = nuevo;
                nuevo.siguiente = primero;
                nuevo.atras = ultimo;
                primero = nuevo;
                ultimo.siguiente = primero;
            }
        }
        public void desplegarListaPU()//Este funcion se utiliza para mostar en pantalla todas las fichas que estan en la mesa.
        {
            //PU significa desde el Primero hacia el Ultimo
            NodoMesa actual = new NodoMesa();//actual hace uso del nodo auxiliar
            actual = primero;
            Console.WriteLine("\n");
            if (actual != null)
            {
                do
                {
                    Console.Write("" + actual.dato);
                    actual = actual.siguiente;
                } while (actual != primero);
            }
            Console.WriteLine("\n");
        }
        public void eliminarNodo()//Esta funcion sirve para eliminar todos los elementos de la mesa. Sirve para cuando una partida termina e inicia la otra; todas las fichas se quitan en de la mesa y regrean a las manos de los jugadores.
        {
            NodoMesa actual = new NodoMesa();
            NodoMesa anterior = new NodoMesa();
            anterior = null;
            bool encontrado = false;

            NodoMesa nodoBuscado = ultimo;
            actual = primero;

            if (actual != null)
            {
                do
                {
                    if (actual == nodoBuscado && encontrado == false)
                    {
                        if (actual == primero)
                        {
                            primero = primero.siguiente;
                            primero.atras = ultimo;
                            ultimo.siguiente = primero;
                        }
                        else if (actual == ultimo)
                        {
                            ultimo = anterior;
                            ultimo.siguiente = primero;
                            primero.atras = ultimo;
                        }
                        else
                        {
                            anterior.siguiente = actual.siguiente;
                            actual.siguiente.atras = anterior;
                        }
                        Console.WriteLine("\nSe ha limpiado la mesa.\n");

                    }

                    anterior = actual;
                    actual = actual.siguiente;
                    nodoBuscado = ultimo;
                    actual = nodoBuscado;
                    if (primero == null)
                    {
                        encontrado = true;
                    }
                } while (actual != primero);
                primero = null;
                ultimo = null;
            }
            Console.WriteLine();
        }
    }
}
