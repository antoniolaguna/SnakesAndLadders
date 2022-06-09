using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    internal static class Utils
    {
        public static int RandomNumber(int minValue, int maxValue)
        {
            int res = 0;
            //dormimos el hilo unos milisegundos, para que varie la semilla del random. Genera numeros mas aleatorios
            Thread.Sleep(15);
            Random rand = new Random((int)DateTime.Now.Ticks);
            res = rand.Next(minValue, maxValue + 1);
            return res;
        }

    }
}
