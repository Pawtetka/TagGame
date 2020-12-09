using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class CommandManager : ICommandManager
    {
        private CommandHistory _commandHistory;
        public CommandManager()
        {
            _commandHistory = new CommandHistory();
        }

        public void StartGame(ICommand startGameCommand)
        {
            startGameCommand.Execute();
            _commandHistory.SaveCommand(startGameCommand);
        }

        public void MoveCell(ICommand moveCellCommand)
        {
            moveCellCommand.Execute();
            _commandHistory.SaveCommand(moveCellCommand);
        }

        public void UndoAction()
        {
            _commandHistory.GetCommand().Undo();
        }

        public ICommand CreateStartGameCommand(int size, Difficult difficult, IFieldCreator fieldCreator)
        {
            return new StartGameCommand(size, difficult, fieldCreator);
        }

        public ICommand SetMoveCellCommand(Direction direction, GameController gameController)
        {
            return new MoveCellCommand(direction, gameController);
        }
    }
}
