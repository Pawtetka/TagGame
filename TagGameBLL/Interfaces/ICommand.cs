using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
