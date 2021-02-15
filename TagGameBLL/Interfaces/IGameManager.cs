namespace TagGameBLL.Interfaces
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