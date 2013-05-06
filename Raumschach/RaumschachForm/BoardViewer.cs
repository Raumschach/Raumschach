using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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


        public BoardViewer()
        {
            InitializeComponent();
            _board = new Board();
            _board.NewGame();
            moveWhite = true;
            UpdateBoard();
            lblPlayer1.BackColor = Color.Yellow;

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
            }
            else if (currentCell.HasPiece())
            {
                currentPanel.BackColor = Color.Red;

                currentMoves = currentCell.GetPiece().GetMoves(_board);

                foreach (
                    var tempPanel in currentMoves.Select(move => (Panel) Controls.Find(move, true).FirstOrDefault()))
                {
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
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
