using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class FieldInfo : IFieldInfo
    {
        public Field Field { get; set; }
        public FieldHistory FieldHistory { get; set; }

        public FieldInfo()
        {
            Field = new Field();
            FieldHistory = new FieldHistory();
        }
    }
}
