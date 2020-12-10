using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class FieldCreator : IFieldCreator
    {
        private Cell[,] _cells;
        private int[,] _winState;
        private int _rndCoef;
        private List<int> _numberPool;
        private IFieldInfo _fieldInfo;
        public FieldCreator() { }
        public FieldCreator(IFieldInfo fieldInfo)
        {
            _fieldInfo = fieldInfo;
        }
        public void GenerateField(int size, Difficult difficult)
        {
            CreateCellsAndPool(size);
            FillCells(difficult);
            _fieldInfo.Field.Cells = _cells;
            CountWinState();
            _fieldInfo.Field.SetWinState(_winState);
            if (_fieldInfo.Field.CheckWinState())
            {
                GenerateField(size, difficult);
            }
        }

        private void CreateCellsAndPool(int size)
        {
            _cells = new Cell[size, size];
            _numberPool = new List<int>();
            for (int i = 1; i < size * size; i++)
            {
                _numberPool.Add(i);
            }
            _numberPool.Add(0);
        }

        private void FillCells(Difficult difficult)
        {
            CountRndCoef(difficult);
            for (int row = 0; row < _cells.GetUpperBound(0) + 1; row++)
            {
                for (int column = 0; column < _cells.GetUpperBound(0) + 1; column++)
                {
                    _cells[row, column] = new Cell();
                    _cells[row, column].Row = row;
                    _cells[row, column].Column = column;

                    if (new Random().Next(0, 100) > _rndCoef)
                    {
                        _cells[row, column].Number = _numberPool[row * (_cells.GetUpperBound(0) + 1) + column];
                        _numberPool[row * (_cells.GetUpperBound(0) + 1) + column] = 0;
                    }
                }
            }

            _numberPool.RemoveAll(number => number == 0);

            for (int row = 0; row < _cells.GetUpperBound(0) + 1; row++)
            {
                for (int column = 0; column < _cells.GetUpperBound(0) + 1; column++)
                {
                    if (row == _cells.GetUpperBound(0) && column == row)
                    {
                        _cells[row, column].Number = 0;
                    }
                    else if (_cells[row, column].Number == 0)
                    {
                        _cells[row, column].Number = _numberPool[new Random().Next(0, _numberPool.Count - 1)];
                        _numberPool.Remove(_cells[row, column].Number);
                    }
                }
            }
        }

        private void CountRndCoef(Difficult difficult)
        {
            switch (difficult)
            {
                case Difficult.Easy:
                    _rndCoef = 50;
                    break;
                case Difficult.Medium:
                    _rndCoef = 65;
                    break;
                case Difficult.Hard:
                    _rndCoef = 80;
                    break;
                case Difficult.Bonus:
                    _rndCoef = 80;
                    break;
            }
        }

        private void CountWinState()
        {
            _winState = new int[_cells.GetUpperBound(0) + 1, _cells.GetUpperBound(0) + 1];
            for (int row = 0; row < _cells.GetUpperBound(0) + 1; row++)
            {
                for (int column = 0; column < _cells.GetUpperBound(0) + 1; column++)
                {
                    _winState[row, column] = row *(_cells.GetUpperBound(0) + 1) + column + 1;
                }
            }
            _winState[_cells.GetUpperBound(0), _cells.GetUpperBound(0)] = 0;
        }

        public void DeleteField()
        {
            _fieldInfo.Field = new Field();
        }
    }
}
