using DPAT_Sudoku.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPAT_Sudoku.Business.Builder
{
    public class Sudoku_9x9_Builder : SudokuBuilder
    {
        private Sudoku_9x9 _sudoku;

        public Sudoku_9x9_Builder()
        {
            _sudoku = new Sudoku_9x9();
        }

        public Sudoku GetResult()
        {
            return _sudoku;
        }

        public void Make(string input)
        {
            List<String> sudokuRows = new List<string>();

            // Split input into rows.
            for(int i = 0; i < 9; i++)
            {
                sudokuRows.Add(input.Substring(i * 9, 9));
            }

            sudokuRows.ForEach(r => Console.WriteLine(r.Length));

            Read9x9(sudokuRows);
        }

        public Sudoku_9x9 Read9x9(List<String> rows9x9)
        {
            // Create rasters.
            for (int i = 0; i < 3; i++) // Vertical index of raster.
            {
                for (int j = 0; j < 3; j++) // Horizontal index of raster.
                {
                    Raster raster = new Raster();
                    List<string> rasterRows = rows9x9.GetRange(i * 3, 3);

                    rasterRows = rasterRows.Select(r => r.Substring(j * 3, 3)).ToList();
                    for (int l = 0; l < rasterRows.Count; l++)
                    {
                        for (int k = 0; k < rasterRows[l].Length; k++)
                        {
                            int? value = int.Parse(rasterRows[l][k].ToString());
                            if (value < 1 || value > 9)
                            {
                                value = null;
                            }

                            Cell cell = new Cell
                            {
                                Value = value
                            };
                            cell.Location.X = j * 3 + k;
                            cell.Location.Y = i * 3 + l;

                            raster.AddCell(cell);
                        }
                    }

                    _sudoku.AddRaster(raster);
                }
            }

            return _sudoku;
        }
    }
}
