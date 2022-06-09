using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    public class Square
    {
        public int idSquare { get; set; }
        public int display { get; set; }
        public bool snake { get; set; }
        public bool ladder { get; set; }

        public Square destination { get; set; }

        public Square(int idSquare, bool snake, bool ladder, Square destination)
        {
            this.idSquare = idSquare;
            this.display = idSquare + 1;
            this.snake = snake;
            this.ladder = ladder;
            this.destination = destination;
        }
    }


}
