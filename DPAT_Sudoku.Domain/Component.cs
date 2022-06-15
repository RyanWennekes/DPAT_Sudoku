using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Domain.Composite
{
    public interface Component
    {
        public bool Solve();
        public bool Validate();
        public List<Cell> GetCells();

        public List<Raster> GetRasters();
    }
}
