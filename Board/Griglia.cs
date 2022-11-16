using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ScacchiLibrary
{
    public class Griglia
    {
        private const int Size = 8;        
        public Casella[,] Scacchiera { get; private set; }
        public Griglia()
        {
            ResetScacchiera();
        }

        private void ResetScacchiera() 
        {
            
            Scacchiera = new Casella[Size, Size];
            //pezzi neri
            Scacchiera[0,0] = new Casella(0, 0, new Rook(false));
            Scacchiera[0,1] = new Casella(0, 1, new Knight(false));
            Scacchiera[0,2] = new Casella(0, 2, new Bishop(false));
            Scacchiera[0,3] = new Casella(0, 3, new Queen(false));
            Scacchiera[0,4] = new Casella(0, 4, new King(false));
            Scacchiera[0,5] = new Casella(0, 5, new Bishop(false));
            Scacchiera[0,6] = new Casella(0, 6, new Knight(false));
            Scacchiera[0,7] = new Casella(0, 7, new Rook(false));

            Scacchiera[1,0] = new Casella(1, 0, new Pawn(false));
            Scacchiera[1,1] = new Casella(1, 1, new Pawn(false));
            Scacchiera[1,2] = new Casella(1, 2, new Pawn(false));
            Scacchiera[1,3] = new Casella(1, 3, new Pawn(false));
            Scacchiera[1,4] = new Casella(1, 4, new Pawn(false));
            Scacchiera[1,5] = new Casella(1, 5, new Pawn(false));
            Scacchiera[1,6] = new Casella(1, 6, new Pawn(false));
            Scacchiera[1,7] = new Casella(1, 7, new Pawn(false));


            // pezzi bianchi
            Scacchiera[7,0] = new Casella(7, 0, new Rook(true));
            Scacchiera[7,1] = new Casella(7, 1, new Knight(true));
            Scacchiera[7,2] = new Casella(7, 2, new Bishop(true));
            Scacchiera[7,3] = new Casella(7, 3, new Queen(true));
            Scacchiera[7,4] = new Casella(7, 4, new King(true));
            Scacchiera[7,5] = new Casella(7, 5, new Bishop(true));
            Scacchiera[7,6] = new Casella(7, 6, new Knight(true));
            Scacchiera[7,7] = new Casella(7, 7, new Rook(true));

            Scacchiera[6, 0] = new Casella(6, 0, new Pawn(true));
            Scacchiera[6, 1] = new Casella(6, 1, new Pawn(true));
            Scacchiera[6, 2] = new Casella(6, 2, new Pawn(true));
            Scacchiera[6, 3] = new Casella(6, 3, new Pawn(true));
            Scacchiera[6, 4] = new Casella(6, 4, new Pawn(true));
            Scacchiera[6, 5] = new Casella(6, 5, new Pawn(true));
            Scacchiera[6, 6] = new Casella(6, 6, new Pawn(true));
            Scacchiera[6, 7] = new Casella(6, 7, new Pawn(true));

            // resto delle caselle
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < Size; j++)
                {   
                    Scacchiera[i, j] = new Casella(i, j, null);
                }
            }           
        }

        public bool OnBoardCheck(int x, int y)
        {
            return (x >= 0 && x <= 7 && y >= 0 && y <= 7);           
           
        }
       



    }
}
