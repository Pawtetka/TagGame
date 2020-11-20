using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class StandartGameController : GameController
    {
        public override void MoveCell(Direction moveDirection)
        {
            for (int row = 0; row < _fieldInfo.FieldSize; row++)
            {
                for (int column = 0; column < _fieldInfo.FieldSize; column++)
                {
                    if (_fieldInfo.Field.GetCell(row, column).Number == 0)
                    {
                        DoMove(row, column, moveDirection);
                    }
                }
            }
        }

        protected void DoMove(int row, int column, Direction direction)
        {
            Cell moveCell = new Cell();
            Cell emptyCell = _fieldInfo.Field.GetCell(row, column);
            switch (direction)
            {
                case Direction.Left:
                    if (row + 1 < _fieldInfo.FieldSize)
                    {
                        moveCell = _fieldInfo.Field.GetCell(row + 1, column);
                    }
                    else return;
                    break;
                case Direction.Right:
                    if (row > 0)
                    {
                        moveCell = _fieldInfo.Field.GetCell(row - 1, column);
                    }
                    else return;
                    break;
                case Direction.Up:
                    if (column > 0)
                    {
                        moveCell = _fieldInfo.Field.GetCell(row, column - 1);
                    }
                    else return;
                    break;
                case Direction.Down:
                    if (column + 1 < _fieldInfo.FieldSize)
                    {
                        moveCell = _fieldInfo.Field.GetCell(row, column + 1);
                    }
                    else return;
                    break;
            }
            emptyCell.Number = moveCell.Number;
            moveCell.Number = 0;
        }
    }
}
