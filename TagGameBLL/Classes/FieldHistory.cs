using System.Collections.Generic;
using TagGameBLL.Exceptions;

namespace TagGameBLL.Classes
{
    public class FieldHistory
    {
        private readonly Stack<FieldMemento> _history;

        public FieldHistory()
        {
            _history = new Stack<FieldMemento>();
        }

        public void AddState(FieldMemento memento)
        {
            _history.Push(memento);
        }

        public FieldMemento PopState()
        {
            if (_history.Count == 0) throw new EmptyHistoryException("History is empty");
            return _history.Pop();
        }
    }
}