using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScacchiLibrary
{
    public class Casella
    {     
       
        public int X { get; set; }
        public int Y { get; set; }        
        public Pezzo? Pezzo { get; set; }
        

        public Casella(int x, int y, Pezzo pezzo)
        {
            X = x;
            Y = y;
            this.Pezzo = pezzo;            
        }
       

        public override bool Equals(object? obj)
        {
            return obj is Casella casella &&
                   X == casella.X &&
                   Y == casella.Y;
        }
    }
}
