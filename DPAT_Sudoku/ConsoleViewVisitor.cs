using DPAT_Sudoku.Domain;
using DPAT_Sudoku.Domain.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku
{
    public class ConsoleViewVisitor : Visitor
    {
        private static ConsoleColor[] _colors = new ConsoleColor[] { ConsoleColor.Yellow, ConsoleColor.DarkMagenta, ConsoleColor.Gray, ConsoleColor.DarkGreen, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.DarkBlue, ConsoleColor.White };

        public void Visit(Samurai element)
        {
            DrawSudoku(element);
        }

        public void Visit(Jigsaw element)
        {
            DrawSudoku(element);
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

        private void DrawSudoku(Sudoku sudoku, int cursorPositionXOffset = 0, int cursorPositionYOffset = 0)
        {
            List<Raster> rasters = sudoku.GetRasters();
            Console.ForegroundColor = ConsoleColor.Black;

            rasters.ForEach(r =>
            {
                Console.BackgroundColor = _colors[rasters.IndexOf(r) % _colors.Length];

                r.GetCells().ForEach(c =>
                {
                    Console.ForegroundColor = c.IsAnnotation ? ConsoleColor.Green : ConsoleColor.Black;
                    Console.SetCursorPosition(c.Location.X + cursorPositionXOffset, c.Location.Y + cursorPositionYOffset);
                    string value = c.Value == null ? " " : c.Value.ToString();
                    if (c.IsAnnotation && !sudoku.IsAnnotationMode())
                    {
                        Console.Write(" ");
                    } else
                    {
                        Console.Write(value);
                    }
                    Console.ForegroundColor = ConsoleColor.Black;
                });
            });

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n");
        }
    }
}
