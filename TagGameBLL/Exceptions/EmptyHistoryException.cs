using System;

namespace TagGameBLL.Exceptions
{
    public class EmptyHistoryException : Exception
    {
        public EmptyHistoryException()
        {
        }

        public EmptyHistoryException(string message)
        {
        }

        public EmptyHistoryException(string message, Exception exception)
        {
        }
    }
}