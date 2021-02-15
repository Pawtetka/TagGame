using Moq;
using TagGameBLL.Classes;
using TagGameBLL.Exceptions;
using TagGameBLL.Interfaces;
using Xunit;

namespace TagGameBLLTests
{
    public class GameManagerTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(4)]
        public void StartGame_WrongDifficult_ThrowsWrongDifficultException(int difficult)
        {
            //Arrange
            var gameManager = new GameManager(new CommandManager(), new FieldInfo());
            //Act
            //Assert
            Assert.Throws<WrongDifficultException>(() => gameManager.StartGame(0, difficult));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void StartGame_WrongSize_ThrowsWrongSizeException(int size)
        {
            //Arrange
            var gameManager = new GameManager(new CommandManager(), new FieldInfo());
            
            //Act
            //Assert
            Assert.Throws<WrongSizeException>(() => gameManager.StartGame(size, 1));
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(5, 3)]
        public void StartGame_Success_StartGameMethodTriggered(int size, int difficult)
        {
            //Arrange
            var mock = new Mock<ICommandManager>();
            ICommand command = new StartGameCommand(size, (Difficult) difficult, new FieldCreator());
            mock.Setup(manager =>
                    manager.CreateStartGameCommand(It.IsAny<int>(), It.IsAny<Difficult>(), It.IsAny<IFieldCreator>()))
                .Returns(command);
            var gameManager = new GameManager(mock.Object, new FieldInfo());
            //Act
            gameManager.StartGame(size, difficult);
            //Assert
            mock.Verify(manager => manager.StartGame(command));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(4)]
        public void MoveCell_WrongMoveDirection_ThrowWrongMoveDirectionException(int direction)
        {
            //Arrange
            var gameManager = new GameManager(new CommandManager(), new FieldInfo());
            //Act
            //Assert
            Assert.Throws<WrongMoveDirectionException>(() => gameManager.MoveCell(direction));
        }

        [Theory]
        [InlineData(0)]
        public void MoveCell_Success_MoveCellMethodTriggered(int direction)
        {
            //Arrange
            var mock = new Mock<ICommandManager>();
            ICommand command = new MoveCellCommand((Direction) direction, new StandartGameController(new FieldInfo()));
            mock.Setup(manager => manager.SetMoveCellCommand(It.IsAny<Direction>(), It.IsAny<GameController>()))
                .Returns(command);
            var gameManager = new GameManager(mock.Object, new FieldInfo());
            //Act
            gameManager.MoveCell(direction);
            //Assert
            mock.Verify(manager => manager.MoveCell(command));
        }

        [Fact]
        public void UndoAction_Success_UndoMethodTriggered()
        {
            //Arrange
            var mock = new Mock<ICommandManager>();
            var gameManager = new GameManager(mock.Object, new FieldInfo());
            //Act
            gameManager.UndoAction();
            //Assert
            mock.Verify(manager => manager.UndoAction());
        }

        [Fact]
        public void GetField_Success_FieldReturned()
        {
            //Arrange
            var gameManager = new GameManager(new CommandManager(), new FieldInfo());
            //Act
            var rezult = gameManager.GetField();
            //Assert
            Assert.NotNull(rezult);
        }

        [Fact]
        public void CheckWin_Success_BoolReturned()
        {
            //Arrange
            var fieldStub = new Field
            {
                Cells = new[,]
                {
                    {new Cell {Number = 1, Row = 0, Column = 0}, new Cell {Number = 2, Row = 0, Column = 1}},
                    {new Cell {Number = 3, Row = 1, Column = 0}, new Cell {Number = 0, Row = 1, Column = 1}}
                }
            };
            int[,] winStateStub =
            {
                {1, 2},
                {3, 0}
            };
            fieldStub.SetWinState(winStateStub);
            var fieldMock = new Mock<IFieldInfo>();
            fieldMock.Setup(info => info.Field).Returns(fieldStub);
            var gameManager = new GameManager(new CommandManager(), fieldMock.Object);
            //Act
            var rezult = gameManager.CheckWin();
            //Assert
            Assert.True(rezult);
        }
    }
}