using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class StartGameCommand : ICommand
    {
        private int _size;
        private Difficult _difficult;
        private IFieldCreator _fieldCreator;

        public StartGameCommand(int size, Difficult difficult, IFieldCreator fieldCreator)
        {
            _size = size;
            _difficult = difficult;
            _fieldCreator = fieldCreator;
        }
        public void Execute()
        {
            _fieldCreator.GenerateField(_size, _difficult);
        }

        public void Undo()
        {
            _fieldCreator.DeleteField();
        }
    }
}
