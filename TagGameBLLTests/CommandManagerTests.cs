using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TagGameBLL.Classes;
using Xunit;

namespace TagGameBLLTests
{
    public class CommandManagerTests
    {
        [Fact]
        public void StartGame_Success_CommandExecuteTriggered()
        {
            //Arrange
            var mock = new Mock<ICommand>();
            var commandManager = new CommandManager();
            //Act
            commandManager.StartGame(mock.Object);
            //Assert
            mock.Verify(command => command.Execute());
        }

        [Fact]
        public void MoveCell_Success_CommandExecuteTriggered()
        {
            //Arrange
            var mock = new Mock<ICommand>();
            var commandManager = new CommandManager();
            //Act
            commandManager.MoveCell(mock.Object);
            //Assert
            mock.Verify(command => command.Execute());
        }

        [Theory]
        [ClassData(typeof(StartGameCommandTestData))]
        public void CreateStartGameCommand_Success_CommandReturned(int size, Difficult difficult, IFieldCreator fieldCreator)
        {
            //Arrange
            var commandManager = new CommandManager();
            //Act
            var result = commandManager.CreateStartGameCommand(size, difficult, fieldCreator);
            //Assert
            Assert.IsType<StartGameCommand>(result);
        }

        [Theory]
        [ClassData(typeof(MoveCellCommandTestData))]
        public void CreateMoveCellCommand_Success_CommandReturned(Direction direction, GameController gameController)
        {
            //Arrange
            var commandManager = new CommandManager();
            //Act
            var result = commandManager.SetMoveCellCommand(direction, gameController);
            //Assert
            Assert.IsType<MoveCellCommand>(result);
        }
    }

    public class StartGameCommandTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 3, Difficult.Easy, new FieldCreator() };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class MoveCellCommandTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { Direction.Down, new StandartGameController(new FieldInfo()) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
