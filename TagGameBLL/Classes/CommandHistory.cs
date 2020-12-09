using System;
using System.Collections.Generic;
using System.Text;
using TagGameBLL.Exceptions;

namespace TagGameBLL.Classes
{
    public class CommandHistory
    {
        private Stack<ICommand> commands;
        public CommandHistory()
        {
            commands = new Stack<ICommand>();
        }

        public void SaveCommand(ICommand command)
        {
            commands.Push(command);
        }

        public ICommand GetCommand()
        {
            if (commands.Count == 0)
            {
                throw new EmptyHistoryException("History is empty");
            }
            return commands.Pop();
        }
    }
}
