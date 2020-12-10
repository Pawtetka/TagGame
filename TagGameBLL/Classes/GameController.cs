using System;
using System.Collections.Generic;
using System.Text;
using TagGameBLL.Exceptions;

namespace TagGameBLL.Classes
{
    abstract public class GameController
    {
        protected IFieldInfo _fieldInfo;

        public GameController() { }
        public GameController(IFieldInfo fieldInfo)
        {
            _fieldInfo = fieldInfo;
        }
        abstract public void MoveCell(Direction moveDirection);

        protected Cell ChooseMovingCell(int row, int column, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (row + 1 < _fieldInfo.Field.Cells.GetUpperBound(0) + 1)
                    {
                        return _fieldInfo.Field.Cells[row + 1, column];
                    }
                    else throw new WrongMoveDirectionException("Wrong direction!");
                case Direction.Down:
                    if (row > 0)
                    {
                        return _fieldInfo.Field.Cells[row - 1, column];
                    }
                    else throw new WrongMoveDirectionException("Wrong direction!");
                case Direction.Right:
                    if (column > 0)
                    {
                        return _fieldInfo.Field.Cells[row, column - 1];
                    }
                    else throw new WrongMoveDirectionException("Wrong direction!");
                case Direction.Left:
                    if (column + 1 < _fieldInfo.Field.Cells.GetUpperBound(0) + 1)
                    {
                        return _fieldInfo.Field.Cells[row, column + 1];
                    }
                    else throw new WrongMoveDirectionException("Wrong direction!");
                default:
                    break;
            }
            throw new WrongMoveDirectionException("Wrong direction!");
        }


        public void SaveFieldState()
        {
            _fieldInfo.FieldHistory.AddState(_fieldInfo.Field.SaveState());
        }

        public void UndoFieldState()
        {
            _fieldInfo.Field.RestoreState(_fieldInfo.FieldHistory.PopState());
        }
    }
}
