using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScacchiLibrary;

public class Rook : Pezzo
{
    private readonly Direzione[] _moveSet =
    {
        new Direzione(-1, 0),
        new Direzione(1, 0),
        new Direzione(0, 1),
        new Direzione(0, -1),
    };

    

    public Rook(bool white) : base(white)
    {
        White = white;
    }

    

    public override string ToString()
    {
        return White ? "Rook" : "Black\nRook";
    }

    public override IEnumerable<Casella> GetLegalMoves(Griglia griglia, Casella casella)
    {

        for (int i = 0; i < _moveSet.Length; i++)
        {
            var move = _moveSet[i];
            int tempX = casella.X + move.X;
            int tempY = casella.Y + move.Y;
            var tempList = new LinkedList<Pezzo>();

            while (griglia.OnBoardCheck(tempX, tempY))
            {
                int x = tempX;
                int y = tempY;
                
                if (GameLogic.CheckPossibleMove(griglia, move, this, tempX, tempY))
                {
                    tempX += move.X;
                    tempY += move.Y;
                    if (tempList.Count > 0 && tempList.Last.Value != null) { break; }
                    tempList.AddLast(griglia.Scacchiera[x, y].Pezzo);
                    yield return griglia.Scacchiera[x, y];
                }
                else
                {
                    break;
                }
                
            }
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is Rook rook &&
               White == rook.White;
    }
}
