using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public interface IFieldCreator
    {
        void GenerateField(int size, Difficult difficult);
        void DeleteField();
    }
}
