using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScacchiLibrary
{
    public abstract class Pezzo
    {        
        public bool White { get; set; }

        public  Pezzo(bool white)
        {
            White = white;
        }
        public abstract IEnumerable<Casella> GetLegalMoves(Griglia griglia, Casella casella);
        public abstract override string ToString();

        public abstract override bool Equals(object? obj);
        
    }
}
