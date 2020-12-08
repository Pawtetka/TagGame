using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TagGameBLL.Classes;
using TagGameBLL.Exceptions;
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
            var gameManager = new GameManager(new CommandManager());
            //Act
            //Accert
            Assert.Throws<WrongDifficultException>(() => gameManager.StartGame(0, difficult));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void StartGame_WrongSize_ThrowsWrongSizeException(int size)
        {
            //Arrange
            var gameManager = new GameManager(new CommandManager());
            //Act
            //Accert
            Assert.Throws<WrongSizeException>(() => gameManager.StartGame(size, 1));
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(5, 3)]
        public void StartGame_Success_MethodTriggered(int size, int difficult)
        {
            //Arrange
            var mock = new Mock<ICommandManager>();
            ICommand command = new StartGameCommand(size, (Difficult)difficult, new FieldCreator());
            mock.Setup(manager => manager.CreateStartGameCommand(It.IsAny<int>(), It.IsAny<Difficult>(), It.IsAny<IFieldCreator>())).
                 Returns(command);
            var gameManager = new GameManager(mock.Object);
            //Act
            gameManager.StartGame(size, difficult);
            //Accert
            mock.Verify(manager => manager.StartGame(command));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(4)]
        public void MoveCell_WrongMoveDirection_ThrowWrongMoveDirectionException(int direction)
        {
            //Arrange
            var gameManager = new GameManager(new CommandManager());
            //Act
            //Accert
            Assert.Throws<WrongMoveDirectionException>(() => gameManager.MoveCell(direction));
        }

        [Theory]
        [InlineData(0)]
        public void MoveCell_Success_MethodTriggered(int direction)
        {
            //Arrange
            var mock = new Mock<ICommandManager>();
            ICommand command = new MoveCellCommand((Direction)direction, new StandartGameController());
            mock.Setup(manager => manager.SetMoveCellCommand(It.IsAny<Direction>(), It.IsAny<GameController>())).
                 Returns(command);
            var gameManager = new GameManager(mock.Object);
            //Act
            gameManager.MoveCell(direction);
            //Accert
            mock.Verify(manager => manager.MoveCell(command));
        }


    }
}
