using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class Cell
    {
        public int Number { get; set; } = 0;
        /*public bool IsSelected { get; set; } = false;*/

        public Cell() { }
        public Cell(int number)
        {
            Number = number;       
        }
    }
}
