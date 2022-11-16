using ScacchiLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScacchiLibrary
{
    public static class GameLogic
    {
       
        public static bool CanMove(IEnumerable<Casella> mosse, Casella destinazione)
        {
            return mosse.Contains(destinazione);
        }
        public static bool CheckPossibleMove(Griglia griglia, Direzione d, Pezzo pezzo, int x, int y)
        {
            bool color = pezzo.White;
                   
            if (griglia.Scacchiera[x, y].Pezzo == null) return true;
            else if (griglia.Scacchiera[x, y].Pezzo != null)
            {
                if (griglia.Scacchiera[x, y].Pezzo.White == color) return false;
                else if (griglia.Scacchiera[x, y].Pezzo.White != color &&
                    griglia.Scacchiera[x - d.X, y - d.Y].Pezzo != null)
                {
                    if (griglia.Scacchiera[x - d.X, y - d.Y].Pezzo.Equals(pezzo)) return true;
                    else return false;
                }
                else if (griglia.Scacchiera[x, y].Pezzo.White != color &&
                        griglia.Scacchiera[x - d.X, y - d.Y].Pezzo == null) return true;
            }
            return false;
        }
        public static bool CheckPossiblePawnMove(Griglia griglia, Direzione d, Pezzo pezzo, int x, int y)
        {             
            bool color = pezzo.White;
            var direzioneMangia = color ? new Direzione(-1, -1) : new Direzione(1, 1);
            var direzioneMangiaDue = color ? new Direzione(-1, 1) : new Direzione(1, -1);
            if (d.Equals(direzioneMangia))
            {
                if (griglia.Scacchiera[x, y].Pezzo != null && griglia.Scacchiera[x, y].Pezzo.White != color) return true;
                else return false;
            }
            else if (d.Equals(direzioneMangiaDue))
            {
                if (griglia.Scacchiera[x, y].Pezzo != null && griglia.Scacchiera[x, y].Pezzo.White != color) return true;
                else return false;
            }
            else if (griglia.Scacchiera[x, y].Pezzo == null) return true;
            return false;
        }
    }
}

