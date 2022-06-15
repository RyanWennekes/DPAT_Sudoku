using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DPAT_Sudoku.Business.Singleton
{
    public class Importer
    {
        private static Importer instance;

        public static Importer GetInstance()
        {
            if (Importer.instance == null)
            {
                Importer.instance = new Importer();
            }

            return Importer.instance;
        }

        // Returns a tuple in which the first string denotes the data, and the second denotes the type.
        public (string, string) Import(String path)
        {
            return (File.ReadAllText(path), Path.GetExtension(path));
        }
    }
}
