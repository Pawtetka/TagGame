using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Exceptions
{
    public class WrongDifficultException : Exception
    {
        public WrongDifficultException() { }

        public WrongDifficultException(string message) : base() { }

        public WrongDifficultException(string message, Exception exception) : base() { }
    }
}
