using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using TagGameBLL.Classes;
using FluentAssertions;
using System.Collections;
using TagGameBLL.Exceptions;

namespace TagGameBLLTests
{
    public class StandartGameControllerTests
    {
        /*private Cell[,] cells;
        private Mock<IFieldInfo> fieldInfo;
        private Field field;
        private FieldHistory fieldHistory;*/
        private GameController gameController;
        private FieldStateFixture stateFixture;
        public StandartGameControllerTests()
        {
            /*cells = new Cell[,]{
                { new Cell{ Number = 1, Row = 0, Column = 0 }, new Cell{ Number = 2, Row = 0, Column = 1 } },
                { new Cell{ Number = 3, Row = 1, Column = 0 }, new Cell{ Number = 0, Row = 1, Column = 1 } }
            };
            fieldInfo = new Mock<IFieldInfo>();
            field = new Field();
            fieldHistory = new FieldHistory();
            fieldInfo.Setup(info => info.Field).Returns(field);
            fieldInfo.Setup(info => info.FieldHistory).Returns(fieldHistory);*/
            stateFixture = new FieldStateFixture();
            gameController = new StandartGameController(stateFixture.fieldInfo.Object);
        }

        [Theory]
        [ClassData(typeof(MoveCellTestData))]
        public void MoveCell_Success_CellMoves(Direction direction, Cell[,] resultState)
        {
            //Arrange
            stateFixture.fieldInfo.Object.Field.Cells = stateFixture.cells;
            //Act
            gameController.MoveCell(direction);
            //Assert
            stateFixture.fieldInfo.Object.Field.Cells.Should().BeEquivalentTo(resultState);
        }

        [Theory]
        [InlineData(Direction.Left)]
        [InlineData(Direction.Up)]
        public void MoveCell_WrongDirection_ThrownWrongDirectionException(Direction direction)
        {
            //Arrange
            stateFixture.fieldInfo.Object.Field.Cells = stateFixture.cells;
            //Act
            //Assert
            Assert.Throws<WrongMoveDirectionException>(() => gameController.MoveCell(direction));
        }

        [Fact]
        public void SaveState_Success_FieldAddedToFieldHistory()
        {
            //Arrange
            //Act
            gameController.SaveFieldState();
            //Assert
            Assert.NotNull(stateFixture.fieldInfo.Object.FieldHistory.PopState());
        }

        [Fact]
        public void ResetState_Success_FieldResetedFromFieldHistory()
        {
            //Arrange
            stateFixture.fieldInfo.Object.Field = new Field();
            stateFixture.fieldInfo.Object.FieldHistory.AddState(new FieldMemento(stateFixture.cells));
            //Act
            gameController.UndoFieldState();
            //Assert
            stateFixture.fieldInfo.Object.Field.Cells.Should().BeEquivalentTo(stateFixture.cells);
        }
    }

    public class MoveCellTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { Direction.Down, new Cell[,]{
                { new Cell{ Number = 1, Row = 0, Column = 0 }, new Cell{ Number = 0, Row = 0, Column = 1 } },
                { new Cell{ Number = 3, Row = 1, Column = 0 }, new Cell{ Number = 2, Row = 1, Column = 1 } } }
            };
            yield return new object[] { Direction.Right, new Cell[,]{
                { new Cell{ Number = 1, Row = 0, Column = 0 }, new Cell{ Number = 2, Row = 0, Column = 1 } },
                { new Cell{ Number = 0, Row = 1, Column = 0 }, new Cell{ Number = 3, Row = 1, Column = 1 } } }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
