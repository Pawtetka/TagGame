namespace TagGameBLL.Classes
{
    public class Field
    {
        private int[,] _winState;

        public Cell[,] Cells { get; set; } = new Cell[0, 0];

        public Cell GetEmptyCell()
        {
            foreach (var cell in Cells)
                if (cell.Number == 0)
                    return cell;
            return null;
        }

        public void SetWinState(int[,] winState)
        {
            _winState = winState;
        }

        public bool CheckWinState()
        {
            foreach (var cell in Cells)
                if (cell.Number != _winState[cell.Row, cell.Column])
                    return false;
            return true;
        }

        public FieldMemento SaveState()
        {
            return new FieldMemento(Cells);
        }

        public void RestoreState(FieldMemento memento)
        {
            Cells = memento.GetState();
        }
    }
}