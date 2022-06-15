using DPAT_Sudoku.Business.Composite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Domain
{
    public abstract class Sudoku : Component
    {
        public bool Solve()
        {
            throw new NotImplementedException();
        }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
