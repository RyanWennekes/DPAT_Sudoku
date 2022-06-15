using DPAT_Sudoku.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPAT_Sudoku.Business.Builder
{
    public class JigsawBuilder : SudokuBuilder
    {
        private Jigsaw _sudoku;
        public JigsawBuilder()
        {
            _sudoku = new Jigsaw();
        }
        public Sudoku GetResult()
        {
            return _sudoku;
        }

        public void Make(string input)
        {
            List<String> cells = input.Split("=").ToList();
            cells.RemoveAt(0);

            // Create nine rasters.
            List<Raster> rasters = new List<Raster>();

            for (int i = 0; i < 9; i++)
            {
                rasters.Add(new Raster());
            }


            for (int i = 0; i < cells.Count; i++)
            {
                int x = i % 9;
                int y = i / 9;

                String[] cellInfo = cells[i].Split('J');

                int? value = int.Parse(cellInfo[0]);
                if (value < 1 || value > 9)
                {
                    value = null;
                }

                Cell cell = new Cell();
                cell.Value = value;
                cell.Location.X = x;
                cell.Location.Y = y;

                rasters[int.Parse(cellInfo[1])].AddCell(cell);
            }

            rasters.ForEach(r => _sudoku.AddRaster(r));
        }
    }
}
