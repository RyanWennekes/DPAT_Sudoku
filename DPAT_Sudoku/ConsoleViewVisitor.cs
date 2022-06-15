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
            Console.Clear();

            DrawSudoku(element.Children[0].GetRasters());
            DrawSudoku(element.Children[1].GetRasters(), 9 + 3, 0);
            DrawSudoku(element.Children[2].GetRasters(), 6, 6);
            DrawSudoku(element.Children[3].GetRasters(), 0, 9 + 3);
            DrawSudoku(element.Children[4].GetRasters(), 9 + 3, 9 + 3);
        }

        public void Visit(Jigsaw element)
        {
            Console.Clear();
            throw new NotImplementedException();
        }

        public void Visit(Sudoku_4x4 element)
        {
            Console.Clear();
            DrawSudoku(element.GetRasters());
        }

        public void Visit(Sudoku_6x6 element)
        {
            Console.Clear();
            DrawSudoku(element.GetRasters());
        }

        public void Visit(Sudoku_9x9 element)
        {
            Console.Clear();
            DrawSudoku(element.GetRasters());
        }

        private void DrawSudoku(List<Raster> rasters, int cursorPositionXOffset = 0, int cursorPositionYOffset = 0)
        {
            Console.ForegroundColor = ConsoleColor.Black;

            rasters.ForEach(r =>
            {
                Console.BackgroundColor = _colors[rasters.IndexOf(r) % _colors.Length];

                r.GetCells().ForEach(c =>
                {
                    Console.SetCursorPosition(c.Location.X + cursorPositionXOffset, c.Location.Y + cursorPositionYOffset);
                    string value = c.Value == null ? " " : c.Value.ToString();
                    Console.Write(value);
                });
            });

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
