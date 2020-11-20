using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class FieldInfo
    {
        private static FieldInfo _instance;

        public int FieldSize { get; set; }
        public Field Field { get; set; }
        public FieldHistory FieldHistory { get; set; }

        private FieldInfo()
        {
            Field = new Field();
            FieldHistory = new FieldHistory();
        }

        public static FieldInfo GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FieldInfo();
            }
            return _instance;
        }
    }
}
