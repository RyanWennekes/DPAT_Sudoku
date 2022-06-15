using DPAT_Sudoku.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPAT_Sudoku.Business.Builder
{
    public class SamuraiBuilder : SudokuBuilder
    {
        private Samurai _sudoku;
        public SamuraiBuilder()
        {
            _sudoku = new Samurai();
        }
        public Sudoku GetResult()
        {
            return _sudoku;
        }

        public void Make(string input)
        {
            List<String> sudokus = input.Split("\r\n").ToList();

            sudokus.ForEach(s =>
            {
                Sudoku_9x9_Builder builder = new Sudoku_9x9_Builder();
                builder.Make(s);

                _sudoku.Children.Add(builder.GetResult());
            });
        }
    }
}
