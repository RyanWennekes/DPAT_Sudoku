using DPAT_Sudoku.Domain;
using DPAT_Sudoku.Domain.Visitor;
using System;

namespace DPAT_Sudoku.Domain
{
    public class Sudoku_6x6 : Sudoku
    {

        public override void Accept(Visitor.Visitor visitor)
        {
            visitor.Visit(this);
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
