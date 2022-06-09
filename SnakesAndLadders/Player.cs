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

        public Player(long id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
