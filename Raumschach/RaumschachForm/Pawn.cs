using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace RaumschachForm
{
     public class Pawn:Piece
    {
   //     private Image blackPawn = Image.FromFile
   //(Environment.CurrentDirectory + @"\Images\PawnB.png");
   //     private Image whitePawn = Image.FromFile
   //(Environment.CurrentDirectory + @"\Images\PawnW.png");

        public Pawn(bool white, string currentPos){
            base.white = white;
            base.currentPos = currentPos;
            MessageBox.Show(Environment.CurrentDirectory);
    }


    }
}
