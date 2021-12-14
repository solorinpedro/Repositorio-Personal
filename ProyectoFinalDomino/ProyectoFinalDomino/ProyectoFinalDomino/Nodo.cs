using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDomino
{
    /*
     Esta clase sirve para declarar la lista circular, donde se almacenaran los datos de los jugadores. 
     */
    class Nodo
    {
        private string[] Dato = new string[8];//En la primerra casila se almacerá el nombre del jugador y en las demas se almacenarán las fichas.
        private Nodo Siguiente;

        public string[] dato
        {
            get { return Dato; }
            set { Dato = value; }
        }

        public Nodo siguiente
        {
            get { return Siguiente; }
            set { Siguiente = value; }
        }
    }
}
