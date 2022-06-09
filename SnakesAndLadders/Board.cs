using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    /*He tomado la decision de representar el tablero con una matriz unidireccional de casillas.
     Aunque el dibujo se represente en dos dimensiones, no veo razón para hacer una matriz bidireccional
    Hacer una matriz bidireccional me complicaria a la hora de mover el token entre las diferentes filas, y segun veo en la reglas,
    la unica ventaja de hacerla bidireccional seria para mostrarlo por pantalla, pero para ello ya la trasformo a bidireccional a la hora de mostrarla*/
    /*La propiedad lengh sobraria, pero es mas comodo acceder a la variable lenght que a squares.lenght*/
    public class Board
    {
        public int lenght { get; set; }
        public Square[] squares { get; set; }

      
        public Board(int lenght)
        {
            this.lenght = lenght;
            this.squares = new Square[lenght];
            GenerateRandomBoard();
        }

        /*Esta funcion genera de forma aleatoria el tablero. No me termina de convencer que sea llamada desde el contructor, ya que al ser
         un metodo pesado, podria retrasar la creacion del objeto board*/
        private void GenerateRandomBoard()
        {
            for (int i = 0; i < this.lenght; i++)
            {
                if (i == 0 || i == this.lenght - 1)
                {
                    //casilla inicial y final deben ser casillas normales
                    squares[i] = new Square(i, false, false, null);
                }
                else
                {
                    int squareType = Utils.RandomNumber(1, 10);
                    if (squareType == 1)
                    {
                        //10% de las veces es una serpiente, marcamos la casilla como serpiente y posteriormente le asignaremos un destino
                        //porque aun no estarian creados todos los destinos
                        squares[i] = new Square(i, true, false, null);
                    }
                    else if (squareType == 2)
                    {
                        //10% de las veces es una escalera, marcamos la casilla como escalera y posteriormente le asignaremos un destino
                        //porque aun no estarian creados todos los destinos
                        squares[i] = new Square(i, false, true, null);
                    }
                    else
                    {
                        //80% de las veces es una casilla normal
                        squares[i] = new Square(i, false, false, null);
                    }
                }
            }

            //aqui asignamos los destinos a las serpientes y las escaleras
            for (int i = 0; i < this.lenght; i++)
            {
                if (squares[i].snake)
                {
                    //es una casilla serpierte, le asignamos un destino entre el inicio (1) y su posicion
                    //No hace falta comprobar que no sea una posicion inicial ni final, porque ya hemos limitado la creacion de serpientes y escaleras
                    int destination = Utils.RandomNumber(0, i - 1);
                    squares[i].destination = squares[destination];
                }
                else if (squares[i].ladder)
                {
                    //es una casilla escalera, le asignamos un destino entre su posicion y el final del tablero
                    //No hace falta comprobar que no sea una posicion inicial ni final, porque ya hemos limitado la creacion de serpientes y escaleras
                    int destination = Utils.RandomNumber(i + 1, lenght - 1);
                    squares[i].destination = squares[destination];
                }
            }
        }

        public override string ToString()
        {
            string result = "";
            int width = Convert.ToInt32(Math.Sqrt(lenght));
            int widthPointer = 0;
            foreach (Square square in squares)
            {
                if (widthPointer == width)
                {
                    widthPointer = 1;
                    result = result + "\n";
                }
                else
                {
                    widthPointer++;
                }

                if (square.snake)
                {
                    result = result + ("|S(" + square.destination.display.ToString() + ")|");
                }
                else if (square.ladder)
                {
                    result = result + ("|L(" + square.destination.display.ToString() + ")|");

                }
                else
                {
                    result = result + ("|" + square.display.ToString() + "|");
                }

            }
            return result;
        }
    }
}
