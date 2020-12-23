using TagGameBLL.Interfaces;

namespace TagGameBLL.Classes
{
    public class MoveCellCommand : ICommand
    {
        private readonly Direction _direction;
        private readonly GameController _gameController;

        public MoveCellCommand(Direction direction, GameController gameController)
        {
            _direction = direction;
            _gameController = gameController;
        }

        public void Execute()
        {
            _gameController.SaveFieldState();
            _gameController.MoveCell(_direction);
        }

        public void Undo()
        {
            _gameController.UndoFieldState();
        }
    }
}