using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public interface IFieldInfo
    {
        Field Field { get; set; }
        FieldHistory FieldHistory { get; set; }
    }
}
