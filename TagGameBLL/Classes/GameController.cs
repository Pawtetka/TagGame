using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    abstract public class GameController
    {
        protected FieldInfo _fieldInfo;

        public GameController()
        {
            _fieldInfo = FieldInfo.GetInstance();
        }
        abstract public void MoveCell(Direction moveDirection);

        protected Cell ChooseMovingCell(int row, int column, Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    if (row + 1 < _fieldInfo.FieldSize)
                    {
                        return _fieldInfo.Field.GetCell(row + 1, column);
                    }
                    else return null;
                case Direction.Up:
                    if (row > 0)
                    {
                        return _fieldInfo.Field.GetCell(row - 1, column);
                    }
                    else return null;
                case Direction.Right:
                    if (column > 0)
                    {
                        return _fieldInfo.Field.GetCell(row, column - 1);
                    }
                    else return null;
                case Direction.Left:
                    if (column + 1 < _fieldInfo.FieldSize)
                    {
                        return _fieldInfo.Field.GetCell(row, column + 1);
                    }
                    else return null;
            }
            return null;
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
