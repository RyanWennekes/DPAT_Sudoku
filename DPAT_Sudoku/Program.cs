using System;
using DPAT_Sudoku.Business.Factory;
using DPAT_Sudoku.Business.Singleton;

namespace DPAT_Sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ISudokuFactory factory = new SudokuFactory();
            IImporter importer = Importer.GetInstance();
            IClient client = new Client(factory, importer);
            client.Start();
        }
    }
}
