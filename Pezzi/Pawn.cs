using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScacchiLibrary
{
    public class Pawn : Pezzo
    {
        private readonly Direzione[] _moveSetWhite =
        {
        new Direzione(-1, 0),
        // TODO: new Direzione(-2, 0) e enpassant o come caz se scrive       
        new Direzione(-1, -1),
        new Direzione(-1, 1),        
        };
        private readonly Direzione[] _moveSetBlack =
        {
       
        new Direzione(1, 0),
        //new Direzione(2, 0),
        new Direzione(1, -1),
        new Direzione(1, 1),
        };
        public Pawn(bool white) : base(white)
        {
            White = white;
        }

        public override bool Equals(object? obj)
        {
            return obj is Pawn pawn &&
                   White == pawn.White;
        }

        public override IEnumerable<Casella> GetLegalMoves(Griglia griglia, Casella casella)
        {
            if (White)
            {
                for (int i = 0; i < _moveSetWhite.Length; i++)
                {
                    var move = _moveSetWhite[i];
                    int tempX = casella.X + move.X;
                    int tempY = casella.Y + move.Y;
                    if (griglia.OnBoardCheck(tempX, tempY))
                    {
                        if (GameLogic.CheckPossiblePawnMove(griglia, move, this, tempX, tempY)) yield return griglia.Scacchiera[tempX, tempY];
                    }
                }
            }
            else
            {
                for (int i = 0; i < _moveSetBlack.Length; i++)
                {
                    var move = _moveSetBlack[i];
                    int tempX = casella.X + move.X;
                    int tempY = casella.Y + move.Y;
                    if (griglia.OnBoardCheck(tempX, tempY))
                    {
                        if (GameLogic.CheckPossiblePawnMove(griglia, move, this, tempX, tempY)) yield return griglia.Scacchiera[tempX, tempY];
                    }
                }
            }
        }

        public override string ToString()
        {
            return White ? "Pawn" : "Black\nPawn";
        }
    }
}
