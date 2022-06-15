using DPAT_Sudoku.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPAT_Sudoku.Business.Builder
{
    public class Sudoku_6x6_Builder : SudokuBuilder
    {
        private Sudoku_6x6 _sudoku;
        public Sudoku_6x6_Builder()
        {
            _sudoku = new Sudoku_6x6();
        }
        public Sudoku GetResult()
        {
            return _sudoku;
        }

        public void Make(string input)
        {
            List<String> sudokuRows = new List<string>();

            // Split input into rows.
            for (int i = 0; i < 6; i++)
            {
                sudokuRows.Add(input.Substring(i * 6, 6));
            }

            Read6x6(sudokuRows);
        }

        public Sudoku_6x6 Read6x6(List<string> rows6x6)
        {
            // Create rasters.
            for (int i = 0; i < 3; i++) // Vertical index of raster.
            {
                for (int j = 0; j < 2; j++) // Horizontal index of raster.
                {
                    Raster raster = new Raster();
                    List<string> rasterRows = rows6x6.GetRange(i * 2, 2);

                    rasterRows = rasterRows.Select(r => r.Substring(j * 3, 3)).ToList();
                    rasterRows.ForEach(r =>
                    {
                        for (int k = 0; k < r.Length; k++)
                        {
                            int? value = int.Parse(r[k].ToString());
                            if (value < 1 || value > 9)
                            {
                                value = null;
                            }

                            Cell cell = new Cell
                            {
                                Value = value
                            };
                            cell.Location.X = j * 3 + k;
                            cell.Location.Y = i * 2 + rasterRows.IndexOf(r);

                            raster.AddCell(cell);
                        }
                    });

                    _sudoku.AddRaster(raster);
                }
            }

            return _sudoku;
        }
    }
}
