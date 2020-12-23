using Moq;
using TagGameBLL.Classes;
using TagGameBLL.Interfaces;
using Xunit;

namespace TagGameBLLTests
{
    public class StartGameCommandTests
    {
        private readonly Mock<IFieldCreator> _mock;

        public StartGameCommandTests()
        {
            _mock = new Mock<IFieldCreator>();
        }

        [Theory]
        [InlineData(3, Difficult.Easy)]
        public void Execute_Success_CreateFieldMethodTriggered(int size, Difficult difficult)
        {
            //Arrange
            var command = new StartGameCommand(size, difficult, _mock.Object);
            //Act
            command.Execute();
            //Assert
            _mock.Verify(creator => creator.GenerateField(size, difficult));
        }

        [Fact]
        public void Undo_Success_DeleteFieldMethodTriggered()
        {
            //Arrange
            var command = new StartGameCommand(3, Difficult.Easy, _mock.Object);
            //Act
            command.Undo();
            //Assert
            _mock.Verify(creator => creator.DeleteField());
        }
    }
}