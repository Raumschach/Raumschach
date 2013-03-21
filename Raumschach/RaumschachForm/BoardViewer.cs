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

            var variable=Image.FromFile
   (Environment.CurrentDirectory+@"\Images\PawnW.png");
            Aa1.BackgroundImage = variable;
            


        }

       

        public void SelectedSquare(object sender, EventArgs e)
        {
            _board.movePiece("Aa1", "Aa2");
            var currentPanel = (Panel)sender;
            if (currentPanel == panelToClear) return;
            if (moveNextClick)
            {

                moveNextClick = false;
                currentPanel.BackgroundImage = pieceToMove;
                panelToClear.BackgroundImage = null;
            }
            if (currentPanel.BackgroundImage != null)
            {
                moveNextClick = true;
                pieceToMove = currentPanel.BackgroundImage;
                panelToClear = currentPanel;
            }



        }

    }
}
