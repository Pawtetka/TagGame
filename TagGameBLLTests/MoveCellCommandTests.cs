using Moq;
using TagGameBLL.Classes;
using Xunit;

namespace TagGameBLLTests
{
    public class MoveCellCommandTests
    {
        private readonly Mock<GameController> _mock;

        public MoveCellCommandTests()
        {
            _mock = new Mock<GameController>(new FieldInfo());
        }

        [Theory]
        [InlineData(Direction.Down)]
        public void Execute_Success_MoveCellMethodTriggered(Direction direction)
        {
            //Arrange
            var command = new MoveCellCommand(direction, _mock.Object);
            //Act
            command.Execute();
            //Assert
            _mock.Verify(controller => controller.MoveCell(direction));
        }
    }
}