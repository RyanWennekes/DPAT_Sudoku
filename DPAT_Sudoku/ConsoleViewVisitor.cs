using DPAT_Sudoku.Domain;
using DPAT_Sudoku.Domain.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku
{
    public class ConsoleViewVisitor : Visitor
    {
        private static ConsoleColor[] _colors = new ConsoleColor[] { ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Gray, ConsoleColor.Green };
        public void Visit(Samurai element)
        {
            throw new NotImplementedException();
        }

        public void Visit(Jigsaw element)
        {
            throw new NotImplementedException();
        }

        public void Visit(Sudoku_4x4 element)
        {
            DrawSudoku(element);
        }

        public void Visit(Sudoku_6x6 element)
        {
            DrawSudoku(element);
        }

        public void Visit(Sudoku_9x9 element)
        {
            DrawSudoku(element);
        }

        private void DrawSudoku(Sudoku sudoku)
        {
            List<Raster> rasters = sudoku.GetRasters();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            rasters.ForEach(r =>
            {
                Console.BackgroundColor = _colors[rasters.IndexOf(r) % _colors.Length];

                r.GetCells().ForEach(c =>
                {
                    Console.SetCursorPosition(c.Location.X, c.Location.Y);
                    string value = c.Value == null ? " " : c.Value.ToString();
                    Console.Write(value);
                });
            });

            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
