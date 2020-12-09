using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public interface ICommandManager
    {
        void StartGame(ICommand command);
        void MoveCell(ICommand command);
        ICommand CreateStartGameCommand(int size, Difficult difficult, IFieldCreator fieldCreator);
        ICommand SetMoveCellCommand(Direction direction, GameController gameController);
        void UndoAction();
    }
}
