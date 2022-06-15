using DPAT_Sudoku.Business.Builder;
using DPAT_Sudoku.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Business.Factory
{
    public class SudokuFactory
    {
        public Dictionary<string, SudokuBuilder> FactoryTypes { get; set; }

        public SudokuFactory()
        {
            FactoryTypes = new Dictionary<string, SudokuBuilder>();
            FactoryTypes.Add(".4x4", new Sudoku_4x4_Builder());
            FactoryTypes.Add(".6x6", new Sudoku_6x6_Builder());
            FactoryTypes.Add(".9x9", new Sudoku_9x9_Builder());
            FactoryTypes.Add(".jigsaw", new JigsawBuilder());
            FactoryTypes.Add(".samurai", new SamuraiBuilder());
        }

        public Sudoku Create(string type, string data)
        {
            SudokuBuilder builder = FactoryTypes.GetValueOrDefault(type);

            builder.Make(data);
            return builder.GetResult();
        }

        public void AddSudokuBuilder(string name, SudokuBuilder builder)
        {
            FactoryTypes.Add(name, builder);
        }
    }
}
