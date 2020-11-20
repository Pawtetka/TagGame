using System;
using System.Collections.Generic;
using System.Text;

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
            return history.Pop();
        }
    }
}
