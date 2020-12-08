using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class CommandHistory
    {
        private Stack<ICommand> commands = new Stack<ICommand>();
        public void SaveCommand(ICommand command)
        {
            commands.Push(command);
        }

        public ICommand GetCommand()
        {
            return commands.Pop();
        }
    }
}
