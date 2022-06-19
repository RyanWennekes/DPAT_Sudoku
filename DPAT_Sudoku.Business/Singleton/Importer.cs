using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DPAT_Sudoku.Business.Singleton
{
    public class Importer : IImporter
    {
        private static IImporter instance;

        public static IImporter GetInstance()
        {
            if (Importer.instance == null)
            {
                Importer.instance = new Importer();
            }

            return Importer.instance;
        }

        // Returns a tuple in which the first string denotes the data, and the second denotes the type.
        public (string, string) Import()
        {
            string path = Console.ReadLine();

            try
            {
                string extension = Path.GetExtension(path);
                string data = File.ReadAllText(path);

                return (data, extension);
            }
            catch (Exception ex)
            {
                Console.WriteLine("You entered an invalid file path! Please enter a new one:");
                return Import();
            }
        }
    }
}
