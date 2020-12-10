using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class Field
    {
        public Cell[,] Cells { get; set;} = new Cell[0,0];

        public Field() { }

        private int[,] _winState;

        public Field(int size)
        {
            Cells = new Cell[size,size];
        }

        public Cell GetEmptyCell()
        {
            foreach (Cell cell in Cells)
            {
                if (cell.Number == 0)
                {
                    return cell;
                }
            }
            return null;
        }

        public void SetWinState(int[,] winState)
        {
            _winState = winState;
        }

        public bool CheckWinState()
        {
            foreach (Cell cell in Cells)
            {
                if (cell.Number != _winState[cell.Row, cell.Column])
                {
                    return false;
                }
            }
            return true;
        }

        public FieldMemento SaveState()
        {
            return new FieldMemento(Cells);
        }

        public void RestoreState(FieldMemento memento)
        {
            Cells = memento.GetState();
        }
    }
}
