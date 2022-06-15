using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Domain
{
    public class Cell
    {
        public Location Location { get; set; }
        public int? Value { get; set; }

        public Cell()
        {
            Location = new Location();
        }
    }
}
