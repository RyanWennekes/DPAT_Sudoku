using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Domain
{
    public class Samurai : Sudoku
    {
        public override void Accept(Visitor.Visitor visitor)
        {
            throw new NotImplementedException();
        }

        public override bool Solve()
        {
            throw new NotImplementedException();
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
