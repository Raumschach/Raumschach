﻿using System;
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

#if (DEBUG && !MYTEST)
        public readonly Image BlackKnight = Image.FromFile
            (Environment.CurrentDirectory + @"\Images\KnightB.png"); //Bruce Wayne

        public readonly Image WhiteKnight = Image.FromFile(Environment.CurrentDirectory + @"\Images\KnightW.png"); //THarvey Two Face
        #endif
        #if (DEBUG && MYTEST)
                    public readonly Image BlackPawn = Image.FromFile
                 (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\KnightB.png");
            //(@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\KnightB.png");
            public readonly Image WhitePawn = Image.FromFile
            (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\KnightW.png");
            //(@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\KnightW.png");
        #endif

        public Knight(bool white, string currentPos)
        {
            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> GetMoves(Board board)
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

        public override Image GetImage()
        {
            return White ? WhiteKnight : BlackKnight;
        }
    }
}