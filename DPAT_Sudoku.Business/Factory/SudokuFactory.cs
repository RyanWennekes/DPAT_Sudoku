using DPAT_Sudoku.Business.Builder;
using DPAT_Sudoku.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Business.Factory
{
    public class SudokuFactory
    {
        public Dictionary<String, SudokuBuilder> FactoryTypes { get; set; }

        public Sudoku Create()
        {
            throw new NotImplementedException();
        }

        public void AddSudokuBuilder(String name, SudokuBuilder builder)
        {
            FactoryTypes.Add(name, builder);
        }
    }
}
