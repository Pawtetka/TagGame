using System;
using System.Collections.Generic;
using System.Text;
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
            //Assert
            Assert.Throws<EmptyHistoryException>(() => commandHistory.GetCommand());
        }
    }
}
