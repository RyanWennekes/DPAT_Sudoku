using DPAT_Sudoku.Domain;
using DPAT_Sudoku.Domain.Composite;
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
            AddSubSudokus(input);
            ApplyLocationOffset();
        }

        private void AddSubSudokus(string input)
        {
            List<string> sudokus = input.Split("\r\n").ToList();

            sudokus.ForEach(s =>
            {
                Sudoku_9x9_Builder builder = new Sudoku_9x9_Builder();
                builder.Make(s);

                _sudoku.Children.Add(builder.GetResult());
            });
        }

        private void ApplyLocationOffset()
        {
            List<Component> subSudokus = _sudoku.Children;
            for (int i = 0; i < subSudokus.Count; i++)
            {
                List<Cell> cells = subSudokus[i].GetCells();

                switch (i)
                {
                    case 1:
                        cells.ForEach(c => c.Location.X += 12);
                        break;
                    case 2:
                        cells.ForEach(c => c.Location.X += 6);
                        cells.ForEach(c => c.Location.Y += 6);
                        break;
                    case 3:
                        cells.ForEach(c => c.Location.Y += 12);
                        break;
                    case 4:
                        cells.ForEach(c => c.Location.X += 12);
                        cells.ForEach(c => c.Location.Y += 12);
                        break;
                    default:
                        break;

                }
            }
        }
    }
}
