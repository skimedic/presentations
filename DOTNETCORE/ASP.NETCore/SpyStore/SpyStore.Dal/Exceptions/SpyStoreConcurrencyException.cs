using System;

namespace SpyStore.Dal.Exceptions
{
    public class SpyStoreConcurrencyException : SpyStoreException
    {
        public SpyStoreConcurrencyException() { }
        public SpyStoreConcurrencyException(string message) : base(message) { }
        public SpyStoreConcurrencyException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}