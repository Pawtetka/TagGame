using TagGameBLL.Interfaces;

namespace TagGameBLL.Classes
{
    public class StartGameCommand : ICommand
    {
        private readonly Difficult _difficult;
        private readonly IFieldCreator _fieldCreator;
        private readonly int _size;

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