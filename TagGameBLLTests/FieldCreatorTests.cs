using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using TagGameBLL.Classes;
using FluentAssertions;

namespace TagGameBLLTests
{
    public class FieldCreatorTests
    {
        [Theory]
        [InlineData(2)]
        public void GenerateField_Success_FieldCreated(int size)
        {
            //Arrange
            var stateFixture = new FieldStateFixture();
            var fieldCreator = new FieldCreator(stateFixture.fieldInfo.Object);
            //Act
            fieldCreator.GenerateField(size, Difficult.Easy);
            //Assert
            Assert.Equal(stateFixture.fieldInfo.Object.Field.Cells.GetUpperBound(0) + 1, size);
            Assert.NotEmpty(stateFixture.fieldInfo.Object.Field.Cells);
        }

        [Fact]
        public void DeleteField_Success_FieldDeleted()
        {
            //Arrange
            var stateFixture = new FieldStateFixture();
            var fieldCreator = new FieldCreator(stateFixture.fieldInfo.Object);
            //Act
            fieldCreator.DeleteField();
            //Assert
            Assert.Empty(stateFixture.fieldInfo.Object.Field.Cells);
        }
    }
}
