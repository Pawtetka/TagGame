using System;

namespace TagGameBLL.Exceptions
{
    public class WrongSizeException : Exception
    {
        public WrongSizeException()
        {
        }

        public WrongSizeException(string message)
        {
        }

        public WrongSizeException(string message, Exception exception)
        {
        }
    }
}