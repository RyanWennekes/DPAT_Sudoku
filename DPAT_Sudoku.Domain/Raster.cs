using DPAT_Sudoku.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Domain
{
    public class Raster : Component
    {
        private List<Cell> _cells;

        public Raster()
        {
            _cells = new List<Cell>();
        }

        public void AddCell(Cell cell)
        {
            _cells.Add(cell);
        }

        public bool Solve()
        {
            throw new NotImplementedException();
        }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
