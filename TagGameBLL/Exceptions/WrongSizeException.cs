using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Exceptions
{
    public class WrongSizeException : Exception
    {
        public WrongSizeException() { }

        public WrongSizeException(string message) : base() { }

        public WrongSizeException(string message, Exception exception) : base() { }
    }
}
