using DPAT_Sudoku.Domain.Composite;
using DPAT_Sudoku.Domain.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Domain
{
    public abstract class Sudoku : Component, Element
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

        public abstract bool Solve();

        public abstract bool Validate();

        public abstract void Accept(Visitor.Visitor visitor);
        public List<Cell> GetCells()
        {
            List<Cell> cells = new List<Cell>();

            Children.ForEach(c =>
            {
                cells.AddRange(c.GetCells());
            });

            return cells;
        }

        public List<Raster> GetRasters()
        {
            List<Raster> rasters = new List<Raster>();

            Children.ForEach(c =>
            {
                rasters.AddRange(c.GetRasters());
            });

            return rasters;
        }
    }
}
