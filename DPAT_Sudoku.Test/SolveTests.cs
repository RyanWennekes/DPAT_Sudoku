using DPAT_Sudoku.Business.Factory;
using DPAT_Sudoku.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Test
{
    [TestClass]
    public class SolveTests
    {
        private Sudoku _sudoku;

        [TestInitialize]
        public void Initialize()
        {
            ISudokuFactory factory = new SudokuFactory();
            _sudoku = factory.Create(".4x4", "0000000000000000");
        }

        [TestMethod]
        public void Should_Solve_Solvable()
        {
            // Act.
            bool solved = _sudoku.Solve();

            // Assert.
            Assert.IsTrue(solved);
        }

        [TestMethod]
        public void Should_Not_Solve_Unsolvable()
        {
            // Arrange.
            _sudoku.SetCellValue(0, 0, 1);
            _sudoku.SetCellValue(1, 0, 1);

            // Act.
            bool solved = _sudoku.Solve();

            // Assert.
            Assert.IsFalse(solved);
        }
    }
}
