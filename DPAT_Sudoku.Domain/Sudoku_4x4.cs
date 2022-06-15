using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Domain
{
    public class Sudoku_4x4 : Sudoku
    {
        public override void Accept(Visitor.Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override int GetHeight()
        {
            return 4;
        }
    }
}
