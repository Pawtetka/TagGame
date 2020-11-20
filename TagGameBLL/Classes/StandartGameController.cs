using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class StandartGameController : GameController
    {
        public override void MoveCell(Direction moveDirection)
        {
            Cell emptyCell = _fieldInfo.Field.GetEmptyCell();
            Cell moveCell = ChooseMovingCell(emptyCell.Row, emptyCell.Column, moveDirection);
            _fieldInfo.Field.GetEmptyCell().Number = moveCell.Number;
            _fieldInfo.Field.GetCell(moveCell.Row, moveCell.Column).Number = 0;
        }

    }
}
