using DPAT_Sudoku.Business.Factory;
using DPAT_Sudoku.Business.Singleton;
using DPAT_Sudoku.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku
{
    public class Client
    {
        private Sudoku _sudoku;
        private bool annotationMode = false;

        public Client()
        {
            Console.ResetColor();
            Console.WriteLine("Welcome to the great DPAT1 Sudoku game! Enter the path to the Sudoku file you want to play:");
            String path = Console.ReadLine();

            Importer importer = Importer.GetInstance();
            (string, string) import = importer.Import(path);

            SudokuFactory factory = new SudokuFactory();
            _sudoku = factory.Create(import.Item2, import.Item1);

            ConsoleViewVisitor visitor = new ConsoleViewVisitor();
            Redraw(visitor);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                int number;

                if (key.Key == ConsoleKey.Spacebar)
                {
                    annotationMode = !annotationMode;
                    int line = _sudoku.GetHeight() + 1;
                    ClearLine(line);
                    Console.SetCursorPosition(0, line);
                    Console.WriteLine($"Annotation mode enabled: {annotationMode} (Press Space to toggle)");
                    Console.SetCursorPosition(0, 0);
                } else if (key.Key == ConsoleKey.C) {
                    Redraw(visitor);
                    List<Cell> invalidCells = _sudoku.Validate();

                    invalidCells.ForEach(c =>
                    {
                        Console.SetCursorPosition(c.Location.X, c.Location.Y);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(c.Value);
                        Console.ResetColor();
                    });
                } else if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Math.Max(0, Console.CursorTop - 1));
                } else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Math.Min(_sudoku.GetHeight() - 1, Console.CursorTop + 1));
                } else if (key.Key == ConsoleKey.LeftArrow)
                {
                    Console.SetCursorPosition(Math.Max(0, Console.CursorLeft - 1), Console.CursorTop);
                } else if (key.Key == ConsoleKey.RightArrow)
                {
                    Console.SetCursorPosition(Math.Min(_sudoku.GetHeight() - 1, Console.CursorLeft + 1), Console.CursorTop);
                } else if (key.Key == ConsoleKey.Escape)
                {
                    goto exit_loop;
                } else if (int.TryParse(key.KeyChar.ToString(), out number))
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); // Reset cursor position.
                    int cursorLocationX = Console.CursorLeft;
                    int cursorLocationY = Console.CursorTop;

                    _sudoku.SetCellValue(cursorLocationX, cursorLocationY, number);
                } else
                {
                    Redraw(visitor);
                }
            }

            exit_loop:;

            Console.Clear();
            Console.WriteLine("Thanks for playing!");
        }

        private void Redraw(ConsoleViewVisitor visitor)
        {
            Console.Clear();

            _sudoku.Accept(visitor);

            Console.WriteLine($"Annotation mode enabled: {annotationMode} (Press Space to toggle)");
            Console.WriteLine("Press S to let the computer solve the sudoku.");
            Console.WriteLine("Press C to let the computer validate the sudoku.");
            Console.WriteLine("Use arrow keys to navigate.");
            Console.SetCursorPosition(0, 0);
        }

        private void ClearLine(int lineNumber)
        {
            Console.SetCursorPosition(0, lineNumber);
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }
}
