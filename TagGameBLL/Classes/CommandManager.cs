using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class CommandManager
    {
        private ICommand _moveCellCommand;
        private ICommand _startGameCommand;

        public void StartGame(int size, Difficult difficult)
        {
            SetStartGameCommand(size, difficult);
            _startGameCommand.Execute();
        }

        public void MoveCell(Direction direction, GameController gameController)
        {
            SetMoveCellCommand(direction, gameController);
            _moveCellCommand.Execute();
        }

        public void UndoAction(GameController gameController)
        {
            _moveCellCommand.Undo();
        }

        public void SetStartGameCommand(int size, Difficult difficult)
        {
            _startGameCommand = new StartGameCommand(size, difficult, new FieldCreator());
        }

        public void SetMoveCellCommand(Direction direction, GameController gameController)
        {
            _moveCellCommand = new MoveCellCommand(direction, gameController);
        }
    }
}
