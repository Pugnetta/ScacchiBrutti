using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScacchiLibrary
{
    
    internal class Knight : Pezzo
    {
        private readonly Direzione[] _moveSet =
       {
        new Direzione(-2, 1),
        new Direzione(-2, -1),
        new Direzione(-1, 2),
        new Direzione(-1, -2),
        new Direzione(2, -1),
        new Direzione(2, 1),
        new Direzione(1, -2),
        new Direzione(1, 2),
        };
        public Knight(bool white) : base(white)
        {
            White = white;
        }

        public override bool Equals(object? obj)
        {
            return obj is Knight knight &&
                   White == knight.White;
        }

        public override IEnumerable<Casella> GetLegalMoves(Griglia scacchiera, Casella casella)
        {
            foreach (var move in _moveSet)
            {
                int tempX = casella.X + move.X;
                int tempY = casella.Y + move.Y;
                if (scacchiera.OnBoardCheck(tempX, tempY))
                {
                    if (GameLogic.CheckPossibleMove(scacchiera, move, this, tempX, tempY))
                        yield return scacchiera.Scacchiera[tempX, tempY];
                }
            }
        }

        public override string ToString()
        {
            return White ? "Knight" : "Black\nKnight";
        }
    }
}
