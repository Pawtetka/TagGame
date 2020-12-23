using TagGameBLL.Exceptions;
using TagGameBLL.Interfaces;

namespace TagGameBLL.Classes
{
    public abstract class GameController
    {
        protected IFieldInfo FieldInfo;

        protected GameController()
        {
        }

        protected GameController(IFieldInfo fieldInfo)
        {
            FieldInfo = fieldInfo;
        }

        public abstract void MoveCell(Direction moveDirection);

        protected Cell ChooseMovingCell(int row, int column, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (row + 1 < FieldInfo.Field.Cells.GetUpperBound(0) + 1)
                        return FieldInfo.Field.Cells[row + 1, column];
                    else throw new WrongMoveDirectionException("Wrong direction!");
                case Direction.Down:
                    if (row > 0)
                        return FieldInfo.Field.Cells[row - 1, column];
                    else throw new WrongMoveDirectionException("Wrong direction!");
                case Direction.Right:
                    if (column > 0)
                        return FieldInfo.Field.Cells[row, column - 1];
                    else throw new WrongMoveDirectionException("Wrong direction!");
                case Direction.Left:
                    if (column + 1 < FieldInfo.Field.Cells.GetUpperBound(0) + 1)
                        return FieldInfo.Field.Cells[row, column + 1];
                    else throw new WrongMoveDirectionException("Wrong direction!");
            }

            throw new WrongMoveDirectionException("Wrong direction!");
        }


        public void SaveFieldState()
        {
            FieldInfo.FieldHistory.AddState(FieldInfo.Field.SaveState());
        }

        public void UndoFieldState()
        {
            FieldInfo.Field.RestoreState(FieldInfo.FieldHistory.PopState());
        }
    }
}