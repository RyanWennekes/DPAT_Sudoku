using DPAT_Sudoku.Business.Factory;
using DPAT_Sudoku.Business.Singleton;
using DPAT_Sudoku.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPAT_Sudoku
{
    public class Client : IClient
    {
        private Sudoku _sudoku;
        private string data;
        private string type;
        private ISudokuFactory _sudokuFactory;
        private IImporter _importer;

        public Client(ISudokuFactory sudokuFactory, IImporter importer) // Inject factory into client constructor.
        {
            Console.ResetColor();
            Console.WriteLine("Welcome to the great DPAT1 Sudoku game! Enter the path to the Sudoku file you want to play:");
            _sudokuFactory = sudokuFactory;
            _importer = importer;
        }

        public void Start()
        {
            (string, string) import = _importer.Import();

            this.type = import.Item2;
            this.data = import.Item1;

            _sudoku = _sudokuFactory.Create(type, data);

            ConsoleViewVisitor visitor = new ConsoleViewVisitor();
            Redraw(visitor);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                int x = Console.CursorLeft;
                int y = Console.CursorTop;
                int number;

                if (key.Key == ConsoleKey.Spacebar)
                {
                    _sudoku.ToggleAnnotationMode();
                    int line = _sudoku.GetHeight() + 1;
                    ClearLine(line);
                    Console.SetCursorPosition(0, line);
                    Console.WriteLine($"Annotation mode enabled: {_sudoku.IsAnnotationMode()} (Press Space to toggle)");
                    Redraw(visitor);
                    Console.SetCursorPosition(0, 0);
                }
                else if (key.Key == ConsoleKey.C)
                {
                    Redraw(visitor);
                    List<Cell> invalidCells = _sudoku.Validate();

                    if (_sudoku.GetCells().FirstOrDefault(c => c.Value == null) == null && invalidCells.Count == 0)
                    {
                        Redraw(visitor);
                        Console.WriteLine("WOOHOO SOLVED IT");
                    } else
                    {
                        invalidCells.ForEach(c =>
                        {
                            Console.SetCursorPosition(c.Location.X, c.Location.Y);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(c.Value);
                            Console.ResetColor();
                        });

                        Console.SetCursorPosition(x - 1, y);
                    }
                }
                else if (key.Key == ConsoleKey.S)
                {
                    if (_sudoku.Solve())
                    {
                        Redraw(visitor);
                        Console.WriteLine("WOOHOO SOLVED IT");
                    } else
                    {
                        Redraw(visitor);
                        Console.WriteLine("Oh oh, this sudoku is unsolvable!");
                    }
                } else if (key.Key == ConsoleKey.R)
                {
                    Reset();
                } else if (key.Key == ConsoleKey.Delete)
                {
                    _sudoku.SetCellValue(x, y, null);
                    Redraw(visitor);
                    Console.SetCursorPosition(x, y);
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Math.Max(0, Console.CursorTop - 1));
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Math.Min(_sudoku.GetHeight() - 1, Console.CursorTop + 1));
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    Console.SetCursorPosition(Math.Max(0, Console.CursorLeft - 1), Console.CursorTop);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    Console.SetCursorPosition(Math.Min(_sudoku.GetHeight() - 1, Console.CursorLeft + 1), Console.CursorTop);
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    goto exit_loop;
                }
                else if (int.TryParse(key.KeyChar.ToString(), out number))
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); // Reset cursor position.
                    int cursorLocationX = Console.CursorLeft;
                    int cursorLocationY = Console.CursorTop;

                    _sudoku.SetCellValue(cursorLocationX, cursorLocationY, number);
                    Redraw(visitor);
                    Console.SetCursorPosition(cursorLocationX, cursorLocationY);
                }
                else
                {
                    Redraw(visitor);
                }
            }

            exit_loop:;

            Stop();    
        }

        private void Redraw(ConsoleViewVisitor visitor)
        {
            Console.Clear();
            _sudoku.Accept(visitor);

            Console.WriteLine($"Annotation mode enabled: {_sudoku.IsAnnotationMode()} (Press Space to toggle)");
            Console.WriteLine("Press S to let the computer solve the sudoku.");
            Console.WriteLine("Press C to let the computer validate the sudoku.");
            Console.WriteLine("Press R to restart.");
            Console.WriteLine("Use arrow keys to navigate.");
            Console.SetCursorPosition(0, 0);
        }

        private void ClearLine(int lineNumber)
        {
            Console.SetCursorPosition(0, lineNumber);
            Console.Write(new string(' ', Console.WindowWidth));
        }

        public void Reset()
        {
            Start();
        }

        public void Stop()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing!");
        }
    }
}
