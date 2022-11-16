using ScacchiLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWFrorm
{
    internal class MyButton: Button
    {
        private readonly int _size = 100;
        public static int BtnSize { get { return 100; } }
        public int X { get; private set; }
        public int Y { get; private set; }
       
        public MyButton(int x, int y)
        {
            Height = Width = _size;                      
            X = x;
            Y = y;
            
        }
        public override string ToString()
        {
            return $"{X} | {Y}";
        }


    }
}
