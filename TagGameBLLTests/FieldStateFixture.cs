using Moq;
using TagGameBLL.Classes;
using TagGameBLL.Interfaces;

namespace TagGameBLLTests
{
    public class FieldStateFixture
    {
        public Cell[,] Cells;

        public Mock<IFieldInfo> FieldInfo;
        public FieldStateFixture()
        {
            Cells = new[,]
            {
                {new Cell {Number = 1, Row = 0, Column = 0}, new Cell {Number = 2, Row = 0, Column = 1}},
                {new Cell {Number = 3, Row = 1, Column = 0}, new Cell {Number = 0, Row = 1, Column = 1}}
            };
            FieldInfo = new Mock<IFieldInfo>();
            var field = new Field();
            var fieldHistory = new FieldHistory();
            FieldInfo.Setup(info => info.Field).Returns(field);
            FieldInfo.Setup(info => info.FieldHistory).Returns(fieldHistory);
        }
    }
}