using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Business.Composite
{
    public interface Component
    {
        public bool Solve();
        public bool Validate();
    }
}
