using System;
using System.Collections.Generic;
using System.Text;
using TagGameBLL.Exceptions;

namespace TagGameBLL.Classes
{
    public class FieldHistory
    {
        private Stack<FieldMemento> history;

        public FieldHistory()
        {
            history = new Stack<FieldMemento>();
        }

        public void AddState(FieldMemento memento)
        {
            history.Push(memento);
        }

        public FieldMemento PopState()
        {
            if (history.Count == 0)
            {
                throw new EmptyHistoryException("History is empty");
            }
            return history.Pop();
        }
    }
}
