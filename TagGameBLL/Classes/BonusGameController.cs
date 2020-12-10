using System;
using System.Collections.Generic;
using System.Text;
using TagGameBLL.Exceptions;

namespace TagGameBLL.Classes
{
    public class BonusGameController : GameController
    {
        private int rndMoveFrequency = 10;
        public BonusGameController() : base() { }
        public BonusGameController(IFieldInfo fieldInfo) : base(fieldInfo) { }
        public override void MoveCell(Direction moveDirection)
        {
            if (new Random().Next(0, 100) < rndMoveFrequency)
            {
                for (int i = 0; i < CountRndMovesAmount(); i++)
                {
                    DoRndMove((Direction)CountRndMoveDirection());
                }
            }
            else
            {
                Cell emptyCell = _fieldInfo.Field.GetEmptyCell();
                Cell moveCell = ChooseMovingCell(emptyCell.Row, emptyCell.Column, moveDirection);
                _fieldInfo.Field.GetEmptyCell().Number = moveCell.Number;
                _fieldInfo.Field.Cells[moveCell.Row, moveCell.Column].Number = 0;
            }
        }

        private int CountRndMovesAmount()
        {
            return new Random().Next(1, 5);
        }

        private int CountRndMoveDirection()
        {
            return new Random().Next(0, 4);
        }

        private void DoRndMove(Direction moveDirection)
        {
            Cell emptyCell = _fieldInfo.Field.GetEmptyCell();
            Cell moveCell = new Cell();
            try
            {
                moveCell = ChooseMovingCell(emptyCell.Row, emptyCell.Column, moveDirection);
            }
            catch (WrongMoveDirectionException e)
            {
                DoRndMove((Direction)CountRndMoveDirection());
                return;
            }
            _fieldInfo.Field.GetEmptyCell().Number = moveCell.Number;
            _fieldInfo.Field.Cells[moveCell.Row, moveCell.Column].Number = 0;
        }
    }
}
