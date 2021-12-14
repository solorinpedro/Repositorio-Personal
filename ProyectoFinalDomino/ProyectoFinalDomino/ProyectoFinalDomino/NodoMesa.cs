using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDomino
{
    //Aquí estan las instrucciones para crear la mesa donde se guardan las fichas. Esta es una lista circular doble.
    class NodoMesa
    {
        private string Dato;
        private NodoMesa Siguiente;
        private NodoMesa Atras;

        public string dato
        {
            get { return Dato; }
            set { Dato = value; }
        }

        public NodoMesa siguiente
        {
            get { return Siguiente; }
            set { Siguiente = value; }
        }

        public NodoMesa atras
        {
            get { return Atras; }
            set { Atras = value; }
        }
    }
}
