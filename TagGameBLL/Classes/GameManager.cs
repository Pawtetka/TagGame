using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class GameManager : IGameManager
    {
        private CommandManager _commandManager;
        private GameController _gameController;
        private GameControllerCreator _gameControllerCreator;
        private FieldInfo _fieldInfo;

        public GameManager(CommandManager commandManager)
        {
            _commandManager = commandManager;
            _fieldInfo = FieldInfo.GetInstance();
        }
        public void StartGame(int size, int difficult)
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
            _commandManager.StartGame(size, (Difficult)difficult);
        }

        public void MoveCell(int direction)
        {
            _commandManager.MoveCell((Direction)direction, _gameController);
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
