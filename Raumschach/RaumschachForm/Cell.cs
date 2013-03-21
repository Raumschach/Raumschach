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
        private string _piece;
        public Cell(string name)
        {
            _name = name;
        }

        public void addPiece(string piece)
        {
            _piece = piece;
        }

        public string getPiece()
        {
            return _piece;
        }
    }
}
