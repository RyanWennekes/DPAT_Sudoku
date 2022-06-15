using System;
using System.Collections.Generic;
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
    }
}
