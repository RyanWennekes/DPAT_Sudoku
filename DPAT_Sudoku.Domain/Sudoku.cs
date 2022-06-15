using DPAT_Sudoku.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Domain
{
    public abstract class Sudoku : Component
    {
        public List<Component> Children { get; set; }

        public Sudoku()
        {
            Children = new List<Component>();
        }

        public void AddRaster(Raster raster)
        {
            Children.Add(raster);
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
