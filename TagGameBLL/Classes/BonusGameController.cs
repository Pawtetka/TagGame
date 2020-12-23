using System;
using TagGameBLL.Exceptions;
using TagGameBLL.Interfaces;

namespace TagGameBLL.Classes
{
    public class BonusGameController : GameController
    {
        private const int RndMoveFrequency = 10;

        public BonusGameController(IFieldInfo fieldInfo) : base(fieldInfo)
        {
        }

        public override void MoveCell(Direction moveDirection)
        {
            if (new Random().Next(0, 100) < RndMoveFrequency)
            {
                for (var i = 0; i < CountRndMovesAmount(); i++) DoRndMove((Direction) CountRndMoveDirection());
            }
            else
            {
                var emptyCell = FieldInfo.Field.GetEmptyCell();
                var moveCell = ChooseMovingCell(emptyCell.Row, emptyCell.Column, moveDirection);
                FieldInfo.Field.GetEmptyCell().Number = moveCell.Number;
                FieldInfo.Field.Cells[moveCell.Row, moveCell.Column].Number = 0;
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
            var emptyCell = FieldInfo.Field.GetEmptyCell();
            Cell moveCell;
            try
            {
                moveCell = ChooseMovingCell(emptyCell.Row, emptyCell.Column, moveDirection);
            }
            catch (WrongMoveDirectionException e)
            {
                DoRndMove((Direction) CountRndMoveDirection());
                return;
            }

            FieldInfo.Field.GetEmptyCell().Number = moveCell.Number;
            FieldInfo.Field.Cells[moveCell.Row, moveCell.Column].Number = 0;
        }
    }
}