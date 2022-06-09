using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    public class Board
    {
        public int lenght { get; set; }
        public Square[] squares { get; set; }

        public Board(int lenght)
        {
            this.lenght = lenght;
            this.squares = new Square[lenght];
        }
    }
}
