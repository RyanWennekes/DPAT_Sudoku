using DPAT_Sudoku.Business.Factory;
using DPAT_Sudoku.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Test
{
    [TestClass]
    public class ValidationTests
    {
        private Sudoku _sudoku;

        [TestInitialize]
        public void Initialize()
        {
            ISudokuFactory factory = new SudokuFactory();
            _sudoku = factory.Create(".4x4", "0000000000000000");
        }

        [TestMethod]
        public void Duplicates_On_Same_Row_Should_Return_Validation_Errors()
        {
            // Arrange.
            _sudoku.SetCellValue(0, 0, 1);
            _sudoku.SetCellValue(2, 0, 1);

            // Act.
            List<Cell> invalidCells = _sudoku.Validate();

            // Assert.
            Assert.IsTrue(invalidCells.Count == 2);
        }

        [TestMethod]
        public void Duplicates_On_Same_Column_Should_Return_Validation_Errors()
        {
            // Arrange.
            _sudoku.SetCellValue(0, 0, 1);
            _sudoku.SetCellValue(0, 2, 1);

            // Act.
            List<Cell> invalidCells = _sudoku.Validate();

            // Assert.
            Assert.IsTrue(invalidCells.Count == 2);
        }

        [TestMethod]
        public void Duplicates_In_Same_Raster_Should_Return_Validation_Errors()
        {
            // Arrange.
            _sudoku.SetCellValue(0, 0, 1);
            _sudoku.SetCellValue(1, 0, 1);

            // Act.
            List<Cell> invalidCells = _sudoku.Validate();

            // Assert.
            Assert.IsTrue(invalidCells.Count == 2);
        }

        [TestMethod]
        public void Annotation_Cells_Should_Not_Be_Validated()
        {
            // Arrange.
            _sudoku.SetCellValue(0, 0, 1);
            _sudoku.ToggleAnnotationMode();
            _sudoku.SetCellValue(1, 0, 1);

            // Act.
            List<Cell> invalidCells = _sudoku.Validate();

            // Assert.
            Assert.IsTrue(invalidCells.Count == 0);
        }
    }
}
