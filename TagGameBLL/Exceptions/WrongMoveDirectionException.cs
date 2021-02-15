using System;
using System.Runtime.Serialization;

namespace TagGameBLL.Exceptions
{
    [Serializable]
    public class WrongMoveDirectionException : Exception
    {
        public WrongMoveDirectionException()
        {
        }

        public WrongMoveDirectionException(string message) 
            : base(message)
        {
        }

        public WrongMoveDirectionException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected WrongMoveDirectionException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}