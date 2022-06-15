using DPAT_Sudoku.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Cell> GetCells()
        {
            return _cells;
        }

        public List<Raster> GetRasters()
        {
            return new List<Raster> { this };
        }

        public bool Solve()
        {
            throw new NotImplementedException();
        }

        public List<Cell> Validate()
        {
            List<Cell> duplicates = new List<Cell>();

            var groups = _cells.GroupBy(c => c.Value).ToList();
            groups.ForEach(group =>
            {
                if (group.Count() > 1 && group.Key != null)
                {
                    duplicates.AddRange(group);
                }
            });

            return duplicates;
        }
    }
}
