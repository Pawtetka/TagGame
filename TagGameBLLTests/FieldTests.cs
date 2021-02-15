using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using TagGameBLL.Classes;
using Xunit;

namespace TagGameBLLTests
{
    public class FieldTests
    {
        private readonly Cell[,] _cells;
        private readonly Field _field;
        private int[,] _winState;

        public FieldTests()
        {
            _cells = new[,]
            {
                {new Cell {Number = 1, Row = 0, Column = 0}, new Cell {Number = 2, Row = 0, Column = 1}},
                {new Cell {Number = 3, Row = 1, Column = 0}, new Cell {Number = 0, Row = 1, Column = 1}}
            };
            _field = new Field {Cells = _cells};
            int[,] winStateStub =
            {
                {1, 2},
                {3, 0}
            };
            _field.SetWinState(winStateStub);
        }

        [Fact]
        public void GetEmptyCell_Success_CellReturned()
        {
            //Arrange
            //Act
            var result = _field.GetEmptyCell();
            //Assert
            Assert.Equal(0, result.Number);
        }

        [Fact]
        public void CheckWinState_Success_StateChecked()
        {
            //Arrange
            //Act
            var result = _field.CheckWinState();
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void SaveState_Success_StateReturned()
        {
            //Arrange
            //Act
            var result = _field.SaveState();
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
            _field.RestoreState(memento);
            //Assert
            _field.Cells.Should().BeEquivalentTo(newState);
        }
    }

    internal class CellsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new[,]
                {
                    {new Cell {Number = 1, Row = 0, Column = 0}, new Cell {Number = 3, Row = 0, Column = 1}},
                    {new Cell {Number = 0, Row = 1, Column = 0}, new Cell {Number = 2, Row = 1, Column = 1}}
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}