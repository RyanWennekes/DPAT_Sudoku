using DPAT_Sudoku.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPAT_Sudoku.Business.Builder
{
    public class Sudoku_4x4_Builder : SudokuBuilder
    {
        private Sudoku_4x4 _sudoku;
        public Sudoku GetResult()
        {
            return _sudoku;
        }

        public void Make(string input)
        {
            _sudoku = new Sudoku_4x4();
            List<String> sudokuRows = new List<string>();

            // Split input into rows.
            for (int i = 0; i < 4; i++)
            {
                sudokuRows.Add(input.Substring(i * 4, 4));
            }

            Read4x4(sudokuRows);
        }

        public Sudoku_4x4 Read4x4(List<string> rows4x4)
        {
            // Create rasters.
            for (int i = 0; i < 2; i++) // Vertical index of raster.
            {
                for (int j = 0; j < 2; j++) // Horizontal index of raster.
                {
                    Raster raster = new Raster();
                    List<string> rasterRows = rows4x4.GetRange(i * 2, 2);

                    rasterRows = rasterRows.Select(r => r.Substring(j * 2, 2)).ToList();
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
                            cell.Location.X = j * 2 + k;
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
