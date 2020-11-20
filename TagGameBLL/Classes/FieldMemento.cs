using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class FieldMemento
    {
        private Cell[,] _cellsState;

        public FieldMemento(Cell[,] cells)
        {
            _cellsState = cells;
        }

        public Cell[,] GetState()
        {
            return _cellsState;
        }
    }
}
