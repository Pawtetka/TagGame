namespace TagGameBLL.Interfaces
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}