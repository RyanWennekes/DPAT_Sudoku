using DPAT_Sudoku.Business.Builder;
using DPAT_Sudoku.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Business.Factory
{
    public interface ISudokuFactory
    {
        public Sudoku Create(string type, string data);
        public void AddSudokuBuilder(string name, SudokuBuilder builder);
    }
}
