﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace RaumschachForm
{
    public abstract class Piece
    {
        public Image MyImage;
        public bool White;
        public string CurrentPos;
        public abstract List<String> GetMoves(Board board);
        public abstract Image GetImage();

        public bool Equals(Piece pc)
        {
            return White == pc.White && CurrentPos == pc.CurrentPos && MyImage == pc.MyImage;
        }


    }
}