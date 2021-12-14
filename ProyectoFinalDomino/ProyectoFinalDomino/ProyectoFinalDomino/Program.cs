using System;

namespace ProyectoFinalDomino
{
    class Program
    {


        static void Main(string[] args)
        {
            Lista l = new Lista();//Se declara la clase donde estan todas las funciones
            l.insertarJugadores();//Funcion que pide los nombre de los jugadores
            l.iniciarPartida();//Se utiliza para llamar la función que inicia la partida luego de que los jugadores ya estan incluidos
        }
    }
}
