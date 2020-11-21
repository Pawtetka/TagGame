using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Exceptions
{
    public class WrongMoveDirectionException : Exception
    {
        public WrongMoveDirectionException() { }

        public WrongMoveDirectionException(string message) : base() { }

        public WrongMoveDirectionException(string message, Exception exception) : base() { }
    }
}
