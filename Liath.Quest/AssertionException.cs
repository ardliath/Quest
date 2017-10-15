using System;
using System.Runtime.Serialization;

namespace Liath.Quest
{
    /// <summary>
    /// The exception which is thrown by Fail Assertions
    /// </summary>
    [Serializable]
    public class AssertionException : Exception
    {
        public AssertionException()
        {
        }

        public AssertionException(string message)
            : base(message)
        {
        }

        public AssertionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected AssertionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}