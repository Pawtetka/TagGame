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
        private FieldInfo _fieldInfo = FieldInfo.GetInstance();
        public void GenerateField(int size, Difficult difficult)
        {
            _fieldInfo.FieldSize = size;
            CreateCellsAndPool(size);
            FillCells(difficult);
            _fieldInfo.Field.SetCells(_cells);
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
            for (int row = 0; row < _fieldInfo.FieldSize; row++)
            {
                for (int column = 0; column < _fieldInfo.FieldSize; column++)
                {
                    _cells[row, column] = new Cell();
                    _cells[row, column].Row = row;
                    _cells[row, column].Column = column;

                    if (new Random().Next(0, 100) > _rndCoef)
                    {
                        _cells[row, column].Number = _numberPool[row * _fieldInfo.FieldSize + column];
                        _numberPool[row * _fieldInfo.FieldSize + column] = 0;
                    }
                }
            }

            _numberPool.RemoveAll(number => number == 0);

            for (int row = 0; row < _fieldInfo.FieldSize; row++)
            {
                for (int column = 0; column < _fieldInfo.FieldSize; column++)
                {
                    if (row == _fieldInfo.FieldSize - 1 && column == row)
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
            _winState = new int[_fieldInfo.FieldSize, _fieldInfo.FieldSize];
            for (int row = 0; row < _fieldInfo.FieldSize; row++)
            {
                for (int column = 0; column < _fieldInfo.FieldSize; column++)
                {
                    _winState[row, column] = row * _fieldInfo.FieldSize + column + 1;
                }
            }
            _winState[_fieldInfo.FieldSize - 1, _fieldInfo.FieldSize - 1] = 0;
        }

        public void DeleteField()
        {
            _fieldInfo.Field = new Field();
            _fieldInfo.FieldSize = 0;
        }
    }
}
