using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RaumschachForm
{
    public abstract class Piece
    {
        public Image myImage;
        public bool white;
        public string currentPos;
        public abstract List<String> getmoves(Board board);
        public Image getImage()
        {
            return null;
        }
        public bool Equals(Piece pc)
        {
            return this.white == pc.white && this.currentPos == pc.currentPos && this.myImage == pc.myImage;
        }


    }
}