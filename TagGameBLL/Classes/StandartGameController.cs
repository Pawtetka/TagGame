using System;
using System.Collections.Generic;
using System.Text;
using TagGameBLL.Exceptions;

namespace TagGameBLL.Classes
{
    public class StandartGameController : GameController
    {
        public StandartGameController() : base() { }
        public StandartGameController(IFieldInfo fieldInfo) : base(fieldInfo) { }
        public override void MoveCell(Direction moveDirection)
        {
            Cell emptyCell = _fieldInfo.Field.GetEmptyCell();
            Cell moveCell = ChooseMovingCell(emptyCell.Row, emptyCell.Column, moveDirection);
            _fieldInfo.Field.GetEmptyCell().Number = moveCell.Number;
            _fieldInfo.Field.Cells[moveCell.Row, moveCell.Column].Number = 0;
        }
    }
}
