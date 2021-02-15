using FluentAssertions;
using TagGameBLL.Classes;
using TagGameBLL.Exceptions;
using Xunit;

namespace TagGameBLLTests
{
    public class CommandHistoryTests
    {
        [Fact]
        public void GetCommand_EmptyHistory_ThrowsEmptyHistoryException()
        {
            //Arrange
            var commandHistory = new CommandHistory();
            //Act
            void Action() => commandHistory.GetCommand();
            //Assert
            Assert.Throws<EmptyHistoryException>(Action);
        }

        [Fact]
        public void UPDATED_GetCommand_EmptyHistory_ThrowsEmptyHistoryException() => new CommandHistory()
            .Invoking(x => x.GetCommand()).Should().Throw<EmptyHistoryException>();
    }
}