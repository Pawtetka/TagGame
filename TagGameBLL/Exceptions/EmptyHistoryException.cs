using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Exceptions
{
    public class EmptyHistoryException : Exception
    {
        public EmptyHistoryException() { }

        public EmptyHistoryException(string message) : base() { }

        public EmptyHistoryException(string message, Exception exception) : base() { }
    }
}
