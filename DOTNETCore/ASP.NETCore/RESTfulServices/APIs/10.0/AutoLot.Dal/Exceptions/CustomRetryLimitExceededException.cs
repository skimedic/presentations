// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Dal - CustomRetryLimitExceededException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/03
// ==================================

namespace AutoLot.Dal.Exceptions;

public class CustomRetryLimitExceededException : CustomException
{
    public CustomRetryLimitExceededException() { }
    public CustomRetryLimitExceededException(string message) : base(message) { }
    public CustomRetryLimitExceededException(
        string message, RetryLimitExceededException innerException) : base(message, innerException)
    {
    }
}