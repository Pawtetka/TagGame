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
        private FieldInfo _fieldInfo;

        public GameManager(ICommandManager commandManager)
        {
            _commandManager = commandManager;
            _fieldInfo = FieldInfo.GetInstance();
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
            var command = _commandManager.CreateStartGameCommand(size, (Difficult)difficult, new FieldCreator());
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
            _gameController = _gameControllerCreator.CreateController();
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
            _commandManager.UndoAction(_gameController);
        }

        public int[,] GetField()
        {
            int[,] field = new int[_fieldInfo.FieldSize, _fieldInfo.FieldSize];
            for (int row = 0; row < _fieldInfo.FieldSize; row++)
            {
                for (int column = 0; column < _fieldInfo.FieldSize; column++)
                {
                    field[row, column] = _fieldInfo.Field.GetCell(row, column).Number;
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
