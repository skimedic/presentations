using System;

namespace AutoLot.Dal.Models.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException() { }
        public CustomException(string message) : base(message) { }
        public CustomException(string message, Exception innerException)
            : base(message, innerException) { }
    }
    public class CustomConcurrencyException : Exception
    {
        public CustomConcurrencyException() { }
        public CustomConcurrencyException(string message) : base(message) { }
        public CustomConcurrencyException(string message, Exception innerException)
            : base(message, innerException) { }
    }
    public class CustomRetryLimitExceededException : Exception
    {
        public CustomRetryLimitExceededException() { }
        public CustomRetryLimitExceededException(string message) : base(message) { }
        public CustomRetryLimitExceededException(string message, Exception innerException)
            : base(message, innerException) { }

    }
}
