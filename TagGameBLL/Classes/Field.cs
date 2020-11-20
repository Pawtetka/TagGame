using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class Field
    {
        private Cell[,] _cells;

        public Field() { }

        public Field(int size)
        {
            _cells = new Cell[size,size];
        }

        public Cell GetCell(int row, int column)
        {
            return _cells[row, column];
        }

        public Cell GetEmptyCell()
        {
            foreach (Cell cell in _cells)
            {
                if (cell.Number == 0)
                {
                    return cell;
                }
            }
            return null;
        }

        public void SetCells(Cell[,] cells)
        {
            _cells = cells;
        }

        public FieldMemento SaveState()
        {
            return new FieldMemento(_cells);
        }

        public void RestoreState(FieldMemento memento)
        {
            _cells = memento.GetState();
        }
    }
}
