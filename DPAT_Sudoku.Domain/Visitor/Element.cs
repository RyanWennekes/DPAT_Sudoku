using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Domain.Visitor
{
    public interface Element
    {
        public void Accept(Visitor visitor);
    }
}
