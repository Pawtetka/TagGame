using TagGameBLL.Classes;
using Xunit;

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
            var fieldCreator = new FieldCreator(stateFixture.FieldInfo.Object);
            //Act
            fieldCreator.GenerateField(size, Difficult.Easy);
            //Assert
            Assert.Equal(stateFixture.FieldInfo.Object.Field.Cells.GetUpperBound(0) + 1, size);
            Assert.NotEmpty(stateFixture.FieldInfo.Object.Field.Cells);
        }

        [Fact]
        public void DeleteField_Success_FieldDeleted()
        {
            //Arrange
            var stateFixture = new FieldStateFixture();
            var fieldCreator = new FieldCreator(stateFixture.FieldInfo.Object);
            //Act
            fieldCreator.DeleteField();
            //Assert
            Assert.Empty(stateFixture.FieldInfo.Object.Field.Cells);
        }
    }
}