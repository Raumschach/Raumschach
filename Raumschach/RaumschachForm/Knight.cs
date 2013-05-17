using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaumschachForm
{
    //It's not the piece Gotham wants, it's the piece Gotham need
    //It's the Dark Knight
    public class Knight: Piece
    {

        #if (!MYTEST)
                public readonly Image BlackKnight = Image.FromFile
                    (Environment.CurrentDirectory + @"\Images\KnightB.png"); //Bruce Wayne

                public readonly Image WhiteKnight = Image.FromFile(Environment.CurrentDirectory + @"\Images\KnightW.png"); //THarvey Two Face
                #endif
                #if (MYTEST)
                            public readonly Image BlackKnight;
                    public readonly Image WhiteKnight;
        #endif

        public Knight(bool white, string currentPos)
        {
            #if (MYTEST)
                        var folder = Environment.SpecialFolder.MyDocuments;
                        if (folder.ToString().Contains("iversoda"))
                        {
                            BlackKnight = Image.FromFile
                             (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\KnightB.png");
                            WhiteKnight = Image.FromFile
                            (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\KnightW.png");
                        }
                        if (folder.ToString().Contains("sternetj"))
                        {
                            BlackKnight = Image.FromFile
                             (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\KnightB.png");
                            WhiteKnight = Image.FromFile
                            (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\KnightW.png");
                        }
            #endif
            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> GetBasicMoves(Board board)
        {
             var moves = new List<string>();

            foreach (var mainDirc in Enum.GetValues(typeof(Board.CellNeighbor)))
            {
                var mainCell = board.GetNeighborCell(board.GetCell(CurrentPos), (Board.CellNeighbor)mainDirc);
                if (mainCell == null) continue;
                mainCell = board.GetNeighborCell(mainCell, (Board.CellNeighbor)mainDirc);
                if (mainCell == null) continue;
                foreach(var secondaryDirc in Enum.GetValues(typeof(Board.CellNeighbor)))
                {
                    var checkCell = board.GetNeighborCell(mainCell, (Board.CellNeighbor)secondaryDirc);

                    if (board.IsSameOrOpposite((Board.CellNeighbor)mainDirc, (Board.CellNeighbor)secondaryDirc) ||
                        checkCell == null || (checkCell.GetPiece() != null && checkCell.GetPiece().White == this.White)) continue;
                    moves.Add(checkCell.GetName());

                }
            }

            return moves;
        }

        public override List<string> GetMoves(Board board)
        {
           

            return validMoves(this.GetBasicMoves(board), board);
        }

        public override Image GetImage()
        {
            return White ? WhiteKnight : BlackKnight;
        }
    }
}
