using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TagGameBLL.Classes;
using Xunit;

namespace TagGameBLLTests
{
    public class MoveCellCommandTests
    {
        private Mock<GameController> mock;
        public MoveCellCommandTests()
        {
            mock = new Mock<GameController>(new FieldInfo());
        }
        [Theory]
        [InlineData(Direction.Down)]
        public void Execute_Success_MoveCellMethodTriggered(Direction direction)
        {
            //Arrange
            var command = new MoveCellCommand(direction, mock.Object);
            //Act
            command.Execute();
            //Assert
            mock.Verify(controller => controller.MoveCell(direction));
        }
    }
}
