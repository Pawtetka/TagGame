namespace TagGameConsole
{
    public interface IView
    {
        int FieldSize { get; }
        int Difficult { get; }
        int Direction { get; }
        void ShowMenu();
        void ShowField(int[,] numbers);
        void ShowWinMenu();

        event View.Handler OnGameStarted;
        event View.Handler OnMoveSelected;
        event View.Handler OnUndoMove;
    }
}