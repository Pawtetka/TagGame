using TagGameBLL.Interfaces;

namespace TagGameBLL.Classes
{
    public class StandartGameController : GameController
    {
        public StandartGameController(IFieldInfo fieldInfo) : base(fieldInfo)
        {
        }

        public override void MoveCell(Direction moveDirection)
        {
            var emptyCell = FieldInfo.Field.GetEmptyCell();
            var moveCell = ChooseMovingCell(emptyCell.Row, emptyCell.Column, moveDirection);
            FieldInfo.Field.GetEmptyCell().Number = moveCell.Number;
            FieldInfo.Field.Cells[moveCell.Row, moveCell.Column].Number = 0;
        }
    }
}