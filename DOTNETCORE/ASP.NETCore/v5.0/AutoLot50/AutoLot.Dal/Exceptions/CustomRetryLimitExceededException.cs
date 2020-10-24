// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - CustomRetryLimitExceededException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/08/08
// See License.txt for more information
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