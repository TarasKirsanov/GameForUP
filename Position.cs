using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit__Game
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Update(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
