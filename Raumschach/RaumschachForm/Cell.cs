namespace RaumschachForm
{
    
    public class Cell
    {
        private readonly string _name;
        private Piece _piece;
        public Cell(string name)
        {
            _name = name;
        }

        public void AddPiece(Piece piece)
        {
            _piece = piece;
            if (piece != null) _piece.CurrentPos = _name;
        }

        public Piece GetPiece()
        {
            return _piece;
        }

        public string GetName()
        {
            return _name;
        }

        public bool HasPiece()
        {
            return _piece != null;
        }
    }
}
