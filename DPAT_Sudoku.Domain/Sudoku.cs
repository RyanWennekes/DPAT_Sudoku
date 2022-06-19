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
        private bool _annotationMode = false;
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
            List<Cell> cells = GetCells().Where(c => c.Value == null).ToList();
            Cell cell = cells.FirstOrDefault();

            if (cell != null)
            {
                for (int i = 1; i < 10; i++)
                {
                    cell.Value = i;
                    List<Cell> invalidCells = Validate();
                    if (invalidCells.Count == 0) // If the number of invalid cells is zero.
                    {
                        if (Solve())
                        {
                            return true;
                        }
                    }
                }

                cell.Value = null;

                return false;
            } else
            {
                return true;
            }
        }

        // Returns an array with invalid cells. Applies on children (composite pattern).
        public virtual List<Cell> Validate()
        {
            List<Cell> invalidCells = new List<Cell>();
            Children.ForEach(c =>
            {
                invalidCells.AddRange(c.Validate());
            });

            List<Cell> cells = GetCells().Where(c => c.IsAnnotation != false).ToList();
            cells.ForEach(c =>
            {
                List<Cell> comparativeCells = GetCells().Where(c => c.IsAnnotation != false).ToList();
                comparativeCells.ForEach(cc =>
                {
                    if (c.Value == cc.Value
                    && c.Value != null
                    && c.Location != cc.Location
                    && (c.Location.X == cc.Location.X || c.Location.Y == cc.Location.Y))
                    {
                        invalidCells.Add(c);
                    }
                });
            });

            return invalidCells.GroupBy(c => c.Location).Select(group => group.First()).ToList();
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

        public void SetCellValue(int x, int y, int? value)
        {
            Cell cell = GetCell(x, y);
            if (cell.Value != null && cell.IsAnnotation == false && _annotationMode == true)
            {
                return;
            }

            List<Raster> rasters = GetRasters();
            rasters.ForEach(r =>
            {
                var cell = r.GetCells().FirstOrDefault(c => c.Location.X == x && c.Location.Y == y);
                if (cell != null)
                {
                    cell.Value = value;
                    cell.IsAnnotation = _annotationMode;
                }
            });
        }

        public Cell GetCell(int x, int y)
        {
            return GetCells().FirstOrDefault(c => c.Location.X == x && c.Location.Y == y);
        }

        public abstract int GetHeight();

        private Cell FirstEmptyCell()
        {
            return GetCells().FirstOrDefault(c => c.Value == null);
        }

        public bool IsAnnotationMode()
        {
            return _annotationMode;
        }

        public void ToggleAnnotationMode()
        {
            _annotationMode = !_annotationMode;
        }
    }
}
