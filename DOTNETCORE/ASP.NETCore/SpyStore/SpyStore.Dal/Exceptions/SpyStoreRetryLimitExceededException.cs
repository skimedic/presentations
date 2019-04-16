using System;

namespace SpyStore.Dal.Exceptions
{
    public class SpyStoreRetryLimitExceededException : SpyStoreException
    {
        public SpyStoreRetryLimitExceededException() { }
        public SpyStoreRetryLimitExceededException(string message) : base(message) { }
        public SpyStoreRetryLimitExceededException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}