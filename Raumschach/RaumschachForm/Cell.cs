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

        public void RestorePreviousPiece(Board board)
        {
            _piece = _previousPiece;

            if (_piece != null)
            {
                _piece.CurrentPos = this._name;
                if (_piece.White && !board._whitePieces.Contains(_piece)) board._whitePieces.Add(_piece);
                else if (!_piece.White && !board._blackPieces.Contains(_piece)) board._blackPieces.Add(_piece);
            }            
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
