// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal - CustomRetryLimitExceededException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Dal.Exceptions;

public class CustomRetryLimitExceededException : CustomException
{
    public CustomRetryLimitExceededException()
    {
    }

    public CustomRetryLimitExceededException(string message) : base(message)
    {
    }

    public CustomRetryLimitExceededException(string message, RetryLimitExceededException innerException)
        : base(message, innerException)
    {
    }
}