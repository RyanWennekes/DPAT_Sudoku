using DPAT_Sudoku.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Domain
{
    public class Samurai : Sudoku
    {
        public override void Accept(Visitor.Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override int GetHeight()
        {
            return 21;
        }

        public override List<Component> GetSudokus()
        {
            return Children;
        }

        public override List<Cell> Validate()
        {
            List<Cell> invalidCells = new List<Cell>();
            Children.ForEach(c =>
            {
                invalidCells.AddRange(c.Validate());
            });

            List<Component> subSudokus = GetSudokus();

            subSudokus.ForEach(s =>
            {
                List<Cell> cells = s.GetCells();
                cells.ForEach(c =>
                {
                    List<Cell> comparativeCells = s.GetCells();
                    comparativeCells.ForEach(cc =>
                    {
                        if (c.Value == cc.Value
                        && c.Location.X == cc.Location.X ^ c.Location.Y == cc.Location.Y)
                        {
                            invalidCells.Add(c);
                        }
                    });
                });
            });

            return invalidCells;
        }
    }
}
