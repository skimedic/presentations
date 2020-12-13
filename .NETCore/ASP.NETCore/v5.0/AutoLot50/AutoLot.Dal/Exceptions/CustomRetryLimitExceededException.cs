// Copyright Information
// ==================================
// AutoLot50 - AutoLot.Dal - CustomRetryLimitExceededException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace AutoLot.Dal.Exceptions
{
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
}