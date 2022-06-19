using DPAT_Sudoku.Business.Factory;
using DPAT_Sudoku.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPAT_Sudoku.Test
{
    [TestClass]
    public class AnnotationModeTests
    {
        private Sudoku _sudoku;

        [TestInitialize]
        public void Initialize()
        {
            ISudokuFactory factory = new SudokuFactory();
            _sudoku = factory.Create(".4x4", "0000000000000000");
        }

        [TestMethod]
        public void Annotation_Should_Be_Created_When_Cell_Empty()
        {
            // Arrange.
            _sudoku.ToggleAnnotationMode();

            // Act.
            _sudoku.SetCellValue(1, 0, 4);

            // Assert.
            Assert.AreEqual(_sudoku.GetCell(1, 0).Value, 4);
        }

        [TestMethod]
        public void Annotation_Should_Be_Overwritten_By_Definitive_Cell()
        {
            // Arrange.
            _sudoku.ToggleAnnotationMode();
            _sudoku.SetCellValue(1, 0, 4);
            _sudoku.ToggleAnnotationMode();

            // Act.
            _sudoku.SetCellValue(1, 0, 3);

            // Assert.
            Assert.AreEqual(_sudoku.GetCell(1, 0).Value, 3);
        }

        [TestMethod]
        public void Annotation_Should_Not_Be_Created_When_Cell_Not_Empty()
        {
            // Arrange.
            _sudoku.SetCellValue(1, 0, 4);
            _sudoku.ToggleAnnotationMode();

            // Act.
            _sudoku.SetCellValue(1, 0, 3);

            // Assert.
            Assert.AreEqual(_sudoku.GetCell(1, 0).Value, 4);
        }

        [TestMethod]
        public void Annotation_Should_Overwrite_Previous_Annotation()
        {
            // Arrange.
            _sudoku.ToggleAnnotationMode();
            _sudoku.SetCellValue(1, 0, 4);

            // Act.
            _sudoku.SetCellValue(1, 0, 3);

            // Assert.
            Assert.AreEqual(_sudoku.GetCell(1, 0).Value, 3);
        }
    }
}
