using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScacchiLibrary
{
    public class Direzione
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Direzione(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            return obj is Direzione direzione &&
                   X == direzione.X &&
                   Y == direzione.Y;
        }
    }
}
