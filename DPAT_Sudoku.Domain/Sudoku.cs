using DPAT_Sudoku.Domain.Composite;
using DPAT_Sudoku.Domain.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Sudoku Solve()
        {


            return this;
        }

        // Returns an array with invalid cells. Applies on children (composite pattern).
        public virtual List<Cell> Validate()
        {
            List<Cell> invalidCells = new List<Cell>();
            Children.ForEach(c =>
            {
                invalidCells.AddRange(c.Validate());
            });

            List<Cell> cells = GetCells();
            cells.ForEach(c =>
            {
                List<Cell> comparativeCells = GetCells();
                comparativeCells.ForEach(cc =>
                {
                    if (c.Value == cc.Value
                    && (c.Location.X == cc.Location.X ^ c.Location.Y == cc.Location.Y)) // Exclusive or: we don't want to invalidate the same cell.
                    {
                        invalidCells.Add(c);
                    }
                });
            });

            return invalidCells;
        }

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

        public virtual List<Component> GetSudokus()
        {
            return new List<Component>() { this }; // Each sudoku, by default, returns a list containing only itself.
        }

        public void SetCellValue(int x, int y, int value)
        {
            List<Raster> rasters = GetRasters();
            rasters.ForEach(r =>
            {
                var cell = r.GetCells().FirstOrDefault(c => c.Location.X == x && c.Location.Y == y);
                if (cell != null)
                {
                    cell.Value = value;
                }
            });
        }

        public abstract int GetHeight();
    }
}
