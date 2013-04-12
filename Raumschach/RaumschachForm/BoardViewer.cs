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
        private Image pieceToMove;
        private Panel panelToClear;
        private Board _board; 


        public BoardViewer()
        {
            InitializeComponent();
            _board = new Board();
            UpdateBoard();

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
                       if (!cell.HasPiece()) continue;
                       var currentPanel = (Panel)Controls.Find(cell.GetName(), true).FirstOrDefault();
                       if (currentPanel != null) currentPanel.BackgroundImage = cell.GetPiece().GetImage();
                   }
               }
           }
       }

        public void SelectedSquare(object sender, EventArgs e)
        {
            var currentPanel = (Panel)sender;
            var currentCell = _board.GetCell(currentPanel.Name);
            List<string> moves = new List<string>();
            if (currentCell.HasPiece()){
                
                moves = currentCell.GetPiece().Getmoves(_board);
            }

            foreach (var move in moves)
            {
                var tempPanel = (Panel)Controls.Find(move, true).FirstOrDefault();
                var brdr = new BorderStyle();

                tempPanel.BackColor = Color.Yellow;
            }


            if (currentPanel == panelToClear)
                return;
            if (moveNextClick)
            {
                moveNextClick = false;
                currentPanel.BackgroundImage = pieceToMove;
                panelToClear.BackgroundImage = null;
            }
            else if (currentPanel.BackgroundImage != null)
            {
                moveNextClick = true;
                pieceToMove = currentPanel.BackgroundImage;
                panelToClear = currentPanel;
            }

        }

        private void fixColors()
        {
            
        }

    }
}
