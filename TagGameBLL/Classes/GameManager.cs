using System;
using System.Collections.Generic;
using System.Text;
using TagGameBLL.Exceptions;

namespace TagGameBLL.Classes
{
    public class GameManager : IGameManager
    {
        private ICommandManager _commandManager;
        private GameController _gameController;
        private GameControllerCreator _gameControllerCreator;
        private IFieldInfo _fieldInfo;

        public GameManager(ICommandManager commandManager, IFieldInfo fieldInfo)
        {
            _commandManager = commandManager;
            _fieldInfo = fieldInfo;
        }
        public void StartGame(int size, int difficult)
        {
            if (difficult < 0 || difficult > 3)
            {
                throw new WrongDifficultException("Wrong difficult");
            }
            if (size <= 0)
            {
                throw new WrongSizeException("Wrong size");
            }
            CreateController(difficult);
            var command = _commandManager.CreateStartGameCommand(size, (Difficult)difficult, new FieldCreator(_fieldInfo));
            _commandManager.StartGame(command);
        }

        private void CreateController(int difficult)
        {
            if (difficult == (int)Difficult.Bonus)
            {
                _gameControllerCreator = new BonusGameControllerCreator();
            }
            else
            {
                _gameControllerCreator = new StandartGameControllerCreator();
            }
            _gameController = _gameControllerCreator.CreateController(_fieldInfo);
        }

        public void MoveCell(int direction)
        {
            if (direction < 0 || direction > 3)
            {
                throw new WrongMoveDirectionException("Wrong direction");
            }
            var command = _commandManager.SetMoveCellCommand((Direction)direction, _gameController);
            _commandManager.MoveCell(command);
        }


        public void UndoAction()
        {
            _commandManager.UndoAction();
        }

        public int[,] GetField()
        {
            int[,] field = new int[_fieldInfo.Field.Cells.GetUpperBound(0) + 1, _fieldInfo.Field.Cells.GetUpperBound(0) + 1];
            for (int row = 0; row < _fieldInfo.Field.Cells.GetUpperBound(0) + 1; row++)
            {
                for (int column = 0; column < _fieldInfo.Field.Cells.GetUpperBound(0) + 1; column++)
                {
                    field[row, column] = _fieldInfo.Field.Cells[row, column].Number;
                }
            }
            return field;
        }

        public bool CheckWin()
        {
            return _fieldInfo.Field.CheckWinState();
        }
    }
}
