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

        public Client()
        {
            Console.WriteLine("Welcome to the great DPAT1 Sudoku game! Enter the path to the Sudoku file you want to play:");
            String path = Console.ReadLine();

            Importer importer = Importer.GetInstance();
            (string, string) import = importer.Import(path);

            SudokuFactory factory = new SudokuFactory();
            _sudoku = factory.Create(import.Item2, import.Item1);

            ConsoleViewVisitor visitor = new ConsoleViewVisitor();
            _sudoku.Accept(visitor);
        }
    }
}
