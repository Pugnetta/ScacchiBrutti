namespace ScacchiLibrary
{
    internal class King : Pezzo
    {
        private readonly Direzione[] _moveSet =
        {
        new Direzione(-1, 0),
        new Direzione(1, 0),
        new Direzione(0, 1),
        new Direzione(0, -1),
        new Direzione(-1, -1),
        new Direzione(-1, 1),
        new Direzione(1, -1),
        new Direzione(1, 1),
        };
        public King(bool white) : base(white)
        {
            White = white;
        }

        public override bool Equals(object? obj)
        {
            return obj is King king &&
                   White == king.White;
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
            // TODO: king logic
        }


        public override string ToString()
        {
            return White ? "King" : "Black\nKing";
        }
    }
}