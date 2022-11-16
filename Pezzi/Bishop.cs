namespace ScacchiLibrary
{
    internal class Bishop : Pezzo
    {
        private readonly Direzione[] _moveSet =
        {
        new Direzione(-1, -1),
        new Direzione(-1, 1),
        new Direzione(1, -1),
        new Direzione(1, 1),
        };
        public Bishop(bool white) : base(white)
        {
            White = white;
        }

        public override bool Equals(object? obj)
        {
            return obj is Bishop bishop &&
                   White == bishop.White;
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

        public override string ToString()
        {
            return White ? "Bishop" : "Black\nBishop";
        }
    }
}