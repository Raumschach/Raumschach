using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaumschachForm
{
    
    public class Cell
    {
        private string _name;
        private Piece _piece;
        public Cell(string name)
        {
            _name = name;
        }

        public void addPiece(Piece piece)
        {
            _piece = piece;
            if (piece != null) _piece.currentPos = _name;
        }

        public Piece getPiece()
        {
            return _piece;
        }

        public string getName()
        {
            return _name;
        }

        public bool hasPiece()
        {
            return _piece != null;
        }
    }
}
