// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - CustomRetryLimitExceededException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
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