namespace RaumschachForm
{
    
    public class Cell
    {
        private readonly string _name;
        private Piece _piece;
        private Piece _previousPiece;
        public Cell(string name)
        {
            _name = name;
            _previousPiece = null;
            _piece = null;
        }

        public void AddPiece(Piece piece)
        {
            _previousPiece = _piece;
            _piece = piece;
            if (piece != null) _piece.CurrentPos = _name;
        }

        public Piece GetPiece()
        {
            return _piece;
        }

        public Piece GetPreviousPiece()
        {
            return _previousPiece;
        }

        public void RestorePreviousPiece()
        {
            _piece = _previousPiece;
            _previousPiece = null;
        }

        public string GetName()
        {
            return _name;
        }

        public bool HasPiece()
        {
            return _piece != null;
        }
        public override bool Equals(object obj)
        {
            return obj is Cell && this._name == ((Cell) obj)._name;
        }
    }
}
