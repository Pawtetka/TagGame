using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TagGameBLL.Classes;
using Xunit;

namespace TagGameBLLTests
{
    public class StartGameCommandTests
    {
        private Mock<IFieldCreator> mock;
        public StartGameCommandTests()
        {
            mock = new Mock<IFieldCreator>();
        }
        [Theory]
        [InlineData(3, Difficult.Easy)]
        public void Execute_Success_CreateFieldMethodTriggered(int size, Difficult difficult)
        {
            //Arrange
            var command = new StartGameCommand(size, difficult, mock.Object);
            //Act
            command.Execute();
            //Assert
            mock.Verify(creator => creator.GenerateField(size, difficult));
        }

        [Fact]
        public void Undo_Success_DeleteFieldMethodTriggered()
        {
            //Arrange
            var command = new StartGameCommand(3, Difficult.Easy, mock.Object);
            //Act
            command.Undo();
            //Assert
            mock.Verify(creator => creator.DeleteField());
        }
    }
}
