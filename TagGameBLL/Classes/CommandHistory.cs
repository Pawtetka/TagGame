using System.Collections.Generic;
using TagGameBLL.Exceptions;
using TagGameBLL.Interfaces;

namespace TagGameBLL.Classes
{
    public class CommandHistory
    {
        private readonly Stack<ICommand> _commands;

        public CommandHistory()
        {
            _commands = new Stack<ICommand>();
        }

        public void SaveCommand(ICommand command)
        {
            _commands.Push(command);
        }

        public ICommand GetCommand()
        {
            if (_commands.Count == 0) throw new EmptyHistoryException("History is empty");
            return _commands.Pop();
        }
    }
}