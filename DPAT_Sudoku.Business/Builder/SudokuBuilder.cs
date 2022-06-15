using DPAT_Sudoku.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Business.Builder
{
    public interface SudokuBuilder
    {
        public Sudoku GetResult();
        public void Make(String input);
    }
}
