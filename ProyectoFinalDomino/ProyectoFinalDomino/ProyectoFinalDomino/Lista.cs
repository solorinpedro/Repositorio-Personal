using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDomino
{
    /*
     En esta clase se encuentran todas las funciones que hacen posible el juego de Domino, desde repartir las fichas, hasta jugar las partidad.
     */
    public class Lista
    {

        Nodo primero = new Nodo();
        Nodo ultimo = new Nodo();

        public Lista()
        {
            primero = null;
            ultimo = null;
        }


        static void header()//Cabezera donde se encuentran los datos que se le pediran al/los usuarios.
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("BIENVENIDO A NUESTRO JUEGO DE DOMINO!\n");
            Console.WriteLine("NOTA:");
            Console.WriteLine("ParejaA: Jugador1 y jugador3.");
            Console.WriteLine("ParejaB: Jugador2 y jugador4.\n\n");
        }//Cabecera 
        public void insertarJugadores()//Funcion para llevar a la lista circular los nombres de los jugadores.
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 1; i < 5; i++)//Ciclo que pedirá uno por uno los nombres de los jugadores.
            {
                Nodo nuevo = new Nodo();
                header();
                Console.Write("Ingrese el nombre del jugador" + i + ": ");
                nuevo.dato[0] = Console.ReadLine();
                Console.Clear();
                if (primero == null)
                {
                    primero = nuevo;
                    ultimo = nuevo;
                    primero.siguiente = primero;
                }
                else
                {
                    ultimo.siguiente = nuevo;
                    nuevo.siguiente = primero;
                    ultimo = nuevo;
                }
            }
        }
        public void repartirFichas()//funcion para crear las fichas y luego repartirsela a cada jugador.
        {
            string[] F = new string[28];
            F[0] = "[0|0]";
            F[1] = "[1|0]";
            F[2] = "[2|0]";
            F[3] = "[1|1]";
            F[4] = "[2|1]";
            F[5] = "[3|0]";
            F[6] = "[4|0]";
            F[7] = "[3|1]";
            F[8] = "[2|2]";
            F[9] = "[5|0]";
            F[10] = "[4|1]";
            F[11] = "[3|2]";
            F[12] = "[6|0]";
            F[13] = "[5|1]";
            F[14] = "[4|2]";
            F[15] = "[3|3]";
            F[16] = "[6|1]";
            F[17] = "[5|2]";
            F[18] = "[4|3]";
            F[19] = "[6|2]";
            F[20] = "[5|3]";
            F[21] = "[4|4]";
            F[22] = "[6|3]";
            F[23] = "[5|4]";
            F[24] = "[6|4]";
            F[25] = "[5|5]";
            F[26] = "[6|5]";
            F[27] = "[6|6]";


            /*
             Anteriormente implementamos repartir las fichas con bucles, pero al final decidimos repartirlas de forma manual.
             */

            clsFicha f = new clsFicha();
            for (int i = 0; i < 28; i++)//Pasar los datos a los objetos de las fichas.
            {
                f.extremoA[i] = Convert.ToString(F[i][1]);
                f.extremoB[i] = Convert.ToString(F[i][3]);
                f.sumatoria[i] = Convert.ToInt32(f.extremoA[i]) + Convert.ToInt32(f.extremoB[i]);
            }

            int[] fichasDisponibles = new int[28];
            int aleatorio = 0;
            Random ficha = new Random();//Declaracion de la variable que utilizamos para generar un numero aleatorio y repartir las fichas de forma aleatoria.

            for (int i = 0; i < 28; i++)
                fichasDisponibles[i] = -1; //Arrays que nos dice cual ficha está disponible y así evitar que las fichas se repitan.

            for (int i = 1; i < 8; i++)//Repartir fichas a jugador 1
            {
                for (int k = 0; ;)
                {
                    aleatorio = ficha.Next(0, 28);
                    if (fichasDisponibles[aleatorio] == -1)
                    {
                        fichasDisponibles[aleatorio] = 0;
                        primero.dato[i] = F[aleatorio];
                        break;
                    }
                    else
                    {
                        aleatorio = ficha.Next(0, 28);
                        k++;
                    }
                }
            }
            for (int i = 1; i < 8; i++)//Repartir fichas a jugador 2
            {
                for (int k = 0; ;)
                {
                    aleatorio = ficha.Next(0, 28);
                    if (fichasDisponibles[aleatorio] == -1)
                    {
                        fichasDisponibles[aleatorio] = 0;
                        primero.siguiente.dato[i] = F[aleatorio];
                        break;
                    }
                    else
                    {
                        aleatorio = ficha.Next(0, 28);
                        k++;
                    }
                }
            }
            for (int i = 1; i < 8; i++)//Repartir fichas a jugador 3
            {
                for (int k = 0; ;)
                {
                    aleatorio = ficha.Next(0, 28);
                    if (fichasDisponibles[aleatorio] == -1)
                    {
                        fichasDisponibles[aleatorio] = 0;
                        primero.siguiente.siguiente.dato[i] = F[aleatorio];
                        break;
                    }
                    else
                    {
                        aleatorio = ficha.Next(0, 28);
                        k++;
                    }
                }
            }
            for (int i = 1; i < 8; i++)//Repartir fichas a jugador 4
            {
                for (int k = 0; ;)
                {
                    aleatorio = ficha.Next(0, 28);
                    if (fichasDisponibles[aleatorio] == -1)
                    {
                        fichasDisponibles[aleatorio] = 0;
                        ultimo.dato[i] = F[aleatorio];
                        break;
                    }
                    else
                    {
                        aleatorio = ficha.Next(0, 28);
                        k++;
                    }
                }
            }
            int n = 8; //Ordenar las fichas a cada jugador.
            for (int i = 1; i < n; i++)//Ordenar las fichas al jugador1
            {
                for (int j = i + 1; j < n; j++)
                {
                    string aux;
                    if ((primero.dato[i][1] + primero.dato[i][3]) > (primero.dato[j][1] + primero.dato[j][3]))
                    {
                        aux = primero.dato[i];
                        primero.dato[i] = primero.dato[j];
                        primero.dato[j] = aux;
                    }
                }
            }
            for (int i = 1; i < n; i++)//Ordenar las fichas al jugador2
            {
                for (int j = i + 1; j < n; j++)
                {
                    string aux;
                    if ((primero.siguiente.dato[i][1] + primero.siguiente.dato[i][3]) > (primero.siguiente.dato[j][1] + primero.siguiente.dato[j][3]))
                    {
                        aux = primero.siguiente.dato[i];
                        primero.siguiente.dato[i] = primero.siguiente.dato[j];
                        primero.siguiente.dato[j] = aux;
                    }
                }
            }
            for (int i = 1; i < n; i++)//Ordenar las fichas al jugador3
            {
                for (int j = i + 1; j < n; j++)
                {
                    string aux;
                    if ((primero.siguiente.siguiente.dato[i][1] + primero.siguiente.siguiente.dato[i][3]) > (primero.siguiente.siguiente.dato[j][1] + primero.siguiente.siguiente.dato[j][3]))
                    {
                        aux = primero.siguiente.siguiente.dato[i];
                        primero.siguiente.siguiente.dato[i] = primero.siguiente.siguiente.dato[j];
                        primero.siguiente.siguiente.dato[j] = aux;
                    }
                }
            }
            for (int i = 1; i < n; i++)//Ordenar las fichas al jugador4
            {
                for (int j = i + 1; j < n; j++)
                {
                    string aux;
                    if ((ultimo.dato[i][1] + ultimo.dato[i][3]) > (ultimo.dato[j][1] + ultimo.dato[j][3]))
                    {
                        aux = ultimo.dato[i];
                        ultimo.dato[i] = ultimo.dato[j];
                        ultimo.dato[j] = aux;
                    }
                }
            }


        }
        public void desplegarListaFichas()//Esta funcion sirve para mostrar en pantalla las fichas que tiene cada jugador en el momento.
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Fichas de cada jugador:\n");
            Nodo aux = primero;

            Console.Write($"{aux.dato[0]}: ");
            for (int i = 1; i < 8; i++)
            {
                if (aux.dato[i] != "llll")//Se iguala a cuatro l, para saber cual ficha ha usado el jugador, las que tienen llll es porque el jugador ya no la tiene en mano
                {
                    Console.Write($"{aux.dato[i]}");
                }
            }
            Console.WriteLine();
            aux = aux.siguiente;
            Console.Write($"{aux.dato[0]}: ");
            for (int i = 1; i < 8; i++)
            {
                if (aux.dato[i] != "llll")//Se iguala a cuatro l, para saber cual ficha ha usado el jugador, las que tienen llll es porque el jugador ya no la tiene en mano
                {
                    Console.Write($"{aux.dato[i]}");
                }
            }
            Console.WriteLine();
            aux = aux.siguiente;
            Console.Write($"{aux.dato[0]}: ");//Imprimir el nombre del jugador mas sus fichas disponibles
            for (int i = 1; i < 8; i++)
            {
                if (aux.dato[i] != "llll")
                {
                    Console.Write($"{aux.dato[i]}");
                }
            }
            Console.WriteLine();
            aux = aux.siguiente;
            Console.Write($"{aux.dato[0]}: ");
            for (int i = 1; i < 8; i++)//Imprimir el nombre del jugador mas sus fichas disponibles
            {
                if (aux.dato[i] != "llll")
                {
                    Console.Write($"{aux.dato[i]}");
                }
            }
            Console.WriteLine("\n\n");
        }
        public void iniciarPartida()//Se inicia la partida
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            string[] extremos = new string[2]; //[0] = extremoA, [1] = extremoB
            Nodo aux = primero;
            extremos[0] = "6"; extremos[1] = "6";//Se igualan los extremos de la mesa a [6|6]
            Nodo ganador = new Nodo(); // Se utiliza para almacenar el jugador que ha ganado e imprimirlo al final.
            ListaMesa lm = new ListaMesa();
            int primerJugador = 1;

            Queue puntajeA = new Queue();
            Queue puntajeB = new Queue();

            int puntosParejaA = 0, puntosParejaB = 0;
            repartirFichas();

            for (primerJugador = 1; primerJugador < 8; primerJugador++)
            {
                if (aux.dato[primerJugador][1] == '6' && aux.dato[primerJugador][3] == '6')
                {
                    lm.insertarNodoPrimero(aux.dato[primerJugador], "6");
                    break;
                }
                if (primerJugador == 7)
                {
                    aux = aux.siguiente;
                    primerJugador = 1;
                }
            }

            Console.WriteLine($"\n{aux.dato[0]} tiene [6|6]\n");//Se busca de manera secuencial la persona que tiene [6|6]
            aux.dato[primerJugador] = "llll";//Se le quita [6|6] al primer jugador, ya que ahora [6|6] se encuentra en la mesa.
            aux = aux.siguiente;
            while (puntosParejaA < 200 && puntosParejaB < 200)//Se jugaran partidas hasta que una de las dos parejas alcancen los dos puntos.
            {
                desplegarListaFichas();//En cada pasada se le enseñará al usuario las fichas que tiene disponible cada jugador.

                bool cambio = false, dominacion = false, tranque = false, capicua = false;
                /*
                 La variable cambio se mantendrá false hasta que alguien juege o pase, luego cambiará a true para pasar al turno del siguiente jugador
                 La variable dominacion será falsa hasta que uno de los jugadores se quede sin ficha. Si el jugador se queda sin fichas es porque ganó las ronda.
                 Puede ser activada al final de las ronda si y solo si el jugador que jugó de ultimo podia ir por los dos extremos
                 */
                string temp = string.Empty, ficha = string.Empty;
                int cantidadPases = 0, puntaje = 0;

                /*
                 La variable cantidad pases sirve para saber cuantos pases seguidos han habido. Si hay 3 pases es porque un jugador tomó los 15 puntos por pase redondo, si hay 4 pases es porque el juego está trancado.
                 */
                {

                    /*
                        Este for sirve para buscar las piezas que se pueden jugar, en caso de que no se pueda jugar el torno pasará al otro jugador y mostrará en pantalla que ese jugador ha pasado.
                     */

                    for (int i = 1; i > 0;)
                    {
                        //Este if se cumplirá si la ficha va por el lado derecho. Entonces se introducirá esa ficha a la lista por cabeza
                        if ((Convert.ToString(aux.dato[i][1]) == extremos[0] || Convert.ToString(aux.dato[i][1]) == extremos[0] || Convert.ToString(aux.dato[i][3]) == extremos[0] || Convert.ToString(aux.dato[i][3]) == extremos[0]) && !cambio && !dominacion && !tranque)
                        {
                            Console.WriteLine("Preciona cualquier tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            lm.insertarNodoPrimero(aux.dato[i], extremos[0]);//Se mandan los parametros de la ficha tanto el por el cual se jugará y las propiedades de la ficha.
                            if (Convert.ToString(aux.dato[i][1]) == extremos[0])
                            {
                                extremos[0] = Convert.ToString(aux.dato[i][3]);//Se iguala el nuevo extremo al de la nueva ficha
                            }
                            else if (Convert.ToString(aux.dato[i][3]) == extremos[0])
                            {
                                extremos[0] = Convert.ToString(aux.dato[i][1]);//Se iguala el nuevo extremo al de la nueva ficha
                            }
                            if (cantidadPases == 3)
                            {
                                Console.WriteLine($"{aux.dato[0]} ha tomado 15 puntos por pasos redondo");
                                if (aux == primero || aux == primero.siguiente.siguiente)
                                {
                                    puntajeA.Enqueue(15);
                                }
                                else
                                {
                                    puntajeB.Enqueue(15);
                                }
                            }

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"Puntos:\nParejaA: {puntosParejaA}\nParejaB: {puntosParejaB}");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.WriteLine($"{aux.dato[0]} ha jugado {aux.dato[i]}");
                            desplegarListaFichas();
                            lm.desplegarListaPU();
                            aux.dato[i] = "llll";
                            if (aux.dato[1] + aux.dato[2] + aux.dato[3] + aux.dato[4] + aux.dato[5] + aux.dato[6] + aux.dato[7] == "llllllllllllllllllllllllllll")
                            {
                                //Console.WriteLine($"{aux.dato[0]} ha dominado.");
                                ganador = aux;
                                if ((Convert.ToString(aux.dato[i][1]) == extremos[0] && Convert.ToString(aux.dato[i][1]) == extremos[1]) || (Convert.ToString(aux.dato[i][1]) == extremos[0] && Convert.ToString(aux.dato[i][1]) == extremos[0]))
                                {
                                    capicua = true;
                                }
                                dominacion = true;
                            }
                            cambio = true;
                            if (cantidadPases == 3)
                            {

                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine($"{aux.dato[0]} ha tomado 15 puntos por pasos redondo");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                if (aux == primero || aux == primero.siguiente.siguiente)//En caso de que consiga un pase redondo conseguirá 15 puntos esa pareja.
                                {
                                    puntajeA.Enqueue(15);
                                }
                                else
                                {
                                    puntajeB.Enqueue(15);
                                }
                            }
                            cantidadPases = 0;
                            aux = aux.siguiente; //Se pasa el turno al siguiente jugador
                            i = 1;
                        }
                        //Este if se cumplirá si la ficha va por el lado izquierdo. Entonces se introducirá esa ficha a la lista por cola
                        else if ((Convert.ToString(aux.dato[i][1]) == extremos[1] || Convert.ToString(aux.dato[i][1]) == extremos[1] || Convert.ToString(aux.dato[i][3]) == extremos[1] || Convert.ToString(aux.dato[i][3]) == extremos[1]) && !cambio && dominacion == false && !tranque)
                        {
                            Console.WriteLine("Preciona cualquier tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            lm.insertarNodoUltimo(aux.dato[i], extremos[1]);
                            if (Convert.ToString(aux.dato[i][1]) == extremos[1])
                            {
                                extremos[1] = Convert.ToString(aux.dato[i][3]);//Se iguala el nuevo extremo al de la nueva ficha
                            }
                            else if (Convert.ToString(aux.dato[i][3]) == extremos[1])
                            {
                                extremos[1] = Convert.ToString(aux.dato[i][1]);//Se iguala el nuevo extremo al de la nueva ficha
                            }
                            if (cantidadPases == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine($"{aux.dato[0]} ha tomado 15 puntos por pasos redondo");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                if (aux == primero || aux == primero.siguiente.siguiente)//Si esta pareja consigue un pase redondo se le agregaran 15 puntos a su cola
                                {
                                    puntajeA.Enqueue(15);
                                }
                                else
                                {
                                    puntajeB.Enqueue(15);
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"Puntos:\nParejaA: {puntosParejaA}\nParejaB: {puntosParejaB}");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.WriteLine($"{aux.dato[0]} ha jugado {aux.dato[i]}");
                            desplegarListaFichas();
                            lm.desplegarListaPU();
                            aux.dato[i] = "llll";
                            if (aux.dato[1] + aux.dato[2] + aux.dato[3] + aux.dato[4] + aux.dato[5] + aux.dato[6] + aux.dato[7] == "llllllllllllllllllllllllllll")
                            {
                                ganador = aux;
                                if ((Convert.ToString(aux.dato[i][1]) == extremos[0] && Convert.ToString(aux.dato[i][1]) == extremos[1]) || (Convert.ToString(aux.dato[i][1]) == extremos[0] && Convert.ToString(aux.dato[i][1]) == extremos[0]))
                                {
                                    capicua = true;
                                }
                                dominacion = true;
                            }
                            cambio = true;
                            cantidadPases = 0;
                            aux = aux.siguiente; //Se pasa el turno al siguiente jugador
                            i = 1;
                        }
                        else if (!cambio && i == 7 && dominacion == false && !tranque)
                        {
                            Console.WriteLine("Preciona cualquier tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"Puntos:\nParejaA: {puntosParejaA}\nParejaB: {puntosParejaB}");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.WriteLine($"{aux.dato[0]} ha pasado.");
                            desplegarListaFichas();
                            lm.desplegarListaPU();
                            cantidadPases++;
                            if (cantidadPases == 4)
                                tranque = true;
                            i = 1;
                            aux = aux.siguiente;
                        }
                        else if (!cambio && dominacion == false && tranque == false)
                        {
                            i++;
                        }
                        if (dominacion)//Cuando a un jugador se le terminan todas las fichas
                        {
                            for (int k = 1; k < 8; k++)
                            {
                                if (aux.dato[k] != "llll")
                                {
                                    puntaje = puntaje + ((Convert.ToInt32(Convert.ToString(aux.dato[k][1]))) + (Convert.ToInt32(Convert.ToString(aux.dato[k][3]))));
                                }
                                if (k == 7)
                                {
                                    k = 1;
                                    aux = aux.siguiente;
                                    if (aux == ganador)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.WriteLine($"{ganador.dato[0]} ha dominado");
                                        desplegarListaFichas();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.BackgroundColor = ConsoleColor.Black;

                                        if (capicua)//En caso de que haya ganado con capicula se le incluiran 10 puntos extras
                                        {
                                            Console.WriteLine($"{ganador.dato[0]} ha ganado con capicua.");
                                            if (ganador == primero || ganador == primero.siguiente.siguiente)
                                            {
                                                puntajeA.Enqueue(10);
                                            }
                                            else
                                            {
                                                puntajeB.Enqueue(10);
                                            }

                                        }

                                        Console.WriteLine($"Puntos totales: {puntaje}");//Se imprime la cantidad de puntos que tiene cada pareja
                                        if (ganador == primero || ganador == primero.siguiente.siguiente)
                                        {
                                            puntajeA.Enqueue(puntaje);
                                        }
                                        else
                                        {
                                            puntajeB.Enqueue(puntaje);
                                        }

                                        break;
                                    }
                                }
                            }
                            break;
                        }
                        else if (tranque)
                        {
                            if (cantidadPases == 4)//En caso de que el juego se haya trancado. Se tomaran las fichas del ultimo que jugó con el siguiente jugador, el que tenga menos ficha gana el tranque
                            {
                                int p = 0;
                                if (p == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\n{aux.dato[0]} ha trancado el juego.");

                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;

                                Nodo delante = aux.siguiente;
                                int puntosA = 0;
                                int puntosB = 0;
                                int puntosC = 0;
                                int puntosD = 0;
                                for (int l = 1; l < 8; l++)
                                    //Se cuenta los puntos de cada jugador para sumarselo a la pareja que ganó
                                    //Se comparan los puntos del que trancó y del siguiente para saber quien ganó el tranque
                                {
                                    if (aux.dato[l] != "llll")
                                    {
                                        puntosA = puntosA + ((Convert.ToInt32(Convert.ToString(aux.dato[l][1]))) + (Convert.ToInt32(Convert.ToString(aux.dato[l][3]))));
                                    }
                                    if (delante.dato[l] != "llll")
                                    {
                                        puntosB = puntosB + ((Convert.ToInt32(Convert.ToString(delante.dato[l][1]))) + (Convert.ToInt32(Convert.ToString(delante.dato[l][3]))));
                                    }
                                    if (delante.siguiente.dato[l] != "llll")
                                    {
                                        puntosC = puntosC + ((Convert.ToInt32(Convert.ToString(delante.siguiente.dato[l][1]))) + (Convert.ToInt32(Convert.ToString(delante.siguiente.dato[l][3]))));
                                    }
                                    if (delante.siguiente.siguiente.dato[l] != "llll")
                                    {
                                        puntosD = puntosD + ((Convert.ToInt32(Convert.ToString(delante.siguiente.siguiente.dato[l][1]))) + (Convert.ToInt32(Convert.ToString(delante.siguiente.siguiente.dato[l][3]))));
                                    }
                                }
                                puntaje = puntosA + puntosB + puntosC + puntosD;
                                if (puntosA < puntosB)
                                {//En caso de que el que trancó tenga menos puntos el será el ganador, de lo contrario el siguiente jugador será el ganador.
                                    Console.WriteLine($"{aux.dato[0]} ha ganado el tranque.");
                                    puntajeA.Enqueue(puntaje);
                                    Console.WriteLine($"Puntos totales: {puntaje}");

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"{delante.dato[0]} ha ganado el tranque.");
                                    puntajeB.Enqueue(puntaje);
                                    Console.WriteLine($"Puntos totales: {puntaje}");
                                    break;
                                }
                            }

                        }
                        cambio = false;

                    }
                    lm.eliminarNodo();//Se limpia la mesa para la siguiente partida
                    repartirFichas();  //Se reparten las fichas para la siguiente partida.
                    puntosParejaA = 0; puntosParejaB = 0;
                    foreach (int puntaje1 in puntajeA)
                    {
                        puntosParejaA = puntosParejaA + puntaje1;//Se suman los puntos de la cola a la variable del total de punto de cada pareja
                    }
                    foreach (int puntaje1 in puntajeB)
                    {
                        puntosParejaB = puntosParejaB + puntaje1;//Se suman los puntos de la cola a la variable del total de punto de cada pareja
                    }

                }
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;

            //Se comparan los puntos para saber cual pareja fue la que ganó
            if (puntosParejaA >= 200)
            {
                Console.WriteLine("\nParejaA ha ganado");
            }
            else
            {
                Console.WriteLine("\nParejaB ha ganado");
            }

            Console.WriteLine("Puntaje parejaA");

            //Se imprimen uno por uno los elementos de la cosa(todos los puntos que iba consiguiendo la pareja).
            foreach (int puntaje in puntajeA)
            {
                Console.WriteLine(puntaje);
            }
            Console.WriteLine("Puntaje parejaB");
            foreach (int puntaje in puntajeB)
            {
                Console.WriteLine(puntaje);
            }
            Console.WriteLine($"Puntos:\nParejaA: {puntosParejaA}\nParejaB: {puntosParejaB}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

        }
    }
}


