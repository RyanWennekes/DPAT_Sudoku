using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Business.Singleton
{
    public interface IImporter
    {
        public (string, string) Import();
    }
}
