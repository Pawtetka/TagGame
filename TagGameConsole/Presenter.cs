using TagGameBLL.Classes;
using TagGameBLL.Interfaces;

namespace TagGameConsole
{
    public class Presenter
    {
        private readonly IGameManager _gameManager;
        private readonly IView _view;

        public Presenter(IView v, IGameManager gameManager)
        {
            _view = v;
            _gameManager = gameManager;
            _view.OnGameStarted += StartGame;
            _view.OnMoveSelected += MoveCell;
            _view.OnUndoMove += UndoAction;
        }

        public void ShowMenu()
        {
            _view.ShowMenu();
        }

        private void StartGame()
        {
            _gameManager.StartGame(_view.FieldSize, _view.Difficult);
            if (_gameManager.CheckWin())
                _view.ShowWinMenu();
            else
                _view.ShowField(_gameManager.GetField());
        }

        private void MoveCell()
        {
            _gameManager.MoveCell(_view.Direction);
            if (_gameManager.CheckWin())
                _view.ShowWinMenu();
            else
                _view.ShowField(_gameManager.GetField());
        }

        private void UndoAction()
        {
            _gameManager.UndoAction();
            _view.ShowField(_gameManager.GetField());
        }
    }
}