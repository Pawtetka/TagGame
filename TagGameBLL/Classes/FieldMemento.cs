namespace TagGameBLL.Classes
{
    public class FieldMemento
    {
        private readonly int[,] _cellsState;

        public FieldMemento(Cell[,] cells)
        {
            _cellsState = new int[cells.GetLength(0), cells.GetLength(1)];
            foreach (var cell in cells) _cellsState[cell.Row, cell.Column] = cell.Number;
        }

        public Cell[,] GetState()
        {
            var cells = new Cell[_cellsState.GetLength(0), _cellsState.GetLength(1)];
            for (var row = 0; row < _cellsState.GetLength(0); row++)
            {
                for (var column = 0; column < _cellsState.GetLength(1); column++)
                {
                    cells[row, column] = new Cell();
                    cells[row, column].Row = row;
                    cells[row, column].Column = column;
                    cells[row, column].Number = _cellsState[row, column];
                }
            }

            return cells;
        }
    }
}