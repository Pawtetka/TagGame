using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class FieldMemento
    {
        private int[,] _cellsState;

        public FieldMemento(Cell[,] cells)
        {
            _cellsState = new int[cells.GetLength(0), cells.GetLength(1)];
            foreach (Cell cell in cells)
            {
                _cellsState[cell.Row, cell.Column] = cell.Number;
            }
        }

        public Cell[,] GetState()
        {
            Cell[,] cells = new Cell[_cellsState.GetLength(0), _cellsState.GetLength(1)];
            for (int row = 0; row < _cellsState.GetLength(0); row++)
            {
                for (int column = 0; column < _cellsState.GetLength(1); column++)
                {
                    cells[row, column] = new Cell();
                    cells[row, column].Row = row;
                    cells[row, column].Column = column;
                    cells[row, column].Number = _cellsState[row, column];
                }
            }
            return cells;
        }
    }
}
