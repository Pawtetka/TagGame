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
        [Theory]
        [InlineData(3, Difficult.Easy)]
        public void Execute_Success_CreateFieldMethodTriggered(int size, Difficult difficult)
        {
            //Arrange
            var mock = new Mock<IFieldCreator>();
            var command = new StartGameCommand(size, difficult, mock.Object);
            //Act
            command.Execute();
            //Assert
            mock.Verify(creator => creator.GenerateField(size, difficult));
        }
    }
}
