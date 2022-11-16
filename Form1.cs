using ScacchiLibrary;


namespace ChessWFrorm
{
    public partial class Scacchiera : Form
    {
        private readonly int _rows = 8;
        private readonly int _cols = 8;
        private MyButton[,] _btnGriglia;
        private Griglia _griglia;
        private Pezzo? _pezzoSelezionato;
        private Casella _attuale;
        
        public Scacchiera()
        {
            InitializeComponent();
            CreaScacchiera();

        }

        private void Scacchiera_Load(object sender, EventArgs e)
        {

        }
        private void CreaScacchiera()
        {
            _griglia = new Griglia();
            _btnGriglia = new MyButton[_rows, _cols];
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    _btnGriglia[i, j] = new MyButton(i, j);
                    if (_griglia.Scacchiera[i, j].Pezzo != null)
                    {
                        _btnGriglia[i, j].Text = _griglia.Scacchiera[i, j].Pezzo.ToString();
                    }
                    _btnGriglia[i, j].Click += Griglia_Click;


                    Board_Panel.Controls.Add(_btnGriglia[i, j]);
                    _btnGriglia[i, j].Location = new Point(j * MyButton.BtnSize, i * MyButton.BtnSize);
                }
            }
            ColoraScacchiera();
            
        }

       

        private void ColoraScacchiera()
        {
            bool white = true;
            int count = 0;
            foreach (var btn in _btnGriglia)
            {
                if (count % 8 == 0 && count != 0)
                {
                    white = white ? false : true;
                }
                if (white)
                {
                    btn.BackColor = Color.AntiqueWhite;
                    white = false;
                }
                else
                {
                    btn.BackColor = Color.GreenYellow;
                    white = true;
                }
                count++;
            }
        }

        private void Griglia_Click(object? sender, EventArgs e)
        {
            var btn = (MyButton)sender;
            Casella tempCasella = _attuale;
            _attuale = _griglia.Scacchiera[btn.X, btn.Y];
            if (btn.Text == "+")
            {
                MovePiece(_attuale, tempCasella);
                ResetDisplay();
            }
            else if (_attuale.Pezzo != null)
            {
                ResetDisplay();
                DisplayLegalMoves(_attuale);
                _pezzoSelezionato = _attuale.Pezzo;
            }
            else if (_attuale.Pezzo == null)
            {
                _pezzoSelezionato = null;
                ResetDisplay();
            }


        }

        private void DisplayLegalMoves(Casella attuale)
        {
            var list = attuale.Pezzo.GetLegalMoves(_griglia, attuale);
            foreach (var c in _griglia.Scacchiera)
            {
                if (list.Contains(c)) _btnGriglia[c.X, c.Y].Text = "+";
            }
        }
        private void ResetDisplay()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    if (_griglia.Scacchiera[i, j].Pezzo != null)
                    {
                        _btnGriglia[i, j].Text = _griglia.Scacchiera[i, j].Pezzo.ToString();
                    }
                    else _btnGriglia[i, j].Text = "";
                }
            }
        }
        private void MovePiece(Casella attuale, Casella vecchia)
        {
            
            attuale.Pezzo = _pezzoSelezionato;
            vecchia.Pezzo = null;

        }

       

        private void ResetGame_Click(object sender, EventArgs e)
        {
            Board_Panel.Controls.Clear();
            CreaScacchiera();
        }


    }
}