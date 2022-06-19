using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku
{
    public interface IClient
    {
        public void Start();
        public void Stop();
        public void Reset();
    }
}
