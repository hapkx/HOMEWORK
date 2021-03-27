using System;
using System.Runtime.Serialization;

namespace B
{
    [Serializable]
    internal class InValidException : Exception
    {
        private int hour;
        private int minute;
        private int second;

        public InValidException()
        {
        }

        public InValidException(string message) : base(message)
        {
        }

        public InValidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InValidException(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        protected InValidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}