using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public interface IGameManager
    {
        void StartGame(int size, int difficult);
        void MoveCell(int direction);
        void UndoAction();
        int[,] GetField();
        bool CheckWin();
    }
}
