using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using TagGameBLL.Classes;
using TagGameBLL.Exceptions;
using Xunit;

namespace TagGameBLLTests
{
    public class StandartGameControllerTests
    {
        private readonly GameController _gameController;
        private readonly FieldStateFixture _stateFixture;

        public StandartGameControllerTests()
        {
            _stateFixture = new FieldStateFixture();
            _gameController = new StandartGameController(_stateFixture.FieldInfo.Object);
        }

        [Theory]
        [ClassData(typeof(MoveCellTestData))]
        public void MoveCell_Success_CellMoves(Direction direction, Cell[,] resultState)
        {
            //Arrange
            _stateFixture.FieldInfo.Object.Field.Cells = _stateFixture.Cells;
            //Act
            _gameController.MoveCell(direction);
            //Assert
            _stateFixture.FieldInfo.Object.Field.Cells.Should().BeEquivalentTo(resultState);
        }

        [Theory]
        [InlineData(Direction.Left)]
        [InlineData(Direction.Up)]
        public void MoveCell_WrongDirection_ThrownWrongDirectionException(Direction direction)
        {
            //Arrange
            _stateFixture.FieldInfo.Object.Field.Cells = _stateFixture.Cells;
            //Act
            //Assert
            Assert.Throws<WrongMoveDirectionException>(() => _gameController.MoveCell(direction));
        }

        [Fact]
        public void SaveState_Success_FieldAddedToFieldHistory()
        {
            //Arrange
            //Act
            _gameController.SaveFieldState();
            //Assert
            Assert.NotNull(_stateFixture.FieldInfo.Object.FieldHistory.PopState());
        }

        [Fact]
        public void ResetState_Success_FieldResetedFromFieldHistory()
        {
            //Arrange
            _stateFixture.FieldInfo.Object.Field = new Field();
            _stateFixture.FieldInfo.Object.FieldHistory.AddState(new FieldMemento(_stateFixture.Cells));
            //Act
            _gameController.UndoFieldState();
            //Assert
            _stateFixture.FieldInfo.Object.Field.Cells.Should().BeEquivalentTo(_stateFixture.Cells);
        }
    }

    public class MoveCellTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                Direction.Down, new[,]
                {
                    {new Cell {Number = 1, Row = 0, Column = 0}, new Cell {Number = 0, Row = 0, Column = 1}},
                    {new Cell {Number = 3, Row = 1, Column = 0}, new Cell {Number = 2, Row = 1, Column = 1}}
                }
            };
            yield return new object[]
            {
                Direction.Right, new[,]
                {
                    {new Cell {Number = 1, Row = 0, Column = 0}, new Cell {Number = 2, Row = 0, Column = 1}},
                    {new Cell {Number = 0, Row = 1, Column = 0}, new Cell {Number = 3, Row = 1, Column = 1}}
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}