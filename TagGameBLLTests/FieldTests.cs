using System;
using System.Collections.Generic;
using System.Text;
using TagGameBLL.Classes;
using Xunit;
using Moq;
using System.Collections;
using FluentAssertions;

namespace TagGameBLLTests
{
    public class FieldTests
    {
        private Field field;
        private Cell[,] cells;
        private int[,] winState;

        public FieldTests()
        {
            cells = new Cell[,]{
                { new Cell { Number = 1, Row = 0, Column = 0 }, new Cell { Number = 2, Row = 0, Column = 1 } },
                { new Cell { Number = 3, Row = 1, Column = 0 }, new Cell { Number = 0, Row = 1, Column = 1 } } };
            field = new Field{ Cells = cells };
            int[,] winStateStub = {
                { 1, 2 },
                { 3, 0 }
            };
            field.SetWinState(winStateStub);
        }

        [Fact]
        public void GetEmptyCell_Success_CellReturned()
        {
            //Arrange
            //Act
            Cell result = field.GetEmptyCell();
            //Assert
            Assert.Equal(0, result.Number);
        }

        [Fact]
        public void CheckWinState_Success_StateChecked()
        {
            //Arrange
            //Act
            bool result = field.CheckWinState();
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void SaveState_Success_StateReturned()
        {
            //Arrange
            //Act
            FieldMemento result = field.SaveState();
            //Assert
            Assert.NotNull(result);
        }

        [Theory]
        [ClassData(typeof(CellsTestData))]
        public void ResetState_Success_StateReseted(Cell[,] newState)
        {
            //Arrange
            var memento = new FieldMemento(newState);
            //Act
            field.RestoreState(memento);
            //Assert
            field.Cells.Should().BeEquivalentTo(newState);
        }
    }

    public class CellsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Cell[,]{
                { new Cell { Number = 1, Row = 0, Column = 0 }, new Cell { Number = 3, Row = 0, Column = 1 } },
                { new Cell { Number = 0, Row = 1, Column = 0 }, new Cell { Number = 2, Row = 1, Column = 1 } } } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
