using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    public class Player
    {
        public long id { get; set; }
        public string name { get; set; }
        public Square position { get; set; }

        public Player(long id, string name, Square initialPosition)
        {
            this.id = id;
            this.name = name;
            //simepre inicializamos la posicion inicial a 0
            this.position = initialPosition;
        }
    }
}
