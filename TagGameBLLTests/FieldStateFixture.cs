using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TagGameBLL.Classes;

namespace TagGameBLLTests
{
    public class FieldStateFixture
    {
        public Cell[,] cells;
        public Mock<IFieldInfo> fieldInfo;
        private Field field;
        private FieldHistory fieldHistory;
        //private int fieldSize;
        public FieldStateFixture()
        {
            cells = new Cell[,]{
                { new Cell{ Number = 1, Row = 0, Column = 0 }, new Cell{ Number = 2, Row = 0, Column = 1 } },
                { new Cell{ Number = 3, Row = 1, Column = 0 }, new Cell{ Number = 0, Row = 1, Column = 1 } }
            };
            fieldInfo = new Mock<IFieldInfo>();
            field = new Field();
            fieldHistory = new FieldHistory();
            fieldInfo.Setup(info => info.Field).Returns(field);
            fieldInfo.Setup(info => info.FieldHistory).Returns(fieldHistory);
            //fieldInfo.Setup(info => info.FieldSize).Returns(fieldSize);
        }
    }
}
