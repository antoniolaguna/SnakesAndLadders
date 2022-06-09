using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    public class Game
    {
        public Board board { get; set; }
        public List<Player> players { get; set; }
        private bool Finished { get; set; }

        public Player Winner { get; set; }


        public Game(int boardLenght, int numPlayers)
        {
            Finished = false;
            this.board = new Board(boardLenght);
            this.players = new List<Player>();
            for (int i = 0; i < numPlayers; i++)
            {
                players.Add(new Player(i + 1, "Player " + (i + 1).ToString(), this.board.squares[0]));
            }
        }



        public void NewRoll(int idPlayer)
        {
            Player selectedPlayer = players[0];
            foreach (Player p in players)
            {
                if (p.id == idPlayer)
                {
                    selectedPlayer = p;
                }
            }

            if (selectedPlayer != null)
            {
                Console.WriteLine("Va a tirar " + selectedPlayer.name);
                Console.WriteLine("Posicion inicial: " + selectedPlayer.position.display);

                int initialPosition = selectedPlayer.position.idSquare;
                int roll = Utils.RandomNumber(1, 6);
                Console.WriteLine("Saca un: " + roll.ToString());
                int finalPosition = initialPosition + roll;

                //En el caso de que la posicion final sea superior al limite, mantenemos posicion
                if (finalPosition > this.board.lenght - 1)
                {
                    Console.WriteLine("Nos salimos del tablero, mantemos posicion");
                }
                else
                {
                    MovePlayer(selectedPlayer, finalPosition);
                    if (IsWinner(selectedPlayer))
                    {
                        Console.WriteLine("Ganador: " + selectedPlayer.name);

                        this.Finished = true;
                        this.Winner = selectedPlayer;
                    }
                }


            }
        }

        //simulacion de una tirada, imponiendo el numero a salir en el dado. Para test
        public void NewRoll(int idPlayer, int roll)
        {
            Player selectedPlayer = players[0];
            foreach (Player p in players)
            {
                if (p.id == idPlayer)
                {
                    selectedPlayer = p;
                }
            }

            if (selectedPlayer != null)
            {
                Console.WriteLine("Va a tirar " + selectedPlayer.name);
                Console.WriteLine("Posicion inicial: " + selectedPlayer.position.display);

                int initialPosition = selectedPlayer.position.idSquare;
                Console.WriteLine("Saca un: " + roll.ToString());
                int finalPosition = initialPosition + roll;

                //En el caso de que la posicion final sea superior al limite, mantenemos posicion
                if (finalPosition > this.board.lenght - 1)
                {
                    Console.WriteLine("Nos salimos del tablero, mantemos posicion");
                }
                else
                {
                    MovePlayer(selectedPlayer, finalPosition);
                    if (IsWinner(selectedPlayer))
                    {
                        Console.WriteLine("Ganador: " + selectedPlayer.name);

                        this.Finished = true;
                        this.Winner = selectedPlayer;
                    }
                }


            }
        }

        private void MovePlayer(Player selectedPlayer, int finalPosition)
        {
            selectedPlayer.position = this.board.squares[finalPosition];
            Console.WriteLine("Posicion final: " + selectedPlayer.position.display);

            if (selectedPlayer.position.snake)
            {
                Console.WriteLine("Es una serpiente, asi que descendemos a: " + selectedPlayer.position.destination.display);
                MovePlayer(selectedPlayer, selectedPlayer.position.destination.idSquare);
            }
            else if (selectedPlayer.position.ladder)
            {
                Console.WriteLine("Es una escalera, asi que ascendemos a: " + selectedPlayer.position.destination.display);
                MovePlayer(selectedPlayer, selectedPlayer.position.destination.idSquare);
            }
        }

        private bool IsWinner(Player selectedPlayer)
        {
            bool res = false;
            if (selectedPlayer.position.idSquare == this.board.lenght - 1)
            {
                res = true;
            }
            return res;
        }

        public bool IsFinished()
        {
            return this.Finished;
        }



    }
}
