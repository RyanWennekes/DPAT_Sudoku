using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Domain.Visitor
{
    public interface Visitor
    {
        public void Visit(Samurai element);
        public void Visit(Jigsaw element);
        public void Visit(Sudoku_4x4 element);
        public void Visit(Sudoku_6x6 element);
        public void Visit(Sudoku_9x9 element);
    }
}
