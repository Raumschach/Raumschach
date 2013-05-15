using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
        private bool wCheck = false;
        private bool bCheck = false;
        ResourceManager rm;


        public BoardViewer()
        {
            InitializeComponent();
            _board = new Board();
            _board.NewGame();
            moveWhite = true;
            UpdateBoard();
            lblPlayer1.BackColor = Color.Goldenrod;
            this.menuStrip1.ForeColor = Color.White;

            rm = new ResourceManager("RaumschachForm.Properties.EnglishResources", typeof(BoardViewer).Assembly);

            //Text
            this.quitToolStripMenuItem.Text = rm.GetString("Quit");
            this.fileToolStripMenuItem.Text = rm.GetString("File");
            this.lblPlayer1.Text = rm.GetString("Player1");
            this.lblPlayer2.Text = rm.GetString("Player2");
            this.newGameToolStripMenuItem.Text = rm.GetString("NewGame");
            this.button1.Text = rm.GetString("NewGame");
            this.languageToolStripMenuItem.Text = rm.GetString("Language");
            this.button2.Text = rm.GetString("Checkmate");
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
                    else{BlackPlayerTaken.Controls.Add(deletePiece);}
                }
                moveNextClick = false;
                currentPanel.BackgroundImage = clearCell.GetPiece().GetImage();
                currentMoves.Add(clearCell.GetName());                

                makeMove();
                _board.MovePiece(clearCell.GetName(), currentCell.GetName());
            }
            else if (currentCell.HasPiece())
            {
                if (!moveWhite)
                {
                    var bQueen = _board._blackPieces.Find(c => c.GetType() == typeof(Queen));
                    if (bQueen != null) ((Queen)bQueen).movesSet = false;
                }
                else
                {
                    var wQueen = _board._whitePieces.Find(c => c.GetType() == typeof(Queen));
                    if (wQueen != null) ((Queen)wQueen).movesSet = false;
                }

                if(currentCell.GetPiece().GetType() != typeof(King))currentPanel.BackColor = Color.Red;

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
            //if (!bworker.IsBusy) bworker.RunWorkerAsync();
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
            lblPlayer1.BackColor = Color.Goldenrod;
            lblPlayer2.BackColor = WhitePlayerTaken.BackColor;
            WhitePlayerTaken.Controls.Clear();
            BlackPlayerTaken.Controls.Clear();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateMoves(object sender, DoWorkEventArgs e)
        {
            var bKing = _board._blackPieces.Find(c => c.GetType() == typeof(King));
            var wKing = _board._whitePieces.Find(c => c.GetType() == typeof(King));
           

            //if (moveWhite)
            //{
            //    var wQueen = _board._whitePieces.Find(b => b.GetType() == typeof(Queen));
            //    if (wQueen != null ) ((Queen)wQueen).movesSet = false;
            //    if (wKing != null) ((King)wKing).movesSet = false;

            //    if (wQueen != null) ((Queen)wQueen).SetMoves(_board);
            //    if (wKing != null) ((King)wKing).SetMoves(_board);

            //}
            //else
            //{
            //    var bQueen = _board._blackPieces.Find(d => d.GetType() == typeof(Queen));
            //    if (bQueen != null) ((Queen)bQueen).movesSet = false;
            //    if (bKing != null) ((King)bKing).movesSet = false;

            //    if (bQueen != null) ((Queen)bQueen).SetMoves(_board);
            //    if (bKing != null) ((King)bKing).SetMoves(_board);
            //}

            while (true)
            {
                var board = (Board)_board.Clone();
                if (board == null) continue;
                if (board.wCheck()) ((Panel)Controls.Find(wKing.CurrentPos, true).FirstOrDefault()).BackColor = Color.OrangeRed;
                else fixColors(new List<string>{wKing.CurrentPos});

                if (board.bCheck()) ((Panel)Controls.Find(bKing.CurrentPos, true).FirstOrDefault()).BackColor = Color.OrangeRed;
                else fixColors(new List<string> { bKing.CurrentPos });

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            if (moveWhite) {
                if (_board.wCheckmate())
                {
                    WinnerLabel.Text = rm.GetString("bWinner");
                    WinnerLabel.Refresh();
                    button2.Enabled = true;
                    return;
                }
            }
            else {
                if (_board.bCheckmate())
                {
                    WinnerLabel.Text = rm.GetString("wWinner");
                    WinnerLabel.Refresh();
                    button2.Enabled = true;
                    return;
                }                
            }
            WinnerLabel.Text = rm.GetString("nWinner");
            WinnerLabel.Refresh();
            System.Threading.Thread.Sleep(1500);
            WinnerLabel.Text = "";
            WinnerLabel.Refresh();
            button2.Enabled = true;

            //_board.state.Remove(_board.state[_board.state.Count -1]);
            //_board = _board.state[_board.state.Count - 1];
            //UpdateBoard();
            //moveWhite = !moveWhite;
            //var color = lblPlayer1.BackColor;
            //lblPlayer1.BackColor = lblPlayer2.BackColor;
            //lblPlayer2.BackColor = color;
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var language = ((ToolStripMenuItem)sender).Text;
            rm = new ResourceManager("RaumschachForm.Properties.EnglishResources", typeof(BoardViewer).Assembly);
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
            this.button2.Text = rm.GetString("Checkmate");
            //
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            this.fileToolStripMenuItem.ForeColor = Color.Black;
        }

        private void fileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            this.fileToolStripMenuItem.ForeColor = Color.White;
        }

        private void languageToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            this.languageToolStripMenuItem.ForeColor = Color.Black;
        }

        private void languageToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            this.languageToolStripMenuItem.ForeColor = Color.White;
        }

        private void buttonMouseEnter(object sender, EventArgs e)
        {
           var btn = (Button)sender;
            btn.BackgroundImage = global::RaumschachForm.Properties.Resources.SteelLight;
        }

        private void buttonMouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackgroundImage = global::RaumschachForm.Properties.Resources.SteelDark;
        }

        private void buttonMouseDown(object sender, MouseEventArgs e)
        {
            var btn = (Button)sender;
            btn.BackgroundImage = global::RaumschachForm.Properties.Resources.BlackSteel;
        }

        private void buttonMouseUp(object sender, MouseEventArgs e)
        {
            var btn = (Button)sender;
            btn.BackgroundImage = global::RaumschachForm.Properties.Resources.SteelLight;
        }

    }
}
