using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaumschachForm
{
    public partial class BoardViewer : Form
    {
        private bool moveNextClick = false;
        private Panel panelToClear;
        public Board _board;
        List<string> currentMoves = new List<string>();
        private bool moveWhite;
        private BackgroundWorker bworker;
        //private bool wCheck = false;
        private bool bCheck = false;
        private int currentStateIndex;


        public BoardViewer()
        {
            InitializeComponent();
            _board = new Board();
            _board.NewGame();
            moveWhite = true;
            UpdateBoard();
            lblPlayer1.BackColor = Color.Yellow;
            currentStateIndex = 0;


            var rm = new ResourceManager("RaumschachForm.Properties.EnglishResources", typeof(BoardViewer).Assembly);
            

            //Text
            this.quitToolStripMenuItem.Text = rm.GetString("Quit");
            this.fileToolStripMenuItem.Text = rm.GetString("File");
            this.lblPlayer1.Text = rm.GetString("Player1");
            this.lblPlayer2.Text = rm.GetString("Player2");
            this.newGameToolStripMenuItem.Text = rm.GetString("NewGame");
            this.button1.Text = rm.GetString("NewGame");
            this.languageToolStripMenuItem.Text = rm.GetString("Language");
            //
            
            bworker = new BackgroundWorker();
            bworker.DoWork += new DoWorkEventHandler(UpdateMoves);
            bworker.RunWorkerAsync();
        }

       private void UpdateBoard()
       {
           for (var brd = 0; brd < 5; brd++)
           {
               for (var row = 0; row < 5; row++)
               {
                   for (var col = 0; col < 5; col++)
                   {
                       var cell = _board._board[brd][row, col];
                       var currentPanel = (Panel)Controls.Find(cell.GetName(), true).FirstOrDefault();

                       if (currentPanel != null) currentPanel.BackgroundImage = cell.HasPiece() ? cell.GetPiece().GetImage() : null;
                   }
               }
           }
       }

        public void SelectedSquare(object sender, EventArgs e)
        {
            
            var currentPanel = (Panel)sender;
            var currentCell = _board.GetCell(currentPanel.Name);

            if (currentCell.GetPiece() != null && (moveWhite != currentCell.GetPiece().White && !moveNextClick))
            {
                return;
            }


            //Deselect
            if (panelToClear != null && currentPanel.Name == panelToClear.Name)
            {
                currentMoves.Add(currentCell.GetName());
                fixColors(currentMoves);
                moveNextClick = false;
                panelToClear = null;
                return;
            }
            if (moveNextClick)
            {
                if (!currentMoves.Contains(currentCell.GetName())) return;
                var clearCell = _board.GetCell(panelToClear.Name);
                if (currentCell.HasPiece())
                {
                    var deletePiece = new Panel { Size = Aa1.Size, BackColor = WhitePlayerTaken.BackColor, BackgroundImage = currentCell.GetPiece().GetImage(), BackgroundImageLayout = Aa1.BackgroundImageLayout };
                    if (moveWhite) { WhitePlayerTaken.Controls.Add(deletePiece); }
                    else BlackPlayerTaken.Controls.Add(deletePiece);
                }
                moveNextClick = false;
                currentPanel.BackgroundImage = clearCell.GetPiece().GetImage();
                currentMoves.Add(clearCell.GetName());                

                makeMove();
                _board.MovePiece(clearCell.GetName(), currentCell.GetName());
                
                currentStateIndex++;
            }
            else if (currentCell.HasPiece())
            {
                currentPanel.BackColor = Color.Red;

                currentMoves = currentCell.GetPiece().GetMoves(_board);

                foreach (
                    var tempPanel in currentMoves.Select(move => (Panel) Controls.Find(move, true).FirstOrDefault()))
                {
                    if (tempPanel.Name != currentPanel.Name)
                        tempPanel.BackColor = Color.Yellow;
                }
                moveNextClick = true;
                panelToClear = currentPanel;
            }

        }

        public void makeMove(){
            panelToClear.BackgroundImage = null;
            fixColors(currentMoves);
            moveWhite = !moveWhite;
            var color = lblPlayer1.BackColor;
            lblPlayer1.BackColor = lblPlayer2.BackColor;
            lblPlayer2.BackColor = color;
            currentMoves = new List<string>();
            bworker.RunWorkerAsync();
        }

        public void fixColors(List<string> moves )
        {
            foreach (var move in moves)
            {
                int brd = _board.GetBoardNumber(move);
                int row = _board.GetCellRow(move);
                int col = _board.GetCellCol(move);
                Panel curPanel = (Panel) Controls.Find(move, true).FirstOrDefault();
                if (curPanel == null) continue;
                if ((row%2 == 0 && col%2 == 0) || (row%2 != 0 && col%2 != 0))
                {
                    curPanel.BackColor = (brd%2 == 0) ? Color.Black : Color.White;
                }
                else
                {
                    curPanel.BackColor = (brd%2 == 0) ? Color.White : Color.Black;
                }

            }
        }

        public void sendClick(string cellName)
        { 
            var panel = new Panel();
            panel.Name = cellName;
            Invoke(new EventHandler(SelectedSquare), panel);
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            _board = new Board();
            _board.NewGame();
            UpdateBoard();
            moveWhite = true;
            lblPlayer1.BackColor = Color.Yellow;
            lblPlayer2.BackColor = WhitePlayerTaken.BackColor;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool wCheck()
        {
            var king = _board._whitePieces.Find(c => c.GetType() == typeof(King));
            foreach (var bPieces in _board._blackPieces)
            {
                if (bPieces.GetMoves(_board).Contains(king.CurrentPos)){
                    return true;
                }
            }
            return false;
        }

        private void UpdateMoves(object sender, DoWorkEventArgs e)
        {
            var bKing = _board._blackPieces.Find(c => c.GetType() == typeof(King));
            var wKing = _board._whitePieces.Find(c => c.GetType() == typeof(King));
           

            if (moveWhite)
            {
                var wQueen = _board._whitePieces.Find(b => b.GetType() == typeof(Queen));
                ((Queen)wQueen).movesSet = false;                
                ((King)wKing).movesSet = false;

                ((Queen)wQueen).SetMoves(_board);
                ((King)wKing).SetMoves(_board);

                foreach (var bPieces in _board._blackPieces){

                }
            }
            else
            {
                var bQueen = _board._blackPieces.Find(d => d.GetType() == typeof(Queen));
                ((Queen)bQueen).movesSet = false;
                ((King)bKing).movesSet = false;

                ((Queen)bQueen).SetMoves(_board);
                ((King)bKing).SetMoves(_board);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentStateIndex--;
             //_board.state.Remove(_board.state[currentStateIndex + 1]);
            _board =_board.state[currentStateIndex];
            UpdateBoard();
            moveWhite = !moveWhite;
            var color = lblPlayer1.BackColor;
            lblPlayer1.BackColor = lblPlayer2.BackColor;
            lblPlayer2.BackColor = color;
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var language = ((ToolStripMenuItem)sender).Text;
            ResourceManager rm = new ResourceManager("RaumschachForm.Properties.EnglishResources", typeof(BoardViewer).Assembly);;
            switch (language)
            {
                case "Français":
                    rm = new ResourceManager("RaumschachForm.Properties.FrenchResources", typeof(BoardViewer).Assembly);
                    break;
                case "Deutsch":
                    rm = new ResourceManager("RaumschachForm.Properties.GermanResources", typeof(BoardViewer).Assembly);
                    break;
            }

            //Text
            this.quitToolStripMenuItem.Text = rm.GetString("Quit");
            this.fileToolStripMenuItem.Text = rm.GetString("File");
            this.lblPlayer1.Text = rm.GetString("Player1");
            this.lblPlayer2.Text = rm.GetString("Player2");
            this.newGameToolStripMenuItem.Text = rm.GetString("NewGame");
            this.button1.Text = rm.GetString("NewGame");
            this.languageToolStripMenuItem.Text = rm.GetString("Language");
            //
        }

    }
}
